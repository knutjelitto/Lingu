using System.Diagnostics;

namespace Lipeg.SDK.Checkers
{
    public abstract class AttributesBase
    {
        protected static bool Is(ref bool? field) => field.HasValue;
        protected static bool Get(ref bool? field, string name)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(name));
            return field ?? false;
            // return field ?? throw new InternalErrorException($"{name} should be set somewhere else");
        }

        protected static bool Set(ref bool? field, bool value)
        {
            if (!field.HasValue || field != value)
            {
                field = value;
                return true;
            }
            return false;
        }
    }
}
