using System;

namespace Lingu.Tree
{
    public static class ExpressionExtensions
    {
        public static bool IsSingleCodePoint(this Expression expression)
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

        public static int GetSingleCodePoint(this Expression expression)
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
