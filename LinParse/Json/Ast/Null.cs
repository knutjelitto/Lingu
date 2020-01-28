using LinParse.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse.Json.Ast
{
    public class Null : Value
    {
        public Null(SourceSpan span)
            : base(span)
        {
        }
    }
}
