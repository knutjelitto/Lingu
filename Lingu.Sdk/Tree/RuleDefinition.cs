using System;
using System.Collections.Generic;
using System.Text;

namespace Lingu.Sdk.Tree
{
    public sealed class RuleDefinition : Definition
    {
        public RuleDefinition(bool generated, AtomName name, Expression expression)
            : base(generated, name, expression)
        {
        }

        public RuleDefinition(AtomName name, Expression expression)
            : base(false, name, expression)
        {
        }
    }
}
