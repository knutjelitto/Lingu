using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public static class OpSymbols
    {
        public const string Sequence = "[sequence]";
        public const string Choice = "[choice]";

        public const string Any = ".";
        public const string Option = "?";
        public const string Star = "*";
        public const string Plus = "+";
        public const string And = "&";
        public const string Not = "!";
        public const string Lift = "^";
        public const string Drop = ",";
        public const string Fuse = "~";

        public const string Options = "options";
        public const string Syntax = "rules";
        public const string Lexical = "lexical";
    }
}
