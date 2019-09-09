using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Grammars
{
    public abstract class Symbol
    {
        public Symbol(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public abstract class Symbol<T> : Symbol
        where T : Symbol<T>
    {
        public Symbol(string name)
            : base(name)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is T other && Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
