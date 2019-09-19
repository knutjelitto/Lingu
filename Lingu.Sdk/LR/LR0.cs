using System;

#nullable enable

namespace Lingu.LR
{
    public class LR0 : Item<LR0>
    {
        public LR0(Core core)
            : base(core)
        {
        }

        public override LR0 Next()
        {
            return new LR0(Core.Next);
        }

        public override bool Equals(object? obj) => obj is LR0 other && Id == other.Id;
        public override int GetHashCode() => Core.GetHashCode();

        public override string? ToString()
        {
            return $"[{Core.ToString()}] -> {Action()}";
        }
    }
}
