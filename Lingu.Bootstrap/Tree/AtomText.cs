using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomText : TerminalAtom
    {
        public AtomText(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
