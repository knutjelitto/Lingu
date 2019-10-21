using Lingu.Runtime.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lingu.Runtime.Concretes
{
    [DebuggerDisplay("{DbgOut()}")]
    public class Location : ILocation
    {
        private Location(ISource source, int start, int end)
        {
            Source = source;
            Offset = start;
            Length = end - start;
        }

        public ISource Source { get; }
        public int Offset { get; }
        public int Length { get; }

        public static Location From(ISource source, int start)
        {
            return new Location(source, start, start);
        }

        public static Location From(ISource source, int start, int end)
        {
            return new Location(source, start, end);
        }

        public string GetText()
        {
            return Source.GetText(Offset, Length);
        }

        public string DbgOut()
        {
            var (lineNo, colNo) = Source.GetLineCol(Offset);

            return $"{Source.Name}:{lineNo}:{colNo}";
        }
    }
}
