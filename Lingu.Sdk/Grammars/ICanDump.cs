using Lingu.Writers;

#nullable enable

namespace Lingu.Grammars
{
    public interface ICanDump
    {
        void Dump(IndentWriter writer);
    }
}
