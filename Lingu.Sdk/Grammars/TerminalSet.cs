using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using Lingu.Grammars;

#nullable enable

namespace Lingu.Grammars
{
    [DebuggerDisplay("{ToString()}")]
    public class TerminalSet : SortedSet<Terminal>
    {
        public TerminalSet()
            : base(new TerminalComparer())
        {
        }
        public TerminalSet(TerminalSet terminals)
            : base(terminals, new TerminalComparer())
        {
            WithEpsilon = terminals.WithEpsilon;
        }

        public bool WithEpsilon { get; set; }

        public bool IsEmpty => Count == 0 && !WithEpsilon;

        public override bool Equals(object? obj)
        {
            return obj is TerminalSet other && SetEquals(other) && WithEpsilon == other.WithEpsilon;
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            foreach (var terminal in this)
            {
                hash.Add(terminal.Id);
            }
            return hash.ToHashCode();
        }

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
            var members = string.Join(", ", this);
            var epsilon = WithEpsilon ? (Count > 0 ? ", ε" : "ε") : string.Empty;
            return $"{{{members}{epsilon}}}";
        }
    }
}
