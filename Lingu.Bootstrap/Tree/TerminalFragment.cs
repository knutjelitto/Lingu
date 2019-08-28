using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class TerminalFragment : TerminalItem
    {
        public TerminalFragment(AtomName name, TerminalExpression definition)
            : base(name)
        {
            Definition = definition;
        }

        public TerminalExpression Definition { get; }
    }
}
