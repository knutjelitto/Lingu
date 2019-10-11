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
            Shorts = shorts.Select(s => new StateItem(s)).ToArray();
            NumberOfTerminals = numberOfTerminals;
        }

        public int NumberOfTerminals { get; }
        public IStateItem this[int symNo] => Shorts[symNo];
        public IEnumerable<IStateItem> Terminals => Shorts.Take(NumberOfTerminals).Cast<IStateItem>();
        public IEnumerable<IStateItem> Nonterminals => Shorts.Skip(NumberOfTerminals).Cast<IStateItem>();
        public IEnumerable<IStateItem> All => Shorts.Cast<IStateItem>();
        private StateItem[] Shorts { get; }
        public int Count => Shorts.Length;
        public IEnumerator<IStateItem> GetEnumerator() => Shorts.Cast<IStateItem>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public Span<StateItem> GetTerminals()
        {
            return Shorts.AsSpan(0, NumberOfTerminals);
        }
        public Span<StateItem> GetNonterminals()
        {
            return Shorts.AsSpan(NumberOfTerminals, Shorts.Length - NumberOfTerminals);
        }
        public Span<StateItem> GetAll()
        {
            return Shorts.AsSpan();
        }
    }
}
