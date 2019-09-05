using Lingu.Commons;

namespace Lingu.Tree
{
    public interface IDumpable
    {
        void Dump(IWriter output, bool top);
    }
}
