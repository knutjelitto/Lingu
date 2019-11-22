using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class PredicateParser : IParser
    {
        public PredicateParser(string name, Func<ICursor, IResult> matcher)
        {
            Name = name;
            Matcher = matcher;
        }
        public string Name { get; }
        public Func<ICursor, IResult> Matcher { get; }

        public IResult Parse(ICursor cursor)
        {
            return Matcher(cursor);
        }

        public IEnumerator<IParser> GetEnumerator() => Enumerable.Empty<IParser>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
