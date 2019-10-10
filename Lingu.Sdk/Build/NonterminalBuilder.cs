using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Runtime.Structures;
using Lingu.Tree;

#nullable enable

namespace Lingu.Build
{
    public class NonterminalBuilder
    {
        public NonterminalBuilder(Grammar grammar, RawGrammar raw)
        {
            Grammar = grammar;
            Raw = raw;
            ToDo = new Queue<(Nonterminal, IEnumerable<IExpression>)>();
        }

        public Grammar Grammar { get; }
        public RawGrammar Raw { get; }
        private Queue<(Nonterminal, IEnumerable<IExpression>)> ToDo { get; }

        public void BuildPass1()
        {
            foreach (var raw in Raw.Nonterminals)
            {
                var nonterminal = new Nonterminal(raw.Name);

                if (Grammar.Nonterminals.Contains(nonterminal))
                {
                    throw new GrammarException($"nonterminal: `{nonterminal.Name}´ already defined before");
                }

                NewNonterminal(nonterminal, raw.Alternates);

            }

            while (ToDo.Count > 0)
            {
                var (nonterminal, expressions) = ToDo.Dequeue();

                BuildNonterminal(nonterminal, expressions);
            }

            foreach (var nonterminal in Grammar.Nonterminals)
            {
                if (nonterminal.IsLift)
                {
                    nonterminal.IsPrivate = true;
                }
            }
        }

        public void BuildPass2()
        {
            int id = Grammar.Terminals.Last().Id + 1;

            var innerStart = Grammar.Options.Start;
            if (innerStart == null)
            {
                innerStart = Grammar.Nonterminals[0];
            }

            var outerStart = new Nonterminal("__acc");
            Grammar.Accept = outerStart;
            outerStart.IsPrivate = true;
            outerStart.AddProductions( Enumerable.Repeat(new ProdSymbol(innerStart), 1) );
            outerStart.Id = id;
            id += 1;


            foreach (var nonterminal in Grammar.Nonterminals.Where(t => !t.IsPrivate))
            {
                nonterminal.Id = id;
                id += 1;
            }
            foreach (var nonterminal in Grammar.Nonterminals.Where(t => t.IsPrivate))
            {
                nonterminal.Id = id;
                id += 1;
            }

            Grammar.Nonterminals.Add(outerStart);

            Grammar.Nonterminals.Sort(nonterminal => nonterminal.Id);

            //
            // Number Productions
            //
            id = 0;
            foreach (var nonterminal in Grammar.Nonterminals)
            {
                foreach (var production in nonterminal.Productions)
                {
                    production.Id = id;
                    id += 1;

                    Grammar.Productions.Add(production);
                }

                if (nonterminal.Productions.All(p => p.IsPromote))
                {
                    nonterminal.IsLift = true;
                }
            }
        }

        private void BuildNonterminal(Nonterminal nonterminal, IEnumerable<IExpression> expressions)
        {
            foreach (var expression in expressions)
            {
                var builds = BuildSymbols(expression);
                nonterminal.AddProductions(builds);
            }
        }

        private void NewNonterminal(Nonterminal nonterminal, IEnumerable<IExpression> expressions)
        {
            Grammar.Nonterminals.Add(nonterminal);
            ToDo.Enqueue((nonterminal, expressions));
        }

        private void NewNonterminal(Nonterminal nonterminal)
        {
            Grammar.Nonterminals.Add(nonterminal);
        }

        private static IEnumerable<ProdSymbol> Single(ProdSymbol symbol)
        {
            return Enumerable.Repeat(symbol, 1);
        }

        private IEnumerable<ProdSymbol> BuildSymbols(IExpression expression)
        {
            switch (expression)
            {
                case Alternates alts:
                    {
                        var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                        {
                            IsGenerated = true,
                        };

                        NewNonterminal(nonterminal, alts.Children);
                        yield return new ProdSymbol(nonterminal);
                    }
                    break;
                case Sequence sequence:
                    {
                        foreach (var expr in sequence.Expressions)
                        {
                            foreach (var symbol in BuildSymbols(expr))
                            {
                                yield return symbol;
                            }
                        }
                    }
                    break;
                case Repeat repeat:
                    {
                        switch (repeat.Kind)
                        {
                            case RepeatKind.Optional:
                                {
                                    var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                                    {
                                        IsGenerated = true,
                                        Repeat = repeat.Kind
                                    };

                                    nonterminal.AddProductions(
                                        BuildSymbols(repeat.Expression),
                                        Enumerable.Empty<ProdSymbol>()
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return new ProdSymbol(nonterminal);
                                }
                                break;
                            case RepeatKind.Star:
                                {
                                    var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                                    {
                                        IsGenerated = true,
                                        Repeat = repeat.Kind
                                    };

                                    var symbols = BuildSymbols(repeat.Expression).ToList();
                                    nonterminal.AddProductions(
                                        Single(new ProdSymbol(nonterminal)).Concat(symbols),
                                        symbols,
                                        Enumerable.Empty<ProdSymbol>()
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return new ProdSymbol(nonterminal);
                                }
                                break;
                            case RepeatKind.Plus:
                                {
                                    var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                                    {
                                        IsGenerated = true,
                                        Repeat = repeat.Kind
                                    };

                                    var symbols = BuildSymbols(repeat.Expression).ToList();
                                    nonterminal.AddProductions(
                                        Single(new ProdSymbol(nonterminal)).Concat(symbols),
                                        symbols
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return new ProdSymbol(nonterminal);
                                }
                                break;
                        }
                    }
                    break;
                case RepeatList list:
                    {
                        switch (list.Kind)
                        {
                            case RepeatKind.StarList:
                                {
                                    var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                                    {
                                        IsGenerated = true,
                                        Repeat = list.Kind
                                    };

                                    var symbols = BuildSymbols(list.Expression).ToList();
                                    var separators = BuildSymbols(list.Separator).ToList();
                                    nonterminal.AddProductions(
                                        Single(new ProdSymbol(nonterminal)).Concat(separators).Concat(symbols),
                                        symbols,
                                        Enumerable.Empty<ProdSymbol>()
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return new ProdSymbol(nonterminal);
                                }
                                break;
                            case RepeatKind.PlusList:
                                {
                                    var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                                    {
                                        IsGenerated = true,
                                        Repeat = list.Kind
                                    };

                                    var symbols = BuildSymbols(list.Expression).ToList();
                                    var separators = BuildSymbols(list.Separator).ToList();
                                    nonterminal.AddProductions(
                                        Single(new ProdSymbol(nonterminal)).Concat(separators).Concat(symbols),
                                        symbols
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return new ProdSymbol(nonterminal);
                                }
                                break;
                        }
                    }
                    break;
                case SubRule subRule:
                    {
                        var nonterminal = new Nonterminal(subRule.Name.Text)
                        {
                            IsGenerated = true
                        };

                        if (Grammar.Nonterminals.Contains(nonterminal))
                        {
                            throw new GrammarException($"nonterminal: a rule named `{nonterminal.Name}´ is already defined before");
                        }

                        NewNonterminal(nonterminal, subRule.Children);
                        yield return new ProdSymbol(nonterminal);
                    }
                    break;
                case Name name:
                    {
                        var sym = (Symbol)name.Text;

                        if (Grammar.Nonterminals.TryGetValue(sym, out var nonterminal))
                        {
                            yield return new ProdSymbol(nonterminal);
                            break;
                        }

                        if (Grammar.Terminals.TryGetValue(sym, out var terminal))
                        {
                            yield return new ProdSymbol(terminal);
                            break;
                        }

                        throw new GrammarException($"nonterminal: reference to `{sym.Name}´ can't be resolved");
                    }
                case Tree.String str:
                    {
                        var terminal = Grammar.Terminals.Where(t => t.Visual == str.Value).FirstOrDefault();

                        if (terminal == null)
                        {
                            var tname = Grammar.NextTerminalName();

                            Debug.Assert(!str.Value.StartsWith('\''));
                            terminal = new Terminal(tname)
                            {
                                IsGenerated = true,
                                Visual = str.Value,
                                Raw = TerminalRule.From(tname, str),
                            };

                            Grammar.Terminals.Add(terminal);
                        }
                        yield return new ProdSymbol(terminal);
                    }
                    break;
                case Drop drop:
                {
                    var symbols = BuildSymbols(drop.Expression).ToList();
                    if (symbols.Count > 1)
                    {
                        var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                        {
                            IsGenerated = true,
                        };

                        nonterminal.AddProductions(
                            symbols
                        );

                        NewNonterminal(nonterminal);
                        yield return new ProdSymbol(nonterminal, true, false);
                        break;
                    }
                    yield return new ProdSymbol(symbols[0].Symbol, true, false);
                }
                    break;
                case Promote promote:
                {
                    var symbols = BuildSymbols(promote.Expression).ToList();
                    if (symbols.Count > 1)
                    {
                        var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                        {
                            IsGenerated = true,
                        };

                        nonterminal.AddProductions(
                            symbols
                        );

                        NewNonterminal(nonterminal);
                        yield return new ProdSymbol(nonterminal, false, true);
                        break;
                    }
                    yield return new ProdSymbol(symbols[0].Symbol, false, true);
                }
                    break;
                case Epsilon _:
                    {
                        // ignore
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            yield break;
        }
    }
}
