using Lipeg.SDK.Tree;
using System;

namespace Lipeg.SDK.Checkers
{
    public static class Extensions
    {
        public static IExpressionAttributes Attr(this Expression expr, Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            return semantic[expr];
        }
        public static IRuleAttributes Attr(this IRule rules, Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            return semantic[rules];
        }
        public static IGrammarAttributes Attr(this Grammar grammar, Semantic semantic)
        {
            if (semantic == null) throw new ArgumentNullException(nameof(semantic));

            return semantic[grammar];
        }
    }
}
