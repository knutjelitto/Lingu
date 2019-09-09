using Lingu.Commons;

namespace Lingu.Tree
{
    public class TreeOption : NamedNode
    {
        public TreeOption(Name name, Name value)
            : base(name)
        {
            Value = value;
        }

        public Name Value { get; }

        public override void Dump(IWriter output, bool top)
        {
            Name.Dump(output, top);
            output.Write(" = ");
            Value.Dump(output, top);
            output.WriteLine(";");
        }
    }
}
