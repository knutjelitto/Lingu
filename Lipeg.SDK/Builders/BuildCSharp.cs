using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Lipeg.Runtime;
using Lipeg.Runtime.Tools;
using Lipeg.SDK.Output;
using Lipeg.SDK.Parsers;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Builders
{
    public class BuildCSharp : IBuildPass
    {
        private class Config
        {
            public Config(Grammar grammar)
            {
                Grammar = grammar;
            }

            public Grammar Grammar { get; }

            public readonly bool Disable = true;
            public readonly string Namespace = "Lipeg.Generated";
            public string ParserClass => $"{Capa(Grammar.Name)}Parser";

            [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Scheiß drauf")]
            public IEnumerable<string> Usings => new[] { "Lipeg.Runtime" };

            public string Capa(Identifier id)
            {
                Debug.Assert(Grammar != null);

                var parts = id.Name.Split('-', '.');
                var builder = new StringBuilder();
                foreach (var part in parts)
                {
                    builder.Append(char.ToUpperInvariant(part[0]) + part.Substring(1));
                }

                return builder.ToString();
            }
        }

        public BuildCSharp(Grammar grammar, FileRef outFile)
        {
            Grammar = grammar;
            OutFile = outFile;
            Cfg = new Config(Grammar);
        }

        public Grammar Grammar { get; }
        public FileRef OutFile { get; }
        private Config Cfg { get; }

        public void Build()
        {
            var writer = new CsWriter();

            if (Cfg.Disable) writer.WriteLine("#if false");

            new Visitor(writer, Cfg, Grammar).Visit();

            if (Cfg.Disable) writer.WriteLine("#endif");

            writer.Persist(OutFile);
        }

        private class Visitor : TreeVisitor
        {
            private readonly List<IParser> parsers = new List<IParser>();
            private readonly Func<IParser> spacer;

            public Visitor(CsWriter writer, Config cfg, Grammar grammar)
                : base(grammar)
            {
                spacer = () => Grammar.Attr.Spacing.Attr.Parser;
                Writer = writer;
                Cfg = cfg;
            }

            public CsWriter Writer { get; }
            public Config Cfg { get; }

            public void Visit()
            {
                Writer.Block($"namespace {Cfg.Namespace}", () =>
                {
                    foreach (var @using in Cfg.Usings)
                    {
                        Writer.WriteLine($"using {@using};");
                    }
                    Writer.WriteLine();
                    Writer.Block($"public partial class {Cfg.ParserClass}", () =>
                    {
                        VisitGrammarRules();
                    });
                });
            }

            private IReadOnlyList<IParser> Pop(int start)
            {
                var subs = parsers.Skip(start).Take(parsers.Count - start).ToArray();
                parsers.RemoveRange(start, parsers.Count - start);

                return subs;
            }

            private IParser Pop()
            {
                var parser = parsers[parsers.Count - 1];
                parsers.RemoveAt(parsers.Count - 1);
                return parser;
            }

            private void Push(IParser parser)
            {
                parsers.Add(parser);
            }

            private IParser Peek()
            {
                return parsers[parsers.Count - 1];
            }

            protected override void VisitRule(IRule rule)
            {
                Writer.WriteLine($"// {rule.Identifier} -> {Cfg.Capa(rule.Identifier)}");
                Writer.Block($"public IResult {Cfg.Capa(rule.Identifier)}(IContext context)", () =>
                {
                    Writer.WriteLine("throw new System.NotImplementedException();");
                });
            }

            public override void VisitExpression(Expression expression)
            {
                if (expression == null) throw new ArgumentNullException(nameof(expression));

                base.VisitExpression(expression);

                if (expression.Attr.IsWithSpacing && !(Peek() is Space))
                {
                    Push(new Space(spacer, Pop()));
                }
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                var start = parsers.Count;

                base.VisitChoiceExpression(expression);

                var parser = new Choice(Pop(start));

                parsers.Add(parser);
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                var start = parsers.Count;

                base.VisitSequenceExpression(expression);

                var parser = new Sequence(Pop(start));
                Push(parser);
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                Push(new SingleChar(expression.Value));
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                var start = parsers.Count;

                base.VisitClassExpression(expression);

                var parser = new Choice(Pop(start));
                parsers.Add(parser);
            }

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                Push(new CharRange(expression.Min, expression.Max));
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                base.VisitDropExpression(expression);

                Push(Drop.From(Pop()));
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                base.VisitFuseExpression(expression);

                Push(new Fuse(Pop()));
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                base.VisitLiftExpression(expression);

                Push(new Lift(Pop()));
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                Push(new Name(() => Grammar.Attr.Rules[expression.Identifier.Name].Attr.Parser, expression.Identifier));
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Push(new Name(() => Grammar.Attr.Rules[expression.Rule.Identifier.Name].Attr.Parser, expression.Rule.Identifier));
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                base.VisitAndExpression(expression);

                var inner = Pop();

                Push(new And(inner));
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                base.VisitNotExpression(expression);

                var inner = Pop();

                Push(new Not(inner));
            }

            protected override void VisitOptionalExpression(OptionalExpression optional)
            {
                VisitExpression(optional.Expression);
                Push(new Parsers.Optional(Pop()));
            }

            protected override void VisitPlusExpression(PlusExpression plus)
            {
                VisitExpression(plus.Expression);
                Push(new Plus(Pop()));
            }

            protected override void VisitStarExpression(StarExpression star)
            {
                VisitExpression(star.Expression);
                Push(new Star(Pop()));
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                Push(new CharSequence(expression.Value));
            }

            protected override void VisitAnyExpression(AnyExpression expression)
            {
                Push(new Any());
            }

            // >===>

            public override void VisitGrammar()
            {
                base.VisitGrammar();
            }

            protected override void VisitGrammarLexicalRules()
            {
                base.VisitGrammarLexicalRules();
            }

            public override void VisitGrammarOptions()
            {
                base.VisitGrammarOptions();
            }

            protected override void VisitGrammarSyntaxRules()
            {
                base.VisitGrammarSyntaxRules();
            }

            protected override void VisitOption(Option option)
            {
                base.VisitOption(option);
            }
        }
    }
}
