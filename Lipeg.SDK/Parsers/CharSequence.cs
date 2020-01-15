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
    public class CharSequence : ICombiParser
    {
        public CharSequence(string characters)
        {
            Kind = OpSymbols.CharSequence;
            Characters = characters;
        }

        public string Kind { get; }
        public string Characters { get; }

        public IResult Parse(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.StartsWith(Characters))
            {
                var next = context.Advance(Characters.Length);
                var location = Location.From(context, next);
                var node = Leaf.From(location, NodeSymbols.StringLiteral, Characters);
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
            return $"'{CharRep.InText(Characters)}'";
        }
    }
}
