using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lipeg.SDK.Common
{
    public static class CharRep
    {
        public static string InText(string value)
        {
            return string.Join(string.Empty, value.Select(v => Convert(v)));
        }

        public static string InText(int value)
        {
            return Convert(value);
        }

        public static string InClass(this int value)
        {
            switch ((char)value)
            {
                case '-':
                    return "\\-";
                case ']':
                    return "\\]";
                default:
                    return Convert(value);
            }
        }

        public static string InRange(int value)
        {
            var result = Convert(value);

            if (!result.StartsWith("U+", StringComparison.InvariantCulture))
            {
                return $"'{result}'";
            }
            return $"{result}";
        }

        public static string Convert(int value)
        {
            if (value <= char.MaxValue)
            {
                switch ((char)value)
                {
                    case '\0':
                        return "\\0";
                    case '\a':
                        return "\\a";
                    case '\b':
                        return "\\b";
                    case '\f':
                        return "\\f";
                    case '\n':
                        return "\\n";
                    case '\r':
                        return "\\r";
                    case '\t':
                        return "\\t";
                    case '\v':
                        return "\\v";
                    case '\'':
                        return "\\'";
                    case '\\':
                        return "\\\\";

                    default:
                        if (value >= 32 && value < 127 || value >= 161 && value <= 255 || char.IsLetterOrDigit((char)value))
                        {
                            return $"{(char)value}";
                        }
                        break;
                }
            }

            return "\\u{" + value.ToString("X4", CultureInfo.InvariantCulture) + "}";
        }
    }
}
