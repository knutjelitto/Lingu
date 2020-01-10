using System.Diagnostics;

namespace Lipeg.Runtime
{
    public struct SourceContext : IContext
    {
        private SourceContext(ISource source, int offset)
        {
            Source = source;
            Offset = offset;
        }

        public ISource Source { get; }

        public int Offset { get; }

        public IContext Advance(int count)
        {
            Debug.Assert(count >= 0);
            return new SourceContext(Source, Offset + count);
        }

        public static IContext Start(ISource source)
        {
            return new SourceContext(source, 0);
        }

        public override string ToString()
        {
            var (line, col) = Source.GetLineCol(Offset);
            return $"({line},{col}){Source.GetText(Offset, 10)} \u2026";
        }
    }
}
