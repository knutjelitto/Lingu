namespace Lingu.Tree
{
    public class LitString : Node
    {
        public LitString(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}
