using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

#nullable enable

namespace Lingu.LR
{
    public class CoreSets : UniqueList<CoreSet>
    {
        public CoreSets(IEqualityComparer<CoreSet> eq)
            : base(eq)
        {
        }

        public CoreSets()
            : this(new ItemSetEquality())
        {
        }

        public override bool Add(CoreSet set)
        {
            Debug.Assert(!Contains(set));
            set.Id = Count;
            return base.Add(set);
        }

        public class ItemSetEquality : IEqualityComparer<CoreSet>
        {
            public bool Equals([AllowNull] CoreSet set1, [AllowNull] CoreSet set2)
            {
                return set1 != null && set2 != null && set1.SetEquals(set2);
            }

            public int GetHashCode([DisallowNull] CoreSet set)
            {
                return set.GetHashCode();
            }
        }
    }
}
