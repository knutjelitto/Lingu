using Lingu.Writers;

namespace Lingu.Tree
{
    public sealed class Epsilon : Node
    {
        public override void Dump(IndentWriter output, bool top)
        {
            output.Write("ε");
        }
    }
}
