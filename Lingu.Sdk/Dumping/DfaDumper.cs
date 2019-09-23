using System.Linq;

using Lingu.Commons;
using Lingu.Runtime.Lexing;
using Lingu.Writers;

#nullable enable

namespace Lingu.Dumping
{
    public class DfaDump
    {
        public void Dump(IndentWriter writer, Dfa dfa)
        {
            foreach (var state in dfa.States)
            {
                Dump(writer, state);
            }
        }

        public void Dump(IndentWriter writer, DfaState state)
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
