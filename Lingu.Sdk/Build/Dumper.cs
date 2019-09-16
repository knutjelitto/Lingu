using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Lingu.Grammars;
using Lingu.Tools;
using Lingu.Writers;
using Mean.Maker.Builders;

namespace Lingu.Build
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

            using (var writer = new StreamWriter(grammarDump))
            {
                PpGrammar(writer);
            }
            using (var writer = new StreamWriter(terminals))
            {
                DumpTerminals(writer);
            }
        }

        private void DumpTerminals(TextWriter writer)
        {
            foreach (var terminal in Grammar.Terminals)
            {
                DumpTerminal(terminal, writer);
            }
        }

        public void DumpTerminal(Terminal terminal, TextWriter writer)
        {
            if (terminal.IsPrivate)
            {
                writer.Write("fragment ");
            }
            if (terminal.IsGenerated)
            {
                writer.Write($"[{terminal.Name}] ({terminal.Id})");
                if (terminal.IsGenerated && terminal.Raw.Expression is Tree.String text)
                {
                    writer.Write($" '{text.Value}'");
                }
            }
            else
            {
                writer.Write($"{terminal.Name} ({terminal.Id})");
            }
            writer.WriteLine();

            try
            {
                var roundtrip = terminal.Dfa;
                var iwriter = new IndentWriter();
                iwriter.Indend(() =>
                {
                    new DfaDump().Dump(iwriter, roundtrip);
                });
                iwriter.Dump(writer);
            }
            catch (Exception e)
            {
                writer.WriteLine($"{e}");
            }
        }

        private void PpGrammar(TextWriter writer)
        {
            var output = new IndentWriter();

            output.Block($"grammar {Grammar.Name}", () =>
            {
                PpSet(output, true, "options", false, Grammar.Options);
                PpSet(output, true, "terminals", true, Grammar.Terminals);
                PpSet(output, true, "rules", true, Grammar.Nonterminals);
            });

            output.Dump(writer);
        }


        private static void PpSet(IndentWriter output, bool top, string name, bool separate, IEnumerable<Symbol> members)
        {
            output.Block(name, () =>
            {
                var more = false;
                foreach (var item in members)
                {
                    if (separate && more) output.WriteLine();
                    item.Dump(output);
                    more = true;
                }
            });
        }


    }
}
