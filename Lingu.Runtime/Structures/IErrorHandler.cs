using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Runtime.Structures
{
    public interface IErrorHandler
    {
        string GetExpectedMessage(ILocation location, IEnumerable<ISymbol> symbols);
        IEnumerable<ISymbol> GetSymbols(Lexing.Dfa dfa);
        IEnumerable<ISymbol> GetSymbols(int stateId);
    }
}
