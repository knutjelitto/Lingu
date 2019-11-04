using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class StringLiteralExpression : Expression
    {
        private StringLiteralExpression(ILocation location, string value)
        {
            Location = location;
            Value = value;
        }

        public ILocation Location { get; }
        public string Value { get; }

        public static StringLiteralExpression From(ILocation location, string value)
        {
            return new StringLiteralExpression(location, value);
        }
    }
}
