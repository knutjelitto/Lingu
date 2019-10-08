using System;
using System.Collections.Generic;
using System.Text;
using Lingu.Runtime.Structures;
using Lingu.Tree;

namespace Lingu.CC
{
    public class TreeBuilder : LinguVisitor.Visitor<Node>
    {
        protected override W Default<W>(IToken token)
        {
            throw new NotImplementedException();
        }

        public override W OnAngrammar<W>(INonterminalToken token)
        {
            return base.OnAngrammar<W>(token);
        }
    }
}
