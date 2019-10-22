using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.Boot.Tree
{
    public class ClassExpression : Expression
    {
        public ClassExpression(IEnumerable<CharacterRange> ranges, bool negated, bool? ignoreCase)
        {
            Ranges = ranges.ToList().AsReadOnly();
            Negated = negated;
            IgnoreCase = ignoreCase;
        }

        public static ClassExpression From(IEnumerable<CharacterRange> ranges, bool negated = false, bool? ignoreCase = null)
        {
            return new ClassExpression(ranges, negated, ignoreCase);
        }

        public IList<CharacterRange> Ranges { get; }
        public bool Negated { get; }
        public bool? IgnoreCase { get; }
    }
}
