using Lingu.Grammars;

namespace Lingu.Tree
{
    public class Terminals : NamedSet<Symbol, RawTerminal>
    {
        public Terminals()
            : base("terminals", true, terminal => terminal)
        {
        }
    }
}
