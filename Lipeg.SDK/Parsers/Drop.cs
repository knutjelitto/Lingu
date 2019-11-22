using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Drop : Single
    {
        public Drop(IParser parser)
            : base(OpSymbols.Drop, parser)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            return Parser.Parse(cursor).SetDrop();
        }
    }
}
