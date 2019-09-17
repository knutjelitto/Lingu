using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;

#nullable enable

namespace Lingu.LR
{
    public class DottedSet : UniqueList<Dotted>
    {
        public DottedSet(params Dotted[] items)
            : this(new ItemEquality(), items)
        {
        }

        public DottedSet(IEqualityComparer<Dotted> eq, params Dotted[] items)
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

        public bool SetEquals(DottedSet other)
        {
            return Frozen && other.Frozen && Ids.SequenceEqual(other.Ids);
        }

        public override bool Equals(object? obj)
        {
            return obj is DottedSet other && SetEquals(other);
        }

        public override int GetHashCode()
        {
            return hashCode;
        }

        private int hashCode;

        private class ItemEquality : IEqualityComparer<Dotted>
        {
            public bool Equals(Dotted? x, Dotted ?y)
            {
                return x != null && y != null && x.Id == y.Id;
            }

            public int GetHashCode(Dotted obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
