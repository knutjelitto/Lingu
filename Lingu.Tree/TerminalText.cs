using System;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class TerminalText : TerminalAtom
    {
        public TerminalText(LitText text)
        {
            Text = text;
        }

        public LitText Text { get; }

        public override void Dump(Indentable output, Boolean top)
        {
            Text.Dump(output, top);
        }
    }
}
