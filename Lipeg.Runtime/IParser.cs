namespace Lipeg.Runtime
{
    public interface IParser
    {
        IResult Parse(ICursor cursor);
    }
}
