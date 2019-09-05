using Lingu.Commons;

namespace Lingu.Sdk.Tree
{
    public sealed class Epsilon : Node
    {
        public override void Dump(IWriter output, bool top)
        {
            output.Write("ε");
        }
    }
}
