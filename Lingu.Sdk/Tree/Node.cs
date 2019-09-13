using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public abstract class Node : ICanDump
    {
        public virtual void Dump(IndentWriter writer, bool top)
        {
            writer.WriteLine(GetType().Name);
        }
        public Repeat Repeat { get; set; }
    }
}
