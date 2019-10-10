namespace Lingu.CC
{
    using System;
    using System.Linq;
    using Lingu.Runtime.Commons;
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
                byte[] compressedTable = 
                {
                    205, 93, 15, 132, 100, 71, 26, 175, 170, 247, 183, 195, 133, 11, 23, 46, 92, 200, 113, 225, 142, 59,
                    46, 220, 146, 229, 150, 91, 110, 184, 37, 75, 150, 11, 23, 46, 92, 184, 112, 225, 194, 133, 132, 11,
                    9, 189, 204, 210, 161, 195, 132, 9, 19, 102, 153, 48, 203, 44, 19, 102, 153, 99, 150, 89, 58, 76, 152,
                    48, 97, 194, 132, 9, 19, 38, 76, 152, 208, 97, 66, 47, 179, 204, 186, 250, 247, 85, 189, 234, 126, 221,
                    253, 94, 213, 247, 118, 243, 171, 127, 95, 125, 245, 222, 215, 239, 85, 191, 215, 253, 234, 247, 125,
                    61, 67, 136, 196, 79, 84, 51, 130, 164, 53, 102, 192, 19, 17, 174, 57, 66, 210, 250, 187, 252, 20, 251,
                    24, 0, 63, 67, 183, 248, 46, 251, 173, 104, 126, 15, 253, 63, 128, 240, 243, 95, 144, 167, 134, 182,
                    253, 213, 240, 206, 191, 46, 179, 120, 141, 93, 99, 170, 181, 154, 192, 131, 36, 228, 209, 71, 101, 109,
                    186, 193, 6, 31, 123, 76, 214, 166, 27, 108, 240, 241, 199, 101, 109, 186, 193, 6, 255, 56, 230, 141,
                    121, 182, 194, 27, 83, 134, 63, 5, 31, 209, 16, 254, 140, 109, 240, 47, 216, 6, 201, 85, 118, 85, 94,
                    123, 170, 118, 37, 92, 60, 18, 176, 239, 7, 140, 252, 149, 144, 191, 149, 13, 61, 55, 125, 239, 231,
                    173, 248, 79, 16, 62, 154, 116, 150, 127, 159, 106, 242, 31, 70, 250, 15, 8, 95, 214, 153, 183, 127,
                    149, 171, 255, 237, 244, 222, 103, 34, 203, 130, 134, 255, 142, 157, 200, 55, 188, 109, 190, 237, 189,
                    231, 24, 180, 41, 134, 149, 235, 102, 222, 172, 20, 8, 115, 249, 116, 38, 29, 225, 44, 202, 225, 115,
                    204, 209, 249, 26, 166, 186, 102, 219, 47, 204, 249, 90, 41, 16, 230, 50, 95, 172, 115, 114, 11, 190,
                    51, 177, 76, 87, 234, 238, 186, 228, 236, 240, 30, 19, 89, 22, 52, 60, 241, 132, 172, 77, 215, 215, 206,
                    42, 214, 245, 97, 176, 134, 110, 241, 67, 51, 113, 86, 194, 194, 211, 79, 203, 218, 116, 125, 237, 12,
                    248, 89, 159, 202, 51, 63, 147, 245, 39, 252, 72, 69, 33, 109, 54, 203, 58, 195, 135, 189, 78, 55, 232,
                    38, 237, 209, 45, 186, 77, 119, 232, 46, 221, 163, 251, 244, 128, 30, 210, 35, 122, 92, 62, 123, 125,
                    122, 162, 7, 110, 112, 91, 162, 20, 107, 41, 221, 96, 34, 249, 30, 63, 33, 55, 249, 190, 162, 20, 107,
                    41, 221, 100, 34, 249, 27, 254, 220, 236, 107, 37, 44, 92, 163, 215, 228, 188, 168, 218, 149, 234, 98,
                    135, 145, 93, 182, 199, 246, 217, 1, 59, 212, 7, 122, 151, 183, 162, 112, 28, 73, 241, 120, 236, 25,
                    116, 249, 200, 28, 155, 103, 11, 108, 145, 45, 177, 101, 182, 194, 86, 217, 26, 35, 235, 108, 131, 109,
                    178, 30, 219, 42, 236, 184, 205, 200, 87, 34, 67, 82, 90, 209, 106, 89, 137, 48, 80, 23, 95, 51, 158,
                    33, 25, 149, 44, 70, 132, 129, 32, 244, 209, 223, 206, 19, 116, 139, 3, 116, 139, 183, 184, 69, 81, 16,
                    241, 140, 204, 97, 184, 195, 15, 73, 148, 98, 45, 165, 59, 76, 36, 127, 195, 231, 101, 182, 149, 104,
                    207, 159, 151, 61, 63, 92, 144, 217, 86, 162, 189, 112, 65, 246, 252, 112, 81, 102, 91, 137, 246, 226,
                    69, 217, 243, 195, 140, 204, 182, 154, 57, 101, 103, 172, 29, 205, 204, 72, 133, 31, 94, 144, 217, 86,
                    47, 40, 248, 27, 124, 81, 102, 91, 189, 168, 224, 111, 240, 37, 153, 109, 245, 146, 130, 191, 193, 87,
                    101, 182, 213, 171, 10, 254, 6, 95, 151, 217, 86, 175, 43, 248, 27, 124, 75, 102, 91, 189, 165, 224,
                    111, 208, 193, 239, 248, 227, 119, 48, 193, 53, 252, 96, 113, 78, 230, 242, 199, 10, 142, 78, 84, 249,
                    153, 2, 112, 149, 15, 139, 82, 172, 175, 210, 98, 242, 63, 250, 119, 100, 182, 213, 59, 10, 254, 6, 187,
                    232, 140, 225, 240, 4, 27, 148, 77, 175, 198, 92, 84, 97, 94, 125, 12, 207, 87, 49, 188, 207, 231, 224,
                    64, 206, 195, 33, 204, 134, 124, 212, 60, 138, 142, 163, 126, 36, 197, 2, 22, 162, 197, 104, 41, 90,
                    142, 86, 162, 213, 104, 45, 90, 143, 54, 162, 205, 168, 23, 109, 69, 219, 209, 78, 249, 92, 238, 70,
                    123, 122, 224, 7, 202, 51, 36, 209, 83, 58, 163, 180, 189, 137, 199, 91, 13, 39, 232, 239, 236, 119,
                    124, 38, 68, 9, 192, 96, 248, 160, 62, 224, 167, 42, 10, 34, 222, 231, 230, 68, 81, 56, 243, 157, 134,
                    31, 24, 207, 144, 140, 74, 22, 35, 194, 64, 93, 124, 68, 121, 134, 100, 84, 178, 24, 17, 6, 234, 226,
                    6, 229, 25, 146, 81, 201, 98, 68, 24, 168, 139, 155, 148, 103, 72, 70, 37, 139, 17, 97, 160, 46, 62,
                    166, 60, 67, 50, 42, 89, 140, 8, 3, 117, 113, 139, 242, 12, 137, 204, 198, 90, 199, 75, 39, 238, 198,
                    115, 49, 244, 68, 61, 29, 109, 185, 191, 131, 207, 41, 207, 144, 68, 79, 233, 140, 210, 246, 252, 78,
                    224, 51, 202, 51, 36, 209, 83, 58, 163, 180, 61, 63, 251, 223, 80, 158, 33, 137, 158, 210, 25, 165, 237,
                    249, 217, 159, 128, 249, 209, 217, 244, 92, 93, 94, 231, 7, 39, 138, 94, 93, 94, 167, 147, 87, 151, 2,
                    11, 241, 196, 149, 165, 252, 242, 46, 124, 111, 143, 126, 161, 219, 158, 215, 89, 144, 175, 40, 207,
                    144, 68, 79, 233, 140, 210, 246, 252, 236, 127, 77, 121, 134, 36, 122, 74, 103, 148, 182, 119, 223, 239,
                    21, 190, 163, 60, 67, 18, 61, 165, 51, 74, 219, 243, 59, 129, 239, 41, 207, 144, 68, 79, 233, 140, 210,
                    246, 252, 236, 127, 75, 121, 134, 36, 122, 74, 103, 148, 182, 119, 207, 239, 21, 14, 98, 114, 24, 31,
                    197, 199, 113, 63, 62, 177, 151, 186, 102, 65, 6, 49, 23, 238, 178, 211, 177, 247, 192, 34, 31, 89, 138,
                    151, 227, 149, 120, 53, 94, 139, 215, 227, 141, 120, 51, 238, 197, 100, 43, 222, 142, 119, 226, 221,
                    120, 175, 176, 227, 126, 92, 118, 83, 84, 3, 220, 15, 128, 179, 120, 248, 70, 48, 120, 146, 39, 145,
                    209, 240, 75, 158, 68, 14, 197, 111, 70, 132, 64, 92, 146, 217, 86, 162, 189, 116, 73, 246, 252, 112,
                    89, 102, 91, 137, 246, 242, 101, 217, 243, 195, 21, 153, 109, 37, 218, 43, 87, 100, 239, 65, 208, 174,
                    164, 157, 212, 98, 93, 9, 144, 174, 183, 185, 37, 81, 138, 181, 148, 110, 51, 145, 252, 143, 127, 18,
                    58, 73, 55, 169, 181, 195, 172, 218, 252, 101, 153, 109, 245, 178, 130, 255, 129, 188, 34, 179, 173,
                    94, 81, 240, 55, 56, 6, 115, 245, 78, 119, 18, 128, 160, 67, 36, 234, 52, 67, 247, 12, 26, 67, 71, 28,
                    130, 46, 128, 162, 115, 24, 58, 98, 24, 186, 243, 56, 12, 29, 49, 12, 221, 5, 28, 134, 142, 24, 134,
                    238, 34, 14, 67, 39, 218, 249, 100, 33, 89, 76, 102, 66, 40, 58, 135, 161, 19, 109, 40, 69, 231, 48,
                    116, 162, 13, 165, 232, 28, 134, 78, 180, 161, 20, 157, 195, 208, 137, 54, 148, 162, 115, 24, 58, 209,
                    134, 82, 116, 14, 67, 39, 90, 92, 138, 142, 63, 172, 36, 134, 172, 243, 68, 9, 29, 115, 206, 176, 49,
                    66, 114, 177, 156, 84, 102, 98, 198, 49, 116, 82, 64, 162, 232, 28, 134, 78, 180, 161, 20, 221, 10, 222,
                    167, 248, 248, 9, 86, 232, 143, 159, 182, 213, 164, 194, 188, 250, 24, 94, 243, 52, 60, 129, 161, 91,
                    79, 188, 25, 186, 119, 205, 27, 111, 37, 76, 188, 199, 173, 110, 4, 191, 161, 225, 158, 85, 178, 153,
                    84, 115, 172, 14, 18, 114, 154, 156, 37, 237, 116, 54, 237, 164, 35, 47, 213, 21, 170, 185, 177, 49,
                    162, 61, 117, 166, 91, 201, 118, 178, 147, 236, 38, 123, 201, 126, 66, 14, 146, 195, 228, 40, 57, 78,
                    250, 133, 89, 56, 73, 200, 39, 148, 103, 72, 74, 43, 90, 45, 43, 17, 6, 106, 99, 222, 35, 138, 117, 34,
                    254, 71, 121, 134, 100, 84, 178, 24, 17, 6, 234, 226, 54, 229, 25, 146, 81, 201, 98, 68, 24, 168, 139,
                    59, 148, 103, 72, 70, 37, 139, 17, 97, 192, 3, 139, 124, 158, 151, 194, 230, 122, 193, 217, 253, 123,
                    198, 51, 36, 163, 146, 197, 136, 48, 80, 23, 101, 100, 60, 113, 185, 120, 189, 137, 239, 185, 148, 98,
                    25, 239, 90, 4, 46, 222, 151, 147, 95, 41, 57, 20, 224, 226, 17, 57, 121, 224, 226, 121, 187, 150, 226,
                    145, 241, 74, 171, 26, 61, 140, 70, 198, 43, 173, 106, 244, 48, 26, 25, 175, 180, 170, 209, 195, 104,
                    100, 188, 210, 170, 70, 15, 163, 145, 241, 74, 171, 26, 61, 140, 65, 198, 111, 192, 37, 113, 139, 110,
                    166, 189, 116, 139, 119, 165, 190, 42, 25, 191, 158, 86, 34, 227, 137, 203, 197, 235, 77, 240, 200, 120,
                    226, 114, 241, 122, 19, 60, 50, 158, 184, 92, 188, 222, 196, 207, 254, 4, 108, 167, 136, 28, 167, 230,
                    226, 7, 49, 23, 174, 211, 201, 28, 167, 192, 78, 58, 145, 223, 44, 39, 227, 137, 203, 197, 235, 77, 240,
                    200, 120, 226, 114, 241, 122, 19, 60, 50, 158, 184, 92, 188, 222, 4, 145, 140, 39, 46, 23, 175, 55, 193,
                    35, 227, 137, 203, 197, 235, 77, 240, 200, 120, 226, 114, 241, 122, 147, 135, 70, 198, 239, 166, 85,
                    201, 248, 242, 215, 170, 0, 184, 31, 0, 123, 233, 240, 141, 240, 37, 229, 25, 146, 232, 41, 157, 81,
                    218, 94, 157, 215, 29, 131, 143, 249, 236, 136, 18, 134, 133, 140, 159, 24, 47, 252, 9, 49, 131, 5, 155,
                    108, 151, 179, 149, 108, 85, 14, 20, 176, 159, 30, 164, 135, 233, 81, 122, 156, 246, 211, 147, 116, 144,
                    158, 166, 103, 105, 59, 155, 205, 58, 89, 119, 120, 83, 133, 185, 108, 94, 15, 124, 202, 141, 138, 34,
                    106, 213, 234, 190, 232, 130, 194, 7, 159, 241, 125, 69, 17, 181, 106, 117, 95, 116, 65, 225, 131, 215,
                    100, 182, 213, 107, 10, 72, 142, 11, 98, 28, 23, 151, 112, 28, 23, 196, 56, 46, 46, 227, 56, 46, 136,
                    113, 92, 248, 123, 46, 234, 49, 4, 100, 45, 171, 69, 16, 16, 224, 7, 134, 29, 23, 196, 241, 91, 52, 228,
                    185, 168, 237, 184, 88, 207, 70, 29, 23, 162, 13, 245, 92, 56, 142, 11, 209, 54, 228, 185, 216, 40, 191,
                    199, 31, 20, 53, 146, 85, 163, 70, 28, 124, 203, 251, 162, 132, 161, 90, 128, 152, 93, 172, 134, 224,
                    67, 110, 68, 148, 48, 76, 143, 146, 2, 185, 129, 32, 41, 144, 27, 136, 145, 2, 185, 129, 16, 41, 144,
                    27, 136, 144, 2, 57, 112, 77, 182, 37, 239, 63, 21, 18, 181, 157, 237, 100, 187, 188, 47, 87, 99, 213,
                    150, 100, 189, 204, 51, 62, 202, 174, 213, 26, 9, 143, 178, 75, 181, 70, 162, 163, 236, 74, 13, 15, 123,
                    126, 159, 132, 37, 172, 109, 33, 56, 170, 26, 107, 75, 246, 179, 137, 164, 109, 213, 216, 40, 187, 78,
                    107, 36, 52, 202, 46, 211, 26, 137, 140, 34, 13, 7, 70, 217, 69, 90, 35, 113, 81, 118, 141, 214, 72,
                    88, 20, 121, 136, 11, 177, 131, 172, 234, 66, 172, 228, 110, 168, 6, 184, 19, 0, 135, 217, 240, 45, 96,
                    112, 191, 240, 37, 119, 236, 255, 248, 194, 31, 81, 178, 187, 148, 220, 165, 144, 184, 40, 180, 162,
                    54, 42, 211, 243, 123, 5, 126, 61, 223, 231, 23, 181, 74, 162, 167, 116, 70, 105, 123, 126, 246, 249,
                    21, 113, 143, 95, 22, 42, 137, 158, 210, 25, 165, 237, 249, 217, 255, 130, 242, 12, 73, 244, 148, 206,
                    40, 109, 207, 207, 254, 48, 250, 153, 245, 221, 121, 34, 252, 106, 39, 39, 89, 181, 139, 125, 37, 39,
                    171, 249, 90, 190, 158, 111, 228, 155, 249, 240, 75, 245, 114, 33, 108, 89, 253, 16, 6, 234, 84, 79,
                    179, 179, 172, 157, 207, 230, 157, 188, 155, 147, 185, 124, 62, 95, 200, 23, 243, 165, 194, 94, 203,
                    121, 153, 195, 142, 20, 252, 117, 122, 184, 202, 228, 148, 96, 123, 236, 17, 226, 57, 236, 148, 86, 53,
                    122, 24, 205, 97, 167, 180, 170, 209, 195, 104, 14, 59, 165, 85, 141, 30, 246, 179, 205, 177, 203, 231,
                    121, 47, 108, 174, 119, 242, 41, 14, 59, 165, 85, 141, 30, 14, 122, 193, 97, 236, 251, 31, 127, 25, 141,
                    70, 92, 22, 77, 111, 18, 120, 140, 7, 216, 215, 243, 143, 50, 32, 175, 36, 46, 15, 162, 240, 112, 127,
                    57, 171, 35, 241, 240, 126, 57, 171, 35, 241, 240, 126, 57, 171, 35, 241, 240, 126, 57, 171, 195, 240,
                    102, 14, 243, 163, 252, 56, 199, 249, 229, 172, 142, 196, 195, 251, 229, 172, 142, 196, 195, 251, 229,
                    172, 142, 196, 195, 251, 229, 172, 142, 196, 195, 251, 229, 172, 142, 196, 195, 251, 229, 172, 142, 196,
                    195, 11, 203, 211, 129, 120, 253, 28, 147, 193, 215, 97, 120, 231, 198, 241, 247, 28, 39, 121, 101, 242,
                    190, 44, 46, 15, 86, 141, 232, 191, 156, 213, 145, 120, 193, 191, 156, 29, 160, 127, 166, 23, 39, 216,
                    25, 40, 155, 94, 141, 211, 188, 194, 188, 250, 24, 62, 171, 98, 184, 30, 235, 222, 110, 121, 199, 229,
                    13, 3, 252, 81, 1, 126, 169, 122, 14, 169, 217, 150, 183, 67, 202, 113, 239, 136, 54, 216, 191, 83, 196,
                    55, 252, 144, 69, 9, 195, 244, 240, 59, 144, 235, 163, 211, 122, 224, 209, 119, 32, 55, 16, 124, 7, 114,
                    3, 177, 119, 32, 251, 96, 142, 79, 242, 124, 216, 68, 119, 91, 245, 66, 239, 64, 198, 194, 130, 255,
                    225, 87, 243, 135, 219, 39, 124, 95, 44, 162, 93, 202, 75, 216, 55, 5, 2, 197, 176, 220, 170, 70, 49,
                    12, 3, 252, 94, 1, 254, 175, 106, 193, 152, 56, 142, 47, 98, 253, 94, 1, 254, 175, 233, 17, 137, 152,
                    142, 47, 165, 85, 77, 193, 9, 214, 64, 60, 34, 166, 227, 75, 105, 85, 83, 112, 130, 53, 16, 141, 136,
                    228, 248, 90, 133, 187, 242, 22, 93, 107, 173, 183, 54, 120, 87, 197, 33, 86, 115, 124, 173, 180, 60,
                    99, 17, 81, 29, 95, 163, 161, 136, 168, 142, 175, 209, 72, 196, 38, 28, 95, 155, 126, 159, 143, 229,
                    236, 167, 246, 123, 245, 114, 33, 76, 101, 63, 73, 175, 53, 145, 252, 172, 26, 135, 136, 234, 248, 26,
                    13, 67, 68, 117, 124, 141, 70, 33, 226, 58, 190, 70, 131, 16, 81, 29, 95, 163, 49, 136, 168, 142, 175,
                    209, 16, 196, 135, 233, 248, 218, 106, 85, 117, 124, 149, 223, 13, 21, 0, 119, 2, 96, 187, 53, 124, 11,
                    224, 59, 190, 118, 90, 101, 142, 47, 226, 250, 189, 244, 38, 120, 142, 47, 226, 250, 189, 244, 38, 120,
                    142, 47, 226, 250, 189, 244, 38, 120, 142, 47, 226, 250, 189, 244, 38, 126, 246, 223, 148, 217, 86, 111,
                    42, 248, 25, 115, 226, 16, 117, 228, 33, 222, 31, 80, 208, 145, 135, 120, 127, 64, 65, 71, 30, 6, 255,
                    1, 133, 122, 172, 2, 217, 109, 213, 34, 21, 8, 112, 10, 197, 56, 68, 136, 58, 252, 241, 253, 1, 133,
                    189, 150, 27, 135, 168, 35, 15, 241, 254, 128, 130, 142, 60, 108, 234, 15, 40, 236, 35, 44, 210, 14,
                    176, 23, 122, 120, 159, 184, 135, 173, 106, 161, 6, 246, 163, 184, 145, 72, 3, 251, 73, 220, 72, 160,
                    129, 253, 32, 110, 36, 206, 192, 126, 14, 215, 196, 167, 148, 103, 72, 70, 37, 139, 17, 97, 192, 27,
                    247, 26, 250, 40, 48, 148, 99, 0, 245, 56, 61, 130, 192, 159, 115, 60, 122, 0, 156, 163, 210, 170, 166,
                    192, 63, 54, 16, 63, 128, 201, 57, 42, 173, 106, 10, 252, 163, 15, 250, 124, 146, 79, 194, 38, 250, 120,
                    26, 231, 168, 180, 170, 41, 240, 143, 88, 24, 224, 114, 142, 163, 193, 3, 225, 156, 227, 41, 250, 23,
                    8, 130, 243, 196, 235, 105, 231, 12, 193, 135, 162, 189, 38, 193, 46, 20, 231, 89, 87, 180, 193, 15,
                    187, 128, 118, 200, 63, 195, 105, 246, 11, 127, 246, 145, 106, 75, 44, 212, 47, 252, 209, 21, 22, 234,
                    23, 254, 232, 2, 11, 245, 11, 127, 116, 125, 133, 249, 133, 175, 180, 170, 209, 195, 126, 182, 13, 58,
                    88, 87, 223, 244, 199, 19, 144, 253, 209, 197, 58, 88, 115, 55, 235, 251, 55, 248, 102, 158, 254, 94,
                    121, 159, 253, 255, 1,
                };
                
                ushort[] u16Table = 
                {
                    0, 0, 0, 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 9, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 266, 45, 0, 0, 0, 0, 49, 0, 0, 0, 0, 0, 0, 0, 0, 53, 0, 0, 0, 0, 0, 0, 0, 0, 25, 29,
                    0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262, 262, 0, 0, 0, 0, 262, 0, 0, 0,
                    0, 0, 0, 0, 0, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 14, 14, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 18, 18, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0,
                    18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 22,
                    0, 0, 0, 0, 22, 0, 0, 0, 0, 0, 0, 0, 0, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 61, 45, 0, 0, 0, 0, 49, 0, 0, 0, 0, 0, 0, 0, 0, 53, 0, 0, 0, 0, 0,
                    0, 0, 0, 57, 29, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 65, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 69, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 73, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 258,
                    258, 0, 0, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 278, 0, 85, 0, 0, 89,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 77, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 101,
                    0, 0, 0, 0, 0, 0, 0, 0, 290, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 93, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 113, 0, 0, 0, 0, 0, 0, 0, 0, 342, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 109, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 274, 0, 274, 0, 0, 274, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 121, 0, 85, 0, 0, 89, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 117, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 129, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 286, 0, 0, 0, 0, 0, 0, 0, 0, 286, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 101,
                    0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 133, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 145, 149, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 141, 0, 0, 0, 0, 0, 0, 0, 0, 338, 0, 0, 0, 0,
                    0, 0, 0, 0, 338, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 113, 0, 0, 0, 0, 0, 0, 0, 0, 157, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 153, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 165, 169, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    161, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0, 270, 0, 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 26, 26, 0, 0,
                    0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 173, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 177, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 282, 0, 0, 0,
                    0, 0, 0, 0, 0, 282, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 38, 0, 0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0,
                    0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 245, 0, 0, 249, 0, 0, 0, 0, 253,
                    0, 0, 0, 0, 322, 0, 0, 322, 0, 0, 0, 257, 261, 265, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 181,
                    185, 189, 193, 197, 201, 205, 209, 213, 217, 221, 225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 237, 241, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 0, 294,
                    0, 0, 294, 0, 0, 0, 294, 294, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 298, 0, 0, 298, 0, 0, 0, 0, 298, 0, 0, 0, 0, 298, 0, 0, 298, 0, 0, 0, 298, 298, 298, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 134, 134, 0, 0, 0, 0, 134, 0, 0, 0, 0, 0, 0, 0, 0, 134, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 333, 0, 337, 341, 345, 349, 353, 0, 0, 0, 0, 0, 0, 374,
                    0, 0, 374, 0, 0, 0, 0, 0, 357, 0, 0, 374, 361, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 269, 0, 0, 273, 277, 281, 285, 289, 293, 297, 301, 305, 0, 309, 313, 317, 321, 325,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 329, 0, 346, 0, 346, 346, 346, 346, 346, 0, 0, 0, 0, 0, 0, 346, 0, 0, 346,
                    0, 0, 0, 0, 0, 346, 0, 0, 346, 346, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 350,
                    0, 350, 350, 350, 350, 350, 0, 0, 0, 0, 0, 0, 350, 0, 0, 350, 0, 0, 0, 0, 0, 350, 0, 0, 350, 350, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 365,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 369, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 373, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 306, 0, 0, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 318, 0, 0, 318, 0, 0, 0, 0, 318, 0, 0,
                    0, 0, 318, 0, 0, 318, 0, 0, 0, 318, 318, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 58, 58, 58, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 0, 0, 0,
                    0, 62, 0, 0, 62, 0, 0, 0, 62, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 66, 66, 66, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70, 0, 0, 0, 0, 70,
                    0, 0, 70, 377, 381, 385, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86, 0, 0, 0, 0, 86, 0, 0, 86, 86, 86, 86, 86, 86, 86, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 90, 0, 0, 0, 0, 90,
                    0, 0, 90, 90, 90, 90, 90, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 94, 0, 0, 94, 0, 0, 0, 0, 94, 0, 0, 0, 0, 94, 0, 0, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 106, 0, 0, 106, 0, 0, 0, 0, 106, 0, 0, 0, 0, 106,
                    0, 0, 106, 106, 106, 106, 106, 106, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 114, 0, 0, 114, 0, 0, 0, 0, 114, 0, 0, 0, 0, 114, 0, 0, 114, 114, 114, 114, 114, 114, 114,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0, 0, 122, 0, 0, 0, 0, 122,
                    0, 0, 0, 0, 122, 0, 0, 122, 122, 122, 122, 122, 122, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 389, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 245, 0, 0, 249, 0, 0, 0, 0, 253,
                    0, 0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 257, 261, 265, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 393, 197, 201, 205, 209, 213, 217, 221, 225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 0, 130, 0, 0, 0, 0, 130, 0, 0, 0, 0, 130, 0, 0, 130,
                    130, 130, 130, 130, 130, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    126, 0, 0, 126, 0, 0, 0, 0, 126, 0, 0, 0, 0, 126, 0, 0, 126, 126, 126, 126, 126, 126, 126, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    245, 0, 0, 249, 0, 0, 0, 0, 253, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 265, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 401, 225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 245, 0, 0, 249, 0, 0, 0, 0, 253, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 265, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 405, 225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 473, 0, 0, 477, 0, 0, 0, 0, 481, 0, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 485, 489, 493, 322, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 409, 413, 417, 421, 425, 429, 433, 437, 441, 445, 449, 453, 457,
                    461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 465, 469, 0, 0, 0, 0, 0, 0, 242,
                    0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 242, 0, 0, 242, 242, 242, 242, 0, 0, 242, 0, 0, 242,
                    242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 497, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 0, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 501, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0, 150,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 146, 0, 0, 146, 0, 0, 0, 0, 0, 0, 0, 0, 509, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 370, 370, 370, 370, 370, 0, 0, 0, 0, 0, 0, 370, 0, 0, 370, 0,
                    0, 0, 0, 0, 370, 0, 0, 370, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0,
                    162, 162, 162, 162, 162, 0, 0, 0, 0, 0, 0, 162, 0, 0, 162, 0, 0, 0, 0, 0, 162, 0, 0, 162, 162, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0,
                    0, 166, 0, 0, 166, 0, 0, 0, 0, 0, 166, 0, 0, 166, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0, 170, 0, 0, 170, 0, 0, 0, 0, 0, 170, 0,
                    0, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174, 174, 174, 174,
                    0, 0, 0, 0, 0, 0, 174, 0, 0, 174, 0, 0, 0, 0, 0, 174, 0, 0, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 517, 0, 0, 0, 0, 178, 0, 0, 178, 521,
                    525, 529, 0, 0, 178, 0, 0, 178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 513, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206,
                    0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 0, 206, 0, 0, 206, 206, 206, 206, 0, 0, 206, 0, 0, 206,
                    206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0,
                    202, 0, 0, 0, 0, 202, 0, 0, 202, 202, 202, 202, 0, 0, 202, 0, 0, 202, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226, 0, 226, 0, 0, 0, 0, 226, 0, 0, 226,
                    226, 226, 226, 0, 0, 226, 0, 0, 226, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 533, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 333, 0, 337, 341, 345, 349, 353, 0, 0, 0, 0, 0, 0, 158, 0,
                    0, 158, 0, 0, 0, 0, 0, 357, 0, 0, 158, 361, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 269, 0, 0, 0, 0, 0, 0, 537, 293, 297, 301, 305, 0, 309, 313, 317, 321, 325, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 130, 130, 130, 130, 130, 0, 130, 0, 0, 0, 0, 130, 0, 0, 130, 130, 130,
                    130, 0, 0, 130, 0, 0, 130, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0,
                    218, 218, 218, 218, 218, 0, 218, 0, 0, 0, 0, 218, 0, 0, 218, 218, 218, 218, 0, 0, 218, 0, 0, 218, 218,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222,
                    0, 0, 0, 0, 222, 0, 0, 222, 222, 222, 222, 0, 0, 222, 0, 0, 222, 222, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 234, 0, 0, 234, 234,
                    234, 234, 0, 0, 234, 0, 0, 234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238,
                    0, 238, 238, 238, 238, 238, 0, 238, 0, 0, 0, 0, 238, 0, 0, 238, 238, 238, 238, 0, 0, 238, 0, 0, 238,
                    238, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230, 0,
                    230, 0, 0, 0, 0, 230, 0, 0, 230, 230, 230, 230, 0, 0, 230, 0, 0, 230, 230, 250, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 609, 613, 617, 621, 625, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374,
                    0, 0, 0, 0, 0, 629, 374, 0, 374, 633, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 541, 0, 0, 545, 549, 553, 557, 561, 565, 569, 573, 577, 0, 581, 585, 589, 593, 597, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 601, 0, 333, 0, 337, 341, 345, 349, 353, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 269, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 637, 321, 325, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 30, 0, 30, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 34, 0, 34, 0, 0, 34, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 42, 0, 0, 0, 0, 0, 0, 0, 0, 42,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 74, 74, 74, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 78, 0, 0, 0, 0, 78,
                    0, 0, 78, 0, 0, 0, 78, 78, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    82, 0, 0, 82, 0, 0, 0, 0, 82, 0, 0, 0, 0, 82, 0, 0, 82, 0, 0, 0, 82, 82, 82, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 245, 0, 0, 249, 0, 0, 0, 0, 253, 0, 0, 0, 0, 322, 0,
                    0, 322, 0, 0, 0, 257, 261, 265, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 641, 189, 193, 197, 201,
                    205, 209, 213, 217, 221, 225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 241, 0, 0, 0, 0, 0, 0, 314, 0, 0, 314, 0, 0, 0, 0, 314, 0, 0, 0, 0, 314, 0, 0, 314, 0, 0, 0, 314,
                    314, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 649, 653, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 645, 0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 98, 98, 98, 98, 98, 98, 98,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102,
                    0, 0, 0, 0, 102, 0, 0, 102, 102, 102, 102, 102, 102, 102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 657,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 318, 0, 0, 318, 0, 0, 0, 0, 318, 0, 0, 0, 0, 0, 0,
                    0, 318, 0, 0, 0, 318, 318, 318, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 0, 58, 58, 58, 58, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 0, 0, 0, 0, 0, 0, 0,
                    62, 0, 0, 0, 62, 62, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66,
                    0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 0, 66, 66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 70, 661,
                    665, 669, 70, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 86, 0,
                    0, 86, 0, 0, 0, 0, 86, 0, 0, 0, 0, 0, 0, 0, 86, 86, 86, 86, 86, 86, 86, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 90, 90,
                    90, 90, 90, 90, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 94, 0, 0,
                    94, 0, 0, 0, 0, 94, 0, 0, 0, 0, 0, 0, 0, 94, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 106, 0, 0, 106, 0, 0, 0, 0, 106, 0, 0, 0, 0, 0, 0, 0, 106, 106,
                    106, 106, 106, 106, 106, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114,
                    0, 0, 114, 0, 0, 0, 0, 114, 0, 0, 0, 0, 0, 0, 0, 114, 114, 114, 114, 114, 114, 114, 114, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0, 0, 122, 0, 0, 0, 0, 122, 0, 0, 0, 0,
                    0, 0, 0, 122, 122, 122, 122, 122, 122, 122, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 673, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0, 0, 477, 0, 0, 0, 0, 481, 0, 0, 0, 0,
                    0, 0, 0, 54, 0, 0, 0, 485, 489, 493, 54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 677, 425,
                    429, 433, 437, 441, 445, 449, 453, 457, 461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 0, 130, 0, 0, 0, 0, 130, 0, 0, 0, 0, 0, 0, 0, 130, 130, 130, 130,
                    130, 130, 130, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0,
                    126, 0, 0, 0, 0, 126, 0, 0, 0, 0, 0, 0, 0, 126, 126, 126, 126, 126, 126, 126, 126, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 681, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0,
                    0, 477, 0, 0, 0, 0, 481, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 493, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 685, 453, 457, 461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0, 0, 477, 0, 0, 0, 0, 481, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 493, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 689,
                    453, 457, 461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    473, 0, 0, 477, 0, 0, 0, 0, 481, 0, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 485, 489, 493, 322, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 693, 413, 417, 421, 425, 429, 433, 437, 441, 445, 449, 453, 457, 461, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 465, 469, 0, 0, 0, 0, 0, 0, 138, 0, 0, 0, 0,
                    0, 0, 0, 0, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 142, 0, 0, 697, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 333, 0, 337, 341, 345, 349, 353,
                    0, 0, 0, 0, 0, 0, 374, 0, 0, 374, 0, 0, 0, 0, 0, 357, 0, 0, 374, 361, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 269, 0, 0, 0, 701, 281, 285, 289, 293, 297, 301, 305, 0, 309,
                    313, 317, 321, 325, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 329, 0, 757, 0, 761, 765, 769, 773, 777, 0, 0, 0, 0,
                    0, 0, 374, 0, 0, 374, 0, 0, 0, 0, 0, 781, 0, 0, 0, 785, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 705, 0, 0, 0, 0, 0, 709, 713, 717, 721, 725, 729, 0, 733, 737, 741, 745, 749,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 753, 0, 194, 0, 194, 194, 194, 194, 194, 0, 0, 0, 0, 0, 0, 194, 0, 0, 194,
                    0, 0, 0, 0, 0, 194, 0, 0, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 789,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 182, 0, 0, 182, 0,
                    0, 0, 0, 0, 182, 0, 0, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0,
                    186, 186, 186, 186, 186, 0, 0, 0, 0, 0, 0, 186, 0, 0, 186, 0, 0, 0, 0, 0, 186, 0, 0, 186, 186, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0,
                    0, 190, 0, 0, 190, 0, 0, 0, 0, 0, 190, 0, 0, 190, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 797, 0, 0, 801, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 793, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 366, 366, 366, 366, 366, 0, 0, 0, 0,
                    0, 0, 366, 0, 0, 366, 0, 0, 0, 0, 0, 366, 0, 0, 366, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 0, 0, 0, 242, 242, 242, 242, 0, 0,
                    242, 242, 0, 242, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 805, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 0, 0, 0, 0, 0, 362, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 809, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 146, 0, 0, 0, 0, 0, 0, 146, 0, 817, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 370, 370, 370, 370, 370, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 370, 370, 0, 370, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 0, 0, 0, 0, 162, 162,
                    0, 162, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 0, 0, 0, 0, 166, 166, 0, 166, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 0, 0,
                    0, 0, 170, 170, 0, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174,
                    174, 174, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 0, 0, 0, 0, 174, 174, 0, 174, 174, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 825, 0, 0, 0, 0,
                    0, 0, 0, 178, 829, 833, 837, 0, 0, 178, 178, 0, 178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 821, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 0, 0, 0, 0, 206, 206, 206, 206, 0,
                    0, 206, 206, 0, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202,
                    202, 202, 202, 0, 202, 0, 0, 0, 0, 0, 0, 0, 202, 202, 202, 202, 0, 0, 202, 202, 0, 202, 202, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226, 0, 226, 0, 0, 0,
                    0, 0, 0, 0, 226, 226, 226, 226, 0, 0, 226, 226, 0, 226, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 841,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 609, 613, 617, 621, 625, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 0, 629, 158, 0, 158, 633, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 541, 0, 0, 0, 0, 0, 0, 845, 565, 569, 573, 577, 0, 581, 585, 589, 593, 597,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 130, 130, 130, 130, 130, 0, 130, 0, 0, 0, 0, 0, 0, 0, 130,
                    130, 130, 130, 0, 0, 130, 130, 0, 130, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 218, 0, 218, 218, 218, 218, 218, 0, 218, 0, 0, 0, 0, 0, 0, 0, 218, 218, 218, 218, 0, 0, 218, 218,
                    0, 218, 218, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222,
                    0, 222, 0, 0, 0, 0, 0, 0, 0, 222, 222, 222, 222, 0, 0, 222, 222, 0, 222, 222, 254, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 0, 0, 0,
                    234, 234, 234, 234, 0, 0, 234, 234, 0, 234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 238, 0, 238, 238, 238, 238, 238, 0, 238, 0, 0, 0, 0, 0, 0, 0, 238, 238, 238, 238, 0, 0, 238, 238,
                    0, 238, 238, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230,
                    0, 230, 0, 0, 0, 0, 0, 0, 0, 230, 230, 230, 230, 0, 0, 230, 230, 0, 230, 230, 250, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 609, 613, 617, 621, 625, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374,
                    0, 0, 0, 0, 0, 629, 374, 0, 374, 633, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 541, 0, 0, 849, 549, 553, 557, 561, 565, 569, 573, 577, 0, 581, 585, 589, 593, 597, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 601, 0, 605, 0, 609, 613, 617, 621, 625, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 541, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 853, 593, 597, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214,
                    214, 214, 214, 214, 0, 214, 0, 0, 0, 0, 214, 0, 0, 214, 214, 214, 214, 0, 0, 214, 0, 0, 214, 214, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 302,
                    0, 0, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    921, 0, 0, 925, 0, 0, 0, 0, 929, 322, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 933, 937, 941, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 857, 861, 865, 869, 873, 877, 881, 885, 889, 893, 897, 901, 905, 909, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 913, 917, 0, 0, 0, 0, 0, 0, 326, 0, 0, 326,
                    0, 0, 0, 0, 326, 326, 0, 0, 0, 0, 0, 0, 326, 0, 0, 0, 326, 326, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 330, 0, 0, 0, 0, 330, 330, 0, 0, 0, 0, 0, 0, 330, 0,
                    0, 0, 330, 330, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0,
                    0, 110, 0, 0, 0, 0, 110, 0, 0, 0, 0, 110, 0, 0, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 0, 0, 0, 0, 0, 0,
                    0, 74, 0, 0, 0, 74, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    78, 0, 0, 78, 0, 0, 0, 0, 78, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 0, 78, 78, 78, 78, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 82, 0, 0, 0, 0, 82, 0, 0, 0, 0, 0, 0, 0, 82,
                    0, 0, 0, 82, 82, 82, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0,
                    0, 477, 0, 0, 0, 0, 481, 0, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 485, 489, 493, 322, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 945, 417, 421, 425, 429, 433, 437, 441, 445, 449, 453, 457, 461, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 469, 0, 0, 0, 0, 0, 0, 314, 0, 0, 314, 0, 0, 0,
                    0, 314, 0, 0, 0, 0, 0, 0, 0, 314, 0, 0, 0, 314, 314, 314, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 649, 653, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 949, 0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98,
                    0, 0, 0, 0, 0, 0, 0, 98, 98, 98, 98, 98, 98, 98, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102, 0, 0, 0, 0, 0, 0, 0, 102, 102, 102, 102, 102, 102,
                    102, 102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 953, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 333, 0, 337, 341, 345, 349, 353, 0, 0, 0, 0, 0, 0, 374, 0, 0, 374, 0, 0, 0, 0, 0, 357,
                    0, 0, 374, 361, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 269, 0, 0, 0,
                    957, 281, 285, 289, 293, 297, 301, 305, 0, 309, 313, 317, 321, 325, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 329,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 0, 358, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 242,
                    0, 0, 242, 242, 242, 242, 0, 0, 242, 0, 0, 0, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 154, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 370, 370, 370, 370, 370, 0, 0, 0, 0, 0, 0,
                    370, 0, 0, 370, 0, 0, 0, 0, 0, 370, 0, 0, 0, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0, 0, 0, 0, 0, 0, 162, 0, 0, 162, 0, 0, 0, 0, 0, 162, 0, 0,
                    0, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166,
                    0, 0, 0, 0, 0, 0, 166, 0, 0, 166, 0, 0, 0, 0, 0, 166, 0, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0, 170, 0, 0, 170, 0, 0, 0,
                    0, 0, 170, 0, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174,
                    174, 174, 174, 0, 0, 0, 0, 0, 0, 174, 0, 0, 174, 0, 0, 0, 0, 0, 174, 0, 0, 0, 174, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 965, 0, 0, 0, 0, 178, 0,
                    0, 178, 969, 973, 977, 0, 0, 178, 0, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 961, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 0, 206, 0, 0, 206, 206, 206, 206, 0, 0, 206,
                    0, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202,
                    202, 0, 202, 0, 0, 0, 0, 202, 0, 0, 202, 202, 202, 202, 0, 0, 202, 0, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226, 0, 226, 0, 0, 0, 0, 226, 0, 0,
                    226, 226, 226, 226, 0, 0, 226, 0, 0, 0, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 981, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 757, 0, 761, 765, 769, 773, 777, 0, 0, 0, 0, 0, 0, 158,
                    0, 0, 158, 0, 0, 0, 0, 0, 781, 0, 0, 0, 785, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 705, 0, 0, 0, 0, 0, 0, 985, 717, 721, 725, 729, 0, 733, 737, 741, 745, 749, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 130, 130, 130, 130, 130, 0, 130, 0, 0, 0, 0, 130, 0, 0, 130, 130, 130,
                    130, 0, 0, 130, 0, 0, 0, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218,
                    218, 218, 218, 218, 0, 218, 0, 0, 0, 0, 218, 0, 0, 218, 218, 218, 218, 0, 0, 218, 0, 0, 0, 218, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0, 0,
                    0, 0, 222, 0, 0, 222, 222, 222, 222, 0, 0, 222, 0, 0, 0, 222, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 234, 0, 0, 234, 234, 234, 234,
                    0, 0, 234, 0, 0, 0, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 238, 238,
                    238, 238, 238, 0, 238, 0, 0, 0, 0, 238, 0, 0, 238, 238, 238, 238, 0, 0, 238, 0, 0, 0, 238, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 0,
                    230, 0, 0, 230, 230, 230, 230, 0, 0, 230, 0, 0, 0, 230, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 605, 0, 609, 613, 617, 621, 625, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 629, 374,
                    0, 374, 633, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 541, 0, 0, 989,
                    549, 553, 557, 561, 565, 569, 573, 577, 0, 581, 585, 589, 593, 597, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 601,
                    0, 757, 0, 761, 765, 769, 773, 777, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 705, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 993, 745, 749, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 997, 246, 0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 0, 246, 0, 0, 246, 246, 246, 246, 0, 0, 246,
                    0, 0, 246, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 254, 0, 254, 254, 254, 254,
                    254, 0, 254, 0, 0, 0, 0, 254, 0, 0, 254, 254, 254, 254, 0, 0, 254, 0, 0, 254, 254, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250, 250, 0, 250, 0, 0, 0, 0, 250, 0,
                    0, 250, 250, 250, 250, 0, 0, 250, 0, 0, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 210, 0, 0, 210, 210, 210, 210, 0, 0, 210,
                    0, 0, 210, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1005, 0, 0, 0, 0, 0, 0, 142, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 605, 0, 609, 613, 617, 621, 625, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 629,
                    374, 0, 374, 633, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 541, 0, 0,
                    0, 1009, 553, 557, 561, 565, 569, 573, 577, 0, 581, 585, 589, 593, 597, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    601, 0, 1065, 0, 1069, 1073, 1077, 1081, 1085, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 1089, 374,
                    0, 0, 1093, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 0, 0,
                    0, 1017, 1021, 1025, 1029, 1033, 1037, 0, 1041, 1045, 1049, 1053, 1057, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1061, 0, 194, 0, 194, 194, 194, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 0, 0, 0, 0, 194, 194, 0,
                    194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1097, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0, 0, 0, 0, 0, 182, 182, 0,
                    182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 0, 0, 0, 0, 186, 186, 0, 186, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 0, 0,
                    0, 0, 190, 190, 0, 190, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105,
                    0, 0, 1109, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1101, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 366, 366, 366, 366, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0,
                    0, 0, 0, 0, 366, 366, 0, 366, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1113, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214, 214, 0, 214, 0, 0, 0, 0, 0, 0, 0, 214,
                    214, 214, 214, 0, 0, 214, 214, 0, 214, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1117, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 306, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 318, 0, 0, 318, 0, 0, 0, 0, 318, 318, 0, 0, 0, 0, 0, 0, 318, 0, 0, 0, 318,
                    318, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0,
                    0, 0, 58, 58, 0, 0, 0, 0, 0, 0, 58, 0, 0, 0, 58, 58, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 62, 0, 0, 0, 0, 0, 0, 62, 0, 0, 0, 62, 62, 62,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66,
                    66, 0, 0, 0, 0, 0, 0, 66, 0, 0, 0, 66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70, 70, 0, 0, 0, 0, 0, 0, 70, 1121, 1125, 1129, 70, 70, 70,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86,
                    86, 0, 0, 0, 0, 0, 0, 86, 86, 86, 86, 86, 86, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 90, 90, 0, 0, 0, 0, 0, 0, 90, 90, 90, 90, 90, 90, 90,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0, 0, 0, 94,
                    94, 0, 0, 0, 0, 0, 0, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 106, 0, 0, 106, 0, 0, 0, 0, 106, 106, 0, 0, 0, 0, 0, 0, 106, 106, 106, 106, 106,
                    106, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 0, 114, 0, 0,
                    0, 0, 114, 114, 0, 0, 0, 0, 0, 0, 114, 114, 114, 114, 114, 114, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0, 0, 122, 0, 0, 0, 0, 122, 122, 0, 0, 0, 0, 0, 0, 122, 122,
                    122, 122, 122, 122, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 0, 0, 0, 1133, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 921, 0, 0, 925, 0, 0, 0, 0, 929, 54, 0, 0, 0, 0, 0, 0, 54, 0, 0,
                    0, 933, 937, 941, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1137, 873, 877, 881, 885, 889,
                    893, 897, 901, 905, 909, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 130, 0, 0, 130, 0, 0, 0, 0, 130, 130, 0, 0, 0, 0, 0, 0, 130, 130, 130, 130, 130, 130, 130, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 126, 0, 0, 0, 0, 126,
                    126, 0, 0, 0, 0, 0, 0, 126, 126, 126, 126, 126, 126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1141, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 921, 0, 0, 925, 0, 0, 0, 0, 929,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 941, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1145, 901, 905, 909, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 921, 0, 0, 925, 0, 0, 0, 0, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 941,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1149, 901, 905, 909, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0, 0, 477, 0, 0,
                    0, 0, 481, 0, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 485, 489, 493, 322, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1153, 413, 417, 421, 425, 429, 433, 437, 441, 445, 449, 453, 457, 461, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 302, 0, 0, 0, 0, 0, 0, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 921, 0, 0, 925, 0, 0, 0, 0, 929, 322, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 933, 937, 941, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1157, 861, 865, 869, 873, 877, 881, 885, 889, 893, 897, 901, 905, 909,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 913, 917, 0, 0, 0, 0, 0, 0, 110, 0, 0,
                    110, 0, 0, 0, 0, 110, 0, 0, 0, 0, 0, 0, 0, 110, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 354, 0, 0,
                    354, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194,
                    0, 194, 194, 194, 194, 194, 0, 0, 0, 0, 0, 0, 194, 0, 0, 194, 0, 0, 0, 0, 0, 194, 0, 0, 0, 194, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1161, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182,
                    0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 182, 0, 0, 182, 0, 0, 0, 0, 0, 182, 0, 0, 0, 182, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 0, 0, 0, 0,
                    0, 186, 0, 0, 186, 0, 0, 0, 0, 0, 186, 0, 0, 0, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 190, 0, 0, 190, 0, 0, 0, 0, 0, 190, 0,
                    0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1169, 0, 0, 1173, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1165, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 366, 0, 366, 366, 366, 366, 366, 0, 0, 0, 0, 0, 0, 366, 0, 0, 366, 0, 0, 0, 0, 0, 366,
                    0, 0, 0, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1177, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214, 214, 0, 214, 0, 0, 0, 0, 214, 0, 0, 214, 214, 214, 214, 0,
                    0, 214, 0, 0, 0, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1181, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1185, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 609, 613, 617, 621, 625, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 629, 374, 0, 374, 633, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 541, 0, 0, 0, 1189, 553, 557, 561, 565, 569, 573, 577, 0, 581, 585,
                    589, 593, 597, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 601, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    358, 0, 0, 0, 0, 0, 0, 358, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242,
                    0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 0, 0, 0, 242, 242, 242, 242, 0, 0, 242, 242, 0, 0, 242,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 154, 0, 0, 0, 0, 0, 0, 154, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    370, 0, 370, 370, 370, 370, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 370, 370, 0, 0, 370,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 162, 0, 0, 0, 0, 0, 162, 162, 0, 0, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 0, 0, 0, 0, 166,
                    166, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170,
                    170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 0, 0, 0, 0, 170, 170, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174, 174, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 0,
                    0, 0, 0, 174, 174, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178,
                    178, 178, 178, 178, 0, 1197, 0, 0, 0, 0, 0, 0, 0, 178, 1201, 1205, 1209, 0, 0, 178, 178, 0, 0, 178, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 1193, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206,
                    0, 0, 0, 0, 0, 0, 0, 206, 206, 206, 206, 0, 0, 206, 206, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0, 202, 0, 0, 0, 0, 0, 0, 0, 202, 202, 202,
                    202, 0, 0, 202, 202, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0,
                    226, 226, 226, 226, 226, 0, 226, 0, 0, 0, 0, 0, 0, 0, 226, 226, 226, 226, 0, 0, 226, 226, 0, 0, 226,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1065, 0, 1069, 1073, 1077, 1081, 1085, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 0, 1089, 158, 0, 0,
                    1093, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 0, 0, 0, 0,
                    1217, 1025, 1029, 1033, 1037, 0, 1041, 1045, 1049, 1053, 1057, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130,
                    0, 130, 130, 130, 130, 130, 0, 130, 0, 0, 0, 0, 0, 0, 0, 130, 130, 130, 130, 0, 0, 130, 130, 0, 0, 130,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218, 218, 218, 218, 0, 218,
                    0, 0, 0, 0, 0, 0, 0, 218, 218, 218, 218, 0, 0, 218, 218, 0, 0, 218, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0, 0, 0, 0, 0, 0, 0, 222, 222, 222,
                    222, 0, 0, 222, 222, 0, 0, 222, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0,
                    234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 0, 0, 0, 234, 234, 234, 234, 0, 0, 234, 234, 0, 0, 234,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 238, 238, 238, 238, 238, 0, 238,
                    0, 0, 0, 0, 0, 0, 0, 238, 238, 238, 238, 0, 0, 238, 238, 0, 0, 238, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 0, 0, 0, 0, 230, 230, 230,
                    230, 0, 0, 230, 230, 0, 0, 230, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0,
                    609, 613, 617, 621, 625, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 629, 374, 0, 374, 633, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 541, 0, 0, 1221, 549, 553, 557, 561,
                    565, 569, 573, 577, 0, 581, 585, 589, 593, 597, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 601, 0, 1065, 0, 1069,
                    1073, 1077, 1081, 1085, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1225, 1053, 1057, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1229,
                    246, 0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 0, 0, 0, 0, 246, 246, 246, 246, 0, 0, 246, 246, 0,
                    246, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 254, 0, 254, 254, 254, 254, 254,
                    0, 254, 0, 0, 0, 0, 0, 0, 0, 254, 254, 254, 254, 0, 0, 254, 254, 0, 254, 254, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250, 250, 0, 250, 0, 0, 0, 0, 0, 0, 0, 250,
                    250, 250, 250, 0, 0, 250, 250, 0, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 0, 0, 0, 210, 210, 210, 210, 0, 0, 210, 210,
                    0, 210, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118,
                    0, 0, 0, 0, 118, 0, 0, 118, 118, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 74, 0, 0, 0, 0, 0, 0, 74, 0, 0, 0, 74, 74, 74,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 78,
                    78, 0, 0, 0, 0, 0, 0, 78, 0, 0, 0, 78, 78, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 82, 0, 0, 82, 0, 0, 0, 0, 82, 82, 0, 0, 0, 0, 0, 0, 82, 0, 0, 0, 82, 82, 82, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 921, 0, 0, 925, 0, 0, 0, 0, 929, 322,
                    0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 933, 937, 941, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1233,
                    865, 869, 873, 877, 881, 885, 889, 893, 897, 901, 905, 909, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 917, 0, 0, 0, 0, 0, 0, 314, 0, 0, 314, 0, 0, 0, 0, 314, 314, 0, 0, 0, 0, 0, 0,
                    314, 0, 0, 0, 314, 314, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 649, 653, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1237, 0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 98, 0, 0, 0, 0, 0, 0, 98,
                    98, 98, 98, 98, 98, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102,
                    0, 0, 102, 0, 0, 0, 0, 102, 102, 0, 0, 0, 0, 0, 0, 102, 102, 102, 102, 102, 102, 102, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1241, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1245, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1249, 246, 0, 246, 246,
                    246, 246, 246, 0, 246, 0, 0, 0, 0, 246, 0, 0, 246, 246, 246, 246, 0, 0, 246, 0, 0, 0, 246, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 254, 0, 254, 254, 254, 254, 254, 0, 254, 0, 0, 0, 0,
                    254, 0, 0, 254, 254, 254, 254, 0, 0, 254, 0, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250, 250, 0, 250, 0, 0, 0, 0, 250, 0, 0, 250, 250, 250, 250, 0,
                    0, 250, 0, 0, 0, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210,
                    210, 210, 0, 210, 0, 0, 0, 0, 210, 0, 0, 210, 210, 210, 210, 0, 0, 210, 0, 0, 0, 210, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 0, 0, 0, 0, 0, 198,
                    0, 0, 198, 0, 0, 0, 0, 0, 198, 0, 0, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 354,
                    0, 0, 0, 0, 0, 0, 354, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0,
                    194, 194, 194, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 0, 0, 0, 0, 194, 194, 0, 0, 194, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1253, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0,
                    182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0, 0, 0, 0, 0, 182, 182, 0, 0, 182, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 186, 0, 0, 0, 0, 0, 186, 186, 0, 0, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 0, 0, 0, 0, 190, 190, 0,
                    0, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1261, 0, 0, 1265, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1257, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 366, 0, 366, 366, 366, 366, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 0, 0, 0, 0, 366, 366,
                    0, 0, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1269, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 214, 0, 214, 214, 214, 214, 214, 0, 214, 0, 0, 0, 0, 0, 0, 0, 214, 214, 214, 214, 0, 0, 214,
                    214, 0, 0, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1273, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 302, 0, 0, 0, 0, 0, 0, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 921, 0, 0, 925, 0, 0, 0, 0, 929, 322, 0, 0,
                    0, 0, 0, 0, 322, 0, 0, 0, 933, 937, 941, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1277, 861, 865,
                    869, 873, 877, 881, 885, 889, 893, 897, 901, 905, 909, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 913, 917, 0, 0, 0, 0, 0, 0, 110, 0, 0, 110, 0, 0, 0, 0, 110, 110, 0, 0, 0, 0, 0, 0, 110,
                    110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    118, 0, 0, 118, 0, 0, 0, 0, 118, 0, 0, 0, 0, 0, 0, 0, 118, 118, 118, 118, 118, 118, 118, 118, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1281, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1001, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1285, 246, 0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 0,
                    0, 0, 0, 246, 246, 246, 246, 0, 0, 246, 246, 0, 0, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 254, 0, 254, 254, 254, 254, 254, 0, 254, 0, 0, 0, 0, 0, 0, 0, 254, 254, 254, 254, 0, 0,
                    254, 254, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250,
                    250, 250, 0, 250, 0, 0, 0, 0, 0, 0, 0, 250, 250, 250, 250, 0, 0, 250, 250, 0, 0, 250, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 0,
                    0, 0, 210, 210, 210, 210, 0, 0, 210, 210, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 0, 0, 0, 0, 198, 198,
                    0, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1289,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 0, 0, 0, 0, 0, 198, 0, 0, 198, 0, 0, 0, 0, 0, 198, 0, 0,
                    0, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1293,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 118, 0, 0, 0, 0, 0, 0, 118, 118, 118, 118, 118, 118, 118, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 0, 0, 0, 0, 198, 198, 0, 0, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
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
