using System.Collections.Generic;
using System.IO;
using System.Linq;

using Lingu.Automata;
using Lingu.Errors;
using Lingu.Grammars;
using Lingu.Runtime.LexDfa;
using Lingu.Tree;

using Mean.Maker.Builders;

namespace Lingu.Build
{
    public class Builder
    {
        public Builder(TreeGrammar tree)
        {
            Grammar = tree;
        }

        public TreeGrammar Grammar { get; }

        public void Build()
        {
            CheckTerminals();
            CheckFragments();

            BuildTerminals();

            if (Grammar.Options.Newline != null)
                Grammar.Options.Newline.IsFragment = false;
            if (Grammar.Options.Separator != null)
                Grammar.Options.Separator.IsFragment = false;

            RenumberTerminals();
        }

        public void Dump(FileRef dests)
        {
            var grammarDump = dests.Add(".Grammar");
            var terminals = dests.Add(".Terminals");

            using (var writer = new StreamWriter(grammarDump))
            {
                Grammar.Dump(writer);
            }
            using (var writer = new StreamWriter(terminals))
            {
                Grammar.DumpTerminals(writer);
            }
        }

        private void CheckTerminals()
        {
            foreach (var terminal in Grammar.Terminals.Cast<TerminalDefinition>())
            {
                CheckTerminal(terminal);
            }
        }

        private void CheckTerminal(TerminalDefinition terminal)
        {
            var path = new Stack<TerminalDefinition>();
            CheckTerminal(terminal, path, terminal.Expression);
        }

        private void CheckTerminal(TerminalDefinition terminal, Stack<TerminalDefinition> path, Expression expression)
        {
            if (expression is Reference reference)
            {
                var definition = (TerminalDefinition)reference.Definition;

                if (terminal.Equals(definition))
                {
                    var msg = $"terminal rule `{terminal.Name}´ is recursive (via ->{string.Join("->", path.Reverse())}->{terminal.Name})";
                    throw new GrammarException(msg);
                }

                path.Push(definition);
                CheckTerminal(terminal, path, definition.Expression);
                path.Pop();
            }
            else
            {
                foreach (var childExpression in expression.Children)
                {
                    CheckTerminal(terminal, path, childExpression);
                }
            }
        }

        private void CheckFragments()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                terminal.IsFragment = true;
            }

            foreach (var rule in Grammar.Nonterminals.Cast<RuleDefinition>())
            {
                CheckFragment(rule.Expression);
            }
        }

        private void CheckFragment(Expression expression)
        {
            if (expression is Reference reference && reference.Definition is TerminalDefinition terminal)
            {
                terminal.IsFragment = false;
            }

            foreach (var subExpression in expression.Children)
            {
                CheckFragment(subExpression);
            }
        }

        private void RenumberTerminals()
        {
            int id = 0;
            foreach (var terminal in Grammar.Terminals.Where(t => !t.IsFragment))
            {
                terminal.Id = id;
                id += 1;
            }
            foreach (var terminal in Grammar.Terminals.Where(t => t.IsFragment))
            {
                terminal.Id = id;
                id += 1;
            }
        }

        private void BuildTerminals()
        {
            foreach (var definition in Grammar.Terminals.Cast<TerminalDefinition>())
            {
                BuildTerminal(definition);
            }
        }

        private void BuildTerminal(TerminalDefinition definition)
        {
            definition.Alias = definition.IsGenerated ? definition.Expression.ToString() : null;
            definition.Bytes = Writer.Compact(definition.Expression.GetFA().ToDfa().Minimize().RemoveDead());
            definition.Dfa = new DfaReader(definition.Bytes).Read();
        }
    }
}
