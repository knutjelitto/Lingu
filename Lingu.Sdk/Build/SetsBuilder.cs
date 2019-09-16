using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;

namespace Lingu.Build
{
    public class SetsBuilder
    {
        public SetsBuilder(Grammar grammar)
        {
            Grammar = grammar;
        }

        public Grammar Grammar { get; }
        public ItemFactory ItemFactory { get; private set; }

        public void Build()
        {
            ItemFactory = new ItemFactory(Grammar.Nonterminals.SelectMany(n => n.Productions).ToList());

            var start = ItemFactory.Get(Grammar.Nonterminals[0].Productions[0]);

            var set0 = new ItemSet(start);
            Closure(set0);

            Grammar.ItemSets.Add(set0);

            for (var i = 0; i < Grammar.ItemSets.Count; ++i)
            {
                foreach (var newSet in Goto(Grammar.ItemSets[i]))
                {
                    bool already = false;
                    for (var j = 0; j <= i; ++j)
                    {
                        if (newSet.SetEquals(Grammar.ItemSets[j]))
                        {
                            already = true;
                            break;
                        }
                    }
                    if (!already)
                    {
                        Grammar.ItemSets.Add(newSet);
                    }
                }
            }
        }

        private Item Start(Production production)
        {
            return ItemFactory.Get(production);
        }

        private void Closure(ItemSet set)
        {
            for (int i = 0; i < set.Count; ++i)
            {
                var from = set[i];

                if (from.PostDot is Nonterminal nonterminal)
                {
                    foreach (var production in nonterminal.Productions)
                    {
                        set.Add(Start(production));
                    }
                }
            }
        }

        private ItemSet Goto(ItemSet itemSet, Symbol symbol)
        {
            var newSet = new ItemSet();
            foreach (var item in itemSet.Where(i => !i.IsComplete))
            {
                if (item.PostDot.Equals(symbol))
                {
                    newSet.Add(item.Next);
                }
            }
            Closure(newSet);

            return newSet;
        }

        private IEnumerable<ItemSet> Goto(ItemSet itemSet)
        {
            foreach (var nonterminal in itemSet.ItemsOf<Nonterminal>())
            {
                yield return Goto(itemSet, nonterminal);
            }

            foreach (var terminal in itemSet.ItemsOf<Terminal>())
            {
                yield return Goto(itemSet, terminal);
            }
        }
    }
}
