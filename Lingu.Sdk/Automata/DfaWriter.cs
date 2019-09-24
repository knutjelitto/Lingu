using System.Collections.Generic;
using System.Linq;

using Lingu.Commons;

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
            WriteStates(states, writer);

            writer.Write(sets.Count);
            WriteSets(sets, writer);

            writer.Write(transitions.Count);
            WriteTransitions(transitions, writer);

            WriteStateTransitions(states, writer);

            return writer.ToArray();
        }

        private static void WriteStates(IReadOnlyList<State> states, BinWriter writer)
        {
            foreach (var state in states)
            {
                writer.Write(state.IsFinal);
                writer.Write(/*TODO - real payload*/0);
                writer.Write(state.Transitions.Count);
            }
        }

        private static void WriteSets(IReadOnlyList<Integers> sets, BinWriter writer)
        {
            foreach (var set in sets)
            {
                writer.Write(set.IntervalCount);
                foreach (var interval in set.GetIntervals())
                {
                    writer.Write(interval.Min);
                    writer.Write(interval.Max);
                }
            }
        }

        private static void WriteTransitions(IReadOnlyList<Transition> transitions, BinWriter writer)
        {
            foreach (var transition in transitions)
            {
                writer.Write(transition.TargetId);
                writer.Write(transition.SetId);
            }
        }

        private static void WriteStateTransitions(IReadOnlyList<State> states, BinWriter writer)
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
