using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class NameExpression : SimpleExpression
    {
        private NameExpression(ILocated located, Identifier identifier)
            : base(located)
        {
            Identifier = identifier;
        }

        public Identifier Identifier { get; }

        public static NameExpression From(ILocated located, Identifier identifier)
        {
            return new NameExpression(located, identifier);
        }
    }
}
