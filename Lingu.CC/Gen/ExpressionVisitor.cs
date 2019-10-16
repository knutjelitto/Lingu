namespace Lingu.CC
{
    using System;
    using System.Diagnostics;
    using Lingu.Runtime.Structures;
    
    public abstract class AbstractExpressionVisitor<T> where T : class
    {
        protected abstract T OnIdentifier(ITerminalToken token);
        protected abstract T OnNumber(ITerminalToken token);
        protected abstract T OnPath(INonterminalToken token);
        protected abstract T OnIdentifierWithArguments(INonterminalToken token);
        protected abstract T OnTypeArguments(INonterminalToken token);
        protected abstract T OnShlOp(INonterminalToken token);
        protected abstract T OnShrOp(INonterminalToken token);
        protected abstract T OnAddOp(INonterminalToken token);
        protected abstract T OnSubOp(INonterminalToken token);
        protected abstract T OnMulOp(INonterminalToken token);
        protected abstract T OnDivOp(INonterminalToken token);
        protected abstract T OnRemOp(INonterminalToken token);
        protected abstract T OnModOp(INonterminalToken token);
        protected abstract T OnNegOp(INonterminalToken token);
        
        protected TAst Visit<TAst>(IToken token) where TAst : T
        {
            Debug.Assert(token != null);
            return token.Symbol.Id switch
            {
                ExpressionId.Identifier => (TAst)OnIdentifier((ITerminalToken)token),
                ExpressionId.Number => (TAst)OnNumber((ITerminalToken)token),
                ExpressionId.Path => (TAst)OnPath((INonterminalToken)token),
                ExpressionId.IdentifierWithArguments => (TAst)OnIdentifierWithArguments((INonterminalToken)token),
                ExpressionId.TypeArguments => (TAst)OnTypeArguments((INonterminalToken)token),
                ExpressionId.ShlOp => (TAst)OnShlOp((INonterminalToken)token),
                ExpressionId.ShrOp => (TAst)OnShrOp((INonterminalToken)token),
                ExpressionId.AddOp => (TAst)OnAddOp((INonterminalToken)token),
                ExpressionId.SubOp => (TAst)OnSubOp((INonterminalToken)token),
                ExpressionId.MulOp => (TAst)OnMulOp((INonterminalToken)token),
                ExpressionId.DivOp => (TAst)OnDivOp((INonterminalToken)token),
                ExpressionId.RemOp => (TAst)OnRemOp((INonterminalToken)token),
                ExpressionId.ModOp => (TAst)OnModOp((INonterminalToken)token),
                ExpressionId.NegOp => (TAst)OnNegOp((INonterminalToken)token),
                
                _ => throw new NotImplementedException(),
            };
        }
        
        protected abstract T DefaultOn(IToken token);
    }
    
    public abstract class ExpressionVisitor<T> : AbstractExpressionVisitor<T> where T : class
    {
        protected override T OnIdentifier(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnNumber(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnPath(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnIdentifierWithArguments(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnTypeArguments(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnShlOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnShrOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnAddOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnSubOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnMulOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnDivOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRemOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnModOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnNegOp(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
    }
    
    public static class ExpressionId
    {
        public const int Identifier = 0;
        public const int Number = 1;
        public const int Path = 20;
        public const int IdentifierWithArguments = 22;
        public const int TypeArguments = 23;
        public const int ShlOp = 25;
        public const int ShrOp = 26;
        public const int AddOp = 27;
        public const int SubOp = 28;
        public const int MulOp = 29;
        public const int DivOp = 30;
        public const int RemOp = 31;
        public const int ModOp = 32;
        public const int NegOp = 33;
    }
}
