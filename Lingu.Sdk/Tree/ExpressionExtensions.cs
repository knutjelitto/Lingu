using System;

using Lingu.Writers;

namespace Lingu.Tree
{
    public static class ExpressionExtensions
    {
        public static string ActionPrefix(this IExpression expression)
        {
            switch (expression.Action)
            {
                case ActionKind.None:
                    return string.Empty;
                case ActionKind.Drop:
                    return ",";
                case ActionKind.Promote:
                    return "^";
            }

            throw new NotImplementedException();
        }

        public static void ActionPrefix(this IExpression expression, IndentWriter writer)
        {
            writer.Write(expression.ActionPrefix());
        }

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
