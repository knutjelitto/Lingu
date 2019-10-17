using System.Collections.Generic;
using System.Linq;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class Production : IProduction
    {
        public Production(INonterminal nonterminal, string visual, bool[] drops, bool[] promotes)
        {
            Nonterminal = nonterminal;
            Visual = visual;
            Drops = drops;
            Promotes = promotes;
        }

        public INonterminal Nonterminal { get; }
        public bool IsPromote => Promotes.Any(p => p);
        public string Visual { get; }
        public bool[] Drops { get; }
        public bool[] Promotes { get; }
        public int Length => Drops.Length;

        public IEnumerable<IToken> DropFilter(IEnumerable<IToken> tokens)
        {
            return tokens.Where((token, index) => !Drops[index]);
        }
    }
}
