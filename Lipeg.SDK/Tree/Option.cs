using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Option
    {
        private Option(Identifier identifier, object value)
        {
            Identifier = identifier;
            Value = value;
        }
        public Identifier Identifier { get; }
        public object Value { get; }

        public static Option From(Identifier identifier, object value)
        {
            return new Option(identifier, value);
        }

        public override string ToString()
        {
            return $"[{Identifier}={Value}]";
        }
    }
}
