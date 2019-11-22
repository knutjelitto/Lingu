using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Checkers;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Sequence : Multi
    {
        public Sequence(IReadOnlyList<IParser> parsers)
            : base(OpSymbols.Sequence, parsers)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            var current = cursor;
            var nodes = new List<INode>();
            foreach (var parser in Parsers)
            {
                var result = parser.Parse(current);
                if (result.IsFail)
                {
                    return Result.Fail(cursor);
                }
                nodes.Add(result.Node);
                current = result.Next;
            }

            return Result.Success(
                current, 
                InternalNode.From(Location.From(cursor, current), NodeSymbols.Sequence, nodes));
        }
    }
}
