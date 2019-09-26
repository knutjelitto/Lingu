using System.Collections.Generic;
using System.Linq;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class RepeatToken : Token, IRepeatToken
    {
        private List<IToken> children;
        public RepeatToken(RepeatSymbol repeat, params IToken[] tokens)
            : base(repeat)
        {
            children = new List<IToken>(tokens);
        }

        public INonterminal Nonterminal => (INonterminal)Symbol;

        public IReadOnlyList<IToken> Children => children;

        public void Add(IToken token)
        {
            children.Add(token);
        }
    }
}
