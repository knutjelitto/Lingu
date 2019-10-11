using System.Linq;

#nullable enable

namespace Lingu.Automata
{
    public partial class FA
    {
        public FA Plus() => Builder.Plus(this);

        public FA Star() => Builder.Star(this);

        public FA Opt() => Builder.Optional(this);

        public FA Or(FA other) => Builder.Or(this, other);

        public FA And(FA other) => Builder.Concat(this, other);

        public static FA Any()
        {
            return Builder.Dot();
        }

        public static FA Eof()
        {
            return Builder.Eof();
        }

        public static FA None()
        {
            return Builder.None();
        }

        public static FA From(int codePoint) => Builder.From((char)codePoint);

        public static FA From(string sequence) => Builder.From(sequence);

        public static FA From(int from, int to) => Builder.From(from, to);

        public static FA And(FA first, params FA[] nexts)
        {
            var fa = first;
            foreach (var next in nexts)
            {
                fa = fa.And(next);
            }

            return fa;
        }

        public static FA Or(FA first, params FA[] nexts)
        {
            var fa = first;
            foreach (var next in nexts)
            {
                fa = fa.Or(next);
            }

            return fa;
        }

        public static FA From(char first, char last)
        {
            return Builder.From(first, last);
        }

        public static FA From(char @char)
        {
            return Builder.From(@char);
        }

        public static FA From(Integers terminal)
        {
            return Builder.Single(terminal);
        }

        private static class Builder
        {
            public static FA Single(Integers terminal)
            {
                var start = new State();
                var end = new State();

                start.Add(terminal, end);

                return FA.From(start, end);
            }

            public static FA Dot() => Single(Integers.Any);

            public static FA From(char ch) => Single(Integers.From(ch));

            public static FA From(int first, int last) => Single(Integers.From(first, last));

            public static FA From(string sequence)
            {
                var start = new State();
                var current = start;
                var next = (State?) null;

                foreach (var ch in sequence)
                {
                    next = new State();
                    current.Add(Integers.From(ch), next);
                    current = next;
                }

                return FA.From(start, next);
            }

            public static FA Eof()
            {
                var start = new State();
                var illegal = new State();
                start.Add(Integers.Any, illegal);
                illegal.Add(Integers.Any, illegal);

                return FA.From(start, start);
            }

            public static FA None()
            {
                var start = new State();
                var illegal = new State();
                start.Add(Integers.Any, illegal);
                illegal.Add(Integers.Any, illegal);

                return FA.From(start, start);
            }

            public static FA Optional(FA fa)
            {
                var clone = fa.ToNfa(true);

                clone.Start.Add(clone.Final);

                return clone;
            }

            public static FA Star(FA fa)
            {
                var clone = fa.ToNfa(true);

                clone.Start.Add(clone.Final);
                clone.Final.Add(clone.Start);

                return clone;
            }

            public static FA Plus(FA fa)
            {
                var clone = fa.ToNfa(true);

                clone.Final.Add(clone.Start);

                return clone;
            }

            public static FA Or(FA fa, FA other)
            {
                var first = fa.ToNfa(true);
                var second = other.ToNfa(true);
                var newEnd = new State();

                first.Start.Add(second.Start);

                first.Final.Add(newEnd);
                second.Final.Add(newEnd);


                return FA.From(first.Start, newEnd);
            }

            public static FA Concat(FA fa, FA other)
            {
                var first = fa.ToNfa(true);
                other = other.ToNfa(true);

                first.Final.Add(other.Start);

                return FA.From(first.Start, other.Final);
            }
        }
    }
}