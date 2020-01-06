using System;
using System.Diagnostics;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Name : IParser
    {
        private Lazy<IParser> getParser;

        public Name(Func<IParser> parser, Identifier identifier)
        {
            Identifier = identifier;
            getParser = new Lazy<IParser>(parser);
        }

        public string Kind => OpSymbols.Ref;
        public IParser Parser => getParser.Value;
        public Identifier Identifier { get; }

        public IResult Parse(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var result = Parser.Parse(context);

            if (result.IsSuccess)
            {
                if (result.Nodes.Count == 1 && result.Nodes[0] is ILeaf leaf && leaf.Name == NodeSymbols.Fusion)
                {
                    result = Result.Success(result, result.Next, Leaf.From(result, Identifier.Name, leaf.Value));
                }
                else
                {
                    result = Result.Success(result, result.Next, NodeList.From(result, Identifier.Name, result.Nodes.ToArray()));
                }
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
