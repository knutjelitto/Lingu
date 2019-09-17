using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;

namespace Lingu.Build
{
    public static class SetsHelper
    {
        public static IEnumerable<T> Items<T>(this ItemSet itemSet)
            where T : Symbol
        {
            return itemSet
                .Where(i => !i.IsComplete && i.PostDot is T)
                .Select(t => t.PostDot as T)
                .Distinct()
                .OrderBy(t => t.Id)
                .Where(t => t != null);
        }


        public static IEnumerable<ItemSet> Goto(this ItemSet itemSet)
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


        public static ItemSet Goto(this ItemSet itemSet, Symbol symbol)
        {
            var newSet = new ItemSet();
            foreach (var item in itemSet.Where(i => !i.IsComplete))
            {
                if (item.PostDot.Equals(symbol))
                {
                    newSet.Add(item.Next);
                }
            }

            return newSet.Close();
        }



        public static ItemSet Close(this ItemSet set)
        {
            for (int i = 0; i < set.Count; ++i)
            {
                var from = set[i];

                if (from.PostDot is Nonterminal nonterminal)
                {
                    foreach (var production in nonterminal.Productions)
                    {
                        set.Add(production.Initial);
                    }
                }
            }

            set.Freeze();

            return set;
        }

    }
}
