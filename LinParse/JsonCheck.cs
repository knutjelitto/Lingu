using LinParse.Common;
using Lipeg.Runtime.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse
{
    public static class JsonCheck
    {
        public enum Outcome
        {
            Succeed,
            Fail,
            Indifferent,
        }

        public static bool Run(FileRef file, Outcome outcome)
        {
            var source = new Source(file.FileName, file.GetContent());
            var lexer = new Json.JsonLexer(source);
            var parser = new Json.JsonParser(lexer);

            var x = parser.Parse();

            switch (outcome)
            {
                case Outcome.Succeed:
                    return x != null && parser.Error == null;
                case Outcome.Fail:
                    return x == null && parser.Error != null;
                default:
                    return true;
            }
        }
    }
}
