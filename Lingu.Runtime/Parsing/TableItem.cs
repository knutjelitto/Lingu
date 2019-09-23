namespace Lingu.Runtime.Parsing
{
    public enum TableItem : ushort
    {
        Error = 0,
        Shift = 1,
        Reduce = 2,
        Accept = 3,
        Mask = 3,
    }
}
