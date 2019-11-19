using System.Linq;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check if all rules are used
    /// </summary>
    public class CheckNullable : ACheckBase, ICheckPass
    {
        public CheckNullable(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            var visitor = new Visitor(Semantic);

            visitor.Changed = true;
            while (visitor.Changed)
            {
                visitor.Changed = false;
                visitor.VisitGrammarRules();
            }
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Semantic semantic) : base(semantic) { }

            public bool Changed { get; set; }

            private void SetNullable(Expression expression, bool nullable)
            {
                if (Semantic[expression].SetIsNullable(nullable))
                {
                    Changed = true;
                }
            }

            private void SetNullable(Rule rule, bool nullable)
            {
                if (nullable && Semantic[rule].SetIsNullable(nullable))
                {
                    Changed = true;
                }
            }

            protected override void VisitRule(Rule rule)
            {
                base.VisitRule(rule);
                SetNullable(rule, Semantic[rule.Expression].IsNullable);
            }

            protected override void VisitAndExpression(AndExpression expression)
            {
                base.VisitAndExpression(expression);
                SetNullable(expression, true);
            }

            protected override void VisitClassCharExpression(ClassCharExpression expression)
            {
                base.VisitClassCharExpression(expression);
                SetNullable(expression, false);
            }

            protected override void VisitClassRangeExpression(ClassRangeExpression expression)
            {
                base.VisitClassRangeExpression(expression);
                SetNullable(expression, false);
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                base.VisitChoiceExpression(expression);
                foreach (var choice in expression.Choices)
                {
                    if (Semantic[choice].IsNullable)
                    {
                        SetNullable(expression, true);
                    }
                }
            }

            protected override void VisitClassExpression(ClassExpression expression)
            {
                base.VisitClassExpression(expression);
                SetNullable(expression, false);
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                base.VisitDropExpression(expression);
                SetNullable(expression, Semantic[expression.Expression].IsNullable);
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                base.VisitFuseExpression(expression);
                SetNullable(expression, Semantic[expression.Expression].IsNullable);
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                base.VisitNameExpression(expression);
                if (Semantic.Rules.TryGetValue(expression.Identifier.Name, out var rule))
                {
                    if (rule == null) throw new InternalErrorException($"`{nameof(rule)}` can't be NULL");

                    SetNullable(expression, Semantic[rule].IsNullable);
                }
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                base.VisitNotExpression(expression);
                SetNullable(expression, true);
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                base.VisitLiftExpression(expression);
                SetNullable(expression, Semantic[expression.Expression].IsNullable);
            }

            protected override void VisitStarExpression(StarExpression expression)
            {
                base.VisitStarExpression(expression);
                SetNullable(expression, Semantic[expression.Expression].IsNullable);
            }

            protected override void VisitPlusExpression(PlusExpression expression)
            {
                base.VisitPlusExpression(expression);
                SetNullable(expression, Semantic[expression.Expression].IsNullable);
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                base.VisitSequenceExpression(expression);
                SetNullable(expression, expression.Sequence.All(s => Semantic[s].IsNullable));
            }

            protected override void VisitStringLiteralExpression(StringLiteralExpression expression)
            {
                base.VisitStringLiteralExpression(expression);
                SetNullable(expression, expression.Value.Length == 0);
            }

            protected override void VisitAnyExpression(AnyExpression expression)
            {
                base.VisitAnyExpression(expression);
                SetNullable(expression, false);
            }
        }
    }
}
