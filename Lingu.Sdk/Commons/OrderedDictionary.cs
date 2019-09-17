using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lingu.Commons
{
    public class OrderedDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {
        private readonly List<TKey> keys = new List<TKey>();
        private readonly Dictionary<TKey, TValue> map = new Dictionary<TKey, TValue>();

        public TValue this[TKey key] => map[key];
        public IEnumerable<TKey> Keys => keys;
        public IEnumerable<TValue> Values => keys.Select(k => map[k]);
        public int Count => keys.Count;

        public bool ContainsKey(TKey key)
        {
            return map.ContainsKey(key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            return map.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return keys.Select(key => new KeyValuePair<TKey, TValue>(key, map[key])).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); ;
        }
    }
}
