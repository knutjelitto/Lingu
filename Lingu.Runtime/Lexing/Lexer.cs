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
            index = 0;
        }

        public IContext Context { get; }
        public ISource Source { get; }
        public IErrorHandler Errors => Context.Errors;

        private int index = 0;

        public ITerminalToken Next(int stateId)
        {
            return Action(stateId);
        }

        public bool IsEnd()
        {
            return Source.IsEnd(index);
        }

        public ITerminalToken Action(int stateId)
        {
            SkipWhitespace();

            var token = LexCommon(Context.Dfas[stateId]);

            Debug.Assert(token != null);

            return token;
        }

        private ITerminalToken? LexCommon(Dfa dfa)
        {
            DfaState? state = dfa.Start;
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

                    var msg = Errors.GetExpectedMessage(Location.From(Source, index), Errors.GetSymbols(dfa).ToArray());
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
            var location = Location.From(Source, start, end);

            return new TerminalToken(terminal, location);
        }

        private void SkipWhitespace()
        {
            DfaState? state = Context.Dfas.Spacing.Start;
            while (!Source.IsEnd(index) && (state = state.Match(Source[index])) != null)
            {
                index += 1;
            }
        }
    }
}
