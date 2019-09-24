using Lingu.Runtime.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Concretes
{
    public class NonterminalToken : Token, INonterminalToken
    {
        public NonterminalToken(INonterminal nonterminal)
            : base(nonterminal)
        {
            Children = Array.Empty<IToken>();
        }

        public INonterminal Nonterminal => (INonterminal)Symbol;

        public IReadOnlyList<IToken> Children { get; }
    }
}
