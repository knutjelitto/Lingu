namespace Lingu.CC
{
    using Lingu.Runtime.Structures;
    
    public static partial class LinguContext
    {
        public static IContext CreateContext()
        {
            return new Lingu.Runtime.Concretes.LinguContext(Data.Symbols, Data.Productions, Data.CreateParseTable(), Data.CreateDfaSet());
        }
    }
}
