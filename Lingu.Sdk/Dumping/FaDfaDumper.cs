using System.Linq;

using Lingu.Automata;
using Lingu.Commons;
using Lingu.Writers;

#nullable enable

namespace Lingu.Dumping
{
    public class FaDfaDumper
    {
        public void Dump(IndentWriter writer, FA dfa)
        {
            foreach (var state in dfa.States)
            {
                Dump(writer, state);
            }
        }

        public void Dump(IndentWriter writer, State state)
        {
            var finA = state.IsFinal ? "(" : ".";
            var finB = state.IsFinal ? ")" : ".";
            var pay = state.IsPayload ? $"  «{state.Payload}»" : string.Empty;

            writer.WriteLine($"{finA}{state.Id}{finB}{pay}");
            writer.Indend(() =>
            {
                foreach (var transition in state.Transitions)
                {
                    writer.WriteLine($"{transition.Target.Id} <= {Str(transition.Set)}");
                }
            });
        }

        private string Str(Integers set)
        {
            return $"[{string.Join(", ", set.GetIntervals().Select(i => Str(i)))}]";
        }

        private string Str((int min, int max) i)
        {
            if (i.min == i.max)
            {
                return CharRep.InRange(i.min);
            }

            return $"{CharRep.InRange(i.min)} - {CharRep.InRange(i.max)}";
        }
    }
}
