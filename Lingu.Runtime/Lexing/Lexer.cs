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

            var indexTmp = index;
            var terminalId = LexCommon();
            if (terminalId == -1)
            {
                index = indexTmp;
                terminalId = LexCommon();
            }


            var terminal = Context.Symbols[terminalId] as ITerminal;

            Debug.Assert(terminal != null);

            return new Conlex(new TerminalToken(terminal));
        }

        private int LexCommon()
        {
            DfaState? state = Context.Common.Start;
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

            if (state != null && state.IsFinal)
            {
                return state.Payload;
            }

            return -1;
        }

        private void SkipWhitespace()
        {
            DfaState? state = Context.Whitespace.Start;
            while (!Source.IsEnd(index) && (state = state.Match(Source[index])) != null)
            {
                index += 1;
            }
        }
    }
}
