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

        public IResult Parse(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.AtEnd && context.Current == Character)
            {
                var next = context.Advance(1);
                var location = Location.From(context, next);
                var node = Leaf.From(location, NodeSymbols.Any, ((char)context.Current).ToString(CultureInfo.InvariantCulture));
                return Result.Success(location, next, node);
            }

            return Result.Fail(context);
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
