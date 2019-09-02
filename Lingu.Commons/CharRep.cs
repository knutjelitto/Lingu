using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Commons
{
    public static class CharRep
    {
        public static string InRange(int value)
        {
            if (value <= char.MaxValue)
            {
                switch ((char)value)
                {
                    case '\0':
                        return "'\\0'";
                    case '\a':
                        return "'\\a'";
                    case '\b':
                        return "'\\b'";
                    case '\f':
                        return "'\\f'";
                    case '\n':
                        return "'\\n'";
                    case '\r':
                        return "'\\r'";
                    case '\t':
                        return "'\\t'";
                    case '\v':
                        return "'\\v'";
                    case '\'':
                        return "'\\''";
                    case '\"':
                        return "'\\\"'";

                    default:
                        if (value >= 32 && value < 127 || value >= (128 + 32) && value <= 255)
                        {
                            return $"'{(char)value}'";
                        }
                        break;
                }
            }

            return "U+" + value.ToString("X4");
        }
    }
}
