using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lingu.Automata
{
    public partial class Nfa
    {
        public Nfa(NfaState start, NfaState end)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));
        }

        public NfaState End { get; }
        public NfaState Start { get; }

        public void Dump()
        {
            Dump(Console.Out);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public void Dump(TextWriter writer)
        {
            new NfaPlumber(this).Dump(writer);
        }

        public Dfa ToDfa()
        {
            var once = new UniqueQueue<NfaClosure>();
            var start = new NfaClosure(this.Start, this.End);
            once.Enqueue(start);

            while (once.Count > 0)
            {
                var closure = once.Dequeue();
                var transitions = closure.UnambiguateTransitions();

                foreach (var transition in transitions)
                {
                    var terminal = transition.Key;
                    var targets = transition.Value;
                    var targetClosure = new NfaClosure(targets, this.End);
                    once.Enqueue(targetClosure, out targetClosure);
                    var target = targetClosure.State;

                    closure.State.Add(Atom.From(terminal), target);
                }
            }

            return Dfa.From(start.State);
        }

        private Nfa Clone()
        {
            var map = new Dictionary<NfaState, NfaState>();

            NfaState Map(NfaState state)
            {
                if (!map.TryGetValue(state, out var mapped))
                {
                    mapped = new NfaState();
                    map.Add(state, mapped);

                    foreach (var transition in state.TerminalTransitions)
                    {
                        mapped.Add(transition.Terminal, Map(transition.Target));
                    }
                    foreach (var transition in state.EpsilonTransitions)
                    {
                        mapped.Add(Map(transition.Target));
                    }
                }

                return mapped;
            }

            return new Nfa(Map(Start), Map(End));
        }
    }
}