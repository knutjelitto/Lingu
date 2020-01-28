using System.Collections.Generic;
using System.Linq;

using LinParse.Common;

namespace LinParse.Json.Ast
{
    public class Array : Value
    {
        public Array(SourceSpan span, IEnumerable<Value> values)
            : base(span)
        {
            Values = values.ToArray();
        }

        public IReadOnlyList<Value> Values { get; }
    }
}
