using LinParse.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinParse.Json
{
    public class JsonLexer : Lexer
    {
        public JsonLexer(Source source)
            : base(source)
        { }

        public override bool CanSkip()
        {
            return 
                content[Current] == '\t' ||
                content[Current] == '\n' ||
                content[Current] == '\r' ||
                content[Current] == ' ';
        }
    }
}
