using System;
using System.Collections.Generic;
using System.Diagnostics;
using Hime.Redist;
using Mean.Language.Generated;
using Mean.Tree.Items;

namespace Mean.Tree
{
    public class UnitBuilder : BaseBuilder
    {
        public UnitBuilder(Global global)
        {
            Global = global;
        }

        private Global Global { get; }

        public Unit Visit(ParseResult tree)
        {
            return VisitNode<Unit>(tree.Root);
        }

        public override object OnVariableUnit(ASTNode node)
        {
            return new Unit(Global, VisitChildren<IdItem>(node));
        }

        public override object OnVariableNamespace(ASTNode node)
        {
            Debug.Assert(node.Children.Count == 2);
            return new Namespace(Identifier(node.Children[0]), VisitChildren<IdItem>(node.Children[1]));
        }

        public override object OnVariableTrait(ASTNode node)
        {
            Debug.Assert(node.Children.Count == 4);
            var id = Identifier(node.Children[0]);
            var generics = VisitNode<Generics>(node.Children[1]);
            var where = VisitNode<Where>(node.Children[2]);
            return base.OnVariableTrait(node);
        }

        public override Object OnVariableMaybeWhere(ASTNode node)
        {
            return base.OnVariableMaybeWhere(node);
        }

        public override Object OnVariableWhere(ASTNode node)
        {
            return base.OnVariableWhere(node);
        }

        public override object OnVariableTraitOutputType(ASTNode node)
        {
            return base.OnVariableTraitOutputType(node);
        }
    }
}
