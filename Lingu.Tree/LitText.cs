using System;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class LitText : Node
    {
        public LitText(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override void Dump(Indentable output, Boolean top)
        {
            if (top)
            {
                output.Write("| ");
                output.WriteLine(Text);
            }
            else
            {
                output.Write(Text);
            }
        }
    }
}
