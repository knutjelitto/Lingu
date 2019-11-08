using System.Linq;

using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    /// <summary>
    /// Check if all rules are used
    /// </summary>
    public class CheckNullable : Check, ICheckPass
    {
        public CheckNullable(Semantic semantic)
        : base(semantic)
        {
        }

        public void Check()
        {
            var visitor = new CheckNullableVisitor(Semantic);

            visitor.Changed = true;
            while (visitor.Changed)
            {
                visitor.Changed = false;
                visitor.VisitGrammarRules();
            }
        }

        private class CheckNullableVisitor : TreeVisitor
        {
            public CheckNullableVisitor(Semantic semantic) : base(semantic) { }

            public bool Changed { get; set; }

            private void Set(Expression expression, bool nullable)
            {
                if (nullable && expression.Attributes.SetNullable())
                {
                    Changed = true;
                }
            }


            protected override void VisitAndExpression(AndExpression expression)
            {
                base.VisitAndExpression(expression);
                Set(expression, true);
            }

            protected override void VisitCharacter(CharacterExpression expression)
            {
                base.VisitCharacter(expression);
                Set(expression, false);
            }

            protected override void VisitCharacterRange(CharacterRangeExpression expression)
            {
                base.VisitCharacterRange(expression);
                Set(expression, false);
            }

            protected override void VisitChoiceExpression(ChoiceExpression expression)
            {
                base.VisitChoiceExpression(expression);
                foreach (var choice in expression.Choices)
                {
                    if (choice.Attributes.Nullable)
                    {
                        Set(expression, true);
                    }
                }
            }

            protected override void VisitCharacterClassExpression(CharacterClassExpression expression)
            {
                base.VisitCharacterClassExpression(expression);
                Set(expression, false);
            }

            protected override void VisitDropExpression(DropExpression expression)
            {
                base.VisitDropExpression(expression);
                Set(expression, expression.Expression.Attributes.Nullable);
            }

            protected override void VisitFuseExpression(FuseExpression expression)
            {
                base.VisitFuseExpression(expression);
                Set(expression, expression.Expression.Attributes.Nullable);
            }

            protected override void VisitLiteralExpression(LiteralExpression expression)
            {
                base.VisitLiteralExpression(expression);
                Set(expression, expression.Value.Length == 0);
            }

            protected override void VisitNameExpression(NameExpression expression)
            {
                base.VisitNameExpression(expression);
                if (Semantic.Rules.TryGetValue(expression.Identifier.Name, out var rule))
                {
                    Set(expression, rule?.Expression.Attributes.Nullable ?? false);
                }
            }

            protected override void VisitNotExpression(NotExpression expression)
            {
                base.VisitNotExpression(expression);
                Set(expression, expression.Expression.Attributes.Nullable);
            }

            protected override void VisitLiftExpression(LiftExpression expression)
            {
                base.VisitLiftExpression(expression);
                Set(expression, expression.Expression.Attributes.Nullable);
            }

            protected override void VisitQuantifiedExpression(QuantifiedExpression expression)
            {
                base.VisitQuantifiedExpression(expression);
                Set(expression, expression.Quantifier.Nullable || expression.Expression.Attributes.Nullable);
            }

            protected override void VisitSequenceExpression(SequenceExpression expression)
            {
                base.VisitSequenceExpression(expression);
                Set(expression, expression.Sequence.All(s => s.Attributes.Nullable));
            }

            protected override void VisitStringLiteral(StringLiteralExpression expression)
            {
                base.VisitStringLiteral(expression);
                Set(expression, expression.Value.Length == 0);
            }

            protected override void VisitWildcardExpression(WildcardExpression expression)
            {
                base.VisitWildcardExpression(expression);
                Set(expression, false);
            }
        }
    }
}
