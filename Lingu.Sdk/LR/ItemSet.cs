using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Lingu.Commons;

#nullable enable

namespace Lingu.LR
{
    public class ItemSet : UniqueList<Item>
    {

        public ItemSet(params Item[] items)
            : this(new ItemEquality(), items)
        {
        }

        public ItemSet(IEqualityComparer<Item> eq, params Item[] items)
            : base(eq)
        {
            Ids = Array.Empty<int>();
            AddRange(items);
        }

        public bool Frozen => Ids != null;

        public void Freeze()
        {
            Ids = this.Select(i => i.Id).OrderBy(i => i).ToArray();
        }

        private int[] Ids { get; set; }

        public bool SetEquals(ItemSet other)
        {
            return Frozen && other.Frozen && Ids.SequenceEqual(other.Ids);
        }

        private class ItemEquality : IEqualityComparer<Item>
        {
            public bool Equals(Item? x, Item ?y)
            {
                return x != null && y != null && x.Id == y.Id;
            }

            public int GetHashCode(Item obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
