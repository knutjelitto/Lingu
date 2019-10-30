using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public abstract class Expr : Expression
    {
        public static Expr From(int value)
        {
            return new IntegerExpr(value);
        }

        public static Expr From(Identifier identifier)
        {
            return new IdentifierExpr(identifier);
        }

        public static Expr From(Identifier identifier, IList<Expr> arguments)
        {
            return new CallExpr(identifier, arguments);
        }

        protected class IntegerExpr : Expr
        {
            public IntegerExpr(int value)
            {
                Value = value;
            }
            public int Value { get; }
        }

        protected class IdentifierExpr : Expr
        {
            public IdentifierExpr(Identifier identifier)
            {
                Identifier = identifier;
            }
            public Identifier Identifier { get; }
        }

        protected class CallExpr : Expr
        {
            public CallExpr(Identifier identifier, IList<Expr> arguments)
            {
                Identifier = identifier;
                Arguments = arguments;
            }
            public Identifier Identifier { get; }
            public IList<Expr> Arguments { get; }
        }
    }
}
