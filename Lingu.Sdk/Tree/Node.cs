using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public abstract class Node : ICanDump
    {
        public virtual void Dump(IWriter output, bool top)
        {
            output.WriteLine(GetType().Name);
        }
    }
}
