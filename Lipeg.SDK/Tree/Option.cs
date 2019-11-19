using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Option
    {
        private Option(Identifier identifier, Identifier qualifiedIdentifier)
        {
            Identifier = identifier;
            QualifiedIdentifier = qualifiedIdentifier;
        }
        public Identifier Identifier { get; }
        public Identifier QualifiedIdentifier { get; }

        public static Option From(Identifier identifier, Identifier qualifiedIdentifier)
        {
            return new Option(identifier, qualifiedIdentifier);
        }

        public override string ToString()
        {
            return $"[{Identifier}={QualifiedIdentifier}]";
        }
    }
}
