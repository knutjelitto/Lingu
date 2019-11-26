using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using System.Diagnostics;

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
            var result = Parser.Parse(cursor).SetDrop();

            return result;
        }
    }
}
