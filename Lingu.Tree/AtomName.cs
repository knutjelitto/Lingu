namespace Lingu.Tree
{
    public class AtomName : TerminalExpression
    {
        public AtomName(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return $"name:{Text}";
        }
    }
}
