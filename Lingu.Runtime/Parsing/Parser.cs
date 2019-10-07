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
            IConlex? context = Lexer.First(stack.StateId);
            while (context != null)
            {
                var action = Decode(context.Token.Terminal.Id);

                switch (action.Action)
                {
                    case TableItem.Error:
                        HandleError(context.Token);
                        context = null;
                        break;
                    case TableItem.Shift:
                        Shift(action.Number);
                        break;
                    case TableItem.Reduce:
                        Reduce(action.Number);
                        break;
                    case TableItem.Accept:
                        Debug.Assert(Lexer.IsEnd());
                        context = null;
                        break;
                }
            }

            return (INonterminalToken)stack.Pop().Token;

            void HandleError(ITerminalToken token)
            {
                var msg = Errors.GetExpectedMessage(token.Location, Errors.GetSymbols(stack.StateId));
                throw new ParserException(msg);
            }

            void Shift(int stateId)
            {
                Debug.Assert(context != null);
                stack.Push(new StackItem(context.Token, stateId));

                context = Lexer.Next(context, stack.StateId);
            }

            void Reduce(int productionId)
            {
                var production = Context.Productions[productionId];
                var nonterminal = production.Nonterminal;

                IToken token;

                var rhs = production.DropFilter(stack.Pop(production.Length)).ToArray();

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

                if (action.Action != TableItem.Shift)
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
