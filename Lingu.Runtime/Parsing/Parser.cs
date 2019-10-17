using System.Diagnostics;
using System.Linq;

using Lingu.Runtime.Concretes;
using Lingu.Runtime.Errors;
using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    public class Parser : IParser
    {
        public Parser(IContext context, ILexer lexer)
        {
            Context = context;
            Lexer = lexer;
            stack = new ParseStack();
        }

        public IContext Context { get; }
        public ILexer Lexer { get; }
        public IErrorHandler Errors => Context.Errors;

        private readonly ParseStack stack;

        public INonterminalToken Parse()
        {
            ITerminalToken? token = Lexer.Next(stack.StateId);

            while (token != null)
            {
                var action = Decode(token.Symbol.Id);

                switch (action.Action)
                {
                    case ParseAction.Error:
                        HandleError(token);
                        token = null;
                        break;
                    case ParseAction.Shift:
                        Shift(action.Number);
                        break;
                    case ParseAction.Reduce:
                        Reduce(action.Number);
                        break;
                    case ParseAction.Accept:
                        Debug.Assert(Lexer.IsEnd());
                        token = null;
                        break;
                }
            }

            return (INonterminalToken)stack.Pop().Token;

            void HandleError(ITerminalToken token)
            {
                var msg = Errors.GetExpectedMessage(token.Location, Errors.GetSymbols(stack.StateId).ToArray());
                throw new ParserException(msg);
            }

            void Shift(int stateId)
            {
                Debug.Assert(token != null);
                stack.Push(new StackItem(token, stateId));

                token = Lexer.Next(stack.StateId);
            }

            void Reduce(int productionId)
            {
                var production = Context.Productions[productionId];
                var nonterminal = production.Nonterminal;

                IToken token;

                var popped = stack.Pop(production.Length);

                var rhs = production.DropFilter(popped).ToArray();

                switch (nonterminal.Repeat)
                {
                    case RepeatKind.Star:
                        switch (rhs.Length)
                        {
                            case 0:
                                /* empty part */
                                {
                                    token = new RepeatToken(RepeatSymbol.Star);
                                    break;
                                }
                            case 1:
                                /* core part */
                                {
                                    var item = rhs[0];
                                    token = new RepeatToken(RepeatSymbol.Star, item);
                                    break;
                                }
                            case 2:
                                /* recursive part */
                                {
                                    var item = rhs[1];
                                    var repeat = (RepeatToken)rhs[0];
                                    repeat.Add(item);
                                    token = repeat;
                                    break;
                                }
                            default:
                                throw new InternalException();
                        }
                        break;
                    case RepeatKind.Plus:
                        switch (rhs.Length)
                        {
                            case 1:
                                /* core part */
                                {
                                    var item = rhs[0];
                                    token = new RepeatToken(RepeatSymbol.Plus, item);
                                    break;
                                }
                            case 2:
                                /* recursive part */
                                {
                                    var item = rhs[1];
                                    var repeat = (RepeatToken)rhs[0];
                                    repeat.Add(item);
                                    token = repeat;
                                    break;
                                }
                            default:
                                throw new InternalException();
                        }
                        break;
                    case RepeatKind.Optional:
                        switch (rhs.Length)
                        {
                            case 0:
                                /* empty part */
                                {
                                    token = new RepeatToken(RepeatSymbol.Option);
                                    break;
                                }
                            case 1:
                                /* core part */
                                {
                                    var item = rhs[0];
                                    token = new RepeatToken(RepeatSymbol.Option, item);
                                    break;
                                }
                            default:
                                throw new InternalException();
                        }
                        break;
                    case RepeatKind.None:
                        if (production.IsPromote)
                        {
                            if (rhs.Length != 1)
                            {
                                throw new InternalException();
                            }
                            token = rhs[0];
                        }
                        else
                        {
                            token = new NonterminalToken(nonterminal, rhs);
                        }
                        break;
                    default:
                        throw new InternalException();
                }

                var action = Decode(nonterminal.Id);

                if (action.Action != ParseAction.Shift)
                {
                    throw new ParserException();
                }

                stack.Push(new StackItem(token, action.Number));
            }
        }

        private IStateItem Decode(int symNo)
        {
            return Context.Table[stack.StateId, symNo];
        }
    }
}
