using System.Collections.Generic;

namespace Lipeg.Runtime
{
    public interface IResult : ILocated
    {
        IContext Next { get; }
        bool IsSuccess { get; }
        IReadOnlyList<INode> Nodes { get; }
    }
}
