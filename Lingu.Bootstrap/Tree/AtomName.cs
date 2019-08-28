using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomName : TerminalExpression
    {
        public AtomName(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return $"name:{Text}";
        }
    }
}
