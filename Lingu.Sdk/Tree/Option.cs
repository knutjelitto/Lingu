using Lingu.Commons;

namespace Lingu.Sdk.Tree
{
    public class Option : NamedNode
    {
        public Option(AtomName name, AtomText value)
            : base(name)
        {
            Value = value;
        }

        public AtomText Value { get; }

        public override void Dump(IWriter output, bool top)
        {
            Name.Dump(output, top);
            output.Write(" = ");
            Value.Dump(output, top);
            output.WriteLine(";");
        }
    }
}
