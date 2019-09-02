using Lingu.Commons;

namespace Lingu.Tree
{
    public sealed class Epsilon : Node
    {
        public override void Dump(Indentable output, bool top)
        {
            output.Write("ε");
        }
    }
}
