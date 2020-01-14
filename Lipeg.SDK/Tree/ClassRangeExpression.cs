using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lipeg.SDK.Tree
{
    public class ClassRangeExpression : ClassPartExpression, IEquatable<ClassRangeExpression>
    {
        private ClassRangeExpression(ILocated located, int min, int max)
            : base(located)
        {
            Min = min;
            Max = max;
        }
        public int Min { get; }
        public int Max { get; }

        public static ClassRangeExpression From(ILocated located, int min, int max)
        {
            return new ClassRangeExpression(located, min, max);
        }

        public override bool Equals(object? obj) => Equals(obj as ClassRangeExpression);

        public bool Equals(ClassRangeExpression? other) =>
            other != null &&
            other.Min == Min &&
            other.Max == Max;

        public override int GetHashCode() => (Min, Max).GetHashCode();

        public override IEnumerable<int> Values => Enumerable.Range(Min, Max - Min + 1);
    }
}
