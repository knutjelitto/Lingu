using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class DropExpression : WithInnerExpression
    {
        private DropExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static DropExpression From(ILocated located, Expression expression)
        {
            return new DropExpression(located, expression);
        }
    }
}
