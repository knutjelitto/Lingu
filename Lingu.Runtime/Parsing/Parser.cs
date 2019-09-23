using System;

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
                var action = table[stack.State, context.Token.Terminal.Id];

                context = Lexer.Next(context);
            }

            throw new NotImplementedException();
        }
    }
}
