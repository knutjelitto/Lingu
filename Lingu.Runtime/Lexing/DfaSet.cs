using System.Collections.Generic;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Lexing
{
    public class DfaSet : IDfaSet
    {
        public DfaSet(IReadOnlyList<Dfa> dfas, IReadOnlyList<int> stateMap, Dfa spacing)
        {
            Dfas = dfas;
            StateMap = stateMap;
            Spacing = spacing;
        }

        public IReadOnlyList<Dfa> Dfas { get; }
        public IReadOnlyList<int> StateMap { get; }
        public Dfa Spacing { get; }

        public Dfa this[int stateId] => Dfas[StateMap[stateId]];
    }
}
