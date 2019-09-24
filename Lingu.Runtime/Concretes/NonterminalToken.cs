using System.Collections.Generic;
using System.Linq;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class NonterminalToken : Token, INonterminalToken
    {
        public NonterminalToken(INonterminal nonterminal, IReadOnlyList<IToken> children)
            : base(nonterminal)
        {
            Children = children.ToArray();
        }

        public INonterminal Nonterminal => (INonterminal)Symbol;

        public IReadOnlyList<IToken> Children { get; }
    }
}
