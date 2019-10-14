namespace Lingu.CC
{
    using System;
    using System.Linq;
    using Lingu.Runtime.Commons;
    using Lingu.Runtime.Concretes;
    using Lingu.Runtime.Lexing;
    using Lingu.Runtime.Parsing;
    using Lingu.Runtime.Structures;
    
    public static partial class LinguContext
    {
        internal static class Data
        {
            public static IDfaSet CreateDfaSet()
            {
                int[] map = 
                {
                    0, 1, 1, 2, 3, 4, 4, 4, 4, 4, 4, 3, 3, 3, 4, 1, 5, 6, 6, 5, 5, 7, 7, 6, 6, 8, 6, 6, 8, 5, 4, 2, 2, 6,
                    4, 9, 9, 9, 6, 4, 10, 10, 10, 11, 11, 11, 12, 12, 9, 9, 9, 9, 13, 13, 13, 13, 13, 13, 13, 12, 9, 13,
                    13, 2, 14, 14, 15, 16, 11, 12, 12, 17, 10, 10, 10, 10, 10, 16, 16, 16, 16, 18, 10, 16, 16, 19, 16, 16,
                    19, 20, 21, 5, 5, 6, 9, 9, 9, 9, 9, 8, 13, 13, 22, 23, 23, 15, 15, 15, 15, 24, 24, 24, 24, 24, 24, 24,
                    23, 15, 24, 24, 2, 14, 14, 15, 6, 12, 10, 25, 10, 26, 10, 10, 10, 27, 10, 28, 22, 23, 23, 29, 20, 20,
                    20, 20, 20, 28, 28, 28, 28, 18, 20, 28, 28, 30, 28, 28, 30, 20, 21, 16, 12, 31, 31, 31, 13, 15, 15, 15,
                    15, 15, 8, 24, 24, 22, 10, 12, 32, 12, 25, 25, 25, 25, 25, 32, 32, 32, 32, 18, 25, 32, 32, 33, 32, 32,
                    33, 20, 21, 34, 16, 16, 16, 16, 23, 20, 35, 20, 26, 20, 20, 20, 27, 20, 22, 28, 36, 37, 37, 31, 31, 31,
                    31, 38, 38, 38, 38, 38, 38, 38, 37, 31, 38, 38, 2, 14, 14, 15, 23, 31, 24, 12, 25, 26, 25, 25, 25, 27,
                    25, 22, 32, 36, 26, 20, 23, 39, 23, 35, 35, 35, 35, 35, 39, 39, 39, 39, 18, 35, 39, 39, 40, 39, 39, 40,
                    20, 21, 34, 28, 28, 28, 28, 13, 31, 31, 31, 31, 31, 8, 38, 38, 22, 36, 34, 32, 32, 32, 32, 10, 36, 23,
                    35, 26, 35, 35, 35, 27, 35, 22, 39, 36, 37, 31, 38, 24, 36, 34, 39, 39, 39, 39, 20, 36, 25, 36, 38, 35,
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
                    /* 17 */ new Set(new Interval(83,83)),
                    /* 18 */ new Set(new Interval(99,99)),
                    /* 19 */ new Set(new Interval(61,61)),
                    /* 20 */ new Set(new Interval(45,45)),
                    /* 21 */ new Set(new Interval(58,58)),
                    /* 22 */ new Set(new Interval(62,62)),
                    /* 23 */ new Set(new Interval(39,39)),
                    /* 24 */ new Set(new Interval(40,40)),
                    /* 25 */ new Set(new Interval(44,44)),
                    /* 26 */ new Set(new Interval(59,59)),
                    /* 27 */ new Set(new Interval(94,94)),
                    /* 28 */ new Set(new Interval(124,124)),
                    /* 29 */ new Set(new Interval(0,38), new Interval(40,91), new Interval(93,1114111)),
                    /* 30 */ new Set(new Interval(92,92)),
                    /* 31 */ new Set(new Interval(39,39), new Interval(48,48), new Interval(92,92), new Interval(97,98), new Interval(102,102), new Interval(110,110), new Interval(114,114), new Interval(116,116), new Interval(118,118)),
                    /* 32 */ new Set(new Interval(48,57), new Interval(65,70), new Interval(97,102)),
                    /* 33 */ new Set(new Interval(46,46)),
                    /* 34 */ new Set(new Interval(65,84), new Interval(86,90), new Interval(95,95), new Interval(97,116), new Interval(118,122)),
                    /* 35 */ new Set(new Interval(85,85), new Interval(117,117)),
                    /* 36 */ new Set(new Interval(126,126)),
                    /* 37 */ new Set(new Interval(43,43)),
                    /* 38 */ new Set(new Interval(98,98)),
                    /* 39 */ new Set(new Interval(65,90), new Interval(97,122)),
                    /* 40 */ new Set(new Interval(32,32), new Interval(45,45), new Interval(95,95)),
                    /* 41 */ new Set(new Interval(48,57), new Interval(65,90), new Interval(97,122)),
                    /* 42 */ new Set(new Interval(42,42)),
                    /* 43 */ new Set(new Interval(63,63)),
                    /* 44 */ new Set(new Interval(41,41)),
                    /* 45 */ new Set(new Interval(48,48)),
                    /* 46 */ new Set(new Interval(49,57)),
                    /* 47 */ new Set(new Interval(48,57)),
                    /* 48 */ new Set(new Interval(9,13), new Interval(32,32), new Interval(133,133), new Interval(8232,8233)),
                    /* 49 */ new Set(new Interval(47,47)),
                    /* 50 */ new Set(new Interval(0,9), new Interval(11,12), new Interval(14,46), new Interval(48,132), new Interval(134,8231), new Interval(8234,1114111)),
                    /* 51 */ new Set(new Interval(10,10), new Interval(13,13), new Interval(133,133), new Interval(8232,8233)),
                    /* 52 */ new Set(new Interval(0,9), new Interval(11,12), new Interval(14,41), new Interval(43,46), new Interval(48,132), new Interval(134,8231), new Interval(8234,1114111)),
                    /* 53 */ new Set(new Interval(0,8), new Interval(14,31), new Interval(33,41), new Interval(43,46), new Interval(48,132), new Interval(134,8231), new Interval(8234,1114111)),
                    /* 54 */ new Set(new Interval(0,41), new Interval(43,46), new Interval(48,1114111)),
                    /* 55 */ new Set(new Interval(0,41), new Interval(43,1114111)),
                    /* 56 */ new Set(new Interval(0,46), new Interval(48,1114111)),
                    /* 57 */ new Set(new Interval(42,42), new Interval(47,47)),
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
                states0[7].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  1 -- '$eof$' -- */
                var states1 = new DfaState[1] {new DfaState(0,true,30)};
                states1[0].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  2 -- ˈidentifierˈ -- */
                var states2 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,0)};
                states2[0].Transitions = new DfaTrans[1] {new DfaTrans(states2[1], sets[4])};
                states2[1].Transitions = new DfaTrans[1] {new DfaTrans(states2[1], sets[5])};
                
                /* dfa  3 -- '{' -- */
                var states3 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,8)};
                states3[0].Transitions = new DfaTrans[1] {new DfaTrans(states3[1], sets[6])};
                states3[1].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  4 -- 'options' | 'rules' | 'terminals' | '}' -- */
                var states4 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,false,-1), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,true,10), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,true,15), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,false,-1), new DfaState(16,false,-1), new DfaState(17,false,-1), new DfaState(18,false,-1), new DfaState(19,false,-1), new DfaState(20,false,-1), new DfaState(21,true,24), new DfaState(22,true,9)};
                states4[0].Transitions = new DfaTrans[4] {new DfaTrans(states4[1], sets[7]), new DfaTrans(states4[8], sets[1]), new DfaTrans(states4[13], sets[8]), new DfaTrans(states4[22], sets[9])};
                states4[1].Transitions = new DfaTrans[1] {new DfaTrans(states4[2], sets[10])};
                states4[2].Transitions = new DfaTrans[1] {new DfaTrans(states4[3], sets[8])};
                states4[3].Transitions = new DfaTrans[1] {new DfaTrans(states4[4], sets[11])};
                states4[4].Transitions = new DfaTrans[1] {new DfaTrans(states4[5], sets[7])};
                states4[5].Transitions = new DfaTrans[1] {new DfaTrans(states4[6], sets[12])};
                states4[6].Transitions = new DfaTrans[1] {new DfaTrans(states4[7], sets[13])};
                states4[7].Transitions = Array.Empty<DfaTrans>();
                states4[8].Transitions = new DfaTrans[1] {new DfaTrans(states4[9], sets[14])};
                states4[9].Transitions = new DfaTrans[1] {new DfaTrans(states4[10], sets[15])};
                states4[10].Transitions = new DfaTrans[1] {new DfaTrans(states4[11], sets[16])};
                states4[11].Transitions = new DfaTrans[1] {new DfaTrans(states4[12], sets[13])};
                states4[12].Transitions = Array.Empty<DfaTrans>();
                states4[13].Transitions = new DfaTrans[1] {new DfaTrans(states4[14], sets[16])};
                states4[14].Transitions = new DfaTrans[1] {new DfaTrans(states4[15], sets[1])};
                states4[15].Transitions = new DfaTrans[1] {new DfaTrans(states4[16], sets[3])};
                states4[16].Transitions = new DfaTrans[1] {new DfaTrans(states4[17], sets[11])};
                states4[17].Transitions = new DfaTrans[1] {new DfaTrans(states4[18], sets[12])};
                states4[18].Transitions = new DfaTrans[1] {new DfaTrans(states4[19], sets[2])};
                states4[19].Transitions = new DfaTrans[1] {new DfaTrans(states4[20], sets[15])};
                states4[20].Transitions = new DfaTrans[1] {new DfaTrans(states4[21], sets[13])};
                states4[21].Transitions = Array.Empty<DfaTrans>();
                states4[22].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  5 -- 'Spacing' | 'Start' | '}' -- */
                var states5 = new DfaState[13] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,false,-1), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,true,14), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,true,11), new DfaState(12,true,9)};
                states5[0].Transitions = new DfaTrans[2] {new DfaTrans(states5[1], sets[17]), new DfaTrans(states5[12], sets[9])};
                states5[1].Transitions = new DfaTrans[2] {new DfaTrans(states5[2], sets[10]), new DfaTrans(states5[8], sets[8])};
                states5[2].Transitions = new DfaTrans[1] {new DfaTrans(states5[3], sets[2])};
                states5[3].Transitions = new DfaTrans[1] {new DfaTrans(states5[4], sets[18])};
                states5[4].Transitions = new DfaTrans[1] {new DfaTrans(states5[5], sets[11])};
                states5[5].Transitions = new DfaTrans[1] {new DfaTrans(states5[6], sets[12])};
                states5[6].Transitions = new DfaTrans[1] {new DfaTrans(states5[7], sets[0])};
                states5[7].Transitions = Array.Empty<DfaTrans>();
                states5[8].Transitions = new DfaTrans[1] {new DfaTrans(states5[9], sets[2])};
                states5[9].Transitions = new DfaTrans[1] {new DfaTrans(states5[10], sets[1])};
                states5[10].Transitions = new DfaTrans[1] {new DfaTrans(states5[11], sets[8])};
                states5[11].Transitions = Array.Empty<DfaTrans>();
                states5[12].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  6 -- ˈidentifierˈ | '}' -- */
                var states6 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,0), new DfaState(2,true,9)};
                states6[0].Transitions = new DfaTrans[2] {new DfaTrans(states6[1], sets[4]), new DfaTrans(states6[2], sets[9])};
                states6[1].Transitions = new DfaTrans[1] {new DfaTrans(states6[1], sets[5])};
                states6[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  7 -- '=' -- */
                var states7 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,12)};
                states7[0].Transitions = new DfaTrans[1] {new DfaTrans(states7[1], sets[19])};
                states7[1].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  8 -- '->' | ':' -- */
                var states8 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,29), new DfaState(3,true,28)};
                states8[0].Transitions = new DfaTrans[2] {new DfaTrans(states8[1], sets[20]), new DfaTrans(states8[3], sets[21])};
                states8[1].Transitions = new DfaTrans[1] {new DfaTrans(states8[2], sets[22])};
                states8[2].Transitions = Array.Empty<DfaTrans>();
                states8[3].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  9 -- ˈtextˈ | '(' | ',' | ';' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states9 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,20), new DfaState(15,true,13), new DfaState(16,true,0), new DfaState(17,true,21), new DfaState(18,true,8), new DfaState(19,true,16)};
                states9[0].Transitions = new DfaTrans[8] {new DfaTrans(states9[1], sets[23]), new DfaTrans(states9[13], sets[24]), new DfaTrans(states9[14], sets[25]), new DfaTrans(states9[15], sets[26]), new DfaTrans(states9[16], sets[4]), new DfaTrans(states9[17], sets[27]), new DfaTrans(states9[18], sets[6]), new DfaTrans(states9[19], sets[28])};
                states9[1].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[29]), new DfaTrans(states9[4], sets[30])};
                states9[2].Transitions = new DfaTrans[3] {new DfaTrans(states9[2], sets[29]), new DfaTrans(states9[3], sets[23]), new DfaTrans(states9[4], sets[30])};
                states9[3].Transitions = Array.Empty<DfaTrans>();
                states9[4].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[31]), new DfaTrans(states9[5], sets[14])};
                states9[5].Transitions = new DfaTrans[1] {new DfaTrans(states9[6], sets[6])};
                states9[6].Transitions = new DfaTrans[1] {new DfaTrans(states9[7], sets[32])};
                states9[7].Transitions = new DfaTrans[2] {new DfaTrans(states9[8], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[8].Transitions = new DfaTrans[2] {new DfaTrans(states9[9], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[9].Transitions = new DfaTrans[2] {new DfaTrans(states9[10], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[10].Transitions = new DfaTrans[2] {new DfaTrans(states9[11], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[11].Transitions = new DfaTrans[2] {new DfaTrans(states9[12], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[12].Transitions = new DfaTrans[1] {new DfaTrans(states9[2], sets[9])};
                states9[13].Transitions = Array.Empty<DfaTrans>();
                states9[14].Transitions = Array.Empty<DfaTrans>();
                states9[15].Transitions = Array.Empty<DfaTrans>();
                states9[16].Transitions = new DfaTrans[1] {new DfaTrans(states9[16], sets[5])};
                states9[17].Transitions = Array.Empty<DfaTrans>();
                states9[18].Transitions = Array.Empty<DfaTrans>();
                states9[19].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 10 -- ˈtextˈ | '(' | '-' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states10 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,25), new DfaState(15,true,2), new DfaState(16,true,13), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,16), new DfaState(46,true,26)};
                states10[0].Transitions = new DfaTrans[10] {new DfaTrans(states10[1], sets[23]), new DfaTrans(states10[13], sets[24]), new DfaTrans(states10[14], sets[20]), new DfaTrans(states10[15], sets[33]), new DfaTrans(states10[16], sets[26]), new DfaTrans(states10[17], sets[34]), new DfaTrans(states10[18], sets[35]), new DfaTrans(states10[26], sets[30]), new DfaTrans(states10[45], sets[28]), new DfaTrans(states10[46], sets[36])};
                states10[1].Transitions = new DfaTrans[2] {new DfaTrans(states10[2], sets[29]), new DfaTrans(states10[4], sets[30])};
                states10[2].Transitions = new DfaTrans[3] {new DfaTrans(states10[2], sets[29]), new DfaTrans(states10[3], sets[23]), new DfaTrans(states10[4], sets[30])};
                states10[3].Transitions = Array.Empty<DfaTrans>();
                states10[4].Transitions = new DfaTrans[2] {new DfaTrans(states10[2], sets[31]), new DfaTrans(states10[5], sets[14])};
                states10[5].Transitions = new DfaTrans[1] {new DfaTrans(states10[6], sets[6])};
                states10[6].Transitions = new DfaTrans[1] {new DfaTrans(states10[7], sets[32])};
                states10[7].Transitions = new DfaTrans[2] {new DfaTrans(states10[8], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[8].Transitions = new DfaTrans[2] {new DfaTrans(states10[9], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[9].Transitions = new DfaTrans[2] {new DfaTrans(states10[10], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[10].Transitions = new DfaTrans[2] {new DfaTrans(states10[11], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[11].Transitions = new DfaTrans[2] {new DfaTrans(states10[12], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[12].Transitions = new DfaTrans[1] {new DfaTrans(states10[2], sets[9])};
                states10[13].Transitions = Array.Empty<DfaTrans>();
                states10[14].Transitions = Array.Empty<DfaTrans>();
                states10[15].Transitions = Array.Empty<DfaTrans>();
                states10[16].Transitions = Array.Empty<DfaTrans>();
                states10[17].Transitions = new DfaTrans[1] {new DfaTrans(states10[17], sets[5])};
                states10[18].Transitions = new DfaTrans[2] {new DfaTrans(states10[19], sets[37]), new DfaTrans(states10[17], sets[5])};
                states10[19].Transitions = new DfaTrans[1] {new DfaTrans(states10[20], sets[32])};
                states10[20].Transitions = new DfaTrans[1] {new DfaTrans(states10[21], sets[32])};
                states10[21].Transitions = new DfaTrans[1] {new DfaTrans(states10[22], sets[32])};
                states10[22].Transitions = new DfaTrans[1] {new DfaTrans(states10[23], sets[32])};
                states10[23].Transitions = new DfaTrans[1] {new DfaTrans(states10[24], sets[32])};
                states10[24].Transitions = new DfaTrans[1] {new DfaTrans(states10[25], sets[32])};
                states10[25].Transitions = Array.Empty<DfaTrans>();
                states10[26].Transitions = new DfaTrans[1] {new DfaTrans(states10[27], sets[14])};
                states10[27].Transitions = new DfaTrans[3] {new DfaTrans(states10[28], sets[38]), new DfaTrans(states10[33], sets[18]), new DfaTrans(states10[38], sets[6])};
                states10[28].Transitions = new DfaTrans[1] {new DfaTrans(states10[29], sets[6])};
                states10[29].Transitions = new DfaTrans[1] {new DfaTrans(states10[30], sets[39])};
                states10[30].Transitions = new DfaTrans[3] {new DfaTrans(states10[31], sets[40]), new DfaTrans(states10[30], sets[41]), new DfaTrans(states10[32], sets[9])};
                states10[31].Transitions = new DfaTrans[2] {new DfaTrans(states10[31], sets[40]), new DfaTrans(states10[30], sets[41])};
                states10[32].Transitions = Array.Empty<DfaTrans>();
                states10[33].Transitions = new DfaTrans[1] {new DfaTrans(states10[34], sets[6])};
                states10[34].Transitions = new DfaTrans[1] {new DfaTrans(states10[35], sets[39])};
                states10[35].Transitions = new DfaTrans[3] {new DfaTrans(states10[36], sets[40]), new DfaTrans(states10[35], sets[41]), new DfaTrans(states10[37], sets[9])};
                states10[36].Transitions = new DfaTrans[2] {new DfaTrans(states10[36], sets[40]), new DfaTrans(states10[35], sets[41])};
                states10[37].Transitions = Array.Empty<DfaTrans>();
                states10[38].Transitions = new DfaTrans[1] {new DfaTrans(states10[39], sets[32])};
                states10[39].Transitions = new DfaTrans[2] {new DfaTrans(states10[40], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[40].Transitions = new DfaTrans[2] {new DfaTrans(states10[41], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[41].Transitions = new DfaTrans[2] {new DfaTrans(states10[42], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[42].Transitions = new DfaTrans[2] {new DfaTrans(states10[43], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[43].Transitions = new DfaTrans[2] {new DfaTrans(states10[44], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[44].Transitions = new DfaTrans[1] {new DfaTrans(states10[25], sets[9])};
                states10[45].Transitions = Array.Empty<DfaTrans>();
                states10[46].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 11 -- ';' -- */
                var states11 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,13)};
                states11[0].Transitions = new DfaTrans[1] {new DfaTrans(states11[1], sets[26])};
                states11[1].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 12 -- ';' | '|' -- */
                var states12 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,13), new DfaState(2,true,16)};
                states12[0].Transitions = new DfaTrans[2] {new DfaTrans(states12[1], sets[26]), new DfaTrans(states12[2], sets[28])};
                states12[1].Transitions = Array.Empty<DfaTrans>();
                states12[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 13 -- ˈtextˈ | '(' | '*' | '+' | ',' | ';' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states13 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,20), new DfaState(17,true,13), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,21), new DfaState(21,true,8), new DfaState(22,true,16)};
                states13[0].Transitions = new DfaTrans[11] {new DfaTrans(states13[1], sets[23]), new DfaTrans(states13[13], sets[24]), new DfaTrans(states13[14], sets[42]), new DfaTrans(states13[15], sets[37]), new DfaTrans(states13[16], sets[25]), new DfaTrans(states13[17], sets[26]), new DfaTrans(states13[18], sets[43]), new DfaTrans(states13[19], sets[4]), new DfaTrans(states13[20], sets[27]), new DfaTrans(states13[21], sets[6]), new DfaTrans(states13[22], sets[28])};
                states13[1].Transitions = new DfaTrans[2] {new DfaTrans(states13[2], sets[29]), new DfaTrans(states13[4], sets[30])};
                states13[2].Transitions = new DfaTrans[3] {new DfaTrans(states13[2], sets[29]), new DfaTrans(states13[3], sets[23]), new DfaTrans(states13[4], sets[30])};
                states13[3].Transitions = Array.Empty<DfaTrans>();
                states13[4].Transitions = new DfaTrans[2] {new DfaTrans(states13[2], sets[31]), new DfaTrans(states13[5], sets[14])};
                states13[5].Transitions = new DfaTrans[1] {new DfaTrans(states13[6], sets[6])};
                states13[6].Transitions = new DfaTrans[1] {new DfaTrans(states13[7], sets[32])};
                states13[7].Transitions = new DfaTrans[2] {new DfaTrans(states13[8], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[8].Transitions = new DfaTrans[2] {new DfaTrans(states13[9], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[9].Transitions = new DfaTrans[2] {new DfaTrans(states13[10], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[10].Transitions = new DfaTrans[2] {new DfaTrans(states13[11], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[11].Transitions = new DfaTrans[2] {new DfaTrans(states13[12], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[12].Transitions = new DfaTrans[1] {new DfaTrans(states13[2], sets[9])};
                states13[13].Transitions = Array.Empty<DfaTrans>();
                states13[14].Transitions = Array.Empty<DfaTrans>();
                states13[15].Transitions = Array.Empty<DfaTrans>();
                states13[16].Transitions = Array.Empty<DfaTrans>();
                states13[17].Transitions = Array.Empty<DfaTrans>();
                states13[18].Transitions = Array.Empty<DfaTrans>();
                states13[19].Transitions = new DfaTrans[1] {new DfaTrans(states13[19], sets[5])};
                states13[20].Transitions = Array.Empty<DfaTrans>();
                states13[21].Transitions = Array.Empty<DfaTrans>();
                states13[22].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 14 -- ˈtextˈ | '(' | ˈidentifierˈ | '{' -- */
                var states14 = new DfaState[16] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,0), new DfaState(15,true,8)};
                states14[0].Transitions = new DfaTrans[4] {new DfaTrans(states14[1], sets[23]), new DfaTrans(states14[13], sets[24]), new DfaTrans(states14[14], sets[4]), new DfaTrans(states14[15], sets[6])};
                states14[1].Transitions = new DfaTrans[2] {new DfaTrans(states14[2], sets[29]), new DfaTrans(states14[4], sets[30])};
                states14[2].Transitions = new DfaTrans[3] {new DfaTrans(states14[2], sets[29]), new DfaTrans(states14[3], sets[23]), new DfaTrans(states14[4], sets[30])};
                states14[3].Transitions = Array.Empty<DfaTrans>();
                states14[4].Transitions = new DfaTrans[2] {new DfaTrans(states14[2], sets[31]), new DfaTrans(states14[5], sets[14])};
                states14[5].Transitions = new DfaTrans[1] {new DfaTrans(states14[6], sets[6])};
                states14[6].Transitions = new DfaTrans[1] {new DfaTrans(states14[7], sets[32])};
                states14[7].Transitions = new DfaTrans[2] {new DfaTrans(states14[8], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[8].Transitions = new DfaTrans[2] {new DfaTrans(states14[9], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[9].Transitions = new DfaTrans[2] {new DfaTrans(states14[10], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[10].Transitions = new DfaTrans[2] {new DfaTrans(states14[11], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[11].Transitions = new DfaTrans[2] {new DfaTrans(states14[12], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[12].Transitions = new DfaTrans[1] {new DfaTrans(states14[2], sets[9])};
                states14[13].Transitions = Array.Empty<DfaTrans>();
                states14[14].Transitions = new DfaTrans[1] {new DfaTrans(states14[14], sets[5])};
                states14[15].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 15 -- ˈtextˈ | '(' | ')' | ',' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states15 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,20), new DfaState(16,true,0), new DfaState(17,true,21), new DfaState(18,true,8), new DfaState(19,true,16)};
                states15[0].Transitions = new DfaTrans[8] {new DfaTrans(states15[1], sets[23]), new DfaTrans(states15[13], sets[24]), new DfaTrans(states15[14], sets[44]), new DfaTrans(states15[15], sets[25]), new DfaTrans(states15[16], sets[4]), new DfaTrans(states15[17], sets[27]), new DfaTrans(states15[18], sets[6]), new DfaTrans(states15[19], sets[28])};
                states15[1].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[29]), new DfaTrans(states15[4], sets[30])};
                states15[2].Transitions = new DfaTrans[3] {new DfaTrans(states15[2], sets[29]), new DfaTrans(states15[3], sets[23]), new DfaTrans(states15[4], sets[30])};
                states15[3].Transitions = Array.Empty<DfaTrans>();
                states15[4].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[31]), new DfaTrans(states15[5], sets[14])};
                states15[5].Transitions = new DfaTrans[1] {new DfaTrans(states15[6], sets[6])};
                states15[6].Transitions = new DfaTrans[1] {new DfaTrans(states15[7], sets[32])};
                states15[7].Transitions = new DfaTrans[2] {new DfaTrans(states15[8], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[8].Transitions = new DfaTrans[2] {new DfaTrans(states15[9], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[9].Transitions = new DfaTrans[2] {new DfaTrans(states15[10], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[10].Transitions = new DfaTrans[2] {new DfaTrans(states15[11], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[11].Transitions = new DfaTrans[2] {new DfaTrans(states15[12], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[12].Transitions = new DfaTrans[1] {new DfaTrans(states15[2], sets[9])};
                states15[13].Transitions = Array.Empty<DfaTrans>();
                states15[14].Transitions = Array.Empty<DfaTrans>();
                states15[15].Transitions = Array.Empty<DfaTrans>();
                states15[16].Transitions = new DfaTrans[1] {new DfaTrans(states15[16], sets[5])};
                states15[17].Transitions = Array.Empty<DfaTrans>();
                states15[18].Transitions = Array.Empty<DfaTrans>();
                states15[19].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 16 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states16 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,25), new DfaState(17,true,2), new DfaState(18,true,13), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,26)};
                states16[0].Transitions = new DfaTrans[14] {new DfaTrans(states16[1], sets[23]), new DfaTrans(states16[13], sets[24]), new DfaTrans(states16[14], sets[42]), new DfaTrans(states16[15], sets[37]), new DfaTrans(states16[16], sets[20]), new DfaTrans(states16[17], sets[33]), new DfaTrans(states16[18], sets[26]), new DfaTrans(states16[19], sets[43]), new DfaTrans(states16[20], sets[34]), new DfaTrans(states16[21], sets[35]), new DfaTrans(states16[29], sets[30]), new DfaTrans(states16[48], sets[6]), new DfaTrans(states16[49], sets[28]), new DfaTrans(states16[50], sets[36])};
                states16[1].Transitions = new DfaTrans[2] {new DfaTrans(states16[2], sets[29]), new DfaTrans(states16[4], sets[30])};
                states16[2].Transitions = new DfaTrans[3] {new DfaTrans(states16[2], sets[29]), new DfaTrans(states16[3], sets[23]), new DfaTrans(states16[4], sets[30])};
                states16[3].Transitions = Array.Empty<DfaTrans>();
                states16[4].Transitions = new DfaTrans[2] {new DfaTrans(states16[2], sets[31]), new DfaTrans(states16[5], sets[14])};
                states16[5].Transitions = new DfaTrans[1] {new DfaTrans(states16[6], sets[6])};
                states16[6].Transitions = new DfaTrans[1] {new DfaTrans(states16[7], sets[32])};
                states16[7].Transitions = new DfaTrans[2] {new DfaTrans(states16[8], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[8].Transitions = new DfaTrans[2] {new DfaTrans(states16[9], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[9].Transitions = new DfaTrans[2] {new DfaTrans(states16[10], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[10].Transitions = new DfaTrans[2] {new DfaTrans(states16[11], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[11].Transitions = new DfaTrans[2] {new DfaTrans(states16[12], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[12].Transitions = new DfaTrans[1] {new DfaTrans(states16[2], sets[9])};
                states16[13].Transitions = Array.Empty<DfaTrans>();
                states16[14].Transitions = Array.Empty<DfaTrans>();
                states16[15].Transitions = Array.Empty<DfaTrans>();
                states16[16].Transitions = Array.Empty<DfaTrans>();
                states16[17].Transitions = Array.Empty<DfaTrans>();
                states16[18].Transitions = Array.Empty<DfaTrans>();
                states16[19].Transitions = Array.Empty<DfaTrans>();
                states16[20].Transitions = new DfaTrans[1] {new DfaTrans(states16[20], sets[5])};
                states16[21].Transitions = new DfaTrans[2] {new DfaTrans(states16[22], sets[37]), new DfaTrans(states16[20], sets[5])};
                states16[22].Transitions = new DfaTrans[1] {new DfaTrans(states16[23], sets[32])};
                states16[23].Transitions = new DfaTrans[1] {new DfaTrans(states16[24], sets[32])};
                states16[24].Transitions = new DfaTrans[1] {new DfaTrans(states16[25], sets[32])};
                states16[25].Transitions = new DfaTrans[1] {new DfaTrans(states16[26], sets[32])};
                states16[26].Transitions = new DfaTrans[1] {new DfaTrans(states16[27], sets[32])};
                states16[27].Transitions = new DfaTrans[1] {new DfaTrans(states16[28], sets[32])};
                states16[28].Transitions = Array.Empty<DfaTrans>();
                states16[29].Transitions = new DfaTrans[1] {new DfaTrans(states16[30], sets[14])};
                states16[30].Transitions = new DfaTrans[3] {new DfaTrans(states16[31], sets[38]), new DfaTrans(states16[36], sets[18]), new DfaTrans(states16[41], sets[6])};
                states16[31].Transitions = new DfaTrans[1] {new DfaTrans(states16[32], sets[6])};
                states16[32].Transitions = new DfaTrans[1] {new DfaTrans(states16[33], sets[39])};
                states16[33].Transitions = new DfaTrans[3] {new DfaTrans(states16[34], sets[40]), new DfaTrans(states16[33], sets[41]), new DfaTrans(states16[35], sets[9])};
                states16[34].Transitions = new DfaTrans[2] {new DfaTrans(states16[34], sets[40]), new DfaTrans(states16[33], sets[41])};
                states16[35].Transitions = Array.Empty<DfaTrans>();
                states16[36].Transitions = new DfaTrans[1] {new DfaTrans(states16[37], sets[6])};
                states16[37].Transitions = new DfaTrans[1] {new DfaTrans(states16[38], sets[39])};
                states16[38].Transitions = new DfaTrans[3] {new DfaTrans(states16[39], sets[40]), new DfaTrans(states16[38], sets[41]), new DfaTrans(states16[40], sets[9])};
                states16[39].Transitions = new DfaTrans[2] {new DfaTrans(states16[39], sets[40]), new DfaTrans(states16[38], sets[41])};
                states16[40].Transitions = Array.Empty<DfaTrans>();
                states16[41].Transitions = new DfaTrans[1] {new DfaTrans(states16[42], sets[32])};
                states16[42].Transitions = new DfaTrans[2] {new DfaTrans(states16[43], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[43].Transitions = new DfaTrans[2] {new DfaTrans(states16[44], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[44].Transitions = new DfaTrans[2] {new DfaTrans(states16[45], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[45].Transitions = new DfaTrans[2] {new DfaTrans(states16[46], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[46].Transitions = new DfaTrans[2] {new DfaTrans(states16[47], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[47].Transitions = new DfaTrans[1] {new DfaTrans(states16[28], sets[9])};
                states16[48].Transitions = Array.Empty<DfaTrans>();
                states16[49].Transitions = Array.Empty<DfaTrans>();
                states16[50].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 17 -- '-' | ';' | '|' -- */
                var states17 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,25), new DfaState(2,true,13), new DfaState(3,true,16)};
                states17[0].Transitions = new DfaTrans[3] {new DfaTrans(states17[1], sets[20]), new DfaTrans(states17[2], sets[26]), new DfaTrans(states17[3], sets[28])};
                states17[1].Transitions = Array.Empty<DfaTrans>();
                states17[2].Transitions = Array.Empty<DfaTrans>();
                states17[3].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 18 -- '..' -- */
                var states18 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,27)};
                states18[0].Transitions = new DfaTrans[1] {new DfaTrans(states18[1], sets[33])};
                states18[1].Transitions = new DfaTrans[1] {new DfaTrans(states18[2], sets[33])};
                states18[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 19 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states19 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,25), new DfaState(17,true,2), new DfaState(18,true,27), new DfaState(19,true,13), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,16), new DfaState(51,true,26)};
                states19[0].Transitions = new DfaTrans[14] {new DfaTrans(states19[1], sets[23]), new DfaTrans(states19[13], sets[24]), new DfaTrans(states19[14], sets[42]), new DfaTrans(states19[15], sets[37]), new DfaTrans(states19[16], sets[20]), new DfaTrans(states19[17], sets[33]), new DfaTrans(states19[19], sets[26]), new DfaTrans(states19[20], sets[43]), new DfaTrans(states19[21], sets[34]), new DfaTrans(states19[22], sets[35]), new DfaTrans(states19[30], sets[30]), new DfaTrans(states19[49], sets[6]), new DfaTrans(states19[50], sets[28]), new DfaTrans(states19[51], sets[36])};
                states19[1].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[29]), new DfaTrans(states19[4], sets[30])};
                states19[2].Transitions = new DfaTrans[3] {new DfaTrans(states19[2], sets[29]), new DfaTrans(states19[3], sets[23]), new DfaTrans(states19[4], sets[30])};
                states19[3].Transitions = Array.Empty<DfaTrans>();
                states19[4].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[31]), new DfaTrans(states19[5], sets[14])};
                states19[5].Transitions = new DfaTrans[1] {new DfaTrans(states19[6], sets[6])};
                states19[6].Transitions = new DfaTrans[1] {new DfaTrans(states19[7], sets[32])};
                states19[7].Transitions = new DfaTrans[2] {new DfaTrans(states19[8], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[8].Transitions = new DfaTrans[2] {new DfaTrans(states19[9], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[9].Transitions = new DfaTrans[2] {new DfaTrans(states19[10], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[10].Transitions = new DfaTrans[2] {new DfaTrans(states19[11], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[11].Transitions = new DfaTrans[2] {new DfaTrans(states19[12], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[12].Transitions = new DfaTrans[1] {new DfaTrans(states19[2], sets[9])};
                states19[13].Transitions = Array.Empty<DfaTrans>();
                states19[14].Transitions = Array.Empty<DfaTrans>();
                states19[15].Transitions = Array.Empty<DfaTrans>();
                states19[16].Transitions = Array.Empty<DfaTrans>();
                states19[17].Transitions = new DfaTrans[1] {new DfaTrans(states19[18], sets[33])};
                states19[18].Transitions = Array.Empty<DfaTrans>();
                states19[19].Transitions = Array.Empty<DfaTrans>();
                states19[20].Transitions = Array.Empty<DfaTrans>();
                states19[21].Transitions = new DfaTrans[1] {new DfaTrans(states19[21], sets[5])};
                states19[22].Transitions = new DfaTrans[2] {new DfaTrans(states19[23], sets[37]), new DfaTrans(states19[21], sets[5])};
                states19[23].Transitions = new DfaTrans[1] {new DfaTrans(states19[24], sets[32])};
                states19[24].Transitions = new DfaTrans[1] {new DfaTrans(states19[25], sets[32])};
                states19[25].Transitions = new DfaTrans[1] {new DfaTrans(states19[26], sets[32])};
                states19[26].Transitions = new DfaTrans[1] {new DfaTrans(states19[27], sets[32])};
                states19[27].Transitions = new DfaTrans[1] {new DfaTrans(states19[28], sets[32])};
                states19[28].Transitions = new DfaTrans[1] {new DfaTrans(states19[29], sets[32])};
                states19[29].Transitions = Array.Empty<DfaTrans>();
                states19[30].Transitions = new DfaTrans[1] {new DfaTrans(states19[31], sets[14])};
                states19[31].Transitions = new DfaTrans[3] {new DfaTrans(states19[32], sets[38]), new DfaTrans(states19[37], sets[18]), new DfaTrans(states19[42], sets[6])};
                states19[32].Transitions = new DfaTrans[1] {new DfaTrans(states19[33], sets[6])};
                states19[33].Transitions = new DfaTrans[1] {new DfaTrans(states19[34], sets[39])};
                states19[34].Transitions = new DfaTrans[3] {new DfaTrans(states19[35], sets[40]), new DfaTrans(states19[34], sets[41]), new DfaTrans(states19[36], sets[9])};
                states19[35].Transitions = new DfaTrans[2] {new DfaTrans(states19[35], sets[40]), new DfaTrans(states19[34], sets[41])};
                states19[36].Transitions = Array.Empty<DfaTrans>();
                states19[37].Transitions = new DfaTrans[1] {new DfaTrans(states19[38], sets[6])};
                states19[38].Transitions = new DfaTrans[1] {new DfaTrans(states19[39], sets[39])};
                states19[39].Transitions = new DfaTrans[3] {new DfaTrans(states19[40], sets[40]), new DfaTrans(states19[39], sets[41]), new DfaTrans(states19[41], sets[9])};
                states19[40].Transitions = new DfaTrans[2] {new DfaTrans(states19[40], sets[40]), new DfaTrans(states19[39], sets[41])};
                states19[41].Transitions = Array.Empty<DfaTrans>();
                states19[42].Transitions = new DfaTrans[1] {new DfaTrans(states19[43], sets[32])};
                states19[43].Transitions = new DfaTrans[2] {new DfaTrans(states19[44], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[44].Transitions = new DfaTrans[2] {new DfaTrans(states19[45], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[45].Transitions = new DfaTrans[2] {new DfaTrans(states19[46], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[46].Transitions = new DfaTrans[2] {new DfaTrans(states19[47], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[47].Transitions = new DfaTrans[2] {new DfaTrans(states19[48], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[48].Transitions = new DfaTrans[1] {new DfaTrans(states19[29], sets[9])};
                states19[49].Transitions = Array.Empty<DfaTrans>();
                states19[50].Transitions = Array.Empty<DfaTrans>();
                states19[51].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 20 -- ˈtextˈ | '(' | ')' | '-' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states20 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,25), new DfaState(16,true,2), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,16), new DfaState(46,true,26)};
                states20[0].Transitions = new DfaTrans[10] {new DfaTrans(states20[1], sets[23]), new DfaTrans(states20[13], sets[24]), new DfaTrans(states20[14], sets[44]), new DfaTrans(states20[15], sets[20]), new DfaTrans(states20[16], sets[33]), new DfaTrans(states20[17], sets[34]), new DfaTrans(states20[18], sets[35]), new DfaTrans(states20[26], sets[30]), new DfaTrans(states20[45], sets[28]), new DfaTrans(states20[46], sets[36])};
                states20[1].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[29]), new DfaTrans(states20[4], sets[30])};
                states20[2].Transitions = new DfaTrans[3] {new DfaTrans(states20[2], sets[29]), new DfaTrans(states20[3], sets[23]), new DfaTrans(states20[4], sets[30])};
                states20[3].Transitions = Array.Empty<DfaTrans>();
                states20[4].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[31]), new DfaTrans(states20[5], sets[14])};
                states20[5].Transitions = new DfaTrans[1] {new DfaTrans(states20[6], sets[6])};
                states20[6].Transitions = new DfaTrans[1] {new DfaTrans(states20[7], sets[32])};
                states20[7].Transitions = new DfaTrans[2] {new DfaTrans(states20[8], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[8].Transitions = new DfaTrans[2] {new DfaTrans(states20[9], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[9].Transitions = new DfaTrans[2] {new DfaTrans(states20[10], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[10].Transitions = new DfaTrans[2] {new DfaTrans(states20[11], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[11].Transitions = new DfaTrans[2] {new DfaTrans(states20[12], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[12].Transitions = new DfaTrans[1] {new DfaTrans(states20[2], sets[9])};
                states20[13].Transitions = Array.Empty<DfaTrans>();
                states20[14].Transitions = Array.Empty<DfaTrans>();
                states20[15].Transitions = Array.Empty<DfaTrans>();
                states20[16].Transitions = Array.Empty<DfaTrans>();
                states20[17].Transitions = new DfaTrans[1] {new DfaTrans(states20[17], sets[5])};
                states20[18].Transitions = new DfaTrans[2] {new DfaTrans(states20[19], sets[37]), new DfaTrans(states20[17], sets[5])};
                states20[19].Transitions = new DfaTrans[1] {new DfaTrans(states20[20], sets[32])};
                states20[20].Transitions = new DfaTrans[1] {new DfaTrans(states20[21], sets[32])};
                states20[21].Transitions = new DfaTrans[1] {new DfaTrans(states20[22], sets[32])};
                states20[22].Transitions = new DfaTrans[1] {new DfaTrans(states20[23], sets[32])};
                states20[23].Transitions = new DfaTrans[1] {new DfaTrans(states20[24], sets[32])};
                states20[24].Transitions = new DfaTrans[1] {new DfaTrans(states20[25], sets[32])};
                states20[25].Transitions = Array.Empty<DfaTrans>();
                states20[26].Transitions = new DfaTrans[1] {new DfaTrans(states20[27], sets[14])};
                states20[27].Transitions = new DfaTrans[3] {new DfaTrans(states20[28], sets[38]), new DfaTrans(states20[33], sets[18]), new DfaTrans(states20[38], sets[6])};
                states20[28].Transitions = new DfaTrans[1] {new DfaTrans(states20[29], sets[6])};
                states20[29].Transitions = new DfaTrans[1] {new DfaTrans(states20[30], sets[39])};
                states20[30].Transitions = new DfaTrans[3] {new DfaTrans(states20[31], sets[40]), new DfaTrans(states20[30], sets[41]), new DfaTrans(states20[32], sets[9])};
                states20[31].Transitions = new DfaTrans[2] {new DfaTrans(states20[31], sets[40]), new DfaTrans(states20[30], sets[41])};
                states20[32].Transitions = Array.Empty<DfaTrans>();
                states20[33].Transitions = new DfaTrans[1] {new DfaTrans(states20[34], sets[6])};
                states20[34].Transitions = new DfaTrans[1] {new DfaTrans(states20[35], sets[39])};
                states20[35].Transitions = new DfaTrans[3] {new DfaTrans(states20[36], sets[40]), new DfaTrans(states20[35], sets[41]), new DfaTrans(states20[37], sets[9])};
                states20[36].Transitions = new DfaTrans[2] {new DfaTrans(states20[36], sets[40]), new DfaTrans(states20[35], sets[41])};
                states20[37].Transitions = Array.Empty<DfaTrans>();
                states20[38].Transitions = new DfaTrans[1] {new DfaTrans(states20[39], sets[32])};
                states20[39].Transitions = new DfaTrans[2] {new DfaTrans(states20[40], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[40].Transitions = new DfaTrans[2] {new DfaTrans(states20[41], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[41].Transitions = new DfaTrans[2] {new DfaTrans(states20[42], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[42].Transitions = new DfaTrans[2] {new DfaTrans(states20[43], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[43].Transitions = new DfaTrans[2] {new DfaTrans(states20[44], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[44].Transitions = new DfaTrans[1] {new DfaTrans(states20[25], sets[9])};
                states20[45].Transitions = Array.Empty<DfaTrans>();
                states20[46].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 21 -- ˈtextˈ | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ -- */
                var states21 = new DfaState[42] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,2), new DfaState(14,true,0), new DfaState(15,true,0), new DfaState(16,false,-1), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,true,4), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,5), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1)};
                states21[0].Transitions = new DfaTrans[5] {new DfaTrans(states21[1], sets[23]), new DfaTrans(states21[13], sets[33]), new DfaTrans(states21[14], sets[34]), new DfaTrans(states21[15], sets[35]), new DfaTrans(states21[23], sets[30])};
                states21[1].Transitions = new DfaTrans[2] {new DfaTrans(states21[2], sets[29]), new DfaTrans(states21[4], sets[30])};
                states21[2].Transitions = new DfaTrans[3] {new DfaTrans(states21[2], sets[29]), new DfaTrans(states21[3], sets[23]), new DfaTrans(states21[4], sets[30])};
                states21[3].Transitions = Array.Empty<DfaTrans>();
                states21[4].Transitions = new DfaTrans[2] {new DfaTrans(states21[2], sets[31]), new DfaTrans(states21[5], sets[14])};
                states21[5].Transitions = new DfaTrans[1] {new DfaTrans(states21[6], sets[6])};
                states21[6].Transitions = new DfaTrans[1] {new DfaTrans(states21[7], sets[32])};
                states21[7].Transitions = new DfaTrans[2] {new DfaTrans(states21[8], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[8].Transitions = new DfaTrans[2] {new DfaTrans(states21[9], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[9].Transitions = new DfaTrans[2] {new DfaTrans(states21[10], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[10].Transitions = new DfaTrans[2] {new DfaTrans(states21[11], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[11].Transitions = new DfaTrans[2] {new DfaTrans(states21[12], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[12].Transitions = new DfaTrans[1] {new DfaTrans(states21[2], sets[9])};
                states21[13].Transitions = Array.Empty<DfaTrans>();
                states21[14].Transitions = new DfaTrans[1] {new DfaTrans(states21[14], sets[5])};
                states21[15].Transitions = new DfaTrans[2] {new DfaTrans(states21[16], sets[37]), new DfaTrans(states21[14], sets[5])};
                states21[16].Transitions = new DfaTrans[1] {new DfaTrans(states21[17], sets[32])};
                states21[17].Transitions = new DfaTrans[1] {new DfaTrans(states21[18], sets[32])};
                states21[18].Transitions = new DfaTrans[1] {new DfaTrans(states21[19], sets[32])};
                states21[19].Transitions = new DfaTrans[1] {new DfaTrans(states21[20], sets[32])};
                states21[20].Transitions = new DfaTrans[1] {new DfaTrans(states21[21], sets[32])};
                states21[21].Transitions = new DfaTrans[1] {new DfaTrans(states21[22], sets[32])};
                states21[22].Transitions = Array.Empty<DfaTrans>();
                states21[23].Transitions = new DfaTrans[1] {new DfaTrans(states21[24], sets[14])};
                states21[24].Transitions = new DfaTrans[3] {new DfaTrans(states21[25], sets[38]), new DfaTrans(states21[30], sets[18]), new DfaTrans(states21[35], sets[6])};
                states21[25].Transitions = new DfaTrans[1] {new DfaTrans(states21[26], sets[6])};
                states21[26].Transitions = new DfaTrans[1] {new DfaTrans(states21[27], sets[39])};
                states21[27].Transitions = new DfaTrans[3] {new DfaTrans(states21[28], sets[40]), new DfaTrans(states21[27], sets[41]), new DfaTrans(states21[29], sets[9])};
                states21[28].Transitions = new DfaTrans[2] {new DfaTrans(states21[28], sets[40]), new DfaTrans(states21[27], sets[41])};
                states21[29].Transitions = Array.Empty<DfaTrans>();
                states21[30].Transitions = new DfaTrans[1] {new DfaTrans(states21[31], sets[6])};
                states21[31].Transitions = new DfaTrans[1] {new DfaTrans(states21[32], sets[39])};
                states21[32].Transitions = new DfaTrans[3] {new DfaTrans(states21[33], sets[40]), new DfaTrans(states21[32], sets[41]), new DfaTrans(states21[34], sets[9])};
                states21[33].Transitions = new DfaTrans[2] {new DfaTrans(states21[33], sets[40]), new DfaTrans(states21[32], sets[41])};
                states21[34].Transitions = Array.Empty<DfaTrans>();
                states21[35].Transitions = new DfaTrans[1] {new DfaTrans(states21[36], sets[32])};
                states21[36].Transitions = new DfaTrans[2] {new DfaTrans(states21[37], sets[32]), new DfaTrans(states21[22], sets[9])};
                states21[37].Transitions = new DfaTrans[2] {new DfaTrans(states21[38], sets[32]), new DfaTrans(states21[22], sets[9])};
                states21[38].Transitions = new DfaTrans[2] {new DfaTrans(states21[39], sets[32]), new DfaTrans(states21[22], sets[9])};
                states21[39].Transitions = new DfaTrans[2] {new DfaTrans(states21[40], sets[32]), new DfaTrans(states21[22], sets[9])};
                states21[40].Transitions = new DfaTrans[2] {new DfaTrans(states21[41], sets[32]), new DfaTrans(states21[22], sets[9])};
                states21[41].Transitions = new DfaTrans[1] {new DfaTrans(states21[22], sets[9])};
                
                /* dfa 22 -- ')' -- */
                var states22 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,23)};
                states22[0].Transitions = new DfaTrans[1] {new DfaTrans(states22[1], sets[44])};
                states22[1].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 23 -- ')' | '|' -- */
                var states23 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,23), new DfaState(2,true,16)};
                states23[0].Transitions = new DfaTrans[2] {new DfaTrans(states23[1], sets[44]), new DfaTrans(states23[2], sets[28])};
                states23[1].Transitions = Array.Empty<DfaTrans>();
                states23[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 24 -- ˈtextˈ | '(' | ')' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states24 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,20), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,21), new DfaState(21,true,8), new DfaState(22,true,16)};
                states24[0].Transitions = new DfaTrans[11] {new DfaTrans(states24[1], sets[23]), new DfaTrans(states24[13], sets[24]), new DfaTrans(states24[14], sets[44]), new DfaTrans(states24[15], sets[42]), new DfaTrans(states24[16], sets[37]), new DfaTrans(states24[17], sets[25]), new DfaTrans(states24[18], sets[43]), new DfaTrans(states24[19], sets[4]), new DfaTrans(states24[20], sets[27]), new DfaTrans(states24[21], sets[6]), new DfaTrans(states24[22], sets[28])};
                states24[1].Transitions = new DfaTrans[2] {new DfaTrans(states24[2], sets[29]), new DfaTrans(states24[4], sets[30])};
                states24[2].Transitions = new DfaTrans[3] {new DfaTrans(states24[2], sets[29]), new DfaTrans(states24[3], sets[23]), new DfaTrans(states24[4], sets[30])};
                states24[3].Transitions = Array.Empty<DfaTrans>();
                states24[4].Transitions = new DfaTrans[2] {new DfaTrans(states24[2], sets[31]), new DfaTrans(states24[5], sets[14])};
                states24[5].Transitions = new DfaTrans[1] {new DfaTrans(states24[6], sets[6])};
                states24[6].Transitions = new DfaTrans[1] {new DfaTrans(states24[7], sets[32])};
                states24[7].Transitions = new DfaTrans[2] {new DfaTrans(states24[8], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[8].Transitions = new DfaTrans[2] {new DfaTrans(states24[9], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[9].Transitions = new DfaTrans[2] {new DfaTrans(states24[10], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[10].Transitions = new DfaTrans[2] {new DfaTrans(states24[11], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[11].Transitions = new DfaTrans[2] {new DfaTrans(states24[12], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[12].Transitions = new DfaTrans[1] {new DfaTrans(states24[2], sets[9])};
                states24[13].Transitions = Array.Empty<DfaTrans>();
                states24[14].Transitions = Array.Empty<DfaTrans>();
                states24[15].Transitions = Array.Empty<DfaTrans>();
                states24[16].Transitions = Array.Empty<DfaTrans>();
                states24[17].Transitions = Array.Empty<DfaTrans>();
                states24[18].Transitions = Array.Empty<DfaTrans>();
                states24[19].Transitions = new DfaTrans[1] {new DfaTrans(states24[19], sets[5])};
                states24[20].Transitions = Array.Empty<DfaTrans>();
                states24[21].Transitions = Array.Empty<DfaTrans>();
                states24[22].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 25 -- ˈtextˈ | '(' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states25 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,2), new DfaState(15,true,13), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,16), new DfaState(45,true,26)};
                states25[0].Transitions = new DfaTrans[9] {new DfaTrans(states25[1], sets[23]), new DfaTrans(states25[13], sets[24]), new DfaTrans(states25[14], sets[33]), new DfaTrans(states25[15], sets[26]), new DfaTrans(states25[16], sets[34]), new DfaTrans(states25[17], sets[35]), new DfaTrans(states25[25], sets[30]), new DfaTrans(states25[44], sets[28]), new DfaTrans(states25[45], sets[36])};
                states25[1].Transitions = new DfaTrans[2] {new DfaTrans(states25[2], sets[29]), new DfaTrans(states25[4], sets[30])};
                states25[2].Transitions = new DfaTrans[3] {new DfaTrans(states25[2], sets[29]), new DfaTrans(states25[3], sets[23]), new DfaTrans(states25[4], sets[30])};
                states25[3].Transitions = Array.Empty<DfaTrans>();
                states25[4].Transitions = new DfaTrans[2] {new DfaTrans(states25[2], sets[31]), new DfaTrans(states25[5], sets[14])};
                states25[5].Transitions = new DfaTrans[1] {new DfaTrans(states25[6], sets[6])};
                states25[6].Transitions = new DfaTrans[1] {new DfaTrans(states25[7], sets[32])};
                states25[7].Transitions = new DfaTrans[2] {new DfaTrans(states25[8], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[8].Transitions = new DfaTrans[2] {new DfaTrans(states25[9], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[9].Transitions = new DfaTrans[2] {new DfaTrans(states25[10], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[10].Transitions = new DfaTrans[2] {new DfaTrans(states25[11], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[11].Transitions = new DfaTrans[2] {new DfaTrans(states25[12], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[12].Transitions = new DfaTrans[1] {new DfaTrans(states25[2], sets[9])};
                states25[13].Transitions = Array.Empty<DfaTrans>();
                states25[14].Transitions = Array.Empty<DfaTrans>();
                states25[15].Transitions = Array.Empty<DfaTrans>();
                states25[16].Transitions = new DfaTrans[1] {new DfaTrans(states25[16], sets[5])};
                states25[17].Transitions = new DfaTrans[2] {new DfaTrans(states25[18], sets[37]), new DfaTrans(states25[16], sets[5])};
                states25[18].Transitions = new DfaTrans[1] {new DfaTrans(states25[19], sets[32])};
                states25[19].Transitions = new DfaTrans[1] {new DfaTrans(states25[20], sets[32])};
                states25[20].Transitions = new DfaTrans[1] {new DfaTrans(states25[21], sets[32])};
                states25[21].Transitions = new DfaTrans[1] {new DfaTrans(states25[22], sets[32])};
                states25[22].Transitions = new DfaTrans[1] {new DfaTrans(states25[23], sets[32])};
                states25[23].Transitions = new DfaTrans[1] {new DfaTrans(states25[24], sets[32])};
                states25[24].Transitions = Array.Empty<DfaTrans>();
                states25[25].Transitions = new DfaTrans[1] {new DfaTrans(states25[26], sets[14])};
                states25[26].Transitions = new DfaTrans[3] {new DfaTrans(states25[27], sets[38]), new DfaTrans(states25[32], sets[18]), new DfaTrans(states25[37], sets[6])};
                states25[27].Transitions = new DfaTrans[1] {new DfaTrans(states25[28], sets[6])};
                states25[28].Transitions = new DfaTrans[1] {new DfaTrans(states25[29], sets[39])};
                states25[29].Transitions = new DfaTrans[3] {new DfaTrans(states25[30], sets[40]), new DfaTrans(states25[29], sets[41]), new DfaTrans(states25[31], sets[9])};
                states25[30].Transitions = new DfaTrans[2] {new DfaTrans(states25[30], sets[40]), new DfaTrans(states25[29], sets[41])};
                states25[31].Transitions = Array.Empty<DfaTrans>();
                states25[32].Transitions = new DfaTrans[1] {new DfaTrans(states25[33], sets[6])};
                states25[33].Transitions = new DfaTrans[1] {new DfaTrans(states25[34], sets[39])};
                states25[34].Transitions = new DfaTrans[3] {new DfaTrans(states25[35], sets[40]), new DfaTrans(states25[34], sets[41]), new DfaTrans(states25[36], sets[9])};
                states25[35].Transitions = new DfaTrans[2] {new DfaTrans(states25[35], sets[40]), new DfaTrans(states25[34], sets[41])};
                states25[36].Transitions = Array.Empty<DfaTrans>();
                states25[37].Transitions = new DfaTrans[1] {new DfaTrans(states25[38], sets[32])};
                states25[38].Transitions = new DfaTrans[2] {new DfaTrans(states25[39], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[39].Transitions = new DfaTrans[2] {new DfaTrans(states25[40], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[40].Transitions = new DfaTrans[2] {new DfaTrans(states25[41], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[41].Transitions = new DfaTrans[2] {new DfaTrans(states25[42], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[42].Transitions = new DfaTrans[2] {new DfaTrans(states25[43], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[43].Transitions = new DfaTrans[1] {new DfaTrans(states25[24], sets[9])};
                states25[44].Transitions = Array.Empty<DfaTrans>();
                states25[45].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 26 -- ˈnumberˈ -- */
                var states26 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,1), new DfaState(2,true,1)};
                states26[0].Transitions = new DfaTrans[2] {new DfaTrans(states26[1], sets[45]), new DfaTrans(states26[2], sets[46])};
                states26[1].Transitions = Array.Empty<DfaTrans>();
                states26[2].Transitions = new DfaTrans[1] {new DfaTrans(states26[2], sets[47])};
                
                /* dfa 27 -- ˈtextˈ | ˈucCodepointˈ -- */
                var states27 = new DfaState[30] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,true,6), new DfaState(16,true,6), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,false,-1), new DfaState(22,false,-1), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1)};
                states27[0].Transitions = new DfaTrans[3] {new DfaTrans(states27[1], sets[23]), new DfaTrans(states27[13], sets[35]), new DfaTrans(states27[21], sets[30])};
                states27[1].Transitions = new DfaTrans[2] {new DfaTrans(states27[2], sets[29]), new DfaTrans(states27[4], sets[30])};
                states27[2].Transitions = new DfaTrans[3] {new DfaTrans(states27[2], sets[29]), new DfaTrans(states27[3], sets[23]), new DfaTrans(states27[4], sets[30])};
                states27[3].Transitions = Array.Empty<DfaTrans>();
                states27[4].Transitions = new DfaTrans[2] {new DfaTrans(states27[2], sets[31]), new DfaTrans(states27[5], sets[14])};
                states27[5].Transitions = new DfaTrans[1] {new DfaTrans(states27[6], sets[6])};
                states27[6].Transitions = new DfaTrans[1] {new DfaTrans(states27[7], sets[32])};
                states27[7].Transitions = new DfaTrans[2] {new DfaTrans(states27[8], sets[32]), new DfaTrans(states27[2], sets[9])};
                states27[8].Transitions = new DfaTrans[2] {new DfaTrans(states27[9], sets[32]), new DfaTrans(states27[2], sets[9])};
                states27[9].Transitions = new DfaTrans[2] {new DfaTrans(states27[10], sets[32]), new DfaTrans(states27[2], sets[9])};
                states27[10].Transitions = new DfaTrans[2] {new DfaTrans(states27[11], sets[32]), new DfaTrans(states27[2], sets[9])};
                states27[11].Transitions = new DfaTrans[2] {new DfaTrans(states27[12], sets[32]), new DfaTrans(states27[2], sets[9])};
                states27[12].Transitions = new DfaTrans[1] {new DfaTrans(states27[2], sets[9])};
                states27[13].Transitions = new DfaTrans[1] {new DfaTrans(states27[14], sets[37])};
                states27[14].Transitions = new DfaTrans[1] {new DfaTrans(states27[15], sets[32])};
                states27[15].Transitions = new DfaTrans[1] {new DfaTrans(states27[16], sets[32])};
                states27[16].Transitions = new DfaTrans[1] {new DfaTrans(states27[17], sets[32])};
                states27[17].Transitions = new DfaTrans[1] {new DfaTrans(states27[18], sets[32])};
                states27[18].Transitions = new DfaTrans[1] {new DfaTrans(states27[19], sets[32])};
                states27[19].Transitions = new DfaTrans[1] {new DfaTrans(states27[20], sets[32])};
                states27[20].Transitions = Array.Empty<DfaTrans>();
                states27[21].Transitions = new DfaTrans[1] {new DfaTrans(states27[22], sets[14])};
                states27[22].Transitions = new DfaTrans[1] {new DfaTrans(states27[23], sets[6])};
                states27[23].Transitions = new DfaTrans[1] {new DfaTrans(states27[24], sets[32])};
                states27[24].Transitions = new DfaTrans[2] {new DfaTrans(states27[25], sets[32]), new DfaTrans(states27[20], sets[9])};
                states27[25].Transitions = new DfaTrans[2] {new DfaTrans(states27[26], sets[32]), new DfaTrans(states27[20], sets[9])};
                states27[26].Transitions = new DfaTrans[2] {new DfaTrans(states27[27], sets[32]), new DfaTrans(states27[20], sets[9])};
                states27[27].Transitions = new DfaTrans[2] {new DfaTrans(states27[28], sets[32]), new DfaTrans(states27[20], sets[9])};
                states27[28].Transitions = new DfaTrans[2] {new DfaTrans(states27[29], sets[32]), new DfaTrans(states27[20], sets[9])};
                states27[29].Transitions = new DfaTrans[1] {new DfaTrans(states27[20], sets[9])};
                
                /* dfa 28 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states28 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,25), new DfaState(18,true,2), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,26)};
                states28[0].Transitions = new DfaTrans[14] {new DfaTrans(states28[1], sets[23]), new DfaTrans(states28[13], sets[24]), new DfaTrans(states28[14], sets[44]), new DfaTrans(states28[15], sets[42]), new DfaTrans(states28[16], sets[37]), new DfaTrans(states28[17], sets[20]), new DfaTrans(states28[18], sets[33]), new DfaTrans(states28[19], sets[43]), new DfaTrans(states28[20], sets[34]), new DfaTrans(states28[21], sets[35]), new DfaTrans(states28[29], sets[30]), new DfaTrans(states28[48], sets[6]), new DfaTrans(states28[49], sets[28]), new DfaTrans(states28[50], sets[36])};
                states28[1].Transitions = new DfaTrans[2] {new DfaTrans(states28[2], sets[29]), new DfaTrans(states28[4], sets[30])};
                states28[2].Transitions = new DfaTrans[3] {new DfaTrans(states28[2], sets[29]), new DfaTrans(states28[3], sets[23]), new DfaTrans(states28[4], sets[30])};
                states28[3].Transitions = Array.Empty<DfaTrans>();
                states28[4].Transitions = new DfaTrans[2] {new DfaTrans(states28[2], sets[31]), new DfaTrans(states28[5], sets[14])};
                states28[5].Transitions = new DfaTrans[1] {new DfaTrans(states28[6], sets[6])};
                states28[6].Transitions = new DfaTrans[1] {new DfaTrans(states28[7], sets[32])};
                states28[7].Transitions = new DfaTrans[2] {new DfaTrans(states28[8], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[8].Transitions = new DfaTrans[2] {new DfaTrans(states28[9], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[9].Transitions = new DfaTrans[2] {new DfaTrans(states28[10], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[10].Transitions = new DfaTrans[2] {new DfaTrans(states28[11], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[11].Transitions = new DfaTrans[2] {new DfaTrans(states28[12], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[12].Transitions = new DfaTrans[1] {new DfaTrans(states28[2], sets[9])};
                states28[13].Transitions = Array.Empty<DfaTrans>();
                states28[14].Transitions = Array.Empty<DfaTrans>();
                states28[15].Transitions = Array.Empty<DfaTrans>();
                states28[16].Transitions = Array.Empty<DfaTrans>();
                states28[17].Transitions = Array.Empty<DfaTrans>();
                states28[18].Transitions = Array.Empty<DfaTrans>();
                states28[19].Transitions = Array.Empty<DfaTrans>();
                states28[20].Transitions = new DfaTrans[1] {new DfaTrans(states28[20], sets[5])};
                states28[21].Transitions = new DfaTrans[2] {new DfaTrans(states28[22], sets[37]), new DfaTrans(states28[20], sets[5])};
                states28[22].Transitions = new DfaTrans[1] {new DfaTrans(states28[23], sets[32])};
                states28[23].Transitions = new DfaTrans[1] {new DfaTrans(states28[24], sets[32])};
                states28[24].Transitions = new DfaTrans[1] {new DfaTrans(states28[25], sets[32])};
                states28[25].Transitions = new DfaTrans[1] {new DfaTrans(states28[26], sets[32])};
                states28[26].Transitions = new DfaTrans[1] {new DfaTrans(states28[27], sets[32])};
                states28[27].Transitions = new DfaTrans[1] {new DfaTrans(states28[28], sets[32])};
                states28[28].Transitions = Array.Empty<DfaTrans>();
                states28[29].Transitions = new DfaTrans[1] {new DfaTrans(states28[30], sets[14])};
                states28[30].Transitions = new DfaTrans[3] {new DfaTrans(states28[31], sets[38]), new DfaTrans(states28[36], sets[18]), new DfaTrans(states28[41], sets[6])};
                states28[31].Transitions = new DfaTrans[1] {new DfaTrans(states28[32], sets[6])};
                states28[32].Transitions = new DfaTrans[1] {new DfaTrans(states28[33], sets[39])};
                states28[33].Transitions = new DfaTrans[3] {new DfaTrans(states28[34], sets[40]), new DfaTrans(states28[33], sets[41]), new DfaTrans(states28[35], sets[9])};
                states28[34].Transitions = new DfaTrans[2] {new DfaTrans(states28[34], sets[40]), new DfaTrans(states28[33], sets[41])};
                states28[35].Transitions = Array.Empty<DfaTrans>();
                states28[36].Transitions = new DfaTrans[1] {new DfaTrans(states28[37], sets[6])};
                states28[37].Transitions = new DfaTrans[1] {new DfaTrans(states28[38], sets[39])};
                states28[38].Transitions = new DfaTrans[3] {new DfaTrans(states28[39], sets[40]), new DfaTrans(states28[38], sets[41]), new DfaTrans(states28[40], sets[9])};
                states28[39].Transitions = new DfaTrans[2] {new DfaTrans(states28[39], sets[40]), new DfaTrans(states28[38], sets[41])};
                states28[40].Transitions = Array.Empty<DfaTrans>();
                states28[41].Transitions = new DfaTrans[1] {new DfaTrans(states28[42], sets[32])};
                states28[42].Transitions = new DfaTrans[2] {new DfaTrans(states28[43], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[43].Transitions = new DfaTrans[2] {new DfaTrans(states28[44], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[44].Transitions = new DfaTrans[2] {new DfaTrans(states28[45], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[45].Transitions = new DfaTrans[2] {new DfaTrans(states28[46], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[46].Transitions = new DfaTrans[2] {new DfaTrans(states28[47], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[47].Transitions = new DfaTrans[1] {new DfaTrans(states28[28], sets[9])};
                states28[48].Transitions = Array.Empty<DfaTrans>();
                states28[49].Transitions = Array.Empty<DfaTrans>();
                states28[50].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 29 -- ')' | '-' | '|' -- */
                var states29 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,23), new DfaState(2,true,25), new DfaState(3,true,16)};
                states29[0].Transitions = new DfaTrans[3] {new DfaTrans(states29[1], sets[44]), new DfaTrans(states29[2], sets[20]), new DfaTrans(states29[3], sets[28])};
                states29[1].Transitions = Array.Empty<DfaTrans>();
                states29[2].Transitions = Array.Empty<DfaTrans>();
                states29[3].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 30 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states30 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,25), new DfaState(18,true,2), new DfaState(19,true,27), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,16), new DfaState(51,true,26)};
                states30[0].Transitions = new DfaTrans[14] {new DfaTrans(states30[1], sets[23]), new DfaTrans(states30[13], sets[24]), new DfaTrans(states30[14], sets[44]), new DfaTrans(states30[15], sets[42]), new DfaTrans(states30[16], sets[37]), new DfaTrans(states30[17], sets[20]), new DfaTrans(states30[18], sets[33]), new DfaTrans(states30[20], sets[43]), new DfaTrans(states30[21], sets[34]), new DfaTrans(states30[22], sets[35]), new DfaTrans(states30[30], sets[30]), new DfaTrans(states30[49], sets[6]), new DfaTrans(states30[50], sets[28]), new DfaTrans(states30[51], sets[36])};
                states30[1].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[29]), new DfaTrans(states30[4], sets[30])};
                states30[2].Transitions = new DfaTrans[3] {new DfaTrans(states30[2], sets[29]), new DfaTrans(states30[3], sets[23]), new DfaTrans(states30[4], sets[30])};
                states30[3].Transitions = Array.Empty<DfaTrans>();
                states30[4].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[31]), new DfaTrans(states30[5], sets[14])};
                states30[5].Transitions = new DfaTrans[1] {new DfaTrans(states30[6], sets[6])};
                states30[6].Transitions = new DfaTrans[1] {new DfaTrans(states30[7], sets[32])};
                states30[7].Transitions = new DfaTrans[2] {new DfaTrans(states30[8], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[8].Transitions = new DfaTrans[2] {new DfaTrans(states30[9], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[9].Transitions = new DfaTrans[2] {new DfaTrans(states30[10], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[10].Transitions = new DfaTrans[2] {new DfaTrans(states30[11], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[11].Transitions = new DfaTrans[2] {new DfaTrans(states30[12], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[12].Transitions = new DfaTrans[1] {new DfaTrans(states30[2], sets[9])};
                states30[13].Transitions = Array.Empty<DfaTrans>();
                states30[14].Transitions = Array.Empty<DfaTrans>();
                states30[15].Transitions = Array.Empty<DfaTrans>();
                states30[16].Transitions = Array.Empty<DfaTrans>();
                states30[17].Transitions = Array.Empty<DfaTrans>();
                states30[18].Transitions = new DfaTrans[1] {new DfaTrans(states30[19], sets[33])};
                states30[19].Transitions = Array.Empty<DfaTrans>();
                states30[20].Transitions = Array.Empty<DfaTrans>();
                states30[21].Transitions = new DfaTrans[1] {new DfaTrans(states30[21], sets[5])};
                states30[22].Transitions = new DfaTrans[2] {new DfaTrans(states30[23], sets[37]), new DfaTrans(states30[21], sets[5])};
                states30[23].Transitions = new DfaTrans[1] {new DfaTrans(states30[24], sets[32])};
                states30[24].Transitions = new DfaTrans[1] {new DfaTrans(states30[25], sets[32])};
                states30[25].Transitions = new DfaTrans[1] {new DfaTrans(states30[26], sets[32])};
                states30[26].Transitions = new DfaTrans[1] {new DfaTrans(states30[27], sets[32])};
                states30[27].Transitions = new DfaTrans[1] {new DfaTrans(states30[28], sets[32])};
                states30[28].Transitions = new DfaTrans[1] {new DfaTrans(states30[29], sets[32])};
                states30[29].Transitions = Array.Empty<DfaTrans>();
                states30[30].Transitions = new DfaTrans[1] {new DfaTrans(states30[31], sets[14])};
                states30[31].Transitions = new DfaTrans[3] {new DfaTrans(states30[32], sets[38]), new DfaTrans(states30[37], sets[18]), new DfaTrans(states30[42], sets[6])};
                states30[32].Transitions = new DfaTrans[1] {new DfaTrans(states30[33], sets[6])};
                states30[33].Transitions = new DfaTrans[1] {new DfaTrans(states30[34], sets[39])};
                states30[34].Transitions = new DfaTrans[3] {new DfaTrans(states30[35], sets[40]), new DfaTrans(states30[34], sets[41]), new DfaTrans(states30[36], sets[9])};
                states30[35].Transitions = new DfaTrans[2] {new DfaTrans(states30[35], sets[40]), new DfaTrans(states30[34], sets[41])};
                states30[36].Transitions = Array.Empty<DfaTrans>();
                states30[37].Transitions = new DfaTrans[1] {new DfaTrans(states30[38], sets[6])};
                states30[38].Transitions = new DfaTrans[1] {new DfaTrans(states30[39], sets[39])};
                states30[39].Transitions = new DfaTrans[3] {new DfaTrans(states30[40], sets[40]), new DfaTrans(states30[39], sets[41]), new DfaTrans(states30[41], sets[9])};
                states30[40].Transitions = new DfaTrans[2] {new DfaTrans(states30[40], sets[40]), new DfaTrans(states30[39], sets[41])};
                states30[41].Transitions = Array.Empty<DfaTrans>();
                states30[42].Transitions = new DfaTrans[1] {new DfaTrans(states30[43], sets[32])};
                states30[43].Transitions = new DfaTrans[2] {new DfaTrans(states30[44], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[44].Transitions = new DfaTrans[2] {new DfaTrans(states30[45], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[45].Transitions = new DfaTrans[2] {new DfaTrans(states30[46], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[46].Transitions = new DfaTrans[2] {new DfaTrans(states30[47], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[47].Transitions = new DfaTrans[2] {new DfaTrans(states30[48], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[48].Transitions = new DfaTrans[1] {new DfaTrans(states30[29], sets[9])};
                states30[49].Transitions = Array.Empty<DfaTrans>();
                states30[50].Transitions = Array.Empty<DfaTrans>();
                states30[51].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 31 -- ˈtextˈ | '(' | ',' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states31 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,20), new DfaState(15,true,0), new DfaState(16,true,21), new DfaState(17,true,8), new DfaState(18,true,16), new DfaState(19,true,9)};
                states31[0].Transitions = new DfaTrans[8] {new DfaTrans(states31[1], sets[23]), new DfaTrans(states31[13], sets[24]), new DfaTrans(states31[14], sets[25]), new DfaTrans(states31[15], sets[4]), new DfaTrans(states31[16], sets[27]), new DfaTrans(states31[17], sets[6]), new DfaTrans(states31[18], sets[28]), new DfaTrans(states31[19], sets[9])};
                states31[1].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[29]), new DfaTrans(states31[4], sets[30])};
                states31[2].Transitions = new DfaTrans[3] {new DfaTrans(states31[2], sets[29]), new DfaTrans(states31[3], sets[23]), new DfaTrans(states31[4], sets[30])};
                states31[3].Transitions = Array.Empty<DfaTrans>();
                states31[4].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[31]), new DfaTrans(states31[5], sets[14])};
                states31[5].Transitions = new DfaTrans[1] {new DfaTrans(states31[6], sets[6])};
                states31[6].Transitions = new DfaTrans[1] {new DfaTrans(states31[7], sets[32])};
                states31[7].Transitions = new DfaTrans[2] {new DfaTrans(states31[8], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[8].Transitions = new DfaTrans[2] {new DfaTrans(states31[9], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[9].Transitions = new DfaTrans[2] {new DfaTrans(states31[10], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[10].Transitions = new DfaTrans[2] {new DfaTrans(states31[11], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[11].Transitions = new DfaTrans[2] {new DfaTrans(states31[12], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[12].Transitions = new DfaTrans[1] {new DfaTrans(states31[2], sets[9])};
                states31[13].Transitions = Array.Empty<DfaTrans>();
                states31[14].Transitions = Array.Empty<DfaTrans>();
                states31[15].Transitions = new DfaTrans[1] {new DfaTrans(states31[15], sets[5])};
                states31[16].Transitions = Array.Empty<DfaTrans>();
                states31[17].Transitions = Array.Empty<DfaTrans>();
                states31[18].Transitions = Array.Empty<DfaTrans>();
                states31[19].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 32 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states32 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,2), new DfaState(17,true,13), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,16), new DfaState(49,true,26)};
                states32[0].Transitions = new DfaTrans[13] {new DfaTrans(states32[1], sets[23]), new DfaTrans(states32[13], sets[24]), new DfaTrans(states32[14], sets[42]), new DfaTrans(states32[15], sets[37]), new DfaTrans(states32[16], sets[33]), new DfaTrans(states32[17], sets[26]), new DfaTrans(states32[18], sets[43]), new DfaTrans(states32[19], sets[34]), new DfaTrans(states32[20], sets[35]), new DfaTrans(states32[28], sets[30]), new DfaTrans(states32[47], sets[6]), new DfaTrans(states32[48], sets[28]), new DfaTrans(states32[49], sets[36])};
                states32[1].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[29]), new DfaTrans(states32[4], sets[30])};
                states32[2].Transitions = new DfaTrans[3] {new DfaTrans(states32[2], sets[29]), new DfaTrans(states32[3], sets[23]), new DfaTrans(states32[4], sets[30])};
                states32[3].Transitions = Array.Empty<DfaTrans>();
                states32[4].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[31]), new DfaTrans(states32[5], sets[14])};
                states32[5].Transitions = new DfaTrans[1] {new DfaTrans(states32[6], sets[6])};
                states32[6].Transitions = new DfaTrans[1] {new DfaTrans(states32[7], sets[32])};
                states32[7].Transitions = new DfaTrans[2] {new DfaTrans(states32[8], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[8].Transitions = new DfaTrans[2] {new DfaTrans(states32[9], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[9].Transitions = new DfaTrans[2] {new DfaTrans(states32[10], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[10].Transitions = new DfaTrans[2] {new DfaTrans(states32[11], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[11].Transitions = new DfaTrans[2] {new DfaTrans(states32[12], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[12].Transitions = new DfaTrans[1] {new DfaTrans(states32[2], sets[9])};
                states32[13].Transitions = Array.Empty<DfaTrans>();
                states32[14].Transitions = Array.Empty<DfaTrans>();
                states32[15].Transitions = Array.Empty<DfaTrans>();
                states32[16].Transitions = Array.Empty<DfaTrans>();
                states32[17].Transitions = Array.Empty<DfaTrans>();
                states32[18].Transitions = Array.Empty<DfaTrans>();
                states32[19].Transitions = new DfaTrans[1] {new DfaTrans(states32[19], sets[5])};
                states32[20].Transitions = new DfaTrans[2] {new DfaTrans(states32[21], sets[37]), new DfaTrans(states32[19], sets[5])};
                states32[21].Transitions = new DfaTrans[1] {new DfaTrans(states32[22], sets[32])};
                states32[22].Transitions = new DfaTrans[1] {new DfaTrans(states32[23], sets[32])};
                states32[23].Transitions = new DfaTrans[1] {new DfaTrans(states32[24], sets[32])};
                states32[24].Transitions = new DfaTrans[1] {new DfaTrans(states32[25], sets[32])};
                states32[25].Transitions = new DfaTrans[1] {new DfaTrans(states32[26], sets[32])};
                states32[26].Transitions = new DfaTrans[1] {new DfaTrans(states32[27], sets[32])};
                states32[27].Transitions = Array.Empty<DfaTrans>();
                states32[28].Transitions = new DfaTrans[1] {new DfaTrans(states32[29], sets[14])};
                states32[29].Transitions = new DfaTrans[3] {new DfaTrans(states32[30], sets[38]), new DfaTrans(states32[35], sets[18]), new DfaTrans(states32[40], sets[6])};
                states32[30].Transitions = new DfaTrans[1] {new DfaTrans(states32[31], sets[6])};
                states32[31].Transitions = new DfaTrans[1] {new DfaTrans(states32[32], sets[39])};
                states32[32].Transitions = new DfaTrans[3] {new DfaTrans(states32[33], sets[40]), new DfaTrans(states32[32], sets[41]), new DfaTrans(states32[34], sets[9])};
                states32[33].Transitions = new DfaTrans[2] {new DfaTrans(states32[33], sets[40]), new DfaTrans(states32[32], sets[41])};
                states32[34].Transitions = Array.Empty<DfaTrans>();
                states32[35].Transitions = new DfaTrans[1] {new DfaTrans(states32[36], sets[6])};
                states32[36].Transitions = new DfaTrans[1] {new DfaTrans(states32[37], sets[39])};
                states32[37].Transitions = new DfaTrans[3] {new DfaTrans(states32[38], sets[40]), new DfaTrans(states32[37], sets[41]), new DfaTrans(states32[39], sets[9])};
                states32[38].Transitions = new DfaTrans[2] {new DfaTrans(states32[38], sets[40]), new DfaTrans(states32[37], sets[41])};
                states32[39].Transitions = Array.Empty<DfaTrans>();
                states32[40].Transitions = new DfaTrans[1] {new DfaTrans(states32[41], sets[32])};
                states32[41].Transitions = new DfaTrans[2] {new DfaTrans(states32[42], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[42].Transitions = new DfaTrans[2] {new DfaTrans(states32[43], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[43].Transitions = new DfaTrans[2] {new DfaTrans(states32[44], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[44].Transitions = new DfaTrans[2] {new DfaTrans(states32[45], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[45].Transitions = new DfaTrans[2] {new DfaTrans(states32[46], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[46].Transitions = new DfaTrans[1] {new DfaTrans(states32[27], sets[9])};
                states32[47].Transitions = Array.Empty<DfaTrans>();
                states32[48].Transitions = Array.Empty<DfaTrans>();
                states32[49].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 33 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states33 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,2), new DfaState(17,true,27), new DfaState(18,true,13), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,26)};
                states33[0].Transitions = new DfaTrans[13] {new DfaTrans(states33[1], sets[23]), new DfaTrans(states33[13], sets[24]), new DfaTrans(states33[14], sets[42]), new DfaTrans(states33[15], sets[37]), new DfaTrans(states33[16], sets[33]), new DfaTrans(states33[18], sets[26]), new DfaTrans(states33[19], sets[43]), new DfaTrans(states33[20], sets[34]), new DfaTrans(states33[21], sets[35]), new DfaTrans(states33[29], sets[30]), new DfaTrans(states33[48], sets[6]), new DfaTrans(states33[49], sets[28]), new DfaTrans(states33[50], sets[36])};
                states33[1].Transitions = new DfaTrans[2] {new DfaTrans(states33[2], sets[29]), new DfaTrans(states33[4], sets[30])};
                states33[2].Transitions = new DfaTrans[3] {new DfaTrans(states33[2], sets[29]), new DfaTrans(states33[3], sets[23]), new DfaTrans(states33[4], sets[30])};
                states33[3].Transitions = Array.Empty<DfaTrans>();
                states33[4].Transitions = new DfaTrans[2] {new DfaTrans(states33[2], sets[31]), new DfaTrans(states33[5], sets[14])};
                states33[5].Transitions = new DfaTrans[1] {new DfaTrans(states33[6], sets[6])};
                states33[6].Transitions = new DfaTrans[1] {new DfaTrans(states33[7], sets[32])};
                states33[7].Transitions = new DfaTrans[2] {new DfaTrans(states33[8], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[8].Transitions = new DfaTrans[2] {new DfaTrans(states33[9], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[9].Transitions = new DfaTrans[2] {new DfaTrans(states33[10], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[10].Transitions = new DfaTrans[2] {new DfaTrans(states33[11], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[11].Transitions = new DfaTrans[2] {new DfaTrans(states33[12], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[12].Transitions = new DfaTrans[1] {new DfaTrans(states33[2], sets[9])};
                states33[13].Transitions = Array.Empty<DfaTrans>();
                states33[14].Transitions = Array.Empty<DfaTrans>();
                states33[15].Transitions = Array.Empty<DfaTrans>();
                states33[16].Transitions = new DfaTrans[1] {new DfaTrans(states33[17], sets[33])};
                states33[17].Transitions = Array.Empty<DfaTrans>();
                states33[18].Transitions = Array.Empty<DfaTrans>();
                states33[19].Transitions = Array.Empty<DfaTrans>();
                states33[20].Transitions = new DfaTrans[1] {new DfaTrans(states33[20], sets[5])};
                states33[21].Transitions = new DfaTrans[2] {new DfaTrans(states33[22], sets[37]), new DfaTrans(states33[20], sets[5])};
                states33[22].Transitions = new DfaTrans[1] {new DfaTrans(states33[23], sets[32])};
                states33[23].Transitions = new DfaTrans[1] {new DfaTrans(states33[24], sets[32])};
                states33[24].Transitions = new DfaTrans[1] {new DfaTrans(states33[25], sets[32])};
                states33[25].Transitions = new DfaTrans[1] {new DfaTrans(states33[26], sets[32])};
                states33[26].Transitions = new DfaTrans[1] {new DfaTrans(states33[27], sets[32])};
                states33[27].Transitions = new DfaTrans[1] {new DfaTrans(states33[28], sets[32])};
                states33[28].Transitions = Array.Empty<DfaTrans>();
                states33[29].Transitions = new DfaTrans[1] {new DfaTrans(states33[30], sets[14])};
                states33[30].Transitions = new DfaTrans[3] {new DfaTrans(states33[31], sets[38]), new DfaTrans(states33[36], sets[18]), new DfaTrans(states33[41], sets[6])};
                states33[31].Transitions = new DfaTrans[1] {new DfaTrans(states33[32], sets[6])};
                states33[32].Transitions = new DfaTrans[1] {new DfaTrans(states33[33], sets[39])};
                states33[33].Transitions = new DfaTrans[3] {new DfaTrans(states33[34], sets[40]), new DfaTrans(states33[33], sets[41]), new DfaTrans(states33[35], sets[9])};
                states33[34].Transitions = new DfaTrans[2] {new DfaTrans(states33[34], sets[40]), new DfaTrans(states33[33], sets[41])};
                states33[35].Transitions = Array.Empty<DfaTrans>();
                states33[36].Transitions = new DfaTrans[1] {new DfaTrans(states33[37], sets[6])};
                states33[37].Transitions = new DfaTrans[1] {new DfaTrans(states33[38], sets[39])};
                states33[38].Transitions = new DfaTrans[3] {new DfaTrans(states33[39], sets[40]), new DfaTrans(states33[38], sets[41]), new DfaTrans(states33[40], sets[9])};
                states33[39].Transitions = new DfaTrans[2] {new DfaTrans(states33[39], sets[40]), new DfaTrans(states33[38], sets[41])};
                states33[40].Transitions = Array.Empty<DfaTrans>();
                states33[41].Transitions = new DfaTrans[1] {new DfaTrans(states33[42], sets[32])};
                states33[42].Transitions = new DfaTrans[2] {new DfaTrans(states33[43], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[43].Transitions = new DfaTrans[2] {new DfaTrans(states33[44], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[44].Transitions = new DfaTrans[2] {new DfaTrans(states33[45], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[45].Transitions = new DfaTrans[2] {new DfaTrans(states33[46], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[46].Transitions = new DfaTrans[2] {new DfaTrans(states33[47], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[47].Transitions = new DfaTrans[1] {new DfaTrans(states33[28], sets[9])};
                states33[48].Transitions = Array.Empty<DfaTrans>();
                states33[49].Transitions = Array.Empty<DfaTrans>();
                states33[50].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 34 -- ',' | '}' -- */
                var states34 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,20), new DfaState(2,true,9)};
                states34[0].Transitions = new DfaTrans[2] {new DfaTrans(states34[1], sets[25]), new DfaTrans(states34[2], sets[9])};
                states34[1].Transitions = Array.Empty<DfaTrans>();
                states34[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 35 -- ˈtextˈ | '(' | ')' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states35 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,2), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,16), new DfaState(45,true,26)};
                states35[0].Transitions = new DfaTrans[9] {new DfaTrans(states35[1], sets[23]), new DfaTrans(states35[13], sets[24]), new DfaTrans(states35[14], sets[44]), new DfaTrans(states35[15], sets[33]), new DfaTrans(states35[16], sets[34]), new DfaTrans(states35[17], sets[35]), new DfaTrans(states35[25], sets[30]), new DfaTrans(states35[44], sets[28]), new DfaTrans(states35[45], sets[36])};
                states35[1].Transitions = new DfaTrans[2] {new DfaTrans(states35[2], sets[29]), new DfaTrans(states35[4], sets[30])};
                states35[2].Transitions = new DfaTrans[3] {new DfaTrans(states35[2], sets[29]), new DfaTrans(states35[3], sets[23]), new DfaTrans(states35[4], sets[30])};
                states35[3].Transitions = Array.Empty<DfaTrans>();
                states35[4].Transitions = new DfaTrans[2] {new DfaTrans(states35[2], sets[31]), new DfaTrans(states35[5], sets[14])};
                states35[5].Transitions = new DfaTrans[1] {new DfaTrans(states35[6], sets[6])};
                states35[6].Transitions = new DfaTrans[1] {new DfaTrans(states35[7], sets[32])};
                states35[7].Transitions = new DfaTrans[2] {new DfaTrans(states35[8], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[8].Transitions = new DfaTrans[2] {new DfaTrans(states35[9], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[9].Transitions = new DfaTrans[2] {new DfaTrans(states35[10], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[10].Transitions = new DfaTrans[2] {new DfaTrans(states35[11], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[11].Transitions = new DfaTrans[2] {new DfaTrans(states35[12], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[12].Transitions = new DfaTrans[1] {new DfaTrans(states35[2], sets[9])};
                states35[13].Transitions = Array.Empty<DfaTrans>();
                states35[14].Transitions = Array.Empty<DfaTrans>();
                states35[15].Transitions = Array.Empty<DfaTrans>();
                states35[16].Transitions = new DfaTrans[1] {new DfaTrans(states35[16], sets[5])};
                states35[17].Transitions = new DfaTrans[2] {new DfaTrans(states35[18], sets[37]), new DfaTrans(states35[16], sets[5])};
                states35[18].Transitions = new DfaTrans[1] {new DfaTrans(states35[19], sets[32])};
                states35[19].Transitions = new DfaTrans[1] {new DfaTrans(states35[20], sets[32])};
                states35[20].Transitions = new DfaTrans[1] {new DfaTrans(states35[21], sets[32])};
                states35[21].Transitions = new DfaTrans[1] {new DfaTrans(states35[22], sets[32])};
                states35[22].Transitions = new DfaTrans[1] {new DfaTrans(states35[23], sets[32])};
                states35[23].Transitions = new DfaTrans[1] {new DfaTrans(states35[24], sets[32])};
                states35[24].Transitions = Array.Empty<DfaTrans>();
                states35[25].Transitions = new DfaTrans[1] {new DfaTrans(states35[26], sets[14])};
                states35[26].Transitions = new DfaTrans[3] {new DfaTrans(states35[27], sets[38]), new DfaTrans(states35[32], sets[18]), new DfaTrans(states35[37], sets[6])};
                states35[27].Transitions = new DfaTrans[1] {new DfaTrans(states35[28], sets[6])};
                states35[28].Transitions = new DfaTrans[1] {new DfaTrans(states35[29], sets[39])};
                states35[29].Transitions = new DfaTrans[3] {new DfaTrans(states35[30], sets[40]), new DfaTrans(states35[29], sets[41]), new DfaTrans(states35[31], sets[9])};
                states35[30].Transitions = new DfaTrans[2] {new DfaTrans(states35[30], sets[40]), new DfaTrans(states35[29], sets[41])};
                states35[31].Transitions = Array.Empty<DfaTrans>();
                states35[32].Transitions = new DfaTrans[1] {new DfaTrans(states35[33], sets[6])};
                states35[33].Transitions = new DfaTrans[1] {new DfaTrans(states35[34], sets[39])};
                states35[34].Transitions = new DfaTrans[3] {new DfaTrans(states35[35], sets[40]), new DfaTrans(states35[34], sets[41]), new DfaTrans(states35[36], sets[9])};
                states35[35].Transitions = new DfaTrans[2] {new DfaTrans(states35[35], sets[40]), new DfaTrans(states35[34], sets[41])};
                states35[36].Transitions = Array.Empty<DfaTrans>();
                states35[37].Transitions = new DfaTrans[1] {new DfaTrans(states35[38], sets[32])};
                states35[38].Transitions = new DfaTrans[2] {new DfaTrans(states35[39], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[39].Transitions = new DfaTrans[2] {new DfaTrans(states35[40], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[40].Transitions = new DfaTrans[2] {new DfaTrans(states35[41], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[41].Transitions = new DfaTrans[2] {new DfaTrans(states35[42], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[42].Transitions = new DfaTrans[2] {new DfaTrans(states35[43], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[43].Transitions = new DfaTrans[1] {new DfaTrans(states35[24], sets[9])};
                states35[44].Transitions = Array.Empty<DfaTrans>();
                states35[45].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 36 -- '}' -- */
                var states36 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,9)};
                states36[0].Transitions = new DfaTrans[1] {new DfaTrans(states36[1], sets[9])};
                states36[1].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 37 -- '|' | '}' -- */
                var states37 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,16), new DfaState(2,true,9)};
                states37[0].Transitions = new DfaTrans[2] {new DfaTrans(states37[1], sets[28]), new DfaTrans(states37[2], sets[9])};
                states37[1].Transitions = Array.Empty<DfaTrans>();
                states37[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 38 -- ˈtextˈ | '(' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states38 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,20), new DfaState(17,true,17), new DfaState(18,true,0), new DfaState(19,true,21), new DfaState(20,true,8), new DfaState(21,true,16), new DfaState(22,true,9)};
                states38[0].Transitions = new DfaTrans[11] {new DfaTrans(states38[1], sets[23]), new DfaTrans(states38[13], sets[24]), new DfaTrans(states38[14], sets[42]), new DfaTrans(states38[15], sets[37]), new DfaTrans(states38[16], sets[25]), new DfaTrans(states38[17], sets[43]), new DfaTrans(states38[18], sets[4]), new DfaTrans(states38[19], sets[27]), new DfaTrans(states38[20], sets[6]), new DfaTrans(states38[21], sets[28]), new DfaTrans(states38[22], sets[9])};
                states38[1].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[29]), new DfaTrans(states38[4], sets[30])};
                states38[2].Transitions = new DfaTrans[3] {new DfaTrans(states38[2], sets[29]), new DfaTrans(states38[3], sets[23]), new DfaTrans(states38[4], sets[30])};
                states38[3].Transitions = Array.Empty<DfaTrans>();
                states38[4].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[31]), new DfaTrans(states38[5], sets[14])};
                states38[5].Transitions = new DfaTrans[1] {new DfaTrans(states38[6], sets[6])};
                states38[6].Transitions = new DfaTrans[1] {new DfaTrans(states38[7], sets[32])};
                states38[7].Transitions = new DfaTrans[2] {new DfaTrans(states38[8], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[8].Transitions = new DfaTrans[2] {new DfaTrans(states38[9], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[9].Transitions = new DfaTrans[2] {new DfaTrans(states38[10], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[10].Transitions = new DfaTrans[2] {new DfaTrans(states38[11], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[11].Transitions = new DfaTrans[2] {new DfaTrans(states38[12], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[12].Transitions = new DfaTrans[1] {new DfaTrans(states38[2], sets[9])};
                states38[13].Transitions = Array.Empty<DfaTrans>();
                states38[14].Transitions = Array.Empty<DfaTrans>();
                states38[15].Transitions = Array.Empty<DfaTrans>();
                states38[16].Transitions = Array.Empty<DfaTrans>();
                states38[17].Transitions = Array.Empty<DfaTrans>();
                states38[18].Transitions = new DfaTrans[1] {new DfaTrans(states38[18], sets[5])};
                states38[19].Transitions = Array.Empty<DfaTrans>();
                states38[20].Transitions = Array.Empty<DfaTrans>();
                states38[21].Transitions = Array.Empty<DfaTrans>();
                states38[22].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 39 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states39 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,2), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,16), new DfaState(49,true,26)};
                states39[0].Transitions = new DfaTrans[13] {new DfaTrans(states39[1], sets[23]), new DfaTrans(states39[13], sets[24]), new DfaTrans(states39[14], sets[44]), new DfaTrans(states39[15], sets[42]), new DfaTrans(states39[16], sets[37]), new DfaTrans(states39[17], sets[33]), new DfaTrans(states39[18], sets[43]), new DfaTrans(states39[19], sets[34]), new DfaTrans(states39[20], sets[35]), new DfaTrans(states39[28], sets[30]), new DfaTrans(states39[47], sets[6]), new DfaTrans(states39[48], sets[28]), new DfaTrans(states39[49], sets[36])};
                states39[1].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[29]), new DfaTrans(states39[4], sets[30])};
                states39[2].Transitions = new DfaTrans[3] {new DfaTrans(states39[2], sets[29]), new DfaTrans(states39[3], sets[23]), new DfaTrans(states39[4], sets[30])};
                states39[3].Transitions = Array.Empty<DfaTrans>();
                states39[4].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[31]), new DfaTrans(states39[5], sets[14])};
                states39[5].Transitions = new DfaTrans[1] {new DfaTrans(states39[6], sets[6])};
                states39[6].Transitions = new DfaTrans[1] {new DfaTrans(states39[7], sets[32])};
                states39[7].Transitions = new DfaTrans[2] {new DfaTrans(states39[8], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[8].Transitions = new DfaTrans[2] {new DfaTrans(states39[9], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[9].Transitions = new DfaTrans[2] {new DfaTrans(states39[10], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[10].Transitions = new DfaTrans[2] {new DfaTrans(states39[11], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[11].Transitions = new DfaTrans[2] {new DfaTrans(states39[12], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[12].Transitions = new DfaTrans[1] {new DfaTrans(states39[2], sets[9])};
                states39[13].Transitions = Array.Empty<DfaTrans>();
                states39[14].Transitions = Array.Empty<DfaTrans>();
                states39[15].Transitions = Array.Empty<DfaTrans>();
                states39[16].Transitions = Array.Empty<DfaTrans>();
                states39[17].Transitions = Array.Empty<DfaTrans>();
                states39[18].Transitions = Array.Empty<DfaTrans>();
                states39[19].Transitions = new DfaTrans[1] {new DfaTrans(states39[19], sets[5])};
                states39[20].Transitions = new DfaTrans[2] {new DfaTrans(states39[21], sets[37]), new DfaTrans(states39[19], sets[5])};
                states39[21].Transitions = new DfaTrans[1] {new DfaTrans(states39[22], sets[32])};
                states39[22].Transitions = new DfaTrans[1] {new DfaTrans(states39[23], sets[32])};
                states39[23].Transitions = new DfaTrans[1] {new DfaTrans(states39[24], sets[32])};
                states39[24].Transitions = new DfaTrans[1] {new DfaTrans(states39[25], sets[32])};
                states39[25].Transitions = new DfaTrans[1] {new DfaTrans(states39[26], sets[32])};
                states39[26].Transitions = new DfaTrans[1] {new DfaTrans(states39[27], sets[32])};
                states39[27].Transitions = Array.Empty<DfaTrans>();
                states39[28].Transitions = new DfaTrans[1] {new DfaTrans(states39[29], sets[14])};
                states39[29].Transitions = new DfaTrans[3] {new DfaTrans(states39[30], sets[38]), new DfaTrans(states39[35], sets[18]), new DfaTrans(states39[40], sets[6])};
                states39[30].Transitions = new DfaTrans[1] {new DfaTrans(states39[31], sets[6])};
                states39[31].Transitions = new DfaTrans[1] {new DfaTrans(states39[32], sets[39])};
                states39[32].Transitions = new DfaTrans[3] {new DfaTrans(states39[33], sets[40]), new DfaTrans(states39[32], sets[41]), new DfaTrans(states39[34], sets[9])};
                states39[33].Transitions = new DfaTrans[2] {new DfaTrans(states39[33], sets[40]), new DfaTrans(states39[32], sets[41])};
                states39[34].Transitions = Array.Empty<DfaTrans>();
                states39[35].Transitions = new DfaTrans[1] {new DfaTrans(states39[36], sets[6])};
                states39[36].Transitions = new DfaTrans[1] {new DfaTrans(states39[37], sets[39])};
                states39[37].Transitions = new DfaTrans[3] {new DfaTrans(states39[38], sets[40]), new DfaTrans(states39[37], sets[41]), new DfaTrans(states39[39], sets[9])};
                states39[38].Transitions = new DfaTrans[2] {new DfaTrans(states39[38], sets[40]), new DfaTrans(states39[37], sets[41])};
                states39[39].Transitions = Array.Empty<DfaTrans>();
                states39[40].Transitions = new DfaTrans[1] {new DfaTrans(states39[41], sets[32])};
                states39[41].Transitions = new DfaTrans[2] {new DfaTrans(states39[42], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[42].Transitions = new DfaTrans[2] {new DfaTrans(states39[43], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[43].Transitions = new DfaTrans[2] {new DfaTrans(states39[44], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[44].Transitions = new DfaTrans[2] {new DfaTrans(states39[45], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[45].Transitions = new DfaTrans[2] {new DfaTrans(states39[46], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[46].Transitions = new DfaTrans[1] {new DfaTrans(states39[27], sets[9])};
                states39[47].Transitions = Array.Empty<DfaTrans>();
                states39[48].Transitions = Array.Empty<DfaTrans>();
                states39[49].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 40 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states40 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,2), new DfaState(18,true,27), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,26)};
                states40[0].Transitions = new DfaTrans[13] {new DfaTrans(states40[1], sets[23]), new DfaTrans(states40[13], sets[24]), new DfaTrans(states40[14], sets[44]), new DfaTrans(states40[15], sets[42]), new DfaTrans(states40[16], sets[37]), new DfaTrans(states40[17], sets[33]), new DfaTrans(states40[19], sets[43]), new DfaTrans(states40[20], sets[34]), new DfaTrans(states40[21], sets[35]), new DfaTrans(states40[29], sets[30]), new DfaTrans(states40[48], sets[6]), new DfaTrans(states40[49], sets[28]), new DfaTrans(states40[50], sets[36])};
                states40[1].Transitions = new DfaTrans[2] {new DfaTrans(states40[2], sets[29]), new DfaTrans(states40[4], sets[30])};
                states40[2].Transitions = new DfaTrans[3] {new DfaTrans(states40[2], sets[29]), new DfaTrans(states40[3], sets[23]), new DfaTrans(states40[4], sets[30])};
                states40[3].Transitions = Array.Empty<DfaTrans>();
                states40[4].Transitions = new DfaTrans[2] {new DfaTrans(states40[2], sets[31]), new DfaTrans(states40[5], sets[14])};
                states40[5].Transitions = new DfaTrans[1] {new DfaTrans(states40[6], sets[6])};
                states40[6].Transitions = new DfaTrans[1] {new DfaTrans(states40[7], sets[32])};
                states40[7].Transitions = new DfaTrans[2] {new DfaTrans(states40[8], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[8].Transitions = new DfaTrans[2] {new DfaTrans(states40[9], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[9].Transitions = new DfaTrans[2] {new DfaTrans(states40[10], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[10].Transitions = new DfaTrans[2] {new DfaTrans(states40[11], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[11].Transitions = new DfaTrans[2] {new DfaTrans(states40[12], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[12].Transitions = new DfaTrans[1] {new DfaTrans(states40[2], sets[9])};
                states40[13].Transitions = Array.Empty<DfaTrans>();
                states40[14].Transitions = Array.Empty<DfaTrans>();
                states40[15].Transitions = Array.Empty<DfaTrans>();
                states40[16].Transitions = Array.Empty<DfaTrans>();
                states40[17].Transitions = new DfaTrans[1] {new DfaTrans(states40[18], sets[33])};
                states40[18].Transitions = Array.Empty<DfaTrans>();
                states40[19].Transitions = Array.Empty<DfaTrans>();
                states40[20].Transitions = new DfaTrans[1] {new DfaTrans(states40[20], sets[5])};
                states40[21].Transitions = new DfaTrans[2] {new DfaTrans(states40[22], sets[37]), new DfaTrans(states40[20], sets[5])};
                states40[22].Transitions = new DfaTrans[1] {new DfaTrans(states40[23], sets[32])};
                states40[23].Transitions = new DfaTrans[1] {new DfaTrans(states40[24], sets[32])};
                states40[24].Transitions = new DfaTrans[1] {new DfaTrans(states40[25], sets[32])};
                states40[25].Transitions = new DfaTrans[1] {new DfaTrans(states40[26], sets[32])};
                states40[26].Transitions = new DfaTrans[1] {new DfaTrans(states40[27], sets[32])};
                states40[27].Transitions = new DfaTrans[1] {new DfaTrans(states40[28], sets[32])};
                states40[28].Transitions = Array.Empty<DfaTrans>();
                states40[29].Transitions = new DfaTrans[1] {new DfaTrans(states40[30], sets[14])};
                states40[30].Transitions = new DfaTrans[3] {new DfaTrans(states40[31], sets[38]), new DfaTrans(states40[36], sets[18]), new DfaTrans(states40[41], sets[6])};
                states40[31].Transitions = new DfaTrans[1] {new DfaTrans(states40[32], sets[6])};
                states40[32].Transitions = new DfaTrans[1] {new DfaTrans(states40[33], sets[39])};
                states40[33].Transitions = new DfaTrans[3] {new DfaTrans(states40[34], sets[40]), new DfaTrans(states40[33], sets[41]), new DfaTrans(states40[35], sets[9])};
                states40[34].Transitions = new DfaTrans[2] {new DfaTrans(states40[34], sets[40]), new DfaTrans(states40[33], sets[41])};
                states40[35].Transitions = Array.Empty<DfaTrans>();
                states40[36].Transitions = new DfaTrans[1] {new DfaTrans(states40[37], sets[6])};
                states40[37].Transitions = new DfaTrans[1] {new DfaTrans(states40[38], sets[39])};
                states40[38].Transitions = new DfaTrans[3] {new DfaTrans(states40[39], sets[40]), new DfaTrans(states40[38], sets[41]), new DfaTrans(states40[40], sets[9])};
                states40[39].Transitions = new DfaTrans[2] {new DfaTrans(states40[39], sets[40]), new DfaTrans(states40[38], sets[41])};
                states40[40].Transitions = Array.Empty<DfaTrans>();
                states40[41].Transitions = new DfaTrans[1] {new DfaTrans(states40[42], sets[32])};
                states40[42].Transitions = new DfaTrans[2] {new DfaTrans(states40[43], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[43].Transitions = new DfaTrans[2] {new DfaTrans(states40[44], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[44].Transitions = new DfaTrans[2] {new DfaTrans(states40[45], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[45].Transitions = new DfaTrans[2] {new DfaTrans(states40[46], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[46].Transitions = new DfaTrans[2] {new DfaTrans(states40[47], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[47].Transitions = new DfaTrans[1] {new DfaTrans(states40[28], sets[9])};
                states40[48].Transitions = Array.Empty<DfaTrans>();
                states40[49].Transitions = Array.Empty<DfaTrans>();
                states40[50].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 41 --  -- */
                var states41 = new DfaState[12] {new DfaState(0,true,-1), new DfaState(1,false,-1), new DfaState(2,true,-1), new DfaState(3,true,-1), new DfaState(4,true,-1), new DfaState(5,true,-1), new DfaState(6,true,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,true,-1)};
                states41[0].Transitions = new DfaTrans[2] {new DfaTrans(states41[0], sets[48]), new DfaTrans(states41[1], sets[49])};
                states41[1].Transitions = new DfaTrans[2] {new DfaTrans(states41[2], sets[49]), new DfaTrans(states41[9], sets[42])};
                states41[2].Transitions = new DfaTrans[3] {new DfaTrans(states41[2], sets[50]), new DfaTrans(states41[0], sets[51]), new DfaTrans(states41[3], sets[49])};
                states41[3].Transitions = new DfaTrans[4] {new DfaTrans(states41[2], sets[52]), new DfaTrans(states41[0], sets[51]), new DfaTrans(states41[3], sets[49]), new DfaTrans(states41[4], sets[42])};
                states41[4].Transitions = new DfaTrans[4] {new DfaTrans(states41[5], sets[42]), new DfaTrans(states41[6], sets[51]), new DfaTrans(states41[4], sets[52]), new DfaTrans(states41[11], sets[49])};
                states41[5].Transitions = new DfaTrans[3] {new DfaTrans(states41[4], sets[50]), new DfaTrans(states41[6], sets[51]), new DfaTrans(states41[3], sets[49])};
                states41[6].Transitions = new DfaTrans[4] {new DfaTrans(states41[6], sets[48]), new DfaTrans(states41[7], sets[49]), new DfaTrans(states41[9], sets[53]), new DfaTrans(states41[10], sets[42])};
                states41[7].Transitions = new DfaTrans[3] {new DfaTrans(states41[4], sets[49]), new DfaTrans(states41[8], sets[42]), new DfaTrans(states41[9], sets[54])};
                states41[8].Transitions = new DfaTrans[3] {new DfaTrans(states41[9], sets[54]), new DfaTrans(states41[8], sets[42]), new DfaTrans(states41[6], sets[49])};
                states41[9].Transitions = new DfaTrans[2] {new DfaTrans(states41[9], sets[55]), new DfaTrans(states41[10], sets[42])};
                states41[10].Transitions = new DfaTrans[2] {new DfaTrans(states41[0], sets[49]), new DfaTrans(states41[9], sets[56])};
                states41[11].Transitions = new DfaTrans[3] {new DfaTrans(states41[4], sets[52]), new DfaTrans(states41[6], sets[51]), new DfaTrans(states41[11], sets[57])};
                
                var dfas = new Dfa[]
                {
                    new Dfa(states0), new Dfa(states1), new Dfa(states2), new Dfa(states3), new Dfa(states4), new Dfa(states5),
                    new Dfa(states6), new Dfa(states7), new Dfa(states8), new Dfa(states9), new Dfa(states10), new Dfa(states11),
                    new Dfa(states12), new Dfa(states13), new Dfa(states14), new Dfa(states15), new Dfa(states16), new Dfa(states17),
                    new Dfa(states18), new Dfa(states19), new Dfa(states20), new Dfa(states21), new Dfa(states22), new Dfa(states23),
                    new Dfa(states24), new Dfa(states25), new Dfa(states26), new Dfa(states27), new Dfa(states28), new Dfa(states29),
                    new Dfa(states30), new Dfa(states31), new Dfa(states32), new Dfa(states33), new Dfa(states34), new Dfa(states35),
                    new Dfa(states36), new Dfa(states37), new Dfa(states38), new Dfa(states39), new Dfa(states40), new Dfa(states41),
                };
                
                return new DfaSet(dfas, map, dfas.Last());
            }
            
            public static ITable CreateParseTable()
            {
                
                ushort[] u16Table = 
                {
                    0, 0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 10,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 267, 46, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 0, 0, 0, 0, 0, 0, 26,
                    30, 0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 263, 263, 0, 0, 0, 0, 263, 0, 0,
                    0, 0, 0, 0, 0, 0, 263, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 15, 15, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 19, 0, 0, 0, 0, 19, 0, 0, 0, 0, 0, 0, 0,
                    0, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 23,
                    23, 0, 0, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 46, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 0, 0,
                    0, 0, 0, 0, 58, 30, 0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 259,
                    259, 0, 0, 0, 0, 259, 0, 0, 0, 0, 0, 0, 0, 0, 259, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 279, 0, 86, 0, 0, 90,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102,
                    0, 0, 0, 0, 0, 0, 0, 0, 291, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 0, 0, 0, 0, 0, 0, 0, 343, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 275, 0, 275, 0, 0, 275, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0, 86, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 287, 0, 0, 0, 0, 0, 0, 0, 0, 287, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102,
                    0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 134, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 146, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 142, 0, 0, 0, 0, 0, 0, 0, 0, 339, 0, 0, 0, 0,
                    0, 0, 0, 0, 339, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 271, 0, 271, 0, 0, 271, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 27, 27, 0, 0,
                    0, 0, 27, 0, 0, 0, 0, 0, 0, 0, 0, 27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 283, 0, 0, 0,
                    0, 0, 0, 0, 0, 283, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 39, 39, 0, 0, 0, 0, 39, 0, 0, 0, 0, 0, 0, 0,
                    0, 39, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 0, 250, 0, 0, 0, 0, 254,
                    0, 0, 0, 0, 323, 0, 0, 323, 0, 0, 0, 258, 262, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182,
                    186, 190, 194, 198, 202, 206, 210, 214, 218, 222, 226, 230, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 242, 0, 0, 0, 0, 0, 0, 295, 0, 0, 295, 0, 0, 0, 0, 295, 0, 0, 0, 0, 295,
                    0, 0, 295, 0, 0, 0, 295, 295, 295, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 299, 0, 0, 299, 0, 0, 0, 0, 299, 0, 0, 0, 0, 299, 0, 0, 299, 0, 0, 0, 299, 299, 299, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 335, 0, 0, 0, 0, 0, 0, 0, 0, 335, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 135, 135, 0, 0, 0, 0, 135, 0, 0, 0, 0, 0, 0, 0, 0, 135, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 338, 342, 346, 350, 354, 0, 0, 0, 0, 0, 0, 375,
                    0, 0, 375, 0, 0, 0, 0, 0, 358, 0, 0, 375, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 270, 0, 0, 274, 278, 282, 286, 290, 294, 298, 302, 306, 0, 310, 314, 318, 322, 326,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 330, 0, 347, 0, 347, 347, 347, 347, 347, 0, 0, 0, 0, 0, 0, 347, 0, 0, 347,
                    0, 0, 0, 0, 0, 347, 0, 0, 347, 347, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 351,
                    0, 351, 351, 351, 351, 351, 0, 0, 0, 0, 0, 0, 351, 0, 0, 351, 0, 0, 0, 0, 0, 351, 0, 0, 351, 351, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 307, 0, 0, 307, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 51, 0, 0, 51, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 319, 0, 0, 319, 0, 0, 0, 0, 319, 0, 0,
                    0, 0, 319, 0, 0, 319, 0, 0, 0, 319, 319, 319, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 59, 0, 0, 59, 0, 0, 0, 0, 59, 0, 0, 0, 0, 59, 0, 0, 59, 0, 0, 0, 59, 59, 59, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 63, 0, 0, 63, 0, 0, 0, 0, 63, 0, 0, 0,
                    0, 63, 0, 0, 63, 0, 0, 0, 63, 63, 63, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 67, 0, 0, 67, 0, 0, 0, 0, 67, 0, 0, 0, 0, 67, 0, 0, 67, 0, 0, 0, 67, 67, 67, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 71, 0, 0, 71, 0, 0, 0, 0, 71, 0, 0, 0, 0, 71,
                    0, 0, 71, 378, 382, 386, 71, 71, 71, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 87, 0, 0, 87, 0, 0, 0, 0, 87, 0, 0, 0, 0, 87, 0, 0, 87, 87, 87, 87, 87, 87, 87, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 91, 0, 0, 91, 0, 0, 0, 0, 91, 0, 0, 0, 0, 91,
                    0, 0, 91, 91, 91, 91, 91, 91, 91, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 95, 0, 0, 95, 0, 0, 0, 0, 95, 0, 0, 0, 0, 95, 0, 0, 95, 95, 95, 95, 95, 95, 95, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 107, 0, 0, 107, 0, 0, 0, 0, 107, 0, 0, 0, 0, 107,
                    0, 0, 107, 107, 107, 107, 107, 107, 107, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 115, 0, 0, 115, 0, 0, 0, 0, 115, 0, 0, 0, 0, 115, 0, 0, 115, 115, 115, 115, 115, 115, 115,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 123, 0, 0, 123, 0, 0, 0, 0, 123,
                    0, 0, 0, 0, 123, 0, 0, 123, 123, 123, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 47, 0, 0, 390, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 0, 250, 0, 0, 0, 0, 254,
                    0, 0, 0, 0, 55, 0, 0, 55, 0, 0, 0, 258, 262, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 394, 198, 202, 206, 210, 214, 218, 222, 226, 230, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 131, 0, 0, 131, 0, 0, 0, 0, 131, 0, 0, 0, 0, 131, 0, 0, 131,
                    131, 131, 131, 131, 131, 131, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    127, 0, 0, 127, 0, 0, 0, 0, 127, 0, 0, 0, 0, 127, 0, 0, 127, 127, 127, 127, 127, 127, 127, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 398, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    246, 0, 0, 250, 0, 0, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 402, 226, 230, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 0, 250, 0, 0, 0, 0, 254, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 406, 226, 230, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 474, 0, 0, 478, 0, 0, 0, 0, 482, 0, 0, 0, 0, 0, 0, 0, 323, 0, 0, 0, 486, 490, 494, 323, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 410, 414, 418, 422, 426, 430, 434, 438, 442, 446, 450, 454, 458,
                    462, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 466, 470, 0, 0, 0, 0, 0, 0, 243,
                    0, 243, 243, 243, 243, 243, 0, 243, 0, 0, 0, 0, 243, 0, 0, 243, 243, 243, 243, 0, 0, 243, 0, 0, 243,
                    243, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 498, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 363, 0, 0, 363, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 502, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 151, 0, 0, 151,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 147, 0, 0, 147, 0, 0, 0, 0, 0, 0, 0, 0, 510, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 371, 0, 371, 371, 371, 371, 371, 0, 0, 0, 0, 0, 0, 371, 0, 0, 371, 0,
                    0, 0, 0, 0, 371, 0, 0, 371, 371, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 163, 0,
                    163, 163, 163, 163, 163, 0, 0, 0, 0, 0, 0, 163, 0, 0, 163, 0, 0, 0, 0, 0, 163, 0, 0, 163, 163, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 167, 0, 167, 167, 167, 167, 167, 0, 0, 0, 0, 0,
                    0, 167, 0, 0, 167, 0, 0, 0, 0, 0, 167, 0, 0, 167, 167, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 171, 0, 171, 171, 171, 171, 171, 0, 0, 0, 0, 0, 0, 171, 0, 0, 171, 0, 0, 0, 0, 0, 171, 0,
                    0, 171, 171, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 0, 175, 175, 175, 175, 175,
                    0, 0, 0, 0, 0, 0, 175, 0, 0, 175, 0, 0, 0, 0, 0, 175, 0, 0, 175, 175, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 179, 0, 179, 179, 179, 179, 179, 0, 518, 0, 0, 0, 0, 179, 0, 0, 179, 522,
                    526, 530, 0, 0, 179, 0, 0, 179, 179, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 514, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 207,
                    0, 207, 207, 207, 207, 207, 0, 207, 0, 0, 0, 0, 207, 0, 0, 207, 207, 207, 207, 0, 0, 207, 0, 0, 207,
                    207, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 203, 0, 203, 203, 203, 203, 203, 0,
                    203, 0, 0, 0, 0, 203, 0, 0, 203, 203, 203, 203, 0, 0, 203, 0, 0, 203, 203, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 227, 0, 227, 227, 227, 227, 227, 0, 227, 0, 0, 0, 0, 227, 0, 0, 227,
                    227, 227, 227, 0, 0, 227, 0, 0, 227, 227, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 534, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 338, 342, 346, 350, 354, 0, 0, 0, 0, 0, 0, 159, 0,
                    0, 159, 0, 0, 0, 0, 0, 358, 0, 0, 159, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 270, 0, 0, 0, 0, 0, 0, 538, 294, 298, 302, 306, 0, 310, 314, 318, 322, 326, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 131, 0, 131, 131, 131, 131, 131, 0, 131, 0, 0, 0, 0, 131, 0, 0, 131, 131, 131,
                    131, 0, 0, 131, 0, 0, 131, 131, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 219, 0,
                    219, 219, 219, 219, 219, 0, 219, 0, 0, 0, 0, 219, 0, 0, 219, 219, 219, 219, 0, 0, 219, 0, 0, 219, 219,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 223, 0, 223, 223, 223, 223, 223, 0, 223,
                    0, 0, 0, 0, 223, 0, 0, 223, 223, 223, 223, 0, 0, 223, 0, 0, 223, 223, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 235, 0, 235, 235, 235, 235, 235, 0, 235, 0, 0, 0, 0, 235, 0, 0, 235, 235,
                    235, 235, 0, 0, 235, 0, 0, 235, 235, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 239,
                    0, 239, 239, 239, 239, 239, 0, 239, 0, 0, 0, 0, 239, 0, 0, 239, 239, 239, 239, 0, 0, 239, 0, 0, 239,
                    239, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 231, 0, 231, 231, 231, 231, 231, 0,
                    231, 0, 0, 0, 0, 231, 0, 0, 231, 231, 231, 231, 0, 0, 231, 0, 0, 231, 231, 251, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 606, 0, 610, 614, 618, 622, 626, 0, 0, 0, 0, 0, 0, 0, 0, 0, 375,
                    0, 0, 0, 0, 0, 630, 375, 0, 375, 634, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 542, 0, 0, 546, 550, 554, 558, 562, 566, 570, 574, 578, 0, 582, 586, 590, 594, 598, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 602, 0, 334, 0, 338, 342, 346, 350, 354, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 638, 322, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 31, 0, 31, 0, 0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 35, 0, 35, 0, 0, 35, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 43, 0, 0, 0, 0, 0, 0, 0, 0, 43,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 75, 0, 0, 75, 0, 0, 0, 0, 75, 0, 0, 0, 0, 75, 0, 0, 75, 0, 0, 0, 75, 75, 75, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 79, 0, 0, 79, 0, 0, 0, 0, 79, 0, 0, 0, 0, 79,
                    0, 0, 79, 0, 0, 0, 79, 79, 79, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    83, 0, 0, 83, 0, 0, 0, 0, 83, 0, 0, 0, 0, 83, 0, 0, 83, 0, 0, 0, 83, 83, 83, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 0, 250, 0, 0, 0, 0, 254, 0, 0, 0, 0, 323, 0,
                    0, 323, 0, 0, 0, 258, 262, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 642, 190, 194, 198, 202,
                    206, 210, 214, 218, 222, 226, 230, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 242, 0, 0, 0, 0, 0, 0, 315, 0, 0, 315, 0, 0, 0, 0, 315, 0, 0, 0, 0, 315, 0, 0, 315, 0, 0, 0, 315,
                    315, 315, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 650, 654, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 646, 0, 0, 0, 0, 0, 99, 0, 0, 99, 0, 0, 0, 0, 99, 0, 0, 0, 0, 99, 0, 0, 99, 99, 99, 99, 99, 99, 99,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 103, 0, 0, 103, 0, 0, 0, 0, 103,
                    0, 0, 0, 0, 103, 0, 0, 103, 103, 103, 103, 103, 103, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 658,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 307, 0, 0, 0, 0, 0, 0, 307, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 51, 0, 0, 0, 0, 0, 0, 51, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 319, 0, 0, 319, 0, 0, 0, 0, 319, 0, 0, 0, 0, 0, 0,
                    0, 319, 0, 0, 0, 319, 319, 319, 319, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 59, 0, 0, 59, 0, 0, 0, 0, 59, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 59, 59, 59, 59, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 63, 0, 0, 63, 0, 0, 0, 0, 63, 0, 0, 0, 0, 0, 0, 0,
                    63, 0, 0, 0, 63, 63, 63, 63, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 67,
                    0, 0, 67, 0, 0, 0, 0, 67, 0, 0, 0, 0, 0, 0, 0, 67, 0, 0, 0, 67, 67, 67, 67, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 71, 0, 0, 71, 0, 0, 0, 0, 71, 0, 0, 0, 0, 0, 0, 0, 71, 662,
                    666, 670, 71, 71, 71, 71, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 87, 0,
                    0, 87, 0, 0, 0, 0, 87, 0, 0, 0, 0, 0, 0, 0, 87, 87, 87, 87, 87, 87, 87, 87, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 91, 0, 0, 91, 0, 0, 0, 0, 91, 0, 0, 0, 0, 0, 0, 0, 91, 91,
                    91, 91, 91, 91, 91, 91, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 95, 0, 0,
                    95, 0, 0, 0, 0, 95, 0, 0, 0, 0, 0, 0, 0, 95, 95, 95, 95, 95, 95, 95, 95, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 107, 0, 0, 107, 0, 0, 0, 0, 107, 0, 0, 0, 0, 0, 0, 0, 107, 107,
                    107, 107, 107, 107, 107, 107, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 115,
                    0, 0, 115, 0, 0, 0, 0, 115, 0, 0, 0, 0, 0, 0, 0, 115, 115, 115, 115, 115, 115, 115, 115, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 123, 0, 0, 123, 0, 0, 0, 0, 123, 0, 0, 0, 0,
                    0, 0, 0, 123, 123, 123, 123, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 674, 0, 0, 0, 0, 0, 0, 47, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 474, 0, 0, 478, 0, 0, 0, 0, 482, 0, 0, 0, 0,
                    0, 0, 0, 55, 0, 0, 0, 486, 490, 494, 55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 678, 426,
                    430, 434, 438, 442, 446, 450, 454, 458, 462, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 131, 0, 0, 131, 0, 0, 0, 0, 131, 0, 0, 0, 0, 0, 0, 0, 131, 131, 131, 131,
                    131, 131, 131, 131, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 127, 0, 0,
                    127, 0, 0, 0, 0, 127, 0, 0, 0, 0, 0, 0, 0, 127, 127, 127, 127, 127, 127, 127, 127, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 682, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 474, 0,
                    0, 478, 0, 0, 0, 0, 482, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 494, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 686, 454, 458, 462, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 474, 0, 0, 478, 0, 0, 0, 0, 482, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 494, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 690,
                    454, 458, 462, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    474, 0, 0, 478, 0, 0, 0, 0, 482, 0, 0, 0, 0, 0, 0, 0, 323, 0, 0, 0, 486, 490, 494, 323, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 694, 414, 418, 422, 426, 430, 434, 438, 442, 446, 450, 454, 458, 462, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 466, 470, 0, 0, 0, 0, 0, 0, 139, 0, 0, 0, 0,
                    0, 0, 0, 0, 139, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 143, 0, 0, 698, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 338, 342, 346, 350, 354,
                    0, 0, 0, 0, 0, 0, 375, 0, 0, 375, 0, 0, 0, 0, 0, 358, 0, 0, 375, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0, 0, 0, 702, 282, 286, 290, 294, 298, 302, 306, 0, 310,
                    314, 318, 322, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 330, 0, 758, 0, 762, 766, 770, 774, 778, 0, 0, 0, 0,
                    0, 0, 375, 0, 0, 375, 0, 0, 0, 0, 0, 782, 0, 0, 0, 786, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 706, 0, 0, 0, 0, 0, 710, 714, 718, 722, 726, 730, 0, 734, 738, 742, 746, 750,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 754, 0, 195, 0, 195, 195, 195, 195, 195, 0, 0, 0, 0, 0, 0, 195, 0, 0, 195,
                    0, 0, 0, 0, 0, 195, 0, 0, 195, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 790,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 183, 0, 183, 183, 183, 183, 183, 0, 0, 0, 0, 0, 0, 183, 0, 0, 183, 0,
                    0, 0, 0, 0, 183, 0, 0, 183, 183, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 187, 0,
                    187, 187, 187, 187, 187, 0, 0, 0, 0, 0, 0, 187, 0, 0, 187, 0, 0, 0, 0, 0, 187, 0, 0, 187, 187, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 191, 0, 191, 191, 191, 191, 191, 0, 0, 0, 0, 0,
                    0, 191, 0, 0, 191, 0, 0, 0, 0, 0, 191, 0, 0, 191, 191, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 798, 0, 0, 802, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 794, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 367, 0, 367, 367, 367, 367, 367, 0, 0, 0, 0,
                    0, 0, 367, 0, 0, 367, 0, 0, 0, 0, 0, 367, 0, 0, 367, 367, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 243, 0, 243, 243, 243, 243, 243, 0, 243, 0, 0, 0, 0, 0, 0, 0, 243, 243, 243, 243, 0, 0,
                    243, 243, 0, 243, 243, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 806, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 363, 0, 0, 0, 0, 0, 0, 363, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 810, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 151, 0, 0, 0, 0, 0, 0, 151, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 147, 0, 0, 0, 0, 0, 0, 147, 0, 818, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 371, 0, 371, 371, 371, 371, 371, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 371, 0, 0, 0, 0, 0, 371, 371, 0, 371, 371, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 163, 0, 163, 163, 163, 163, 163, 0, 0, 0, 0, 0, 0, 0, 0, 0, 163, 0, 0, 0, 0, 0, 163, 163,
                    0, 163, 163, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 167, 0, 167, 167, 167, 167, 167,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 167, 0, 0, 0, 0, 0, 167, 167, 0, 167, 167, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 171, 0, 171, 171, 171, 171, 171, 0, 0, 0, 0, 0, 0, 0, 0, 0, 171, 0, 0, 0,
                    0, 0, 171, 171, 0, 171, 171, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 0, 175,
                    175, 175, 175, 175, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 0, 0, 0, 0, 0, 175, 175, 0, 175, 175, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 179, 0, 179, 179, 179, 179, 179, 0, 826, 0, 0, 0, 0,
                    0, 0, 0, 179, 830, 834, 838, 0, 0, 179, 179, 0, 179, 179, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 822, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 207, 0, 207, 207, 207, 207, 207, 0, 207, 0, 0, 0, 0, 0, 0, 0, 207, 207, 207, 207, 0,
                    0, 207, 207, 0, 207, 207, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 203, 0, 203, 203,
                    203, 203, 203, 0, 203, 0, 0, 0, 0, 0, 0, 0, 203, 203, 203, 203, 0, 0, 203, 203, 0, 203, 203, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 227, 0, 227, 227, 227, 227, 227, 0, 227, 0, 0, 0,
                    0, 0, 0, 0, 227, 227, 227, 227, 0, 0, 227, 227, 0, 227, 227, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 842,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 606, 0, 610, 614, 618, 622, 626, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 159, 0, 0, 0, 0, 0, 630, 159, 0, 159, 634, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 542, 0, 0, 0, 0, 0, 0, 846, 566, 570, 574, 578, 0, 582, 586, 590, 594, 598,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 131, 0, 131, 131, 131, 131, 131, 0, 131, 0, 0, 0, 0, 0, 0, 0, 131,
                    131, 131, 131, 0, 0, 131, 131, 0, 131, 131, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 219, 0, 219, 219, 219, 219, 219, 0, 219, 0, 0, 0, 0, 0, 0, 0, 219, 219, 219, 219, 0, 0, 219, 219,
                    0, 219, 219, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 223, 0, 223, 223, 223, 223, 223,
                    0, 223, 0, 0, 0, 0, 0, 0, 0, 223, 223, 223, 223, 0, 0, 223, 223, 0, 223, 223, 255, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 235, 0, 235, 235, 235, 235, 235, 0, 235, 0, 0, 0, 0, 0, 0, 0,
                    235, 235, 235, 235, 0, 0, 235, 235, 0, 235, 235, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 239, 0, 239, 239, 239, 239, 239, 0, 239, 0, 0, 0, 0, 0, 0, 0, 239, 239, 239, 239, 0, 0, 239, 239,
                    0, 239, 239, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 231, 0, 231, 231, 231, 231, 231,
                    0, 231, 0, 0, 0, 0, 0, 0, 0, 231, 231, 231, 231, 0, 0, 231, 231, 0, 231, 231, 251, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 606, 0, 610, 614, 618, 622, 626, 0, 0, 0, 0, 0, 0, 0, 0, 0, 375,
                    0, 0, 0, 0, 0, 630, 375, 0, 375, 634, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 542, 0, 0, 850, 550, 554, 558, 562, 566, 570, 574, 578, 0, 582, 586, 590, 594, 598, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 602, 0, 606, 0, 610, 614, 618, 622, 626, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 542, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 854, 594, 598, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 215, 0, 215,
                    215, 215, 215, 215, 0, 215, 0, 0, 0, 0, 215, 0, 0, 215, 215, 215, 215, 0, 0, 215, 0, 0, 215, 215, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 303,
                    0, 0, 303, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    922, 0, 0, 926, 0, 0, 0, 0, 930, 323, 0, 0, 0, 0, 0, 0, 323, 0, 0, 0, 934, 938, 942, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 858, 862, 866, 870, 874, 878, 882, 886, 890, 894, 898, 902, 906, 910, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 914, 918, 0, 0, 0, 0, 0, 0, 327, 0, 0, 327,
                    0, 0, 0, 0, 327, 327, 0, 0, 0, 0, 0, 0, 327, 0, 0, 0, 327, 327, 327, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 331, 0, 0, 331, 0, 0, 0, 0, 331, 331, 0, 0, 0, 0, 0, 0, 331, 0,
                    0, 0, 331, 331, 331, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 111, 0,
                    0, 111, 0, 0, 0, 0, 111, 0, 0, 0, 0, 111, 0, 0, 111, 111, 111, 111, 111, 111, 111, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 75, 0, 0, 75, 0, 0, 0, 0, 75, 0, 0, 0, 0, 0, 0,
                    0, 75, 0, 0, 0, 75, 75, 75, 75, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    79, 0, 0, 79, 0, 0, 0, 0, 79, 0, 0, 0, 0, 0, 0, 0, 79, 0, 0, 0, 79, 79, 79, 79, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 83, 0, 0, 83, 0, 0, 0, 0, 83, 0, 0, 0, 0, 0, 0, 0, 83,
                    0, 0, 0, 83, 83, 83, 83, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 474, 0,
                    0, 478, 0, 0, 0, 0, 482, 0, 0, 0, 0, 0, 0, 0, 323, 0, 0, 0, 486, 490, 494, 323, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 946, 418, 422, 426, 430, 434, 438, 442, 446, 450, 454, 458, 462, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 470, 0, 0, 0, 0, 0, 0, 315, 0, 0, 315, 0, 0, 0,
                    0, 315, 0, 0, 0, 0, 0, 0, 0, 315, 0, 0, 0, 315, 315, 315, 315, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 650, 654, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 950, 0, 0, 0, 0, 0, 99, 0, 0, 99, 0, 0, 0, 0, 99,
                    0, 0, 0, 0, 0, 0, 0, 99, 99, 99, 99, 99, 99, 99, 99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 103, 0, 0, 103, 0, 0, 0, 0, 103, 0, 0, 0, 0, 0, 0, 0, 103, 103, 103, 103, 103, 103,
                    103, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 954, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 334, 0, 338, 342, 346, 350, 354, 0, 0, 0, 0, 0, 0, 375, 0, 0, 375, 0, 0, 0, 0, 0, 358,
                    0, 0, 375, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0, 0, 0,
                    958, 282, 286, 290, 294, 298, 302, 306, 0, 310, 314, 318, 322, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 330,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 359, 0, 0, 359, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 243, 0, 243, 243, 243, 243, 243, 0, 243, 0, 0, 0, 0, 243,
                    0, 0, 243, 243, 243, 243, 0, 0, 243, 0, 0, 0, 243, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 155, 0, 0, 155, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 371, 0, 371, 371, 371, 371, 371, 0, 0, 0, 0, 0, 0,
                    371, 0, 0, 371, 0, 0, 0, 0, 0, 371, 0, 0, 0, 371, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 163, 0, 163, 163, 163, 163, 163, 0, 0, 0, 0, 0, 0, 163, 0, 0, 163, 0, 0, 0, 0, 0, 163, 0, 0,
                    0, 163, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 167, 0, 167, 167, 167, 167, 167,
                    0, 0, 0, 0, 0, 0, 167, 0, 0, 167, 0, 0, 0, 0, 0, 167, 0, 0, 0, 167, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 171, 0, 171, 171, 171, 171, 171, 0, 0, 0, 0, 0, 0, 171, 0, 0, 171, 0, 0, 0,
                    0, 0, 171, 0, 0, 0, 171, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 0, 175, 175,
                    175, 175, 175, 0, 0, 0, 0, 0, 0, 175, 0, 0, 175, 0, 0, 0, 0, 0, 175, 0, 0, 0, 175, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 179, 0, 179, 179, 179, 179, 179, 0, 966, 0, 0, 0, 0, 179, 0,
                    0, 179, 970, 974, 978, 0, 0, 179, 0, 0, 0, 179, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 962, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 207, 0, 207, 207, 207, 207, 207, 0, 207, 0, 0, 0, 0, 207, 0, 0, 207, 207, 207, 207, 0, 0, 207,
                    0, 0, 0, 207, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 203, 0, 203, 203, 203, 203,
                    203, 0, 203, 0, 0, 0, 0, 203, 0, 0, 203, 203, 203, 203, 0, 0, 203, 0, 0, 0, 203, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 227, 0, 227, 227, 227, 227, 227, 0, 227, 0, 0, 0, 0, 227, 0, 0,
                    227, 227, 227, 227, 0, 0, 227, 0, 0, 0, 227, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 982, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 758, 0, 762, 766, 770, 774, 778, 0, 0, 0, 0, 0, 0, 159,
                    0, 0, 159, 0, 0, 0, 0, 0, 782, 0, 0, 0, 786, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 706, 0, 0, 0, 0, 0, 0, 986, 718, 722, 726, 730, 0, 734, 738, 742, 746, 750, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 131, 0, 131, 131, 131, 131, 131, 0, 131, 0, 0, 0, 0, 131, 0, 0, 131, 131, 131,
                    131, 0, 0, 131, 0, 0, 0, 131, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 219, 0, 219,
                    219, 219, 219, 219, 0, 219, 0, 0, 0, 0, 219, 0, 0, 219, 219, 219, 219, 0, 0, 219, 0, 0, 0, 219, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 223, 0, 223, 223, 223, 223, 223, 0, 223, 0, 0,
                    0, 0, 223, 0, 0, 223, 223, 223, 223, 0, 0, 223, 0, 0, 0, 223, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 235, 0, 235, 235, 235, 235, 235, 0, 235, 0, 0, 0, 0, 235, 0, 0, 235, 235, 235, 235,
                    0, 0, 235, 0, 0, 0, 235, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 239, 0, 239, 239,
                    239, 239, 239, 0, 239, 0, 0, 0, 0, 239, 0, 0, 239, 239, 239, 239, 0, 0, 239, 0, 0, 0, 239, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 231, 0, 231, 231, 231, 231, 231, 0, 231, 0, 0, 0, 0,
                    231, 0, 0, 231, 231, 231, 231, 0, 0, 231, 0, 0, 0, 231, 251, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 606, 0, 610, 614, 618, 622, 626, 0, 0, 0, 0, 0, 0, 0, 0, 0, 375, 0, 0, 0, 0, 0, 630, 375,
                    0, 375, 634, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 542, 0, 0, 990,
                    550, 554, 558, 562, 566, 570, 574, 578, 0, 582, 586, 590, 594, 598, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 602,
                    0, 758, 0, 762, 766, 770, 774, 778, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 706, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 994, 746, 750, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 383, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 998, 247, 0, 247, 247, 247, 247, 247, 0, 247, 0, 0, 0, 0, 247, 0, 0, 247, 247, 247, 247, 0, 0, 247,
                    0, 0, 247, 247, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 0, 255, 255, 255, 255,
                    255, 0, 255, 0, 0, 0, 0, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 251, 0, 251, 251, 251, 251, 251, 0, 251, 0, 0, 0, 0, 251, 0,
                    0, 251, 251, 251, 251, 0, 0, 251, 0, 0, 251, 251, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 211, 0, 211, 211, 211, 211, 211, 0, 211, 0, 0, 0, 0, 211, 0, 0, 211, 211, 211, 211, 0, 0, 211,
                    0, 0, 211, 211, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1006, 0, 0, 0, 0, 0, 0, 143, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 606, 0, 610, 614, 618, 622, 626, 0, 0, 0, 0, 0, 0, 0, 0, 0, 375, 0, 0, 0, 0, 0, 630,
                    375, 0, 375, 634, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 542, 0, 0,
                    0, 1010, 554, 558, 562, 566, 570, 574, 578, 0, 582, 586, 590, 594, 598, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    602, 0, 1066, 0, 1070, 1074, 1078, 1082, 1086, 0, 0, 0, 0, 0, 0, 0, 0, 0, 375, 0, 0, 0, 0, 0, 1090, 375,
                    0, 0, 1094, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1014, 0, 0, 0, 0,
                    0, 1018, 1022, 1026, 1030, 1034, 1038, 0, 1042, 1046, 1050, 1054, 1058, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1062, 0, 195, 0, 195, 195, 195, 195, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 195, 0, 0, 0, 0, 0, 195, 195, 0,
                    195, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1098, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 183, 0, 183, 183, 183, 183, 183, 0, 0, 0, 0, 0, 0, 0, 0, 0, 183, 0, 0, 0, 0, 0, 183, 183, 0,
                    183, 183, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 187, 0, 187, 187, 187, 187, 187,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 187, 0, 0, 0, 0, 0, 187, 187, 0, 187, 187, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 191, 0, 191, 191, 191, 191, 191, 0, 0, 0, 0, 0, 0, 0, 0, 0, 191, 0, 0, 0,
                    0, 0, 191, 191, 0, 191, 191, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1106,
                    0, 0, 1110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1102, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 367, 0, 367, 367, 367, 367, 367, 0, 0, 0, 0, 0, 0, 0, 0, 0, 367, 0,
                    0, 0, 0, 0, 367, 367, 0, 367, 367, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 215, 0, 215, 215, 215, 215, 215, 0, 215, 0, 0, 0, 0, 0, 0, 0, 215,
                    215, 215, 215, 0, 0, 215, 215, 0, 215, 215, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 307, 0, 0, 0, 0, 0, 0, 307, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 51, 0, 0, 0, 0, 0, 0, 51, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 319, 0, 0, 319, 0, 0, 0, 0, 319, 319, 0, 0, 0, 0, 0, 0, 319, 0, 0, 0, 319,
                    319, 319, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 59, 0, 0, 59, 0, 0,
                    0, 0, 59, 59, 0, 0, 0, 0, 0, 0, 59, 0, 0, 0, 59, 59, 59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 63, 0, 0, 63, 0, 0, 0, 0, 63, 63, 0, 0, 0, 0, 0, 0, 63, 0, 0, 0, 63, 63, 63,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 67, 0, 0, 67, 0, 0, 0, 0, 67,
                    67, 0, 0, 0, 0, 0, 0, 67, 0, 0, 0, 67, 67, 67, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 71, 0, 0, 71, 0, 0, 0, 0, 71, 71, 0, 0, 0, 0, 0, 0, 71, 1122, 1126, 1130, 71, 71, 71,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 87, 0, 0, 87, 0, 0, 0, 0, 87,
                    87, 0, 0, 0, 0, 0, 0, 87, 87, 87, 87, 87, 87, 87, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 91, 0, 0, 91, 0, 0, 0, 0, 91, 91, 0, 0, 0, 0, 0, 0, 91, 91, 91, 91, 91, 91, 91,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 95, 0, 0, 95, 0, 0, 0, 0, 95,
                    95, 0, 0, 0, 0, 0, 0, 95, 95, 95, 95, 95, 95, 95, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 107, 0, 0, 107, 0, 0, 0, 0, 107, 107, 0, 0, 0, 0, 0, 0, 107, 107, 107, 107, 107,
                    107, 107, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 115, 0, 0, 115, 0, 0,
                    0, 0, 115, 115, 0, 0, 0, 0, 0, 0, 115, 115, 115, 115, 115, 115, 115, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 123, 0, 0, 123, 0, 0, 0, 0, 123, 123, 0, 0, 0, 0, 0, 0, 123, 123,
                    123, 123, 123, 123, 123, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 47, 0, 0, 0, 0, 0, 0, 1134, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 922, 0, 0, 926, 0, 0, 0, 0, 930, 55, 0, 0, 0, 0, 0, 0, 55, 0, 0,
                    0, 934, 938, 942, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1138, 874, 878, 882, 886, 890,
                    894, 898, 902, 906, 910, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 131, 0, 0, 131, 0, 0, 0, 0, 131, 131, 0, 0, 0, 0, 0, 0, 131, 131, 131, 131, 131, 131, 131, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 127, 0, 0, 127, 0, 0, 0, 0, 127,
                    127, 0, 0, 0, 0, 0, 0, 127, 127, 127, 127, 127, 127, 127, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1142, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 922, 0, 0, 926, 0, 0, 0, 0, 930,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 942, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1146, 902, 906, 910, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 922, 0, 0, 926, 0, 0, 0, 0, 930, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 942,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1150, 902, 906, 910, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 474, 0, 0, 478, 0, 0,
                    0, 0, 482, 0, 0, 0, 0, 0, 0, 0, 323, 0, 0, 0, 486, 490, 494, 323, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1154, 414, 418, 422, 426, 430, 434, 438, 442, 446, 450, 454, 458, 462, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 466, 470, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 303, 0, 0, 0, 0, 0, 0, 303, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 922, 0, 0, 926, 0, 0, 0, 0, 930, 323, 0, 0, 0, 0, 0, 0, 323, 0, 0, 0, 934, 938, 942, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1158, 862, 866, 870, 874, 878, 882, 886, 890, 894, 898, 902, 906, 910,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 914, 918, 0, 0, 0, 0, 0, 0, 111, 0, 0,
                    111, 0, 0, 0, 0, 111, 0, 0, 0, 0, 0, 0, 0, 111, 111, 111, 111, 111, 111, 111, 111, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 355, 0, 0,
                    355, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 195,
                    0, 195, 195, 195, 195, 195, 0, 0, 0, 0, 0, 0, 195, 0, 0, 195, 0, 0, 0, 0, 0, 195, 0, 0, 0, 195, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 183,
                    0, 183, 183, 183, 183, 183, 0, 0, 0, 0, 0, 0, 183, 0, 0, 183, 0, 0, 0, 0, 0, 183, 0, 0, 0, 183, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 187, 0, 187, 187, 187, 187, 187, 0, 0, 0, 0, 0,
                    0, 187, 0, 0, 187, 0, 0, 0, 0, 0, 187, 0, 0, 0, 187, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 191, 0, 191, 191, 191, 191, 191, 0, 0, 0, 0, 0, 0, 191, 0, 0, 191, 0, 0, 0, 0, 0, 191, 0,
                    0, 0, 191, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1170, 0, 0, 1174, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1166, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 367, 0, 367, 367, 367, 367, 367, 0, 0, 0, 0, 0, 0, 367, 0, 0, 367, 0, 0, 0, 0, 0, 367,
                    0, 0, 0, 367, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 215, 0, 215, 215, 215, 215, 215, 0, 215, 0, 0, 0, 0, 215, 0, 0, 215, 215, 215, 215, 0,
                    0, 215, 0, 0, 0, 215, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 606, 0, 610, 614, 618, 622, 626, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 375, 0, 0, 0, 0, 0, 630, 375, 0, 375, 634, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 542, 0, 0, 0, 1190, 554, 558, 562, 566, 570, 574, 578, 0, 582, 586,
                    590, 594, 598, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 602, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    359, 0, 0, 0, 0, 0, 0, 359, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 243,
                    0, 243, 243, 243, 243, 243, 0, 243, 0, 0, 0, 0, 0, 0, 0, 243, 243, 243, 243, 0, 0, 243, 243, 0, 0, 243,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 155, 0, 0, 0, 0, 0, 0, 155, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    371, 0, 371, 371, 371, 371, 371, 0, 0, 0, 0, 0, 0, 0, 0, 0, 371, 0, 0, 0, 0, 0, 371, 371, 0, 0, 371,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 163, 0, 163, 163, 163, 163, 163, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 163, 0, 0, 0, 0, 0, 163, 163, 0, 0, 163, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 167, 0, 167, 167, 167, 167, 167, 0, 0, 0, 0, 0, 0, 0, 0, 0, 167, 0, 0, 0, 0, 0, 167,
                    167, 0, 0, 167, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 171, 0, 171, 171, 171, 171,
                    171, 0, 0, 0, 0, 0, 0, 0, 0, 0, 171, 0, 0, 0, 0, 0, 171, 171, 0, 0, 171, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 0, 175, 175, 175, 175, 175, 0, 0, 0, 0, 0, 0, 0, 0, 0, 175, 0, 0,
                    0, 0, 0, 175, 175, 0, 0, 175, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 179, 0, 179,
                    179, 179, 179, 179, 0, 1198, 0, 0, 0, 0, 0, 0, 0, 179, 1202, 1206, 1210, 0, 0, 179, 179, 0, 0, 179, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 1194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 207, 0, 207, 207, 207, 207, 207, 0, 207,
                    0, 0, 0, 0, 0, 0, 0, 207, 207, 207, 207, 0, 0, 207, 207, 0, 0, 207, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 203, 0, 203, 203, 203, 203, 203, 0, 203, 0, 0, 0, 0, 0, 0, 0, 203, 203, 203,
                    203, 0, 0, 203, 203, 0, 0, 203, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 227, 0,
                    227, 227, 227, 227, 227, 0, 227, 0, 0, 0, 0, 0, 0, 0, 227, 227, 227, 227, 0, 0, 227, 227, 0, 0, 227,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1066, 0, 1070, 1074, 1078, 1082, 1086, 0, 0, 0, 0, 0, 0, 0, 0, 0, 159, 0, 0, 0, 0, 0, 1090, 159, 0, 0,
                    1094, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1014, 0, 0, 0, 0, 0, 0,
                    1218, 1026, 1030, 1034, 1038, 0, 1042, 1046, 1050, 1054, 1058, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 131,
                    0, 131, 131, 131, 131, 131, 0, 131, 0, 0, 0, 0, 0, 0, 0, 131, 131, 131, 131, 0, 0, 131, 131, 0, 0, 131,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 219, 0, 219, 219, 219, 219, 219, 0, 219,
                    0, 0, 0, 0, 0, 0, 0, 219, 219, 219, 219, 0, 0, 219, 219, 0, 0, 219, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 223, 0, 223, 223, 223, 223, 223, 0, 223, 0, 0, 0, 0, 0, 0, 0, 223, 223, 223,
                    223, 0, 0, 223, 223, 0, 0, 223, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 235, 0,
                    235, 235, 235, 235, 235, 0, 235, 0, 0, 0, 0, 0, 0, 0, 235, 235, 235, 235, 0, 0, 235, 235, 0, 0, 235,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 239, 0, 239, 239, 239, 239, 239, 0, 239,
                    0, 0, 0, 0, 0, 0, 0, 239, 239, 239, 239, 0, 0, 239, 239, 0, 0, 239, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 231, 0, 231, 231, 231, 231, 231, 0, 231, 0, 0, 0, 0, 0, 0, 0, 231, 231, 231,
                    231, 0, 0, 231, 231, 0, 0, 231, 251, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 606, 0,
                    610, 614, 618, 622, 626, 0, 0, 0, 0, 0, 0, 0, 0, 0, 375, 0, 0, 0, 0, 0, 630, 375, 0, 375, 634, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 542, 0, 0, 1222, 550, 554, 558, 562,
                    566, 570, 574, 578, 0, 582, 586, 590, 594, 598, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 602, 0, 1066, 0, 1070,
                    1074, 1078, 1082, 1086, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1014, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1226, 1054, 1058, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 383, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1230,
                    247, 0, 247, 247, 247, 247, 247, 0, 247, 0, 0, 0, 0, 0, 0, 0, 247, 247, 247, 247, 0, 0, 247, 247, 0,
                    247, 247, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 0, 255, 255, 255, 255, 255,
                    0, 255, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 251, 0, 251, 251, 251, 251, 251, 0, 251, 0, 0, 0, 0, 0, 0, 0, 251,
                    251, 251, 251, 0, 0, 251, 251, 0, 251, 251, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 211, 0, 211, 211, 211, 211, 211, 0, 211, 0, 0, 0, 0, 0, 0, 0, 211, 211, 211, 211, 0, 0, 211, 211,
                    0, 211, 211, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 119, 0, 0, 119, 0, 0, 0, 0, 119,
                    0, 0, 0, 0, 119, 0, 0, 119, 119, 119, 119, 119, 119, 119, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 75, 0, 0, 75, 0, 0, 0, 0, 75, 75, 0, 0, 0, 0, 0, 0, 75, 0, 0, 0, 75, 75, 75,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 79, 0, 0, 79, 0, 0, 0, 0, 79,
                    79, 0, 0, 0, 0, 0, 0, 79, 0, 0, 0, 79, 79, 79, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 83, 0, 0, 83, 0, 0, 0, 0, 83, 83, 0, 0, 0, 0, 0, 0, 83, 0, 0, 0, 83, 83, 83, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 922, 0, 0, 926, 0, 0, 0, 0, 930, 323,
                    0, 0, 0, 0, 0, 0, 323, 0, 0, 0, 934, 938, 942, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1234,
                    866, 870, 874, 878, 882, 886, 890, 894, 898, 902, 906, 910, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 918, 0, 0, 0, 0, 0, 0, 315, 0, 0, 315, 0, 0, 0, 0, 315, 315, 0, 0, 0, 0, 0, 0,
                    315, 0, 0, 0, 315, 315, 315, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 650, 654, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1238, 0, 0, 0, 0, 0, 99, 0, 0, 99, 0, 0, 0, 0, 99, 99, 0, 0, 0, 0, 0, 0, 99,
                    99, 99, 99, 99, 99, 99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 103,
                    0, 0, 103, 0, 0, 0, 0, 103, 103, 0, 0, 0, 0, 0, 0, 103, 103, 103, 103, 103, 103, 103, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 383, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1250, 247, 0, 247, 247,
                    247, 247, 247, 0, 247, 0, 0, 0, 0, 247, 0, 0, 247, 247, 247, 247, 0, 0, 247, 0, 0, 0, 247, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 0, 255, 255, 255, 255, 255, 0, 255, 0, 0, 0, 0,
                    255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 0, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 251, 0, 251, 251, 251, 251, 251, 0, 251, 0, 0, 0, 0, 251, 0, 0, 251, 251, 251, 251, 0,
                    0, 251, 0, 0, 0, 251, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 211, 0, 211, 211, 211,
                    211, 211, 0, 211, 0, 0, 0, 0, 211, 0, 0, 211, 211, 211, 211, 0, 0, 211, 0, 0, 0, 211, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 199, 0, 199, 199, 199, 199, 199, 0, 0, 0, 0, 0, 0, 199,
                    0, 0, 199, 0, 0, 0, 0, 0, 199, 0, 0, 199, 199, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 379, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 355,
                    0, 0, 0, 0, 0, 0, 355, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 195, 0,
                    195, 195, 195, 195, 195, 0, 0, 0, 0, 0, 0, 0, 0, 0, 195, 0, 0, 0, 0, 0, 195, 195, 0, 0, 195, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 183, 0,
                    183, 183, 183, 183, 183, 0, 0, 0, 0, 0, 0, 0, 0, 0, 183, 0, 0, 0, 0, 0, 183, 183, 0, 0, 183, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 187, 0, 187, 187, 187, 187, 187, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 187, 0, 0, 0, 0, 0, 187, 187, 0, 0, 187, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 191, 0, 191, 191, 191, 191, 191, 0, 0, 0, 0, 0, 0, 0, 0, 0, 191, 0, 0, 0, 0, 0, 191, 191, 0,
                    0, 191, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1262, 0, 0, 1266, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1258, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 367, 0, 367, 367, 367, 367, 367, 0, 0, 0, 0, 0, 0, 0, 0, 0, 367, 0, 0, 0, 0, 0, 367, 367,
                    0, 0, 367, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 215, 0, 215, 215, 215, 215, 215, 0, 215, 0, 0, 0, 0, 0, 0, 0, 215, 215, 215, 215, 0, 0, 215,
                    215, 0, 0, 215, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1274, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 303, 0, 0, 0, 0, 0, 0, 303, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 922, 0, 0, 926, 0, 0, 0, 0, 930, 323, 0, 0,
                    0, 0, 0, 0, 323, 0, 0, 0, 934, 938, 942, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1278, 862, 866,
                    870, 874, 878, 882, 886, 890, 894, 898, 902, 906, 910, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 914, 918, 0, 0, 0, 0, 0, 0, 111, 0, 0, 111, 0, 0, 0, 0, 111, 111, 0, 0, 0, 0, 0, 0, 111,
                    111, 111, 111, 111, 111, 111, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    119, 0, 0, 119, 0, 0, 0, 0, 119, 0, 0, 0, 0, 0, 0, 0, 119, 119, 119, 119, 119, 119, 119, 119, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1282, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 383, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1002, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1286, 247, 0, 247, 247, 247, 247, 247, 0, 247, 0, 0, 0, 0,
                    0, 0, 0, 247, 247, 247, 247, 0, 0, 247, 247, 0, 0, 247, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 255, 0, 255, 255, 255, 255, 255, 0, 255, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0,
                    255, 255, 0, 0, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 251, 0, 251, 251, 251,
                    251, 251, 0, 251, 0, 0, 0, 0, 0, 0, 0, 251, 251, 251, 251, 0, 0, 251, 251, 0, 0, 251, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 211, 0, 211, 211, 211, 211, 211, 0, 211, 0, 0, 0, 0, 0,
                    0, 0, 211, 211, 211, 211, 0, 0, 211, 211, 0, 0, 211, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 199, 0, 199, 199, 199, 199, 199, 0, 0, 0, 0, 0, 0, 0, 0, 0, 199, 0, 0, 0, 0, 0, 199, 199,
                    0, 199, 199, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1290,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 199, 0, 199, 199, 199, 199, 199, 0, 0, 0, 0, 0, 0, 199, 0, 0, 199, 0, 0, 0, 0, 0, 199, 0, 0,
                    0, 199, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1294,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 119, 0, 0, 119, 0, 0, 0, 0, 119, 119, 0, 0, 0, 0, 0, 0, 119, 119, 119, 119, 119, 119, 119, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 199, 0, 199, 199, 199, 199, 199,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 199, 0, 0, 0, 0, 0, 199, 199, 0, 0, 199, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0,
                };
                
                return U16ParseTable.From(u16Table, 324, 31, 81);
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
            public static readonly TerminalSymbol __T5 = new TerminalSymbol(11, "__T5", true, "Start");
            public static readonly TerminalSymbol __T6 = new TerminalSymbol(12, "__T6", false, "=");
            public static readonly TerminalSymbol __T7 = new TerminalSymbol(13, "__T7", false, ";");
            public static readonly TerminalSymbol __T8 = new TerminalSymbol(14, "__T8", true, "Spacing");
            public static readonly TerminalSymbol __T9 = new TerminalSymbol(15, "__T9", false, "rules");
            public static readonly TerminalSymbol __T10 = new TerminalSymbol(16, "__T10", true, "|");
            public static readonly TerminalSymbol __T11 = new TerminalSymbol(17, "__T11", true, "?");
            public static readonly TerminalSymbol __T12 = new TerminalSymbol(18, "__T12", true, "*");
            public static readonly TerminalSymbol __T13 = new TerminalSymbol(19, "__T13", true, "+");
            public static readonly TerminalSymbol __T14 = new TerminalSymbol(20, "__T14", false, ",");
            public static readonly TerminalSymbol __T15 = new TerminalSymbol(21, "__T15", false, "^");
            public static readonly TerminalSymbol __T16 = new TerminalSymbol(22, "__T16", false, "(");
            public static readonly TerminalSymbol __T17 = new TerminalSymbol(23, "__T17", false, ")");
            public static readonly TerminalSymbol __T18 = new TerminalSymbol(24, "__T18", false, "terminals");
            public static readonly TerminalSymbol __T19 = new TerminalSymbol(25, "__T19", false, "-");
            public static readonly TerminalSymbol __T20 = new TerminalSymbol(26, "__T20", false, "~");
            public static readonly TerminalSymbol __T21 = new TerminalSymbol(27, "__T21", false, "..");
            public static readonly TerminalSymbol __T22 = new TerminalSymbol(28, "__T22", true, ":");
            public static readonly TerminalSymbol __T23 = new TerminalSymbol(29, "__T23", true, "->");
            public static readonly TerminalSymbol __eof = new TerminalSymbol(30, "__eof", false, "$eof$");
            public static readonly NonterminalSymbol file = new NonterminalSymbol(31, "file", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar = new NonterminalSymbol(32, "grammar", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_item = new NonterminalSymbol(33, "grammar_item", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_options = new NonterminalSymbol(34, "grammar_options", false, RepeatKind.None);
            public static readonly NonterminalSymbol option = new NonterminalSymbol(35, "option", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_rules = new NonterminalSymbol(36, "grammar_rules", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule = new NonterminalSymbol(37, "rule", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_expression = new NonterminalSymbol(38, "rule_expression", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_alternative = new NonterminalSymbol(39, "rule_alternative", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_sequence = new NonterminalSymbol(40, "rule_sequence", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_repetition = new NonterminalSymbol(41, "rule_repetition", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_option = new NonterminalSymbol(42, "rule_option", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_star = new NonterminalSymbol(43, "rule_star", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_plus = new NonterminalSymbol(44, "rule_plus", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_tree_action = new NonterminalSymbol(45, "rule_tree_action", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_drop_element = new NonterminalSymbol(46, "rule_drop_element", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_promote_element = new NonterminalSymbol(47, "rule_promote_element", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_element = new NonterminalSymbol(48, "rule_element", false, RepeatKind.None);
            public static readonly NonterminalSymbol sub_rule = new NonterminalSymbol(49, "sub_rule", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_atom = new NonterminalSymbol(50, "rule_atom", false, RepeatKind.None);
            public static readonly NonterminalSymbol reference = new NonterminalSymbol(51, "reference", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_terminals = new NonterminalSymbol(52, "grammar_terminals", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_rule = new NonterminalSymbol(53, "terminal_rule", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_expression = new NonterminalSymbol(54, "terminal_expression", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_alternative = new NonterminalSymbol(55, "terminal_alternative", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_diff = new NonterminalSymbol(56, "terminal_diff", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_sequence = new NonterminalSymbol(57, "terminal_sequence", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_repetition = new NonterminalSymbol(58, "terminal_repetition", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_option = new NonterminalSymbol(59, "terminal_option", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_star = new NonterminalSymbol(60, "terminal_star", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_plus = new NonterminalSymbol(61, "terminal_plus", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_range_loop = new NonterminalSymbol(62, "terminal_range_loop", false, RepeatKind.None);
            public static readonly NonterminalSymbol range = new NonterminalSymbol(63, "range", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_element = new NonterminalSymbol(64, "terminal_element", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_not = new NonterminalSymbol(65, "terminal_not", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_atom = new NonterminalSymbol(66, "terminal_atom", false, RepeatKind.None);
            public static readonly NonterminalSymbol characterRange = new NonterminalSymbol(67, "characterRange", false, RepeatKind.None);
            public static readonly NonterminalSymbol character = new NonterminalSymbol(68, "character", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(69, "__N1", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(70, "__N2", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N3 = new NonterminalSymbol(71, "__N3", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N4 = new NonterminalSymbol(72, "__N4", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N5 = new NonterminalSymbol(73, "__N5", false, RepeatKind.StarList);
            public static readonly NonterminalSymbol __N6 = new NonterminalSymbol(74, "__N6", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N7 = new NonterminalSymbol(75, "__N7", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N8 = new NonterminalSymbol(76, "__N8", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N9 = new NonterminalSymbol(77, "__N9", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N10 = new NonterminalSymbol(78, "__N10", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N11 = new NonterminalSymbol(79, "__N11", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N12 = new NonterminalSymbol(80, "__N12", false, RepeatKind.Optional);
            public static readonly TerminalSymbol newline = new TerminalSymbol(81, "newline", false, "");
            public static readonly TerminalSymbol newlineChar = new TerminalSymbol(82, "newlineChar", false, "");
            public static readonly TerminalSymbol whitespace = new TerminalSymbol(83, "whitespace", false, "");
            public static readonly TerminalSymbol lineComment = new TerminalSymbol(84, "lineComment", false, "");
            public static readonly TerminalSymbol blockComment = new TerminalSymbol(85, "blockComment", false, "");
            public static readonly TerminalSymbol spacing = new TerminalSymbol(86, "spacing", false, "");
            public static readonly TerminalSymbol identifierStart = new TerminalSymbol(87, "identifierStart", false, "");
            public static readonly TerminalSymbol identifierContinue = new TerminalSymbol(88, "identifierContinue", false, "");
            public static readonly TerminalSymbol digit = new TerminalSymbol(89, "digit", false, "");
            public static readonly TerminalSymbol nonzeroDigit = new TerminalSymbol(90, "nonzeroDigit", false, "");
            public static readonly TerminalSymbol zero = new TerminalSymbol(91, "zero", false, "");
            public static readonly TerminalSymbol hexDigit = new TerminalSymbol(92, "hexDigit", false, "");
            public static readonly TerminalSymbol escapes = new TerminalSymbol(93, "escapes", false, "");
            public static readonly TerminalSymbol ucNameStart = new TerminalSymbol(94, "ucNameStart", false, "");
            public static readonly TerminalSymbol ucNameInner = new TerminalSymbol(95, "ucNameInner", false, "");
            public static readonly TerminalSymbol ucNameEnd = new TerminalSymbol(96, "ucNameEnd", false, "");
            public static readonly TerminalSymbol ucName = new TerminalSymbol(97, "ucName", false, "");
            public static readonly NonterminalSymbol __acc = new NonterminalSymbol(98, "__acc", true, RepeatKind.None);
            
            public static readonly Symbol[] Symbols = 
            {
                identifier, number, any, text, ucBlock, ucCategory, ucCodepoint, __T1, __T2, __T3, __T4, __T5, __T6, __T7,
                __T8, __T9, __T10, __T11, __T12, __T13, __T14, __T15, __T16, __T17, __T18, __T19, __T20, __T21, __T22, __T23,
                __eof, file, grammar, grammar_item, grammar_options, option, grammar_rules, rule, rule_expression, rule_alternative,
                rule_sequence, rule_repetition, rule_option, rule_star, rule_plus, rule_tree_action, rule_drop_element, rule_promote_element,
                rule_element, sub_rule, rule_atom, reference, grammar_terminals, terminal_rule, terminal_expression, terminal_alternative,
                terminal_diff, terminal_sequence, terminal_repetition, terminal_option, terminal_star, terminal_plus, terminal_range_loop,
                range, terminal_element, terminal_not, terminal_atom, characterRange, character, __N1, __N2, __N3, __N4,
                __N5, __N6, __N7, __N8, __N9, __N10, __N11, __N12, newline, newlineChar, whitespace, lineComment, blockComment,
                spacing, identifierStart, identifierContinue, digit, nonzeroDigit, zero, hexDigit, escapes, ucNameStart,
                ucNameInner, ucNameEnd, ucName, __acc,
            };
            
            public static readonly Production[] Productions = 
            {
                new Production(__acc, false, "__acc -> ^file", false),
                new Production(file, false, "file -> ^grammar", false),
                new Production(grammar, false, "grammar -> ,'grammar' ^ˈidentifierˈ ,'{' ^__N1 ,'}'", true, false, true, false, true),
                new Production(grammar_item, true, "grammar_item -> ^grammar_options", false),
                new Production(grammar_item, true, "grammar_item -> ^grammar_rules", false),
                new Production(grammar_item, true, "grammar_item -> ^grammar_terminals", false),
                new Production(grammar_options, false, "grammar_options -> ,'options' ,'{' ^__N2 ,'}'", true, true, false, true),
                new Production(option, false, "option -> ^'Start' ,'=' ^ˈidentifierˈ ,';'", false, true, false, true),
                new Production(option, false, "option -> ^'Spacing' ,'=' ^ˈidentifierˈ ,';'", false, true, false, true),
                new Production(grammar_rules, false, "grammar_rules -> ,'rules' ,'{' ^__N3 ,'}'", true, true, false, true),
                new Production(rule, false, "rule -> ^ˈidentifierˈ ,__N4 ^rule_expression ,';'", false, true, false, true),
                new Production(rule_expression, false, "rule_expression -> ^__N5", false),
                new Production(rule_alternative, true, "rule_alternative -> ^rule_sequence", false),
                new Production(rule_sequence, false, "rule_sequence -> ^__N6", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_option", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_star", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_plus", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_tree_action", false),
                new Production(rule_option, false, "rule_option -> ^rule_tree_action ,'?'", false, true),
                new Production(rule_star, false, "rule_star -> ^rule_tree_action ,'*'", false, true),
                new Production(rule_plus, false, "rule_plus -> ^rule_tree_action ,'+'", false, true),
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
                new Production(reference, true, "reference -> ^ˈidentifierˈ", false),
                new Production(grammar_terminals, false, "grammar_terminals -> ,'terminals' ,'{' ^__N8 ,'}'", true, true, false, true),
                new Production(terminal_rule, false, "terminal_rule -> ^ˈidentifierˈ ,__N9 ^terminal_expression ,';'", false, true, false, true),
                new Production(terminal_expression, false, "terminal_expression -> ^terminal_alternative ^__N10", false, false),
                new Production(terminal_alternative, true, "terminal_alternative -> ^terminal_sequence", false),
                new Production(terminal_alternative, true, "terminal_alternative -> ^terminal_diff", false),
                new Production(terminal_diff, false, "terminal_diff -> ^terminal_sequence ,'-' ^terminal_sequence", false, true, false),
                new Production(terminal_sequence, false, "terminal_sequence -> ^__N11", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_option", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_star", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_plus", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_range_loop", false),
                new Production(terminal_repetition, true, "terminal_repetition -> ^terminal_element", false),
                new Production(terminal_option, false, "terminal_option -> ^terminal_element ^'?'", false, false),
                new Production(terminal_star, false, "terminal_star -> ^terminal_element ^'*'", false, false),
                new Production(terminal_plus, false, "terminal_plus -> ^terminal_element ^'+'", false, false),
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
                new Production(__N5, false, "__N5 -> ^__N5 ^'|' ^rule_alternative", false, false, false),
                new Production(__N5, false, "__N5 -> ^rule_alternative", false),
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
