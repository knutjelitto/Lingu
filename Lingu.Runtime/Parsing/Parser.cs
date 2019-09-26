using System.Collections.Generic;
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

        private readonly ParseStack stack;

        public INonterminalToken Parse()
        {
            var context = Lexer.First();
            while (context != null)
            {
                var (action, number) = Decode(context.Token.Terminal.Id);

                switch (action)
                {
                    case TableItem.Error:
                        var msg = $"expected: {FmtExpected()}";
                        throw new ParserException(msg);
                    case TableItem.Shift:
                        Shift(number);
                        break;
                    case TableItem.Reduce:
                        Reduce(number);
                        break;
                    case TableItem.Accept:
                        Debug.Assert(Lexer.IsEnd());
                        context = null;
                        break;
                }
            }

            return (INonterminalToken)stack.Pop().Token;

            void Shift(int stateId)
            {
                stack.Push(new StackItem(context.Token, stateId));

                context = Lexer.Next(context);
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
                    case RepeatKind.None:
                        if (nonterminal.Lift ==  LiftKind.Lift)
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

                var (action, number) = Decode(nonterminal.Id);

                if (action != TableItem.Shift)
                {
                    throw new ParserException();
                }

                stack.Push(new StackItem(token, number));
            }
        }

        private (TableItem action, int number) Decode(int id)
        {
            var rawaction = Context.Table[stack.State, id];

            var action = (rawaction & TableItem.ActionBits);
            var number = (int)rawaction >> 2;

            return (action, number);
        }

        private string FmtExpected()
        {
            return string.Join(", ", GetExpected());
        }

        private IEnumerable<string> GetExpected()
        {
            for (var symId = 0; symId < Context.Table.NumberOfTerminals; ++symId)
            {
                var (action, _) = Decode(symId);

                if (action == TableItem.Shift)
                {
                    yield return Context.Symbols[symId].ToString() ?? throw new InternalException();
                }
            }
        }
    }
}
