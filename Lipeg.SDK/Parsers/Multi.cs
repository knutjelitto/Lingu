using System;
using System.Collections.Generic;

using Lipeg.Runtime;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Parsers
{
    public abstract class Multi : ICombiParser
    {
        protected Multi(string name, IReadOnlyList<ICombiParser> parsers)
        {
            Kind = name;
            Parsers = parsers;
        }
        public string Kind { get; }
        public IReadOnlyList<ICombiParser> Parsers { get; }

        public abstract void Dump(int level, IWriter writer);

        public abstract IResult Parse(IContext context);

        public override string ToString()
        {
            return $"({Kind} " + String.Join(" ", Parsers) + ")";
        }
    }
}
