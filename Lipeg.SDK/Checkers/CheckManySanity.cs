using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checkers
{
    /// <summary>
    /// Check if all X* or X+ rules have non-nullable X
    /// </summary>
    public class CheckManySanity : ACheckBase, ICheckPass
    {
        public CheckManySanity(Semantic semantic)
            : base(semantic)
        {
        }

        public void Check()
        {
            new Visitor(Semantic).VisitGrammarRules();
        }

        private class Visitor : TreeVisitor
        {
            public Visitor(Semantic semantic) : base(semantic) { }

            protected override void VisitStarExpression(StarExpression expression)
            {
                base.VisitStarExpression(expression);
                if (Semantic[expression.Expression].IsNullable)
                {
                    Results.AddError(new CheckError(ErrorCode.NullableManyContent, expression));
                }
            }

            protected override void VisitPlusExpression(PlusExpression expression)
            {
                base.VisitPlusExpression(expression);
                if (Semantic[expression.Expression].IsNullable)
                {
                    Results.AddError(new CheckError(ErrorCode.NullableManyContent, expression));
                }
            }
        }
    }
}
