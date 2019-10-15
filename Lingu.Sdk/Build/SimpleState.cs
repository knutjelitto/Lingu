using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Lingu.Runtime.Concretes;
using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Build
{
    public sealed class SimpleState : IState
    {
        public SimpleState(IEnumerable<int> intse, int numberOfTerminals)
        {
            Intse = intse.Select(s => new StateItem(s)).ToArray();
            NumberOfTerminals = numberOfTerminals;
        }

        public int NumberOfTerminals { get; }
        public IStateItem this[int symNo] => Intse[symNo];
        public IEnumerable<IStateItem> Terminals => Intse.Take(NumberOfTerminals).Cast<IStateItem>();
        public IEnumerable<IStateItem> Nonterminals => Intse.Skip(NumberOfTerminals).Cast<IStateItem>();
        public IEnumerable<IStateItem> All => Intse.Cast<IStateItem>();
        private StateItem[] Intse { get; }
        public int Count => Intse.Length;
        public IEnumerator<IStateItem> GetEnumerator() => Intse.Cast<IStateItem>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public Span<StateItem> GetTerminals()
        {
            return Intse.AsSpan(0, NumberOfTerminals);
        }
        public Span<StateItem> GetNonterminals()
        {
            return Intse.AsSpan(NumberOfTerminals, Intse.Length - NumberOfTerminals);
        }
        public Span<StateItem> GetAll()
        {
            return Intse.AsSpan();
        }
    }
}
