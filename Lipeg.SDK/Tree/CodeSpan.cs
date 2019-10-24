using System;
using System.Collections.Generic;
using System.Text;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class CodeSpan
    {
        private CodeSpan(ILocation location, string code, string? value)
        {
            Code = code;
            Location = location;
            Value = value ?? code;
        }

        public string Code { get; }
        public ILocation Location { get; }
        public string? Value { get; }

        public static CodeSpan From(ILocation location, string code, string? value = null)
        {
            return new CodeSpan(location, code, value);
        }

        public override string? ToString() => Value;
    }
}
