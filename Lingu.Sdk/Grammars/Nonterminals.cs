using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Grammars
{
    public class Nonterminals : UniqueList<Symbol, Nonterminal>
    {
        public Nonterminals()
            : base(nonterminal => nonterminal)
        {
        }

        public override int Add(Nonterminal value)
        {
            if (TryGetValue(value, out var already))
            {
                already.Productions.AddRange(value.Productions);
                return already.Id;
            }

            return base.Add(value);
        }
    }
}
