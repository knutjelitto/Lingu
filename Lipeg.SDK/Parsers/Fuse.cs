using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Fuse : IParser
    {
        public Fuse(IParser parser)
        {
            Parser = parser;
        }

        public IParser Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            return Parser.Parse(cursor).SetFuse();
        }
    }
}
