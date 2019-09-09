using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Grammars
{
    public class Nonterminal : Symbol<Nonterminal>
    {
        public Nonterminal(string name)
            : base(name)
        {
        }
    }
}
