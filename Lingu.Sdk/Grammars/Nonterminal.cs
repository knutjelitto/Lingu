using System.Collections.Generic;
using Lingu.Commons;

namespace Lingu.Grammars
{
    public abstract class Nonterminal : Symbol
    {
        public Nonterminal(string name)
            : base(name)
        {
            Productions = new List<Production>();
        }

        public List<Production> Productions { get; set; }
    }
}
