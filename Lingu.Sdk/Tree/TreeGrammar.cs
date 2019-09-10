using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;
using Lingu.Errors;
using Lingu.Tools;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public class TreeGrammar : Grammar
    {
        public TreeGrammar(string name)
            : base(name)
        {
            TreeOptions = new TreeOptions();
            References = new List<Reference>();
        }

        public TreeOptions TreeOptions { get; }
        //public Rules Rules { get; }

        public List<Reference> References { get; }

        public TreeTerminal GenTerminal(IExpression expression)
        {
            var name = new Name("$T" + nextTerminalId++);

            var terminal = new TreeTerminal(true, name, expression);

            Terminals.Add(terminal);

            return terminal;
        }

        public TreeNonterminal GenRule(IExpression expression)
        {
            var name = new Name("$R" + nextRuleId++);

            var terminal = new TreeNonterminal(true, name, expression);

            Nonterminals.Add(terminal);

            return terminal;
        }

        public void Resolve()
        {
            foreach (var reference in References)
            {
                if (reference.Kind == ReferenceKind.Terminal)
                {
                    if (!Terminals.TryGetValue(reference, out var terminal))
                    {
                        throw new TreeException($"can't resolve reference to terminal `{reference.Name}`");
                    }
                    reference.ResolveTo((TreeTerminal)terminal);
                }
                else if (reference.Kind == ReferenceKind.TerminalOrRule)
                {
                    if (!Nonterminals.TryGetValue(reference, out var rule))
                    {
                        if (!Terminals.TryGetValue(reference, out var terminal))
                        {
                            throw new TreeException($"can't resolve reference to rule or terminal `{reference.Name}`");
                        }
                        reference.ResolveTo((TreeTerminal)terminal);
                    }
                    else
                    {
                        reference.ResolveTo((TreeNonterminal)rule);
                    }
                }
            }
        }

        public void DumpTerminals(TextWriter writer)
        {
            foreach (var terminal in Terminals.Cast<TreeTerminal>())
            {
                DumpTerminal(terminal, writer);
            }
        }

        public void DumpTerminal(TreeTerminal terminal, TextWriter writer)
        {
            if (terminal.IsFragment)
            {
                writer.Write("fragment ");
            }
            if (terminal.IsGenerated)
            {
                writer.Write($"[{terminal.Name}] ({terminal.Id})");
                if (terminal.IsGenerated && terminal.Expression is String text)
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

        public override void Dump(IWriter output, bool top)
        {
            output.Block($"grammar {Name}", () =>
            {
                DumpSet(output, top, "options", false, TreeOptions);
                DumpSet(output, top, "terminals", true, Terminals);
                DumpSet(output, top, "rules", true, Nonterminals);
            });
        }

        private static void DumpSet(IWriter output, bool top, string name, bool separate, IEnumerable<Symbol> members)
        {
            output.Block(name, () =>
            {
                var more = false;
                foreach (var item in members)
                {
                    if (item is Nonterminal non && non.IsEmbedded)
                    {
                        continue;
                    }
                    if (separate && more) output.WriteLine();
                    item.Dump(output, top);
                    more = true;
                }
            });
        }

        private int nextTerminalId = 1;
        private int nextRuleId = 1;
    }
}
