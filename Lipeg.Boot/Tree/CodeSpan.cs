using System;
using System.Collections.Generic;
using System.Text;
using Pegasus.Common;

namespace Lipeg.Boot.Tree
{
    public class CodeSpan
    {
        public CodeSpan(string code, Cursor start, Cursor end, string? value = null)
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

        public override string? ToString() => Value;
    }
}
