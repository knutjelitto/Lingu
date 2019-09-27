using Lingu.Runtime.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Concretes
{
    public struct Location : ILocation
    {
        public Location(ISource source, int start, int end)
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
    }
}
