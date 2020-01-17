using System;using System.Collections.Generic;
using System.Globalization;

namespace Lipeg.Runtime
{
    public abstract class ParserBase : IParser, IParserTools
    {
        protected Dictionary<Func<IContext, IResult>, Dictionary<int, IResult>> cache = new Dictionary<Func<IContext, IResult>, Dictionary<int, IResult>>();

        public abstract IResult Parse(IContext context);

        public virtual void __ClearCache()
        {
            this.cache.Clear();
        }

        public virtual IResult __Parse(Func<IContext, IResult> parser, IContext context)
        {
            if (cache.TryGetValue(parser, out var parserCache))
            {
                if (parserCache.TryGetValue(context.Offset, out var previousResult))
                {
                    return previousResult;
                }
            }

            var result = parser(context);

            if (parserCache == null)
            {
                parserCache = new Dictionary<int, IResult>();
                cache.Add(parser, parserCache);
            }
            parserCache[context.Offset] = result;

            return result;
        }

        public abstract IContext __SkipSpace(IContext context);

        public virtual IResult __FinishRule(IResult result, string name)
        {
            if (result.IsSuccess)
            {
                if (result.Nodes.Count == 1 && result.Nodes[0] is ILeaf leaf && leaf.Name == NodeSymbols.Fusion)
                {
                    result = Result.Success(result, result.Next, Leaf.From(result, name, leaf.Value));
                }
                else
                {
                    result = Result.Success(result, result.Next, NodeList.From(result, name, result.Nodes));
                }
            }

            return result;
        }

        public virtual IResult __MatchString(IContext current, string str)
        {
            if (current.StartsWith(str))
            {
                var next = current.Advance(str.Length);
                var location = Location.From(current, next);
                var node = Leaf.From(location, NodeSymbols.StringLiteral, str);
                return Result.Success(location, next, node);
            }
            return Result.Fail(current);
        }

        public virtual IResult __MatchPredicate(IContext current, Func<int, bool> predicate)
        {
            if (!current.AtEnd && predicate(current.Current))
            {
                var next = current.Advance(1);
                var location = Location.From(current, next);
                var node = Leaf.From(location, NodeSymbols.CharacterLiteral, ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                return Result.Success(node, next, node);
            }
            return Result.Fail(current);
        }
    }
}
