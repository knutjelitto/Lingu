using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

#nullable enable

namespace Lingu.LR
{
    public class DottedSets : UniqueList<DottedSet>
    {
        public DottedSets(IEqualityComparer<DottedSet> eq)
            : base(eq)
        {
        }

        public DottedSets()
            : this(new ItemSetEquality())
        {
        }

        public override bool Add(DottedSet set)
        {
            Debug.Assert(!Contains(set));
            set.Id = Count;
            return base.Add(set);
        }

        public class ItemSetEquality : IEqualityComparer<DottedSet>
        {
            public bool Equals([AllowNull] DottedSet set1, [AllowNull] DottedSet set2)
            {
                return set1 != null && set2 != null && set1.SetEquals(set2);
            }

            public int GetHashCode([DisallowNull] DottedSet set)
            {
                return set.GetHashCode();
            }
        }
    }
}
