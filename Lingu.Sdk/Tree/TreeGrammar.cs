#if false
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;
using Lingu.Errors;
using Lingu.Tools;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public class TreeGrammar : Grammar
    {
        public TreeGrammar(string name)
            : base(name)
        {
            TreeOptions = new TreeOptions();
            References = new List<Reference>();
        }

        public TreeOptions TreeOptions { get; }
        //public Rules Rules { get; }

        public List<Reference> References { get; }

        public TreeTerminal GenTerminal(IExpression expression)
        {
            var name = "__T" + nextTerminalId++;

            var terminal = new TreeTerminal(true, name, expression);

            Terminals.Add(terminal);

            return terminal;
        }

        public TreeNonterminal GenRule(IExpression expression)
        {
            var name = "__N" + nextRuleId++;

            var terminal = new TreeNonterminal(true, name, expression);

            Nonterminals.Add(terminal);

            return terminal;
        }

        public void Resolve()
        {
            foreach (var reference in References)
            {
                if (reference.Kind == ReferenceKind.Terminal)
                {
                    if (!Terminals.TryGetValue(reference, out var terminal))
                    {
                        throw new TreeException($"can't resolve reference to terminal `{reference.Name}`");
                    }
                    reference.ResolveTo((TreeTerminal)terminal);
                }
                else if (reference.Kind == ReferenceKind.TerminalOrRule)
                {
                    if (!Nonterminals.TryGetValue(reference, out var rule))
                    {
                        if (!Terminals.TryGetValue(reference, out var terminal))
                        {
                            throw new TreeException($"can't resolve reference to rule or terminal `{reference.Name}`");
                        }
                        reference.ResolveTo((TreeTerminal)terminal);
                    }
                    else
                    {
                        reference.ResolveTo((TreeNonterminal)rule);
                    }
                }
            }
        }

        public void DumpTerminals(TextWriter writer)
        {
        }


        private int nextTerminalId = 1;
        private int nextRuleId = 1;
    }
}
#endif