using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Lingu.Commons;

namespace Lingu.LR
{
    public class ItemSet : UniqueList<Item>
    {
        public ItemSet()
            : base(new ItemEquality())
        {
        }

        public ItemSet(params Item[] items)
            : base(new ItemEquality())
        {
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
            return Frozen && other.Frozen == Ids.SequenceEqual(other.Ids);
        }

        private class ItemEquality : IEqualityComparer<Item>
        {
            public bool Equals([AllowNull] Item x, [AllowNull] Item y)
            {
                return x != null && y != null && x.Id == y.Id;
            }

            public int GetHashCode([DisallowNull] Item obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
