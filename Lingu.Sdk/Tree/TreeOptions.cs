using Lingu.Grammars;

namespace Lingu.Tree
{
    public class TreeOptions : NamedSet<Symbol, Option>
    {
        public TreeOptions()
            : base("options", false, option => option)
        {
        }
    }
}
