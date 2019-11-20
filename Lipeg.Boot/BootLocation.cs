using Lipeg.Runtime;
using Pegasus.Common;

namespace Lipeg.Boot
{
    internal class BootLocation : ILocation
    {
        private BootLocation(ISource source, int start, int end)
        {
            Source = source;
            Start = start;
            End = end;
        }

        public ISource Source { get; }
        public int Start { get; }
        public int End { get; }

        public static ILocation From(ISource source, Pegasus.Common.Cursor start)
        {
            return new BootLocation(source, start.Location, start.Location);
        }

        public static ILocation From(ISource source, Pegasus.Common.Cursor start, Pegasus.Common.Cursor end)
        {
            return new BootLocation(source, start.Location, end.Location);
        }

        public static ILocation From(ISource source, int start, int end)
        {
            return new BootLocation(source, start, end);
        }
    }
}
