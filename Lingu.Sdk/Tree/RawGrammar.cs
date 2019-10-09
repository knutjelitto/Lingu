using System.Collections.Generic;

using Lingu.Grammars;

namespace Lingu.Tree
{
    public class RawGrammar
    {
        public RawGrammar(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public List<Option> Options = new List<Option>();
        public List<TerminalRule> Terminals = new List<TerminalRule>();
        public List<NonterminalRule> Nonterminals = new List<NonterminalRule>();
    }
}
