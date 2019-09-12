using Lingu.Writers;

namespace Lingu.Grammars
{
    public interface ICanDump
    {
        void Dump(IndentWriter output, bool top);
    }
}
