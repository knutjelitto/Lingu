using Lingu.Commons;
using Lingu.Tree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lingu.Grammars
{
    public class Nonterminals : UniqueList<Symbol, Nonterminal>
    {
        public Nonterminals()
            : base(nonterminal => nonterminal)
        {
        }
    }
}
