using System;
using System.Collections.Generic;
using System.Text;
using Pegasus.Common;

namespace Lipeg.Boot.BootTree
{
    public class CodeSpan
    {
        private CodeSpan(string code, Cursor start, Cursor end, string? value)
        {
            Code = code;
            Start = start;
            End = end;
            Value = value ?? code;
        }

        public string Code { get; }
        public Cursor End { get; }
        public Cursor Start { get; }
        public string? Value { get; }

        public static CodeSpan From(string code, Cursor start, Cursor end, string? value = null)
        {
            return new CodeSpan(code, start, end, value);
        }

        public override string? ToString() => Value;
    }
}
