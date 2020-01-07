using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class StarExpression : SuffixExpression
    {
        private StarExpression(ILocated located, Expression expression)
            : base(located, expression)
        {
        }

        public static StarExpression From(ILocated located, Expression expression)
        {
            return new StarExpression(located, expression);
        }
    }
}
