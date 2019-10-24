using Lipeg.Runtime;
using Pegasus.Common;

namespace Lipeg.Boot
{
    public class Location : ILocation
    {
        private Location(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; }
        public int End { get; }

        public static ILocation From(Cursor start)
        {
            return new Location(start.Location, start.Location);
        }

        public static ILocation From(Cursor start, Cursor end)
        {
            return new Location(start.Location, end.Location);
        }
    }
}
