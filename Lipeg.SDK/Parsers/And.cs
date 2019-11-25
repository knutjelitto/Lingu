using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Parsers
{
    public class And : Single
    {
        public And(IParser inner)
            : base(OpSymbols.And, inner)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            var result = Parser.Parse(cursor);
            if (result.IsSuccess)
            {
                return Result.Success(cursor, LeafNode.From(Location.From(cursor), NodeSymbols.And));
            }
            return Result.Fail(cursor);
        }
    }
}
