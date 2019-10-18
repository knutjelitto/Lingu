using System;

namespace Lingu.CC
{
    public sealed class Program
    {
        static void Main(/*string[] args*/)
        {
            new Ucds.Ucd().Build();

            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
