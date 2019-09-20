using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class From<TItem, TSet, TSetSet>
        where TItem : Item<TItem>
        where TSet : ItemSet<TItem, TSet, TSetSet>
        where TSetSet : ItemSetSet<TItem, TSet, TSetSet>
    {
        public From(TSet set, Symbol symbol)
        {
            Set = set;
            Symbol = symbol;
        }

        public TSet Set { get; }
        public Symbol Symbol { get; }
    }
}
