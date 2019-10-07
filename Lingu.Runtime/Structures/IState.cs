using System.Collections.Generic;

namespace Lingu.Runtime.Structures
{
    public interface IState : IReadOnlyList<IStateItem>
    {
        IEnumerable<IStateItem> Terminals { get; }
        IEnumerable<IStateItem> Nonterminals { get; }
        IEnumerable<IStateItem> All { get; }
    }
}
