using System;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Optional : Single
    {
        public Optional(IParser parser)
            : base(OpSymbols.Option, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var result = Parser.Parse(context);

            if (result.IsSuccess)
            {
                return Result.Success(result, result.Next, NodeList.From(result, NodeSymbols.Optional, result.Nodes.ToArray()));
            }
            return Result.Success(Location.From(context), context, NodeList.From(Location.From(context), NodeSymbols.Optional));
        }
    }
}
