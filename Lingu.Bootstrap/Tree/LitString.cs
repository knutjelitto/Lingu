using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Bootstrap.Tree
{
    public class LitString : Node
    {
        public LitString(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
