using System;
using Lingu.Commons;

namespace Lingu.Tree
{
    public abstract class Node : IDumpable
    {
        public virtual void Dump(IWriter output, bool top)
        {
            output.WriteLine(GetType().Name);
        }
    }
}
