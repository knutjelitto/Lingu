using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lipeg.Runtime;
using Lipeg.SDK.Output;
using Lipeg.SDK.Tree;

namespace Lipeg.SDK.Parsers
{
    public class Name : ICombiParser
    {
        private Lazy<ICombiParser> getParser;
        private static Dictionary<string, Dictionary<int, IResult>> cache = new Dictionary<string, Dictionary<int, IResult>>();

        public Name(Func<ICombiParser> parser, Identifier identifier)
        {
            Identifier = identifier;
            getParser = new Lazy<ICombiParser>(parser);
        }

        public string Kind => OpSymbols.Ref;
        public ICombiParser Parser => getParser.Value;
        public Identifier Identifier { get; }

        public static void Clear()
        {
            cache.Clear();
        }

        public IResult Parse(IContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (cache.TryGetValue(Identifier.Name, out var lineCache))
            {
                if (lineCache.TryGetValue(context.Offset, out var previous))
                {
                    return previous;
                }
            }

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

            if (lineCache == null)
            {
                lineCache = new Dictionary<int, IResult>();
                cache.Add(Identifier.Name, lineCache);
            }
            lineCache[context.Offset] = result;

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
