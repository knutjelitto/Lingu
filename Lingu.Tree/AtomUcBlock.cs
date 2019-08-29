namespace Lingu.Tree
{
    public class AtomUcBlock : TerminalAtom
    {
        public AtomUcBlock(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
