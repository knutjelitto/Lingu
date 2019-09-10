using Lingu.Commons;

namespace Lingu.Grammars
{
    public interface ICanDump
    {
        void Dump(IWriter output, bool top);
    }
}
