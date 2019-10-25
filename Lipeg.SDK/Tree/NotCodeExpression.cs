﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class NotCodeExpression : Expression
    {
        private NotCodeExpression(CodeSpan code)
        {
            Code = code;
        }
        public CodeSpan Code { get; }

        public static NotCodeExpression From(CodeSpan code)
        {
            return new NotCodeExpression(code);
        }
    }
}