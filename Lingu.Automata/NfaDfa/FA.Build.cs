namespace Lingu.Automata
{
    public partial class FA
    {
        public static FA operator +(FA n1, FA n2)
        {
            return Builder.Concat(n1, n2);
        }

        public static FA operator |(FA n1, FA n2)
        {
            return Builder.Or(n1, n2);
        }

        public FA Plus() => Builder.Plus(this);

        public FA Star() => Builder.Star(this);

        public FA Opt() => Builder.Optional(this);

        public FA Or(FA other) => Builder.Or(this, other);

        public FA Concat(FA other) => Builder.Concat(this, other);

        public static FA Any => Builder.Dot;

        public static FA From(int codePoint) => Builder.From((char)codePoint);
        public static FA From(string sequence) => Builder.From(sequence);

        public static FA From(int from, int to)
        {
            return Builder.From(from, to);
        }

        public static implicit operator FA((char first, char last) range)
        {
            return Builder.From(range.first, range.last);
        }

        public static implicit operator FA(char @char)
        {
            return Builder.From(@char);
        }

        public static implicit operator FA(string sequence)
        {
            return Builder.From(sequence);
        }

        public static explicit operator FA(Atom terminal)
        {
            return Builder.Single(terminal);
        }

        private static class Builder
        {
            public static FA Single(Atom terminal)
            {
                var start = new State();
                var end = new State();

                start.Add(terminal, end);

                return FA.From(start, end);
            }

            public static FA Dot => Single(Atom.From(UnicodeSets.Any()));

            public static FA From(char ch)
            {
                return Single(Atom.From(ch));
            }

            public static FA From(int first, int last)
            {
                return Single(Atom.From(first, last));
            }

            public static FA From(string sequence)
            {
                var start = new State();
                var current = start;
                var next = (State) null;

                foreach (var ch in sequence)
                {
                    next = new State();
                    current.Add(Atom.From(ch), next);
                    current = next;
                }

                return FA.From(start, next);
            }

            public static FA Optional(FA fa)
            {
                var clone = fa.Clone();

                clone.Start.Add(clone.Final);

                return clone;
            }

            public static FA Star(FA fa)
            {
                var clone = fa.Clone();

                clone.Start.Add(clone.Final);
                clone.Final.Add(clone.Start);

                return clone;
            }

            public static FA Plus(FA fa)
            {
                var clone = fa.Clone();

                clone.Final.Add(clone.Start);

                return clone;
            }

            public static FA Or(FA fa, FA other)
            {
                var first = fa.Clone();
                var second = other.Clone();
                var newEnd = new State();

                first.Start.Add(second.Start);

                first.Final.Add(newEnd);
                second.Final.Add(newEnd);


                return FA.From(first.Start, newEnd);
            }

            public static FA Concat(FA fa, FA other)
            {
                var first = fa.Clone();

                first.Final.Add(other.Start);

                return FA.From(first.Start, other.Final);
            }
        }

    }
}