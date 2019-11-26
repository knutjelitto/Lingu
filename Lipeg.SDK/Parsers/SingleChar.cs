using System;
using System.Diagnostics;
using System.Globalization;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class SingleChar : IParser
    {
        public SingleChar(int character)
        {
            Character = @character;
        }
        public string Kind => OpSymbols.ClassChar;
        public int Character { get; }

        public IResult Parse(ICursor cursor)
        {
            if (cursor == null) throw new ArgumentNullException(nameof(cursor));

            if (!cursor.AtEnd && cursor.Current == Character)
            {
                if ((char)Character == '\'')
                {
                    Debug.Assert(true);
                }
                var next = cursor.Advance(1);
                var location = Location.From(cursor, next);
                return Result.Success(next, LeafNode.From(location, NodeSymbols.Any, ((char)cursor.Current).ToString(CultureInfo.InvariantCulture)));
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
            return $"'{CharRep.Convert(Character)}'";
        }
    }
}
