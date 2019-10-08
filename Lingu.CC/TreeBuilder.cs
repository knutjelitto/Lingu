using System;

using Lingu.Runtime.Structures;
using Lingu.Tree;

namespace Lingu.CC
{
    public class TreeBuilder : LinguVisitor.Visitor<object>
    {
        protected override W Default<W>(IToken token)
        {
            throw new NotImplementedException();
        }

        public Node Visit(INonterminalToken root)
        {
            return Visit<Node>(root);
        }

        public override W OnFile<W>(INonterminalToken token)
        {
            throw new NotImplementedException();
        }
    }
}
