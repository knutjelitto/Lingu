using Lingu.Grammars;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#nullable enable

namespace Lingu.LR
{
    public class SymbolSet : HashSet<Symbol>
    {
        public SymbolSet()
            : base (new SymbolEquality())
        {
        }

        private class SymbolEquality : IEqualityComparer<Symbol>
        {
            public bool Equals([AllowNull] Symbol x, [AllowNull] Symbol y)
            {
                return x != null && y != null && x.Id == y.Id;
            }

            public int GetHashCode([DisallowNull] Symbol symbol)
            {
                return symbol.Id.GetHashCode();
            }
        }
    }
}
