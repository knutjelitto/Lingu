using System;

using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class UcCategory : Atom
    {
        public UcCategory(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override FA GetFA()
        {
            throw new NotImplementedException();
        }

        public override void Dump(IndentWriter output)
        {
            output.Write(Text);
        }
    }
}
