using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
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
            var visitor = new Visitor(Semantic);

            visitor.VisitGrammarRules();
        }

        private class Visitor : TreeVisitor
        {
            private List<IParser> parsers = new List<IParser>();

            public Visitor(Semantic semantic)
                : base(semantic)
            {
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

            protected override void VisitAndExpression(AndExpression expression)
            {
                base.VisitAndExpression(expression);
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                var start = parsers.Count;

                base.VisitChoiceExpression(expression);

                var parser = new Parsers.Choice(Pop(start));
                parsers.Add(parser);
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                base.VisitClassCharExpression(expression);
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                base.VisitClassExpression(expression);
            }

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                base.VisitClassRangeExpression(expression);
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                base.VisitDropExpression(expression);
                
                Push(new Parsers.Drop(Pop()));
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                base.VisitFuseExpression(expression);
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                base.VisitLiftExpression(expression);
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                var name = new Parsers.Name(() => Semantic[Semantic.Rules[expression.Identifier.Name]].Parser);
                Push(name);
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                base.VisitNotExpression(expression);
            }

            protected override void VisitQuantifiedExpression(QuantifiedExpression expression)
            {
                base.VisitQuantifiedExpression(expression);
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                var start = parsers.Count;

                base.VisitSequenceExpression(expression);

                var parser = new Parsers.Sequence(Pop(start));
                parsers.Add(parser);
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                var matcher = new Func<ICursor, IResult>(
                    (cursor) =>
                    {
                        if (cursor.Source.Part(cursor.Offset, expression.Value.Length) == expression.Value)
                        {
                        }
                        throw new NotImplementedException();
                    });
            }

            protected override void VisitWildcardExpression(WildcardExpression expression)
            {
                base.VisitWildcardExpression(expression);
            }

            // >===>

            protected override void VisitAliasExpression(AliasExpression expression)
            {
                base.VisitAliasExpression(expression);
            }

            public override void VisitGrammar()
            {
                base.VisitGrammar();
            }

            protected override void VisitGrammarLexical()
            {
                base.VisitGrammarLexical();
            }

            public override void VisitGrammarOptions()
            {
                base.VisitGrammarOptions();
            }

            public override void VisitGrammarRules()
            {
                base.VisitGrammarRules();
            }

            protected override void VisitGrammarSyntax()
            {
                base.VisitGrammarSyntax();
            }

            protected override void VisitOption(Option option)
            {
                base.VisitOption(option);
            }

            protected override void VisitRule(Rule rule)
            {
                base.VisitRule(rule);
            }

            public override void VisitExpression(Expression expression)
            {
                base.VisitExpression(expression);
            }
        }
    }
}
