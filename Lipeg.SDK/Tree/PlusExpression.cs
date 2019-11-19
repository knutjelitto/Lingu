using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class PlusExpression : WithInnerExpression
    {
        private PlusExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static PlusExpression From(ILocated located, Expression expression)
        {
            return new PlusExpression(located, expression);
        }
    }
}
