using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Runtime.LexDfa;
using Lingu.Tree;

namespace Lingu.Build
{
    public class Builder
    {
        public Builder(RawGrammar tree)
        {
            Raw = tree;
            Grammar = new Grammar(Raw.Name);
        }

        public RawGrammar Raw { get; }
        public Grammar Grammar { get; }

        public Grammar Build()
        {
            BuildOptions();

            BuildTerminalsPass1(); // terminal create entities
            BuildTerminalsPass2(); // terminal resolve references
            BuildTerminalsPass3(); // terminal detect recursions

            BuildNonterminalsPass1(); // nonterminal create
            BuildNonterminalsPass2(); // nonterminal resolve references

            BuildTerminalsPass4(); // terminal fragments (deps on nonterminals)
            BuildTerminalsPass5(); // terminal renumber (non-fragments first)
            BuildTerminalsPass6(); // terminal compile (create automatons)

            return Grammar;
        }

        private string NextTerminalName()
        {
            return $"__T{nextTerminalId++}";
        }

        private string NextNonterminalName()
        {
            return $"__T{nextNonterminalId++}";
        }

        /// <summary>
        /// Simply build options
        /// </summary>
        private void BuildOptions()
        {
            foreach (var raw in Raw.Options)
            {
                var option = raw;
                if (Grammar.Options.Contains(option))
                {
                    throw new GrammarException($"option: `{option.Name}´ already defined before");
                }
                Grammar.Options.Add(option);
            }
        }

        private void BuildNonterminalsPass1()
        {
            foreach (var raw in Raw.Nonterminals)
            {
                var nonterminal = new Nonterminal(raw.Name)
                {
                    Raw = raw
                };

                if (Grammar.Nonterminals.Contains(nonterminal))
                {
                    throw new GrammarException($"nonterminal: `{nonterminal.Name}´ already defined before");
                }

                Grammar.Nonterminals.Add(nonterminal);
            }
        }

        /// <summary>
        /// Resolving references
        /// </summary>
        private void BuildNonterminalsPass2()
        {
            foreach (var nonterminal in Grammar.Nonterminals)
            {
                Resolve(nonterminal.Raw.Expressions);
            }

            void Resolve(IEnumerable<IExpression> expressions)
            {
                foreach (var expression in expressions)
                {
                    Resolve2(expression);
                }
            }

            void Resolve2(IExpression expr)
            {
                if (expr is Name name)
                {
                    var sym = (Symbol)name.Text;

                    if (!Grammar.Nonterminals.TryGetValue(sym, out var nonterminal))
                    {
                        if (!Grammar.Terminals.TryGetValue(sym, out var terminal))
                        {
                            throw new GrammarException($"nonterminal: reference to `{sym.Name}´ can't be resolved");
                        }
                        else
                        {
                            name.Rule = terminal;
                        }
                    }
                    else
                    {
                        name.Rule = nonterminal;
                    }

                }
                else if (expr is Tree.String str)
                {
                    var sym = (Symbol)str.Value;
                    var tname = (Symbol)NextTerminalName(); ;

                    if (!Grammar.Terminals.TryGetValue(sym, out var terminal))
                    {
                        var rawTerminal = new RawTerminal(tname.Name, expr);
                        terminal = new Terminal(tname.Name)
                        {
                            IsGenerated = true,
                            Visual = sym.Name,
                            Raw = rawTerminal
                        };
                        Grammar.Terminals.Add(terminal);
                    }

                    str.Terminal = terminal;

                }
                else
                {
                    foreach (var subExpr in expr.Children)
                    {
                        Resolve2(subExpr);
                    }
                }
            }
        }

        /// <summary>
        /// Create terminals.
        /// </summary>
        private void BuildTerminalsPass1()
        {
            foreach (var raw in Raw.Terminals)
            {
                var terminal = new Terminal(raw.Name)
                {
                    Raw = raw
                };

                if (Grammar.Terminals.Contains(terminal))
                {
                    throw new GrammarException($"terminal: `{terminal.Name}´ already defined before");
                }

                Grammar.Terminals.Add(terminal);
            }
        }

        /// <summary>
        /// Resolving references
        /// </summary>
        private void BuildTerminalsPass2()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                Resolve(terminal.Raw.Expression);
            }

            void Resolve(IExpression expr)
            {
                if (expr is Name name)
                {
                    if (!Grammar.Terminals.TryGetValue((Symbol)name.Text, out var terminal))
                    {
                        throw new GrammarException($"terminal: reference to `{terminal.Name}´ can't be resolved");
                    }
                    name.Rule = terminal;
                }
                else
                {
                    foreach (var subExpr in expr.Children)
                    {
                        Resolve(subExpr);
                    }
                }
            }
        }

        /// <summary>
        /// Check terminal recursion
        /// </summary>
        private void BuildTerminalsPass3()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                CheckTerminalRecursion(terminal);
            }

            void CheckTerminalRecursion(Terminal terminal)
            {
                var path = new Stack<RawTerminal>();

                CheckTerminalRecursion2(terminal.Raw, path, terminal.Raw.Expression);
            }

            void CheckTerminalRecursion2(Terminal terminal, Stack<RawTerminal> path, IExpression expression)
            {
                if (expression is Name name)
                {
                    var definition = (Terminal)name.Rule;

                    if (terminal.Equals(definition))
                    {
                        var msg = $"terminal: `{terminal.Name}´ is recursive (via ->{string.Join("->", path.Reverse())}->{terminal.Name})";
                        throw new GrammarException(msg);
                    }

                    path.Push(definition.Raw);
                    CheckTerminalRecursion2(terminal, path, definition.Raw.Expression);
                    path.Pop();
                }
                else
                {
                    foreach (var childExpression in expression.Children)
                    {
                        CheckTerminalRecursion2(terminal, path, childExpression);
                    }
                }
            }
        }

        /// <summary>
        /// Determine ``IsFragment´´ status of terminals.
        /// </summary>
        private void BuildTerminalsPass4()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                terminal.IsFragment = true;
                terminal.Raw.IsFragment = true;
            }

            foreach (var rule in Grammar.Nonterminals)
            {
                foreach (var raw in rule.Raw.Expressions)
                {
                    CheckFragment(raw);
                }
            }

            if (Grammar.Newline != null)
            {
                Grammar.Newline.IsFragment = false;
                Grammar.Newline.Raw.IsFragment = false;
            }
            if (Grammar.Separator != null)
            {
                Grammar.Separator.IsFragment = false;
                Grammar.Separator.Raw.IsFragment = false;
            }

            void CheckFragment(IExpression expression)
            {
                if (expression is Name name && name.Rule is Terminal terminal)
                {
                    terminal.IsFragment = false;
                    terminal.Raw.IsFragment = false;
                }

                foreach (var subExpression in expression.Children)
                {
                    CheckFragment(subExpression);
                }
            }
        }

        /// <summary>
        /// Renumbering
        /// </summary>
        private void BuildTerminalsPass5()
        {
            int id = 2;
            foreach (var terminal in Grammar.Terminals.Where(t => !t.Raw.IsFragment))
            {
                terminal.Id = id;
                terminal.Raw.Id = id;
                id += 1;
            }
            foreach (var terminal in Grammar.Terminals.Where(t => t.Raw.IsFragment))
            {
                terminal.Id = id;
                terminal.Raw.Id = id;
                id += 1;
            }

            Grammar.Terminals.Sort(terminal => terminal.Id);
        }

        /// <summary>
        /// Compile
        /// </summary>
        private void BuildTerminalsPass6()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                BuildTerminal(terminal);
            }

            void BuildTerminal(Terminal terminal)
            {
                terminal.Visual = terminal.IsGenerated ? terminal.Raw.Expression.ToString() : null;
                terminal.Bytes = Writer.GetBytes(terminal.Raw.Expression.GetFA().ToDfa().Minimize().RemoveDead());
                terminal.Dfa = new DfaReader(terminal.Bytes).Read();
            }
        }

        private int nextTerminalId = 1;
        private int nextNonterminalId = 1;
    }
}
