using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lipeg.Runtime;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Parsers
{
    public abstract class Single : IParser
    {
        protected Single(string name, IParser parser)
        {
            Name = name;
            Parser = parser;
        }
        public string Name { get; }
        public IParser Parser { get; }

        public abstract IResult Parse(ICursor cursor);

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"({Name} ");
            Parser.Dump(level + 1, writer);
            writer.Write(")");
        }
    }
}
