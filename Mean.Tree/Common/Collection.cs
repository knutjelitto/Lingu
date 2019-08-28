using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Mean.Tree.Items;

namespace Mean.Tree
{
    public class Collection<T> : IReadOnlyList<T>
        where T : Item, IContained
    {
        public Collection(Item container)
        {
            Items = new List<T>();
            Container = container;
        }

        public Collection(Item container, IEnumerable<T> items)
            : this(container)
        {
            AddRange(items);
        }

        public T this[int index]
        {
            get => Items[index];
        }
        public Item Container { get; }

        public int Count => Items.Count;

        private List<T> Items { get; }


        public virtual void Add(T item)
        {
            item.Container = Container;
            Items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
