using System;
using System.Reflection.Metadata;
using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Space : IParser
    {
        public Space(Func<IParser> spacer, IParser andThen)
        {
            Spacer = spacer;
            AndThen = andThen;
        }

        public string Name => OpSymbols.Spacing;

        public Func<IParser> Spacer { get; }
        public IParser AndThen { get; }

        public IResult Parse(ICursor cursor)
        {
            var result = Spacer().Parse(cursor);
            if (result is ISuccess)
            {
                result = AndThen.Parse(result.Next);
                return result;
            }

            return Result.Fail(cursor);
        }

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"[{Name} ");
            AndThen.Dump(level+1, writer);
            writer.Write($"]");
        }

        public override string ToString()
        {
            return $"[{Name} {AndThen}]";
        }
    }
}
