using System.Linq;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check if all rules are used
    /// </summary>
    public class CheckIsNullable : CheckBase, ICheckPass
    {
        public CheckIsNullable(Grammar grammar)
            : base(grammar)
        {
        }

        public void Check()
        {
            var visitor = new Visitor(Grammar);

            visitor.Changed = true;
            while (visitor.Changed)
            {
                visitor.Changed = false;
                visitor.VisitGrammarRules();
            }
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Grammar grammar) : base(grammar) { }

            public bool Changed { get; set; }

            private void SetNullable(Expression expression, bool nullable)
            {
                if (expression.Attr.SetIsNullable(nullable))
                {
                    Changed = true;
                }
            }

            private void SetNullable(IRule rule, bool nullable)
            {
                if (nullable && rule.Attr.SetIsNullable(nullable))
                {
                    Changed = true;
                }
            }

            protected override void VisitRule(IRule rule)
            {
                base.VisitRule(rule);
                SetNullable(rule, rule.Expression.Attr.IsNullable);
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
                    if (choice.Attr.IsNullable)
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
                SetNullable(expression, expression.Expression.Attr.IsNullable);
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                base.VisitFuseExpression(expression);
                SetNullable(expression, expression.Expression.Attr.IsNullable);
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                base.VisitNameExpression(expression);
                if (Grammar.Attr.Rules.TryGetValue(expression.Identifier.Name, out var rule))
                {
                    if (rule == null) throw new InternalNullException();

                    SetNullable(expression, rule.Attr.IsNullable);
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
                SetNullable(expression, expression.Expression.Attr.IsNullable);
            }

            protected override void VisitStarExpression(StarExpression expression)
            {
                base.VisitStarExpression(expression);
                SetNullable(expression, expression.Expression.Attr.IsNullable);
            }

            protected override void VisitPlusExpression(PlusExpression expression)
            {
                base.VisitPlusExpression(expression);
                SetNullable(expression, expression.Expression.Attr.IsNullable);
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                base.VisitSequenceExpression(expression);
                SetNullable(expression, expression.Sequence.All(expr => expr.Attr.IsNullable));
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
