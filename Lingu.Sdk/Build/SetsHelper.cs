using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;

namespace Lingu.Build
{
    public static class SetsHelper
    {
        public static IEnumerable<TSet> Goto<TItem, TSet>(this TSet itemSet)
            where TSet : ItemSet<TItem, TSet>, new()
            where TItem : Item
        {
            foreach (var terminal in itemSet.Items<Terminal>())
            {
                yield return itemSet.Goto(terminal);
            }
            foreach (var nonterminal in itemSet.Items<Nonterminal>())
            {
                yield return itemSet.Goto(nonterminal);
            }
        }
    }
}
