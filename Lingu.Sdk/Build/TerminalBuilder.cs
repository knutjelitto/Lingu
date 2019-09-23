using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Automata;
using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Runtime.Lexing;
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
            BuildTerminalsPass6(); // terminal compile (create automatons)
        }

        /// <summary>
        /// Build common dfa for parser needed terminals
        /// </summary>
        public void BuildPass3()
        {
            var terminals = Grammar.Terminals.Where(t => t.IsPid).ToList();

            FA? nfa = null;
            foreach (var terminal in terminals)
            {
                var tmp = terminal.Raw.Expression.GetFA().ToDfa().Minimize().RemoveDead();
                foreach (var state in tmp.States.Where(s => s.IsFinal))
                {
                    state.Payload = terminal.Id;
                }
                if (nfa == null)
                {
                    nfa = tmp.ToNfa();
                }
                else
                {
                    nfa = nfa.Or(tmp.ToNfa());
                }
            }

            Debug.Assert(nfa != null);

            var dfa = nfa.ToDfa().Minimize().RemoveDead();
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

            void CheckTerminalRecursion(Terminal terminal)
            {
                var path = new Stack<RawTerminal>();

                CheckTerminalRecursion2(terminal.Raw, path, terminal.Raw.Expression);
            }

            void CheckTerminalRecursion2(Terminal terminal, Stack<RawTerminal> path, IExpression expression)
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
            var eof = new Terminal("$");
            eof.Raw = new RawTerminal(eof.Name, new Eof(eof.Name));
            eof.IsGenerated = true;
            Grammar.Terminals.Add(eof);
            Grammar.Eof = eof;

            if (Grammar.Options.Whitespace == null)
            {
                var ws = new Terminal("&");
                var alt = new Alternates(new Tree.String(" "), new Tree.String("\t"), new Tree.String("\r"), new Tree.String("\n"));
                ws.Raw = new RawTerminal(ws.Name, alt);
                Grammar.Whitespace = ws;
            }
            else
            {
                Grammar.Whitespace = Grammar.Options.Whitespace;
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
                terminal.Bytes = DfaWriter.GetBytes(terminal.Raw.Expression.GetFA().ToDfa().Minimize().RemoveDead());
                terminal.Dfa = new DfaReader(terminal.Bytes).Read();
            }
        }
    }
}
