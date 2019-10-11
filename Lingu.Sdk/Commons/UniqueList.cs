using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lingu.Commons
{
    public class UniqueList<T> : UniqueList<T, T> where T: notnull
    {
        public UniqueList()
            : base(item => item)
        {
        }
        public UniqueList(IEqualityComparer<T> eq)
            : base(item => item, eq)
        {
        }
    }

    public class UniqueList<TKey, TValue> : IReadOnlyList<TValue> where TKey: notnull
    {
        public UniqueList(Func<TValue, TKey> getKey)
            : this(getKey, new Dictionary<TKey, int>())
        {
        }

        public UniqueList(Func<TValue, TKey> getKey, IEqualityComparer<TKey> eq)
            : this(getKey, new Dictionary<TKey, int>(eq))
        {
        }

        private UniqueList(Func<TValue, TKey> getKey, Dictionary<TKey, int> index)
        {
            GetKey = getKey;

            Values = new List<TValue>();
            Index = index;
        }

        private List<TValue> Values { get; }
        private Dictionary<TKey, int> Index { get; }

        public TValue this[int index] => Values[index];

        public TValue this[TKey key] => Values[Index[key]];

        public int Count => Values.Count;

        public Func<TValue, TKey> GetKey { get; }

        public bool Contains(TKey key)
        {
            return Index.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            if (Index.TryGetValue(key, out var i))
            {
                value = Values[i];
                return true;
            }
            value = default;
            return false;
        }

        public virtual bool Add(TValue value)
        {
            var key = GetKey(value);
            if (Index.TryGetValue(key, out var _))
            {
                return false;
            }
            Index.Add(key, Values.Count);
            Values.Add(value);
            return true;
        }

        public virtual int MaybeAlreadyAdd(TValue value)
        {
            var key = GetKey(value);
            if (Index.TryGetValue(key, out var i))
            {
                return i;
            }
            Index.Add(key, Values.Count);
            Values.Add(value);
            return Values.Count - 1;
        }

        public void AddRange(IEnumerable<TValue> values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public void Sort<TSort>(Func<TValue, TSort> order)
        {
            var list = new List<TValue>(Values.OrderBy(value => order(value)));
            Values.Clear();
            Index.Clear();
            AddRange(list);
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
