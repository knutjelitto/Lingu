using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class Any : Atom
    {
        public override FA GetFA() => FA.Any;

        public override string ToString()
        {
            return ".";
        }

        public override void Dump(IndentWriter output, bool top)
        {
            output.Write(this.ToString());
        }
    }
}
