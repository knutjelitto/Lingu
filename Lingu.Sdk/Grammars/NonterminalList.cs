using Lingu.Commons;

#nullable enable

namespace Lingu.Grammars
{
    public class NonterminalList : UniqueList<Symbol, Nonterminal>
    {
        public NonterminalList()
            : base(nonterminal => nonterminal, new Symbol.NamesEquals())
        {
        }
    }
}
