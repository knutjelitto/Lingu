using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Automata
{
    public class IntegerSet : IEnumerable<int>
    {
        public static readonly IntegerSet Empty = new IntegerSet();

        public IntegerSet(IntegerRange range)
            : this(Enumerable.Repeat(range, 1))
        {
        }

        public IntegerSet()
            : this(Enumerable.Empty<IntegerRange>())
        {
        }

        public IntegerSet(params (int min, int max)[] ranges)
            : this(ranges.Select(p => new IntegerRange(p.min, p.max)))
        {
        }

        public IntegerSet(IEnumerable<IntegerSet> set)
            : this(set.SelectMany(s => s.ranges))
        {
        }

        public IntegerSet(IEnumerable<IntegerRange> ranges)
        {
            this.ranges = new List<IntegerRange>();
            foreach (var range in ranges)
            {
                Add(range);
            }
        }

        public int Cardinality => ranges.Sum(range => range.Count);

        public bool IsEmpty => ranges.Count == 0;

        public int Max => ranges.Last().Max;

        public int Min => ranges.First().Min;

        public int RangeCount => ranges.Count;

        public static IntegerSet Parse(string str)
        {
            if (TryParse(str, out var set))
            {
                return set;
            }
            return null;
        }

        public static bool TryParse(string str, out IntegerSet set)
        {
            if (str.Length == 0 || str[0] != '[')
            {
                set = null;
                return false;
            }

            var start = 1;
            var end = 1;
            set = new IntegerSet();
            while (end < str.Length)
            {
                while (end < str.Length && str[end] != ',' && str[end] != ']')
                {
                    end = end + 1;
                }
                if (end > start && IntegerRange.TryParse(str.Substring(start, end - start), out var range))
                {
                    set.Add(range);
                    start = end = end + 1;
                }
                else
                {
                    break;
                }
            }

            if (end == str.Length)
            {
                return true;
            }

            set = null;
            return false;
        }

        public void Add(int value)
        {
            Add(new IntegerRange(value));
        }

        public void Add(params (int min, int max)[] rangesToAdd)
        {
            Add(rangesToAdd.Select(range => new IntegerRange(range.min, range.max)));
        }

        public void Add(IntegerSet other)
        {
            Add(other.ranges);
        }

        public IntegerSet Clone()
        {
            return new IntegerSet(ranges);
        }

        public bool Contains(int value)
        {
            return Find(value, out var _);
        }

        public override bool Equals(object obj)
        {
            return obj is IntegerSet other && ranges.SequenceEqual(other.ranges);
        }

        public IntegerSet ExceptWith(IntegerSet other)
        {
            var set = Clone();
            set.Sub(other.ranges);
            return set;
        }

        public IntegerSet IntersectWith(IntegerSet other)
        {
            var union = this.UnionWith(other);
            var ex1 = this.ExceptWith(other);
            var ex2 = other.ExceptWith(this);

            return union.ExceptWith(ex1).ExceptWith(ex2);
        }

        public string FmtCSharp()
        {
            return "";
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var range in ranges)
            {
                foreach (var value in range)
                {
                    yield return value;
                }
            }
        }

        public override int GetHashCode()
        {
            return ranges.Hash();
        }

        public IEnumerable<IntegerRange> GetRanges()
        {
            return ranges;
        }

        public IEnumerable<int> GetValues()
        {
            return ranges.SelectMany(range => range);
        }

        public bool IsProperSubsetOf(IntegerSet other)
        {
            return IsSubsetOf(other) && !Equals(other);
        }

        public bool IsProperSupersetOf(IntegerSet other)
        {
            return IsSupersetOf(other) && !Equals(other);
        }

        public bool IsSubsetOf(IntegerSet other)
        {
            foreach (var range in ranges)
            {
                if (!other.Contains(range))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsSupersetOf(IntegerSet other)
        {
            return other.IsSubsetOf(this);
        }

        public bool Overlaps(IntegerSet other)
        {
            var t = 0;
            var o = 0;

            while (t < ranges.Count && o < other.ranges.Count)
            {
                while (t < ranges.Count && o < other.ranges.Count && ranges[t].Max < other.ranges[o].Min)
                {
                    t += 1;
                }

                while (t < ranges.Count && o < other.ranges.Count && other.ranges[o].Max < ranges[t].Min)
                {
                    o += 1;
                }

                if (t < ranges.Count && o < other.ranges.Count && other.ranges[o].Overlaps(ranges[t]))
                {
                    return true;
                }
            }

            return false;
        }

        public void Sub(int value)
        {
            Sub(new IntegerRange(value));
        }

        public void Sub(params (int min, int max)[] rangesToSub)
        {
            Sub(rangesToSub.Select(range => new IntegerRange(range.min, range.max)));
        }

        public IntegerSet Substract(IntegerSet other)
        {
            return Clone().Sub(other.ranges);
        }

        public override string ToString()
        {
            return $"[{string.Join(",", ranges)}]";
        }

        public string ToIString()
        {
            return $"[{string.Join(",", ranges.Select(r => r.ToIString()))}]";
        }

        public IntegerSet UnionWith(IntegerSet other)
        {
            var set = Clone();
            set.Add(other.ranges);
            return set;
        }

        public static IntegerSet operator +(IntegerSet set1, IntegerSet set2)
        {
            return set2.UnionWith(set2);
        }

        public static IntegerSet operator /(IntegerSet set1, IntegerSet set2)
        {
            return set1.ExceptWith(set2);
        }

        private void Add(IntegerRange add)
        {
            var i = 0;
            while (i < ranges.Count)
            {
                var current = ranges[i];

                if (add.Min > current.Max + 1)
                {
                    ++i;
                    continue;
                }

                if (add.Max + 1 < current.Min)
                {
                    // before current
                    ranges.Insert(i, add);
                    return;
                }

                if (add.Max <= current.Max)
                {
                    // combine with current
                    ranges[i] = new IntegerRange((char) Math.Min(add.Min, current.Min), current.Max);
                    return;
                }

                add = new IntegerRange((char) Math.Min(add.Min, current.Min), add.Max);
                ranges.RemoveAt(i);
            }

            if (i == ranges.Count)
            {
                ranges.Add(add);
            }
        }

        private void Add(IEnumerable<IntegerRange> rangesToAdd)
        {
            foreach (var range in rangesToAdd)
            {
                Add(range);
            }
        }

        private bool Contains(IntegerRange range)
        {
            return Find(range.Min, out var found) && range.Max <= found.Max;
        }

        private bool Find(int value, out IntegerRange range)
        {
            bool Find(int lower, int upper, out IntegerRange found)
            {
                if (upper < lower)
                {
                    found = default;
                    return false;
                }

                var mid = lower + (upper - lower) / 2;

                if (ranges[mid].Contains(value))
                {
                    found = ranges[mid];
                    return true;
                }
                if (value < ranges[mid].Min)
                {
                    return Find(lower, mid - 1, out found);
                }
                return Find(mid + 1, upper, out found);
            }

            return Find(0, ranges.Count - 1, out range);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Sub(IntegerRange sub)
        {
            var i = 0;

            while (i < ranges.Count)
            {
                var range = ranges[i];

                if (sub.Max < range.Min)
                {
                    i += 1;
                    continue;
                }

                if (range.Max < sub.Min)
                {
                    i += 1;
                    continue;
                }

                if (sub.Min <= range.Min)
                {
                    // cover from below
                    if (sub.Max >= range.Max)
                    {
                        // full cover
                        ranges.RemoveAt(i);
                    }
                    else
                    {
                        ranges[i] = new IntegerRange(sub.Max + 1, range.Max);
                        i += 1;
                    }
                    continue;
                }

                if (range.Max <= sub.Max)
                {
                    // cover from above
                    if (range.Min >= sub.Min)
                    {
                        // full cover
                        ranges.RemoveAt(i);
                    }
                    else
                    {
                        ranges[i] = new IntegerRange(range.Min, sub.Min - 1);
                        i += 1;
                    }
                    continue;
                }

                // inner
                // sub.Min > range.Min && range.Max > sub.Max
                ranges.Insert(i, new IntegerRange(range.Min, sub.Min - 1));
                ranges[i + 1] = new IntegerRange(sub.Max + 1, range.Max);
                // done
                break;
            }
        }

        public IntegerSet Sub(IEnumerable<IntegerRange> rangesToSub)
        {
            foreach (var range in rangesToSub)
            {
                Sub(range);
            }

            return this;
        }

        private readonly List<IntegerRange> ranges;
    }
}