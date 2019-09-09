using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public class TreeOption : Symbol
    {
        public TreeOption(string name, Name value)
            : base(name)
        {
            Value = value;
        }

        public Name Value { get; }

        public override void Dump(IWriter output, bool top)
        {
            output.WriteLine($"{this} = {Value};");
        }
    }
}
