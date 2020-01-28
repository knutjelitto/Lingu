using LinParse.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse.Json.Ast
{
    public class Member : Value
    {
        public Member(SourceSpan span, String key, Value value)
            : base(span)
        {
            Key = key;
            Value = value;
        }

        public String Key { get; }
        public Value Value { get; }
    }
}
