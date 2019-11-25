using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Parsers;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Builders
{
    public class BuildCombinator : IBuildPass
    {
        public BuildCombinator(Semantic semantic)
        {
            Semantic = semantic;
        }

        public Semantic Semantic { get; }

        public void Build()
        {
            new Visitor(Semantic).Visit();
        }

        private class Visitor : TreeVisitor
        {
            private readonly List<IParser> parsers = new List<IParser>();
            private readonly IParser spacer;

            public Visitor(Semantic semantic)
                : base(semantic)
            {
                spacer = new Space(() => Grammar.Attr(Semantic).Spacing.Attr(Semantic).Parser);
            }

            public void Visit()
            {
                VisitGrammarRules();

                Debug.Assert(parsers.Count == 0);
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

            public override void VisitExpression(Expression expression)
            {
                if (expression == null) throw new ArgumentNullException(nameof(expression));

                base.VisitExpression(expression);

                if (expression.Attr(Semantic).IsWithSpacing)
                {
                    Push(new Sequence(spacer, Pop()));
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
                parsers.Add(parser);
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
                
                Push(new Drop(Pop()));
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
                Push(new Name(() => Semantic[Semantic.Rules[expression.Identifier.Name]].Parser, expression.Identifier));
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Push(new Name(() => Semantic[Semantic.Rules[expression.Rule.Identifier.Name]].Parser, expression.Rule.Identifier));
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
                Push(new Parsers.Option(Pop()));
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

            public override void VisitGrammarRules()
            {
                base.VisitGrammarRules();
            }

            protected override void VisitGrammarSyntaxRules()
            {
                base.VisitGrammarSyntaxRules();
            }

            protected override void VisitOption(Tree.Option option)
            {
                base.VisitOption(option);
            }

            protected override void VisitRule(IRule rule)
            {
                base.VisitRule(rule);

                Debug.Assert(parsers.Count == 1);

                rule.Attr(Semantic).SetParser(Pop());
            }
        }
    }
}
