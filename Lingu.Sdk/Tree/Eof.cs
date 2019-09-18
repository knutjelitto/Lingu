using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Eof : Atom
    {
        public Eof(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override void Dump(IndentWriter writer)
        {
            writer.Write(Name);
        }

        public override FA GetFA()
        {
            return FA.Any().ToDfa().Not();
        }
    }
}
