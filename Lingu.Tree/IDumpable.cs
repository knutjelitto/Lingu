using Lingu.Commons;

namespace Lingu.Tree
{
    public interface IDumpable
    {
        void Dump(Indentable output, bool top);
    }
}
