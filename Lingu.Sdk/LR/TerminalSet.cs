using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class TerminalSet : SortedSet<Terminal>
    {
        public TerminalSet()
            : base (new TerminalComparer())
        {
        }

        public bool WithEpsilon { get; set; }

        private class TerminalComparer : IComparer<Terminal>
        {
            public int Compare([AllowNull] Terminal x, [AllowNull] Terminal y)
            {
                if (x == null) throw new ArgumentOutOfRangeException(nameof(x));
                if (y == null) throw new ArgumentOutOfRangeException(nameof(y));

                return x.Id.CompareTo(y.Id);
            }
        }

        public override string ToString()
        {
            var members = string.Join(",", this);
            var epsilon = WithEpsilon ? ",ε" : string.Empty;
            return $"{{{members}{epsilon}}}";
        }
    }
}
