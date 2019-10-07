using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Automata;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Nope : Atom
    {
        public Nope()
        {
            var state = new State();
            FA = FA.From(state, state);
        }

        public string Name { get; }

        private readonly FA FA;

        public override void Dump(IndentWriter writer)
        {
            writer.Write(Name);
        }

        public override FA GetFA() => FA;
    }
}