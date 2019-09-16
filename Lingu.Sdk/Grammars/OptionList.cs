using Lingu.Commons;

namespace Lingu.Grammars
{
    public class OptionList : UniqueList<Symbol, Option>
    {
        public OptionList()
            : base(option => option, new Symbol.NamesEquals())
        {
        }
    }
}
