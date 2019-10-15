using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Lingu.Runtime.Structures;

#nullable enable

namespace Lingu.Runtime.Commons
{
    public class CompactState : IState
    {
        private readonly int terminalMin;
        private readonly int[] terminalValues;
        private readonly int nonterminalMin;
        private readonly int[] nonterminalValues;

        public CompactState(int terminalMin, int[] terminalValues, int nonterminalMin, int[] nonterminalValues)
        {
            this.terminalMin = terminalMin;
            this.terminalValues = terminalValues;
            this.nonterminalMin = nonterminalMin;
            this.nonterminalValues = nonterminalValues;
        }

        public IEnumerator<IStateItem> GetEnumerator() => Terminals.Concat(Nonterminals).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => this.terminalValues.Length + this.nonterminalValues.Length;

        public IStateItem this[int index]
        {
            get
            {
                if (index >= this.terminalValues.Length)
                    return new CompactItem(this.nonterminalValues[index - this.terminalValues.Length] + nonterminalMin);
                return new CompactItem(this.terminalValues[index] + terminalMin);
            }
        }

        public IEnumerable<IStateItem> Terminals => this.terminalValues.Select(v => new CompactItem(v + terminalMin));
        public IEnumerable<IStateItem> Nonterminals => this.nonterminalValues.Select(v => new CompactItem(v + nonterminalMin));
        public IEnumerable<IStateItem> All => this;
    }
}
