using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lingu.Grammars;

namespace Lingu.LR
{
    public class ItemFactory
    {
        public ItemFactory()
        {
        }

        public void Initialize(IReadOnlyList<Production> productions)
        {
            index = new Item[productions.Count][];

            var productionId = 0;
            var itemId = 0;
            foreach (var production in productions)
            {
                Debug.Assert(production.Id == productionId);
                productionId += 1;

                production.ItemFactory = this;

                var items = new Item[production.Count + 1];
                index[production.Id] = items;
                for (var dot = 0; dot <= production.Count; dot++)
                {
                    items[dot] = new Item(this, itemId, production, dot);
                    itemId += 1;
                }
            }
        }

        public Item Get(Production production)
        {
            return Get(production, 0);
        }

        public Item Get(Production production, int dot)
        {
            if (dot >= 0 && dot <= production.Count)
            {
                var items = index[production.Id];
                if (dot < items.Length)
                {
                    return items[dot];
                }
            }

            throw new ArgumentOutOfRangeException(nameof(dot));
        }

        private Item[][] index;
    }
}