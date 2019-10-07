using System;
using System.Diagnostics;
using System.Text;
using Lingu.Automata;
using Lingu.Grammars;
using Lingu.Runtime.Lexing;
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

            Debug.Assert(Grammar.SpacingDfa != null);
            Debug.Assert(Grammar.Dfas != null);

            writer.WriteLine();
            DumpTerminal(writer, "Spacing", Grammar.SpacingDfa);

            for (var i = 0; i < Grammar.Dfas.Count; ++i)
            {
                writer.WriteLine();
                DumpTerminal(writer, $"Dfa{i}", Grammar.Dfas[i]);
            }
        }

        public void DumpTerminal(IWriter writer, Terminal terminal)
        {
            var builder = new StringBuilder();

            if (terminal.IsPrivate)
            {
                builder.Append("fragment ");
            }
            if (terminal.IsGenerated)
            {
                builder.Append($"[{terminal.Name}] «{terminal.Id}»");
                if (terminal.IsGenerated && terminal.Raw?.Expression is Tree.String text)
                {
                    builder.Append($" '{text.Value}'");
                }
            }
            else
            {
                builder.Append($"{terminal.Name} «{terminal.Id}»");
            }

            DumpTerminal(writer, builder.ToString(), terminal);
        }


        public void DumpTerminal(IWriter writer, string head, Terminal terminal)
        {
            DumpTerminal(writer, head, terminal.GetDfa());
        }

        public void DumpTerminal(IWriter writer, string head, FA dfa)
        {
            writer.WriteLine($"{head}");

            try
            {
                var iwriter = new IndentWriter();
                iwriter.Indent(() =>
                {
                    new FaDfaDumper().Dump(iwriter, dfa);
                });
                iwriter.Dump(writer);
            }
            catch (Exception e)
            {
                writer.WriteLine($"{e}");
            }
        }
        public void DumpTerminal(IWriter writer, string head, Dfa dfa)
        {
            writer.WriteLine($"{head}");

            try
            {
                var iwriter = new IndentWriter();
                iwriter.Indent(() =>
                {
                    new DfaDumper().Dump(iwriter, dfa);
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
