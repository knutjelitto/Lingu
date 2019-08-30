using System;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Option : NamedNode
    {
        public Option(AtomName name, LitString value)
            : base(name)
        {
            Value = value;
        }

        public LitString Value { get; }

        public override void Dump(Indentable output, bool top)
        {
            output.WriteLine($"{Name} = {Value}");
        }
    }
}
