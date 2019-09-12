using Lingu.Commons;

namespace Lingu.Grammars
{
    public class Options : UniqueList<Symbol, Option>
    {
        public Options()
            : base(option => option)
        {
        }
    }
}
