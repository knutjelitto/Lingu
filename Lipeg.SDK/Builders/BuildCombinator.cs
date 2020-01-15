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
        public BuildCombinator(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Build()
        {
            new Visitor(Grammar).Visit();
        }

        private class Visitor : TreeVisitor
        {
            private readonly List<Parsers.ICombiParser> parsers = new List<Parsers.ICombiParser>();
            private readonly Func<Parsers.ICombiParser> spacer;

            public Visitor(Grammar grammar)
                : base(grammar)
            {
                spacer = () => (Parsers.ICombiParser)Grammar.Attr.Spacing.Attr.Parser;
            }

            public void Visit()
            {
                VisitGrammarRules();

                Debug.Assert(parsers.Count == 0);
            }

            private IReadOnlyList<Parsers.ICombiParser> Pop(int start)
            {
                var subs = parsers.Skip(start).Take(parsers.Count - start).ToArray();
                parsers.RemoveRange(start, parsers.Count - start);

                return subs;
            }

            private Parsers.ICombiParser Pop()
            {
                var parser = parsers[parsers.Count - 1];
                parsers.RemoveAt(parsers.Count - 1);
                return parser;
            }

            private void Push(Parsers.ICombiParser parser)
            {
                parsers.Add(parser);
            }

            private Parsers.ICombiParser Peek()
            {
                return parsers[parsers.Count - 1];
            }

            protected override void VisitRule(IRule rule)
            {
                base.VisitRule(rule);

                Debug.Assert(parsers.Count == 1);

                rule.Attr.SetParser(Pop());
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
                Push(new Name(() => (Parsers.ICombiParser)Grammar.Attr.Rules[expression.Identifier.Name].Attr.Parser, expression.Identifier));
            }

            protected override void VisitInlineExpression(InlineExpression expression)
            {
                Push(new Name(() => (Parsers.ICombiParser)Grammar.Attr.Rules[expression.Rule.Identifier.Name].Attr.Parser, expression.Rule.Identifier));
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
        }
    }
}
