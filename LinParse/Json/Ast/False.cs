using LinParse.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse.Json.Ast
{
    public class False : Value
    {
        public False(SourceSpan span)
            : base(span)
        {
        }
    }
}
