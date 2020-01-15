using Lipeg.Runtime;
using Lipeg.SDK.Tree;
using System.Diagnostics;

namespace Lipeg.SDK.Parsers
{
    public class Drop : Single
    {
        protected Drop(ICombiParser parser)
            : base(OpSymbols.Drop, parser)
        {
        }

        public override IResult Parse(IContext context)
        {
            var result = Parser.Parse(context);

            if (result.IsSuccess)
            {
                // drop parse result
                return Result.Success(result, result.Next);
            }

            return result;
        }

        public static ICombiParser From(ICombiParser parser)
        {
            return new Drop(parser);
        }
    }
}
