using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Fuse : Single
    {
        public Fuse(IParser parser)
            : base(OpSymbols.Fuse, parser)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            return Parser.Parse(cursor).SetFuse();
        }
    }
}
