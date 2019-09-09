using Lingu.Commons;

namespace Lingu.Grammars
{
    public interface IDumpable
    {
        void Dump(IWriter output, bool top);
    }
}
