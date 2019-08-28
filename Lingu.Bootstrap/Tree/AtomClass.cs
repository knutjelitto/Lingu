using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomClass : TerminalAtom
    {
        public AtomClass(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
