using Lipeg.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Parsers
{
    public class Reference : IParser
    {
        protected Reference(string name, Func<IParser> parser)
        {
            Name = name;
            Parser = parser;
        }

        public string Name { get; }
        public Func<IParser> Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            return Parser().Parse(cursor);
        }

        public IEnumerator<IParser> GetEnumerator() => Enumerable.Empty<IParser>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
