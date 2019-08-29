namespace Lingu.Tree
{
    public class AtomUcCategory : TerminalAtom
    {
        public AtomUcCategory(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
