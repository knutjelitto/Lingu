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
            private List<IParser> parsers = new List<IParser>();

            public Visitor(Semantic semantic)
                : base(semantic)
            {
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
                base.VisitClassCharExpression(expression);

                var matcher = new Func<ICursor, IResult>(
                    (cursor) =>
                    {
                        if (cursor.Current == expression.Value)
                        {
                            var next = cursor.Advance(1);
                            var location = Location.From(cursor, next);
                            return Result.Success(next, LeafNode.From(location, NodeSymbols.Any, ((char)cursor.Current).ToString(CultureInfo.InvariantCulture)));
                        }

                        return Result.Fail(cursor);
                    });

                Push(new Predicate(matcher));
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
                var matcher = new Func<ICursor, IResult>(
                    (cursor) =>
                    {
                        if (expression.Min <= cursor.Current && cursor.Current <= expression.Max)
                        {
                            var next = cursor.Advance(1);
                            var location = Location.From(cursor, next);
                            return Result.Success(next, LeafNode.From(location, NodeSymbols.CharacterLiteral, ((char)cursor.Current).ToString(CultureInfo.InvariantCulture)));
                        }
                        return Result.Fail(cursor);
                    });

                Push(new Predicate(matcher));
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
                Push(new Name(() => Semantic[Semantic.Rules[expression.Identifier.Name]].Parser));
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                base.VisitAndExpression(expression);

                var inner = Pop();

                var matcher = new Func<ICursor, IResult>(
                    (cursor) =>
                    {
                        var result = inner.Parse(cursor);
                        if (result.IsSuccess)
                        {
                            return Result.Success(cursor, LeafNode.From(Location.From(cursor), NodeSymbols.And));
                        }
                        return Result.Fail(cursor);
                    });

                Push(new Predicate(matcher));
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                base.VisitNotExpression(expression);

                var inner = Pop();

                var matcher = new Func<ICursor, IResult>(
                    (cursor) =>
                    {
                        var result = inner.Parse(cursor);
                        if (result.IsFail)
                        {
                            return Result.Success(cursor, LeafNode.From(Location.From(cursor), NodeSymbols.Not));
                        }
                        return Result.Fail(cursor);
                    });

                Push(new Predicate(matcher));
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
                var matcher = new Func<ICursor, IResult>(
                    (cursor) =>
                    {
                        if (cursor.Source.Part(cursor.Offset, expression.Value.Length) == expression.Value)
                        {
                            var next = cursor.Advance(expression.Value.Length);
                            var location = Location.From(cursor, next);
                            return Result.Success(next, LeafNode.From(location, NodeSymbols.StringLiteral, expression.Value));
                        }
                        return Result.Fail(cursor);
                    });

                Push(new Predicate(matcher));
            }

            protected override void VisitAnyExpression(AnyExpression expression)
            {
                base.VisitAnyExpression(expression);

                var matcher = new Func<ICursor, IResult>(
                    (cursor) =>
                    {
                        if (!cursor.AtEnd)
                        {
                            var next = cursor.Advance(1);
                            var location = Location.From(cursor, next);
                            return Result.Success(next, LeafNode.From(location, NodeSymbols.Any, ((char)cursor.Current).ToString(CultureInfo.InvariantCulture)));
                        }

                        return Result.Fail(cursor);
                    });

                Push(new Predicate(matcher));
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

            protected override void VisitRule(Rule rule)
            {
                base.VisitRule(rule);

                Debug.Assert(parsers.Count == 1);

                Semantic[rule].SetParser(Pop());
            }
        }
    }
}
