using System.Collections.Generic;
using Lingu.Commons;
using Lingu.Tree;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Nonterminal : Rule
    {
        public Nonterminal(string name)
            : base(name)
        {
            Productions = new List<Production>();
        }

        public bool IsEmbedded { get; set; }
        public RawNonterminal Raw { get; set; }

        public List<Production> Productions { get; set; }

        public override void Dump(IndentWriter output, bool top)
        {
            Raw.Dump(output, top);
        }
    }
}
