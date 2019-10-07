using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public sealed class SimpleState : IState
    {
        public SimpleState(IEnumerable<ushort> shorts, int numberOfTerminals)
        {
            Shorts = shorts.Select(s => new StateItem(s)).Cast<IStateItem>().ToArray();
            NumberOfTerminals = numberOfTerminals;
        }
        public int NumberOfTerminals { get; }
        public IStateItem this[int symNo] => Shorts[symNo];
        public IEnumerable<IStateItem> Terminals => Shorts.Take(NumberOfTerminals);
        public IEnumerable<IStateItem> Nonterminals => Shorts.Skip(NumberOfTerminals);
        public IEnumerable<IStateItem> All => Shorts;
        private IReadOnlyList<IStateItem> Shorts { get; }
        public int Count => Shorts.Count;
        public IEnumerator<IStateItem> GetEnumerator() => Shorts.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
