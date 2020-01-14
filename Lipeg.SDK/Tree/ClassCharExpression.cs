using Lipeg.Runtime;
using System;
using System.Collections.Generic;

namespace Lipeg.SDK.Tree
{
    public class ClassCharExpression : ClassPartExpression, IEquatable<ClassCharExpression>
    {
        private ClassCharExpression(ILocated located, int charValue)
            : base(located)
        {
            Value = charValue;
        }
        public int Value { get; }

        public static ClassCharExpression From(ILocated located, int value)
        {
            return new ClassCharExpression(located, value);
        }

        public override bool Equals(object? obj) => Equals(obj as ClassCharExpression);

        public bool Equals(ClassCharExpression? other) =>
            other != null &&
            other.Value == Value;

        public override int GetHashCode() => Value.GetHashCode();
        public override IEnumerable<int> Values => new[] {Value};
    }
}
