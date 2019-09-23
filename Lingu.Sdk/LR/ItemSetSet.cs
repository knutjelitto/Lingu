using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using Lingu.Commons;

#nullable enable

namespace Lingu.LR
{
    public class ItemSetSet<TItem, TSet, TSetSet> : UniqueList<TSet>
        where TItem : Item<TItem>
        where TSet : ItemSet<TItem, TSet, TSetSet>, new()
        where TSetSet : ItemSetSet<TItem, TSet, TSetSet>
    {
        public ItemSetSet(IEqualityComparer<TSet> eq)
            : base(eq)
        {
        }

        public ItemSetSet()
            : this(new SetEquality())
        {
        }

        public override bool Add(TSet set)
        {
            Debug.Assert(!Contains(set));
            set.Id = Count;
            return base.Add(set);
        }

        public class SetEquality : IEqualityComparer<TSet>
        {
            public bool Equals([AllowNull] TSet set1, [AllowNull] TSet set2)
            {
                return set1 != null && set2 != null && set1.Equals(set2);
            }

            public int GetHashCode([DisallowNull] TSet set)
            {
                return set.GetHashCode();
            }
        }
    }
}
