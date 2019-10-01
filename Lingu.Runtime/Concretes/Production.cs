using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class Production : IProduction
    {
        public Production(INonterminal nonterminal, string visual, params bool[] drops)
        {
            Nonterminal = nonterminal;
            Visual = visual;
            Drops = drops;
        }

        public INonterminal Nonterminal { get; }
        public string Visual { get; }
        public bool[] Drops { get; }
        public int Length => Drops.Length;

        public IEnumerable<IToken> DropFilter(IEnumerable<IToken> tokens)
        {
            return tokens.Where((token, index) => !Drops[index]);
        }
    }
}
