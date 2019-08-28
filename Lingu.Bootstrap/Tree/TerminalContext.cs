﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Bootstrap.Tree
{
    public class TerminalContext : TerminalItem
    {
        public TerminalContext(AtomName name, IEnumerable<TerminalRule> rules)
            : base(name)
        {
            Rules = rules.ToArray();
        }

        public IReadOnlyList<TerminalRule> Rules { get; }
    }
}
