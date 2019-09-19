using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class CoreFactory
    {
        public void Initialize(IReadOnlyList<Production> productions)
        {
            index = new Core[productions.Count][];

            var productionId = 0;
            var itemId = 0;
            foreach (var production in productions)
            {
                Debug.Assert(production.Id == productionId);
                productionId += 1;

                production.ItemFactory = this;

                var items = new Core[production.Count + 1];
                index[production.Id] = items;
                for (var dot = 0; dot <= production.Count; dot++)
                {
                    items[dot] = new Core(this, itemId, production, dot);
                    itemId += 1;
                }
            }
        }

        public Core Get(Production production)
        {
            return Get(production, 0);
        }

        public Core Get(Production production, int dot)
        {
            Debug.Assert(index != null);

            if (dot >= 0 && dot <= production.Count)
            {
                return index[production.Id][dot];
            }

            throw new ArgumentOutOfRangeException(nameof(dot));
        }

        private Core[][]? index;
    }
}