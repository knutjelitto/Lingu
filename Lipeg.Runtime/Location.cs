using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Runtime
{
    public class Location : ILocation
    {
        private Location(ISource source, int start, int end)
        {
            Source = source;
            Start = start;
            End = end;
        }

        public ISource Source { get; }
        public int Start { get; }
        public int End { get; }

        public static ILocation From(ILocation start, ILocation end)
        {
            return new Location(start.Source, start.Start, end.End);
        }
    }
}
