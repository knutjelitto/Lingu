using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public abstract class Node : ICanDump
    {
        public virtual void Dump(IndentWriter output, bool top)
        {
            output.WriteLine(GetType().Name);
        }

        public TreeActionKind Action { get; set; }
        public Repeat Repeat { get; set; }
    }
}
