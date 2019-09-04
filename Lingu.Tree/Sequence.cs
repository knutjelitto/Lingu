﻿using Lingu.Automata;
using Lingu.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Lingu.Tree
{
    public class Sequence : Expression
    {
        public Sequence(IEnumerable<Expression> expressions)
        {
            Expressions = expressions.ToArray();
        }

        public IReadOnlyList<Expression> Expressions { get; }

        public override FA GetNfa()
        {
            var nfa = Expressions.First().GetNfa();
            foreach (var expr in Expressions.Skip(1))
            {
                nfa = nfa.Concat(expr.GetNfa());
            }
            return nfa;
        }

        public override void Dump(Indentable output, bool top)
        {
            if (!top) output.Write("(");
            var more = false;
            foreach (var expression in Expressions)
            {
                if (more)
                {
                    output.Write(" ");
                }
                expression.Dump(output, false);
                more = true;
            }
            if (!top) output.Write(")");
        }
    }
}