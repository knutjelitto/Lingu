using System;

namespace Lingu.Tree
{
    public static class ExpressionExtensions
    {
        public static bool IsSingleCodePoint(this Expression expression)
        {
            if (expression is AtomCodepoint)
            {
                return true;
            }
            if (expression is AtomText text && text.Value.Length == 1)
            {
                return true;
            }

            return false;
        }

        public static int GetSingleCodePoint(this Expression expression)
        {
            if (expression is AtomCodepoint codePoint)
            {
                return codePoint.Value;
            }
            if (expression is AtomText text && text.Value.Length == 1)
            {
                return text.Text[0];
            }

            throw new NotImplementedException();
        }
    }
}
