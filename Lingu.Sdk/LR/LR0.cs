using System;

#nullable enable

namespace Lingu.LR
{
    public class LR0 : Item<LR0>
    {
        public LR0(Core core, bool inKernel)
            : base(core, inKernel)
        {
        }

        public override LR0 Next(bool inKernel)
        {
            return new LR0(Core.Next, inKernel);
        }

        public override bool Equals(object? obj) => obj is LR0 other && Id == other.Id;
        public override int GetHashCode() => Core.GetHashCode();

        public override string ToString()
        {
            return $"[{Core.ToString()}] -> {Action()}";
        }
    }
}
