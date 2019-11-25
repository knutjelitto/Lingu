using System;
using System.Diagnostics;

using Lipeg.SDK.Output;
using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Parsers;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Dump
{
    public class DumpParser : IDump<Semantic>
    {
        public void Dump(IWriter writer, Semantic semantic)
        {
            if (writer == null) throw  new ArgumentNullException(nameof(writer));
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            new Visitor(semantic, writer).Dump();
        }

        private class Visitor
        {
            public Visitor(Semantic semantic, IWriter writer)
            {
                Semantic = semantic;
                Writer = writer;
            }

            public Semantic Semantic { get; }
            public Grammar Grammar => Semantic.Grammar;
            public IWriter Writer { get; }

            private int Level { get; set; }

            public void Dump()
            {
                var more = false;
                foreach (var rule in Grammar.Rules)
                {
                    var parser = rule.Attr(Semantic).Parser;

                    if (more)
                    {
                        Writer.WriteLine();
                    }
                    Writer.WriteLine($"({rule.Identifier.Name}");
                    Writer.Indent(() =>
                    {
                        parser.Dump(0, Writer);
                    });
                    Writer.WriteLine(")");
                    more = true;
                }
            }
        }
    }
}
