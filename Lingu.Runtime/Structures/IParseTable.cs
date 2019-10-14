using Lingu.Runtime.Concretes;
using System.Collections.Generic;

namespace Lingu.Runtime.Structures
{
    public interface IParseTable
    {
        IState this[int stateNo] { get; }

        IStateItem this[int stateNo, int symNo] { get; }

        int NumberOfStates { get; }
        int NumberOfTerminals { get; }
        int NumberOfSymbols { get; }
        int NumberOfNonterminals => NumberOfSymbols - NumberOfTerminals;
    }
}
