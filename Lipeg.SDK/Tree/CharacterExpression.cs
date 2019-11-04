using System;

namespace Lipeg.SDK.Tree
{
    public class CharacterExpression : Expression, IEquatable<CharacterExpression>
    {
        private CharacterExpression(int value)
        {
            Value = value;
        }
        public int Value { get; }

        public static CharacterExpression From(int value)
        {
            return new CharacterExpression(value);
        }

        public override bool Equals(object? obj) => Equals(obj as CharacterExpression);

        public bool Equals(CharacterExpression? other) =>
            other != null &&
            other.Value == Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
