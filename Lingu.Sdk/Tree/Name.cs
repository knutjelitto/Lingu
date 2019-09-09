using System;

using Lingu.Commons;
using Lingu.Grammars;

namespace Lingu.Tree
{
    public class Name : Symbol, IDumpable
    {
        public static readonly Name Empty = new Name(string.Empty);

        public Name(string name)
            : base(name)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Name other && Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode(); ;
        }

        public override string ToString()
        {
            return Name;
        }

        public override void Dump(IWriter output, bool top)
        {
            output.Write(ToString());
        }
    }
}
