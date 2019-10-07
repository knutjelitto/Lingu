using System.Collections.Generic;

namespace Lingu.Runtime.Structures
{
    public interface ITable
    {
        IState this[int stateNo] { get; }

        IStateItem this[int stateNo, int symNo] => this[stateNo][symNo];

        IEnumerable<IStateItem> ReallyAll { get; }
    }
}
