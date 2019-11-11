using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class NotExpression : WithInnerExpression
    {
        private NotExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static NotExpression From(ILocated located, Expression expression)
        {
            return new NotExpression(located, expression);
        }
    }
}
