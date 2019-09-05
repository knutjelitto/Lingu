using Lingu.Commons;

namespace Lingu.Sdk.Tree
{
    public interface IDumpable
    {
        void Dump(IWriter output, bool top);
    }
}
