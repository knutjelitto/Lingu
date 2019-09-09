using Lingu.Grammars;

namespace Lingu.Tree
{
    public class Terminals : NamedSet<Symbol, TerminalDefinition>
    {
        public Terminals()
            : base("terminals", true, terminal => terminal)
        {
        }
    }
}
