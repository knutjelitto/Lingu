using System;
using System.Collections.Generic;
using System.Text;

using Mean.Maker.Builders;

namespace Lingu.Bootstrap.Generate
{
    public class HimeRunner : Runner
    {
        public string Hime { get; } = @"D:/Projects/Support/Compilers/Hime/net461";

        public Capture Clang(string description, string arguments)
        {
            return Run(description, $"{Hime}/himecc.exe", arguments);
        }

        public Capture Any(string description, string program, string arguments)
        {
            return Run(description, program, arguments);
        }
    }
}
