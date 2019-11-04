using System;
using System.Diagnostics;

using Lipeg.Runtime;

namespace Lipeg.SDK.Tree
{
    public class QualifiedIdentifier : Expression
    {
        private QualifiedIdentifier(IPlusList<Identifier> identifiers)
        {
            Debug.Assert(identifiers.Count > 0);

            Identifiers = identifiers;
        }

        public IPlusList<Identifier> Identifiers { get; }

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
