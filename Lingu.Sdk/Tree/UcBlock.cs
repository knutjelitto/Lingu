using System;

using Lingu.Automata;
using Lingu.Output;

namespace Lingu.Tree
{
    /// <summary>
    /// Represents a Unicode block
    /// </summary>
    public class UcBlock : Atom
    {
        public UcBlock(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public override FA GetFA()
        {
            throw new NotImplementedException();
        }

        public override void Dump(IndentWriter output)
        {
            output.Write(Text);
        }
    }
}
