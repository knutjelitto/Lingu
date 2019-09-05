using System.Diagnostics;
using System.Text;

namespace Lingu.Automata
{
    public class Atom
    {
        private Atom(int first, int last)
            : this(new Codepoints((first, last)))
        {
            Set = new Codepoints((first, last));
        }

        private Atom(Codepoints set)
        {
            Set = set;
        }

        public Codepoints Set { get; }

        public static Atom From(int single)
        {
            return new Atom(single, single);
        }

        public static Atom From(int first, int last)
        {
            Debug.Assert(first <= last);
            return new Atom(first, last);
        }

        public static Atom From(Codepoints set)
        {
            return new Atom(set);
        }

        public override bool Equals(object obj)
        {
            return obj is Atom other && Set.Equals(other.Set);
        }

        public override int GetHashCode()
        {
            return Set.GetHashCode();
        }

        public bool Match(char character)
        {
            return Set.Contains(character);
        }

        public Atom Not()
        {
            return new Atom(Invert(Set));
        }

        public string ToIString()
        {
            return Set.ToIString();
        }

        public override string ToString()
        {
            return Set.ToString();
        }

        private static Codepoints Invert(Codepoints set)
        {
            return UnicodeSets.Any().Substract(set);
        }

        public static explicit operator Atom(char ch)
        {
            return new Atom(ch, ch);
        }
    }
}