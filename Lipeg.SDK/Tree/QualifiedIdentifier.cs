using System;
using System.Diagnostics;

using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class QualifiedIdentifier : SimpleExpression, ILocated
    {
        private QualifiedIdentifier(ILocated located, IPlusList<Identifier> identifiers)
            : base(located)
        {
            Debug.Assert(identifiers.Count > 0);

            Identifiers = identifiers;
        }

        public IPlusList<Identifier> Identifiers { get; }

        public static QualifiedIdentifier From(ILocated located, IPlusList<Identifier> identifiers)
        {
            if (identifiers == null) throw new ArgumentNullException(nameof(identifiers));

            return new QualifiedIdentifier(located, identifiers);
        }

        public override string ToString()
        {
            return string.Join(".", Identifiers);
        }
    }
}
