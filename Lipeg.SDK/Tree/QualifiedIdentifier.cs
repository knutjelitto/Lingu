using System;
using System.Diagnostics;
using System.Linq;

using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class QualifiedIdentifier : Expression, ILocated
    {
        private QualifiedIdentifier(IPlusList<Identifier> identifiers)
        {
            Debug.Assert(identifiers.Count > 0);

            Identifiers = identifiers;
            Location = Runtime.Location.From(identifiers[0].Location, identifiers[identifiers.Count - 1].Location);
        }

        public IPlusList<Identifier> Identifiers { get; }

        public ILocation Location { get; }

        public static QualifiedIdentifier From(IPlusList<Identifier> identifiers)
        {
            if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));

            return new QualifiedIdentifier(identifiers);
        }

        public override string ToString()
        {
            return string.Join(".", Identifiers);
        }
    }
}
