using Lingu.Automata;
using Lingu.Output;

namespace Lingu.Tree
{
    public sealed class Any : Atom
    {
        public override FA GetFA() => FA.Any();

        public override string ToString()
        {
            return ".";
        }

        public override void Dump(IndentWriter output)
        {
            output.Write(this.ToString());
        }
    }
}
