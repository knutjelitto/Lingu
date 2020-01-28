﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinParseTests.Builders
{
    internal class LlvmRunner : Runner
    {
        public string Llvm { get; } = @"D:/Compilers/LLVM";
        public string Bin => Llvm + @"/Bin";
        public string Lib => Llvm + @"/Lib";
        public string Include => Llvm + @"/Include";

        public Capture Clang(string description, string arguments)
        {
            return Run(description, $"{Bin}/clang.exe", arguments);
        }

        public Capture Any(string description, string program, string arguments)
        {
            return Run(description, program, arguments);
        }
    }
}
