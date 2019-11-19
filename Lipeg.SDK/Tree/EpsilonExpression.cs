using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class EpsilonExpression : SimpleExpression
    {
        private EpsilonExpression(ILocated located)
            : base(located)
        {
        }

        public static EpsilonExpression From(ILocated located)
        {
            return new EpsilonExpression(located);
        }
    }
}
