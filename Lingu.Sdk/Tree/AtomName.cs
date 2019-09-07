using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomName : Node
    {
        public static readonly AtomName Empty = new AtomName(string.Empty);

        public AtomName(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }

        public override void Dump(IWriter output, bool top)
        {
            output.Write(Text);
        }
    }
}
