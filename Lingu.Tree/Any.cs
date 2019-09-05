using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public sealed class Any : Atom
    {
        public override FA GetFA() => FA.Any;

        public override string ToString()
        {
            return ".";
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write(this.ToString());
        }
    }
}
