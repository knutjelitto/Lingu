using System;
using Lingu.Errors;
using System.Diagnostics;
using System.Globalization;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class AtomUcCodepoint : TerminalAtom
    {
        public AtomUcCodepoint(string text)
        {
            Text = text;

            Debug.Assert(text.ToUpper().StartsWith("\\U{"));
            if (int.TryParse(Text.Substring(3, Text.Length - 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value))
            {
                Value = value;
                return;
            }

            throw new TreeException($"can't convert `{text}` to a valid unicode codepoint");
        }

        public string Text { get; }
        public int Value { get; }

        public override void Dump(Indentable output, Boolean top)
        {
            if (top)
            {
                output.WriteLine($"| {Text}");
            }
            else
            {
                output.Write(Text);
            }
        }
    }
}
