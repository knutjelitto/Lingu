using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Lift : Single
    {
        public Lift(IParser parser)
            : base(OpSymbols.Lift, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var result = Parser.Parse(context);

            if (result.IsSuccess)
            {
                var nodes = new List<INode>();

                foreach (var node in result.Nodes)
                {
                    nodes.AddRange(node.Children);
                }

                result = Result.Success(result, result.Next, nodes.ToArray());
            }

            return result;
        }
    }
}
