﻿using System;
using System.Diagnostics;
using System.Globalization;
using Lingu.Automata;
using Lingu.Commons;
using Lingu.Errors;

namespace Lingu.Tree
{
    public class AtomCodepoint : Atom
    {
        public AtomCodepoint(string text)
        {
            Text = text;

            if (text.ToUpper().StartsWith("\\U{"))
            {
                if (int.TryParse(Text.Substring(3, Text.Length - 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value))
                {
                    Value = value;
                    return;
                }
            }
            else if (text.ToUpper().StartsWith("U+"))
            {
                if (int.TryParse(Text.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value))
                {
                    Value = value;
                    return;
                }
            }

            throw new TreeException($"can't convert `{text}` to a valid unicode codepoint");
        }

        public string Text { get; }
        public int Value { get; }

        public override Nfa GetNfa()
        {
            return Nfa.From(Value);
        }

        public override void Dump(Indentable output, bool top)
        {
            output.Write(Text);
        }
    }
}
