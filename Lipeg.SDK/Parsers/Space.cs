using System;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Space : ICombiParser
    {
        public Space(Func<ICombiParser> spacer, ICombiParser andThen)
        {
            Spacer = spacer;
            AndThen = andThen;
        }

        public string Kind => OpSymbols.Spacing;

        public Func<ICombiParser> Spacer { get; }
        public ICombiParser AndThen { get; }

        public IResult Parse(IContext context)
        {
            var result = Spacer().Parse(context);
            if (result is ISuccess)
            {
                result = AndThen.Parse(result.Next);
                return result;
            }

            return Result.Fail(context);
        }

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"[");
            AndThen.Dump(level + 1, writer);
            writer.Write($"]");
        }

        public override string ToString()
        {
            return $"[{AndThen}]";
        }
    }
}
