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
        public TreeActionX Action { get; }

        public override Nfa GetNfa()
        {
            return Expression.GetNfa();
        }

        public override void Dump(Indentable output, bool top)
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