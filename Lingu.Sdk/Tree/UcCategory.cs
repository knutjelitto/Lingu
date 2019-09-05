using System;
using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Sdk.Tree
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

        public override void Dump(IWriter output, bool top)
        {
            output.Write(Text);
        }
    }
}
