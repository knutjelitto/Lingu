﻿using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lingu.Automata
{
    public class Writer
    {
        public Writer(FA dfa)
        {
            Compact(dfa);
        }

        public static byte[] Compact(FA dfa)
        {
            var sets = new UniqueList<Codepoints>();
            var transitions = new UniqueList<Transition>(new TransitionEq());

            foreach (var state in dfa.States)
            {
                foreach (var transition in state.Transitions)
                {
                    transition.SetId = sets.Add(transition.Set);
                }
            }
            foreach (var state in dfa.States)
            {
                foreach (var transition in state.Transitions)
                {
                    transition.TransitionId = transitions.Add(transition);
                }
            }

            return Write(dfa.States, sets, transitions);
        }

        private static byte[] Write(IReadOnlyList<State> states, IReadOnlyList<Codepoints> sets, IReadOnlyList<Transition> transitions)
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
                writer.Write(0);
                writer.Write(state.Transitions.Count);
            }
        }

        private static void WriteSets(IReadOnlyList<Codepoints> sets, BinWriter writer)
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