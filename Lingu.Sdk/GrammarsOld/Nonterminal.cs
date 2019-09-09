using System.Collections.Generic;

namespace Lingu.GrammarsOld
{
    public class Nonterminal : Symbol
    {
        public Nonterminal(string name)
            : base(name)
        {
        }

        public List<Production> Body { get; set; }

        public Nonterminal Head => this;
    }
}