using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lingu.Grammars;

namespace Lingu.LR
{
    public class DottedFactory
    {
        public void Initialize(IReadOnlyList<Production> productions)
        {
            index = new Dotted[productions.Count][];

            var productionId = 0;
            var itemId = 0;
            foreach (var production in productions)
            {
                Debug.Assert(production.Id == productionId);
                productionId += 1;

                production.ItemFactory = this;

                var items = new Dotted[production.Count + 1];
                index[production.Id] = items;
                for (var dot = 0; dot <= production.Count; dot++)
                {
                    items[dot] = new Dotted(this, itemId, production, dot);
                    itemId += 1;
                }
            }
        }

        public Dotted Get(Production production)
        {
            return Get(production, 0);
        }

        public Dotted Get(Production production, int dot)
        {
            if (dot >= 0 && dot <= production.Count)
            {
                return index[production.Id][dot];
            }

            throw new ArgumentOutOfRangeException(nameof(dot));
        }

        private Dotted[][] index;
    }
}