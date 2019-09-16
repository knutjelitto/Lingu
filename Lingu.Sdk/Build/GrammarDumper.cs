using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Lingu.Grammars;
using Lingu.Tools;
using Lingu.Tree;
using Lingu.Writers;
using Mean.Maker.Builders;

namespace Lingu.Build
{
    public class GrammarDumper
    {
        public GrammarDumper(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Dump(FileRef dests)
        {
            var grammarDump = dests.Add(".Grammar");
            var terminals = dests.Add(".Terminals");
            var sets = dests.Add(".Sets");

            using (var writer = new StreamWriter(grammarDump))
            {
                PpGrammar(writer);
            }
            using (var writer = new StreamWriter(terminals))
            {
                DumpTerminals(writer);
            }
            using (var writer = new StreamWriter(sets))
            {
                DumpSets(writer);
            }
        }

        private void DumpSets(TextWriter writer)
        {
            for (var i = 0; i < Grammar.ItemSets.Count; ++i)
            {
                writer.WriteLine($"set {i}:");
                foreach (var item in Grammar.ItemSets[i])
                {
                    writer.WriteLine($"    {item}");
                }
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
                PpSet(output, "options", false, Grammar.Options);
                PpSet(output, "terminals", true, Grammar.Terminals);
                PpSet(output, "rules", true, Grammar.Nonterminals);
            });

            output.Dump(writer);
        }


        private static void PpSet(IndentWriter writer, string name, bool separate, IEnumerable<Symbol> members)
        {
            writer.Block(name, () =>
            {
                var more = false;
                foreach (var item in members)
                {
                    if (separate && more) writer.WriteLine();
                    PpAnySymbol(writer, item);
                    more = true;
                }
            });
        }

        private static void PpAnySymbol(IndentWriter writer, Symbol symbol)
        {
            switch (symbol)
            {
                case Option option:
                    writer.WriteLine($"{option.Name} = {option.Value.Name};");
                    return;
                case Terminal terminal:
                    PpTerminal(writer, terminal);
                    return;
                case Nonterminal nonterminal:
                    PpNonterminal(writer, nonterminal);
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void PpTerminal(IndentWriter writer, Terminal terminal)
        {
            var p = terminal.IsPrivate ? "private " : "";
            var a = terminal.IsGenerated ? $"{terminal.Visual} " : "";
            writer.Indend($"{terminal.Name} // {p}{a}({terminal.Id})", () =>
            {
                if (terminal.Raw.Expression is Alternates alternates)
                {
                    bool more = false;
                    foreach (var alt in alternates.Expressions)
                    {
                        if (more)
                        {
                            writer.Write("| ");
                        }
                        else
                        {
                            writer.Write(": ");
                        }
                        more = true;

                        alt.Dump(writer);
                        writer.WriteLine();
                    }
                }
                else
                {
                    writer.Write(": ");
                    terminal.Raw.Expression.Dump(writer);
                    writer.WriteLine();
                }
                writer.WriteLine(";");
            });
        }


        private static void PpNonterminal(IndentWriter writer, Nonterminal nonterminal)
        {
            var p = nonterminal.IsPrivate ? "private " : "";
            var l = Lifta();

            writer.Indend($"{nonterminal.Name} // {p}{l}({nonterminal.Id})", () =>
            {
                bool more = false;
                foreach (var production in nonterminal.Productions)
                {
                    if (more)
                    {
                        writer.Write("| ");
                    }
                    else
                    {
                        writer.Write(": ");
                    }
                    more = true;

                    PpProduction(writer, production);
                }
                writer.WriteLine(";");
            });

            string Lifta()
            {
                switch (nonterminal.Lift)
                {
                    case LiftKind.User:
                        return "(^^) ";
                    case LiftKind.Optional:
                        return "(^?) ";
                    case LiftKind.Star:
                        return "(^*) ";
                    case LiftKind.Plus:
                        return "(^+) ";
                    case LiftKind.Alternate:
                        return "(^|) ";
                    case LiftKind.None:
                        return string.Empty;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static void PpProduction(IndentWriter writer, Production production)
        {
            writer.WriteLine(production.ToString());
        }

    }
}
