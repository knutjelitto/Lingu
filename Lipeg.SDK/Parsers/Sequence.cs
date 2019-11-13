using System.Collections.Generic;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Sequence : IParser
    {
        public Sequence(IReadOnlyList<IParser> parsers)
        {
            Parsers = parsers;
        }

        private IReadOnlyList<IParser> Parsers { get; }

        public IResult Parse(ICursor cursor)
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
