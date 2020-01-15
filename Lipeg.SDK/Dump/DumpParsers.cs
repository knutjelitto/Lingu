using System;

using Lipeg.SDK.Output;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Tree;
using Lipeg.SDK.Parsers;

namespace Lipeg.SDK.Dump
{
    public class DumpParsers : IDump<bool>
    {
        public void Dump(Grammar grammar, IWriter writer, bool _)
        {
            if (writer == null) throw  new ArgumentNullException(nameof(writer));

            new Visitor(grammar, writer).Dump();
        }

        private class Visitor
        {
            public Visitor(Grammar grammar, IWriter writer)
            {
                Grammar = grammar;
                Writer = writer;
            }

            public Grammar Grammar { get; }
            public IWriter Writer { get; }

            public void Dump()
            {
                var more = false;
                foreach (var rule in Grammar.AllRules)
                {
                    var parser = (ICombiParser)rule.Attr.Parser;

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
