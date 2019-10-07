using System.Collections.Generic;

namespace Lingu.Runtime.Structures
{
    public interface IProduction
    {
        int Length { get; }
        INonterminal Nonterminal { get; }
        bool IsPromote { get; }

        /// <summary>
        /// Filter out ``drop´´ symbols
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        IEnumerable<IToken> DropFilter(IEnumerable<IToken> tokens);
    }
}
