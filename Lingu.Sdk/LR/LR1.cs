using System;
using System.Collections.Generic;
using System.Text;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class LR1 : Item<LR1>
    {
        public LR1(Core core, Terminal lookahead)
            : base(core)
        {
            Lookahead = lookahead;
        }

        public Terminal Lookahead { get; }

        public override LR1 Next()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj) => obj is LR1 other && Id == other.Id && Lookahead.Equals(other.Lookahead);
        public override int GetHashCode() => (Core, Lookahead).GetHashCode();
        public override string? ToString()
        {
            return $"[{Core.ToString()}; {Lookahead}] -> {Action()}";
        }
    }
}
