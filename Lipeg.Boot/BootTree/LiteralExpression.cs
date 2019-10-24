using Pegasus.Common;

namespace Lipeg.Boot.BootTree
{
    public class LiteralExpression : Expression
    {
        private LiteralExpression(Cursor start, Cursor end, string value)
        {
            Start = start;
            End = end;
            Value = value;
        }

        public static LiteralExpression From(Cursor start, Cursor end, string value)
        {
            return new LiteralExpression(start, end, value);
        }

        public Cursor Start { get; }
        public Cursor End { get; }
        public string Value { get; }
    }
}
