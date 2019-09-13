using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Tree;

namespace Lingu.Build
{
    public class ProductionBuilder
    {
        public ProductionBuilder(Grammar grammar, RawGrammar raw)
        {
            Grammar = grammar;
            Raw = raw;
            ToDo = new Queue<(Nonterminal, IEnumerable<IExpression>)>();
        }

        public Grammar Grammar { get; }
        public RawGrammar Raw { get; }
        private Queue<(Nonterminal, IEnumerable<IExpression>)> ToDo { get; }

        public void Build()
        {
            foreach (var raw in Raw.Nonterminals)
            {
                var nonterminal = new Nonterminal(raw.Name);

                if (Grammar.Nonterminals.Contains(nonterminal))
                {
                    throw new GrammarException($"nonterminal: `{nonterminal.Name}´ already defined before");
                }

                Grammar.Nonterminals.Add(nonterminal);
                ToDo.Enqueue((nonterminal, raw.Alternates));

            }

            while (ToDo.Count > 0)
            {
                var (nonterminal, expressions) = ToDo.Dequeue();

                BuildNonterminal(nonterminal, expressions);
            }
        }

        private void BuildNonterminal(Nonterminal nonterminal, IEnumerable<IExpression> expressions)
        {
            foreach (var expression in expressions)
            {
                nonterminal.AddProductions(BuildSymbols(expression));
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

        private IEnumerable<Symbol> BuildSymbols(IExpression expression)
        {
            switch (expression)
            {
                case Alternates alts:
                    {
                        var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                        {
                            IsGenerated = true
                        };

                        NewNonterminal(nonterminal, alts.Children);
                        yield return nonterminal;
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
                                        IsGenerated = true
                                    };

                                    nonterminal.AddProductions(
                                        BuildSymbols(repeat.Expression),
                                        Enumerable.Empty<Symbol>()
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return nonterminal;
                                }
                                break;
                            case RepeatKind.Star:
                                {
                                    var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                                    {
                                        IsGenerated = true
                                    };

                                    var symbols = BuildSymbols(repeat.Expression).ToList();
                                    nonterminal.AddProductions(
                                        Enumerable.Repeat(nonterminal, 1).Concat(symbols),
                                        symbols,
                                        Enumerable.Empty<Symbol>()
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return nonterminal;
                                }
                                break;
                            case RepeatKind.Plus:
                                {
                                    var nonterminal = new Nonterminal(Grammar.NextNonterminalName())
                                    {
                                        IsGenerated = true
                                    };

                                    var symbols = BuildSymbols(repeat.Expression).ToList();
                                    nonterminal.AddProductions(
                                        Enumerable.Repeat(nonterminal, 1).Concat(symbols),
                                        symbols
                                    );

                                    NewNonterminal(nonterminal);
                                    yield return nonterminal;
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
                        yield return nonterminal;
                    }
                    break;
                case Name name:
                    {
                        var sym = (Symbol)name.Text;

                        if (Grammar.Nonterminals.TryGetValue(sym, out var nonterminal))
                        {
                            yield return nonterminal;
                            break;
                        }

                        if (Grammar.Terminals.TryGetValue(sym, out var terminal))
                        {
                            yield return terminal;
                            break;
                        }

                        throw new GrammarException($"nonterminal: reference to `{sym.Name}´ can't be resolved");
                    }
                case Tree.String str:
                    {
                        var terminal = Grammar.Terminals.Where(t => t.Visual == str.Value).FirstOrDefault();

                        if (terminal == null)
                        {
                            var tname = Grammar.NextTerminalName(); ;

                            terminal = new Terminal(tname)
                            {
                                IsGenerated = true,
                                Visual = str.Value,
                                Raw = new RawTerminal(tname, str),
                            };

                            Grammar.Terminals.Add(terminal);
                        }
                        yield return terminal;
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
