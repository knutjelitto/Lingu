using System;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Lexing
{
    public class Lexer : ILexer
    {
        public Lexer(IContext context, ISource source)
        {
            Context = context;
            Source = source;
        }

        public IContext Context { get; }
        public ISource Source { get; }
        public Dfa Whitespace => Context.Whitespace;

        int index = 0;

        public IConlex First()
        {
            index = 0;

            SkipWhitespace();

            throw new NotImplementedException();
        }

        public IConlex Next(IConlex context)
        {
            throw new NotImplementedException();
        }

        private void SkipWhitespace()
        {
            DfaState? state = Whitespace.Start;
            while (!Source.IsEnd(index) && (state = state.Match(Source[index])) != null)
            {
                index += 1;
            }
        }

        private class Conlex : IConlex
        {
            public Conlex(ITerminalToken token)
            {
                Token = token;
            }

            public ITerminalToken Token { get; }
        }
    }
}
