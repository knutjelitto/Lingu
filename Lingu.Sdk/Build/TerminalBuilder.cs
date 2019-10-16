using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Tree;

#nullable enable

namespace Lingu.Build
{
    public class TerminalBuilder
    {
        public TerminalBuilder(BuildGrammar buildGrammar, RawGrammar rawGrammar)
        {
            BuildGrammar = buildGrammar;
            RawGrammar = rawGrammar;
        }

        public BuildGrammar BuildGrammar { get; }
        public RawGrammar RawGrammar { get; }

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

        /// <summary>
        /// Create terminals.
        /// </summary>
        private void BuildTerminalsPass1()
        {
            foreach (var raw in RawGrammar.Terminals)
            {
                var terminal = new Terminal(raw.Name)
                {
                    Raw = raw
                };

                if (BuildGrammar.Terminals.Contains(terminal))
                {
                    throw new GrammarException($"terminal: `{terminal.Name}´ already defined before");
                }

                BuildGrammar.Terminals.Add(terminal);
            }
        }

        /// <summary>
        /// Resolving references
        /// </summary>
        private void BuildTerminalsPass2()
        {
            foreach (var terminal in BuildGrammar.Terminals)
            {
                Resolve(terminal.Raw.Expression);
            }

            void Resolve(IExpression expr)
            {
                if (expr is Name name)
                {
                    if (!BuildGrammar.Terminals.TryGetValue((Symbol)name.Text, out var terminal))
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
            foreach (var terminal in BuildGrammar.Terminals)
            {
                CheckTerminalRecursion(terminal);
            }

            static void CheckTerminalRecursion(Terminal terminal)
            {
                var path = new Stack<TerminalRule>();

                CheckTerminalRecursion2(terminal.Raw, path, terminal.Raw.Expression);
            }

            static void CheckTerminalRecursion2(Terminal terminal, Stack<TerminalRule> path, IExpression expression)
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
            foreach (var terminal in BuildGrammar.Terminals)
            {
                terminal.IsFragment = true;
                terminal.IsPrivate = true;
                terminal.IsVisible = false;
            }

            foreach (var nonterminal in BuildGrammar.Nonterminals)
            {
                foreach (var production in nonterminal.Productions)
                {
                    foreach (var terminal in production.Symbols.OfType<Terminal>())
                    {
                        terminal.IsFragment = false;
                        terminal.IsPrivate = false;
                    }

                    for (var i = 0; i < production.Count; ++i)
                    {
                        if (production.Symbols[i] is Terminal && !production.Drops[i])
                        {
                            production.Symbols[i].IsVisible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Add `eof´ + renumbering
        /// </summary>
        private void BuildTerminalsPass5()
        {
            var eof = new Terminal("__eof")
            {
                Visual = "$eof$",
                IsGenerated = true,

            };
            eof.Raw = TerminalRule.From(eof.Name, new Eof(eof.Name));
            BuildGrammar.Terminals.Add(eof);
            BuildGrammar.Eof = eof;

            if (BuildGrammar.Options.Spacing == null)
            {
                BuildGrammar.SpacingDfa = new None("__spc").GetFA().ToDfa().Minimize().RemoveDead();
            }
            else
            {
                var star = Repeat.From(BuildGrammar.Options.Spacing.Raw.Expression, 0);
                BuildGrammar.SpacingDfa = star.GetFA().ToDfa().Minimize().RemoveDead();
            }

            int id = 0;
            foreach (var terminal in BuildGrammar.Terminals.Where(t => !t.Raw.IsPrivate))
            {
                terminal.Id = id;
                terminal.Raw.Id = id;
                id += 1;
            }
            foreach (var terminal in BuildGrammar.Terminals.Where(t => t.Raw.IsPrivate))
            {
                terminal.Id = id;
                terminal.Raw.Id = id;
                id += 1;
            }

            BuildGrammar.Terminals.Sort(terminal => terminal.Id);
        }
    }
}
