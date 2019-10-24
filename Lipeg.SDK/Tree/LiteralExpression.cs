using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class LiteralExpression : Expression
    {
        private LiteralExpression(ILocation location, string value)
        {
            Location = location;
            Value = value;
        }

        public static LiteralExpression From(ILocation location, string value)
        {
            return new LiteralExpression(location, value);
        }

        public ILocation Location { get; }
        public string Value { get; }
    }
}
