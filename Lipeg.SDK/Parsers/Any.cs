using System;
using System.Globalization;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Any : IParser
    {
        public Any()
        {
        }
        public string Name => OpSymbols.Any;

        public IResult Parse(ICursor cursor)
        {
            if (cursor == null) throw new ArgumentNullException(nameof(cursor));

            if (!cursor.AtEnd)
            {
                var next = cursor.Advance(1);
                var location = Location.From(cursor, next);
                return Result.Success(next, LeafNode.From(location, NodeSymbols.Any, ((char)cursor.Current).ToString(CultureInfo.InvariantCulture)));
            }

            return Result.Fail(cursor);
        }

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write("{Name}");
        }            
    }
}
