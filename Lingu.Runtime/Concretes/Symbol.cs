using System;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class Symbol : ISymbol
    {
        public Symbol(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
