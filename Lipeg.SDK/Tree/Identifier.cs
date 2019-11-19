using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class Identifier : SimpleExpression
    {
        private Identifier(ILocated located, string name)
            : base(located)
        {
            Parts = new List<IdPart> { new IdPart(located, name)};
        }

        private Identifier(ILocated located, IEnumerable<Identifier> identifiers)
            : base(located)
        {
            var parts = new List<IdPart>();
            foreach (var identifier in identifiers)
            {
                parts.AddRange(identifier.Parts);
            }
            Parts = parts;
        }

        public IList<IdPart> Parts { get; }

        public string Name => string.Join(".", Parts);

        public Identifier With(Identifier append)
        {
            return From(this, Enumerable.Repeat(this, 1).Concat(Enumerable.Repeat(append, 1)));
        }

        public static Identifier From(ILocated located, string name)
        {
            return new Identifier(located, name);
        }

        public static Identifier From(ILocated located, IEnumerable<Identifier> identifiers)
        {
            if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));

            return new Identifier(located, identifiers);
        }

        public override string ToString() => Name;
    }
}
