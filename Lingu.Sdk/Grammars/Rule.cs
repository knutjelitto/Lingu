using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Commons;

namespace Lingu.Grammars
{
    public abstract class Rule : Symbol
    {
        public Rule(string name)
            : base(name)
        {
            Id = -1;
        }

        public int Id { get; set;  }
        public bool IsGenerated { get; set; }
        public int UseCount { get; private set; }
        public void Use()
        {
            UseCount += 1;
        }
    }
}
