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
        public Sequence(IReadOnlyList<ICombiParser> parsers)
            : base(OpSymbols.Sequence, parsers)
        {
        }

        public override IResult Parse(IContext context)
        {
            var next = context;
            var nodes = new List<INode>();
            foreach (var parser in Parsers)
            {
                var result = parser.Parse(next);

                if (!result.IsSuccess)
                {
                    return Result.Fail(context);
                }

                nodes.AddRange(result.Nodes);

                next = result.Next;
            }

            var location = Location.From(context, next);
            return Result.Success(location, next, nodes.ToArray());
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
