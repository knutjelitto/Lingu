using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public override IResult Parse(ICursor cursor)
        {
            var current = cursor;
            var nodes = new List<INode>();
            foreach (var parser in Parsers)
            {
                var result = parser.Parse(current);
                if (result == null) throw new InternalErrorException("can't be");

                if (result.IsFail)
                {
                    return Result.Fail(cursor);
                }
                if (!result.IsDrop)
                {
                    if (result.IsFuse)
                    {
                        var value = result.Node.Fuse();
                        result.SetNode(LeafNode.From(result.Node, NodeSymbols.Fusion, value));
                    }
                    if (result.IsLift)
                    {
                        if (result.Node is InternalNode lifted)
                        {
                            nodes.AddRange(lifted);
                        }
                        else
                        {
                            /*
                             * Do nothing if leaf node
                             */
                            nodes.Add(result.Node);
                        }
                    }
                    else
                    {
                        if (result.Node == null) throw new InternalErrorException("can't be");
                        nodes.Add(result.Node);
                    }
                }
                current = result.Next;
            }

            //if (nodes.Count == 1)
            //{
            //    var node = nodes[0];
            //    return Result.Success(current, node);
            //}

            return Result.Success(
                current, 
                InternalNode.From(Location.From(cursor, current), NodeSymbols.Sequence, nodes));
        }

        public override void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            if (Parsers.Count > 1)
            {
                writer.Write($"({Kind} ");
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
