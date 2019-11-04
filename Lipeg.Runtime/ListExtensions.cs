using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public static class ListExtensions
    {
        public static IStarList<T> ToStarList<T>(this IEnumerable<T> list)
        {
            return new StarList<T>(list);
        }
        public static IPlusList<T> ToPlusList<T>(this IEnumerable<T> list)
        {
            return new PlusList<T>(list);
        }
        public static IOption<T> ToOption<T>(this IEnumerable<T> list)
        {
            return new Option<T>(list);
        }
    }
}
