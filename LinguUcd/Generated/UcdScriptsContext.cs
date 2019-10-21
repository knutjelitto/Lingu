//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by the lingu compiler compiler. 
// from file: 'UcdScripts.lug' DO NOT EDIT! 
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
    
    public class UcdScriptsContext : Lingu.Runtime.Concretes.LinguContext
    {
        public UcdScriptsContext()
            : base(symbols, productions, CreateParseTable(), CreateDfaSet())
        {
        }
        public static IDfaSet CreateDfaSet()
        {
            byte[] bytes = 
            {
                128,3,0,1,30,1,1,1,4,1,2,3,3,3,4,5,1,6,6,7,7,8,9,2,1,6,7,2,5,5,10,9,1,1,10,1,24,16,1,10,10,1,13,13,1,35,35,3,48,57,65,70,97,102,1,59,59,
                1,46,46,4,1,31,9,11,12,14,31,33,255,255,67,1,32,32,1,109,109,1,105,105,1,115,115,1,110,110,1,103,103,1,58,58,3,1,43,9,11,12,14,255,255,
                67,6,32,32,45,45,48,57,65,90,95,95,97,122,12,10,1,11,1,1,1,1,1,7,1,4,1,4,1,4,1,4,1,4,1,4,4,1,7,1,1,2,2,3,3,4,1,1,1,1,1,1,1,15,1,3,5,1,
                3,6,1,3,7,1,3,8,1,3,9,1,3,1,1,11,1,1,2,2,5,1,9,1,4,1,1,1,3,4,8,1,10,1,5,1,1,5,2,1,1,14,2,8,1,2,1,1,1,1,1,2,16,5,1,8,4,6,1,1,5,2,1,3,7,
                4,2,1,1,1,28,2,1,8,5,1,9,6,1,10,7,1,10,8,1,9,9,1,11,10,1,12,11,1,13,12,1,7,13,1,5,1,1,3,1,7,1,1,7,2,30,1,5,1,5,1,5,1,5,1,5,1,5,1,3,1,1,
                3,2,1,3,3,1,3,4,1,3,5,1,3,6,1,1,4,2,9,1,2,1,1,1,1,3,14,1,1,3,2,1,3,2,1,1,1,2,2,7,2,30,1,4,1,4,1,4,1,4,1,4,1,4,1,3,1,1,3,2,1,3,3,1,3,4,
                1,3,5,1,3,6,1,1,2,2,9,1,6,1,15,1,1,15,1,3,2,5,1,1,1,1,2,1,3,1,1,2,1,1,1,1,3,1,1,1,2,
            };
            
            return new CompactDfaReader(new BinReader(new CompressReader().Uncompress(bytes))).Read();
        }
        
        public static IParseTable CreateParseTable()
        {
            byte[] bytes = 
            {
                196,2,0,5,30,11,20,14,1,2,1,5,2,1,9,3,1,18,10,2,1,1,2,1,1,2,1,1,3,1,1,8,1,1,2,1,32,2,1,36,2,1,40,3,1,1,9,1,1,1,2,2,1,5,1,5,5,1,1,12,1,
                1,6,2,1,5,9,2,1,1,12,1,1,12,1,1,5,1,1,10,9,5,1,5,9,13,17,21,25,29,11,6,41,1,5,9,13,17,10,1,1,5,1,1,3,1,37,1,1,5,2,1,1,1,3,1,50,2,1,3,1,
                14,2,1,3,1,10,2,1,3,1,18,2,1,3,1,49,3,1,3,1,22,2,1,7,1,6,4,13,2,34,2,1,3,1,57,5,1,7,1,65,6,61,3,73,7,1,3,1,46,2,1,3,1,77,8,1,3,1,81,9,
                1,3,1,62,10,1,7,1,41,11,89,4,93,12,1,3,1,38,3,1,3,1,30,2,1,3,1,58,10,1,3,1,97,3,1,3,1,101,7,1,3,1,105,7,1,3,1,109,13,1,3,1,113,12,1,3,
                1,42,2,1,3,1,117,13,1,3,1,26,2,1,1,1,
            };
            
            return new CompactTableReader(new BinReader(new CompressReader().Uncompress(bytes))).Read();
        }
        
        public static readonly TerminalSymbol nl = new TerminalSymbol(0, "nl", true, "");
        public static readonly TerminalSymbol nonl = new TerminalSymbol(1, "nonl", true, "");
        public static readonly TerminalSymbol ws = new TerminalSymbol(2, "ws", false, "");
        public static readonly TerminalSymbol begin = new TerminalSymbol(3, "begin", true, "");
        public static readonly TerminalSymbol end = new TerminalSymbol(4, "end", true, "");
        public static readonly TerminalSymbol ID = new TerminalSymbol(5, "ID", true, "");
        public static readonly TerminalSymbol __T1 = new TerminalSymbol(6, "__T1", true, "#");
        public static readonly TerminalSymbol __T2 = new TerminalSymbol(7, "__T2", false, " missing: ");
        public static readonly TerminalSymbol __T3 = new TerminalSymbol(8, "__T3", false, ";");
        public static readonly TerminalSymbol __T4 = new TerminalSymbol(9, "__T4", false, "..");
        public static readonly TerminalSymbol __eof = new TerminalSymbol(10, "__eof", false, "$eof$");
        public static readonly NonterminalSymbol start = new NonterminalSymbol(11, "start", false, RepeatKind.None);
        public static readonly NonterminalSymbol line = new NonterminalSymbol(12, "line", false, RepeatKind.None);
        public static readonly NonterminalSymbol missing = new NonterminalSymbol(13, "missing", false, RepeatKind.None);
        public static readonly NonterminalSymbol comment = new NonterminalSymbol(14, "comment", false, RepeatKind.None);
        public static readonly NonterminalSymbol empty = new NonterminalSymbol(15, "empty", false, RepeatKind.None);
        public static readonly NonterminalSymbol range = new NonterminalSymbol(16, "range", false, RepeatKind.None);
        public static readonly NonterminalSymbol data = new NonterminalSymbol(17, "data", false, RepeatKind.None);
        public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(18, "__N1", false, RepeatKind.Star);
        public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(19, "__N2", false, RepeatKind.Star);
        public static readonly TerminalSymbol hexdigit = new TerminalSymbol(20, "hexdigit", false, "");
        public static readonly NonterminalSymbol __acc = new NonterminalSymbol(21, "__acc", true, RepeatKind.None);
        
        private static readonly Symbol[] symbols = 
        {
            nl,nonl,ws,begin,end,ID,__T1,__T2,__T3,__T4,__eof,start,line,missing,comment,empty,range,data,__N1,__N2,hexdigit,__acc,
        };
        
        private static readonly Production[] productions = 
        {
            new Production(__acc, "start", new bool[]{false}, new bool[]{false}),
            new Production(start, "__N1", new bool[]{false}, new bool[]{false}),
            new Production(line, "^comment", new bool[]{false}, new bool[]{true}),
            new Production(line, "^missing", new bool[]{false}, new bool[]{true}),
            new Production(line, "^empty", new bool[]{false}, new bool[]{true}),
            new Production(line, "^data", new bool[]{false}, new bool[]{true}),
            new Production(missing, "'#' ,' missing: ' range ,';' ,ˈwsˈ ˈIDˈ ,ˈnlˈ", new bool[]{false,true,false,true,true,false,true}, new bool[]{false,false,false,false,false,false,false}),
            new Production(comment, "'#' ,__N2 ,ˈnlˈ", new bool[]{false,true,true}, new bool[]{false,false,false}),
            new Production(empty, "ˈnlˈ", new bool[]{false}, new bool[]{false}),
            new Production(range, "ˈbeginˈ ,'..' ˈendˈ", new bool[]{false,true,false}, new bool[]{false,false,false}),
            new Production(data, "range ,';' ,ˈwsˈ ˈIDˈ ,ˈwsˈ ,ˈnlˈ", new bool[]{false,true,true,false,true,true}, new bool[]{false,false,false,false,false,false}),
            new Production(__N1, "__N1 line", new bool[]{false,false}, new bool[]{false,false}),
            new Production(__N1, "line", new bool[]{false}, new bool[]{false}),
            new Production(__N1, "", new bool[]{}, new bool[]{}),
            new Production(__N2, "__N2 ˈnonlˈ", new bool[]{false,false}, new bool[]{false,false}),
            new Production(__N2, "ˈnonlˈ", new bool[]{false}, new bool[]{false}),
            new Production(__N2, "", new bool[]{}, new bool[]{}),
        };
    }
}
