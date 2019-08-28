using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class AtomInteger : TerminalExpression
    {
        public AtomInteger(string text)
        {
            Text = text;
            Value = int.Parse(Text);
        }

        public string Text { get; }
        public int Value { get; }
    }
}
