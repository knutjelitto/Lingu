using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.SDK.Tree
{
    public class Option
    {
        private Option(Identifier identifier, OptionValue optionValue)
        {
            Identifier = identifier;
            OptionValue = optionValue;
        }
        public Identifier Identifier { get; }
        public OptionValue OptionValue { get; }

        public static Option From(Identifier identifier, OptionValue optionValue)
        {
            return new Option(identifier, optionValue);
        }

        public override string ToString()
        {
            return $"[{Identifier}={OptionValue}]";
        }
    }
}
