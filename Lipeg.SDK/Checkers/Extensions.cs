using Lipeg.SDK.Tree;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Checkers
{
    public static class Extensions
    {
        internal static IExpressionAttributes Attr(this Expression expr, Semantic semantic)
        {
            return semantic[expr];
        }
        internal static IRuleAttributes Attr(this Rule rules, Semantic semantic)
        {
            return semantic[rules];
        }
    }
}
