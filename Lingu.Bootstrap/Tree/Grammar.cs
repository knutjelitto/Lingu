using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class Grammar : Node
    {
        public Grammar(AtomName name, Options options)
        {
            Name = name;
            Options = options;
        }

        public AtomName Name { get; }
        public Options Options { get; }
    }
}
