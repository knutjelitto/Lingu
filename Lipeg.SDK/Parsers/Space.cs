using System;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Space : IParser
    {
        public Space(Func<IParser> spacer)
        {
            Spacer = spacer;
        }

        public string Name => OpSymbols.Spacing;

        public Func<IParser> Spacer { get; }

        public IResult Parse(ICursor cursor)
        {
            return Spacer().Parse(cursor);
        }

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"{Name}");
        }
    }
}
