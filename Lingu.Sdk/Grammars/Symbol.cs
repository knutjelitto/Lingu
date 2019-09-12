using System;

using Lingu.Writers;

namespace Lingu.Grammars
{
    public abstract class Symbol : ICanDump
    {
        public Symbol(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void Dump(IndentWriter output, bool top);

        public override bool Equals(object obj)
        {
            return obj is Symbol other && Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public static explicit operator Symbol(string name) => new InSymbol(name);

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }

        private class InSymbol : Symbol
        {
            public InSymbol(string name) : base(name)
            {
            }

            public override void Dump(IndentWriter output, bool top)
            {
                output.Write(Name);
            }
        }
    }
}
