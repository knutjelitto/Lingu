using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class CharSequence : IParser
    {
        public CharSequence(string characters)
        {
            Name = OpSymbols.String;
            Characters = characters;
        }

        public string Name { get; }
        public string Characters { get; }

        public IResult Parse(ICursor cursor)
        {
            if (cursor == null) throw new ArgumentNullException(nameof(cursor));

            if (cursor.StartsWith("options") && Characters == "options")
            {
                Debug.Assert(true);
            }

            if (cursor.StartsWith(Characters))
            {
                var next = cursor.Advance(Characters.Length);
                var location = Location.From(cursor, next);
                return Result.Success(next, LeafNode.From(location, NodeSymbols.StringLiteral, Characters));
            }
            return Result.Fail(cursor);
        }

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"{this}");
        }

        public override string ToString()
        {
            return $"'{CharRep.InText(Characters)}'";
        }
    }
}
