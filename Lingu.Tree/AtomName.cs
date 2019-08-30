using System;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomName : TerminalAtom
    {
        public static readonly AtomName Empty = new AtomName(string.Empty);

        public AtomName(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }

        public override void Dump(Indentable output, Boolean top)
        {
            if (top)
            {
                output.Write("| ");
            }
            output.Write(Text);
            if (top)
            {
                output.WriteLine("");
            }
        }
    }
}
