using System;

using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Concretes
{
    public class Symbol : ISymbol
    {
        public Symbol(int id, string name, bool visible)
        {
            Id = id;
            Name = name;
            Visible = visible;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Visible { get; }
    }
}
