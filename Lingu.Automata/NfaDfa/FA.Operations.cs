using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lingu.Automata
{
    public partial class FA
    {
        private static class Operations
        {
            public static FA ToDfa(FA nfa)
            {
                var once = new UniqueQueue<Closure>();
                var start = new Closure(nfa.Start, nfa.Final);
                once.Enqueue(start);

                while (once.Count > 0)
                {
                    var closure = once.Dequeue();
                    var transitions = closure.UnambiguateTransitions();

                    foreach (var transition in transitions)
                    {
                        var terminal = transition.Key;
                        var targets = transition.Value;
                        var targetClosure = new Closure(targets, nfa.Final);
                        once.Enqueue(targetClosure, out targetClosure);
                        var target = targetClosure.DfaState;

                        closure.DfaState.Add(Atom.From(terminal), target);
                    }
                }

                return From(start.DfaState);
            }
        }
    }
}
