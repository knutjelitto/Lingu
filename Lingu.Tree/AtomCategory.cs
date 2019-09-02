using System;
using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomCategory : Atom
    {
        public AtomCategory(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override Nfa GetNfa()
        {
            throw new NotImplementedException();
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write(Text);
        }
    }
}
