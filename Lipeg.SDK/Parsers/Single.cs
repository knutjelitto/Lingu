﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lipeg.Runtime;
using Lipeg.SDK.Output;

namespace Lipeg.SDK.Parsers
{
    public abstract class Single : ICombiParser
    {
        protected Single(string name, ICombiParser parser)
        {
            Kind = name;
            Parser = parser;
        }
        public string Kind { get; }
        public ICombiParser Parser { get; }

        public abstract IResult Parse(IContext context);

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"({Kind} ");
            Parser.Dump(level + 1, writer);
            writer.Write(")");
        }

        public override string ToString()
        {
            return $"({Kind} {Parser})";
        }
    }
}
