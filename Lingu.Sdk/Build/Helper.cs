using System.Collections.Generic;
using System.Linq;

using Lingu.Grammars;
using Lingu.LR;

namespace Lingu.Build
{
    public static class Helper
    {
        public static IEnumerable<T> ItemsOf<T>(this ItemSet itemSet)
            where T : Symbol
        {
            return itemSet
                .Where(i => !i.IsComplete && i.PostDot is T)
                .Select(t => t.PostDot as T)
                .Distinct()
                .OrderBy(t => t.Id);
        }
    }
}
