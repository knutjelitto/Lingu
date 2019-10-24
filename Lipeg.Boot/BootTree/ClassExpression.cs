using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class ClassExpression : Expression
    {
        public ClassExpression(IEnumerable<CharacterRange> ranges, bool negated)
        {
            Ranges = ranges.ToList().AsReadOnly();
            Negated = negated;
        }

        public static ClassExpression From(IEnumerable<CharacterRange> ranges, bool negated = false)
        {
            return new ClassExpression(ranges, negated);
        }

        public IList<CharacterRange> Ranges { get; }
        public bool Negated { get; }
    }
}
