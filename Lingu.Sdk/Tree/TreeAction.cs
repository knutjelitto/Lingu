using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Commons;

namespace Lingu.Tree
{
    public class TreeAction : Expression
    {
        public enum TreeActionX
        {
            Drop,
            Promote
        }

        public TreeAction(Expression expression, TreeActionX action)
        {
            Expression = expression;
            Action = action;
        }

        public Expression Expression { get; }
        public override IEnumerable<Expression> Children => Enumerable.Repeat(Expression, 1);

        public TreeActionX Action { get; }

        public override FA GetFA()
        {
            return Expression.GetFA();
        }

        public override void Dump(IWriter output, bool top)
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