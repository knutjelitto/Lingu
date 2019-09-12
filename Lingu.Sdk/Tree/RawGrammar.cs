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
        public List<RawTerminal> Terminals = new List<RawTerminal>();
        public List<RawNonterminal> Nonterminals = new List<RawNonterminal>();
    }
}
