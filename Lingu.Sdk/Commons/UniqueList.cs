using System;
using System.Collections;
using System.Collections.Generic;

namespace Lingu.Commons
{
    public class UniqueList<T> : UniqueList<T, T>
    {
        public UniqueList() : base(item => item)
        {
        }
    }

    public class UniqueList<TKey,TValue> : IReadOnlyList<TValue>
    {
        private readonly List<TValue> values = new List<TValue>();
        private readonly Dictionary<TKey, TValue> index = new Dictionary<TKey, TValue>();

        public UniqueList(Func<TValue, TKey> getKey)
        {
            GetKey = getKey;
        }

        public TValue this[int index] => values[index];

        public TValue this[TKey key] => index[key];

        public int Count => values.Count;

        public IEnumerable<TKey> Keys => index.Keys;

        public IEnumerable<TValue> Values => values;

        public Func<TValue, TKey> GetKey { get; }

        public bool Contains(TKey key)
        {
            return index.ContainsKey(key);
        }

        public bool ContainsKey(TKey key)
        {
            return index.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return index.TryGetValue(key, out value);
        }

        public void MaybeAdd(TValue value)
        {
            var key = GetKey(value);
            if (!Contains(key))
            {
                index.Add(GetKey(value), value);
                values.Add(value);
            }
        }

        public void Add(TValue value)
        {
            index.Add(GetKey(value), value);
            values.Add(value);
        }

        public void AddRange(IEnumerable<TValue> values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
