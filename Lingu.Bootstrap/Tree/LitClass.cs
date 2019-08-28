using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class LitClass : TerminalAtom
    {
        public LitClass(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
