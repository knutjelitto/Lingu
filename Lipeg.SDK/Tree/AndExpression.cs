using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class AndExpression : PrefixExpression
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
