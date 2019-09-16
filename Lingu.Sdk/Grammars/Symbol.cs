using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Lingu.Writers;

namespace Lingu.Grammars
{
    public abstract class Symbol : ICanDump
    {
        public Symbol(string name)
        {
            Name = name;
            Id = -1;
        }

        public string Name { get; }
        public int Id { get; set; }
        public bool IsGenerated { get; set; }
        public bool IsPrivate { get; set; }

        public int UseCount { get; private set; }
        public void Use()
        {
            UseCount += 1;
        }

        public abstract void Dump(IndentWriter writer);

        public static explicit operator Symbol(string name) => new InSymbol(name);

        public override string ToString()
        {
            return Name;
        }

        public class NamesEquals : IEqualityComparer<Symbol>
        {
            public bool Equals([AllowNull] Symbol x, [AllowNull] Symbol y)
            {
                return x != null && y != null && x.Name.Equals(y.Name, StringComparison.Ordinal);
            }

            public int GetHashCode([DisallowNull] Symbol obj)
            {
                return obj.Name.GetHashCode();
            }
        }


        private class InSymbol : Symbol
        {
            public InSymbol(string name) : base(name)
            {
            }

            public override void Dump(IndentWriter output)
            {
                output.Write(Name);
            }
        }
    }
}
