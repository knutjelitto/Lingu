using System;
using System.Collections.Generic;
using System.IO;

using Lingu.Grammars;
using Lingu.LR;
using Lingu.Tools;
using Lingu.Tree;
using Lingu.Writers;

using Mean.Maker.Builders;

#nullable enable

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
            var nonterminals = dests.Add(".Nonterminals");
            var sets = dests.Add(".Sets");

            using (var writer = new StreamWriter(grammarDump))
            {
                PpGrammar(new TextIWriter(writer));
            }
            using (var writer = new StreamWriter(terminals))
            {
                DumpTerminals(new TextIWriter(writer));
            }
            using (var writer = new StreamWriter(nonterminals))
            {
                DumpNonterminals(new TextIWriter(writer));
            }
            using (var writer = new StreamWriter(sets))
            {
                DumpSets(new TextIWriter(writer));
            }
        }

        private void DumpSets(IWriter writer)
        {
            //DumpLR0Sets(writer);
            DumpLR1Sets(writer);
        }

        private void DumpLR0Sets(IWriter writer)
        {
            var namesLength = 0;
            var bodyLength = 0;

            foreach (var set in Grammar.LR0Sets)
            {
                for (var i = 0; i < set.Count; ++i)
                {
                    namesLength = Math.Max(namesLength, set[i].Core.LHStoString().Length);
                    bodyLength = Math.Max(bodyLength, set[i].Core.RHStoString().Length);
                }
            }

            string namesFormat = $"{{0,-{namesLength}}}";
            string bodyFormat = $"{{0,-{bodyLength}}}";

            foreach (var set in Grammar.LR0Sets)
            {
                writer.WriteLine($"{set}");

                for (var i = 0; i < set.Count; ++i)
                {
                    var name = string.Format(namesFormat, set[i].Core.LHStoString());
                    var body = string.Format(bodyFormat, set[i].Core.RHStoString());
                    var kernel = set[i].InKernel ? "k" : " ";
                    writer.WriteLine($"    [{name} -> {body} ]{kernel}  {Action(set[i])}");
                }
            }

            string Action(LR0 item)
            {
                if (item.IsComplete)
                {
                    return $"(-,reduce)";
                }
                else
                {
                    return $"({item.PostDot},i{item.Num})";
                }
            }
        }

        private void DumpLR1Sets(IWriter writer)
        {
            var namesLength = 0;
            var bodyLength = 0;
            var actionLeft = 0;
            var actionRight = (int)Math.Log10(Grammar.LR1Sets.Count) + 1;

            foreach (var set in Grammar.LR1Sets)
            {
                for (var i = 0; i < set.Count; ++i)
                {
                    namesLength = Math.Max(namesLength, set[i].Core.LHStoString().Length);
                    bodyLength = Math.Max(bodyLength, set[i].Core.RHStoString().Length);

                    if (!set[i].IsComplete)
                    {
                        actionLeft = Math.Max(actionLeft, set[i].PostDot.ToString().Length);
                    }
                }
            }

            string namesFormat = $"{{0,-{namesLength}}}";
            string bodyFormat = $"{{0,-{bodyLength}}}";
            string aleftFormat = $"{{0,-{actionLeft}}}";
            string arightFormat = $"i{{0,-{actionRight}}}";

            foreach (var set in Grammar.LR1Sets)
            {
                writer.WriteLine($"{set}");

                for (var i = 0; i < set.Count; ++i)
                {
                    var name = string.Format(namesFormat, set[i].Core.LHStoString());
                    var body = string.Format(bodyFormat, set[i].Core.RHStoString());
                    var kernel = set[i].InKernel ? "k" : " ";
                    writer.WriteLine($"    [{name} -> {body} ]{kernel}  {Action(set[i])} {set[i].Lookahead}");
                }
            }

            string Action(LR1 item)
            {
                if (item.IsComplete)
                {
                    var spaces = Math.Max(0, actionLeft + actionRight);
                    return $"(R<{item.Core.Production.Id}>{new string(' ', spaces)})";
                }
                else
                {
                    var left = string.Format(aleftFormat, item.PostDot);
                    var right = string.Format(arightFormat, item.Num);
                    return $"({left} , {right})";
                }
            }
        }

        private void DumpNonterminals(IWriter writer)
        {
            foreach (var nonterminal in Grammar.Nonterminals)
            {
                DumpNonterminal(writer, nonterminal);
            }
        }

        private void DumpNonterminal(IWriter writer, Nonterminal nonterminal)
        {
            writer.WriteLine($"{nonterminal.Name}  {nonterminal.First}");
        }


        private void DumpTerminals(IWriter writer)
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

        private void PpGrammar(IWriter writer)
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
                return nonterminal.Lift switch
                {
                    LiftKind.Lift => "(^^) ",
                    LiftKind.Optional => "(^?) ",
                    LiftKind.Star => "(^*) ",
                    LiftKind.Plus => "(^+) ",
                    LiftKind.Alternate => "(^|) ",
                    LiftKind.None => string.Empty,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        private static void PpProduction(IndentWriter writer, Production production)
        {
            writer.WriteLine(production.ToString());
        }

    }
}
