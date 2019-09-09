using System.Collections.Generic;
using System.IO;
using System.Linq;

using Lingu.Automata;
using Lingu.Errors;
using Lingu.Tree;

using Mean.Maker.Builders;

namespace Lingu.Build
{
    public class Builder
    {
        public Builder(GrammarTree tree)
        {
            Tree = tree;
        }

        public GrammarTree Tree { get; }

        public void Build()
        {
            CheckTerminals();
            CheckFragments();
            CheckOptions();

            BuildTerminals();
        }

        public void Dump(FileRef dests)
        {
            var grammarDump = dests.Add(".Grammar");
            var terminals = dests.Add(".Terminals");

            using (var writer = new StreamWriter(grammarDump))
            {
                Tree.Dump(writer);
            }
            using (var writer = new StreamWriter(terminals))
            {
                Tree.DumpTerminals(writer);
            }
        }

        private void CheckTerminals()
        {
            foreach (var terminal in Tree.Terminals)
            {
                CheckTerminal(terminal);
            }
        }

        private void CheckTerminal(TerminalDefinition terminal)
        {
            var path = new Stack<Name>();
            CheckTerminal(terminal.Name, path, terminal.Expression);
        }

        private void CheckTerminal(Name name, Stack<Name> path, Expression expression)
        {
            if (expression is Reference reference)
            {
                var terminal = reference.Definition;

                if (name.Equals(terminal.Name))
                {
                    var msg = $"terminal rule `{name}´ is recursive (via ->{string.Join("->", path.Reverse())}->{name})";
                    throw new GrammarException(msg);
                }

                path.Push(terminal.Name);
                CheckTerminal(name, path, terminal.Expression);
                path.Pop();
            }
            else
            {
                foreach (var childExpression in expression.Children)
                {
                    CheckTerminal(name, path, childExpression);
                }
            }
        }

        private void CheckOptions()
        {
            foreach (var option in Tree.Options)
            {
                switch (option.Name.Text.ToLowerInvariant())
                {
                    case "start":
                        break;
                    case "separator":
                        if (!Tree.Terminals.TryGetValue(option.Value.Text, out var separator))
                        {
                            throw new GrammarException($"option `{option.Name}´: no such terminal rule `{option.Value}´");
                        }
                        separator.IsFragment = false;
                        break;
                    case "newline":
                        if (!Tree.Terminals.TryGetValue(option.Value.Text, out var newline))
                        {
                            throw new GrammarException($"option `{option.Name}´: no such terminal rule `{option.Value}´");
                        }
                        newline.IsFragment = false;

                        break;
                    default:
                        throw new GrammarException($"option `{option.Name}´: no such option");
                }
            }
        }

        private void CheckFragments()
        {
            foreach (var terminal in Tree.Terminals)
            {
                terminal.IsFragment = true;
            }

            foreach (var rule in Tree.Rules)
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

        private void BuildTerminals()
        {
            foreach (var terminal in Tree.Terminals)
            {
                BuildTerminal(terminal);
            }
        }

        private void BuildTerminal(TerminalDefinition terminal)
        {
            terminal.Dfa = terminal.Expression.GetFA().ToDfa().Minimize().RemoveDead();
            terminal.Bytes = Writer.Compact(terminal.Dfa);
        }
    }
}
