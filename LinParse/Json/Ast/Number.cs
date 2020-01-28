using LinParse.Common;
using System.Globalization;

namespace LinParse.Json.Ast
{
    public class Number : Value
    {
        public Number(SourceSpan span)
            : base(span)
        {
            try
            {
                Value = double.Parse(span.Value, NumberStyles.Float);
            }
            catch
            {
                Value = 0;
            }
        }

        public double Value { get; }
    }
}
