using LinParse.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse.Json.Ast
{
    public abstract class Value
    {
        protected Value(SourceSpan span)
        {
            Span = span;
        }

        public SourceSpan Span { get; }
    }
}
