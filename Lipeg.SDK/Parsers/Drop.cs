using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Drop : IParser
    {
        public Drop(IParser parser)
        {
            Parser = parser;
        }

        public IParser Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            return Parser.Parse(cursor).SetDrop();
        }
    }
}
