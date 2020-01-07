using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class OptionalExpression : SuffixExpression
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
