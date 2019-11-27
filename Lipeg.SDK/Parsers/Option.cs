using System;
using System.Diagnostics.CodeAnalysis;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Option : Single
    {
        public Option(IParser parser)
            : base(OpSymbols.Option, parser)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            var result = Parser.Parse(cursor);
            if (result.IsSuccess)
            {
                return Result.Success(result.Next, InternalNode.From(Location.From(cursor), NodeSymbols.Option, result.Node));
            }
            return Result.Success(cursor, InternalNode.From(Location.From(cursor), NodeSymbols.Option));
        }
    }
}
