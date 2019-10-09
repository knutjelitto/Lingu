using System;
using System.Collections.Generic;

using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Tree;
using Lingu.Writers;

#nullable enable

namespace Lingu.Dumping
{
    public class GrammarDumper
    {
        public GrammarDumper(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Dump(IWriter writer)
        {
            var output = new IndentWriter();

            output.Block($"grammar {Grammar.Name}", () =>
            {
                PpSet(output, "options", false, Grammar.OptionList);
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

            writer.Indend($"{nonterminal.Name} // {p}({nonterminal.Id})", () =>
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
        }

        private static void PpProduction(IndentWriter writer, Production production)
        {
            writer.WriteLine(production.ToString());
        }
    }
}
