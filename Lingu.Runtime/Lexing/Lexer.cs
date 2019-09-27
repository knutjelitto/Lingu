using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Lingu.Runtime.Concretes;
using Lingu.Runtime.Errors;
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
        public IErrorHandler Errors => Context.Errors;


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

            var token = LexCommon();

            Debug.Assert(token != null);

            return new Conlex(token);
        }

        private ITerminalToken? LexCommon()
        {
            DfaState? state = Context.Common.Start;
            var start = index;
            while (!Source.IsEnd(index))
            {
                Debug.Assert(state != null);
                var next = state.Match(Source[index]);
                if (next == null)
                {
                    if (state.Final)
                    {
                        return MakeResult(state.Payload, start, index);
                    }

                    var msg = Errors.GetExpectedMessage(Location.From(Source, index), Errors.GetSymbols(Context.Common));
                    throw new ParserException(msg);
                }
                state = next;
                index += 1;
            }

            if (state != null && state.Final)
            {
                return MakeResult(state.Payload, start, index);
            }

            return null;
        }

        private ITerminalToken MakeResult(int terminalId, int start, int end)
        {
            var terminal = (ITerminal)Context.Symbols[terminalId];
            var location = new Location(Source, start, end);

            return new TerminalToken(terminal, location);
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
