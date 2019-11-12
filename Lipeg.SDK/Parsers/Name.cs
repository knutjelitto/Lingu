using Lipeg.Runtime;
using System;

namespace Lipeg.SDK.Parsers
{
    public class Name : IParser
    {
        public Name(Func<IParser> parser)
        {
            Parser = parser;
        }

        public Func<IParser> Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            return Parser().Parse(cursor);
        }
    }
}
