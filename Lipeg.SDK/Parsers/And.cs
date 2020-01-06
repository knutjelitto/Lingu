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

        public override IResult Parse(IContext context)
        {
            var result = Parser.Parse(context);

            if (result.IsSuccess)
            {
                // drop parse result
                return Result.Success(result, context);
            }

            return result;
        }
    }
}
