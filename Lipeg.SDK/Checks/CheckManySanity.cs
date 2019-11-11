using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Checks
{
    /// <summary>
    /// Check if all X* or X+ rules have non-nullable X
    /// </summary>
    public class CheckManySanity : Check, ICheckPass
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

            protected override void VisitQuantifiedExpression(QuantifiedExpression expression)
            {
                if (expression.Quantifier.Many && Semantic[expression.Expression].Nullable)
                {
                    Results.AddError(new CheckError(ErrorCode.NullableManyContent, expression));
                }
                base.VisitQuantifiedExpression(expression);
            }
        }
    }
}
