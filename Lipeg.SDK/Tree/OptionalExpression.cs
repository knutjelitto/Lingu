using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class OptionalExpression : WithInnerExpression
    {
        private OptionalExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static OptionalExpression From(ILocated located, Expression expression)
        {
            return new OptionalExpression(located, expression);
        }
    }
}
