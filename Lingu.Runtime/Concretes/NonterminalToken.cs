using System;
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

        public IReadOnlyList<IToken> Children { get; }

        public IToken this[int childIndex] => Children[childIndex];

        public override String ToString()
        {
            return $"[{Symbol} ({string.Join(" ", Children.Select(c => c.Symbol.ToString()))})]";
        }
    }
}
