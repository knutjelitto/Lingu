using Lipeg.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lipeg.SDK.Checkers
{
    public abstract class AttributesBase
    {
        protected static bool Is(ref bool? field) => field.HasValue;
        protected static bool Get(ref bool? field, string name)
        {
            return field ?? throw new InternalErrorException($"{name} should be set somewhere else");
        }

        protected static bool Set(ref bool? field, bool value)
        {
            if (!Is(ref field))
            {
                field = value;
                return true;
            }
            return false;
        }
    }
}
