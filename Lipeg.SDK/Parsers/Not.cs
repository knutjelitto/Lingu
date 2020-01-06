using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lipeg.SDK.Parsers
{
    public class Not : Single
    {
        public Not(IParser inner)
            : base(OpSymbols.Not, inner)
        {
        }

        public override IResult Parse(IContext context)
        {
            if (context == null) throw new InternalNullException();

            if (context.StartsWith("'"))
            {
                Debug.Assert(true);
            }

            var result = Parser.Parse(context);


            if (!result.IsSuccess)
            {
                // drop parse result
                return Result.Success(result, context);
            }

            return Result.Fail(context);
        }
    }
}
