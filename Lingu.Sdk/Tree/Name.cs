using System;
using System.Collections.Generic;
using System.Linq;

using Lingu.Automata;
using Lingu.Grammars;
using Lingu.Writers;

namespace Lingu.Tree
{
    public class Name : Node, IExpression
    {
        public static readonly Name Empty = new Name(string.Empty);

        public Name(string name)
        {
            Text = name;
        }

        public Terminal Rule { get; set; }

        public IEnumerable<IExpression> Children => Enumerable.Empty<IExpression>();

        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }

        public override void Dump(IndentWriter output)
        {
            output.Write(ToString());
        }

        public FA GetFA()
        {
            return Rule.Raw.Expression.GetFA();
        }
    }
}
