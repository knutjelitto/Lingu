using System;

using Lingu.Grammars;
using Lingu.Writers;

#nullable enable

namespace Lingu.Dumping
{
    public class TerminalDumper
    {
        public TerminalDumper(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }


        public void Dump(IWriter writer)
        {
            foreach (var terminal in Grammar.Terminals)
            {
                DumpTerminal(writer, terminal);
            }
        }

        public void DumpTerminal(IWriter writer, Terminal terminal)
        {
            if (terminal.IsPrivate)
            {
                writer.Write("fragment ");
            }
            if (terminal.IsGenerated)
            {
                writer.Write($"[{terminal.Name}] ({terminal.Id})");
                if (terminal.IsGenerated && terminal.Raw?.Expression is Tree.String text)
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

    }
}
