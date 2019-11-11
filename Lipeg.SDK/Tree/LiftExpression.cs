using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class LiftExpression : WithInnerExpression
    {
        private LiftExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static LiftExpression From(ILocated located, Expression expression)
        {
            return new LiftExpression(located, expression);
        }
    }
}
