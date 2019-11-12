using System;

using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Predicate : IParser
    {
        public Predicate(Func<ICursor, IResult> matcher)
        {
            Matcher = matcher;
        }

        public Func<ICursor, IResult> Matcher { get; }

        public IResult Parse(ICursor cursor)
        {
            return Matcher(cursor);
        }
    }
}
