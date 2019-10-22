using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.Tree
{
    public class CodeExpression : Expression
    {
        private CodeExpression(CodeSpan codeSpan, CodeType codeType)
        {
            CodeSpan = codeSpan;
            CodeType = codeType;
        }
        public CodeSpan CodeSpan { get; }
        public CodeType CodeType { get; }

        public static CodeExpression From(CodeSpan codeSpan, CodeType codeType)
        {
            return new CodeExpression(codeSpan, codeType);
        }
    }
}
