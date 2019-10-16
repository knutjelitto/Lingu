namespace Lingu.CC
{
    using System;
    using System.Diagnostics;
    using Lingu.Runtime.Structures;
    
    public abstract class AbstractExprVisitor<T> where T : class
    {
        protected abstract T OnId(ITerminalToken token);
        protected abstract T OnNum(ITerminalToken token);
        protected abstract T OnAdd(INonterminalToken token);
        protected abstract T OnSub(INonterminalToken token);
        protected abstract T OnMul(INonterminalToken token);
        protected abstract T OnDiv(INonterminalToken token);
        
        protected TAst Visit<TAst>(IToken token) where TAst : T
        {
            Debug.Assert(token != null);
            return token.Symbol.Id switch
            {
                ExprId.Id => (TAst)OnId((ITerminalToken)token),
                ExprId.Num => (TAst)OnNum((ITerminalToken)token),
                ExprId.Add => (TAst)OnAdd((INonterminalToken)token),
                ExprId.Sub => (TAst)OnSub((INonterminalToken)token),
                ExprId.Mul => (TAst)OnMul((INonterminalToken)token),
                ExprId.Div => (TAst)OnDiv((INonterminalToken)token),
                
                _ => throw new NotImplementedException(),
            };
        }
        
        protected abstract T DefaultOn(IToken token);
    }
    
    public abstract class ExprVisitor<T> : AbstractExprVisitor<T> where T : class
    {
        protected override T OnId(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnNum(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnAdd(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnSub(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnMul(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnDiv(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
    }
    
    public static class ExprId
    {
        public const int Id = 0;
        public const int Num = 1;
        public const int Add = 11;
        public const int Sub = 12;
        public const int Mul = 13;
        public const int Div = 14;
    }
}
