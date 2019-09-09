using System;

using Lingu.Commons;

namespace Lingu.Tree
{
    public class Name : Node
    {
        public static readonly Name Empty = new Name(string.Empty);

        public Name(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override bool Equals(object obj)
        {
            return obj is Name other && Text.Equals(other.Text, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return Text.GetHashCode(); ;
        }

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
