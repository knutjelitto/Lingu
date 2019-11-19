using Lipeg.Runtime;
using System.Diagnostics;

namespace Lipeg.SDK.Checkers
{
    public abstract class AttributesBase
    {
        protected static bool Is(ref bool? field) => field.HasValue;
        protected static T Get<T>(ref T? field, string name) where T : class
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(name));
            return field ?? throw new InternalErrorException($"{name} should be set somewhere else");
        }

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

        protected static bool Set<T>(ref T? field, T value) where T : class
        {
            if (field == default || field != value)
            {
                field = value;
                return true;
            }
            return false;
        }
    }
}
