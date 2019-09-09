using System;
using System.Collections.Generic;

using Lingu.Commons;
using Lingu.Tree;

namespace Lingu.Grammars
{
    public abstract class Grammar : Symbol
    {
        public Grammar(string name)
            : base(name)
        {
            Terminals = new UniqueList<Symbol, Terminal>(t => t);
            Nonterminals = new UniqueList<Symbol, Nonterminal>(n => n);
            Productions = new List<Production>();

            Options = new Options((TreeGrammar)this);
        }

        public Options Options { get; }

        public Nonterminal Start { get; set; }
        public Terminal Separator { get; set; }
        public Terminal Newline { get; set; }

        public virtual UniqueList<Symbol, Terminal> Terminals { get; }
        public UniqueList<Symbol, Nonterminal> Nonterminals { get; }
        public List<Production> Productions { get; }
    }
}
