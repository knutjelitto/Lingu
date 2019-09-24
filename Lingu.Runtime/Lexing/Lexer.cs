using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lingu.Runtime.Concretes;
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

        public IReadOnlyList<ISymbol> Symbols => Context.Symbols;
        public Dfa Whitespace => Context.Whitespace;
        public Dfa Common => Context.Common;

        int index = 0;

        public IConlex First()
        {
            index = 0;

            return Action();
        }

        public IConlex Next(IConlex context)
        {
            return Action();
        }

        public bool IsEnd()
        {
            return Source.IsEnd(index);
        }

        public IConlex Action()
        {
            SkipWhitespace();

            var terminalId = LexCommon();

            var terminal = Symbols[terminalId] as ITerminal;

            Debug.Assert(terminal != null);

            return new Conlex(new TerminalToken(terminal));
        }

        private int LexCommon()
        {
            DfaState? state = Common.Start;
            while (!Source.IsEnd(index))
            {
                var next = state.Match(Source[index]);
                if (next == null)
                {
                    return state.Payload;
                }
                state = next;
                index += 1;
            }

            if (state != null)
            {
                return state.Payload;
            }

            return -1;
        }

        private void SkipWhitespace()
        {
            DfaState? state = Whitespace.Start;
            while (!Source.IsEnd(index) && (state = state.Match(Source[index])) != null)
            {
                index += 1;
            }
        }
    }
}
