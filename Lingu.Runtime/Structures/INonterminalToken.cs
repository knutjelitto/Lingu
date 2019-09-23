using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface INonterminalToken : IToken
    {
        INonterminal Nonterminal { get; }
        IReadOnlyList<IToken> Children { get; }
    }
}
