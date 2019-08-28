using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomUcRange : TerminalAtom
    {
        public AtomUcRange(AtomUcCodepoint from, AtomUcCodepoint to)
        {
            From = from;
            To = to;
        }

        public AtomUcCodepoint From { get; }
        public AtomUcCodepoint To { get; }
    }
}
