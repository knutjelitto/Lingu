namespace Lingu.Tree
{
    public class Integer : Node
    {
        public Integer(string text)
        {
            Text = text;
            Value = int.Parse(Text);
        }

        public string Text { get; }
        public int Value { get; }
    }
}
