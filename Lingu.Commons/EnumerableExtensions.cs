using System.Collections.Generic;
using System.Linq;

namespace Lingu.Commons
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T Left, T Right)> GlidePairWise<T>(this IEnumerable<T> items)
        {
            var more = false;
            var first = default(T);

            foreach (var second in items)
            {
                if (more)
                {
                    yield return (first, second);
                }
                first = second;
                more = true;
            }
        }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static IEnumerable<T> Plus<T>(this IEnumerable<T> items, T item)
        {
            return items.Concat(Enumerable.Repeat(item, 1));
        }

    }
}
