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

        public override FA GetNfa()
        {
            return FA.From(Value);
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write(Text);
            if (Text != "'" + Value + "'")
            {
                output.Write("/*!! '");
                output.Write(Value);
                output.Write("' !!*/");
            }
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
            return Text;
        }

        private string Convert(string text)
        {
            var result = new StringBuilder();

            for (int i = 0; i < text.Length; i += 1)
            {
                if (text[i] == '\\')
                {
                    i += 1;
                    switch (char.ToUpper(text[i]))
                    {
                        case '\\': result.Append('\\'); break;
                        case '\'': result.Append('\''); break;
                        case '\"': result.Append('\"'); break;
                        case '0': result.Append('\0'); break;
                        case 'A': result.Append('\a'); break;
                        case 'B': result.Append('\b'); break;
                        case 'F': result.Append('\f'); break;
                        case 'N': result.Append('\n'); break;
                        case 'R': result.Append('\r'); break;
                        case 'T': result.Append('\t'); break;
                        case 'V': result.Append('\v'); break;
                        case 'U':
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
