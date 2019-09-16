using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Lingu.Commons;

namespace Lingu.Grammars
{
    public class NonterminalList : UniqueList<Symbol, Nonterminal>
    {
        public NonterminalList()
            : base(nonterminal => nonterminal, new Symbol.NamesEquals())
        {
        }
    }
}
