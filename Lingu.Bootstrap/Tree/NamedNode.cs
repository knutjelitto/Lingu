using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public abstract class NamedNode : Node
    {
        public NamedNode(AtomName name)
        {
            Name = name;
        }

        public AtomName Name { get; }
    }
}
