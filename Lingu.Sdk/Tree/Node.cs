using Lingu.Grammars;
using Lingu.Output;

namespace Lingu.Tree
{
    public abstract class Node : ICanDump
    {
        public virtual void Dump(IndentWriter writer, bool top)
        {
            writer.WriteLine(GetType().Name);
        }

        public abstract void Dump(IndentWriter writer);
        //public Repeat Repeat { get; set; }
    }
}
