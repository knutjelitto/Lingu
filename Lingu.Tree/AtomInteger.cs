namespace Lingu.Tree
{
    public class AtomInteger : TerminalExpression
    {
        public AtomInteger(string text)
        {
            Text = text;
            Value = int.Parse(Text);
        }

        public string Text { get; }
        public int Value { get; }
    }
}
