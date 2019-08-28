using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Hime.Redist;

using Mean.Language.Generated;

namespace Mean.Tree
{
    public class BaseBuilder : MeanVisitor
    {
        protected Identifier Identifier(ASTNode node)
        {
            return new Identifier(node.Children[0].Value);
        }
    }
}
