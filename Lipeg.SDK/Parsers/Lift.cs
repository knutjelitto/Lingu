using Lipeg.Runtime;

namespace Lipeg.SDK.Parsers
{
    public class Lift : IParser
    {
        public Lift(IParser parser)
        {
            Parser = parser;
        }

        public IParser Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            return Parser.Parse(cursor).SetLift();
        }
    }
}
