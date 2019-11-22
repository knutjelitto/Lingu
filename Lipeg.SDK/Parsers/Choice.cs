using System.Collections.Generic;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Choice : Multi
    {
        public Choice(IReadOnlyList<IParser> parsers)
            : base(OpSymbols.Choice, parsers)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            foreach (var parser in Parsers)
            {
                var result = parser.Parse(cursor);
                if (result.IsSuccess)
                {
                    return result;
                }
            }

            return Result.Fail(cursor);
        }
    }
}
