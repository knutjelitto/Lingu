using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomUcCodepoint : TerminalAtom
    {
        public AtomUcCodepoint(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
