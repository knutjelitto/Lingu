using Lingu.Writers;

namespace Lingu.Grammars
{
    public class Option : Symbol
    {
        public Option(string name, string value)
            : base(name)
        {
            Value = (Symbol)value;
        }

        public Symbol Value { get; }

        public override void Dump(IndentWriter output)
        {
            output.WriteLine($"{this} = {Value};");
        }
    }
}
