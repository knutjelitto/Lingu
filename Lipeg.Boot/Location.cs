using Lipeg.Runtime;
using Pegasus.Common;

namespace Lipeg.Boot
{
    internal class Location : ILocation
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

        public static ILocation From(ISource source, Cursor start)
        {
            return new Location(source, start.Location, start.Location);
        }

        public static ILocation From(ISource source, Cursor start, Cursor end)
        {
            return new Location(source, start.Location, end.Location);
        }

        public static ILocation From(ISource source, int start, int end)
        {
            return new Location(source, start, end);
        }
    }
}
