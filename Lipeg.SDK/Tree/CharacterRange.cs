using System;

namespace Lipeg.SDK.Tree
{
    public class CharacterRange : CharExpression, IEquatable<CharacterRange>
    {
        private CharacterRange(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public int Min { get; }
        public int Max { get; }

        public static CharacterRange From(int min, int max)
        {
            return new CharacterRange(min, max);
        }

        public override bool Equals(object? obj) => Equals(obj as CharacterRange);

        public bool Equals(CharacterRange? other) =>
            other != null &&
            other.Min == Min &&
            other.Max == Max;

        public override int GetHashCode() => (Min, Max).GetHashCode();
    }
}
