using System.Collections.Generic;
using Lingu.Commons;

namespace Lingu.Grammars
{
    public abstract class Nonterminal : Rule
    {
        public Nonterminal(int id, string name)
            : base(id, name)
        {
            Productions = new List<Production>();
        }

        public Nonterminal(string name)
            : this(-1, name)
        {
            Productions = new List<Production>();
        }

        public bool IsEmbedded { get; set; }

        public List<Production> Productions { get; set; }
    }
}
