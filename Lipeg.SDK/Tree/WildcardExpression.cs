using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class WildcardExpression : SimpleExpression
    {
        private WildcardExpression(ILocated located)
            : base(located)
        {
        }

        public static WildcardExpression From(ILocated located)
        {
            return new WildcardExpression(located);
        }
    }
}
