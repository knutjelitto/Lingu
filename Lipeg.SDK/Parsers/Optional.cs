using System;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Optional : Single
    {
        public Optional(ICombiParser parser)
            : base(OpSymbols.Option, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var result = Parser.Parse(context);
            var node = NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray());

            if (result.IsSuccess)
            {
                return Result.Success(result, result.Next, node);
            }
            else
            {
                return Result.Success(context, context, node);
            }
        }
    }
}
