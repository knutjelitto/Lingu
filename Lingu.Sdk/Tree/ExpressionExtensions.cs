using System;

using Lingu.Output;

#nullable enable

namespace Lingu.Tree
{
    public static class ExpressionExtensions
    {
        public static bool IsSingleCodePoint(this IExpression expression)
        {
            if (expression is UcCodepoint)
            {
                return true;
            }
            if (expression is String text && text.Value.Length == 1)
            {
                return true;
            }

            return false;
        }

        public static int GetSingleCodePoint(this IExpression expression)
        {
            if (expression is UcCodepoint codePoint)
            {
                return codePoint.Value;
            }
            if (expression is String text && text.Value.Length == 1)
            {
                return text.Value[0];
            }

            throw new NotImplementedException();
        }
    }
}
