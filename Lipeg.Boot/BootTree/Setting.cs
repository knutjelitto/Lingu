using System;
using System.Collections.Generic;
using System.Text;

namespace Lipeg.Boot.BootTree
{
    public class Setting
    {
        private Setting(Identifier identifier, object value)
        {
            Identifier = identifier;
            Value = value;
        }
        public Identifier Identifier { get; }
        public object Value { get; }

        public static Setting From(Identifier identifier, object value)
        {
            return new Setting(identifier, value);
        }

        public override string ToString()
        {
            return $"[{Identifier}={Value}]";
        }
    }
}
