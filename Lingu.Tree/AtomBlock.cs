using System;

using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomBlock : Atom
    {
        public AtomBlock(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override FA GetFA()
        {
            throw new NotImplementedException();
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write(Text);
        }
    }
}
