using System;
using System.Collections.Generic;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Sequence : Multi
    {
        public Sequence(IReadOnlyList<IParser> parsers)
            : base(OpSymbols.Sequence, parsers)
        {
        }

        public Sequence(params IParser[] parsers)
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

        public override void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            if (Parsers.Count > 1)
            {
                writer.Write($"({Name} ");
                var more = false;
                foreach (var child in Parsers)
                {
                    if (more)
                    {
                        writer.Write(" ");
                    }
                    more = true;
                    child.Dump(level + 1, writer);
                }
                writer.Write(")");
            }
            else
            {
                Parsers[0].Dump(level, writer);
            }
        }
    }
}
