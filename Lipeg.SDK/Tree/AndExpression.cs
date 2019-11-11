using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class AndExpression : WithInnerExpression
    {
        private AndExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static AndExpression From(ILocated located, Expression expression)
        {
            return new AndExpression(located, expression);
        }
    }
}
