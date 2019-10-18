namespace Lingu.CC
{
    using System;
    using System.Diagnostics;
    using Lingu.Runtime.Structures;
    
    public abstract class AbstractWikiVisitor<T> where T : class
    {
        protected abstract T OnWs(ITerminalToken token);
        protected abstract T OnStart(INonterminalToken token);
        
        protected TAst Visit<TAst>(IToken token) where TAst : T
        {
            Debug.Assert(token != null);
            return token.Symbol.Id switch
            {
                WikiId.Ws => (TAst)OnWs((ITerminalToken)token),
                WikiId.Start => (TAst)OnStart((INonterminalToken)token),
                
                _ => throw new NotImplementedException(),
            };
        }
        
        protected abstract T DefaultOn(IToken token);
    }
    
    public abstract class WikiVisitor<T> : AbstractWikiVisitor<T> where T : class
    {
        protected override T OnWs(ITerminalToken token)
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
    
    public static class WikiId
    {
        public const int Ws = 0;
        public const int Start = 2;
    }
}
