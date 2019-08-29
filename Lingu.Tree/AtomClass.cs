namespace Lingu.Tree
{
    public class AtomClass : TerminalAtom
    {
        public AtomClass(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
