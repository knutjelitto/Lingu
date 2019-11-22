using System;
using System.Diagnostics.CodeAnalysis;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    [SuppressMessage("Naming", "CA1716:Identifiers should not match keywords", Justification = "Scheiß drauf")]
    public class Option : Single
    {
        public Option(IParser parser)
            : base(OpSymbols.Opt, parser)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            var result = Parser.Parse(cursor);
            if (result.IsSuccess)
            {
                return result;
            }
            return Result.Success(cursor, LeafNode.From(Location.From(cursor), NodeSymbols.Option));
        }
    }
}
