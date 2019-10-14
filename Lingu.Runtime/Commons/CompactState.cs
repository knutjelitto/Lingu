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
        private readonly CompactItem[] terminalValues;
        private readonly CompactItem[] nonterminalValues;

        public CompactState(CompactItem[] terminalValues, CompactItem[] nonterminalValues)
        {
            this.terminalValues = terminalValues;
            this.nonterminalValues = nonterminalValues;
        }

        public IEnumerator<IStateItem> GetEnumerator() => 
            this.terminalValues.Concat(this.nonterminalValues).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => this.terminalValues.Length + this.nonterminalValues.Length;

        public IStateItem this[int index]
        {
            get
            {
                if (index >= this.terminalValues.Length)
                    return this.nonterminalValues[index - this.terminalValues.Length];
                return this.terminalValues[index];
            }
        }

        public IEnumerable<IStateItem> Terminals => this.terminalValues;
        public IEnumerable<IStateItem> Nonterminals => this.nonterminalValues;
        public IEnumerable<IStateItem> All => this;
    }
}
