using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Parsers
{
    public class Not : Single
    {
        public Not(IParser inner)
            : base(OpSymbols.Not, inner)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            var result = Parser.Parse(cursor);
            if (result.IsFail)
            {
                return Result.Success(cursor, LeafNode.From(Location.From(cursor), NodeSymbols.Not));
            }
            return Result.Fail(cursor);
        }
    }
}
