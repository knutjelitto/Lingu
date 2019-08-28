using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Hime.Redist;
using Lingu.Bootstrap.Tree;
using Mean.Maker.Builders;

namespace Lingu.Bootstrap
{
    public class Parser
    {
        public static ParseResult Grammar(string source)
        {
            var lexer = new LinguLexer(source);
            var parser = new LinguParser(lexer);

            var result = parser.Parse();

            return result;
        }

        public static Grammar Tree(ASTNode node)
        {
            return new TreeBuilder().Visit(node);
        }

        public static Grammar Parse(FileRef file)
        {
            var source = File.ReadAllText(file);

            var result = Grammar(source);

            foreach (var error in result.Errors)
            {
                Console.WriteLine($"{error}");
            }

            if (result.IsSuccess)
            {
                return Tree(result.Root);
            }

            return null;
        }
    }
}
