namespace Lipeg.Runtime
{
    public interface IContext : ILocated
    {
        ISource Source { get; }
        int Offset { get; }
        IContext Advance(int count);
        int Current => Source[Offset];
        bool AtEnd => Source.AtEnd(Offset);

        bool StartsWith(string prefix)
        {
            return Source.StartsWith(Offset, prefix);
        }
    }
}
