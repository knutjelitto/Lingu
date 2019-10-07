using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Grammars
{
    public abstract class Symbol : ISymbol, IEquatable<Symbol>
    {
        public Symbol(string name)
        {
            Name = name;
            Id = -1;
            Pid = -1;
            First = new TerminalSet();
        }

        public string Name { get; }
        public int Id { get; set; }
        public int Pid { get; set; }
        public bool IsGenerated { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsPid => Pid >= 0;

        public int UseCount { get; private set; }
        public void Use()
        {
            UseCount += 1;
        }

        public TerminalSet First { get; }

        public static explicit operator Symbol(string name) => new InSymbol(name);

        public override string ToString()
        {
            return Name;
        }

        public virtual string ToShort()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is Symbol other && Id == other.Id;
        }

        public bool Equals([AllowNull] Symbol other)
        {
            return other != null && Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
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
        }
    }
}
