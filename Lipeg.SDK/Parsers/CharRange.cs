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

        public IResult Parse(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.AtEnd && Min <= context.Current && context.Current <= Max)
            {
                var next = context.Advance(1);
                var location = Location.From(context, next);
                var node = Leaf.From(location, NodeSymbols.CharacterLiteral, ((char)context.Current).ToString(CultureInfo.InvariantCulture));
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
            return $"'{CharRep.Convert(Min)}-{CharRep.Convert(Max)}'";
        }
    }
}
