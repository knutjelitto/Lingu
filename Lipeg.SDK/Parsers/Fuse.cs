﻿using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Fuse : Single
    {
        public Fuse(IParser parser)
            : base(OpSymbols.Fuse, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var result = Parser.Parse(context);

            if (result.IsSuccess)
            {
                var value = string.Join(string.Empty, result.Nodes.Select(n => n.Fuse()));

                return Result.Success(result, result.Next, Leaf.From(result, NodeSymbols.Fusion, value));
            }

            return result;
        }
    }
}
