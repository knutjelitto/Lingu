using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class FuseExpression : PrefixExpression
    {
        private FuseExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static FuseExpression From(ILocated located, Expression expression)
        {
            return new FuseExpression(located, expression);
        }
    }
}
