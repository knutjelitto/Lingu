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

        public override Nfa GetNfa()
        {
            throw new System.NotImplementedException();
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write(Text);
        }
    }
}
