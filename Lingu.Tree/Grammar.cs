using System.IO;
using System.Collections.Generic;

using Lingu.Commons;
using Lingu.Errors;
using System;

namespace Lingu.Tree
{
    public class Grammar : IDumpable
    {
        public Grammar(AtomName name)
        {
            Name = name;
            Options = new Options();
            Terminals = new Terminals();
            Rules = new Rules();

            References = new List<Reference>();
        }

        public AtomName Name { get; }
        public Options Options { get; }
        public Terminals Terminals { get; }
        public Rules Rules { get; }

        public List<Reference> References { get; }

        public TerminalDefinition GenTerminal(Expression expression)
        {
            var name = new AtomName("__T_" + nextTerminalId++);

            var terminal = new TerminalDefinition(true, name, expression);

            Terminals.Add(terminal);

            return terminal;
        }

        public RuleDefinition GenRule(Expression expression)
        {
            var name = new AtomName("__T_" + nextRuleId++);

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
                if (terminal.IsGenerated)
                {
                    writer.WriteLine($"[{terminal.Name}]");
                }
                else
                {
                    writer.WriteLine($"{terminal.Name}");
                }

                try
                {
                    var nfa = terminal.Expression.GetNfa();
                    var dfa = nfa.ToDfa().Minimize();

                    dfa.Dump("  ", writer);
                }
                catch (Exception e)
                {
                    writer.WriteLine($"{e.Message}");
                }
            }
        }

        public void Dump(TextWriter writer)
        {
            var output = new Indentable();

            Dump(output, true);

            output.Dump(writer);
        }

        public void Dump(Indentable output, bool top)
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
