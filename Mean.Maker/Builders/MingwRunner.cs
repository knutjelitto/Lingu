using System;
using System.Diagnostics;
using System.Text;

namespace Mean.Maker.Builders
{
    internal class MingwRunner : Runner
    {
        public string MinGW { get; } = @"D:/Compilers/MinGW64";
        public string Bin => MinGW + @"/Bin";
        public string Lib => MinGW + @"/Lib";
        public string Include => MinGW + @"/Include";

        public Capture GCC(string description, string arguments)
        {
            return Run(description, $"{Bin}/gcc.exe", arguments);
        }

        public Capture Any(string description, string program, string arguments)
        {
            return Run(description, program, arguments);
        }
    }
}
