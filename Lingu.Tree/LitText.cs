namespace Lingu.Tree
{
    public class LitText : Node
    {
        public LitText(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
