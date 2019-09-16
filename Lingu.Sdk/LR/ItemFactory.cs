using System;
using System.Collections.Generic;

using Lingu.Grammars;

namespace Lingu.LR
{
    public class ItemFactory
    {
        public ItemFactory(IEnumerable<Production> productions)
        {
            foreach (var production in productions)
            {
                var rules = new LR0Item[production.Count + 1];
                this.index.Add(production, rules);
                for (var dot = 0; dot <= production.Count; dot++)
                {
                    rules[dot] = new LR0Item(this, production, dot);
                }
            }
        }

        public LR0Item Get(Production production, int dot)
        {
            if (dot >= 0 && dot <= production.Count && this.index.TryGetValue(production, out var dotted) && dot < dotted.Length)
            {
                return dotted[dot];
            }

            throw new ArgumentOutOfRangeException(nameof(dot));
        }

        private readonly Dictionary<Production, LR0Item[]> index = new Dictionary<Production, LR0Item[]>();
    }
}