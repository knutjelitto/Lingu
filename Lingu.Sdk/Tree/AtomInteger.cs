namespace Lingu.Sdk.Tree
{
    public class AtomInteger : Node
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
