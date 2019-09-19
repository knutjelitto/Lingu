using System;

#nullable enable

namespace Lingu.LR
{
    public class LR0 : Item
    {
        public LR0(Core dotted, Action? action = null)
            : base(dotted, action)
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is LR0 other && other.Core.Id == Core.Id;
        }

        public override int GetHashCode()
        {
            return Core.GetHashCode();
        }

        public override string? ToString()
        {
            var a = Action?.ToString() ?? "none";
            return $"{Core.ToString()} -- {a}";
        }
    }
}
