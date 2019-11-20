using System.Diagnostics;
using System.Linq;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check which rules are ``terminal´´ (sole lexical)
    /// </summary>
    public class CheckIsLexical : ACheckBase, ICheckPass
    {
        public CheckIsLexical(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            var visitor = new Visitor(Semantic);

            foreach (var rule in Grammar.LexicalRules)
            {
                rule.Attr(Semantic).SetIsLexical(true);
            }

            visitor.Changed = true;
            while (visitor.Changed)
            {
                visitor.Changed = false;
                visitor.VisitGrammarRules();
            }
        }

        private class Visitor : TreeVisitor
        {
            private bool changed;

            public Visitor(Semantic semantic) : base(semantic) { }

            public bool Changed
            {
                get => changed;
                set
                {
                    if (!changed && value)
                    {
                        Debug.Assert(true);
                    }
                    changed = value;
                }
            }

            private void SetIsLexical(Expression expression, bool isLexical)
            {
                if (expression.Attr(Semantic).SetIsLexical(isLexical))
                {
                    Changed = true;
                }
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                base.VisitAndExpression(expression);
                SetIsLexical(expression, expression.Expression.Attr(Semantic).IsLexical);
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                SetIsLexical(expression, true);
            }

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                SetIsLexical(expression, true);
            }
            protected override void VisitClassExpression(ClassExpression expression)
            {
                base.VisitClassExpression(expression);
                SetIsLexical(expression, true);
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                SetIsLexical(expression, expression.Value.Length > 0);
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                base.VisitChoiceExpression(expression);
                SetIsLexical(expression, expression.Choices.All(c => c.Attr(Semantic).IsLexical));
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                base.VisitDropExpression(expression);
                SetIsLexical(expression, false);
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                base.VisitFuseExpression(expression);
                SetIsLexical(expression, expression.Expression.Attr(Semantic).IsLexical);
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                base.VisitNameExpression(expression);
                if (Semantic.Rules.TryGetValue(expression.Identifier.Name, out var rule))
                {
                    if (rule == null) throw new InternalErrorException($"`{nameof(rule)}` can't be NULL");

                    SetIsLexical(expression, rule.Attr(Semantic).IsLexical);
                }
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                base.VisitNotExpression(expression);
                SetIsLexical(expression, expression.Expression.Attr(Semantic).IsLexical);
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                base.VisitLiftExpression(expression);
                SetIsLexical(expression, expression.Expression.Attr(Semantic).IsLexical);
            }

            protected override void VisitOptionalExpression(OptionalExpression expression)
            {
                base.VisitOptionalExpression(expression);
                SetIsLexical(expression, expression.Expression.Attr(Semantic).IsLexical);
            }

            protected override void VisitPlusExpression(PlusExpression expression)
            {
                base.VisitPlusExpression(expression);
                SetIsLexical(expression, expression.Expression.Attr(Semantic).IsLexical);
            }

            protected override void VisitStarExpression(StarExpression expression)
            {
                base.VisitStarExpression(expression);
                SetIsLexical(expression, expression.Expression.Attr(Semantic).IsLexical);
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                base.VisitSequenceExpression(expression);
                SetIsLexical(expression, expression.Sequence[0].Attr(Semantic).IsLexical);
            }
            protected override void VisitAnyExpression(AnyExpression expression)
            {
                base.VisitAnyExpression(expression);
                SetIsLexical(expression, true);
            }
        }
    }
}
