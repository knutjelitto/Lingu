using System;
using System.Collections.Generic;

using Lipeg.Runtime;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Parsers
{
    public abstract class Multi : IParser
    {
        protected Multi(string name, IReadOnlyList<IParser> parsers)
        {
            Kind = name;
            Parsers = parsers;
        }
        public string Kind { get; }
        public IReadOnlyList<IParser> Parsers { get; }

        public abstract void Dump(int level, IWriter writer);

        public abstract IResult Parse(ICursor cursor);

        public override string ToString()
        {
            return $"({Kind} " + String.Join(" ", Parsers) + ")";
        }
    }
}
