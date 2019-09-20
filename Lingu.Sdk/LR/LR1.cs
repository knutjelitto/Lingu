using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public class LR1 : Item<LR1>
    {
        public LR1(Core core, bool inKernel, TerminalSet lookahead)
            : base(core, inKernel)
        {
            Debug.Assert(!lookahead.IsEmpty);
            Lookahead = lookahead;
        }

        public TerminalSet Lookahead { get; }

        public override LR1 Next(bool inKernel)
        {
            var lookahead = new TerminalSet(Core.Next.First);
            if (lookahead.WithEpsilon)
            {
                lookahead.UnionWith(Lookahead);
                lookahead.WithEpsilon = false;
            }
            Debug.Assert(!lookahead.IsEmpty);

            return new LR1(Core.Next, inKernel, lookahead);
        }

        public override bool Equals(object? obj) => obj is LR1 other && Id == other.Id && Lookahead.Equals(other.Lookahead);
        public override int GetHashCode() => (Core, Lookahead).GetHashCode();
        public override string? ToString()
        {
            return $"[{Core.ToString()}; {Lookahead}] -> {Action()}";
        }
    }
}
