using LinParse.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LinParse.Json
{
    public class JsonParser : Parser<JsonLexer>
    {
        public JsonParser(JsonLexer lexer)
            : base(lexer)
        {
        }

        public Ast.Value? Parse()
        {
            Ast.Value? value = null;
            try
            {
                value = Value();
                lexer.Skip();
                if (lexer.Current < lexer.Limit)
                {
                    throw new InvalidOperationException("");
                }
            }
            catch (Exception exception)
            {
                Error = exception;
                return null;
            }

            return value;
        }

        public Exception? Error { get; private set; } = null;

        public int NestLevel { get; private set; }
        public const int NestLimit = 1000;

        protected void Nest()
        {
            NestLevel += 1;
            if (NestLevel > NestLimit)
            {
                throw new InvalidOperationException($"nesting too deep (> {NestLimit})");
            }
        }

        protected void Unnest()
        {
            NestLevel -= 1;
        }

        public Ast.Value Value()
        {
            if (TryValue(out var value))
            {
                return value ?? throw new NullReferenceException();
            }

            throw new NotImplementedException();
        }


        public bool TryValue(out Ast.Value? value)
        {
            lexer.Skip();

            value = null;

            switch (At())
            {
                case '{':
                    Nest();
                    value = Object();
                    Unnest();
                    break;
                case '[':
                    Nest();
                    value = Array();
                    Unnest();
                    break;
                case '"':
                    value = String();
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '-':
                    value = Number();
                    break;
                case 't':
                    value = True();
                    break;
                case 'f':
                    value = False();
                    break;
                case 'n':
                    value = Null();
                    break;
            }

            return value != null;
        }

        public Ast.Object Object()
        {
            var start = lexer.Current;

            Match('{');
            var members = Members().ToArray();
            Match('}');
            return new Ast.Object(lexer.Span(start), members);

            IEnumerable<Ast.Member> Members()
            {
                lexer.Skip();
                var start = lexer.Current;
                if (TryString(out var first))
                {
                    var key = first ?? throw new NullReferenceException();
                    while (true)
                    {
                        lexer.Skip();
                        Match(':');
                        var value = Value();
                        yield return new Ast.Member(lexer.Span(start), key, value);
                        lexer.Skip();
                        if (At() == ',')
                        {
                            MatchAny();
                        }
                        else
                        {
                            break;
                        }
                        lexer.Skip();
                        start = lexer.Current;
                        key = String();
                    }
                }
            }
        }

        public Ast.Array Array()
        {
            var start = lexer.Current;

            Match('[');
            var values = Values().ToArray();
            Match(']');

            return new Ast.Array(lexer.Span(start), values);

            IEnumerable<Ast.Value> Values()
            {
                lexer.Skip();
                if (TryValue(out var first))
                {
                    var value = first ?? throw new NullReferenceException();
                    while (true)
                    {
                        yield return value ?? throw new NullReferenceException();
                        lexer.Skip();
                        if (At() == ',')
                        {
                            MatchAny();
                        }
                        else if (At() != ']')
                        {
                            throw new InvalidOperationException();
                        }
                        else
                        {
                            break;
                        }
                        lexer.Skip();
                        value = Value();
                    }
                }
            }
        }

        public Ast.String String()
        {
            if (TryString(out var str))
            {
                return str ?? throw new NullReferenceException();
            }

            throw new NotImplementedException();
        }

        public bool TryString(out Ast.String? str)
        {
            if (At() != '\"')
            {
                str = null;
                return false;
            }

            var start = lexer.Current;

            var accu = new StringBuilder();

            Match('\"');
            while (HaveMore())
            {
                if (At() == '\"')
                {
                    break;
               }
                switch (At())
                {
                    case '\\':
                        Match('\\');
                        switch (At())
                        {
                            case '\"':
                            case '\\':
                            case '/':
                                accu.Append(MatchAny());
                                break;
                            case 'b':
                                MatchAny();
                                accu.Append('\b');
                                break;
                            case 'f':
                                MatchAny();
                                accu.Append('\f');
                                break;
                            case 'n':
                                MatchAny();
                                accu.Append('\n');
                                break;
                            case 'r':
                                MatchAny();
                                accu.Append('\r');
                                break;
                            case 't':
                                MatchAny();
                                accu.Append('\r');
                                break;
                            case 'u':
                                MatchAny();
                                var digits = new char[4];
                                digits[0] = MatchHexDigit();
                                digits[1] = MatchHexDigit();
                                digits[2] = MatchHexDigit();
                                digits[3] = MatchHexDigit();
                                accu.Append((char)int.Parse(digits.AsSpan(), NumberStyles.HexNumber));
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        break;
                    default:
                        if (At() >= 0x20)
                        {
                            accu.Append(MatchAny());
                            break;
                        }
                        throw new NotImplementedException();
                }
            }
            Match('\"');

            str = new Ast.String(lexer.Span(start), accu.ToString());
            return true;
        }

        public Ast.Number Number()
        {
            var start = lexer.Current;
            if (At() == '-')
            {
                MatchAny(); // '-'
            }
            if ('1' <= At() && At() <= '9' )
            {
                MatchAny(); // 1-9
                while (CheckDigit())
                {
                    MatchAny(); // 0-9
                }
            }
            else if (At() == '0')
            {
                MatchAny(); // 0
            }
            else
            {
                throw new NotImplementedException();
            }
            if (At() == '.')
            {
                MatchAny(); // .
                MatchDigit();
                while (CheckDigit())
                {
                    MatchAny();
                }
            }
            if (CheckOneOf('e', 'E'))
            {
                MatchAny();
                if (CheckOneOf('+', '-'))
                {
                    MatchAny();
                }
                MatchDigit();
                while (CheckDigit())
                {
                    MatchAny();
                }
            }

            return new Ast.Number(lexer.Span(start));
        }

        public Ast.True True()
        {
            var start = lexer.Current;
            Match("true");
            return new Ast.True(lexer.Span(start));
        }

        public Ast.False False()
        {
            var start = lexer.Current;
            Match("false");
            return new Ast.False(lexer.Span(start));
        }

        public Ast.Null Null()
        {
            var start = lexer.Current;
            Match("null");
            return new Ast.Null(lexer.Span(start));
        }
    }
}
