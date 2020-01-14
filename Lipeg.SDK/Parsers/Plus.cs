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
            var current = context;
            var start = current;
            var nodes = new List<INode>();
            while (true)
            {
                var result = Parser.Parse(current);
                if (result.IsSuccess)
                {
                    nodes.AddRange(result.Nodes);
                    current = result.Next;
                }
                else
                {
                    break;
                }
            }

            if (nodes.Count > 0)
            {
                var location = Location.From(context, current);
                var node = NodeList.From(location, NodeSymbols.Plus, nodes.ToArray());
                return Result.Success(location, current, node);
            }

            return Result.Fail(start);
        }
    }
}
