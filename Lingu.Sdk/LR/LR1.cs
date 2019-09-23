using System.Diagnostics;

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
            return new LR1(Core.Next, inKernel, Lookahead);
        }

        public override bool Equals(object? obj)
        {
            return obj is LR1 other && Id == other.Id && Lookahead.Equals(other.Lookahead);
        }

        public override int GetHashCode() => (Core, Lookahead).GetHashCode();

        public override string? ToString()
        {
            return $"[{Core.ToString()}; {Lookahead}] -> {Action()}";
        }
    }
}
