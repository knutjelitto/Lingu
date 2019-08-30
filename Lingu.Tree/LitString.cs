using System;

namespace Lingu.Tree
{
    public class LitString : Node
    {
        public LitString(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override String ToString()
        {
            return Text;
        }
    }
}
