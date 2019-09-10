using Lingu.Commons;
using Lingu.Tree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lingu.Grammars
{
    public class Nonterminals : UniqueList<Symbol, Nonterminal>
    {
        public Nonterminals()
            : base(nonterminal => nonterminal)
        {
        }

        public override int Add(Nonterminal value)
        {
            if (TryGetValue(value, out var found) && found is TreeNonterminal already)
            {
                var newExpression = ((TreeNonterminal)value).Expression;
                var oldExpression = already.Expression;

                if (oldExpression is Alternates oAlt)
                {
                    if (newExpression is Alternates nAlt)
                    {
                        oAlt.Combine(nAlt.Expressions);
                    }
                    else
                    {
                        oAlt.Combine(newExpression);
                    }
                }
                else
                {
                    if (newExpression is Alternates nAlt)
                    {
                        oAlt = new Alternates(Enumerable.Repeat(oldExpression, 1).Concat(nAlt.Expressions));
                    }
                    else
                    {
                        oAlt = new Alternates(Enumerable.Repeat(oldExpression, 1).Concat(Enumerable.Repeat(newExpression, 1)));
                    }
                    already.Expression = oAlt;
                }

                return already.Id;
            }

            return base.Add(value);
        }
    }
}
