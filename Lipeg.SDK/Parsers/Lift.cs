using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Lift : Single
    {
        public Lift(IParser parser)
            : base(OpSymbols.Lift, parser)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            return Parser.Parse(cursor).SetLift();
        }
    }
}
