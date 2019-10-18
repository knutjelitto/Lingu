namespace Lingu.CC
{
    using System;
    using System.Diagnostics;
    using Lingu.Runtime.Structures;
    
    public abstract class AbstractUcdVisitor<T> where T : class
    {
        protected abstract T OnWhitespace(ITerminalToken token);
        protected abstract T OnStart(INonterminalToken token);
        
        protected TAst Visit<TAst>(IToken token) where TAst : T
        {
            Debug.Assert(token != null);
            return token.Symbol.Id switch
            {
                UcdId.Whitespace => (TAst)OnWhitespace((ITerminalToken)token),
                UcdId.Start => (TAst)OnStart((INonterminalToken)token),
                
                _ => throw new NotImplementedException(),
            };
        }
        
        protected abstract T DefaultOn(IToken token);
    }
    
    public abstract class UcdVisitor<T> : AbstractUcdVisitor<T> where T : class
    {
        protected override T OnWhitespace(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnStart(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
    }
    
    public static class UcdId
    {
        public const int Whitespace = 0;
        public const int Start = 2;
    }
}
