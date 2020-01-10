using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check if all X* or X+ rules have non-nullable X
    /// </summary>
    public class CheckManySanity : CheckBase, ICheckPass
    {
        public CheckManySanity(Grammar grammar)
            : base(grammar)
        {
        }

        public void Check()
        {
            new Visitor(Grammar).VisitGrammarRules();
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Grammar grammar) : base(grammar) { }

            protected override void VisitStarExpression(StarExpression expression)
            {
                base.VisitStarExpression(expression);
                if (expression.Expression.Attr.IsNullable)
                {
                    Results.AddError(new MessageError(MessageCode.NullableManyContent, expression));
                }
            }

            protected override void VisitPlusExpression(PlusExpression expression)
            {
                base.VisitPlusExpression(expression);
                if (expression.Expression.Attr.IsNullable)
                {
                    Results.AddError(new MessageError(MessageCode.NullableManyContent, expression));
                }
            }
        }
    }
}
