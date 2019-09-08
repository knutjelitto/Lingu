﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Lingu.Commons
{
    public class UniqueList<T> : UniqueList<T, T>
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

    public class UniqueList<TKey, TValue> : IReadOnlyList<TValue>
    {
        public UniqueList(Func<TValue, TKey> getKey)
            : this(getKey, EqualityComparer<TKey>.Default)
        {
        }

        public UniqueList(Func<TValue, TKey> getKey, IEqualityComparer<TKey> eq)
        {
            GetKey = getKey;

            Values = new List<TValue>();
            Index = new Dictionary<TKey, int>(eq);
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

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (Index.TryGetValue(key, out var i))
            {
                value = Values[i];
                return true;
            }
            value = default;
            return false;
        }

        public int Add(TValue value)
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