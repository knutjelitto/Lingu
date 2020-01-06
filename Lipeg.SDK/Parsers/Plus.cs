using System.Collections.Generic;
using System.Reflection.Metadata;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Plus : Single
    {
        public Plus(IParser parser)
            : base(OpSymbols.Plus, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var nodes = new List<INode>();
            var next = context;
            while (true)
            {
                var result = Parser.Parse(next);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    next = result.Next;
                }
                else
                {
                    break;
                }
            }

            if (nodes.Count > 0)
            {
                var location = Location.From(context, next);
                var node = NodeList.From(location, NodeSymbols.Plus, nodes.ToArray());
                return Result.Success(location, next, node);
            }

            return Result.Fail(context);
        }
    }
}
