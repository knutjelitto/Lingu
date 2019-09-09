using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Commons;

namespace Lingu.Grammars
{
    public class Grammar : Symbol<Grammar>
    {
        public Grammar(string name)
            : base(name)
        { 
        }

        public UniqueList<Terminal> Terminals { get; }
        public UniqueList<Nonterminal> Nonterminals { get; }
    }
}
