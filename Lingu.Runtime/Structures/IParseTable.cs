using Lingu.Runtime.Concretes;
using System.Collections.Generic;

namespace Lingu.Runtime.Structures
{
    public interface IParseTable
    {
        IState this[int stateNo] { get; }

        IStateItem this[int stateNo, int symNo] => this[stateNo][symNo];

        int NumberOfStates { get; }
        int NumberOfTerminals { get; }
        int NumberOfSymbols { get; }

        IEnumerable<IStateItem> ReallyAll
        {
            get
            {
                for (var stateNo = 0; stateNo < NumberOfStates; ++stateNo)
                {
                    for (var symNo = 0; symNo < NumberOfSymbols; ++symNo)
                    {
                        yield return this[stateNo, symNo];
                    }
                }
            }
        }
    }
}
