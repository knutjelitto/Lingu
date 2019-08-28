using System;
using System.Diagnostics;
using System.Text;

namespace Mean.Maker.Builders
{
    public class ObjConvRunner : Runner
    {
        public string Root { get; } = @"D:/Compilers/ObjConv";

        public Capture ObjConv(string description, string arguments)
        {
            return Run(description, $@"{Root}/objconv.exe", arguments);
        }
    }
}
