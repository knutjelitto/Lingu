using Lingu.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Grammars
{
    public class Terminals : UniqueList<Symbol, Terminal>
    {
        public Terminals()
            : base(terminal => terminal)
        {
        }
    }
}
