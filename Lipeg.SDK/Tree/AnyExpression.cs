using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class AnyExpression : SimpleExpression
    {
        private AnyExpression(ILocated located)
            : base(located)
        {
        }

        public static AnyExpression From(ILocated located)
        {
            return new AnyExpression(located);
        }
    }
}
