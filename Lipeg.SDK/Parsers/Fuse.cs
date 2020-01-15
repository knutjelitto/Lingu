using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Fuse : Single
    {
        public Fuse(ICombiParser parser)
            : base(OpSymbols.Fuse, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var result = Parser.Parse(context);

            if (result.IsSuccess)
            {
                var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));
                var node = Leaf.From(result, NodeSymbols.Fusion, value);

                return Result.Success(result, result.Next, node);
            }

            return result;
        }
    }
}
