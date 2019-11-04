using System;

namespace Lipeg.SDK.Tree
{
    public class CharacterRangeExpression : Expression, IEquatable<CharacterRangeExpression>
    {
        private CharacterRangeExpression(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public int Min { get; }
        public int Max { get; }

        public static CharacterRangeExpression From(int min, int max)
        {
            return new CharacterRangeExpression(min, max);
        }

        public override bool Equals(object? obj) => Equals(obj as CharacterRangeExpression);

        public bool Equals(CharacterRangeExpression? other) =>
            other != null &&
            other.Min == Min &&
            other.Max == Max;

        public override int GetHashCode() => (Min, Max).GetHashCode();
    }
}
