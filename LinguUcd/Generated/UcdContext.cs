//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by the lingu compiler compiler. 
// from file: 'Ucd.lug' DO NOT EDIT! 
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

namespace Lingu.CC
{
    using Lingu.Runtime.Commons;
    using Lingu.Runtime.Concretes;
    using Lingu.Runtime.Structures;
    
    public class UcdContext : Lingu.Runtime.Concretes.LinguContext
    {
        public UcdContext()
            : base(symbols, productions, CreateParseTable(), CreateDfaSet())
        {
        }
        public static IDfaSet CreateDfaSet()
        {
            byte[] bytes = 
            {
                30,0,1,5,1,1,1,3,11,1,1,32,32,3,2,1,2,1,1,1,1,2,1,1,1,4,1,1,1,2,1,2,1,1,2,
            };
            
            return new CompactDfaReader(new BinReader(new CompressReader().Uncompress(bytes))).Read();
        }
        
        public static IParseTable CreateParseTable()
        {
            byte[] bytes = 
            {
                37,0,6,5,2,4,4,1,6,1,8,1,12,1,1,1,2,1,5,2,1,13,1,1,5,2,1,1,1,3,1,6,2,1,3,1,14,3,1,3,1,10,3,1,1,1,
            };
            
            return new CompactTableReader(new BinReader(new CompressReader().Uncompress(bytes))).Read();
        }
        
        public static readonly TerminalSymbol whitespace = new TerminalSymbol(0, "whitespace", true, "");
        public static readonly TerminalSymbol __eof = new TerminalSymbol(1, "__eof", false, "$eof$");
        public static readonly NonterminalSymbol start = new NonterminalSymbol(2, "start", false, RepeatKind.None);
        public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(3, "__N1", false, RepeatKind.Star);
        public static readonly NonterminalSymbol __acc = new NonterminalSymbol(4, "__acc", true, RepeatKind.None);
        
        private static readonly Symbol[] symbols = 
        {
            whitespace,__eof,start,__N1,__acc,
        };
        
        private static readonly Production[] productions = 
        {
            new Production(__acc, "start", new bool[]{false}, new bool[]{false}),
            new Production(start, "__N1", new bool[]{false}, new bool[]{false}),
            new Production(__N1, "__N1 ˈwhitespaceˈ", new bool[]{false,false}, new bool[]{false,false}),
            new Production(__N1, "ˈwhitespaceˈ", new bool[]{false}, new bool[]{false}),
            new Production(__N1, "", new bool[]{}, new bool[]{}),
        };
    }
}
