using Hime.Redist;
using Mean.Language.Generated;
using Mean.Maker.Builders;
using System.IO;

namespace Mean.Language
{
    public class Parser
    {
        public static ParseResult Expression(string source)
        {
            var lexer = new MeanExpressionLexer(source);
            var parser = new MeanExpressionParser(lexer);

            var result = parser.Parse();

            return result;
        }

        public static ParseResult Unit(FileRef file)
        {
            return Unit(File.ReadAllText(file));
        }

        public static ParseResult Unit(string source)
        {
            var lexer = new MeanLexer(source);
            var parser = new MeanParser(lexer);

            var result = parser.Parse();

            return result;
        }
    }
}
