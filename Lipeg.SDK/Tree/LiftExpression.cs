using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class LiftExpression : PrefixExpression
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
