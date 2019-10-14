using Lingu.Output;

#nullable enable

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
    }
}
