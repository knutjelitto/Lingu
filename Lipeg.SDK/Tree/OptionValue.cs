using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class OptionValue
    {
        private OptionValue(Identifier qualifiedIdentifier)
        {
            QualifiedIdentifier = qualifiedIdentifier;
        }

        public Identifier QualifiedIdentifier { get; }

        public static OptionValue From(Identifier qualifiedIdentifier)
        {
            return new OptionValue(qualifiedIdentifier);
        }
    }
}
