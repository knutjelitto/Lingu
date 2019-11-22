using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
#pragma warning disable CA1716 // Identifiers should not match keywords
#pragma warning disable CA1720 // Identifier contains type name
    public abstract class Single : IParser
#pragma warning restore CA1720 // Identifier contains type name
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        protected Single(string name, IParser parser)
        {
            Name = name;
            Parser = parser;
        }
        public string Name { get; }
        public IParser Parser { get; }
        public abstract IResult Parse(ICursor cursor);
        public IEnumerator<IParser> GetEnumerator() => Enumerable.Repeat(Parser, 1).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
