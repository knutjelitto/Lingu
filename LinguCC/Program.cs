using System;

namespace Lingu.CC
{
    public sealed class Program
    {
        static void Main(/*string[] args*/)
        {
            new Ucds.Ucd().Build("Ucd");
            new Ucds.Ucd().Build("UcdBlocks");
            new Ucds.Ucd().Build("UcdScripts");

            Console.Write("press (almost) any key ... ");
            Console.ReadKey(true);
        }
    }
}
