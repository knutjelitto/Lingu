using System.Collections.Generic;
using System.Diagnostics;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Star : Single
    {
        public Star(IParser parser)
            : base(OpSymbols.Star, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var current = context;

            var nodes = new List<INode>();
            do
            {
                if (current == null) throw new InternalNullException();
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
            while (true);

            var location = Location.From(context, current);
            var node = NodeList.From(location, NodeSymbols.Star, nodes);

            return Result.Success(location, current, node);
        }
    }
}
