using System;
using System.Collections.Generic;
using System.Text;

#nullable enable

namespace Lingu.LR
{
    public class LR0 : Item
    {
        public LR0(Dotted dotted, Action action)
            : base(dotted)
        {
            Action = action;
        }

        public Action Action { get; }

        public override bool Equals(object? obj)
        {
            return obj is LR0 other && other.Dotted.Id == Dotted.Id;
        }

        public override int GetHashCode()
        {
            return Dotted.GetHashCode();
        }

        public override string? ToString()
        {
            return $"{Dotted.ToString()} -- {Action}";
        }
    }
}
