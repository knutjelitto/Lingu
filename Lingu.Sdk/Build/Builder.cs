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
        public Builder(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }

        public void Check()
        {
            CheckTerminals();
            CheckFragments();
        }

        public void Build()
        {
            BuildTerminals();
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

        public void CheckTerminals()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                CheckTerminal(terminal);
            }
        }

        private void CheckTerminal(TerminalDefinition terminal)
        {
            var path = new Stack<AtomName>();
            CheckTerminal(terminal.Name, path, terminal.Expression);
        }

        private void CheckTerminal(AtomName name, Stack<AtomName> path, Expression expression)
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

        private void CheckFragments()
        {
            foreach (var terminal in Grammar.Terminals)
            {
                terminal.IsFragment = true;
            }

            foreach (var rule in Grammar.Rules)
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
            foreach (var terminal in Grammar.Terminals)
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
