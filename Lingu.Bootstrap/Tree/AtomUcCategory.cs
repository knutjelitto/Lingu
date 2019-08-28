using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomUcCategory : TerminalAtom
    {
        public AtomUcCategory(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
