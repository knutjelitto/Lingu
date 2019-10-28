using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class StringLiteral : Expression
    {
        private StringLiteral(ILocation location, string value)
        {
            Location = location;
            Value = value;
        }

        public ILocation Location { get; }
        public string Value { get; }

        public static StringLiteral From(ILocation location, string value)
        {
            return new StringLiteral(location, value);
        }
    }
}
