using Lingu.Grammars;

namespace Lingu.Tree
{
    public class Terminals : NamedSet<Symbol, TreeTerminal>
    {
        public Terminals()
            : base("terminals", true, terminal => terminal)
        {
        }
    }
}
