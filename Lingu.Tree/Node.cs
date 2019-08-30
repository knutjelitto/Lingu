using System;
using Lingu.Commons;

namespace Lingu.Tree
{
    public abstract class Node
    {
        public virtual void Dump(Indentable output, bool top)
        {
            output.WriteLine(GetType().Name);
        }
    }
}
