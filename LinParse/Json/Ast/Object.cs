using System.Collections.Generic;
using System.Linq;

using LinParse.Common;

namespace LinParse.Json.Ast
{
    public class Object : Value
    {
        public Object(SourceSpan span, IEnumerable<Member> members)
            : base(span)
        {
            Members = members.ToArray();
        }

        public IReadOnlyList<Member> Members { get; }
    }
}
