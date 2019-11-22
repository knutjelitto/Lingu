using System.Collections.Generic;
using System.Reflection.Metadata;
using Lipeg.Runtime;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Plus : Single
    {
        public Plus(IParser parser)
            : base(OpSymbols.Plus, parser)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            var nodes = new List<INode>();
            var current = cursor;
            while (true)
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

            if (nodes.Count > 0)
            {
                return Result.Success(current, InternalNode.From(Location.From(cursor, current), NodeSymbols.Plus, nodes));
            }
            return Result.Fail(cursor);
        }
    }
}
