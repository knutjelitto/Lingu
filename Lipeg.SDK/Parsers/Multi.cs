using Lipeg.Runtime;
using System.Collections;
using System.Collections.Generic;

namespace Lipeg.SDK.Parsers
{
    public abstract class Multi : IParser
    {
        protected Multi(string name, IEnumerable<IParser> parsers)
        {
            Name = name;
            Parsers = parsers;
        }
        public string Name { get; }
        public IEnumerable<IParser> Parsers { get; }
        public abstract IResult Parse(ICursor cursor);

        public IEnumerator<IParser> GetEnumerator() => Parsers.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
