namespace Lingu.CC
{
    using System;
    using System.Diagnostics;
    using Lingu.Runtime.Structures;
    
    public abstract class AbstractUcdBlocksVisitor<T> where T : class
    {
        protected abstract T OnNl(ITerminalToken token);
        protected abstract T OnNonl(ITerminalToken token);
        protected abstract T OnWs(ITerminalToken token);
        protected abstract T OnBegin(ITerminalToken token);
        protected abstract T OnEnd(ITerminalToken token);
        protected abstract T OnId(ITerminalToken token);
        protected abstract T OnStart(INonterminalToken token);
        protected abstract T OnMissing(INonterminalToken token);
        protected abstract T OnComment(INonterminalToken token);
        protected abstract T OnEmpty(INonterminalToken token);
        protected abstract T OnRange(INonterminalToken token);
        protected abstract T OnData(INonterminalToken token);
        
        protected TAst Visit<TAst>(IToken token) where TAst : T
        {
            Debug.Assert(token != null);
            return token.Symbol.Id switch
            {
                UcdBlocksId.Nl => (TAst)OnNl((ITerminalToken)token),
                UcdBlocksId.Nonl => (TAst)OnNonl((ITerminalToken)token),
                UcdBlocksId.Ws => (TAst)OnWs((ITerminalToken)token),
                UcdBlocksId.Begin => (TAst)OnBegin((ITerminalToken)token),
                UcdBlocksId.End => (TAst)OnEnd((ITerminalToken)token),
                UcdBlocksId.Id => (TAst)OnId((ITerminalToken)token),
                UcdBlocksId.Start => (TAst)OnStart((INonterminalToken)token),
                UcdBlocksId.Missing => (TAst)OnMissing((INonterminalToken)token),
                UcdBlocksId.Comment => (TAst)OnComment((INonterminalToken)token),
                UcdBlocksId.Empty => (TAst)OnEmpty((INonterminalToken)token),
                UcdBlocksId.Range => (TAst)OnRange((INonterminalToken)token),
                UcdBlocksId.Data => (TAst)OnData((INonterminalToken)token),
                
                _ => throw new NotImplementedException(),
            };
        }
        
        protected abstract T DefaultOn(IToken token);
    }
    
    public abstract class UcdBlocksVisitor<T> : AbstractUcdBlocksVisitor<T> where T : class
    {
        protected override T OnNl(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnNonl(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnWs(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnBegin(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnEnd(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnId(ITerminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnStart(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnMissing(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnComment(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnEmpty(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnRange(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
        protected override T OnData(INonterminalToken token)
        {
            Debug.Assert(token != null);
            return DefaultOn(token);
        }
    }
    
    public static class UcdBlocksId
    {
        public const int Nl = 0;
        public const int Nonl = 1;
        public const int Ws = 2;
        public const int Begin = 3;
        public const int End = 4;
        public const int Id = 5;
        public const int Start = 11;
        public const int Missing = 13;
        public const int Comment = 14;
        public const int Empty = 15;
        public const int Range = 16;
        public const int Data = 17;
    }
}
