using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Character : CharExpression, IEquatable<Character>
    {
        private Character(int value)
        {
            Value = value;
        }
        public int Value { get; }

        public static Character From(int value)
        {
            return new Character(value);
        }

        public override bool Equals(object? obj) => Equals(obj as Character);

        public bool Equals(Character? other) =>
            other != null &&
            other.Value == Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
