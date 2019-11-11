using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class StringLiteralExpression : SimpleExpression
    {
        private StringLiteralExpression(ILocated located, string value)
            : base(located)
        {
            Value = value;
        }
        public string Value { get; }

        public static StringLiteralExpression From(ILocated located, string value)
        {
            return new StringLiteralExpression(located, value);
        }
    }
}
