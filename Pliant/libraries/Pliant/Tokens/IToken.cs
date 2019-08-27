using System.Collections.Generic;

namespace Pliant.Tokens
{
    public interface IToken : ITrivia
    {
        TokenName TokenName { get; }
        IReadOnlyList<ITrivia> LeadingTrivia { get; }
        IReadOnlyList<ITrivia> TrailingTrivia { get; }
    }
}