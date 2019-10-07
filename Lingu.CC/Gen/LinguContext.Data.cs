namespace Lingu.CC
{
    using System.Linq;
    using Lingu.Runtime.Concretes;
    using Lingu.Runtime.Lexing;
    using Lingu.Runtime.Parsing;
    using Lingu.Runtime.Structures;
    
    public partial class LinguContext
    {
        public static class Data
        {
            public static IDfaSet CreateDfaSet()
            {
                int[] map = 
                {
                    0, 1, 1, 2, 3, 4, 4, 4, 4, 4, 4, 3, 3, 3, 4, 1, 5, 5, 5, 5, 5, 6, 5, 5, 7, 5, 5, 7, 5, 4, 2, 5, 4, 8,
                    8, 8, 5, 4, 9, 9, 9, 10, 10, 11, 11, 8, 8, 8, 8, 12, 12, 12, 12, 12, 12, 12, 8, 12, 12, 2, 13, 13, 14,
                    15, 10, 11, 11, 16, 9, 9, 9, 9, 9, 15, 15, 15, 15, 17, 9, 15, 15, 18, 15, 15, 18, 19, 20, 5, 5, 11, 8,
                    8, 8, 8, 8, 7, 12, 12, 21, 22, 22, 14, 14, 14, 14, 23, 23, 23, 23, 23, 23, 23, 14, 23, 23, 2, 13, 13,
                    14, 5, 11, 9, 24, 9, 25, 9, 9, 9, 26, 9, 27, 21, 22, 22, 28, 19, 19, 19, 19, 19, 27, 27, 27, 27, 17,
                    19, 27, 27, 29, 27, 27, 29, 19, 20, 15, 8, 11, 30, 30, 30, 12, 22, 14, 14, 14, 14, 14, 7, 23, 23, 21,
                    9, 11, 31, 11, 24, 24, 24, 24, 24, 31, 31, 31, 31, 17, 24, 31, 31, 32, 31, 31, 32, 19, 20, 33, 15, 15,
                    15, 15, 22, 19, 34, 19, 25, 19, 19, 19, 26, 19, 21, 27, 11, 35, 36, 36, 30, 30, 30, 30, 37, 37, 37, 37,
                    37, 37, 37, 30, 37, 37, 2, 13, 13, 14, 14, 22, 30, 23, 11, 24, 25, 24, 24, 24, 26, 24, 21, 31, 35, 25,
                    19, 22, 38, 22, 34, 34, 34, 34, 34, 38, 38, 38, 38, 17, 34, 38, 38, 39, 38, 38, 39, 19, 20, 33, 27, 27,
                    27, 27, 12, 36, 30, 30, 30, 30, 30, 7, 37, 37, 21, 22, 35, 33, 31, 31, 31, 31, 9, 35, 22, 34, 25, 34,
                    34, 34, 26, 34, 21, 38, 35, 30, 36, 30, 37, 23, 35, 33, 38, 38, 38, 38, 19, 36, 35, 24, 35, 37, 34,
                };
                
                Set[] sets = 
                {
                    /*  0 */ new Set(new Interval(103,103)),
                    /*  1 */ new Set(new Interval(114,114)),
                    /*  2 */ new Set(new Interval(97,97)),
                    /*  3 */ new Set(new Interval(109,109)),
                    /*  4 */ new Set(new Interval(65,90), new Interval(95,95), new Interval(97,122)),
                    /*  5 */ new Set(new Interval(48,57), new Interval(65,90), new Interval(95,95), new Interval(97,122)),
                    /*  6 */ new Set(new Interval(123,123)),
                    /*  7 */ new Set(new Interval(111,111)),
                    /*  8 */ new Set(new Interval(116,116)),
                    /*  9 */ new Set(new Interval(125,125)),
                    /* 10 */ new Set(new Interval(112,112)),
                    /* 11 */ new Set(new Interval(105,105)),
                    /* 12 */ new Set(new Interval(110,110)),
                    /* 13 */ new Set(new Interval(115,115)),
                    /* 14 */ new Set(new Interval(117,117)),
                    /* 15 */ new Set(new Interval(108,108)),
                    /* 16 */ new Set(new Interval(101,101)),
                    /* 17 */ new Set(new Interval(61,61)),
                    /* 18 */ new Set(new Interval(45,45)),
                    /* 19 */ new Set(new Interval(58,58)),
                    /* 20 */ new Set(new Interval(62,62)),
                    /* 21 */ new Set(new Interval(39,39)),
                    /* 22 */ new Set(new Interval(40,40)),
                    /* 23 */ new Set(new Interval(44,44)),
                    /* 24 */ new Set(new Interval(59,59)),
                    /* 25 */ new Set(new Interval(94,94)),
                    /* 26 */ new Set(new Interval(124,124)),
                    /* 27 */ new Set(new Interval(0,38), new Interval(40,91), new Interval(93,1114111)),
                    /* 28 */ new Set(new Interval(92,92)),
                    /* 29 */ new Set(new Interval(39,39), new Interval(48,48), new Interval(92,92), new Interval(97,98), new Interval(102,102), new Interval(110,110), new Interval(114,114), new Interval(116,116), new Interval(118,118)),
                    /* 30 */ new Set(new Interval(48,57), new Interval(65,70), new Interval(97,102)),
                    /* 31 */ new Set(new Interval(46,46)),
                    /* 32 */ new Set(new Interval(65,84), new Interval(86,90), new Interval(95,95), new Interval(97,116), new Interval(118,122)),
                    /* 33 */ new Set(new Interval(85,85), new Interval(117,117)),
                    /* 34 */ new Set(new Interval(126,126)),
                    /* 35 */ new Set(new Interval(43,43)),
                    /* 36 */ new Set(new Interval(98,98)),
                    /* 37 */ new Set(new Interval(99,99)),
                    /* 38 */ new Set(new Interval(65,90), new Interval(97,122)),
                    /* 39 */ new Set(new Interval(32,32), new Interval(45,45), new Interval(95,95)),
                    /* 40 */ new Set(new Interval(48,57), new Interval(65,90), new Interval(97,122)),
                    /* 41 */ new Set(new Interval(42,42)),
                    /* 42 */ new Set(new Interval(63,63)),
                    /* 43 */ new Set(new Interval(41,41)),
                    /* 44 */ new Set(new Interval(48,48)),
                    /* 45 */ new Set(new Interval(49,57)),
                    /* 46 */ new Set(new Interval(48,57)),
                    /* 47 */ new Set(new Interval(9,13), new Interval(32,32), new Interval(133,133), new Interval(8232,8233)),
                    /* 48 */ new Set(new Interval(47,47)),
                    /* 49 */ new Set(new Interval(0,9), new Interval(11,12), new Interval(14,46), new Interval(48,132), new Interval(134,8231), new Interval(8234,1114111)),
                    /* 50 */ new Set(new Interval(10,10), new Interval(13,13), new Interval(133,133), new Interval(8232,8233)),
                    /* 51 */ new Set(new Interval(0,9), new Interval(11,12), new Interval(14,41), new Interval(43,46), new Interval(48,132), new Interval(134,8231), new Interval(8234,1114111)),
                    /* 52 */ new Set(new Interval(0,8), new Interval(14,31), new Interval(33,41), new Interval(43,46), new Interval(48,132), new Interval(134,8231), new Interval(8234,1114111)),
                    /* 53 */ new Set(new Interval(0,41), new Interval(43,46), new Interval(48,1114111)),
                    /* 54 */ new Set(new Interval(0,41), new Interval(43,1114111)),
                    /* 55 */ new Set(new Interval(0,46), new Interval(48,1114111)),
                    /* 56 */ new Set(new Interval(42,42), new Interval(47,47)),
                };
                
                /* dfa  0 -- 'grammar' -- */
                var states0 = new DfaState[8] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,false,-1), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,true,7)};
                states0[0].Transitions = new DfaTrans[1] {new DfaTrans(states0[1], sets[0])};
                states0[1].Transitions = new DfaTrans[1] {new DfaTrans(states0[2], sets[1])};
                states0[2].Transitions = new DfaTrans[1] {new DfaTrans(states0[3], sets[2])};
                states0[3].Transitions = new DfaTrans[1] {new DfaTrans(states0[4], sets[3])};
                states0[4].Transitions = new DfaTrans[1] {new DfaTrans(states0[5], sets[3])};
                states0[5].Transitions = new DfaTrans[1] {new DfaTrans(states0[6], sets[2])};
                states0[6].Transitions = new DfaTrans[1] {new DfaTrans(states0[7], sets[1])};
                states0[7].Transitions = new DfaTrans[0] {};
                
                /* dfa  1 -- '$eof$' -- */
                var states1 = new DfaState[1] {new DfaState(0,true,28)};
                states1[0].Transitions = new DfaTrans[0] {};
                
                /* dfa  2 -- ˈidentifierˈ -- */
                var states2 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,0)};
                states2[0].Transitions = new DfaTrans[1] {new DfaTrans(states2[1], sets[4])};
                states2[1].Transitions = new DfaTrans[1] {new DfaTrans(states2[1], sets[5])};
                
                /* dfa  3 -- '{' -- */
                var states3 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,8)};
                states3[0].Transitions = new DfaTrans[1] {new DfaTrans(states3[1], sets[6])};
                states3[1].Transitions = new DfaTrans[0] {};
                
                /* dfa  4 -- 'options' | 'rules' | 'terminals' | '}' -- */
                var states4 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,false,-1), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,true,10), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,true,13), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,false,-1), new DfaState(16,false,-1), new DfaState(17,false,-1), new DfaState(18,false,-1), new DfaState(19,false,-1), new DfaState(20,false,-1), new DfaState(21,true,22), new DfaState(22,true,9)};
                states4[0].Transitions = new DfaTrans[4] {new DfaTrans(states4[1], sets[7]), new DfaTrans(states4[8], sets[1]), new DfaTrans(states4[13], sets[8]), new DfaTrans(states4[22], sets[9])};
                states4[1].Transitions = new DfaTrans[1] {new DfaTrans(states4[2], sets[10])};
                states4[2].Transitions = new DfaTrans[1] {new DfaTrans(states4[3], sets[8])};
                states4[3].Transitions = new DfaTrans[1] {new DfaTrans(states4[4], sets[11])};
                states4[4].Transitions = new DfaTrans[1] {new DfaTrans(states4[5], sets[7])};
                states4[5].Transitions = new DfaTrans[1] {new DfaTrans(states4[6], sets[12])};
                states4[6].Transitions = new DfaTrans[1] {new DfaTrans(states4[7], sets[13])};
                states4[7].Transitions = new DfaTrans[0] {};
                states4[8].Transitions = new DfaTrans[1] {new DfaTrans(states4[9], sets[14])};
                states4[9].Transitions = new DfaTrans[1] {new DfaTrans(states4[10], sets[15])};
                states4[10].Transitions = new DfaTrans[1] {new DfaTrans(states4[11], sets[16])};
                states4[11].Transitions = new DfaTrans[1] {new DfaTrans(states4[12], sets[13])};
                states4[12].Transitions = new DfaTrans[0] {};
                states4[13].Transitions = new DfaTrans[1] {new DfaTrans(states4[14], sets[16])};
                states4[14].Transitions = new DfaTrans[1] {new DfaTrans(states4[15], sets[1])};
                states4[15].Transitions = new DfaTrans[1] {new DfaTrans(states4[16], sets[3])};
                states4[16].Transitions = new DfaTrans[1] {new DfaTrans(states4[17], sets[11])};
                states4[17].Transitions = new DfaTrans[1] {new DfaTrans(states4[18], sets[12])};
                states4[18].Transitions = new DfaTrans[1] {new DfaTrans(states4[19], sets[2])};
                states4[19].Transitions = new DfaTrans[1] {new DfaTrans(states4[20], sets[15])};
                states4[20].Transitions = new DfaTrans[1] {new DfaTrans(states4[21], sets[13])};
                states4[21].Transitions = new DfaTrans[0] {};
                states4[22].Transitions = new DfaTrans[0] {};
                
                /* dfa  5 -- ˈidentifierˈ | '}' -- */
                var states5 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,0), new DfaState(2,true,9)};
                states5[0].Transitions = new DfaTrans[2] {new DfaTrans(states5[1], sets[4]), new DfaTrans(states5[2], sets[9])};
                states5[1].Transitions = new DfaTrans[1] {new DfaTrans(states5[1], sets[5])};
                states5[2].Transitions = new DfaTrans[0] {};
                
                /* dfa  6 -- '=' -- */
                var states6 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,11)};
                states6[0].Transitions = new DfaTrans[1] {new DfaTrans(states6[1], sets[17])};
                states6[1].Transitions = new DfaTrans[0] {};
                
                /* dfa  7 -- '->' | ':' -- */
                var states7 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,27), new DfaState(3,true,26)};
                states7[0].Transitions = new DfaTrans[2] {new DfaTrans(states7[1], sets[18]), new DfaTrans(states7[3], sets[19])};
                states7[1].Transitions = new DfaTrans[1] {new DfaTrans(states7[2], sets[20])};
                states7[2].Transitions = new DfaTrans[0] {};
                states7[3].Transitions = new DfaTrans[0] {};
                
                /* dfa  8 -- ˈtextˈ | '(' | ',' | ';' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states8 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,18), new DfaState(15,true,12), new DfaState(16,true,0), new DfaState(17,true,19), new DfaState(18,true,8), new DfaState(19,true,14)};
                states8[0].Transitions = new DfaTrans[8] {new DfaTrans(states8[1], sets[21]), new DfaTrans(states8[13], sets[22]), new DfaTrans(states8[14], sets[23]), new DfaTrans(states8[15], sets[24]), new DfaTrans(states8[16], sets[4]), new DfaTrans(states8[17], sets[25]), new DfaTrans(states8[18], sets[6]), new DfaTrans(states8[19], sets[26])};
                states8[1].Transitions = new DfaTrans[2] {new DfaTrans(states8[2], sets[27]), new DfaTrans(states8[4], sets[28])};
                states8[2].Transitions = new DfaTrans[3] {new DfaTrans(states8[2], sets[27]), new DfaTrans(states8[3], sets[21]), new DfaTrans(states8[4], sets[28])};
                states8[3].Transitions = new DfaTrans[0] {};
                states8[4].Transitions = new DfaTrans[2] {new DfaTrans(states8[2], sets[29]), new DfaTrans(states8[5], sets[14])};
                states8[5].Transitions = new DfaTrans[1] {new DfaTrans(states8[6], sets[6])};
                states8[6].Transitions = new DfaTrans[1] {new DfaTrans(states8[7], sets[30])};
                states8[7].Transitions = new DfaTrans[2] {new DfaTrans(states8[8], sets[30]), new DfaTrans(states8[2], sets[9])};
                states8[8].Transitions = new DfaTrans[2] {new DfaTrans(states8[9], sets[30]), new DfaTrans(states8[2], sets[9])};
                states8[9].Transitions = new DfaTrans[2] {new DfaTrans(states8[10], sets[30]), new DfaTrans(states8[2], sets[9])};
                states8[10].Transitions = new DfaTrans[2] {new DfaTrans(states8[11], sets[30]), new DfaTrans(states8[2], sets[9])};
                states8[11].Transitions = new DfaTrans[2] {new DfaTrans(states8[12], sets[30]), new DfaTrans(states8[2], sets[9])};
                states8[12].Transitions = new DfaTrans[1] {new DfaTrans(states8[2], sets[9])};
                states8[13].Transitions = new DfaTrans[0] {};
                states8[14].Transitions = new DfaTrans[0] {};
                states8[15].Transitions = new DfaTrans[0] {};
                states8[16].Transitions = new DfaTrans[1] {new DfaTrans(states8[16], sets[5])};
                states8[17].Transitions = new DfaTrans[0] {};
                states8[18].Transitions = new DfaTrans[0] {};
                states8[19].Transitions = new DfaTrans[0] {};
                
                /* dfa  9 -- ˈtextˈ | '(' | '-' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states9 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,23), new DfaState(15,true,2), new DfaState(16,true,12), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,14), new DfaState(46,true,24)};
                states9[0].Transitions = new DfaTrans[10] {new DfaTrans(states9[1], sets[21]), new DfaTrans(states9[13], sets[22]), new DfaTrans(states9[14], sets[18]), new DfaTrans(states9[15], sets[31]), new DfaTrans(states9[16], sets[24]), new DfaTrans(states9[17], sets[32]), new DfaTrans(states9[18], sets[33]), new DfaTrans(states9[26], sets[28]), new DfaTrans(states9[45], sets[26]), new DfaTrans(states9[46], sets[34])};
                states9[1].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[27]), new DfaTrans(states9[4], sets[28])};
                states9[2].Transitions = new DfaTrans[3] {new DfaTrans(states9[2], sets[27]), new DfaTrans(states9[3], sets[21]), new DfaTrans(states9[4], sets[28])};
                states9[3].Transitions = new DfaTrans[0] {};
                states9[4].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[29]), new DfaTrans(states9[5], sets[14])};
                states9[5].Transitions = new DfaTrans[1] {new DfaTrans(states9[6], sets[6])};
                states9[6].Transitions = new DfaTrans[1] {new DfaTrans(states9[7], sets[30])};
                states9[7].Transitions = new DfaTrans[2] {new DfaTrans(states9[8], sets[30]), new DfaTrans(states9[2], sets[9])};
                states9[8].Transitions = new DfaTrans[2] {new DfaTrans(states9[9], sets[30]), new DfaTrans(states9[2], sets[9])};
                states9[9].Transitions = new DfaTrans[2] {new DfaTrans(states9[10], sets[30]), new DfaTrans(states9[2], sets[9])};
                states9[10].Transitions = new DfaTrans[2] {new DfaTrans(states9[11], sets[30]), new DfaTrans(states9[2], sets[9])};
                states9[11].Transitions = new DfaTrans[2] {new DfaTrans(states9[12], sets[30]), new DfaTrans(states9[2], sets[9])};
                states9[12].Transitions = new DfaTrans[1] {new DfaTrans(states9[2], sets[9])};
                states9[13].Transitions = new DfaTrans[0] {};
                states9[14].Transitions = new DfaTrans[0] {};
                states9[15].Transitions = new DfaTrans[0] {};
                states9[16].Transitions = new DfaTrans[0] {};
                states9[17].Transitions = new DfaTrans[1] {new DfaTrans(states9[17], sets[5])};
                states9[18].Transitions = new DfaTrans[2] {new DfaTrans(states9[19], sets[35]), new DfaTrans(states9[17], sets[5])};
                states9[19].Transitions = new DfaTrans[1] {new DfaTrans(states9[20], sets[30])};
                states9[20].Transitions = new DfaTrans[1] {new DfaTrans(states9[21], sets[30])};
                states9[21].Transitions = new DfaTrans[1] {new DfaTrans(states9[22], sets[30])};
                states9[22].Transitions = new DfaTrans[1] {new DfaTrans(states9[23], sets[30])};
                states9[23].Transitions = new DfaTrans[1] {new DfaTrans(states9[24], sets[30])};
                states9[24].Transitions = new DfaTrans[1] {new DfaTrans(states9[25], sets[30])};
                states9[25].Transitions = new DfaTrans[0] {};
                states9[26].Transitions = new DfaTrans[1] {new DfaTrans(states9[27], sets[14])};
                states9[27].Transitions = new DfaTrans[3] {new DfaTrans(states9[28], sets[36]), new DfaTrans(states9[33], sets[37]), new DfaTrans(states9[38], sets[6])};
                states9[28].Transitions = new DfaTrans[1] {new DfaTrans(states9[29], sets[6])};
                states9[29].Transitions = new DfaTrans[1] {new DfaTrans(states9[30], sets[38])};
                states9[30].Transitions = new DfaTrans[3] {new DfaTrans(states9[31], sets[39]), new DfaTrans(states9[30], sets[40]), new DfaTrans(states9[32], sets[9])};
                states9[31].Transitions = new DfaTrans[2] {new DfaTrans(states9[31], sets[39]), new DfaTrans(states9[30], sets[40])};
                states9[32].Transitions = new DfaTrans[0] {};
                states9[33].Transitions = new DfaTrans[1] {new DfaTrans(states9[34], sets[6])};
                states9[34].Transitions = new DfaTrans[1] {new DfaTrans(states9[35], sets[38])};
                states9[35].Transitions = new DfaTrans[3] {new DfaTrans(states9[36], sets[39]), new DfaTrans(states9[35], sets[40]), new DfaTrans(states9[37], sets[9])};
                states9[36].Transitions = new DfaTrans[2] {new DfaTrans(states9[36], sets[39]), new DfaTrans(states9[35], sets[40])};
                states9[37].Transitions = new DfaTrans[0] {};
                states9[38].Transitions = new DfaTrans[1] {new DfaTrans(states9[39], sets[30])};
                states9[39].Transitions = new DfaTrans[2] {new DfaTrans(states9[40], sets[30]), new DfaTrans(states9[25], sets[9])};
                states9[40].Transitions = new DfaTrans[2] {new DfaTrans(states9[41], sets[30]), new DfaTrans(states9[25], sets[9])};
                states9[41].Transitions = new DfaTrans[2] {new DfaTrans(states9[42], sets[30]), new DfaTrans(states9[25], sets[9])};
                states9[42].Transitions = new DfaTrans[2] {new DfaTrans(states9[43], sets[30]), new DfaTrans(states9[25], sets[9])};
                states9[43].Transitions = new DfaTrans[2] {new DfaTrans(states9[44], sets[30]), new DfaTrans(states9[25], sets[9])};
                states9[44].Transitions = new DfaTrans[1] {new DfaTrans(states9[25], sets[9])};
                states9[45].Transitions = new DfaTrans[0] {};
                states9[46].Transitions = new DfaTrans[0] {};
                
                /* dfa 10 -- ';' -- */
                var states10 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,12)};
                states10[0].Transitions = new DfaTrans[1] {new DfaTrans(states10[1], sets[24])};
                states10[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 11 -- ';' | '|' -- */
                var states11 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,12), new DfaState(2,true,14)};
                states11[0].Transitions = new DfaTrans[2] {new DfaTrans(states11[1], sets[24]), new DfaTrans(states11[2], sets[26])};
                states11[1].Transitions = new DfaTrans[0] {};
                states11[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 12 -- ˈtextˈ | '(' | '*' | '+' | ',' | ';' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states12 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,16), new DfaState(15,true,17), new DfaState(16,true,18), new DfaState(17,true,12), new DfaState(18,true,15), new DfaState(19,true,0), new DfaState(20,true,19), new DfaState(21,true,8), new DfaState(22,true,14)};
                states12[0].Transitions = new DfaTrans[11] {new DfaTrans(states12[1], sets[21]), new DfaTrans(states12[13], sets[22]), new DfaTrans(states12[14], sets[41]), new DfaTrans(states12[15], sets[35]), new DfaTrans(states12[16], sets[23]), new DfaTrans(states12[17], sets[24]), new DfaTrans(states12[18], sets[42]), new DfaTrans(states12[19], sets[4]), new DfaTrans(states12[20], sets[25]), new DfaTrans(states12[21], sets[6]), new DfaTrans(states12[22], sets[26])};
                states12[1].Transitions = new DfaTrans[2] {new DfaTrans(states12[2], sets[27]), new DfaTrans(states12[4], sets[28])};
                states12[2].Transitions = new DfaTrans[3] {new DfaTrans(states12[2], sets[27]), new DfaTrans(states12[3], sets[21]), new DfaTrans(states12[4], sets[28])};
                states12[3].Transitions = new DfaTrans[0] {};
                states12[4].Transitions = new DfaTrans[2] {new DfaTrans(states12[2], sets[29]), new DfaTrans(states12[5], sets[14])};
                states12[5].Transitions = new DfaTrans[1] {new DfaTrans(states12[6], sets[6])};
                states12[6].Transitions = new DfaTrans[1] {new DfaTrans(states12[7], sets[30])};
                states12[7].Transitions = new DfaTrans[2] {new DfaTrans(states12[8], sets[30]), new DfaTrans(states12[2], sets[9])};
                states12[8].Transitions = new DfaTrans[2] {new DfaTrans(states12[9], sets[30]), new DfaTrans(states12[2], sets[9])};
                states12[9].Transitions = new DfaTrans[2] {new DfaTrans(states12[10], sets[30]), new DfaTrans(states12[2], sets[9])};
                states12[10].Transitions = new DfaTrans[2] {new DfaTrans(states12[11], sets[30]), new DfaTrans(states12[2], sets[9])};
                states12[11].Transitions = new DfaTrans[2] {new DfaTrans(states12[12], sets[30]), new DfaTrans(states12[2], sets[9])};
                states12[12].Transitions = new DfaTrans[1] {new DfaTrans(states12[2], sets[9])};
                states12[13].Transitions = new DfaTrans[0] {};
                states12[14].Transitions = new DfaTrans[0] {};
                states12[15].Transitions = new DfaTrans[0] {};
                states12[16].Transitions = new DfaTrans[0] {};
                states12[17].Transitions = new DfaTrans[0] {};
                states12[18].Transitions = new DfaTrans[0] {};
                states12[19].Transitions = new DfaTrans[1] {new DfaTrans(states12[19], sets[5])};
                states12[20].Transitions = new DfaTrans[0] {};
                states12[21].Transitions = new DfaTrans[0] {};
                states12[22].Transitions = new DfaTrans[0] {};
                
                /* dfa 13 -- ˈtextˈ | '(' | ˈidentifierˈ | '{' -- */
                var states13 = new DfaState[16] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,0), new DfaState(15,true,8)};
                states13[0].Transitions = new DfaTrans[4] {new DfaTrans(states13[1], sets[21]), new DfaTrans(states13[13], sets[22]), new DfaTrans(states13[14], sets[4]), new DfaTrans(states13[15], sets[6])};
                states13[1].Transitions = new DfaTrans[2] {new DfaTrans(states13[2], sets[27]), new DfaTrans(states13[4], sets[28])};
                states13[2].Transitions = new DfaTrans[3] {new DfaTrans(states13[2], sets[27]), new DfaTrans(states13[3], sets[21]), new DfaTrans(states13[4], sets[28])};
                states13[3].Transitions = new DfaTrans[0] {};
                states13[4].Transitions = new DfaTrans[2] {new DfaTrans(states13[2], sets[29]), new DfaTrans(states13[5], sets[14])};
                states13[5].Transitions = new DfaTrans[1] {new DfaTrans(states13[6], sets[6])};
                states13[6].Transitions = new DfaTrans[1] {new DfaTrans(states13[7], sets[30])};
                states13[7].Transitions = new DfaTrans[2] {new DfaTrans(states13[8], sets[30]), new DfaTrans(states13[2], sets[9])};
                states13[8].Transitions = new DfaTrans[2] {new DfaTrans(states13[9], sets[30]), new DfaTrans(states13[2], sets[9])};
                states13[9].Transitions = new DfaTrans[2] {new DfaTrans(states13[10], sets[30]), new DfaTrans(states13[2], sets[9])};
                states13[10].Transitions = new DfaTrans[2] {new DfaTrans(states13[11], sets[30]), new DfaTrans(states13[2], sets[9])};
                states13[11].Transitions = new DfaTrans[2] {new DfaTrans(states13[12], sets[30]), new DfaTrans(states13[2], sets[9])};
                states13[12].Transitions = new DfaTrans[1] {new DfaTrans(states13[2], sets[9])};
                states13[13].Transitions = new DfaTrans[0] {};
                states13[14].Transitions = new DfaTrans[1] {new DfaTrans(states13[14], sets[5])};
                states13[15].Transitions = new DfaTrans[0] {};
                
                /* dfa 14 -- ˈtextˈ | '(' | ')' | ',' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states14 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,18), new DfaState(16,true,0), new DfaState(17,true,19), new DfaState(18,true,8), new DfaState(19,true,14)};
                states14[0].Transitions = new DfaTrans[8] {new DfaTrans(states14[1], sets[21]), new DfaTrans(states14[13], sets[22]), new DfaTrans(states14[14], sets[43]), new DfaTrans(states14[15], sets[23]), new DfaTrans(states14[16], sets[4]), new DfaTrans(states14[17], sets[25]), new DfaTrans(states14[18], sets[6]), new DfaTrans(states14[19], sets[26])};
                states14[1].Transitions = new DfaTrans[2] {new DfaTrans(states14[2], sets[27]), new DfaTrans(states14[4], sets[28])};
                states14[2].Transitions = new DfaTrans[3] {new DfaTrans(states14[2], sets[27]), new DfaTrans(states14[3], sets[21]), new DfaTrans(states14[4], sets[28])};
                states14[3].Transitions = new DfaTrans[0] {};
                states14[4].Transitions = new DfaTrans[2] {new DfaTrans(states14[2], sets[29]), new DfaTrans(states14[5], sets[14])};
                states14[5].Transitions = new DfaTrans[1] {new DfaTrans(states14[6], sets[6])};
                states14[6].Transitions = new DfaTrans[1] {new DfaTrans(states14[7], sets[30])};
                states14[7].Transitions = new DfaTrans[2] {new DfaTrans(states14[8], sets[30]), new DfaTrans(states14[2], sets[9])};
                states14[8].Transitions = new DfaTrans[2] {new DfaTrans(states14[9], sets[30]), new DfaTrans(states14[2], sets[9])};
                states14[9].Transitions = new DfaTrans[2] {new DfaTrans(states14[10], sets[30]), new DfaTrans(states14[2], sets[9])};
                states14[10].Transitions = new DfaTrans[2] {new DfaTrans(states14[11], sets[30]), new DfaTrans(states14[2], sets[9])};
                states14[11].Transitions = new DfaTrans[2] {new DfaTrans(states14[12], sets[30]), new DfaTrans(states14[2], sets[9])};
                states14[12].Transitions = new DfaTrans[1] {new DfaTrans(states14[2], sets[9])};
                states14[13].Transitions = new DfaTrans[0] {};
                states14[14].Transitions = new DfaTrans[0] {};
                states14[15].Transitions = new DfaTrans[0] {};
                states14[16].Transitions = new DfaTrans[1] {new DfaTrans(states14[16], sets[5])};
                states14[17].Transitions = new DfaTrans[0] {};
                states14[18].Transitions = new DfaTrans[0] {};
                states14[19].Transitions = new DfaTrans[0] {};
                
                /* dfa 15 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states15 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,16), new DfaState(15,true,17), new DfaState(16,true,23), new DfaState(17,true,2), new DfaState(18,true,12), new DfaState(19,true,15), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,14), new DfaState(50,true,24)};
                states15[0].Transitions = new DfaTrans[14] {new DfaTrans(states15[1], sets[21]), new DfaTrans(states15[13], sets[22]), new DfaTrans(states15[14], sets[41]), new DfaTrans(states15[15], sets[35]), new DfaTrans(states15[16], sets[18]), new DfaTrans(states15[17], sets[31]), new DfaTrans(states15[18], sets[24]), new DfaTrans(states15[19], sets[42]), new DfaTrans(states15[20], sets[32]), new DfaTrans(states15[21], sets[33]), new DfaTrans(states15[29], sets[28]), new DfaTrans(states15[48], sets[6]), new DfaTrans(states15[49], sets[26]), new DfaTrans(states15[50], sets[34])};
                states15[1].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[27]), new DfaTrans(states15[4], sets[28])};
                states15[2].Transitions = new DfaTrans[3] {new DfaTrans(states15[2], sets[27]), new DfaTrans(states15[3], sets[21]), new DfaTrans(states15[4], sets[28])};
                states15[3].Transitions = new DfaTrans[0] {};
                states15[4].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[29]), new DfaTrans(states15[5], sets[14])};
                states15[5].Transitions = new DfaTrans[1] {new DfaTrans(states15[6], sets[6])};
                states15[6].Transitions = new DfaTrans[1] {new DfaTrans(states15[7], sets[30])};
                states15[7].Transitions = new DfaTrans[2] {new DfaTrans(states15[8], sets[30]), new DfaTrans(states15[2], sets[9])};
                states15[8].Transitions = new DfaTrans[2] {new DfaTrans(states15[9], sets[30]), new DfaTrans(states15[2], sets[9])};
                states15[9].Transitions = new DfaTrans[2] {new DfaTrans(states15[10], sets[30]), new DfaTrans(states15[2], sets[9])};
                states15[10].Transitions = new DfaTrans[2] {new DfaTrans(states15[11], sets[30]), new DfaTrans(states15[2], sets[9])};
                states15[11].Transitions = new DfaTrans[2] {new DfaTrans(states15[12], sets[30]), new DfaTrans(states15[2], sets[9])};
                states15[12].Transitions = new DfaTrans[1] {new DfaTrans(states15[2], sets[9])};
                states15[13].Transitions = new DfaTrans[0] {};
                states15[14].Transitions = new DfaTrans[0] {};
                states15[15].Transitions = new DfaTrans[0] {};
                states15[16].Transitions = new DfaTrans[0] {};
                states15[17].Transitions = new DfaTrans[0] {};
                states15[18].Transitions = new DfaTrans[0] {};
                states15[19].Transitions = new DfaTrans[0] {};
                states15[20].Transitions = new DfaTrans[1] {new DfaTrans(states15[20], sets[5])};
                states15[21].Transitions = new DfaTrans[2] {new DfaTrans(states15[22], sets[35]), new DfaTrans(states15[20], sets[5])};
                states15[22].Transitions = new DfaTrans[1] {new DfaTrans(states15[23], sets[30])};
                states15[23].Transitions = new DfaTrans[1] {new DfaTrans(states15[24], sets[30])};
                states15[24].Transitions = new DfaTrans[1] {new DfaTrans(states15[25], sets[30])};
                states15[25].Transitions = new DfaTrans[1] {new DfaTrans(states15[26], sets[30])};
                states15[26].Transitions = new DfaTrans[1] {new DfaTrans(states15[27], sets[30])};
                states15[27].Transitions = new DfaTrans[1] {new DfaTrans(states15[28], sets[30])};
                states15[28].Transitions = new DfaTrans[0] {};
                states15[29].Transitions = new DfaTrans[1] {new DfaTrans(states15[30], sets[14])};
                states15[30].Transitions = new DfaTrans[3] {new DfaTrans(states15[31], sets[36]), new DfaTrans(states15[36], sets[37]), new DfaTrans(states15[41], sets[6])};
                states15[31].Transitions = new DfaTrans[1] {new DfaTrans(states15[32], sets[6])};
                states15[32].Transitions = new DfaTrans[1] {new DfaTrans(states15[33], sets[38])};
                states15[33].Transitions = new DfaTrans[3] {new DfaTrans(states15[34], sets[39]), new DfaTrans(states15[33], sets[40]), new DfaTrans(states15[35], sets[9])};
                states15[34].Transitions = new DfaTrans[2] {new DfaTrans(states15[34], sets[39]), new DfaTrans(states15[33], sets[40])};
                states15[35].Transitions = new DfaTrans[0] {};
                states15[36].Transitions = new DfaTrans[1] {new DfaTrans(states15[37], sets[6])};
                states15[37].Transitions = new DfaTrans[1] {new DfaTrans(states15[38], sets[38])};
                states15[38].Transitions = new DfaTrans[3] {new DfaTrans(states15[39], sets[39]), new DfaTrans(states15[38], sets[40]), new DfaTrans(states15[40], sets[9])};
                states15[39].Transitions = new DfaTrans[2] {new DfaTrans(states15[39], sets[39]), new DfaTrans(states15[38], sets[40])};
                states15[40].Transitions = new DfaTrans[0] {};
                states15[41].Transitions = new DfaTrans[1] {new DfaTrans(states15[42], sets[30])};
                states15[42].Transitions = new DfaTrans[2] {new DfaTrans(states15[43], sets[30]), new DfaTrans(states15[28], sets[9])};
                states15[43].Transitions = new DfaTrans[2] {new DfaTrans(states15[44], sets[30]), new DfaTrans(states15[28], sets[9])};
                states15[44].Transitions = new DfaTrans[2] {new DfaTrans(states15[45], sets[30]), new DfaTrans(states15[28], sets[9])};
                states15[45].Transitions = new DfaTrans[2] {new DfaTrans(states15[46], sets[30]), new DfaTrans(states15[28], sets[9])};
                states15[46].Transitions = new DfaTrans[2] {new DfaTrans(states15[47], sets[30]), new DfaTrans(states15[28], sets[9])};
                states15[47].Transitions = new DfaTrans[1] {new DfaTrans(states15[28], sets[9])};
                states15[48].Transitions = new DfaTrans[0] {};
                states15[49].Transitions = new DfaTrans[0] {};
                states15[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 16 -- '-' | ';' | '|' -- */
                var states16 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,23), new DfaState(2,true,12), new DfaState(3,true,14)};
                states16[0].Transitions = new DfaTrans[3] {new DfaTrans(states16[1], sets[18]), new DfaTrans(states16[2], sets[24]), new DfaTrans(states16[3], sets[26])};
                states16[1].Transitions = new DfaTrans[0] {};
                states16[2].Transitions = new DfaTrans[0] {};
                states16[3].Transitions = new DfaTrans[0] {};
                
                /* dfa 17 -- '..' -- */
                var states17 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,25)};
                states17[0].Transitions = new DfaTrans[1] {new DfaTrans(states17[1], sets[31])};
                states17[1].Transitions = new DfaTrans[1] {new DfaTrans(states17[2], sets[31])};
                states17[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 18 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states18 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,16), new DfaState(15,true,17), new DfaState(16,true,23), new DfaState(17,true,2), new DfaState(18,true,25), new DfaState(19,true,12), new DfaState(20,true,15), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,14), new DfaState(51,true,24)};
                states18[0].Transitions = new DfaTrans[14] {new DfaTrans(states18[1], sets[21]), new DfaTrans(states18[13], sets[22]), new DfaTrans(states18[14], sets[41]), new DfaTrans(states18[15], sets[35]), new DfaTrans(states18[16], sets[18]), new DfaTrans(states18[17], sets[31]), new DfaTrans(states18[19], sets[24]), new DfaTrans(states18[20], sets[42]), new DfaTrans(states18[21], sets[32]), new DfaTrans(states18[22], sets[33]), new DfaTrans(states18[30], sets[28]), new DfaTrans(states18[49], sets[6]), new DfaTrans(states18[50], sets[26]), new DfaTrans(states18[51], sets[34])};
                states18[1].Transitions = new DfaTrans[2] {new DfaTrans(states18[2], sets[27]), new DfaTrans(states18[4], sets[28])};
                states18[2].Transitions = new DfaTrans[3] {new DfaTrans(states18[2], sets[27]), new DfaTrans(states18[3], sets[21]), new DfaTrans(states18[4], sets[28])};
                states18[3].Transitions = new DfaTrans[0] {};
                states18[4].Transitions = new DfaTrans[2] {new DfaTrans(states18[2], sets[29]), new DfaTrans(states18[5], sets[14])};
                states18[5].Transitions = new DfaTrans[1] {new DfaTrans(states18[6], sets[6])};
                states18[6].Transitions = new DfaTrans[1] {new DfaTrans(states18[7], sets[30])};
                states18[7].Transitions = new DfaTrans[2] {new DfaTrans(states18[8], sets[30]), new DfaTrans(states18[2], sets[9])};
                states18[8].Transitions = new DfaTrans[2] {new DfaTrans(states18[9], sets[30]), new DfaTrans(states18[2], sets[9])};
                states18[9].Transitions = new DfaTrans[2] {new DfaTrans(states18[10], sets[30]), new DfaTrans(states18[2], sets[9])};
                states18[10].Transitions = new DfaTrans[2] {new DfaTrans(states18[11], sets[30]), new DfaTrans(states18[2], sets[9])};
                states18[11].Transitions = new DfaTrans[2] {new DfaTrans(states18[12], sets[30]), new DfaTrans(states18[2], sets[9])};
                states18[12].Transitions = new DfaTrans[1] {new DfaTrans(states18[2], sets[9])};
                states18[13].Transitions = new DfaTrans[0] {};
                states18[14].Transitions = new DfaTrans[0] {};
                states18[15].Transitions = new DfaTrans[0] {};
                states18[16].Transitions = new DfaTrans[0] {};
                states18[17].Transitions = new DfaTrans[1] {new DfaTrans(states18[18], sets[31])};
                states18[18].Transitions = new DfaTrans[0] {};
                states18[19].Transitions = new DfaTrans[0] {};
                states18[20].Transitions = new DfaTrans[0] {};
                states18[21].Transitions = new DfaTrans[1] {new DfaTrans(states18[21], sets[5])};
                states18[22].Transitions = new DfaTrans[2] {new DfaTrans(states18[23], sets[35]), new DfaTrans(states18[21], sets[5])};
                states18[23].Transitions = new DfaTrans[1] {new DfaTrans(states18[24], sets[30])};
                states18[24].Transitions = new DfaTrans[1] {new DfaTrans(states18[25], sets[30])};
                states18[25].Transitions = new DfaTrans[1] {new DfaTrans(states18[26], sets[30])};
                states18[26].Transitions = new DfaTrans[1] {new DfaTrans(states18[27], sets[30])};
                states18[27].Transitions = new DfaTrans[1] {new DfaTrans(states18[28], sets[30])};
                states18[28].Transitions = new DfaTrans[1] {new DfaTrans(states18[29], sets[30])};
                states18[29].Transitions = new DfaTrans[0] {};
                states18[30].Transitions = new DfaTrans[1] {new DfaTrans(states18[31], sets[14])};
                states18[31].Transitions = new DfaTrans[3] {new DfaTrans(states18[32], sets[36]), new DfaTrans(states18[37], sets[37]), new DfaTrans(states18[42], sets[6])};
                states18[32].Transitions = new DfaTrans[1] {new DfaTrans(states18[33], sets[6])};
                states18[33].Transitions = new DfaTrans[1] {new DfaTrans(states18[34], sets[38])};
                states18[34].Transitions = new DfaTrans[3] {new DfaTrans(states18[35], sets[39]), new DfaTrans(states18[34], sets[40]), new DfaTrans(states18[36], sets[9])};
                states18[35].Transitions = new DfaTrans[2] {new DfaTrans(states18[35], sets[39]), new DfaTrans(states18[34], sets[40])};
                states18[36].Transitions = new DfaTrans[0] {};
                states18[37].Transitions = new DfaTrans[1] {new DfaTrans(states18[38], sets[6])};
                states18[38].Transitions = new DfaTrans[1] {new DfaTrans(states18[39], sets[38])};
                states18[39].Transitions = new DfaTrans[3] {new DfaTrans(states18[40], sets[39]), new DfaTrans(states18[39], sets[40]), new DfaTrans(states18[41], sets[9])};
                states18[40].Transitions = new DfaTrans[2] {new DfaTrans(states18[40], sets[39]), new DfaTrans(states18[39], sets[40])};
                states18[41].Transitions = new DfaTrans[0] {};
                states18[42].Transitions = new DfaTrans[1] {new DfaTrans(states18[43], sets[30])};
                states18[43].Transitions = new DfaTrans[2] {new DfaTrans(states18[44], sets[30]), new DfaTrans(states18[29], sets[9])};
                states18[44].Transitions = new DfaTrans[2] {new DfaTrans(states18[45], sets[30]), new DfaTrans(states18[29], sets[9])};
                states18[45].Transitions = new DfaTrans[2] {new DfaTrans(states18[46], sets[30]), new DfaTrans(states18[29], sets[9])};
                states18[46].Transitions = new DfaTrans[2] {new DfaTrans(states18[47], sets[30]), new DfaTrans(states18[29], sets[9])};
                states18[47].Transitions = new DfaTrans[2] {new DfaTrans(states18[48], sets[30]), new DfaTrans(states18[29], sets[9])};
                states18[48].Transitions = new DfaTrans[1] {new DfaTrans(states18[29], sets[9])};
                states18[49].Transitions = new DfaTrans[0] {};
                states18[50].Transitions = new DfaTrans[0] {};
                states18[51].Transitions = new DfaTrans[0] {};
                
                /* dfa 19 -- ˈtextˈ | '(' | ')' | '-' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states19 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,23), new DfaState(16,true,2), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,14), new DfaState(46,true,24)};
                states19[0].Transitions = new DfaTrans[10] {new DfaTrans(states19[1], sets[21]), new DfaTrans(states19[13], sets[22]), new DfaTrans(states19[14], sets[43]), new DfaTrans(states19[15], sets[18]), new DfaTrans(states19[16], sets[31]), new DfaTrans(states19[17], sets[32]), new DfaTrans(states19[18], sets[33]), new DfaTrans(states19[26], sets[28]), new DfaTrans(states19[45], sets[26]), new DfaTrans(states19[46], sets[34])};
                states19[1].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[27]), new DfaTrans(states19[4], sets[28])};
                states19[2].Transitions = new DfaTrans[3] {new DfaTrans(states19[2], sets[27]), new DfaTrans(states19[3], sets[21]), new DfaTrans(states19[4], sets[28])};
                states19[3].Transitions = new DfaTrans[0] {};
                states19[4].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[29]), new DfaTrans(states19[5], sets[14])};
                states19[5].Transitions = new DfaTrans[1] {new DfaTrans(states19[6], sets[6])};
                states19[6].Transitions = new DfaTrans[1] {new DfaTrans(states19[7], sets[30])};
                states19[7].Transitions = new DfaTrans[2] {new DfaTrans(states19[8], sets[30]), new DfaTrans(states19[2], sets[9])};
                states19[8].Transitions = new DfaTrans[2] {new DfaTrans(states19[9], sets[30]), new DfaTrans(states19[2], sets[9])};
                states19[9].Transitions = new DfaTrans[2] {new DfaTrans(states19[10], sets[30]), new DfaTrans(states19[2], sets[9])};
                states19[10].Transitions = new DfaTrans[2] {new DfaTrans(states19[11], sets[30]), new DfaTrans(states19[2], sets[9])};
                states19[11].Transitions = new DfaTrans[2] {new DfaTrans(states19[12], sets[30]), new DfaTrans(states19[2], sets[9])};
                states19[12].Transitions = new DfaTrans[1] {new DfaTrans(states19[2], sets[9])};
                states19[13].Transitions = new DfaTrans[0] {};
                states19[14].Transitions = new DfaTrans[0] {};
                states19[15].Transitions = new DfaTrans[0] {};
                states19[16].Transitions = new DfaTrans[0] {};
                states19[17].Transitions = new DfaTrans[1] {new DfaTrans(states19[17], sets[5])};
                states19[18].Transitions = new DfaTrans[2] {new DfaTrans(states19[19], sets[35]), new DfaTrans(states19[17], sets[5])};
                states19[19].Transitions = new DfaTrans[1] {new DfaTrans(states19[20], sets[30])};
                states19[20].Transitions = new DfaTrans[1] {new DfaTrans(states19[21], sets[30])};
                states19[21].Transitions = new DfaTrans[1] {new DfaTrans(states19[22], sets[30])};
                states19[22].Transitions = new DfaTrans[1] {new DfaTrans(states19[23], sets[30])};
                states19[23].Transitions = new DfaTrans[1] {new DfaTrans(states19[24], sets[30])};
                states19[24].Transitions = new DfaTrans[1] {new DfaTrans(states19[25], sets[30])};
                states19[25].Transitions = new DfaTrans[0] {};
                states19[26].Transitions = new DfaTrans[1] {new DfaTrans(states19[27], sets[14])};
                states19[27].Transitions = new DfaTrans[3] {new DfaTrans(states19[28], sets[36]), new DfaTrans(states19[33], sets[37]), new DfaTrans(states19[38], sets[6])};
                states19[28].Transitions = new DfaTrans[1] {new DfaTrans(states19[29], sets[6])};
                states19[29].Transitions = new DfaTrans[1] {new DfaTrans(states19[30], sets[38])};
                states19[30].Transitions = new DfaTrans[3] {new DfaTrans(states19[31], sets[39]), new DfaTrans(states19[30], sets[40]), new DfaTrans(states19[32], sets[9])};
                states19[31].Transitions = new DfaTrans[2] {new DfaTrans(states19[31], sets[39]), new DfaTrans(states19[30], sets[40])};
                states19[32].Transitions = new DfaTrans[0] {};
                states19[33].Transitions = new DfaTrans[1] {new DfaTrans(states19[34], sets[6])};
                states19[34].Transitions = new DfaTrans[1] {new DfaTrans(states19[35], sets[38])};
                states19[35].Transitions = new DfaTrans[3] {new DfaTrans(states19[36], sets[39]), new DfaTrans(states19[35], sets[40]), new DfaTrans(states19[37], sets[9])};
                states19[36].Transitions = new DfaTrans[2] {new DfaTrans(states19[36], sets[39]), new DfaTrans(states19[35], sets[40])};
                states19[37].Transitions = new DfaTrans[0] {};
                states19[38].Transitions = new DfaTrans[1] {new DfaTrans(states19[39], sets[30])};
                states19[39].Transitions = new DfaTrans[2] {new DfaTrans(states19[40], sets[30]), new DfaTrans(states19[25], sets[9])};
                states19[40].Transitions = new DfaTrans[2] {new DfaTrans(states19[41], sets[30]), new DfaTrans(states19[25], sets[9])};
                states19[41].Transitions = new DfaTrans[2] {new DfaTrans(states19[42], sets[30]), new DfaTrans(states19[25], sets[9])};
                states19[42].Transitions = new DfaTrans[2] {new DfaTrans(states19[43], sets[30]), new DfaTrans(states19[25], sets[9])};
                states19[43].Transitions = new DfaTrans[2] {new DfaTrans(states19[44], sets[30]), new DfaTrans(states19[25], sets[9])};
                states19[44].Transitions = new DfaTrans[1] {new DfaTrans(states19[25], sets[9])};
                states19[45].Transitions = new DfaTrans[0] {};
                states19[46].Transitions = new DfaTrans[0] {};
                
                /* dfa 20 -- ˈtextˈ | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ -- */
                var states20 = new DfaState[42] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,2), new DfaState(14,true,0), new DfaState(15,true,0), new DfaState(16,false,-1), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,true,4), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,5), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1)};
                states20[0].Transitions = new DfaTrans[5] {new DfaTrans(states20[1], sets[21]), new DfaTrans(states20[13], sets[31]), new DfaTrans(states20[14], sets[32]), new DfaTrans(states20[15], sets[33]), new DfaTrans(states20[23], sets[28])};
                states20[1].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[27]), new DfaTrans(states20[4], sets[28])};
                states20[2].Transitions = new DfaTrans[3] {new DfaTrans(states20[2], sets[27]), new DfaTrans(states20[3], sets[21]), new DfaTrans(states20[4], sets[28])};
                states20[3].Transitions = new DfaTrans[0] {};
                states20[4].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[29]), new DfaTrans(states20[5], sets[14])};
                states20[5].Transitions = new DfaTrans[1] {new DfaTrans(states20[6], sets[6])};
                states20[6].Transitions = new DfaTrans[1] {new DfaTrans(states20[7], sets[30])};
                states20[7].Transitions = new DfaTrans[2] {new DfaTrans(states20[8], sets[30]), new DfaTrans(states20[2], sets[9])};
                states20[8].Transitions = new DfaTrans[2] {new DfaTrans(states20[9], sets[30]), new DfaTrans(states20[2], sets[9])};
                states20[9].Transitions = new DfaTrans[2] {new DfaTrans(states20[10], sets[30]), new DfaTrans(states20[2], sets[9])};
                states20[10].Transitions = new DfaTrans[2] {new DfaTrans(states20[11], sets[30]), new DfaTrans(states20[2], sets[9])};
                states20[11].Transitions = new DfaTrans[2] {new DfaTrans(states20[12], sets[30]), new DfaTrans(states20[2], sets[9])};
                states20[12].Transitions = new DfaTrans[1] {new DfaTrans(states20[2], sets[9])};
                states20[13].Transitions = new DfaTrans[0] {};
                states20[14].Transitions = new DfaTrans[1] {new DfaTrans(states20[14], sets[5])};
                states20[15].Transitions = new DfaTrans[2] {new DfaTrans(states20[16], sets[35]), new DfaTrans(states20[14], sets[5])};
                states20[16].Transitions = new DfaTrans[1] {new DfaTrans(states20[17], sets[30])};
                states20[17].Transitions = new DfaTrans[1] {new DfaTrans(states20[18], sets[30])};
                states20[18].Transitions = new DfaTrans[1] {new DfaTrans(states20[19], sets[30])};
                states20[19].Transitions = new DfaTrans[1] {new DfaTrans(states20[20], sets[30])};
                states20[20].Transitions = new DfaTrans[1] {new DfaTrans(states20[21], sets[30])};
                states20[21].Transitions = new DfaTrans[1] {new DfaTrans(states20[22], sets[30])};
                states20[22].Transitions = new DfaTrans[0] {};
                states20[23].Transitions = new DfaTrans[1] {new DfaTrans(states20[24], sets[14])};
                states20[24].Transitions = new DfaTrans[3] {new DfaTrans(states20[25], sets[36]), new DfaTrans(states20[30], sets[37]), new DfaTrans(states20[35], sets[6])};
                states20[25].Transitions = new DfaTrans[1] {new DfaTrans(states20[26], sets[6])};
                states20[26].Transitions = new DfaTrans[1] {new DfaTrans(states20[27], sets[38])};
                states20[27].Transitions = new DfaTrans[3] {new DfaTrans(states20[28], sets[39]), new DfaTrans(states20[27], sets[40]), new DfaTrans(states20[29], sets[9])};
                states20[28].Transitions = new DfaTrans[2] {new DfaTrans(states20[28], sets[39]), new DfaTrans(states20[27], sets[40])};
                states20[29].Transitions = new DfaTrans[0] {};
                states20[30].Transitions = new DfaTrans[1] {new DfaTrans(states20[31], sets[6])};
                states20[31].Transitions = new DfaTrans[1] {new DfaTrans(states20[32], sets[38])};
                states20[32].Transitions = new DfaTrans[3] {new DfaTrans(states20[33], sets[39]), new DfaTrans(states20[32], sets[40]), new DfaTrans(states20[34], sets[9])};
                states20[33].Transitions = new DfaTrans[2] {new DfaTrans(states20[33], sets[39]), new DfaTrans(states20[32], sets[40])};
                states20[34].Transitions = new DfaTrans[0] {};
                states20[35].Transitions = new DfaTrans[1] {new DfaTrans(states20[36], sets[30])};
                states20[36].Transitions = new DfaTrans[2] {new DfaTrans(states20[37], sets[30]), new DfaTrans(states20[22], sets[9])};
                states20[37].Transitions = new DfaTrans[2] {new DfaTrans(states20[38], sets[30]), new DfaTrans(states20[22], sets[9])};
                states20[38].Transitions = new DfaTrans[2] {new DfaTrans(states20[39], sets[30]), new DfaTrans(states20[22], sets[9])};
                states20[39].Transitions = new DfaTrans[2] {new DfaTrans(states20[40], sets[30]), new DfaTrans(states20[22], sets[9])};
                states20[40].Transitions = new DfaTrans[2] {new DfaTrans(states20[41], sets[30]), new DfaTrans(states20[22], sets[9])};
                states20[41].Transitions = new DfaTrans[1] {new DfaTrans(states20[22], sets[9])};
                
                /* dfa 21 -- ')' -- */
                var states21 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,21)};
                states21[0].Transitions = new DfaTrans[1] {new DfaTrans(states21[1], sets[43])};
                states21[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 22 -- ')' | '|' -- */
                var states22 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,21), new DfaState(2,true,14)};
                states22[0].Transitions = new DfaTrans[2] {new DfaTrans(states22[1], sets[43]), new DfaTrans(states22[2], sets[26])};
                states22[1].Transitions = new DfaTrans[0] {};
                states22[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 23 -- ˈtextˈ | '(' | ')' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states23 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,16), new DfaState(16,true,17), new DfaState(17,true,18), new DfaState(18,true,15), new DfaState(19,true,0), new DfaState(20,true,19), new DfaState(21,true,8), new DfaState(22,true,14)};
                states23[0].Transitions = new DfaTrans[11] {new DfaTrans(states23[1], sets[21]), new DfaTrans(states23[13], sets[22]), new DfaTrans(states23[14], sets[43]), new DfaTrans(states23[15], sets[41]), new DfaTrans(states23[16], sets[35]), new DfaTrans(states23[17], sets[23]), new DfaTrans(states23[18], sets[42]), new DfaTrans(states23[19], sets[4]), new DfaTrans(states23[20], sets[25]), new DfaTrans(states23[21], sets[6]), new DfaTrans(states23[22], sets[26])};
                states23[1].Transitions = new DfaTrans[2] {new DfaTrans(states23[2], sets[27]), new DfaTrans(states23[4], sets[28])};
                states23[2].Transitions = new DfaTrans[3] {new DfaTrans(states23[2], sets[27]), new DfaTrans(states23[3], sets[21]), new DfaTrans(states23[4], sets[28])};
                states23[3].Transitions = new DfaTrans[0] {};
                states23[4].Transitions = new DfaTrans[2] {new DfaTrans(states23[2], sets[29]), new DfaTrans(states23[5], sets[14])};
                states23[5].Transitions = new DfaTrans[1] {new DfaTrans(states23[6], sets[6])};
                states23[6].Transitions = new DfaTrans[1] {new DfaTrans(states23[7], sets[30])};
                states23[7].Transitions = new DfaTrans[2] {new DfaTrans(states23[8], sets[30]), new DfaTrans(states23[2], sets[9])};
                states23[8].Transitions = new DfaTrans[2] {new DfaTrans(states23[9], sets[30]), new DfaTrans(states23[2], sets[9])};
                states23[9].Transitions = new DfaTrans[2] {new DfaTrans(states23[10], sets[30]), new DfaTrans(states23[2], sets[9])};
                states23[10].Transitions = new DfaTrans[2] {new DfaTrans(states23[11], sets[30]), new DfaTrans(states23[2], sets[9])};
                states23[11].Transitions = new DfaTrans[2] {new DfaTrans(states23[12], sets[30]), new DfaTrans(states23[2], sets[9])};
                states23[12].Transitions = new DfaTrans[1] {new DfaTrans(states23[2], sets[9])};
                states23[13].Transitions = new DfaTrans[0] {};
                states23[14].Transitions = new DfaTrans[0] {};
                states23[15].Transitions = new DfaTrans[0] {};
                states23[16].Transitions = new DfaTrans[0] {};
                states23[17].Transitions = new DfaTrans[0] {};
                states23[18].Transitions = new DfaTrans[0] {};
                states23[19].Transitions = new DfaTrans[1] {new DfaTrans(states23[19], sets[5])};
                states23[20].Transitions = new DfaTrans[0] {};
                states23[21].Transitions = new DfaTrans[0] {};
                states23[22].Transitions = new DfaTrans[0] {};
                
                /* dfa 24 -- ˈtextˈ | '(' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states24 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,2), new DfaState(15,true,12), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,14), new DfaState(45,true,24)};
                states24[0].Transitions = new DfaTrans[9] {new DfaTrans(states24[1], sets[21]), new DfaTrans(states24[13], sets[22]), new DfaTrans(states24[14], sets[31]), new DfaTrans(states24[15], sets[24]), new DfaTrans(states24[16], sets[32]), new DfaTrans(states24[17], sets[33]), new DfaTrans(states24[25], sets[28]), new DfaTrans(states24[44], sets[26]), new DfaTrans(states24[45], sets[34])};
                states24[1].Transitions = new DfaTrans[2] {new DfaTrans(states24[2], sets[27]), new DfaTrans(states24[4], sets[28])};
                states24[2].Transitions = new DfaTrans[3] {new DfaTrans(states24[2], sets[27]), new DfaTrans(states24[3], sets[21]), new DfaTrans(states24[4], sets[28])};
                states24[3].Transitions = new DfaTrans[0] {};
                states24[4].Transitions = new DfaTrans[2] {new DfaTrans(states24[2], sets[29]), new DfaTrans(states24[5], sets[14])};
                states24[5].Transitions = new DfaTrans[1] {new DfaTrans(states24[6], sets[6])};
                states24[6].Transitions = new DfaTrans[1] {new DfaTrans(states24[7], sets[30])};
                states24[7].Transitions = new DfaTrans[2] {new DfaTrans(states24[8], sets[30]), new DfaTrans(states24[2], sets[9])};
                states24[8].Transitions = new DfaTrans[2] {new DfaTrans(states24[9], sets[30]), new DfaTrans(states24[2], sets[9])};
                states24[9].Transitions = new DfaTrans[2] {new DfaTrans(states24[10], sets[30]), new DfaTrans(states24[2], sets[9])};
                states24[10].Transitions = new DfaTrans[2] {new DfaTrans(states24[11], sets[30]), new DfaTrans(states24[2], sets[9])};
                states24[11].Transitions = new DfaTrans[2] {new DfaTrans(states24[12], sets[30]), new DfaTrans(states24[2], sets[9])};
                states24[12].Transitions = new DfaTrans[1] {new DfaTrans(states24[2], sets[9])};
                states24[13].Transitions = new DfaTrans[0] {};
                states24[14].Transitions = new DfaTrans[0] {};
                states24[15].Transitions = new DfaTrans[0] {};
                states24[16].Transitions = new DfaTrans[1] {new DfaTrans(states24[16], sets[5])};
                states24[17].Transitions = new DfaTrans[2] {new DfaTrans(states24[18], sets[35]), new DfaTrans(states24[16], sets[5])};
                states24[18].Transitions = new DfaTrans[1] {new DfaTrans(states24[19], sets[30])};
                states24[19].Transitions = new DfaTrans[1] {new DfaTrans(states24[20], sets[30])};
                states24[20].Transitions = new DfaTrans[1] {new DfaTrans(states24[21], sets[30])};
                states24[21].Transitions = new DfaTrans[1] {new DfaTrans(states24[22], sets[30])};
                states24[22].Transitions = new DfaTrans[1] {new DfaTrans(states24[23], sets[30])};
                states24[23].Transitions = new DfaTrans[1] {new DfaTrans(states24[24], sets[30])};
                states24[24].Transitions = new DfaTrans[0] {};
                states24[25].Transitions = new DfaTrans[1] {new DfaTrans(states24[26], sets[14])};
                states24[26].Transitions = new DfaTrans[3] {new DfaTrans(states24[27], sets[36]), new DfaTrans(states24[32], sets[37]), new DfaTrans(states24[37], sets[6])};
                states24[27].Transitions = new DfaTrans[1] {new DfaTrans(states24[28], sets[6])};
                states24[28].Transitions = new DfaTrans[1] {new DfaTrans(states24[29], sets[38])};
                states24[29].Transitions = new DfaTrans[3] {new DfaTrans(states24[30], sets[39]), new DfaTrans(states24[29], sets[40]), new DfaTrans(states24[31], sets[9])};
                states24[30].Transitions = new DfaTrans[2] {new DfaTrans(states24[30], sets[39]), new DfaTrans(states24[29], sets[40])};
                states24[31].Transitions = new DfaTrans[0] {};
                states24[32].Transitions = new DfaTrans[1] {new DfaTrans(states24[33], sets[6])};
                states24[33].Transitions = new DfaTrans[1] {new DfaTrans(states24[34], sets[38])};
                states24[34].Transitions = new DfaTrans[3] {new DfaTrans(states24[35], sets[39]), new DfaTrans(states24[34], sets[40]), new DfaTrans(states24[36], sets[9])};
                states24[35].Transitions = new DfaTrans[2] {new DfaTrans(states24[35], sets[39]), new DfaTrans(states24[34], sets[40])};
                states24[36].Transitions = new DfaTrans[0] {};
                states24[37].Transitions = new DfaTrans[1] {new DfaTrans(states24[38], sets[30])};
                states24[38].Transitions = new DfaTrans[2] {new DfaTrans(states24[39], sets[30]), new DfaTrans(states24[24], sets[9])};
                states24[39].Transitions = new DfaTrans[2] {new DfaTrans(states24[40], sets[30]), new DfaTrans(states24[24], sets[9])};
                states24[40].Transitions = new DfaTrans[2] {new DfaTrans(states24[41], sets[30]), new DfaTrans(states24[24], sets[9])};
                states24[41].Transitions = new DfaTrans[2] {new DfaTrans(states24[42], sets[30]), new DfaTrans(states24[24], sets[9])};
                states24[42].Transitions = new DfaTrans[2] {new DfaTrans(states24[43], sets[30]), new DfaTrans(states24[24], sets[9])};
                states24[43].Transitions = new DfaTrans[1] {new DfaTrans(states24[24], sets[9])};
                states24[44].Transitions = new DfaTrans[0] {};
                states24[45].Transitions = new DfaTrans[0] {};
                
                /* dfa 25 -- ˈnumberˈ -- */
                var states25 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,1), new DfaState(2,true,1)};
                states25[0].Transitions = new DfaTrans[2] {new DfaTrans(states25[1], sets[44]), new DfaTrans(states25[2], sets[45])};
                states25[1].Transitions = new DfaTrans[0] {};
                states25[2].Transitions = new DfaTrans[1] {new DfaTrans(states25[2], sets[46])};
                
                /* dfa 26 -- ˈtextˈ | ˈucCodepointˈ -- */
                var states26 = new DfaState[30] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,true,6), new DfaState(16,true,6), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,false,-1), new DfaState(22,false,-1), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1)};
                states26[0].Transitions = new DfaTrans[3] {new DfaTrans(states26[1], sets[21]), new DfaTrans(states26[13], sets[33]), new DfaTrans(states26[21], sets[28])};
                states26[1].Transitions = new DfaTrans[2] {new DfaTrans(states26[2], sets[27]), new DfaTrans(states26[4], sets[28])};
                states26[2].Transitions = new DfaTrans[3] {new DfaTrans(states26[2], sets[27]), new DfaTrans(states26[3], sets[21]), new DfaTrans(states26[4], sets[28])};
                states26[3].Transitions = new DfaTrans[0] {};
                states26[4].Transitions = new DfaTrans[2] {new DfaTrans(states26[2], sets[29]), new DfaTrans(states26[5], sets[14])};
                states26[5].Transitions = new DfaTrans[1] {new DfaTrans(states26[6], sets[6])};
                states26[6].Transitions = new DfaTrans[1] {new DfaTrans(states26[7], sets[30])};
                states26[7].Transitions = new DfaTrans[2] {new DfaTrans(states26[8], sets[30]), new DfaTrans(states26[2], sets[9])};
                states26[8].Transitions = new DfaTrans[2] {new DfaTrans(states26[9], sets[30]), new DfaTrans(states26[2], sets[9])};
                states26[9].Transitions = new DfaTrans[2] {new DfaTrans(states26[10], sets[30]), new DfaTrans(states26[2], sets[9])};
                states26[10].Transitions = new DfaTrans[2] {new DfaTrans(states26[11], sets[30]), new DfaTrans(states26[2], sets[9])};
                states26[11].Transitions = new DfaTrans[2] {new DfaTrans(states26[12], sets[30]), new DfaTrans(states26[2], sets[9])};
                states26[12].Transitions = new DfaTrans[1] {new DfaTrans(states26[2], sets[9])};
                states26[13].Transitions = new DfaTrans[1] {new DfaTrans(states26[14], sets[35])};
                states26[14].Transitions = new DfaTrans[1] {new DfaTrans(states26[15], sets[30])};
                states26[15].Transitions = new DfaTrans[1] {new DfaTrans(states26[16], sets[30])};
                states26[16].Transitions = new DfaTrans[1] {new DfaTrans(states26[17], sets[30])};
                states26[17].Transitions = new DfaTrans[1] {new DfaTrans(states26[18], sets[30])};
                states26[18].Transitions = new DfaTrans[1] {new DfaTrans(states26[19], sets[30])};
                states26[19].Transitions = new DfaTrans[1] {new DfaTrans(states26[20], sets[30])};
                states26[20].Transitions = new DfaTrans[0] {};
                states26[21].Transitions = new DfaTrans[1] {new DfaTrans(states26[22], sets[14])};
                states26[22].Transitions = new DfaTrans[1] {new DfaTrans(states26[23], sets[6])};
                states26[23].Transitions = new DfaTrans[1] {new DfaTrans(states26[24], sets[30])};
                states26[24].Transitions = new DfaTrans[2] {new DfaTrans(states26[25], sets[30]), new DfaTrans(states26[20], sets[9])};
                states26[25].Transitions = new DfaTrans[2] {new DfaTrans(states26[26], sets[30]), new DfaTrans(states26[20], sets[9])};
                states26[26].Transitions = new DfaTrans[2] {new DfaTrans(states26[27], sets[30]), new DfaTrans(states26[20], sets[9])};
                states26[27].Transitions = new DfaTrans[2] {new DfaTrans(states26[28], sets[30]), new DfaTrans(states26[20], sets[9])};
                states26[28].Transitions = new DfaTrans[2] {new DfaTrans(states26[29], sets[30]), new DfaTrans(states26[20], sets[9])};
                states26[29].Transitions = new DfaTrans[1] {new DfaTrans(states26[20], sets[9])};
                
                /* dfa 27 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states27 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,16), new DfaState(16,true,17), new DfaState(17,true,23), new DfaState(18,true,2), new DfaState(19,true,15), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,14), new DfaState(50,true,24)};
                states27[0].Transitions = new DfaTrans[14] {new DfaTrans(states27[1], sets[21]), new DfaTrans(states27[13], sets[22]), new DfaTrans(states27[14], sets[43]), new DfaTrans(states27[15], sets[41]), new DfaTrans(states27[16], sets[35]), new DfaTrans(states27[17], sets[18]), new DfaTrans(states27[18], sets[31]), new DfaTrans(states27[19], sets[42]), new DfaTrans(states27[20], sets[32]), new DfaTrans(states27[21], sets[33]), new DfaTrans(states27[29], sets[28]), new DfaTrans(states27[48], sets[6]), new DfaTrans(states27[49], sets[26]), new DfaTrans(states27[50], sets[34])};
                states27[1].Transitions = new DfaTrans[2] {new DfaTrans(states27[2], sets[27]), new DfaTrans(states27[4], sets[28])};
                states27[2].Transitions = new DfaTrans[3] {new DfaTrans(states27[2], sets[27]), new DfaTrans(states27[3], sets[21]), new DfaTrans(states27[4], sets[28])};
                states27[3].Transitions = new DfaTrans[0] {};
                states27[4].Transitions = new DfaTrans[2] {new DfaTrans(states27[2], sets[29]), new DfaTrans(states27[5], sets[14])};
                states27[5].Transitions = new DfaTrans[1] {new DfaTrans(states27[6], sets[6])};
                states27[6].Transitions = new DfaTrans[1] {new DfaTrans(states27[7], sets[30])};
                states27[7].Transitions = new DfaTrans[2] {new DfaTrans(states27[8], sets[30]), new DfaTrans(states27[2], sets[9])};
                states27[8].Transitions = new DfaTrans[2] {new DfaTrans(states27[9], sets[30]), new DfaTrans(states27[2], sets[9])};
                states27[9].Transitions = new DfaTrans[2] {new DfaTrans(states27[10], sets[30]), new DfaTrans(states27[2], sets[9])};
                states27[10].Transitions = new DfaTrans[2] {new DfaTrans(states27[11], sets[30]), new DfaTrans(states27[2], sets[9])};
                states27[11].Transitions = new DfaTrans[2] {new DfaTrans(states27[12], sets[30]), new DfaTrans(states27[2], sets[9])};
                states27[12].Transitions = new DfaTrans[1] {new DfaTrans(states27[2], sets[9])};
                states27[13].Transitions = new DfaTrans[0] {};
                states27[14].Transitions = new DfaTrans[0] {};
                states27[15].Transitions = new DfaTrans[0] {};
                states27[16].Transitions = new DfaTrans[0] {};
                states27[17].Transitions = new DfaTrans[0] {};
                states27[18].Transitions = new DfaTrans[0] {};
                states27[19].Transitions = new DfaTrans[0] {};
                states27[20].Transitions = new DfaTrans[1] {new DfaTrans(states27[20], sets[5])};
                states27[21].Transitions = new DfaTrans[2] {new DfaTrans(states27[22], sets[35]), new DfaTrans(states27[20], sets[5])};
                states27[22].Transitions = new DfaTrans[1] {new DfaTrans(states27[23], sets[30])};
                states27[23].Transitions = new DfaTrans[1] {new DfaTrans(states27[24], sets[30])};
                states27[24].Transitions = new DfaTrans[1] {new DfaTrans(states27[25], sets[30])};
                states27[25].Transitions = new DfaTrans[1] {new DfaTrans(states27[26], sets[30])};
                states27[26].Transitions = new DfaTrans[1] {new DfaTrans(states27[27], sets[30])};
                states27[27].Transitions = new DfaTrans[1] {new DfaTrans(states27[28], sets[30])};
                states27[28].Transitions = new DfaTrans[0] {};
                states27[29].Transitions = new DfaTrans[1] {new DfaTrans(states27[30], sets[14])};
                states27[30].Transitions = new DfaTrans[3] {new DfaTrans(states27[31], sets[36]), new DfaTrans(states27[36], sets[37]), new DfaTrans(states27[41], sets[6])};
                states27[31].Transitions = new DfaTrans[1] {new DfaTrans(states27[32], sets[6])};
                states27[32].Transitions = new DfaTrans[1] {new DfaTrans(states27[33], sets[38])};
                states27[33].Transitions = new DfaTrans[3] {new DfaTrans(states27[34], sets[39]), new DfaTrans(states27[33], sets[40]), new DfaTrans(states27[35], sets[9])};
                states27[34].Transitions = new DfaTrans[2] {new DfaTrans(states27[34], sets[39]), new DfaTrans(states27[33], sets[40])};
                states27[35].Transitions = new DfaTrans[0] {};
                states27[36].Transitions = new DfaTrans[1] {new DfaTrans(states27[37], sets[6])};
                states27[37].Transitions = new DfaTrans[1] {new DfaTrans(states27[38], sets[38])};
                states27[38].Transitions = new DfaTrans[3] {new DfaTrans(states27[39], sets[39]), new DfaTrans(states27[38], sets[40]), new DfaTrans(states27[40], sets[9])};
                states27[39].Transitions = new DfaTrans[2] {new DfaTrans(states27[39], sets[39]), new DfaTrans(states27[38], sets[40])};
                states27[40].Transitions = new DfaTrans[0] {};
                states27[41].Transitions = new DfaTrans[1] {new DfaTrans(states27[42], sets[30])};
                states27[42].Transitions = new DfaTrans[2] {new DfaTrans(states27[43], sets[30]), new DfaTrans(states27[28], sets[9])};
                states27[43].Transitions = new DfaTrans[2] {new DfaTrans(states27[44], sets[30]), new DfaTrans(states27[28], sets[9])};
                states27[44].Transitions = new DfaTrans[2] {new DfaTrans(states27[45], sets[30]), new DfaTrans(states27[28], sets[9])};
                states27[45].Transitions = new DfaTrans[2] {new DfaTrans(states27[46], sets[30]), new DfaTrans(states27[28], sets[9])};
                states27[46].Transitions = new DfaTrans[2] {new DfaTrans(states27[47], sets[30]), new DfaTrans(states27[28], sets[9])};
                states27[47].Transitions = new DfaTrans[1] {new DfaTrans(states27[28], sets[9])};
                states27[48].Transitions = new DfaTrans[0] {};
                states27[49].Transitions = new DfaTrans[0] {};
                states27[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 28 -- ')' | '-' | '|' -- */
                var states28 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,21), new DfaState(2,true,23), new DfaState(3,true,14)};
                states28[0].Transitions = new DfaTrans[3] {new DfaTrans(states28[1], sets[43]), new DfaTrans(states28[2], sets[18]), new DfaTrans(states28[3], sets[26])};
                states28[1].Transitions = new DfaTrans[0] {};
                states28[2].Transitions = new DfaTrans[0] {};
                states28[3].Transitions = new DfaTrans[0] {};
                
                /* dfa 29 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states29 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,16), new DfaState(16,true,17), new DfaState(17,true,23), new DfaState(18,true,2), new DfaState(19,true,25), new DfaState(20,true,15), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,14), new DfaState(51,true,24)};
                states29[0].Transitions = new DfaTrans[14] {new DfaTrans(states29[1], sets[21]), new DfaTrans(states29[13], sets[22]), new DfaTrans(states29[14], sets[43]), new DfaTrans(states29[15], sets[41]), new DfaTrans(states29[16], sets[35]), new DfaTrans(states29[17], sets[18]), new DfaTrans(states29[18], sets[31]), new DfaTrans(states29[20], sets[42]), new DfaTrans(states29[21], sets[32]), new DfaTrans(states29[22], sets[33]), new DfaTrans(states29[30], sets[28]), new DfaTrans(states29[49], sets[6]), new DfaTrans(states29[50], sets[26]), new DfaTrans(states29[51], sets[34])};
                states29[1].Transitions = new DfaTrans[2] {new DfaTrans(states29[2], sets[27]), new DfaTrans(states29[4], sets[28])};
                states29[2].Transitions = new DfaTrans[3] {new DfaTrans(states29[2], sets[27]), new DfaTrans(states29[3], sets[21]), new DfaTrans(states29[4], sets[28])};
                states29[3].Transitions = new DfaTrans[0] {};
                states29[4].Transitions = new DfaTrans[2] {new DfaTrans(states29[2], sets[29]), new DfaTrans(states29[5], sets[14])};
                states29[5].Transitions = new DfaTrans[1] {new DfaTrans(states29[6], sets[6])};
                states29[6].Transitions = new DfaTrans[1] {new DfaTrans(states29[7], sets[30])};
                states29[7].Transitions = new DfaTrans[2] {new DfaTrans(states29[8], sets[30]), new DfaTrans(states29[2], sets[9])};
                states29[8].Transitions = new DfaTrans[2] {new DfaTrans(states29[9], sets[30]), new DfaTrans(states29[2], sets[9])};
                states29[9].Transitions = new DfaTrans[2] {new DfaTrans(states29[10], sets[30]), new DfaTrans(states29[2], sets[9])};
                states29[10].Transitions = new DfaTrans[2] {new DfaTrans(states29[11], sets[30]), new DfaTrans(states29[2], sets[9])};
                states29[11].Transitions = new DfaTrans[2] {new DfaTrans(states29[12], sets[30]), new DfaTrans(states29[2], sets[9])};
                states29[12].Transitions = new DfaTrans[1] {new DfaTrans(states29[2], sets[9])};
                states29[13].Transitions = new DfaTrans[0] {};
                states29[14].Transitions = new DfaTrans[0] {};
                states29[15].Transitions = new DfaTrans[0] {};
                states29[16].Transitions = new DfaTrans[0] {};
                states29[17].Transitions = new DfaTrans[0] {};
                states29[18].Transitions = new DfaTrans[1] {new DfaTrans(states29[19], sets[31])};
                states29[19].Transitions = new DfaTrans[0] {};
                states29[20].Transitions = new DfaTrans[0] {};
                states29[21].Transitions = new DfaTrans[1] {new DfaTrans(states29[21], sets[5])};
                states29[22].Transitions = new DfaTrans[2] {new DfaTrans(states29[23], sets[35]), new DfaTrans(states29[21], sets[5])};
                states29[23].Transitions = new DfaTrans[1] {new DfaTrans(states29[24], sets[30])};
                states29[24].Transitions = new DfaTrans[1] {new DfaTrans(states29[25], sets[30])};
                states29[25].Transitions = new DfaTrans[1] {new DfaTrans(states29[26], sets[30])};
                states29[26].Transitions = new DfaTrans[1] {new DfaTrans(states29[27], sets[30])};
                states29[27].Transitions = new DfaTrans[1] {new DfaTrans(states29[28], sets[30])};
                states29[28].Transitions = new DfaTrans[1] {new DfaTrans(states29[29], sets[30])};
                states29[29].Transitions = new DfaTrans[0] {};
                states29[30].Transitions = new DfaTrans[1] {new DfaTrans(states29[31], sets[14])};
                states29[31].Transitions = new DfaTrans[3] {new DfaTrans(states29[32], sets[36]), new DfaTrans(states29[37], sets[37]), new DfaTrans(states29[42], sets[6])};
                states29[32].Transitions = new DfaTrans[1] {new DfaTrans(states29[33], sets[6])};
                states29[33].Transitions = new DfaTrans[1] {new DfaTrans(states29[34], sets[38])};
                states29[34].Transitions = new DfaTrans[3] {new DfaTrans(states29[35], sets[39]), new DfaTrans(states29[34], sets[40]), new DfaTrans(states29[36], sets[9])};
                states29[35].Transitions = new DfaTrans[2] {new DfaTrans(states29[35], sets[39]), new DfaTrans(states29[34], sets[40])};
                states29[36].Transitions = new DfaTrans[0] {};
                states29[37].Transitions = new DfaTrans[1] {new DfaTrans(states29[38], sets[6])};
                states29[38].Transitions = new DfaTrans[1] {new DfaTrans(states29[39], sets[38])};
                states29[39].Transitions = new DfaTrans[3] {new DfaTrans(states29[40], sets[39]), new DfaTrans(states29[39], sets[40]), new DfaTrans(states29[41], sets[9])};
                states29[40].Transitions = new DfaTrans[2] {new DfaTrans(states29[40], sets[39]), new DfaTrans(states29[39], sets[40])};
                states29[41].Transitions = new DfaTrans[0] {};
                states29[42].Transitions = new DfaTrans[1] {new DfaTrans(states29[43], sets[30])};
                states29[43].Transitions = new DfaTrans[2] {new DfaTrans(states29[44], sets[30]), new DfaTrans(states29[29], sets[9])};
                states29[44].Transitions = new DfaTrans[2] {new DfaTrans(states29[45], sets[30]), new DfaTrans(states29[29], sets[9])};
                states29[45].Transitions = new DfaTrans[2] {new DfaTrans(states29[46], sets[30]), new DfaTrans(states29[29], sets[9])};
                states29[46].Transitions = new DfaTrans[2] {new DfaTrans(states29[47], sets[30]), new DfaTrans(states29[29], sets[9])};
                states29[47].Transitions = new DfaTrans[2] {new DfaTrans(states29[48], sets[30]), new DfaTrans(states29[29], sets[9])};
                states29[48].Transitions = new DfaTrans[1] {new DfaTrans(states29[29], sets[9])};
                states29[49].Transitions = new DfaTrans[0] {};
                states29[50].Transitions = new DfaTrans[0] {};
                states29[51].Transitions = new DfaTrans[0] {};
                
                /* dfa 30 -- ˈtextˈ | '(' | ',' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states30 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,18), new DfaState(15,true,0), new DfaState(16,true,19), new DfaState(17,true,8), new DfaState(18,true,14), new DfaState(19,true,9)};
                states30[0].Transitions = new DfaTrans[8] {new DfaTrans(states30[1], sets[21]), new DfaTrans(states30[13], sets[22]), new DfaTrans(states30[14], sets[23]), new DfaTrans(states30[15], sets[4]), new DfaTrans(states30[16], sets[25]), new DfaTrans(states30[17], sets[6]), new DfaTrans(states30[18], sets[26]), new DfaTrans(states30[19], sets[9])};
                states30[1].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[27]), new DfaTrans(states30[4], sets[28])};
                states30[2].Transitions = new DfaTrans[3] {new DfaTrans(states30[2], sets[27]), new DfaTrans(states30[3], sets[21]), new DfaTrans(states30[4], sets[28])};
                states30[3].Transitions = new DfaTrans[0] {};
                states30[4].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[29]), new DfaTrans(states30[5], sets[14])};
                states30[5].Transitions = new DfaTrans[1] {new DfaTrans(states30[6], sets[6])};
                states30[6].Transitions = new DfaTrans[1] {new DfaTrans(states30[7], sets[30])};
                states30[7].Transitions = new DfaTrans[2] {new DfaTrans(states30[8], sets[30]), new DfaTrans(states30[2], sets[9])};
                states30[8].Transitions = new DfaTrans[2] {new DfaTrans(states30[9], sets[30]), new DfaTrans(states30[2], sets[9])};
                states30[9].Transitions = new DfaTrans[2] {new DfaTrans(states30[10], sets[30]), new DfaTrans(states30[2], sets[9])};
                states30[10].Transitions = new DfaTrans[2] {new DfaTrans(states30[11], sets[30]), new DfaTrans(states30[2], sets[9])};
                states30[11].Transitions = new DfaTrans[2] {new DfaTrans(states30[12], sets[30]), new DfaTrans(states30[2], sets[9])};
                states30[12].Transitions = new DfaTrans[1] {new DfaTrans(states30[2], sets[9])};
                states30[13].Transitions = new DfaTrans[0] {};
                states30[14].Transitions = new DfaTrans[0] {};
                states30[15].Transitions = new DfaTrans[1] {new DfaTrans(states30[15], sets[5])};
                states30[16].Transitions = new DfaTrans[0] {};
                states30[17].Transitions = new DfaTrans[0] {};
                states30[18].Transitions = new DfaTrans[0] {};
                states30[19].Transitions = new DfaTrans[0] {};
                
                /* dfa 31 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states31 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,16), new DfaState(15,true,17), new DfaState(16,true,2), new DfaState(17,true,12), new DfaState(18,true,15), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,14), new DfaState(49,true,24)};
                states31[0].Transitions = new DfaTrans[13] {new DfaTrans(states31[1], sets[21]), new DfaTrans(states31[13], sets[22]), new DfaTrans(states31[14], sets[41]), new DfaTrans(states31[15], sets[35]), new DfaTrans(states31[16], sets[31]), new DfaTrans(states31[17], sets[24]), new DfaTrans(states31[18], sets[42]), new DfaTrans(states31[19], sets[32]), new DfaTrans(states31[20], sets[33]), new DfaTrans(states31[28], sets[28]), new DfaTrans(states31[47], sets[6]), new DfaTrans(states31[48], sets[26]), new DfaTrans(states31[49], sets[34])};
                states31[1].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[27]), new DfaTrans(states31[4], sets[28])};
                states31[2].Transitions = new DfaTrans[3] {new DfaTrans(states31[2], sets[27]), new DfaTrans(states31[3], sets[21]), new DfaTrans(states31[4], sets[28])};
                states31[3].Transitions = new DfaTrans[0] {};
                states31[4].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[29]), new DfaTrans(states31[5], sets[14])};
                states31[5].Transitions = new DfaTrans[1] {new DfaTrans(states31[6], sets[6])};
                states31[6].Transitions = new DfaTrans[1] {new DfaTrans(states31[7], sets[30])};
                states31[7].Transitions = new DfaTrans[2] {new DfaTrans(states31[8], sets[30]), new DfaTrans(states31[2], sets[9])};
                states31[8].Transitions = new DfaTrans[2] {new DfaTrans(states31[9], sets[30]), new DfaTrans(states31[2], sets[9])};
                states31[9].Transitions = new DfaTrans[2] {new DfaTrans(states31[10], sets[30]), new DfaTrans(states31[2], sets[9])};
                states31[10].Transitions = new DfaTrans[2] {new DfaTrans(states31[11], sets[30]), new DfaTrans(states31[2], sets[9])};
                states31[11].Transitions = new DfaTrans[2] {new DfaTrans(states31[12], sets[30]), new DfaTrans(states31[2], sets[9])};
                states31[12].Transitions = new DfaTrans[1] {new DfaTrans(states31[2], sets[9])};
                states31[13].Transitions = new DfaTrans[0] {};
                states31[14].Transitions = new DfaTrans[0] {};
                states31[15].Transitions = new DfaTrans[0] {};
                states31[16].Transitions = new DfaTrans[0] {};
                states31[17].Transitions = new DfaTrans[0] {};
                states31[18].Transitions = new DfaTrans[0] {};
                states31[19].Transitions = new DfaTrans[1] {new DfaTrans(states31[19], sets[5])};
                states31[20].Transitions = new DfaTrans[2] {new DfaTrans(states31[21], sets[35]), new DfaTrans(states31[19], sets[5])};
                states31[21].Transitions = new DfaTrans[1] {new DfaTrans(states31[22], sets[30])};
                states31[22].Transitions = new DfaTrans[1] {new DfaTrans(states31[23], sets[30])};
                states31[23].Transitions = new DfaTrans[1] {new DfaTrans(states31[24], sets[30])};
                states31[24].Transitions = new DfaTrans[1] {new DfaTrans(states31[25], sets[30])};
                states31[25].Transitions = new DfaTrans[1] {new DfaTrans(states31[26], sets[30])};
                states31[26].Transitions = new DfaTrans[1] {new DfaTrans(states31[27], sets[30])};
                states31[27].Transitions = new DfaTrans[0] {};
                states31[28].Transitions = new DfaTrans[1] {new DfaTrans(states31[29], sets[14])};
                states31[29].Transitions = new DfaTrans[3] {new DfaTrans(states31[30], sets[36]), new DfaTrans(states31[35], sets[37]), new DfaTrans(states31[40], sets[6])};
                states31[30].Transitions = new DfaTrans[1] {new DfaTrans(states31[31], sets[6])};
                states31[31].Transitions = new DfaTrans[1] {new DfaTrans(states31[32], sets[38])};
                states31[32].Transitions = new DfaTrans[3] {new DfaTrans(states31[33], sets[39]), new DfaTrans(states31[32], sets[40]), new DfaTrans(states31[34], sets[9])};
                states31[33].Transitions = new DfaTrans[2] {new DfaTrans(states31[33], sets[39]), new DfaTrans(states31[32], sets[40])};
                states31[34].Transitions = new DfaTrans[0] {};
                states31[35].Transitions = new DfaTrans[1] {new DfaTrans(states31[36], sets[6])};
                states31[36].Transitions = new DfaTrans[1] {new DfaTrans(states31[37], sets[38])};
                states31[37].Transitions = new DfaTrans[3] {new DfaTrans(states31[38], sets[39]), new DfaTrans(states31[37], sets[40]), new DfaTrans(states31[39], sets[9])};
                states31[38].Transitions = new DfaTrans[2] {new DfaTrans(states31[38], sets[39]), new DfaTrans(states31[37], sets[40])};
                states31[39].Transitions = new DfaTrans[0] {};
                states31[40].Transitions = new DfaTrans[1] {new DfaTrans(states31[41], sets[30])};
                states31[41].Transitions = new DfaTrans[2] {new DfaTrans(states31[42], sets[30]), new DfaTrans(states31[27], sets[9])};
                states31[42].Transitions = new DfaTrans[2] {new DfaTrans(states31[43], sets[30]), new DfaTrans(states31[27], sets[9])};
                states31[43].Transitions = new DfaTrans[2] {new DfaTrans(states31[44], sets[30]), new DfaTrans(states31[27], sets[9])};
                states31[44].Transitions = new DfaTrans[2] {new DfaTrans(states31[45], sets[30]), new DfaTrans(states31[27], sets[9])};
                states31[45].Transitions = new DfaTrans[2] {new DfaTrans(states31[46], sets[30]), new DfaTrans(states31[27], sets[9])};
                states31[46].Transitions = new DfaTrans[1] {new DfaTrans(states31[27], sets[9])};
                states31[47].Transitions = new DfaTrans[0] {};
                states31[48].Transitions = new DfaTrans[0] {};
                states31[49].Transitions = new DfaTrans[0] {};
                
                /* dfa 32 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states32 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,16), new DfaState(15,true,17), new DfaState(16,true,2), new DfaState(17,true,25), new DfaState(18,true,12), new DfaState(19,true,15), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,14), new DfaState(50,true,24)};
                states32[0].Transitions = new DfaTrans[13] {new DfaTrans(states32[1], sets[21]), new DfaTrans(states32[13], sets[22]), new DfaTrans(states32[14], sets[41]), new DfaTrans(states32[15], sets[35]), new DfaTrans(states32[16], sets[31]), new DfaTrans(states32[18], sets[24]), new DfaTrans(states32[19], sets[42]), new DfaTrans(states32[20], sets[32]), new DfaTrans(states32[21], sets[33]), new DfaTrans(states32[29], sets[28]), new DfaTrans(states32[48], sets[6]), new DfaTrans(states32[49], sets[26]), new DfaTrans(states32[50], sets[34])};
                states32[1].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[27]), new DfaTrans(states32[4], sets[28])};
                states32[2].Transitions = new DfaTrans[3] {new DfaTrans(states32[2], sets[27]), new DfaTrans(states32[3], sets[21]), new DfaTrans(states32[4], sets[28])};
                states32[3].Transitions = new DfaTrans[0] {};
                states32[4].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[29]), new DfaTrans(states32[5], sets[14])};
                states32[5].Transitions = new DfaTrans[1] {new DfaTrans(states32[6], sets[6])};
                states32[6].Transitions = new DfaTrans[1] {new DfaTrans(states32[7], sets[30])};
                states32[7].Transitions = new DfaTrans[2] {new DfaTrans(states32[8], sets[30]), new DfaTrans(states32[2], sets[9])};
                states32[8].Transitions = new DfaTrans[2] {new DfaTrans(states32[9], sets[30]), new DfaTrans(states32[2], sets[9])};
                states32[9].Transitions = new DfaTrans[2] {new DfaTrans(states32[10], sets[30]), new DfaTrans(states32[2], sets[9])};
                states32[10].Transitions = new DfaTrans[2] {new DfaTrans(states32[11], sets[30]), new DfaTrans(states32[2], sets[9])};
                states32[11].Transitions = new DfaTrans[2] {new DfaTrans(states32[12], sets[30]), new DfaTrans(states32[2], sets[9])};
                states32[12].Transitions = new DfaTrans[1] {new DfaTrans(states32[2], sets[9])};
                states32[13].Transitions = new DfaTrans[0] {};
                states32[14].Transitions = new DfaTrans[0] {};
                states32[15].Transitions = new DfaTrans[0] {};
                states32[16].Transitions = new DfaTrans[1] {new DfaTrans(states32[17], sets[31])};
                states32[17].Transitions = new DfaTrans[0] {};
                states32[18].Transitions = new DfaTrans[0] {};
                states32[19].Transitions = new DfaTrans[0] {};
                states32[20].Transitions = new DfaTrans[1] {new DfaTrans(states32[20], sets[5])};
                states32[21].Transitions = new DfaTrans[2] {new DfaTrans(states32[22], sets[35]), new DfaTrans(states32[20], sets[5])};
                states32[22].Transitions = new DfaTrans[1] {new DfaTrans(states32[23], sets[30])};
                states32[23].Transitions = new DfaTrans[1] {new DfaTrans(states32[24], sets[30])};
                states32[24].Transitions = new DfaTrans[1] {new DfaTrans(states32[25], sets[30])};
                states32[25].Transitions = new DfaTrans[1] {new DfaTrans(states32[26], sets[30])};
                states32[26].Transitions = new DfaTrans[1] {new DfaTrans(states32[27], sets[30])};
                states32[27].Transitions = new DfaTrans[1] {new DfaTrans(states32[28], sets[30])};
                states32[28].Transitions = new DfaTrans[0] {};
                states32[29].Transitions = new DfaTrans[1] {new DfaTrans(states32[30], sets[14])};
                states32[30].Transitions = new DfaTrans[3] {new DfaTrans(states32[31], sets[36]), new DfaTrans(states32[36], sets[37]), new DfaTrans(states32[41], sets[6])};
                states32[31].Transitions = new DfaTrans[1] {new DfaTrans(states32[32], sets[6])};
                states32[32].Transitions = new DfaTrans[1] {new DfaTrans(states32[33], sets[38])};
                states32[33].Transitions = new DfaTrans[3] {new DfaTrans(states32[34], sets[39]), new DfaTrans(states32[33], sets[40]), new DfaTrans(states32[35], sets[9])};
                states32[34].Transitions = new DfaTrans[2] {new DfaTrans(states32[34], sets[39]), new DfaTrans(states32[33], sets[40])};
                states32[35].Transitions = new DfaTrans[0] {};
                states32[36].Transitions = new DfaTrans[1] {new DfaTrans(states32[37], sets[6])};
                states32[37].Transitions = new DfaTrans[1] {new DfaTrans(states32[38], sets[38])};
                states32[38].Transitions = new DfaTrans[3] {new DfaTrans(states32[39], sets[39]), new DfaTrans(states32[38], sets[40]), new DfaTrans(states32[40], sets[9])};
                states32[39].Transitions = new DfaTrans[2] {new DfaTrans(states32[39], sets[39]), new DfaTrans(states32[38], sets[40])};
                states32[40].Transitions = new DfaTrans[0] {};
                states32[41].Transitions = new DfaTrans[1] {new DfaTrans(states32[42], sets[30])};
                states32[42].Transitions = new DfaTrans[2] {new DfaTrans(states32[43], sets[30]), new DfaTrans(states32[28], sets[9])};
                states32[43].Transitions = new DfaTrans[2] {new DfaTrans(states32[44], sets[30]), new DfaTrans(states32[28], sets[9])};
                states32[44].Transitions = new DfaTrans[2] {new DfaTrans(states32[45], sets[30]), new DfaTrans(states32[28], sets[9])};
                states32[45].Transitions = new DfaTrans[2] {new DfaTrans(states32[46], sets[30]), new DfaTrans(states32[28], sets[9])};
                states32[46].Transitions = new DfaTrans[2] {new DfaTrans(states32[47], sets[30]), new DfaTrans(states32[28], sets[9])};
                states32[47].Transitions = new DfaTrans[1] {new DfaTrans(states32[28], sets[9])};
                states32[48].Transitions = new DfaTrans[0] {};
                states32[49].Transitions = new DfaTrans[0] {};
                states32[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 33 -- ',' | '}' -- */
                var states33 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,18), new DfaState(2,true,9)};
                states33[0].Transitions = new DfaTrans[2] {new DfaTrans(states33[1], sets[23]), new DfaTrans(states33[2], sets[9])};
                states33[1].Transitions = new DfaTrans[0] {};
                states33[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 34 -- ˈtextˈ | '(' | ')' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states34 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,2), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,14), new DfaState(45,true,24)};
                states34[0].Transitions = new DfaTrans[9] {new DfaTrans(states34[1], sets[21]), new DfaTrans(states34[13], sets[22]), new DfaTrans(states34[14], sets[43]), new DfaTrans(states34[15], sets[31]), new DfaTrans(states34[16], sets[32]), new DfaTrans(states34[17], sets[33]), new DfaTrans(states34[25], sets[28]), new DfaTrans(states34[44], sets[26]), new DfaTrans(states34[45], sets[34])};
                states34[1].Transitions = new DfaTrans[2] {new DfaTrans(states34[2], sets[27]), new DfaTrans(states34[4], sets[28])};
                states34[2].Transitions = new DfaTrans[3] {new DfaTrans(states34[2], sets[27]), new DfaTrans(states34[3], sets[21]), new DfaTrans(states34[4], sets[28])};
                states34[3].Transitions = new DfaTrans[0] {};
                states34[4].Transitions = new DfaTrans[2] {new DfaTrans(states34[2], sets[29]), new DfaTrans(states34[5], sets[14])};
                states34[5].Transitions = new DfaTrans[1] {new DfaTrans(states34[6], sets[6])};
                states34[6].Transitions = new DfaTrans[1] {new DfaTrans(states34[7], sets[30])};
                states34[7].Transitions = new DfaTrans[2] {new DfaTrans(states34[8], sets[30]), new DfaTrans(states34[2], sets[9])};
                states34[8].Transitions = new DfaTrans[2] {new DfaTrans(states34[9], sets[30]), new DfaTrans(states34[2], sets[9])};
                states34[9].Transitions = new DfaTrans[2] {new DfaTrans(states34[10], sets[30]), new DfaTrans(states34[2], sets[9])};
                states34[10].Transitions = new DfaTrans[2] {new DfaTrans(states34[11], sets[30]), new DfaTrans(states34[2], sets[9])};
                states34[11].Transitions = new DfaTrans[2] {new DfaTrans(states34[12], sets[30]), new DfaTrans(states34[2], sets[9])};
                states34[12].Transitions = new DfaTrans[1] {new DfaTrans(states34[2], sets[9])};
                states34[13].Transitions = new DfaTrans[0] {};
                states34[14].Transitions = new DfaTrans[0] {};
                states34[15].Transitions = new DfaTrans[0] {};
                states34[16].Transitions = new DfaTrans[1] {new DfaTrans(states34[16], sets[5])};
                states34[17].Transitions = new DfaTrans[2] {new DfaTrans(states34[18], sets[35]), new DfaTrans(states34[16], sets[5])};
                states34[18].Transitions = new DfaTrans[1] {new DfaTrans(states34[19], sets[30])};
                states34[19].Transitions = new DfaTrans[1] {new DfaTrans(states34[20], sets[30])};
                states34[20].Transitions = new DfaTrans[1] {new DfaTrans(states34[21], sets[30])};
                states34[21].Transitions = new DfaTrans[1] {new DfaTrans(states34[22], sets[30])};
                states34[22].Transitions = new DfaTrans[1] {new DfaTrans(states34[23], sets[30])};
                states34[23].Transitions = new DfaTrans[1] {new DfaTrans(states34[24], sets[30])};
                states34[24].Transitions = new DfaTrans[0] {};
                states34[25].Transitions = new DfaTrans[1] {new DfaTrans(states34[26], sets[14])};
                states34[26].Transitions = new DfaTrans[3] {new DfaTrans(states34[27], sets[36]), new DfaTrans(states34[32], sets[37]), new DfaTrans(states34[37], sets[6])};
                states34[27].Transitions = new DfaTrans[1] {new DfaTrans(states34[28], sets[6])};
                states34[28].Transitions = new DfaTrans[1] {new DfaTrans(states34[29], sets[38])};
                states34[29].Transitions = new DfaTrans[3] {new DfaTrans(states34[30], sets[39]), new DfaTrans(states34[29], sets[40]), new DfaTrans(states34[31], sets[9])};
                states34[30].Transitions = new DfaTrans[2] {new DfaTrans(states34[30], sets[39]), new DfaTrans(states34[29], sets[40])};
                states34[31].Transitions = new DfaTrans[0] {};
                states34[32].Transitions = new DfaTrans[1] {new DfaTrans(states34[33], sets[6])};
                states34[33].Transitions = new DfaTrans[1] {new DfaTrans(states34[34], sets[38])};
                states34[34].Transitions = new DfaTrans[3] {new DfaTrans(states34[35], sets[39]), new DfaTrans(states34[34], sets[40]), new DfaTrans(states34[36], sets[9])};
                states34[35].Transitions = new DfaTrans[2] {new DfaTrans(states34[35], sets[39]), new DfaTrans(states34[34], sets[40])};
                states34[36].Transitions = new DfaTrans[0] {};
                states34[37].Transitions = new DfaTrans[1] {new DfaTrans(states34[38], sets[30])};
                states34[38].Transitions = new DfaTrans[2] {new DfaTrans(states34[39], sets[30]), new DfaTrans(states34[24], sets[9])};
                states34[39].Transitions = new DfaTrans[2] {new DfaTrans(states34[40], sets[30]), new DfaTrans(states34[24], sets[9])};
                states34[40].Transitions = new DfaTrans[2] {new DfaTrans(states34[41], sets[30]), new DfaTrans(states34[24], sets[9])};
                states34[41].Transitions = new DfaTrans[2] {new DfaTrans(states34[42], sets[30]), new DfaTrans(states34[24], sets[9])};
                states34[42].Transitions = new DfaTrans[2] {new DfaTrans(states34[43], sets[30]), new DfaTrans(states34[24], sets[9])};
                states34[43].Transitions = new DfaTrans[1] {new DfaTrans(states34[24], sets[9])};
                states34[44].Transitions = new DfaTrans[0] {};
                states34[45].Transitions = new DfaTrans[0] {};
                
                /* dfa 35 -- '}' -- */
                var states35 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,9)};
                states35[0].Transitions = new DfaTrans[1] {new DfaTrans(states35[1], sets[9])};
                states35[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 36 -- '|' | '}' -- */
                var states36 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,14), new DfaState(2,true,9)};
                states36[0].Transitions = new DfaTrans[2] {new DfaTrans(states36[1], sets[26]), new DfaTrans(states36[2], sets[9])};
                states36[1].Transitions = new DfaTrans[0] {};
                states36[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 37 -- ˈtextˈ | '(' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states37 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,16), new DfaState(15,true,17), new DfaState(16,true,18), new DfaState(17,true,15), new DfaState(18,true,0), new DfaState(19,true,19), new DfaState(20,true,8), new DfaState(21,true,14), new DfaState(22,true,9)};
                states37[0].Transitions = new DfaTrans[11] {new DfaTrans(states37[1], sets[21]), new DfaTrans(states37[13], sets[22]), new DfaTrans(states37[14], sets[41]), new DfaTrans(states37[15], sets[35]), new DfaTrans(states37[16], sets[23]), new DfaTrans(states37[17], sets[42]), new DfaTrans(states37[18], sets[4]), new DfaTrans(states37[19], sets[25]), new DfaTrans(states37[20], sets[6]), new DfaTrans(states37[21], sets[26]), new DfaTrans(states37[22], sets[9])};
                states37[1].Transitions = new DfaTrans[2] {new DfaTrans(states37[2], sets[27]), new DfaTrans(states37[4], sets[28])};
                states37[2].Transitions = new DfaTrans[3] {new DfaTrans(states37[2], sets[27]), new DfaTrans(states37[3], sets[21]), new DfaTrans(states37[4], sets[28])};
                states37[3].Transitions = new DfaTrans[0] {};
                states37[4].Transitions = new DfaTrans[2] {new DfaTrans(states37[2], sets[29]), new DfaTrans(states37[5], sets[14])};
                states37[5].Transitions = new DfaTrans[1] {new DfaTrans(states37[6], sets[6])};
                states37[6].Transitions = new DfaTrans[1] {new DfaTrans(states37[7], sets[30])};
                states37[7].Transitions = new DfaTrans[2] {new DfaTrans(states37[8], sets[30]), new DfaTrans(states37[2], sets[9])};
                states37[8].Transitions = new DfaTrans[2] {new DfaTrans(states37[9], sets[30]), new DfaTrans(states37[2], sets[9])};
                states37[9].Transitions = new DfaTrans[2] {new DfaTrans(states37[10], sets[30]), new DfaTrans(states37[2], sets[9])};
                states37[10].Transitions = new DfaTrans[2] {new DfaTrans(states37[11], sets[30]), new DfaTrans(states37[2], sets[9])};
                states37[11].Transitions = new DfaTrans[2] {new DfaTrans(states37[12], sets[30]), new DfaTrans(states37[2], sets[9])};
                states37[12].Transitions = new DfaTrans[1] {new DfaTrans(states37[2], sets[9])};
                states37[13].Transitions = new DfaTrans[0] {};
                states37[14].Transitions = new DfaTrans[0] {};
                states37[15].Transitions = new DfaTrans[0] {};
                states37[16].Transitions = new DfaTrans[0] {};
                states37[17].Transitions = new DfaTrans[0] {};
                states37[18].Transitions = new DfaTrans[1] {new DfaTrans(states37[18], sets[5])};
                states37[19].Transitions = new DfaTrans[0] {};
                states37[20].Transitions = new DfaTrans[0] {};
                states37[21].Transitions = new DfaTrans[0] {};
                states37[22].Transitions = new DfaTrans[0] {};
                
                /* dfa 38 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states38 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,16), new DfaState(16,true,17), new DfaState(17,true,2), new DfaState(18,true,15), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,14), new DfaState(49,true,24)};
                states38[0].Transitions = new DfaTrans[13] {new DfaTrans(states38[1], sets[21]), new DfaTrans(states38[13], sets[22]), new DfaTrans(states38[14], sets[43]), new DfaTrans(states38[15], sets[41]), new DfaTrans(states38[16], sets[35]), new DfaTrans(states38[17], sets[31]), new DfaTrans(states38[18], sets[42]), new DfaTrans(states38[19], sets[32]), new DfaTrans(states38[20], sets[33]), new DfaTrans(states38[28], sets[28]), new DfaTrans(states38[47], sets[6]), new DfaTrans(states38[48], sets[26]), new DfaTrans(states38[49], sets[34])};
                states38[1].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[27]), new DfaTrans(states38[4], sets[28])};
                states38[2].Transitions = new DfaTrans[3] {new DfaTrans(states38[2], sets[27]), new DfaTrans(states38[3], sets[21]), new DfaTrans(states38[4], sets[28])};
                states38[3].Transitions = new DfaTrans[0] {};
                states38[4].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[29]), new DfaTrans(states38[5], sets[14])};
                states38[5].Transitions = new DfaTrans[1] {new DfaTrans(states38[6], sets[6])};
                states38[6].Transitions = new DfaTrans[1] {new DfaTrans(states38[7], sets[30])};
                states38[7].Transitions = new DfaTrans[2] {new DfaTrans(states38[8], sets[30]), new DfaTrans(states38[2], sets[9])};
                states38[8].Transitions = new DfaTrans[2] {new DfaTrans(states38[9], sets[30]), new DfaTrans(states38[2], sets[9])};
                states38[9].Transitions = new DfaTrans[2] {new DfaTrans(states38[10], sets[30]), new DfaTrans(states38[2], sets[9])};
                states38[10].Transitions = new DfaTrans[2] {new DfaTrans(states38[11], sets[30]), new DfaTrans(states38[2], sets[9])};
                states38[11].Transitions = new DfaTrans[2] {new DfaTrans(states38[12], sets[30]), new DfaTrans(states38[2], sets[9])};
                states38[12].Transitions = new DfaTrans[1] {new DfaTrans(states38[2], sets[9])};
                states38[13].Transitions = new DfaTrans[0] {};
                states38[14].Transitions = new DfaTrans[0] {};
                states38[15].Transitions = new DfaTrans[0] {};
                states38[16].Transitions = new DfaTrans[0] {};
                states38[17].Transitions = new DfaTrans[0] {};
                states38[18].Transitions = new DfaTrans[0] {};
                states38[19].Transitions = new DfaTrans[1] {new DfaTrans(states38[19], sets[5])};
                states38[20].Transitions = new DfaTrans[2] {new DfaTrans(states38[21], sets[35]), new DfaTrans(states38[19], sets[5])};
                states38[21].Transitions = new DfaTrans[1] {new DfaTrans(states38[22], sets[30])};
                states38[22].Transitions = new DfaTrans[1] {new DfaTrans(states38[23], sets[30])};
                states38[23].Transitions = new DfaTrans[1] {new DfaTrans(states38[24], sets[30])};
                states38[24].Transitions = new DfaTrans[1] {new DfaTrans(states38[25], sets[30])};
                states38[25].Transitions = new DfaTrans[1] {new DfaTrans(states38[26], sets[30])};
                states38[26].Transitions = new DfaTrans[1] {new DfaTrans(states38[27], sets[30])};
                states38[27].Transitions = new DfaTrans[0] {};
                states38[28].Transitions = new DfaTrans[1] {new DfaTrans(states38[29], sets[14])};
                states38[29].Transitions = new DfaTrans[3] {new DfaTrans(states38[30], sets[36]), new DfaTrans(states38[35], sets[37]), new DfaTrans(states38[40], sets[6])};
                states38[30].Transitions = new DfaTrans[1] {new DfaTrans(states38[31], sets[6])};
                states38[31].Transitions = new DfaTrans[1] {new DfaTrans(states38[32], sets[38])};
                states38[32].Transitions = new DfaTrans[3] {new DfaTrans(states38[33], sets[39]), new DfaTrans(states38[32], sets[40]), new DfaTrans(states38[34], sets[9])};
                states38[33].Transitions = new DfaTrans[2] {new DfaTrans(states38[33], sets[39]), new DfaTrans(states38[32], sets[40])};
                states38[34].Transitions = new DfaTrans[0] {};
                states38[35].Transitions = new DfaTrans[1] {new DfaTrans(states38[36], sets[6])};
                states38[36].Transitions = new DfaTrans[1] {new DfaTrans(states38[37], sets[38])};
                states38[37].Transitions = new DfaTrans[3] {new DfaTrans(states38[38], sets[39]), new DfaTrans(states38[37], sets[40]), new DfaTrans(states38[39], sets[9])};
                states38[38].Transitions = new DfaTrans[2] {new DfaTrans(states38[38], sets[39]), new DfaTrans(states38[37], sets[40])};
                states38[39].Transitions = new DfaTrans[0] {};
                states38[40].Transitions = new DfaTrans[1] {new DfaTrans(states38[41], sets[30])};
                states38[41].Transitions = new DfaTrans[2] {new DfaTrans(states38[42], sets[30]), new DfaTrans(states38[27], sets[9])};
                states38[42].Transitions = new DfaTrans[2] {new DfaTrans(states38[43], sets[30]), new DfaTrans(states38[27], sets[9])};
                states38[43].Transitions = new DfaTrans[2] {new DfaTrans(states38[44], sets[30]), new DfaTrans(states38[27], sets[9])};
                states38[44].Transitions = new DfaTrans[2] {new DfaTrans(states38[45], sets[30]), new DfaTrans(states38[27], sets[9])};
                states38[45].Transitions = new DfaTrans[2] {new DfaTrans(states38[46], sets[30]), new DfaTrans(states38[27], sets[9])};
                states38[46].Transitions = new DfaTrans[1] {new DfaTrans(states38[27], sets[9])};
                states38[47].Transitions = new DfaTrans[0] {};
                states38[48].Transitions = new DfaTrans[0] {};
                states38[49].Transitions = new DfaTrans[0] {};
                
                /* dfa 39 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states39 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,16), new DfaState(16,true,17), new DfaState(17,true,2), new DfaState(18,true,25), new DfaState(19,true,15), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,14), new DfaState(50,true,24)};
                states39[0].Transitions = new DfaTrans[13] {new DfaTrans(states39[1], sets[21]), new DfaTrans(states39[13], sets[22]), new DfaTrans(states39[14], sets[43]), new DfaTrans(states39[15], sets[41]), new DfaTrans(states39[16], sets[35]), new DfaTrans(states39[17], sets[31]), new DfaTrans(states39[19], sets[42]), new DfaTrans(states39[20], sets[32]), new DfaTrans(states39[21], sets[33]), new DfaTrans(states39[29], sets[28]), new DfaTrans(states39[48], sets[6]), new DfaTrans(states39[49], sets[26]), new DfaTrans(states39[50], sets[34])};
                states39[1].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[27]), new DfaTrans(states39[4], sets[28])};
                states39[2].Transitions = new DfaTrans[3] {new DfaTrans(states39[2], sets[27]), new DfaTrans(states39[3], sets[21]), new DfaTrans(states39[4], sets[28])};
                states39[3].Transitions = new DfaTrans[0] {};
                states39[4].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[29]), new DfaTrans(states39[5], sets[14])};
                states39[5].Transitions = new DfaTrans[1] {new DfaTrans(states39[6], sets[6])};
                states39[6].Transitions = new DfaTrans[1] {new DfaTrans(states39[7], sets[30])};
                states39[7].Transitions = new DfaTrans[2] {new DfaTrans(states39[8], sets[30]), new DfaTrans(states39[2], sets[9])};
                states39[8].Transitions = new DfaTrans[2] {new DfaTrans(states39[9], sets[30]), new DfaTrans(states39[2], sets[9])};
                states39[9].Transitions = new DfaTrans[2] {new DfaTrans(states39[10], sets[30]), new DfaTrans(states39[2], sets[9])};
                states39[10].Transitions = new DfaTrans[2] {new DfaTrans(states39[11], sets[30]), new DfaTrans(states39[2], sets[9])};
                states39[11].Transitions = new DfaTrans[2] {new DfaTrans(states39[12], sets[30]), new DfaTrans(states39[2], sets[9])};
                states39[12].Transitions = new DfaTrans[1] {new DfaTrans(states39[2], sets[9])};
                states39[13].Transitions = new DfaTrans[0] {};
                states39[14].Transitions = new DfaTrans[0] {};
                states39[15].Transitions = new DfaTrans[0] {};
                states39[16].Transitions = new DfaTrans[0] {};
                states39[17].Transitions = new DfaTrans[1] {new DfaTrans(states39[18], sets[31])};
                states39[18].Transitions = new DfaTrans[0] {};
                states39[19].Transitions = new DfaTrans[0] {};
                states39[20].Transitions = new DfaTrans[1] {new DfaTrans(states39[20], sets[5])};
                states39[21].Transitions = new DfaTrans[2] {new DfaTrans(states39[22], sets[35]), new DfaTrans(states39[20], sets[5])};
                states39[22].Transitions = new DfaTrans[1] {new DfaTrans(states39[23], sets[30])};
                states39[23].Transitions = new DfaTrans[1] {new DfaTrans(states39[24], sets[30])};
                states39[24].Transitions = new DfaTrans[1] {new DfaTrans(states39[25], sets[30])};
                states39[25].Transitions = new DfaTrans[1] {new DfaTrans(states39[26], sets[30])};
                states39[26].Transitions = new DfaTrans[1] {new DfaTrans(states39[27], sets[30])};
                states39[27].Transitions = new DfaTrans[1] {new DfaTrans(states39[28], sets[30])};
                states39[28].Transitions = new DfaTrans[0] {};
                states39[29].Transitions = new DfaTrans[1] {new DfaTrans(states39[30], sets[14])};
                states39[30].Transitions = new DfaTrans[3] {new DfaTrans(states39[31], sets[36]), new DfaTrans(states39[36], sets[37]), new DfaTrans(states39[41], sets[6])};
                states39[31].Transitions = new DfaTrans[1] {new DfaTrans(states39[32], sets[6])};
                states39[32].Transitions = new DfaTrans[1] {new DfaTrans(states39[33], sets[38])};
                states39[33].Transitions = new DfaTrans[3] {new DfaTrans(states39[34], sets[39]), new DfaTrans(states39[33], sets[40]), new DfaTrans(states39[35], sets[9])};
                states39[34].Transitions = new DfaTrans[2] {new DfaTrans(states39[34], sets[39]), new DfaTrans(states39[33], sets[40])};
                states39[35].Transitions = new DfaTrans[0] {};
                states39[36].Transitions = new DfaTrans[1] {new DfaTrans(states39[37], sets[6])};
                states39[37].Transitions = new DfaTrans[1] {new DfaTrans(states39[38], sets[38])};
                states39[38].Transitions = new DfaTrans[3] {new DfaTrans(states39[39], sets[39]), new DfaTrans(states39[38], sets[40]), new DfaTrans(states39[40], sets[9])};
                states39[39].Transitions = new DfaTrans[2] {new DfaTrans(states39[39], sets[39]), new DfaTrans(states39[38], sets[40])};
                states39[40].Transitions = new DfaTrans[0] {};
                states39[41].Transitions = new DfaTrans[1] {new DfaTrans(states39[42], sets[30])};
                states39[42].Transitions = new DfaTrans[2] {new DfaTrans(states39[43], sets[30]), new DfaTrans(states39[28], sets[9])};
                states39[43].Transitions = new DfaTrans[2] {new DfaTrans(states39[44], sets[30]), new DfaTrans(states39[28], sets[9])};
                states39[44].Transitions = new DfaTrans[2] {new DfaTrans(states39[45], sets[30]), new DfaTrans(states39[28], sets[9])};
                states39[45].Transitions = new DfaTrans[2] {new DfaTrans(states39[46], sets[30]), new DfaTrans(states39[28], sets[9])};
                states39[46].Transitions = new DfaTrans[2] {new DfaTrans(states39[47], sets[30]), new DfaTrans(states39[28], sets[9])};
                states39[47].Transitions = new DfaTrans[1] {new DfaTrans(states39[28], sets[9])};
                states39[48].Transitions = new DfaTrans[0] {};
                states39[49].Transitions = new DfaTrans[0] {};
                states39[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 40 --  -- */
                var states40 = new DfaState[12] {new DfaState(0,true,-1), new DfaState(1,false,-1), new DfaState(2,true,-1), new DfaState(3,true,-1), new DfaState(4,true,-1), new DfaState(5,true,-1), new DfaState(6,true,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,true,-1)};
                states40[0].Transitions = new DfaTrans[2] {new DfaTrans(states40[0], sets[47]), new DfaTrans(states40[1], sets[48])};
                states40[1].Transitions = new DfaTrans[2] {new DfaTrans(states40[2], sets[48]), new DfaTrans(states40[9], sets[41])};
                states40[2].Transitions = new DfaTrans[3] {new DfaTrans(states40[2], sets[49]), new DfaTrans(states40[0], sets[50]), new DfaTrans(states40[3], sets[48])};
                states40[3].Transitions = new DfaTrans[4] {new DfaTrans(states40[2], sets[51]), new DfaTrans(states40[0], sets[50]), new DfaTrans(states40[3], sets[48]), new DfaTrans(states40[4], sets[41])};
                states40[4].Transitions = new DfaTrans[4] {new DfaTrans(states40[5], sets[41]), new DfaTrans(states40[6], sets[50]), new DfaTrans(states40[4], sets[51]), new DfaTrans(states40[11], sets[48])};
                states40[5].Transitions = new DfaTrans[3] {new DfaTrans(states40[4], sets[49]), new DfaTrans(states40[6], sets[50]), new DfaTrans(states40[3], sets[48])};
                states40[6].Transitions = new DfaTrans[4] {new DfaTrans(states40[6], sets[47]), new DfaTrans(states40[7], sets[48]), new DfaTrans(states40[9], sets[52]), new DfaTrans(states40[10], sets[41])};
                states40[7].Transitions = new DfaTrans[3] {new DfaTrans(states40[4], sets[48]), new DfaTrans(states40[8], sets[41]), new DfaTrans(states40[9], sets[53])};
                states40[8].Transitions = new DfaTrans[3] {new DfaTrans(states40[9], sets[53]), new DfaTrans(states40[8], sets[41]), new DfaTrans(states40[6], sets[48])};
                states40[9].Transitions = new DfaTrans[2] {new DfaTrans(states40[9], sets[54]), new DfaTrans(states40[10], sets[41])};
                states40[10].Transitions = new DfaTrans[2] {new DfaTrans(states40[0], sets[48]), new DfaTrans(states40[9], sets[55])};
                states40[11].Transitions = new DfaTrans[3] {new DfaTrans(states40[4], sets[51]), new DfaTrans(states40[6], sets[50]), new DfaTrans(states40[11], sets[56])};
                
                var dfas = new Dfa[]
                {
                    new Dfa(states0), new Dfa(states1), new Dfa(states2), new Dfa(states3), new Dfa(states4), new Dfa(states5),
                    new Dfa(states6), new Dfa(states7), new Dfa(states8), new Dfa(states9), new Dfa(states10), new Dfa(states11),
                    new Dfa(states12), new Dfa(states13), new Dfa(states14), new Dfa(states15), new Dfa(states16), new Dfa(states17),
                    new Dfa(states18), new Dfa(states19), new Dfa(states20), new Dfa(states21), new Dfa(states22), new Dfa(states23),
                    new Dfa(states24), new Dfa(states25), new Dfa(states26), new Dfa(states27), new Dfa(states28), new Dfa(states29),
                    new Dfa(states30), new Dfa(states31), new Dfa(states32), new Dfa(states33), new Dfa(states34), new Dfa(states35),
                    new Dfa(states36), new Dfa(states37), new Dfa(states38), new Dfa(states39), new Dfa(states40),
                };
                
                return new DfaSet(dfas, map, dfas.Last());
            }
            
            public static ITable CreateParseTable()
            {
                ushort[] u16Table = 
                {
                    0, 0, 0, 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 9, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262, 45, 0,
                    0, 49, 0, 0, 0, 0, 0, 0, 0, 0, 53, 0, 0, 0, 0, 0, 0, 0, 0, 25, 29, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 258, 258, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 14, 0, 0, 14, 0, 0, 0,
                    0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 18, 18, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 22, 0, 0, 22, 0, 0, 0, 0, 0, 0, 0, 0, 22, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 61, 45, 0, 0, 49, 0,
                    0, 0, 0, 0, 0, 0, 0, 53, 0, 0, 0, 0, 0, 0, 0, 0, 57, 29, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 69, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 73, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 254, 254, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 85, 0, 0, 0, 0, 0, 0, 0, 0, 274, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 77, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 97,
                    0, 0, 0, 0, 0, 0, 0, 0, 286, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 89, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 93, 0, 0, 0, 0, 0, 0, 0, 0, 0, 109, 0, 0, 0, 0, 0, 0, 0, 0, 338, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 101, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 270, 0, 0, 0, 0, 0, 0, 0,
                    0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 85, 0, 0, 0, 0, 0, 0, 0, 0, 117, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 113, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 121, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 282, 0, 0, 0,
                    0, 0, 0, 0, 0, 282, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 97, 0, 0, 0, 0, 0, 0, 0, 0, 129, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 141, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 133, 0, 0, 0, 0, 0, 0, 0, 0,
                    334, 0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 109, 0, 0, 0, 0, 0, 0, 0, 0, 149, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 145, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 157, 161, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 153,
                    0, 0, 0, 266, 0, 0, 0, 0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 26, 26, 0, 0, 26, 0, 0, 0, 0,
                    0, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 165, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 278, 0, 0, 0, 0, 0, 0, 0, 0, 278, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 34, 34, 0, 0, 34, 0, 0,
                    0, 0, 0, 0, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 229, 0, 0, 233,
                    0, 0, 0, 0, 237, 0, 0, 0, 318, 0, 318, 0, 0, 0, 241, 245, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 169, 173, 177, 181, 185, 189, 193, 197, 201, 205, 209, 213, 217, 221, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 225, 0, 0, 0, 0, 0, 0, 290, 0, 0, 290, 0, 0, 0, 0, 290, 0, 0,
                    0, 290, 0, 290, 0, 0, 0, 290, 290, 290, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 294, 0, 294, 0, 0, 0, 294, 294, 294, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 130, 130, 0, 0, 130, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 317, 0, 321, 325, 329, 333, 337, 0, 0, 0, 0, 0, 370, 0, 370, 0, 0, 0,
                    0, 0, 341, 0, 0, 370, 345, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 253,
                    0, 0, 257, 261, 265, 269, 273, 277, 281, 285, 289, 0, 293, 297, 301, 305, 309, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 313, 0, 342, 0, 342, 342, 342, 342, 342, 0, 0, 0, 0, 0, 342, 0, 342, 0, 0, 0, 0, 0, 342, 0, 0,
                    342, 342, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 346, 0, 346, 346, 346, 346, 346,
                    0, 0, 0, 0, 0, 346, 0, 346, 0, 0, 0, 0, 0, 346, 0, 0, 346, 346, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 349, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 353, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 306, 0, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 357, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 46, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 314, 0, 0, 314, 0, 0, 0, 0, 314, 0, 0,
                    0, 314, 0, 314, 0, 0, 0, 314, 314, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 0, 54, 0, 0, 0, 54, 0, 54, 0, 0, 0, 54, 54, 54, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 0, 58, 0, 58,
                    0, 0, 0, 58, 58, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0,
                    62, 0, 0, 0, 0, 62, 0, 0, 0, 62, 0, 62, 0, 0, 0, 62, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0, 66, 0, 66, 365, 369, 373, 66, 66,
                    66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 82, 0, 0, 0, 0,
                    82, 0, 0, 0, 82, 0, 82, 82, 82, 82, 82, 82, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86, 0, 0, 0, 86, 0, 86, 86, 86, 86, 86, 86, 86, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 90, 0, 0, 0,
                    90, 0, 90, 90, 90, 90, 90, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102, 0, 0, 0, 102, 0, 102, 102, 102, 102, 102, 102, 102, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 0, 110, 0, 0, 0, 0, 110, 0, 0, 0,
                    110, 0, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 0, 0, 0, 118, 0, 118, 118, 118, 118, 118, 118, 118, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 229, 0, 0, 233, 0, 0, 0, 0, 237, 0,
                    0, 0, 50, 0, 50, 0, 0, 0, 241, 245, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 377, 185,
                    189, 193, 197, 201, 205, 209, 213, 217, 221, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 126, 0, 0, 0, 0, 126, 0, 0, 0, 126, 0, 126, 126, 126, 126, 126,
                    126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0, 0, 122, 0, 0,
                    0, 0, 122, 0, 0, 0, 122, 0, 122, 122, 122, 122, 122, 122, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 381, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 229, 0, 0, 233, 0, 0, 0, 0, 237,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 385, 213, 217, 221, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 229, 0, 0, 233, 0, 0, 0, 0, 237, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 249, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 389, 213, 217, 221, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 453, 0, 0, 457, 0, 0, 0, 0, 461,
                    0, 0, 0, 0, 0, 318, 0, 0, 0, 465, 469, 473, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 393, 397,
                    401, 405, 409, 413, 417, 421, 425, 429, 433, 437, 441, 445, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 449, 0, 0, 0, 0, 0, 0, 238, 0, 238, 238, 238, 238, 238, 0, 238, 0, 0, 0, 238,
                    0, 238, 238, 238, 238, 0, 0, 238, 0, 0, 238, 238, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 477, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 358, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 481, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 146, 0, 146, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 142, 0, 142, 0, 0, 0, 0, 0, 0, 0, 0, 489, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 366, 366, 366, 366, 366, 0, 0, 0, 0,
                    0, 366, 0, 366, 0, 0, 0, 0, 0, 366, 0, 0, 366, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 158, 0, 158, 158, 158, 158, 158, 0, 0, 0, 0, 0, 158, 0, 158, 0, 0, 0, 0, 0, 158, 0, 0, 158,
                    158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0,
                    0, 0, 0, 0, 162, 0, 162, 0, 0, 0, 0, 0, 162, 0, 0, 162, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 166, 0, 166, 0, 0, 0, 0, 0, 166, 0,
                    0, 166, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170,
                    0, 0, 0, 0, 0, 170, 0, 170, 0, 0, 0, 0, 0, 170, 0, 0, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174, 174, 174, 174, 0, 497, 0, 0, 0, 174, 0, 174, 501, 505, 509, 0,
                    0, 174, 0, 0, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 493, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202,
                    202, 202, 202, 0, 202, 0, 0, 0, 202, 0, 202, 202, 202, 202, 0, 0, 202, 0, 0, 202, 202, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 198, 0, 0, 0, 198, 0,
                    198, 198, 198, 198, 0, 0, 198, 0, 0, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0, 0, 0, 222, 0, 222, 222, 222, 222, 0, 0, 222, 0, 0,
                    222, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 513, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 317, 0, 321, 325, 329, 333, 337, 0, 0, 0, 0, 0, 154, 0, 154, 0, 0, 0, 0, 0, 341, 0, 0, 154, 345, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 253, 0, 0, 0, 0, 0, 0, 517, 277,
                    281, 285, 289, 0, 293, 297, 301, 305, 309, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 126, 126, 126,
                    126, 126, 0, 126, 0, 0, 0, 126, 0, 126, 126, 126, 126, 0, 0, 126, 0, 0, 126, 126, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214, 214, 0, 214, 0, 0, 0, 214, 0, 214,
                    214, 214, 214, 0, 0, 214, 0, 0, 214, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    218, 0, 218, 218, 218, 218, 218, 0, 218, 0, 0, 0, 218, 0, 218, 218, 218, 218, 0, 0, 218, 0, 0, 218, 218,
                    250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230, 0, 230,
                    0, 0, 0, 230, 0, 230, 230, 230, 230, 0, 0, 230, 0, 0, 230, 230, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 234, 0, 234, 234, 234, 234, 0,
                    0, 234, 0, 0, 234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226,
                    226, 226, 226, 0, 226, 0, 0, 0, 226, 0, 226, 226, 226, 226, 0, 0, 226, 0, 0, 226, 226, 246, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 585, 0, 589, 593, 597, 601, 605, 0, 0, 0, 0, 0, 0, 0,
                    370, 0, 0, 0, 0, 0, 609, 370, 0, 370, 613, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 521, 0, 0, 525, 529, 533, 537, 541, 545, 549, 553, 557, 0, 561, 565, 569, 573, 577, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 581, 0, 317, 0, 321, 325, 329, 333, 337, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 253, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 617, 305, 309, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0,
                    0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 42, 0, 621,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 229, 0, 0,
                    233, 0, 0, 0, 0, 237, 0, 0, 0, 318, 0, 318, 0, 0, 0, 241, 245, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 625, 177, 181, 185, 189, 193, 197, 201, 205, 209, 213, 217, 221, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 225, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70, 0,
                    0, 0, 70, 0, 70, 0, 0, 0, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 0, 0, 0, 74, 0, 74, 0, 0, 0, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 78, 0, 0, 0, 78, 0, 78,
                    0, 0, 0, 78, 78, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 310, 0,
                    0, 310, 0, 0, 0, 0, 310, 0, 0, 0, 310, 0, 310, 0, 0, 0, 310, 310, 310, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 633, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 629, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0, 0,
                    0, 94, 0, 0, 0, 94, 0, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 0, 98, 0, 98, 98, 98, 98, 98, 98, 98, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 641, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 645, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 0, 0, 0,
                    46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 314, 0, 0, 314, 0, 0, 0, 0, 314,
                    0, 0, 0, 0, 0, 314, 0, 0, 0, 314, 314, 314, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 0, 54, 0, 0, 0, 0, 0, 54, 0, 0, 0, 54, 54, 54, 54, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 0, 0, 0,
                    58, 0, 0, 0, 58, 58, 58, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62,
                    0, 0, 62, 0, 0, 0, 0, 62, 0, 0, 0, 0, 0, 62, 0, 0, 0, 62, 62, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0, 0, 0, 66, 653, 657, 661, 66,
                    66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 82, 0, 0,
                    0, 0, 82, 0, 0, 0, 0, 0, 82, 82, 82, 82, 82, 82, 82, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86, 0, 0, 0, 0, 0, 86, 86, 86, 86, 86, 86, 86, 86,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 90, 0,
                    0, 0, 0, 0, 90, 90, 90, 90, 90, 90, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102, 0, 0, 0, 0, 0, 102, 102, 102, 102, 102, 102, 102, 102, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 0, 110, 0, 0, 0, 0, 110, 0,
                    0, 0, 0, 0, 110, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 0, 0, 0, 0, 0, 118, 118, 118, 118, 118, 118, 118,
                    118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 453, 0, 0, 457, 0, 0, 0, 0,
                    461, 0, 0, 0, 0, 0, 50, 0, 0, 0, 465, 469, 473, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    665, 409, 413, 417, 421, 425, 429, 433, 437, 441, 445, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 126, 0, 0, 0, 0, 126, 0, 0, 0, 0, 0, 126, 126, 126,
                    126, 126, 126, 126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0,
                    0, 122, 0, 0, 0, 0, 122, 0, 0, 0, 0, 0, 122, 122, 122, 122, 122, 122, 122, 122, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 669, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 453, 0, 0, 457, 0,
                    0, 0, 0, 461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 673, 437, 441, 445, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 453, 0, 0, 457, 0, 0, 0, 0, 461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 677, 437, 441, 445, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 453, 0, 0, 457, 0, 0,
                    0, 0, 461, 0, 0, 0, 0, 0, 318, 0, 0, 0, 465, 469, 473, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    681, 397, 401, 405, 409, 413, 417, 421, 425, 429, 433, 437, 441, 445, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 449, 0, 0, 0, 0, 0, 0, 134, 0, 0, 0, 0, 0, 0, 0, 0, 134, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 685, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 317, 0, 321, 325, 329, 333, 337, 0, 0, 0, 0, 0, 370, 0, 370, 0, 0, 0, 0, 0,
                    341, 0, 0, 370, 345, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 253, 0,
                    0, 0, 689, 265, 269, 273, 277, 281, 285, 289, 0, 293, 297, 301, 305, 309, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 313, 0, 745, 0, 749, 753, 757, 761, 765, 0, 0, 0, 0, 0, 370, 0, 370, 0, 0, 0, 0, 0, 769, 0, 0, 0,
                    773, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 693, 0, 0, 0, 0, 0, 697,
                    701, 705, 709, 713, 717, 0, 721, 725, 729, 733, 737, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 741, 0, 190, 0, 190,
                    190, 190, 190, 190, 0, 0, 0, 0, 0, 190, 0, 190, 0, 0, 0, 0, 0, 190, 0, 0, 190, 190, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 777, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178,
                    178, 178, 0, 0, 0, 0, 0, 178, 0, 178, 0, 0, 0, 0, 0, 178, 0, 0, 178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 182, 0, 182, 0, 0, 0,
                    0, 0, 182, 0, 0, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186,
                    186, 186, 186, 0, 0, 0, 0, 0, 186, 0, 186, 0, 0, 0, 0, 0, 186, 0, 0, 186, 186, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 785, 0, 0, 789, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 781, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 362, 362, 362, 362,
                    362, 0, 0, 0, 0, 0, 362, 0, 362, 0, 0, 0, 0, 0, 362, 0, 0, 362, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 238, 238, 238, 238, 238, 0, 238, 0, 0, 0, 0, 0, 238, 238, 238, 238,
                    0, 0, 238, 238, 0, 238, 238, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 793, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 0, 0, 0, 0, 0, 358, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 797, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 146, 0, 0, 0, 0, 0, 0, 146, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 142, 0, 0, 0, 0, 0, 0, 142, 0, 805, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 366, 366, 366, 366, 366, 0, 0, 0, 0, 0, 0, 0, 366, 0, 0,
                    0, 0, 0, 366, 366, 0, 366, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0,
                    158, 158, 158, 158, 158, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 0, 158, 158, 0, 158, 158, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0, 0, 0, 0, 0, 0, 0,
                    162, 0, 0, 0, 0, 0, 162, 162, 0, 162, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 0, 0, 166, 0, 0, 0, 0, 0, 166, 166, 0, 166, 166, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0,
                    0, 0, 170, 0, 0, 0, 0, 0, 170, 170, 0, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 174, 0, 174, 174, 174, 174, 174, 0, 813, 0, 0, 0, 0, 0, 174, 817, 821, 825, 0, 0, 174, 174, 0,
                    174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 809, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202,
                    0, 202, 0, 0, 0, 0, 0, 202, 202, 202, 202, 0, 0, 202, 202, 0, 202, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 198, 0, 0, 0, 0, 0, 198, 198, 198,
                    198, 0, 0, 198, 198, 0, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0,
                    222, 222, 222, 222, 222, 0, 222, 0, 0, 0, 0, 0, 222, 222, 222, 222, 0, 0, 222, 222, 0, 222, 222, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 829, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 585, 0, 589,
                    593, 597, 601, 605, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 0, 0, 0, 609, 154, 0, 154, 613, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 521, 0, 0, 0, 0, 0, 0, 833, 545, 549, 553, 557,
                    0, 561, 565, 569, 573, 577, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 126, 126, 126, 126, 126, 0, 126,
                    0, 0, 0, 0, 0, 126, 126, 126, 126, 0, 0, 126, 126, 0, 126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214, 214, 0, 214, 0, 0, 0, 0, 0, 214, 214, 214, 214, 0, 0,
                    214, 214, 0, 214, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218,
                    218, 218, 218, 0, 218, 0, 0, 0, 0, 0, 218, 218, 218, 218, 0, 0, 218, 218, 0, 218, 218, 250, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 0,
                    0, 230, 230, 230, 230, 0, 0, 230, 230, 0, 230, 230, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 0, 234, 234, 234, 234, 0, 0, 234, 234,
                    0, 234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226,
                    0, 226, 0, 0, 0, 0, 0, 226, 226, 226, 226, 0, 0, 226, 226, 0, 226, 226, 246, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 585, 0, 589, 593, 597, 601, 605, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0,
                    0, 0, 609, 370, 0, 370, 613, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    521, 0, 0, 837, 529, 533, 537, 541, 545, 549, 553, 557, 0, 561, 565, 569, 573, 577, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 581, 0, 585, 0, 589, 593, 597, 601, 605, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 521, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 841, 573, 577, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210,
                    210, 0, 210, 0, 0, 0, 210, 0, 210, 210, 210, 210, 0, 0, 210, 0, 0, 210, 210, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 229, 0, 0, 233, 0, 0, 0, 0, 237, 0, 0, 0, 318, 0, 318, 0, 0, 0, 241,
                    245, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 845, 177, 181, 185, 189, 193, 197, 201, 205,
                    209, 213, 217, 221, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 225, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 302, 0, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 909, 0, 0, 913, 0, 0, 0, 0, 917, 318, 0, 0, 0, 0, 318, 0, 0,
                    0, 921, 925, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 849, 853, 857, 861, 865, 869, 873, 877,
                    881, 885, 889, 893, 897, 901, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 905,
                    0, 0, 0, 0, 0, 0, 322, 0, 0, 322, 0, 0, 0, 0, 322, 322, 0, 0, 0, 0, 322, 0, 0, 0, 322, 322, 322, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 326, 0, 0, 326, 0, 0, 0, 0, 326, 326,
                    0, 0, 0, 0, 326, 0, 0, 0, 326, 326, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 106, 0, 0, 106, 0, 0, 0, 0, 106, 0, 0, 0, 106, 0, 106, 106, 106, 106, 106, 106, 106, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 933, 0, 0, 0, 0, 0, 0, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    453, 0, 0, 457, 0, 0, 0, 0, 461, 0, 0, 0, 0, 0, 318, 0, 0, 0, 465, 469, 473, 318, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 937, 401, 405, 409, 413, 417, 421, 425, 429, 433, 437, 441, 445, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 449, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0,
                    70, 0, 0, 0, 0, 0, 70, 0, 0, 0, 70, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 0, 0, 0, 0, 0, 74, 0, 0, 0, 74, 74, 74, 74, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 78, 0, 0, 0, 0, 0,
                    78, 0, 0, 0, 78, 78, 78, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 310,
                    0, 0, 310, 0, 0, 0, 0, 310, 0, 0, 0, 0, 0, 310, 0, 0, 0, 310, 310, 310, 310, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 633, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 941, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0,
                    0, 0, 94, 0, 0, 0, 0, 0, 94, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 0, 0, 0, 98, 98, 98, 98, 98, 98, 98, 98,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 945, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 317, 0, 321, 325, 329, 333, 337, 0, 0, 0, 0, 0, 370, 0, 370, 0, 0, 0, 0, 0, 341, 0, 0, 370, 345, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 253, 0, 0, 0, 949, 265, 269, 273,
                    277, 281, 285, 289, 0, 293, 297, 301, 305, 309, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 313, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 354, 0, 354, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 238, 0, 238, 238, 238, 238, 238, 0, 238, 0, 0, 0, 238, 0, 238, 238, 238, 238, 0,
                    0, 238, 0, 0, 0, 238, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 150, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 366, 0, 366, 366, 366, 366, 366, 0, 0, 0, 0, 0, 366, 0, 366, 0, 0, 0, 0, 0, 366, 0, 0,
                    0, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 158, 158, 158, 158, 158,
                    0, 0, 0, 0, 0, 158, 0, 158, 0, 0, 0, 0, 0, 158, 0, 0, 0, 158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0, 0, 0, 0, 0, 162, 0, 162, 0, 0, 0, 0, 0, 162,
                    0, 0, 0, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166,
                    166, 0, 0, 0, 0, 0, 166, 0, 166, 0, 0, 0, 0, 0, 166, 0, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 170, 0, 170, 0, 0, 0, 0, 0, 170,
                    0, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174, 174, 174,
                    174, 0, 957, 0, 0, 0, 174, 0, 174, 961, 965, 969, 0, 0, 174, 0, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 953, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0, 202, 0, 0, 0, 202, 0, 202, 202,
                    202, 202, 0, 0, 202, 0, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198,
                    0, 198, 198, 198, 198, 198, 0, 198, 0, 0, 0, 198, 0, 198, 198, 198, 198, 0, 0, 198, 0, 0, 0, 198, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0,
                    0, 0, 222, 0, 222, 222, 222, 222, 0, 0, 222, 0, 0, 0, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 973, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 745, 0, 749, 753, 757, 761, 765, 0, 0, 0, 0, 0,
                    154, 0, 154, 0, 0, 0, 0, 0, 769, 0, 0, 0, 773, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 693, 0, 0, 0, 0, 0, 0, 977, 705, 709, 713, 717, 0, 721, 725, 729, 733, 737, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 126, 126, 126, 126, 126, 0, 126, 0, 0, 0, 126, 0, 126, 126, 126, 126,
                    0, 0, 126, 0, 0, 0, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214,
                    214, 214, 214, 0, 214, 0, 0, 0, 214, 0, 214, 214, 214, 214, 0, 0, 214, 0, 0, 0, 214, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218, 218, 218, 218, 0, 218, 0, 0, 0, 218, 0, 218,
                    218, 218, 218, 0, 0, 218, 0, 0, 0, 218, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    230, 0, 230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 230, 0, 230, 230, 230, 230, 0, 0, 230, 0, 0, 0, 230,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234,
                    0, 0, 0, 234, 0, 234, 234, 234, 234, 0, 0, 234, 0, 0, 0, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226, 0, 226, 0, 0, 0, 226, 0, 226, 226, 226, 226, 0,
                    0, 226, 0, 0, 0, 226, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 585, 0, 589, 593,
                    597, 601, 605, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 609, 370, 0, 370, 613, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 521, 0, 0, 981, 529, 533, 537, 541, 545, 549, 553, 557,
                    0, 561, 565, 569, 573, 577, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 581, 0, 745, 0, 749, 753, 757, 761, 765, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 693, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 985, 733, 737, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 0, 993, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 989, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0,
                    0, 242, 0, 242, 242, 242, 242, 0, 0, 242, 0, 0, 242, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250, 250, 0, 250, 0, 0, 0, 250, 0, 250, 250, 250, 250, 0, 0, 250,
                    0, 0, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 246, 246, 246, 246,
                    246, 0, 246, 0, 0, 0, 246, 0, 246, 246, 246, 246, 0, 0, 246, 0, 0, 246, 246, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 206, 0, 206, 206,
                    206, 206, 0, 0, 206, 0, 0, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 997, 0, 0, 0, 0, 0, 0, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 585, 0, 589, 593, 597, 601, 605, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0,
                    0, 609, 370, 0, 370, 613, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 521,
                    0, 0, 0, 1001, 533, 537, 541, 545, 549, 553, 557, 0, 561, 565, 569, 573, 577, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 581, 0, 1057, 0, 1061, 1065, 1069, 1073, 1077, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 1081, 370,
                    0, 0, 1085, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1005, 0, 0, 0, 0,
                    0, 1009, 1013, 1017, 1021, 1025, 1029, 0, 1033, 1037, 1041, 1045, 1049, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1053, 0, 190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 0, 190, 0, 0, 0, 0, 0, 190, 190, 0, 190,
                    190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1089, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    178, 0, 178, 178, 178, 178, 178, 0, 0, 0, 0, 0, 0, 0, 178, 0, 0, 0, 0, 0, 178, 178, 0, 178, 178, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0,
                    0, 0, 182, 0, 0, 0, 0, 0, 182, 182, 0, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 0, 0, 0, 0, 0, 0, 186, 0, 0, 0, 0, 0, 186, 186, 0, 186, 186,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1097, 0, 0, 1101, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1093, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    362, 0, 362, 362, 362, 362, 362, 0, 0, 0, 0, 0, 0, 0, 362, 0, 0, 0, 0, 0, 362, 362, 0, 362, 362, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210,
                    210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 0, 210, 210, 210, 210, 0, 0, 210, 210, 0, 210, 210, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 298, 0, 298, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 1109, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 306, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1113, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 0,
                    46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 314, 0,
                    0, 314, 0, 0, 0, 0, 314, 314, 0, 0, 0, 0, 314, 0, 0, 0, 314, 314, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 0, 54, 54, 0, 0, 0, 0, 54, 0, 0, 0,
                    54, 54, 54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58, 0,
                    0, 0, 0, 58, 58, 0, 0, 0, 0, 58, 0, 0, 0, 58, 58, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 62, 0, 0, 0, 0, 62, 0, 0, 0, 62, 62, 62, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 66, 0,
                    0, 0, 0, 66, 1121, 1125, 1129, 66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 82, 0, 0, 82, 0, 0, 0, 0, 82, 82, 0, 0, 0, 0, 82, 82, 82, 82, 82, 82, 82, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86, 86, 0, 0, 0, 0,
                    86, 86, 86, 86, 86, 86, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90,
                    0, 0, 90, 0, 0, 0, 0, 90, 90, 0, 0, 0, 0, 90, 90, 90, 90, 90, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102, 102, 0, 0, 0, 0, 102, 102, 102,
                    102, 102, 102, 102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0,
                    0, 110, 0, 0, 0, 0, 110, 110, 0, 0, 0, 0, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 118, 0, 0, 0, 0, 118,
                    118, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    909, 0, 0, 913, 0, 0, 0, 0, 917, 50, 0, 0, 0, 0, 50, 0, 0, 0, 921, 925, 929, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1133, 865, 869, 873, 877, 881, 885, 889, 893, 897, 901, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 126, 0, 0, 0, 0, 126,
                    126, 0, 0, 0, 0, 126, 126, 126, 126, 126, 126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 122, 0, 0, 122, 0, 0, 0, 0, 122, 122, 0, 0, 0, 0, 122, 122, 122, 122, 122, 122,
                    122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1137, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 909, 0, 0, 913, 0, 0, 0, 0, 917, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 929, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1141, 893, 897, 901, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 909, 0, 0, 913, 0, 0, 0, 0, 917, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1145, 893, 897, 901, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 453, 0, 0, 457, 0, 0, 0, 0, 461, 0, 0, 0, 0, 0, 318, 0, 0, 0, 465, 469, 473, 318, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1149, 397, 401, 405, 409, 413, 417, 421, 425, 429, 433, 437, 441, 445,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 449, 0, 0, 0, 0, 0, 0, 453, 0, 0, 457,
                    0, 0, 0, 0, 461, 0, 0, 0, 0, 0, 318, 0, 0, 0, 465, 469, 473, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 1153, 401, 405, 409, 413, 417, 421, 425, 429, 433, 437, 441, 445, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 449, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 302, 0, 0, 0, 0, 0, 0, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 909,
                    0, 0, 913, 0, 0, 0, 0, 917, 318, 0, 0, 0, 0, 318, 0, 0, 0, 921, 925, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1157, 853, 857, 861, 865, 869, 873, 877, 881, 885, 889, 893, 897, 901, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 905, 0, 0, 0, 0, 0, 0, 106, 0, 0, 106, 0, 0, 0,
                    0, 106, 0, 0, 0, 0, 0, 106, 106, 106, 106, 106, 106, 106, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 350, 0, 350, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0,
                    0, 0, 0, 0, 190, 0, 190, 0, 0, 0, 0, 0, 190, 0, 0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1161, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 0, 0, 0, 0,
                    178, 0, 178, 0, 0, 0, 0, 0, 178, 0, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 182, 0, 182, 0, 0, 0, 0, 0, 182, 0, 0, 0, 182,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 0, 0,
                    0, 0, 186, 0, 186, 0, 0, 0, 0, 0, 186, 0, 0, 0, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1169, 0, 0, 1173, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 1165, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 362, 362, 362, 362, 362, 0, 0, 0, 0, 0,
                    362, 0, 362, 0, 0, 0, 0, 0, 362, 0, 0, 0, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1177, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 210, 0, 210,
                    210, 210, 210, 0, 0, 210, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1181, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1185, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 585, 0, 589, 593, 597, 601, 605,
                    0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 609, 370, 0, 370, 613, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 521, 0, 0, 0, 1189, 533, 537, 541, 545, 549, 553, 557, 0, 561, 565,
                    569, 573, 577, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 581, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 354, 0,
                    0, 0, 0, 0, 0, 354, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 238,
                    238, 238, 238, 238, 0, 238, 0, 0, 0, 0, 0, 238, 238, 238, 238, 0, 0, 238, 238, 0, 0, 238, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0,
                    0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 366, 366,
                    366, 366, 366, 0, 0, 0, 0, 0, 0, 0, 366, 0, 0, 0, 0, 0, 366, 366, 0, 0, 366, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 158, 158, 158, 158, 158, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0,
                    0, 0, 0, 158, 158, 0, 0, 158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 162,
                    162, 162, 162, 162, 0, 0, 0, 0, 0, 0, 0, 162, 0, 0, 0, 0, 0, 162, 162, 0, 0, 162, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 0, 0, 166, 0,
                    0, 0, 0, 0, 166, 166, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0,
                    170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0, 0, 170, 0, 0, 0, 0, 0, 170, 170, 0, 0, 170, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174, 174, 174, 174, 0, 1197, 0, 0, 0, 0, 0,
                    174, 1201, 1205, 1209, 0, 0, 174, 174, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1193, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0, 202, 0, 0, 0, 0, 0, 202, 202, 202, 202, 0, 0, 202, 202,
                    0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198,
                    0, 198, 0, 0, 0, 0, 0, 198, 198, 198, 198, 0, 0, 198, 198, 0, 0, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0, 0, 0, 0, 0, 222, 222, 222, 222,
                    0, 0, 222, 222, 0, 0, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1057, 0, 1061, 1065, 1069, 1073, 1077, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 0, 0, 0,
                    1081, 154, 0, 0, 1085, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1005,
                    0, 0, 0, 0, 0, 0, 1217, 1017, 1021, 1025, 1029, 0, 1033, 1037, 1041, 1045, 1049, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 126, 0, 126, 126, 126, 126, 126, 0, 126, 0, 0, 0, 0, 0, 126, 126, 126, 126, 0, 0, 126,
                    126, 0, 0, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214,
                    214, 0, 214, 0, 0, 0, 0, 0, 214, 214, 214, 214, 0, 0, 214, 214, 0, 0, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218, 218, 218, 218, 0, 218, 0, 0, 0, 0, 0, 218, 218, 218,
                    218, 0, 0, 218, 218, 0, 0, 218, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0,
                    230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 0, 0, 230, 230, 230, 230, 0, 0, 230, 230, 0, 0, 230, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0,
                    0, 0, 0, 234, 234, 234, 234, 0, 0, 234, 234, 0, 0, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226, 0, 226, 0, 0, 0, 0, 0, 226, 226, 226, 226, 0, 0, 226,
                    226, 0, 0, 226, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 585, 0, 589, 593, 597,
                    601, 605, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 609, 370, 0, 370, 613, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 521, 0, 0, 1221, 529, 533, 537, 541, 545, 549, 553, 557,
                    0, 561, 565, 569, 573, 577, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 581, 0, 1057, 0, 1061, 1065, 1069, 1073, 1077,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1005, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1225, 1045, 1049, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 0, 993, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1229, 242, 0, 242, 242, 242, 242, 242, 0, 242,
                    0, 0, 0, 0, 0, 242, 242, 242, 242, 0, 0, 242, 242, 0, 242, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250, 250, 0, 250, 0, 0, 0, 0, 0, 250, 250, 250, 250, 0, 0,
                    250, 250, 0, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 246, 246,
                    246, 246, 246, 0, 246, 0, 0, 0, 0, 0, 246, 246, 246, 246, 0, 0, 246, 246, 0, 246, 246, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 0, 0,
                    206, 206, 206, 206, 0, 0, 206, 206, 0, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 114, 0, 0, 114, 0, 0, 0, 0, 114, 0, 0, 0, 114, 0, 114, 114, 114, 114, 114, 114, 114, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 42, 0, 0, 0, 0,
                    1233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 909,
                    0, 0, 913, 0, 0, 0, 0, 917, 318, 0, 0, 0, 0, 318, 0, 0, 0, 921, 925, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1237, 857, 861, 865, 869, 873, 877, 881, 885, 889, 893, 897, 901, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 905, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70,
                    70, 0, 0, 0, 0, 70, 0, 0, 0, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 74, 0, 0, 0, 0, 74, 0, 0, 0, 74, 74, 74, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 78, 78, 0, 0, 0, 0, 78,
                    0, 0, 0, 78, 78, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 310, 0,
                    0, 310, 0, 0, 0, 0, 310, 310, 0, 0, 0, 0, 310, 0, 0, 0, 310, 310, 310, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 633, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1241, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0,
                    0, 0, 94, 94, 0, 0, 0, 0, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 98, 0, 0, 0, 0, 98, 98, 98, 98, 98, 98, 98, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1245, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 298, 0, 0, 0, 0, 0, 0, 298, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    378, 0, 0, 0, 0, 0, 0, 0, 0, 993, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1253, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 242, 0, 242, 242, 242, 242, 0, 0, 242,
                    0, 0, 0, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250,
                    250, 0, 250, 0, 0, 0, 250, 0, 250, 250, 250, 250, 0, 0, 250, 0, 0, 0, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 246, 0, 246, 246,
                    246, 246, 0, 0, 246, 0, 0, 0, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206,
                    0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 206, 0, 206, 206, 206, 206, 0, 0, 206, 0, 0, 0, 206, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0, 0, 0, 0,
                    0, 194, 0, 194, 0, 0, 0, 0, 0, 194, 0, 0, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 350, 0, 0, 0,
                    0, 0, 0, 350, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 190, 190,
                    190, 190, 190, 0, 0, 0, 0, 0, 0, 0, 190, 0, 0, 0, 0, 0, 190, 190, 0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1257, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178,
                    0, 0, 0, 0, 0, 0, 0, 178, 0, 0, 0, 0, 0, 178, 178, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 0, 182, 0, 0, 0, 0, 0, 182, 182,
                    0, 0, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186,
                    0, 0, 0, 0, 0, 0, 0, 186, 0, 0, 0, 0, 0, 186, 186, 0, 0, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1265, 0, 0, 1269, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1261, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 362, 362, 362, 362, 362, 0, 0,
                    0, 0, 0, 0, 0, 362, 0, 0, 0, 0, 0, 362, 362, 0, 0, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1273, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0,
                    0, 0, 210, 210, 210, 210, 0, 0, 210, 210, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1277, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 909, 0, 0, 913, 0, 0, 0, 0, 917, 318, 0, 0, 0, 0, 318,
                    0, 0, 0, 921, 925, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1281, 857, 861, 865, 869, 873,
                    877, 881, 885, 889, 893, 897, 901, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    905, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 302, 0, 0, 0, 0, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 909, 0, 0, 913, 0, 0, 0, 0, 917, 318, 0,
                    0, 0, 0, 318, 0, 0, 0, 921, 925, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1285, 853, 857, 861,
                    865, 869, 873, 877, 881, 885, 889, 893, 897, 901, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 905, 0, 0, 0, 0, 0, 0, 106, 0, 0, 106, 0, 0, 0, 0, 106, 106, 0, 0, 0, 0, 106, 106, 106,
                    106, 106, 106, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0,
                    0, 114, 0, 0, 0, 0, 114, 0, 0, 0, 0, 0, 114, 114, 114, 114, 114, 114, 114, 114, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1289, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 0, 993, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1293, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 0, 242, 242, 242, 242, 0, 0,
                    242, 242, 0, 0, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250,
                    250, 250, 0, 250, 0, 0, 0, 0, 0, 250, 250, 250, 250, 0, 0, 250, 250, 0, 0, 250, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 0, 0, 246, 246,
                    246, 246, 0, 0, 246, 246, 0, 0, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206,
                    0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 0, 0, 206, 206, 206, 206, 0, 0, 206, 206, 0, 0, 206, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0, 0, 0, 0,
                    0, 0, 0, 194, 0, 0, 0, 0, 0, 194, 194, 0, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 298, 0, 0, 0, 0, 298, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1297, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194,
                    194, 194, 0, 0, 0, 0, 0, 194, 0, 194, 0, 0, 0, 0, 0, 194, 0, 0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1301, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 0, 114, 0, 0, 0, 0, 114, 114,
                    0, 0, 0, 0, 114, 114, 114, 114, 114, 114, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0, 0, 0, 0, 0, 0, 0, 194, 0, 0, 0, 0, 0, 194, 194,
                    0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                };
                
                return U16ParseTable.From(u16Table, 326, 79, 29);
            }
            
            public static readonly TerminalSymbol identifier = new TerminalSymbol(0, "identifier", true, "");
            public static readonly TerminalSymbol number = new TerminalSymbol(1, "number", true, "");
            public static readonly TerminalSymbol any = new TerminalSymbol(2, "any", true, "");
            public static readonly TerminalSymbol text = new TerminalSymbol(3, "text", true, "");
            public static readonly TerminalSymbol ucBlock = new TerminalSymbol(4, "ucBlock", true, "");
            public static readonly TerminalSymbol ucCategory = new TerminalSymbol(5, "ucCategory", true, "");
            public static readonly TerminalSymbol ucCodepoint = new TerminalSymbol(6, "ucCodepoint", true, "");
            public static readonly TerminalSymbol __T1 = new TerminalSymbol(7, "__T1", false, "grammar");
            public static readonly TerminalSymbol __T2 = new TerminalSymbol(8, "__T2", false, "{");
            public static readonly TerminalSymbol __T3 = new TerminalSymbol(9, "__T3", false, "}");
            public static readonly TerminalSymbol __T4 = new TerminalSymbol(10, "__T4", false, "options");
            public static readonly TerminalSymbol __T5 = new TerminalSymbol(11, "__T5", false, "=");
            public static readonly TerminalSymbol __T6 = new TerminalSymbol(12, "__T6", false, ";");
            public static readonly TerminalSymbol __T7 = new TerminalSymbol(13, "__T7", false, "rules");
            public static readonly TerminalSymbol __T8 = new TerminalSymbol(14, "__T8", false, "|");
            public static readonly TerminalSymbol __T9 = new TerminalSymbol(15, "__T9", true, "?");
            public static readonly TerminalSymbol __T10 = new TerminalSymbol(16, "__T10", true, "*");
            public static readonly TerminalSymbol __T11 = new TerminalSymbol(17, "__T11", true, "+");
            public static readonly TerminalSymbol __T12 = new TerminalSymbol(18, "__T12", false, ",");
            public static readonly TerminalSymbol __T13 = new TerminalSymbol(19, "__T13", false, "^");
            public static readonly TerminalSymbol __T14 = new TerminalSymbol(20, "__T14", false, "(");
            public static readonly TerminalSymbol __T15 = new TerminalSymbol(21, "__T15", false, ")");
            public static readonly TerminalSymbol __T16 = new TerminalSymbol(22, "__T16", false, "terminals");
            public static readonly TerminalSymbol __T17 = new TerminalSymbol(23, "__T17", false, "-");
            public static readonly TerminalSymbol __T18 = new TerminalSymbol(24, "__T18", false, "~");
            public static readonly TerminalSymbol __T19 = new TerminalSymbol(25, "__T19", false, "..");
            public static readonly TerminalSymbol __T20 = new TerminalSymbol(26, "__T20", true, ":");
            public static readonly TerminalSymbol __T21 = new TerminalSymbol(27, "__T21", true, "->");
            public static readonly TerminalSymbol __eof = new TerminalSymbol(28, "__eof", false, "$eof$");
            public static readonly NonterminalSymbol file = new NonterminalSymbol(29, "file", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol angrammar = new NonterminalSymbol(30, "angrammar", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_item = new NonterminalSymbol(31, "grammar_item", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_options = new NonterminalSymbol(32, "grammar_options", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol option = new NonterminalSymbol(33, "option", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_rules = new NonterminalSymbol(34, "grammar_rules", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule = new NonterminalSymbol(35, "rule", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_expression = new NonterminalSymbol(36, "rule_expression", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_alternative = new NonterminalSymbol(37, "rule_alternative", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_sequence = new NonterminalSymbol(38, "rule_sequence", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_repetition = new NonterminalSymbol(39, "rule_repetition", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_optional = new NonterminalSymbol(40, "rule_optional", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_star_closure = new NonterminalSymbol(41, "rule_star_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_plus_closure = new NonterminalSymbol(42, "rule_plus_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_tree_action = new NonterminalSymbol(43, "rule_tree_action", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_drop_element = new NonterminalSymbol(44, "rule_drop_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_promote_element = new NonterminalSymbol(45, "rule_promote_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_element = new NonterminalSymbol(46, "rule_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol sub_rule = new NonterminalSymbol(47, "sub_rule", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_atom = new NonterminalSymbol(48, "rule_atom", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol reference = new NonterminalSymbol(49, "reference", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_terminals = new NonterminalSymbol(50, "grammar_terminals", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_rule = new NonterminalSymbol(51, "terminal_rule", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_expression = new NonterminalSymbol(52, "terminal_expression", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_alternative = new NonterminalSymbol(53, "terminal_alternative", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_diff = new NonterminalSymbol(54, "terminal_diff", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_sequence = new NonterminalSymbol(55, "terminal_sequence", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_repetition = new NonterminalSymbol(56, "terminal_repetition", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_optional = new NonterminalSymbol(57, "terminal_optional", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_star_closure = new NonterminalSymbol(58, "terminal_star_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_plus_closure = new NonterminalSymbol(59, "terminal_plus_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_range_loop = new NonterminalSymbol(60, "terminal_range_loop", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol range = new NonterminalSymbol(61, "range", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_element = new NonterminalSymbol(62, "terminal_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_not = new NonterminalSymbol(63, "terminal_not", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_atom = new NonterminalSymbol(64, "terminal_atom", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol characterRange = new NonterminalSymbol(65, "characterRange", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol character = new NonterminalSymbol(66, "character", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(67, "__N1", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(68, "__N2", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N3 = new NonterminalSymbol(69, "__N3", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N4 = new NonterminalSymbol(70, "__N4", true, RepeatKind.None, LiftKind.Alternate);
            public static readonly NonterminalSymbol __N5 = new NonterminalSymbol(71, "__N5", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N6 = new NonterminalSymbol(72, "__N6", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N7 = new NonterminalSymbol(73, "__N7", true, RepeatKind.None, LiftKind.Alternate);
            public static readonly NonterminalSymbol __N8 = new NonterminalSymbol(74, "__N8", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N9 = new NonterminalSymbol(75, "__N9", true, RepeatKind.None, LiftKind.Alternate);
            public static readonly NonterminalSymbol __N10 = new NonterminalSymbol(76, "__N10", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N11 = new NonterminalSymbol(77, "__N11", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N12 = new NonterminalSymbol(78, "__N12", true, RepeatKind.Optional, LiftKind.Optional);
            public static readonly TerminalSymbol newline = new TerminalSymbol(79, "newline", false, "");
            public static readonly TerminalSymbol newlineChar = new TerminalSymbol(80, "newlineChar", false, "");
            public static readonly TerminalSymbol whitespace = new TerminalSymbol(81, "whitespace", false, "");
            public static readonly TerminalSymbol lineComment = new TerminalSymbol(82, "lineComment", false, "");
            public static readonly TerminalSymbol blockComment = new TerminalSymbol(83, "blockComment", false, "");
            public static readonly TerminalSymbol spacing = new TerminalSymbol(84, "spacing", false, "");
            public static readonly TerminalSymbol identifierStart = new TerminalSymbol(85, "identifierStart", false, "");
            public static readonly TerminalSymbol identifierContinue = new TerminalSymbol(86, "identifierContinue", false, "");
            public static readonly TerminalSymbol digit = new TerminalSymbol(87, "digit", false, "");
            public static readonly TerminalSymbol nonzeroDigit = new TerminalSymbol(88, "nonzeroDigit", false, "");
            public static readonly TerminalSymbol zero = new TerminalSymbol(89, "zero", false, "");
            public static readonly TerminalSymbol hexDigit = new TerminalSymbol(90, "hexDigit", false, "");
            public static readonly TerminalSymbol escapes = new TerminalSymbol(91, "escapes", false, "");
            public static readonly TerminalSymbol ucNameStart = new TerminalSymbol(92, "ucNameStart", false, "");
            public static readonly TerminalSymbol ucNameInner = new TerminalSymbol(93, "ucNameInner", false, "");
            public static readonly TerminalSymbol ucNameEnd = new TerminalSymbol(94, "ucNameEnd", false, "");
            public static readonly TerminalSymbol ucName = new TerminalSymbol(95, "ucName", false, "");
            public static readonly NonterminalSymbol __acc = new NonterminalSymbol(96, "__acc", true, RepeatKind.None, LiftKind.None);
            
            public static readonly Symbol[] Symbols = 
            {
                identifier, number, any, text, ucBlock, ucCategory, ucCodepoint, __T1, __T2, __T3, __T4, __T5, __T6, __T7,
                __T8, __T9, __T10, __T11, __T12, __T13, __T14, __T15, __T16, __T17, __T18, __T19, __T20, __T21, __eof, file,
                angrammar, grammar_item, grammar_options, option, grammar_rules, rule, rule_expression, rule_alternative,
                rule_sequence, rule_repetition, rule_optional, rule_star_closure, rule_plus_closure, rule_tree_action, rule_drop_element,
                rule_promote_element, rule_element, sub_rule, rule_atom, reference, grammar_terminals, terminal_rule, terminal_expression,
                terminal_alternative, terminal_diff, terminal_sequence, terminal_repetition, terminal_optional, terminal_star_closure,
                terminal_plus_closure, terminal_range_loop, range, terminal_element, terminal_not, terminal_atom, characterRange,
                character, __N1, __N2, __N3, __N4, __N5, __N6, __N7, __N8, __N9, __N10, __N11, __N12, newline, newlineChar,
                whitespace, lineComment, blockComment, spacing, identifierStart, identifierContinue, digit, nonzeroDigit,
                zero, hexDigit, escapes, ucNameStart, ucNameInner, ucNameEnd, ucName, __acc,
            };
            
            public static readonly Production[] Productions = 
            {
                new Production(__acc, false, "__acc -> ^file", false),
                new Production(file, false, "file -> ^angrammar", false),
                new Production(angrammar, false, "angrammar -> ,'grammar' ^ˈidentifierˈ ,'{' ^__N1 ,'}'", true, false, true, false, true),
                new Production(grammar_item, true, "grammar_item -> ^grammar_options", false),
                new Production(grammar_item, true, "grammar_item -> ^grammar_rules", false),
                new Production(grammar_item, true, "grammar_item -> ^grammar_terminals", false),
                new Production(grammar_options, false, "grammar_options -> ,'options' ,'{' ^__N2 ,'}'", true, true, false, true),
                new Production(option, false, "option -> ^ˈidentifierˈ ,'=' ^ˈidentifierˈ ,';'", false, true, false, true),
                new Production(grammar_rules, false, "grammar_rules -> ,'rules' ,'{' ^__N3 ,'}'", true, true, false, true),
                new Production(rule, false, "rule -> ^ˈidentifierˈ ,__N4 ^rule_expression ,';'", false, true, false, true),
                new Production(rule_expression, false, "rule_expression -> ^rule_alternative ^__N5", false, false),
                new Production(rule_alternative, true, "rule_alternative -> ^rule_sequence", false),
                new Production(rule_sequence, false, "rule_sequence -> ^__N6", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_optional", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_star_closure", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_plus_closure", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_tree_action", false),
                new Production(rule_optional, false, "rule_optional -> ^rule_tree_action ,'?'", false, true),
                new Production(rule_star_closure, false, "rule_star_closure -> ^rule_tree_action ,'*'", false, true),
                new Production(rule_plus_closure, false, "rule_plus_closure -> ^rule_tree_action ,'+'", false, true),
                new Production(rule_tree_action, true, "rule_tree_action -> ^rule_drop_element", false),
                new Production(rule_tree_action, true, "rule_tree_action -> ^rule_promote_element", false),
                new Production(rule_tree_action, true, "rule_tree_action -> ^rule_element", false),
                new Production(rule_drop_element, false, "rule_drop_element -> ,',' ^rule_element", true, false),
                new Production(rule_promote_element, false, "rule_promote_element -> ,'^' ^rule_element", true, false),
                new Production(rule_element, true, "rule_element -> ^sub_rule", false),
                new Production(rule_element, true, "rule_element -> ,'(' ^rule_expression ,')'", true, false, true),
                new Production(rule_element, true, "rule_element -> ^rule_atom", false),
                new Production(sub_rule, false, "sub_rule -> ,'{' ^ˈidentifierˈ ,__N7 ^rule_expression ,'}'", true, false, true, false, true),
                new Production(rule_atom, true, "rule_atom -> ^reference", false),
                new Production(rule_atom, true, "rule_atom -> ^ˈtextˈ", false),
                new Production(reference, false, "reference -> ^ˈidentifierˈ", false),
                new Production(grammar_terminals, false, "grammar_terminals -> ,'terminals' ,'{' ^__N8 ,'}'", true, true, false, true),
                new Production(terminal_rule, false, "terminal_rule -> ^ˈidentifierˈ ,__N9 ^terminal_expression ,';'", false, true, false, true),
                new Production(terminal_expression, false, "terminal_expression -> ^terminal_alternative ^__N10", false, false),
                new Production(terminal_alternative, true, "terminal_alternative -> ^terminal_sequence", false),
                new Production(terminal_alternative, true, "terminal_alternative -> ^terminal_diff", false),
                new Production(terminal_diff, false, "terminal_diff -> ^terminal_sequence ,'-' ^terminal_sequence", false, true, false),
                new Production(terminal_sequence, false, "terminal_sequence -> ^__N11", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_optional", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_star_closure", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_plus_closure", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_range_loop", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_element", false),
                new Production(terminal_optional, false, "terminal_optional -> ^terminal_element ^'?'", false, false),
                new Production(terminal_star_closure, false, "terminal_star_closure -> ^terminal_element ^'*'", false, false),
                new Production(terminal_plus_closure, false, "terminal_plus_closure -> ^terminal_element ^'+'", false, false),
                new Production(terminal_range_loop, false, "terminal_range_loop -> ^terminal_element ^range", false, false),
                new Production(range, false, "range -> ,'{' ^ˈnumberˈ ^__N12 ,'}'", true, false, false, true),
                new Production(terminal_element, true, "terminal_element -> ^terminal_atom", false),
                new Production(terminal_element, true, "terminal_element -> ^terminal_not", false),
                new Production(terminal_element, true, "terminal_element -> ,'(' ^terminal_expression ,')'", true, false, true),
                new Production(terminal_not, false, "terminal_not -> ,'~' ^terminal_atom", true, false),
                new Production(terminal_atom, true, "terminal_atom -> ^ˈanyˈ", false),
                new Production(terminal_atom, true, "terminal_atom -> ^ˈtextˈ", false),
                new Production(terminal_atom, true, "terminal_atom -> ^characterRange", false),
                new Production(terminal_atom, true, "terminal_atom -> ^ˈucCodepointˈ", false),
                new Production(terminal_atom, true, "terminal_atom -> ^ˈucBlockˈ", false),
                new Production(terminal_atom, true, "terminal_atom -> ^ˈucCategoryˈ", false),
                new Production(terminal_atom, true, "terminal_atom -> ^reference", false),
                new Production(characterRange, false, "characterRange -> ^character ,'..' ^character", false, true, false),
                new Production(character, true, "character -> ^ˈucCodepointˈ", false),
                new Production(character, true, "character -> ^ˈtextˈ", false),
                new Production(__N1, false, "__N1 -> ^__N1 ^grammar_item", false, false),
                new Production(__N1, false, "__N1 -> ^grammar_item", false),
                new Production(__N1, false, "__N1 -> "),
                new Production(__N2, false, "__N2 -> ^__N2 ^option", false, false),
                new Production(__N2, false, "__N2 -> ^option", false),
                new Production(__N2, false, "__N2 -> "),
                new Production(__N3, false, "__N3 -> ^__N3 ^rule", false, false),
                new Production(__N3, false, "__N3 -> ^rule", false),
                new Production(__N3, false, "__N3 -> "),
                new Production(__N4, false, "__N4 -> ^':'", false),
                new Production(__N4, false, "__N4 -> ^'->'", false),
                new Production(__N5, false, "__N5 -> ^__N5 ,'|' ^rule_alternative", false, true, false),
                new Production(__N5, false, "__N5 -> ,'|' ^rule_alternative", true, false),
                new Production(__N5, false, "__N5 -> "),
                new Production(__N6, false, "__N6 -> ^__N6 ^rule_repetition", false, false),
                new Production(__N6, false, "__N6 -> ^rule_repetition", false),
                new Production(__N6, false, "__N6 -> "),
                new Production(__N7, false, "__N7 -> ^':'", false),
                new Production(__N7, false, "__N7 -> ^'->'", false),
                new Production(__N8, false, "__N8 -> ^__N8 ^terminal_rule", false, false),
                new Production(__N8, false, "__N8 -> ^terminal_rule", false),
                new Production(__N8, false, "__N8 -> "),
                new Production(__N9, false, "__N9 -> ^':'", false),
                new Production(__N9, false, "__N9 -> ^'->'", false),
                new Production(__N10, false, "__N10 -> ^__N10 ,'|' ^terminal_alternative", false, true, false),
                new Production(__N10, false, "__N10 -> ,'|' ^terminal_alternative", true, false),
                new Production(__N10, false, "__N10 -> "),
                new Production(__N11, false, "__N11 -> ^__N11 ^terminal_repetition", false, false),
                new Production(__N11, false, "__N11 -> ^terminal_repetition", false),
                new Production(__N11, false, "__N11 -> "),
                new Production(__N12, false, "__N12 -> ,',' ^ˈnumberˈ", true, false),
                new Production(__N12, false, "__N12 -> "),
            };
        }
    }
}
