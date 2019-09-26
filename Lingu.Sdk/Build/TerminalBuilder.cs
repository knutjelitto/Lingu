using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Automata;
using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Tree;

#nullable enable

namespace Lingu.Build
{
    public class TerminalBuilder
    {
        public TerminalBuilder(Grammar grammar, RawGrammar tree)
        {
            Grammar = grammar;
            Raw = tree;
        }

        public Grammar Grammar { get; }
        public RawGrammar Raw { get; }

        public void BuildPass1()
        {
            BuildTerminalsPass1(); // terminal create entities
            BuildTerminalsPass2(); // terminal resolve references
            BuildTerminalsPass3(); // terminal detect recursions
        }

        public void BuildPass2()
        {
            BuildTerminalsPass4(); // terminal fragments (deps on nonterminals)
            BuildTerminalsPass5(); // terminal renumber (non-fragments first)
        }

        /// <summary>
        /// Build common dfa for parser needed terminals
        /// </summary>
        public void BuildPass3()
        {
            var terminals = Grammar.Terminals.Where(t => t.IsPid).ToList();
            var terminalDfas = new List<FA>();
            for (var i = 0; i < terminals.Count; ++i)
            {
                var terminal = terminals[i];
                var fa = terminal.Raw.Expression.GetFA();
                fa = fa.ToDfa();
                fa = fa.Minimize();
                fa = fa.RemoveDead();

                terminalDfas.Add(fa);
            }

            FA? dfa = null;
            for (var i = 0; i < terminals.Count; ++i)
            {
                foreach (var state in terminalDfas[i].Finals)
                {
                    state.SetPayload(terminals[i].Id);
                }
                if (dfa == null)
                {
                    dfa = terminalDfas[i];
                }
                else
                {
                    dfa = dfa.Union(terminalDfas[i]);
                }
            }

            Debug.Assert(dfa != null);

            var runtimeDfa = dfa.Convert();

            Grammar.CommonDfa = runtimeDfa;
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
                        throw new GrammarException($"terminal: reference to `{name.Text}´ can't be resolved");
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

            static void CheckTerminalRecursion(Terminal terminal)
            {
                var path = new Stack<RawTerminal>();

                CheckTerminalRecursion2(terminal.Raw, path, terminal.Raw.Expression);
            }

            static void CheckTerminalRecursion2(Terminal terminal, Stack<RawTerminal> path, IExpression expression)
            {
                if (expression is Name name)
                {
                    var definition = name.Rule;

                    if (terminal.Name.Equals(definition.Name))
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
                terminal.IsPrivate = true;
            }

            foreach (var nonterminal in Grammar.Nonterminals)
            {
                foreach (var production in nonterminal.Productions)
                {
                    foreach (var terminal in production.Symbols.OfType<Terminal>())
                    {
                        terminal.IsPrivate = false;
                    }
                }
            }
        }

        /// <summary>
        /// Add `eof´ + renumbering
        /// </summary>
        private void BuildTerminalsPass5()
        {
            var eof = new Terminal("$eof$");
            eof.Raw = new RawTerminal(eof.Name, new Eof(eof.Name));
            eof.IsGenerated = true;
            Grammar.Terminals.Add(eof);
            Grammar.Eof = eof;

            if (Grammar.Options.Whitespace == null)
            {
                var ws = new Terminal("$spc$")
                {
                    IsGenerated = true
                };
                var alt = new Alternates(new Tree.String("' '"), new Tree.String("'\t'"), new Tree.String("'\r'"), new Tree.String("'\n'"));
                var star = Repeat.From(alt, 0);
                ws.Raw = new RawTerminal(ws.Name, star);
                Grammar.Terminals.Add(ws);
                Grammar.WhitespaceDfa = ws.GetDfa().Convert();
            }
            else
            {
                var star = Repeat.From(Grammar.Options.Whitespace.Raw.Expression, 0);
                Grammar.WhitespaceDfa = star.GetFA().ToDfa().Convert();
            }

            int id = 0;
            foreach (var terminal in Grammar.Terminals.Where(t => !t.Raw.IsPrivate))
            {
                terminal.Id = id;
                terminal.Raw.Id = id;
                id += 1;
            }
            foreach (var terminal in Grammar.Terminals.Where(t => t.Raw.IsPrivate))
            {
                terminal.Id = id;
                terminal.Raw.Id = id;
                id += 1;
            }

            Grammar.Terminals.Sort(terminal => terminal.Id);
        }
    }
}
