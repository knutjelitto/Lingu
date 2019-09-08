using Lingu.Commons;
using Lingu.Runtime.LexDfa;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tools
{
    public class DfaDump
    {
        public void Dump(IWriter writer, Dfa dfa)
        {
            foreach (var state in dfa.States)
            {
                Dump(writer, state);
            }
        }

        public void Dump(IWriter writer, DfaState state)
        {
            var finA = state.IsFinal ? "(" : ".";
            var finB = state.IsFinal ? ")" : ".";
            writer.WriteLine($"{finA}{state.Id}{finB}");
            writer.Indend(() =>
            {
                foreach (var transition in state.Transitions)
                {
                    writer.WriteLine($"{transition.Target.Id} <= {Str(transition.Set)}");
                }
            });
        }

        private string Str(DfaSet set)
        {
            return $"[{string.Join(",", set.Intervals.Select(i => Str(i)))}]";
        }

        private string Str(DfaInterval interval)
        {
            if (interval.Min == interval.Max)
            {
                return CharRep.InRange(interval.Min);
            }

            return $"{CharRep.InRange(interval.Min)}-{CharRep.InRange(interval.Max)}";
        }
    }
}
