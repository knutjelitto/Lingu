using Lingu.Automata;
using Lingu.Grammars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lingu.Tree
{
    public class Ref : Node, IExpression
    {
        public Ref(Name name)
        {
            Name = name;
        }

        public Name Name { get; }

        public Rule Rule { get; set; }

        public IEnumerable<IExpression> Children => Enumerable.Empty<IExpression>();

        public FA GetFA()
        {
            throw new NotImplementedException();
        }
    }
}
