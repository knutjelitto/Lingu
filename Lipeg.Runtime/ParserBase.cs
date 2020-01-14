using System;
using System.Globalization;

namespace Lipeg.Runtime
{
    public class ParserBase
    {
        protected IResult MatchString(IContext current, string str)
        {
            if (current.StartsWith(str))
            {
                var next = current.Advance(str.Length);
                var location = Location.From(current, next);
                var node = Leaf.From(location, "string", str);
                return Result.Success(location, next, node);
            }
            return Result.Fail(current);
        }

        protected IResult MatchPredicate(IContext current, Func<int, bool> predicate)
        {
            if (!current.AtEnd && predicate(current.Current))
            {
                var next = current.Advance(1);
                var location = Location.From(current, next);
                var node = Leaf.From(location, "char", ((char)current.Current).ToString(CultureInfo.InvariantCulture));
                return Result.Success(node, next, node);
            }
            return Result.Fail(current);
        }
    }
}
