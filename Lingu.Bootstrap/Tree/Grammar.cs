using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class Grammar : Node
    {
        public Grammar(AtomName name, Options options, Terminals terminals)
        {
            Name = name;
            Options = options;
            Terminals = terminals;
        }

        public AtomName Name { get; }
        public Options Options { get; }
        public Terminals Terminals { get; }
    }
}
