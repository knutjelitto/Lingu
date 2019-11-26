using System;
using System.Collections.Generic;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Choice : Multi
    {
        public Choice(IReadOnlyList<IParser> parsers)
            : base(OpSymbols.Choice, parsers)
        {
        }

        public override IResult Parse(ICursor cursor)
        {
            foreach (var parser in Parsers)
            {
                var result = parser.Parse(cursor);
                if (result.IsSuccess)
                {
                    return result;
                }
            }

            return Result.Fail(cursor);
        }

        public override void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            if (Parsers.Count > 1)
            {
                if (level == 0)
                {
                    writer.Write($"({Kind} ");
                    writer.Indent(() =>
                    {
                        var more = false;
                        foreach (var child in Parsers)
                        {
                            if (more)
                            {
                                writer.WriteLine();
                            }
                            child.Dump(level + 1, writer);
                            more = true;
                        }
                    });
                    writer.Write(")");
                }
                else
                {
                    var more = false;

                    writer.Write($"({Kind} ");
                    foreach (var child in Parsers)
                    {
                        if (more)
                        {
                            writer.Write(" ");
                        }
                        child.Dump(level + 1, writer);
                        more = true;
                    }
                    writer.Write(")");
                }
            }
            else
            {
                Parsers[0].Dump(level + 1, writer);
            }
        }
    }
}
