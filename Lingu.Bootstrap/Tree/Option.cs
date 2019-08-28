using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class Option : NamedNode
    {
        public Option(AtomName name, LitString litString)
            : base(name)
        {
            LitString = litString;
        }

        public LitString LitString { get; }
    }
}
