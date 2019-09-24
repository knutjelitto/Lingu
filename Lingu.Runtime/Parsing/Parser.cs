﻿using System;
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
        }

        public IContext Context { get; }
        public ILexer Lexer { get; }

        public INonterminalToken Parse()
        {
            var stack = new ParseStack();
            var table = Context.Table;

            var context = Lexer.First();
            while (context != null)
            {
                var rawaction = table[stack.State, context.Token.Terminal.Id];

                var action = (rawaction & TableItem.Mask);
                var number = (int)rawaction >> 2;

                switch (action)
                {
                    case TableItem.Error:
                        throw new ParserException();
                    case TableItem.Shift:
                        stack.Push(new StackItem(number, context.Token));
                        context = Lexer.Next(context);
                        break;
                    case TableItem.Reduce:
                        {
                            var production = Context.Productions[number];
                            var rhs = stack.Pop(production.Length);
                            var shift = (int)table[stack.State, production.Nonterminal.Id] >> 2;
                            stack.Push(new StackItem(shift, new NonterminalToken(production.Nonterminal, rhs)));
                        }
                        break;
                    case TableItem.Accept:
                        Debug.Assert(Lexer.IsEnd());
                        context = null;
                        break;
                }
            }

            return (INonterminalToken)stack.Pop().Token;
        }
    }
}