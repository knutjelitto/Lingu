using Lingu.Runtime.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Concretes
{
    public struct Location : ILocation
    {
        public Location(ISource source, int offset, int length)
        {
            Source = source;
            Offset = offset;
            Length = length;
        }

        public ISource Source { get; }
        public int Offset { get; }
        public int Length { get; }
    }
}
