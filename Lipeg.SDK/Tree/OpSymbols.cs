using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public static class OpSymbols
    {
        public const string Choice = "||";
        public const string Sequence = "&&";

        public const string Any = ".";
        public const string Option = "?";
        public const string Star = "*";
        public const string Plus = "+";
        public const string And = "&";
        public const string Not = "!";
        public const string Lift = "^";
        public const string Drop = ",";
        public const string Fuse = "~";

        public const string Spacing = "␣";

#pragma warning disable CA1720 // Identifier contains type name
        public const string CharSequence = "string";
#pragma warning restore CA1720 // Identifier contains type name
        public const string ClassChar = "char";
        public const string ClassRange = "range";

        public const string Ref = "ref";

        public const string DefPlain = "<=";

        public const string Opt = "opt";
        public const string Opts = "opts";
        public const string Syntax = "rules";
        public const string Lexical = "lexical";
    }
}
