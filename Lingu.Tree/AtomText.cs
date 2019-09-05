using System;
using System.Text;
using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomText : Atom
    {
        public AtomText(string text)
        {
            Text = text;
            Value = Convert(text.Substring(1, text.Length - 2)); // drop '' and convert
        }

        public string Text { get; }
        public string Value { get; }

        public override FA GetFA()
        {
            return FA.From(Value);
        }

        public override void Dump(IWriter output, bool top)
        {
            output.Write(ToString());
        }

        public override bool Equals(object obj)
        {
            return obj is AtomText other && Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(); ;
        }

        public override string ToString()
        {
            return $"'{CharRep.InText(Value)}'";
        }

        private string Convert(string text)
        {
            var result = new StringBuilder();

            for (int i = 0; i < text.Length; i += 1)
            {
                if (text[i] == '\\')
                {
                    i += 1;
                    switch (char.ToLower(text[i]))
                    {
                        case '\\': result.Append('\\'); break;
                        case '\'': result.Append('\''); break;
                        case '\"': result.Append('\"'); break;
                        case '0': result.Append('\0'); break;
                        case 'a': result.Append('\a'); break;
                        case 'b': result.Append('\b'); break;
                        case 'f': result.Append('\f'); break;
                        case 'n': result.Append('\n'); break;
                        case 'r': result.Append('\r'); break;
                        case 't': result.Append('\t'); break;
                        case 'v': result.Append('\v'); break;
                        case 'u':
                            var start = i + 1;
                            var end = text.IndexOf('}', start + 1);
                            if (int.TryParse(text.AsSpan(start, end - start + 1), out var codePoint))
                            {
                                result.Append(char.ConvertFromUtf32(codePoint));
                            }
                            i = end;
                            break;
                        default:
                            result.Append(text[i]);
                            break;
                    }
                }
                else
                {
                    result.Append(text[i]);
                }
            }

            return result.ToString();
        }
    }
}
