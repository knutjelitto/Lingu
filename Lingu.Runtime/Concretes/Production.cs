using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class Production : IProduction
    {
        private readonly bool[] drops;

        public Production(INonterminal nonterminal, params bool[] drops)
        {
            this.drops = drops;
            Nonterminal = nonterminal;
        }

        public int Length => this.drops.Length;
        public INonterminal Nonterminal { get; }
        public IEnumerable<IToken> DropFilter(IEnumerable<IToken> tokens)
        {
            return tokens.Where((token, index) => !this.drops[index]);
        }
    }
}
