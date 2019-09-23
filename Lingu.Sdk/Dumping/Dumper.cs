using Lingu.Grammars;
using Lingu.Writers;
using Mean.Maker.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lingu.Dumping
{
    public class Dumper
    {
        public Dumper(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Dump(FileRef dests)
        {
            var grammarDump = dests.Add(".Grammar");
            var terminals = dests.Add(".Terminals");
            var nonterminals = dests.Add(".Nonterminals");
            var sets = dests.Add(".Sets");
            var table = dests.Add(".Table");

            using (var writer = new StreamWriter(grammarDump))
            {
                new GrammarDumper(Grammar).Dump(new TextIWriter(writer));
            }
            using (var writer = new StreamWriter(terminals))
            {
                new TerminalDumper(Grammar).Dump(new TextIWriter(writer));
            }
            using (var writer = new StreamWriter(nonterminals))
            {
                new NonterminalDumper(Grammar).Dump(new TextIWriter(writer));
            }
            using (var writer = new StreamWriter(sets))
            {
                new SetDumper(Grammar).Dump(new TextIWriter(writer));
            }
            using (var writer = new StreamWriter(table))
            {
                new TableDumper(Grammar).Dump(new TextIWriter(writer));
            }
        }
    }
}
