using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class CharacterRange : IEquatable<CharacterRange>
    {
        public CharacterRange(char min, char max)
        {
            Min = min;
            Max = max;
        }
        public char Min { get; }
        public char Max { get; }

        public static CharacterRange From(char min, char max)
        {
            return new CharacterRange(min, max);
        }

        public override bool Equals(object? obj) => Equals(obj as CharacterRange);

        public bool Equals(CharacterRange? other) =>
            other != null &&
            other.Min == this.Min &&
            other.Max == this.Max;

        public override int GetHashCode() => (Min, Max).GetHashCode();
    }
}
