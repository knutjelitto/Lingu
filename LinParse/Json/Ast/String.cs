using LinParse.Common;

namespace LinParse.Json.Ast
{
    public class String : Value
    {
        public String(SourceSpan span, string value)
            : base(span)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
