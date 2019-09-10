using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class TreeAction : IExpression
    {
        public enum TreeActionX
        {
            Drop,
            Promote
        }

        public TreeAction(IExpression expression, TreeActionX action)
        {
            Expression = expression;
            Action = action;
        }

        public IExpression Expression { get; }

        public TreeActionX Action { get; }

        public IEnumerable<IExpression> Children => Enumerable.Repeat(Expression, 1);

        public FA GetFA()
        {
            return Expression.GetFA();
        }

        public void Dump(IWriter output, bool top)
        {
            Expression.Dump(output, top);
            switch (Action)
            {
                case TreeActionX.Drop:
                    output.Write("!");
                    break;
                case TreeActionX.Promote:
                    output.Write("^");
                    break;
            }
        }
    }
}