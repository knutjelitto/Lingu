namespace Lingu.Tree
{
    public class TerminalText : TerminalExpression
    {
        public TerminalText(LitText text)
        {
            Text = text;
        }

        public LitText Text { get; }
    }
}
