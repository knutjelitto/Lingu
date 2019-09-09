using System;
using System.IO;
using System.Collections.Generic;

using Lingu.Commons;
using Lingu.Errors;
using Lingu.Automata;
using Lingu.Tools;

namespace Lingu.Tree
{
    public class GrammarTree : IDumpable
    {
        public GrammarTree(Name name)
        {
            Name = name;
            Options = new Options();
            Terminals = new Terminals();
            Rules = new Rules();

            References = new List<Reference>();
        }

        public Name Name { get; }
        public Options Options { get; }
        public Terminals Terminals { get; }
        public Rules Rules { get; }

        public List<Reference> References { get; }

        public TerminalDefinition GenTerminal(Expression expression)
        {
            var name = new Name("$T" + nextTerminalId++);

            var terminal = new TerminalDefinition(true, name, expression);

            Terminals.Add(terminal);

            return terminal;
        }

        public RuleDefinition GenRule(Expression expression)
        {
            var name = new Name("$R" + nextRuleId++);

            var terminal = new RuleDefinition(true, name, expression);

            Rules.Add(terminal);

            return terminal;
        }

        public void Resolve()
        {
            foreach (var reference in References)
            {
                if (reference.Kind == ReferenceKind.Terminal)
                {
                    if (!Terminals.TryGetValue(reference.Name.Text, out var terminal))
                    {
                        throw new TreeException($"can't resolve reference to terminal `{reference.Name}`");
                    }
                    reference.ResolveTo(terminal);
                }
                else if (reference.Kind == ReferenceKind.TerminalOrRule)
                {
                    if (!Rules.TryGetValue(reference.Name.Text, out var rule))
                    {
                        if (!Terminals.TryGetValue(reference.Name.Text, out var terminal))
                        {
                            throw new TreeException($"can't resolve reference to rule or terminal `{reference.Name}`");
                        }
                        reference.ResolveTo(terminal);
                    }
                    else
                    {
                        reference.ResolveTo(rule);
                    }
                }
            }
        }

        public void DumpTerminals(TextWriter writer)
        {
            foreach (var terminal in Terminals)
            {
                DumpTerminal(terminal, writer);
            }
        }

        public void DumpTerminal(TerminalDefinition terminal, TextWriter writer)
        {
            if (terminal.IsFragment)
            {
                writer.Write("fragment ");
            }
            if (terminal.IsGenerated)
            {
                writer.Write($"[{terminal.Name}]");
                if (terminal.IsGenerated && terminal.Expression is String text)
                {
                    writer.Write($" '{text.Value}'");
                }
            }
            else
            {
                writer.Write($"{terminal.Name}");
            }
            writer.WriteLine($"  [{terminal.Bytes.Length} bytes]");

            try
            {
                terminal.Dfa.Dump("    ", writer);
                writer.WriteLine("    ----");
                var roundtrip = Reader.ReadDfa(terminal.Bytes);
                var iwriter = new IWriter();
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

        public void Dump(TextWriter writer)
        {
            var output = new IWriter();

            Dump(output, true);

            output.Dump(writer);
        }

        public void Dump(IWriter output, bool top)
        {
            output.Block($"grammar {Name}", () =>
            {
                Options.Dump(output, top);
                Terminals.Dump(output, top);
                Rules.Dump(output, top);
            });
        }

        private int nextTerminalId = 1;
        private int nextRuleId = 1;
    }
}
