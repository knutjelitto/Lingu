using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Character : CharExpression, IEquatable<Character>
    {
        private Character(int @char)
        {
            Char = @char;
        }
        public int Char { get; }

        public static Character From(int @char)
        {
            return new Character(@char);
        }

        public override bool Equals(object? obj) => Equals(obj as Character);

        public bool Equals(Character? other) =>
            other != null &&
            other.Char == Char;

        public override int GetHashCode() => Char.GetHashCode();
    }
}
