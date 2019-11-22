using System;
using System.Collections.Generic;
using System.Linq;

using Lipeg.SDK.Output;
using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
using System.Diagnostics;
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

            public void Dump()
            {
                foreach (var rule in Grammar.Rules)
                {
                    var parser = rule.Attr(Semantic).Parser;

                    Writer.WriteLine($"{rule.Identifier.Name}(");
                    Writer.Indent(() =>
                    {
                        Do(parser);
                    });
                    Writer.WriteLine(")");
                }
            }

            private void Do(IParser parser)
            {
                Dump((dynamic)parser);
            }

            private void Dump(IParser parser)
            {
                throw new NotImplementedException();
            }

            private void Dump(Choice choice)
            {
                if (choice.Parsers.Count > 1)
                {

                }
                Writer.Write($"({choice.Name})");

            }

        }
    }
}
