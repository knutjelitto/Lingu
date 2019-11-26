using System;
using System.Diagnostics;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Reference : IParser
    {
        protected Reference(string kind, Identifier identifier, Func<IParser> parser)
        {
            Kind = kind;
            Identifier = identifier;
            Parser = parser;
        }

        public string Kind { get; }
        public Identifier Identifier { get; }
        public Func<IParser> Parser { get; }

        public IResult Parse(ICursor cursor)
        {
            if (cursor == null) throw new ArgumentNullException(nameof(cursor));

            var result = Parser().Parse(cursor);

            if (result.IsSuccess)
            {
                if (result?.Node?.Name == "qualified-identifier")
                {
                    Debug.Assert(true);
                }
                if (result?.Node == null) throw new InternalErrorException("can't be");
                result.Node.WithName(Identifier.Name);
            }

            return result;
        }

        public void Dump(int level, IWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            writer.Write($"{this}");
        }

        public override string ToString()
        {
            return $"{Identifier.Name}";
        }
    }
}
