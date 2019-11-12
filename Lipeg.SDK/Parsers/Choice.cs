using System.Collections.Generic;

using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Choice : IParser
    {
        public Choice(IReadOnlyList<IParser> parsers)
        {
            Parsers = parsers;
        }

        private IReadOnlyList<IParser> Parsers { get; }

        public IResult Parse(ICursor cursor)
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
