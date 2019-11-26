using System;
using System.Globalization;

using Lipeg.Runtime;
using Lipeg.SDK.Common;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class CharRange : IParser
    {
        public CharRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public string Kind => OpSymbols.ClassRange;
        public int Min { get; }
        public int Max { get; }

        public IResult Parse(ICursor cursor)
        {
            if (cursor == null) throw new ArgumentNullException(nameof(cursor));

            if (!cursor.AtEnd && Min <= cursor.Current && cursor.Current <= Max)
            {
                var next = cursor.Advance(1);
                var location = Location.From(cursor, next);
                return Result.Success(next, LeafNode.From(location, NodeSymbols.CharacterLiteral, ((char)cursor.Current).ToString(CultureInfo.InvariantCulture)));
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
            return $"'{CharRep.Convert(Min)}-{CharRep.Convert(Max)}'";
        }
    }
}
