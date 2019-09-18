using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;

#nullable enable

namespace Lingu.LR
{
    public class CoreSet : UniqueList<Core>
    {
        public CoreSet(params Core[] items)
            : this(new ItemEquality(), items)
        {
        }

        public CoreSet(IEqualityComparer<Core> eq, params Core[] items)
            : base(eq)
        {
            Ids = Array.Empty<int>();
            AddRange(items);
        }

        public int Id { get; set; }

        public bool Frozen => Ids.Length > 0;

        public void Freeze()
        {
            Ids = this.Select(i => i.Id).OrderBy(i => i).ToArray();
            var hash = new HashCode();
            foreach (var id in Ids)
            {
                hash.Add(id);
            }

            hashCode = hash.ToHashCode();
        }

        private int[] Ids { get; set; }

        public bool SetEquals(CoreSet other)
        {
            return Frozen && other.Frozen && Ids.SequenceEqual(other.Ids);
        }

        public override bool Equals(object? obj)
        {
            return obj is CoreSet other && SetEquals(other);
        }

        public override int GetHashCode()
        {
            return hashCode;
        }

        private int hashCode;

        private class ItemEquality : IEqualityComparer<Core>
        {
            public bool Equals(Core? x, Core ?y)
            {
                return x != null && y != null && x.Id == y.Id;
            }

            public int GetHashCode(Core obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
