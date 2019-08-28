using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomUcBlock : TerminalAtom
    {
        public AtomUcBlock(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
