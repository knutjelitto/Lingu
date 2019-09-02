﻿using System.Collections.Generic;
using System.Linq;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class Terminals : NamedSet<TerminalDefinition>
    {
        public Terminals()
            : base("terminals", true)
        {
        }
    }
}
