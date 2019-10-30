using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class QualifiedIdentifier : Expression
    {
        private QualifiedIdentifier(IReadOnlyList<Identifier> identifiers)
        {
            Debug.Assert(identifiers.Count > 0);

            Identifiers = identifiers;
        }

        public IReadOnlyList<Identifier> Identifiers { get; }

        public static QualifiedIdentifier From(IReadOnlyList<Identifier> identifiers)
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
