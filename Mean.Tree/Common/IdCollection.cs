using Mean.Tree.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mean.Tree
{
    public class IdCollection<T> : Collection<T>
        where T : Item, IContained, IIdentified
    {
        public IdCollection(Item container)
            : base(container)
        {
        }

        public IdCollection(Item container, IEnumerable<T> items)
            : base(container, items)
        {
        }

        public override void Add(T item)
        {
            base.Add(item);
            Lookup.Add(item.Identifier, item);
        }

        private Dictionary<Identifier, T> Lookup { get; }

        public T GetItem(Identifier identifier)
        {
            if (Lookup.TryGetValue(identifier, out var item))
            {
                return item;
            }

            return default;
        }
    }
}
