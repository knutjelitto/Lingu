using System;
using System.Globalization;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Any : ICombiParser
    {
        public Any()
        {
        }
        public string Kind => OpSymbols.Any;

        public IResult Parse(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.AtEnd)
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

            writer.Write($"{Kind}");
        }            
    }
}
