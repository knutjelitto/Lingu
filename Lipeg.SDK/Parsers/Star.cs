using System.Collections.Generic;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Star : IParser
    {
        public Star(IParser parser)
        {
            Parser = parser;
        }

        public IParser Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            var nodes = new List<INode>();
            var current = cursor;
            do
            {
                var result = Parser.Parse(current);
                if (!result.IsFail)
                {
                    nodes.Add(result.Node);
                    current = result.Next;
                }
                else
                {
                    break;
                }
            }
            while (true);
            
            return Result.Success(current, InternalNode.From(Location.From(cursor, current), NodeSymbols.Star, nodes));
        }
    }
}
