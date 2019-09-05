using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
