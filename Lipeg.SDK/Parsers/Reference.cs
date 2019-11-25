using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Parsers
{
    public class Reference : IParser
    {
        protected Reference(string name, Identifier identifier, Func<IParser> parser)
        {
            Name = name;
            Identifier = identifier;
            Parser = parser;
        }

        public string Name { get; }
        public Identifier Identifier { get; }
        public Func<IParser> Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            return Parser().Parse(cursor);
        }

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"{Identifier.Name}");
        }
    }
}
