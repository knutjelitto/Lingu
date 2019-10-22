namespace Lipeg.Boot
{
    public class Parser : IParser
    {
        private Parser(ILexer lexer)
        {
            Lexer = lexer;
        }

        public ILexer Lexer { get; }

        public static IParser From(ILexer lexer)
        {
            return new Parser(lexer);
        }

        public void Parse()
        {
            Skip();
            if (Lexer.Match("grammar"))
            {
                Skip();
                Identifier();
            }
        }

        private void Skip()
        {
            Lexer.Skip(c => char.IsWhiteSpace(c));
        }

        private string Identifier()
        {
            var id = string.Empty;
            if (Lexer.Is(char.IsLetter))
            {
                id += Lexer.Match();
                while (Lexer.Is(char.IsLetterOrDigit))
                {
                    id += Lexer.Match();
                }
            }

            return id;
        }
    }
}
