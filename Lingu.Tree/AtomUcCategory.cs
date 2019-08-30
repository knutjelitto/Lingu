using System;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomUcCategory : TerminalAtom
    {
        public AtomUcCategory(string text)
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
