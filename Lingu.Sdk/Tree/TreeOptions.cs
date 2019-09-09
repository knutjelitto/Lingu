using Lingu.Grammars;

namespace Lingu.Tree
{
    public class TreeOptions : NamedSet<Symbol, TreeOption>
    {
        public TreeOptions()
            : base("options", false, option => option)
        {
        }
    }
}
