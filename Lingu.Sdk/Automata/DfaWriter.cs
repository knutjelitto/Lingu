using System.Collections.Generic;

using Lingu.Commons;

#nullable enable

namespace Lingu.Automata
{
    public static class DfaWriter
    {
        public static byte[] GetBytes(FA dfa)
        {
            var sets = new UniqueList<Integers>();
            var transitions = new UniqueList<Transition>(new TransitionEq());

            foreach (var state in dfa.States)
            {
                foreach (var transition in state.Transitions)
                {
                    transition.SetId = sets.MaybeAlreadyAdd(transition.Set);
                }
            }
            foreach (var state in dfa.States)
            {
                foreach (var transition in state.Transitions)
                {
                    transition.TransitionId = transitions.MaybeAlreadyAdd(transition);
                }
            }

            return Write(dfa.States, sets, transitions);
        }

        private static byte[] Write(IReadOnlyList<State> states, IReadOnlyList<Integers> sets, IReadOnlyList<Transition> transitions)
        {
            var writer = new BinWriter();

            writer.Write(states.Count);
            WriteStates(writer, states);

            writer.Write(sets.Count);
            WriteSets(writer, sets);

            writer.Write(transitions.Count);
            WriteTransitions(writer, transitions);

            WriteStateTransitions(writer, states);

            return writer.ToArray();
        }

        private static void WriteStates(BinWriter writer, IReadOnlyList<State> states)
        {
            foreach (var state in states)
            {
                writer.Write(state.Final);
                writer.Write(state.Payload + 1);
                writer.Write(state.Transitions.Count);
            }
        }

        private static void WriteSets(BinWriter writer, IReadOnlyList<Integers> sets)
        {
            foreach (var set in sets)
            {
                writer.Write(set.IntervalCount);
                foreach (var (min, max) in set.GetIntervals())
                {
                    writer.Write(min);
                    writer.Write(max);
                }
            }
        }

        private static void WriteTransitions(BinWriter writer, IReadOnlyList<Transition> transitions)
        {
            foreach (var transition in transitions)
            {
                writer.Write(transition.TargetId);
                writer.Write(transition.SetId);
            }
        }

        private static void WriteStateTransitions(BinWriter writer, IReadOnlyList<State> states)
        {
            foreach (var state in states)
            {
                foreach (var transition in state.Transitions)
                {
                    writer.Write(transition.TransitionId);
                }
            }
        }

        private class TransitionEq : EqualityComparer<Transition>
        {
            public override bool Equals(Transition x, Transition y)
            {
                return x.TargetId == y.TargetId && x.SetId == y.SetId;
            }

            public override int GetHashCode(Transition t)
            {
                return (t.TargetId, t.SetId).GetHashCode();
            }
        }
    }
}
