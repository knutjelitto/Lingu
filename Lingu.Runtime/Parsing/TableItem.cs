using Lingu.Runtime.Structures;

namespace Lingu.Runtime.Parsing
{
    public enum TableItem : ushort
    {
        Error = 0,
        Accept = 1,
        Shift = 2,
        Reduce = 3,
        ActionBits = 3,
    }
}
