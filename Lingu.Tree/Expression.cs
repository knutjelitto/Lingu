using Lingu.Automata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Tree
{
    public abstract class Expression : Node
    {
        public abstract FA GetNfa();
    }
}
