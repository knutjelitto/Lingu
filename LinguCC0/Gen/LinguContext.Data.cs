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
                    4, 9, 9, 9, 6, 4, 10, 10, 10, 11, 11, 11, 12, 12, 9, 9, 9, 9, 13, 13, 13, 13, 13, 13, 13, 9, 13, 13,
                    2, 14, 14, 15, 16, 11, 12, 12, 17, 10, 10, 10, 10, 10, 16, 16, 16, 16, 18, 10, 16, 16, 19, 16, 16, 19,
                    20, 21, 5, 5, 6, 12, 9, 9, 9, 22, 9, 22, 9, 8, 13, 13, 23, 24, 24, 15, 15, 15, 15, 25, 25, 25, 25, 25,
                    25, 25, 15, 25, 25, 2, 14, 14, 15, 6, 12, 10, 26, 10, 27, 10, 10, 10, 28, 10, 29, 23, 24, 24, 30, 20,
                    20, 20, 20, 20, 29, 29, 29, 29, 18, 20, 29, 29, 31, 29, 29, 31, 20, 21, 16, 9, 12, 9, 9, 9, 9, 9, 18,
                    9, 9, 32, 9, 9, 32, 20, 21, 9, 33, 33, 33, 13, 24, 15, 15, 15, 22, 15, 22, 15, 8, 25, 25, 23, 10, 12,
                    34, 12, 26, 26, 26, 26, 26, 34, 34, 34, 34, 18, 26, 34, 34, 35, 34, 34, 35, 20, 21, 36, 16, 16, 16, 16,
                    24, 20, 37, 20, 27, 20, 20, 20, 28, 20, 23, 29, 12, 28, 23, 9, 38, 39, 39, 33, 33, 33, 33, 40, 40, 40,
                    40, 40, 40, 40, 33, 40, 40, 2, 14, 14, 15, 15, 24, 15, 15, 15, 15, 15, 18, 15, 15, 41, 15, 15, 41, 20,
                    21, 15, 33, 25, 12, 26, 27, 26, 26, 26, 28, 26, 23, 34, 38, 27, 20, 24, 42, 24, 37, 37, 37, 37, 37, 42,
                    42, 42, 42, 18, 37, 42, 42, 43, 42, 42, 43, 20, 21, 36, 29, 29, 29, 29, 9, 9, 9, 9, 13, 39, 33, 33, 33,
                    22, 33, 22, 33, 8, 40, 40, 23, 24, 28, 23, 15, 38, 36, 34, 34, 34, 34, 10, 38, 24, 37, 27, 37, 37, 37,
                    28, 37, 23, 42, 38, 33, 39, 33, 33, 33, 33, 33, 18, 33, 33, 44, 33, 33, 44, 20, 21, 33, 33, 40, 15, 15,
                    15, 15, 25, 38, 36, 42, 42, 42, 42, 20, 39, 28, 23, 33, 38, 26, 38, 33, 33, 33, 33, 40, 37,
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
                var states1 = new DfaState[1] {new DfaState(0,true,32)};
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
                var states4 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,false,-1), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,true,10), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,true,15), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,false,-1), new DfaState(16,false,-1), new DfaState(17,false,-1), new DfaState(18,false,-1), new DfaState(19,false,-1), new DfaState(20,false,-1), new DfaState(21,true,26), new DfaState(22,true,9)};
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
                var states8 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,31), new DfaState(3,true,30)};
                states8[0].Transitions = new DfaTrans[2] {new DfaTrans(states8[1], sets[20]), new DfaTrans(states8[3], sets[21])};
                states8[1].Transitions = new DfaTrans[1] {new DfaTrans(states8[2], sets[22])};
                states8[2].Transitions = Array.Empty<DfaTrans>();
                states8[3].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa  9 -- ˈtextˈ | '(' | ',' | ';' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states9 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,22), new DfaState(15,true,13), new DfaState(16,true,0), new DfaState(17,true,23), new DfaState(18,true,8), new DfaState(19,true,16)};
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
                var states10 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,27), new DfaState(15,true,2), new DfaState(16,true,13), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,16), new DfaState(46,true,28)};
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
                
                /* dfa 13 -- ˈtextˈ | '(' | '*' | '*:' | '+' | '+:' | ',' | ';' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states13 = new DfaState[25] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,20), new DfaState(17,true,21), new DfaState(18,true,22), new DfaState(19,true,13), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,23), new DfaState(23,true,8), new DfaState(24,true,16)};
                states13[0].Transitions = new DfaTrans[11] {new DfaTrans(states13[1], sets[23]), new DfaTrans(states13[13], sets[24]), new DfaTrans(states13[14], sets[42]), new DfaTrans(states13[16], sets[37]), new DfaTrans(states13[18], sets[25]), new DfaTrans(states13[19], sets[26]), new DfaTrans(states13[20], sets[43]), new DfaTrans(states13[21], sets[4]), new DfaTrans(states13[22], sets[27]), new DfaTrans(states13[23], sets[6]), new DfaTrans(states13[24], sets[28])};
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
                states13[14].Transitions = new DfaTrans[1] {new DfaTrans(states13[15], sets[21])};
                states13[15].Transitions = Array.Empty<DfaTrans>();
                states13[16].Transitions = new DfaTrans[1] {new DfaTrans(states13[17], sets[21])};
                states13[17].Transitions = Array.Empty<DfaTrans>();
                states13[18].Transitions = Array.Empty<DfaTrans>();
                states13[19].Transitions = Array.Empty<DfaTrans>();
                states13[20].Transitions = Array.Empty<DfaTrans>();
                states13[21].Transitions = new DfaTrans[1] {new DfaTrans(states13[21], sets[5])};
                states13[22].Transitions = Array.Empty<DfaTrans>();
                states13[23].Transitions = Array.Empty<DfaTrans>();
                states13[24].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 14 -- ˈtextˈ | '(' | ˈidentifierˈ | '{' -- */
                var states14 = new DfaState[16] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,0), new DfaState(15,true,8)};
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
                var states15 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,22), new DfaState(16,true,0), new DfaState(17,true,23), new DfaState(18,true,8), new DfaState(19,true,16)};
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
                var states16 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,18), new DfaState(15,true,20), new DfaState(16,true,27), new DfaState(17,true,2), new DfaState(18,true,13), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,28)};
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
                var states17 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,27), new DfaState(2,true,13), new DfaState(3,true,16)};
                states17[0].Transitions = new DfaTrans[3] {new DfaTrans(states17[1], sets[20]), new DfaTrans(states17[2], sets[26]), new DfaTrans(states17[3], sets[28])};
                states17[1].Transitions = Array.Empty<DfaTrans>();
                states17[2].Transitions = Array.Empty<DfaTrans>();
                states17[3].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 18 -- '..' -- */
                var states18 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,29)};
                states18[0].Transitions = new DfaTrans[1] {new DfaTrans(states18[1], sets[33])};
                states18[1].Transitions = new DfaTrans[1] {new DfaTrans(states18[2], sets[33])};
                states18[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 19 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states19 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,18), new DfaState(15,true,20), new DfaState(16,true,27), new DfaState(17,true,2), new DfaState(18,true,29), new DfaState(19,true,13), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,16), new DfaState(51,true,28)};
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
                var states20 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,27), new DfaState(16,true,2), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,16), new DfaState(46,true,28)};
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
                
                /* dfa 22 -- ˈtextˈ | '(' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '~' -- */
                var states22 = new DfaState[44] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,2), new DfaState(15,true,0), new DfaState(16,true,0), new DfaState(17,false,-1), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,true,4), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,5), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,true,28)};
                states22[0].Transitions = new DfaTrans[7] {new DfaTrans(states22[1], sets[23]), new DfaTrans(states22[13], sets[24]), new DfaTrans(states22[14], sets[33]), new DfaTrans(states22[15], sets[34]), new DfaTrans(states22[16], sets[35]), new DfaTrans(states22[24], sets[30]), new DfaTrans(states22[43], sets[36])};
                states22[1].Transitions = new DfaTrans[2] {new DfaTrans(states22[2], sets[29]), new DfaTrans(states22[4], sets[30])};
                states22[2].Transitions = new DfaTrans[3] {new DfaTrans(states22[2], sets[29]), new DfaTrans(states22[3], sets[23]), new DfaTrans(states22[4], sets[30])};
                states22[3].Transitions = Array.Empty<DfaTrans>();
                states22[4].Transitions = new DfaTrans[2] {new DfaTrans(states22[2], sets[31]), new DfaTrans(states22[5], sets[14])};
                states22[5].Transitions = new DfaTrans[1] {new DfaTrans(states22[6], sets[6])};
                states22[6].Transitions = new DfaTrans[1] {new DfaTrans(states22[7], sets[32])};
                states22[7].Transitions = new DfaTrans[2] {new DfaTrans(states22[8], sets[32]), new DfaTrans(states22[2], sets[9])};
                states22[8].Transitions = new DfaTrans[2] {new DfaTrans(states22[9], sets[32]), new DfaTrans(states22[2], sets[9])};
                states22[9].Transitions = new DfaTrans[2] {new DfaTrans(states22[10], sets[32]), new DfaTrans(states22[2], sets[9])};
                states22[10].Transitions = new DfaTrans[2] {new DfaTrans(states22[11], sets[32]), new DfaTrans(states22[2], sets[9])};
                states22[11].Transitions = new DfaTrans[2] {new DfaTrans(states22[12], sets[32]), new DfaTrans(states22[2], sets[9])};
                states22[12].Transitions = new DfaTrans[1] {new DfaTrans(states22[2], sets[9])};
                states22[13].Transitions = Array.Empty<DfaTrans>();
                states22[14].Transitions = Array.Empty<DfaTrans>();
                states22[15].Transitions = new DfaTrans[1] {new DfaTrans(states22[15], sets[5])};
                states22[16].Transitions = new DfaTrans[2] {new DfaTrans(states22[17], sets[37]), new DfaTrans(states22[15], sets[5])};
                states22[17].Transitions = new DfaTrans[1] {new DfaTrans(states22[18], sets[32])};
                states22[18].Transitions = new DfaTrans[1] {new DfaTrans(states22[19], sets[32])};
                states22[19].Transitions = new DfaTrans[1] {new DfaTrans(states22[20], sets[32])};
                states22[20].Transitions = new DfaTrans[1] {new DfaTrans(states22[21], sets[32])};
                states22[21].Transitions = new DfaTrans[1] {new DfaTrans(states22[22], sets[32])};
                states22[22].Transitions = new DfaTrans[1] {new DfaTrans(states22[23], sets[32])};
                states22[23].Transitions = Array.Empty<DfaTrans>();
                states22[24].Transitions = new DfaTrans[1] {new DfaTrans(states22[25], sets[14])};
                states22[25].Transitions = new DfaTrans[3] {new DfaTrans(states22[26], sets[38]), new DfaTrans(states22[31], sets[18]), new DfaTrans(states22[36], sets[6])};
                states22[26].Transitions = new DfaTrans[1] {new DfaTrans(states22[27], sets[6])};
                states22[27].Transitions = new DfaTrans[1] {new DfaTrans(states22[28], sets[39])};
                states22[28].Transitions = new DfaTrans[3] {new DfaTrans(states22[29], sets[40]), new DfaTrans(states22[28], sets[41]), new DfaTrans(states22[30], sets[9])};
                states22[29].Transitions = new DfaTrans[2] {new DfaTrans(states22[29], sets[40]), new DfaTrans(states22[28], sets[41])};
                states22[30].Transitions = Array.Empty<DfaTrans>();
                states22[31].Transitions = new DfaTrans[1] {new DfaTrans(states22[32], sets[6])};
                states22[32].Transitions = new DfaTrans[1] {new DfaTrans(states22[33], sets[39])};
                states22[33].Transitions = new DfaTrans[3] {new DfaTrans(states22[34], sets[40]), new DfaTrans(states22[33], sets[41]), new DfaTrans(states22[35], sets[9])};
                states22[34].Transitions = new DfaTrans[2] {new DfaTrans(states22[34], sets[40]), new DfaTrans(states22[33], sets[41])};
                states22[35].Transitions = Array.Empty<DfaTrans>();
                states22[36].Transitions = new DfaTrans[1] {new DfaTrans(states22[37], sets[32])};
                states22[37].Transitions = new DfaTrans[2] {new DfaTrans(states22[38], sets[32]), new DfaTrans(states22[23], sets[9])};
                states22[38].Transitions = new DfaTrans[2] {new DfaTrans(states22[39], sets[32]), new DfaTrans(states22[23], sets[9])};
                states22[39].Transitions = new DfaTrans[2] {new DfaTrans(states22[40], sets[32]), new DfaTrans(states22[23], sets[9])};
                states22[40].Transitions = new DfaTrans[2] {new DfaTrans(states22[41], sets[32]), new DfaTrans(states22[23], sets[9])};
                states22[41].Transitions = new DfaTrans[2] {new DfaTrans(states22[42], sets[32]), new DfaTrans(states22[23], sets[9])};
                states22[42].Transitions = new DfaTrans[1] {new DfaTrans(states22[23], sets[9])};
                states22[43].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 23 -- ')' -- */
                var states23 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,25)};
                states23[0].Transitions = new DfaTrans[1] {new DfaTrans(states23[1], sets[44])};
                states23[1].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 24 -- ')' | '|' -- */
                var states24 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,25), new DfaState(2,true,16)};
                states24[0].Transitions = new DfaTrans[2] {new DfaTrans(states24[1], sets[44]), new DfaTrans(states24[2], sets[28])};
                states24[1].Transitions = Array.Empty<DfaTrans>();
                states24[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 25 -- ˈtextˈ | '(' | ')' | '*' | '*:' | '+' | '+:' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states25 = new DfaState[25] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,20), new DfaState(18,true,21), new DfaState(19,true,22), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,23), new DfaState(23,true,8), new DfaState(24,true,16)};
                states25[0].Transitions = new DfaTrans[11] {new DfaTrans(states25[1], sets[23]), new DfaTrans(states25[13], sets[24]), new DfaTrans(states25[14], sets[44]), new DfaTrans(states25[15], sets[42]), new DfaTrans(states25[17], sets[37]), new DfaTrans(states25[19], sets[25]), new DfaTrans(states25[20], sets[43]), new DfaTrans(states25[21], sets[4]), new DfaTrans(states25[22], sets[27]), new DfaTrans(states25[23], sets[6]), new DfaTrans(states25[24], sets[28])};
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
                states25[15].Transitions = new DfaTrans[1] {new DfaTrans(states25[16], sets[21])};
                states25[16].Transitions = Array.Empty<DfaTrans>();
                states25[17].Transitions = new DfaTrans[1] {new DfaTrans(states25[18], sets[21])};
                states25[18].Transitions = Array.Empty<DfaTrans>();
                states25[19].Transitions = Array.Empty<DfaTrans>();
                states25[20].Transitions = Array.Empty<DfaTrans>();
                states25[21].Transitions = new DfaTrans[1] {new DfaTrans(states25[21], sets[5])};
                states25[22].Transitions = Array.Empty<DfaTrans>();
                states25[23].Transitions = Array.Empty<DfaTrans>();
                states25[24].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 26 -- ˈtextˈ | '(' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states26 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,2), new DfaState(15,true,13), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,16), new DfaState(45,true,28)};
                states26[0].Transitions = new DfaTrans[9] {new DfaTrans(states26[1], sets[23]), new DfaTrans(states26[13], sets[24]), new DfaTrans(states26[14], sets[33]), new DfaTrans(states26[15], sets[26]), new DfaTrans(states26[16], sets[34]), new DfaTrans(states26[17], sets[35]), new DfaTrans(states26[25], sets[30]), new DfaTrans(states26[44], sets[28]), new DfaTrans(states26[45], sets[36])};
                states26[1].Transitions = new DfaTrans[2] {new DfaTrans(states26[2], sets[29]), new DfaTrans(states26[4], sets[30])};
                states26[2].Transitions = new DfaTrans[3] {new DfaTrans(states26[2], sets[29]), new DfaTrans(states26[3], sets[23]), new DfaTrans(states26[4], sets[30])};
                states26[3].Transitions = Array.Empty<DfaTrans>();
                states26[4].Transitions = new DfaTrans[2] {new DfaTrans(states26[2], sets[31]), new DfaTrans(states26[5], sets[14])};
                states26[5].Transitions = new DfaTrans[1] {new DfaTrans(states26[6], sets[6])};
                states26[6].Transitions = new DfaTrans[1] {new DfaTrans(states26[7], sets[32])};
                states26[7].Transitions = new DfaTrans[2] {new DfaTrans(states26[8], sets[32]), new DfaTrans(states26[2], sets[9])};
                states26[8].Transitions = new DfaTrans[2] {new DfaTrans(states26[9], sets[32]), new DfaTrans(states26[2], sets[9])};
                states26[9].Transitions = new DfaTrans[2] {new DfaTrans(states26[10], sets[32]), new DfaTrans(states26[2], sets[9])};
                states26[10].Transitions = new DfaTrans[2] {new DfaTrans(states26[11], sets[32]), new DfaTrans(states26[2], sets[9])};
                states26[11].Transitions = new DfaTrans[2] {new DfaTrans(states26[12], sets[32]), new DfaTrans(states26[2], sets[9])};
                states26[12].Transitions = new DfaTrans[1] {new DfaTrans(states26[2], sets[9])};
                states26[13].Transitions = Array.Empty<DfaTrans>();
                states26[14].Transitions = Array.Empty<DfaTrans>();
                states26[15].Transitions = Array.Empty<DfaTrans>();
                states26[16].Transitions = new DfaTrans[1] {new DfaTrans(states26[16], sets[5])};
                states26[17].Transitions = new DfaTrans[2] {new DfaTrans(states26[18], sets[37]), new DfaTrans(states26[16], sets[5])};
                states26[18].Transitions = new DfaTrans[1] {new DfaTrans(states26[19], sets[32])};
                states26[19].Transitions = new DfaTrans[1] {new DfaTrans(states26[20], sets[32])};
                states26[20].Transitions = new DfaTrans[1] {new DfaTrans(states26[21], sets[32])};
                states26[21].Transitions = new DfaTrans[1] {new DfaTrans(states26[22], sets[32])};
                states26[22].Transitions = new DfaTrans[1] {new DfaTrans(states26[23], sets[32])};
                states26[23].Transitions = new DfaTrans[1] {new DfaTrans(states26[24], sets[32])};
                states26[24].Transitions = Array.Empty<DfaTrans>();
                states26[25].Transitions = new DfaTrans[1] {new DfaTrans(states26[26], sets[14])};
                states26[26].Transitions = new DfaTrans[3] {new DfaTrans(states26[27], sets[38]), new DfaTrans(states26[32], sets[18]), new DfaTrans(states26[37], sets[6])};
                states26[27].Transitions = new DfaTrans[1] {new DfaTrans(states26[28], sets[6])};
                states26[28].Transitions = new DfaTrans[1] {new DfaTrans(states26[29], sets[39])};
                states26[29].Transitions = new DfaTrans[3] {new DfaTrans(states26[30], sets[40]), new DfaTrans(states26[29], sets[41]), new DfaTrans(states26[31], sets[9])};
                states26[30].Transitions = new DfaTrans[2] {new DfaTrans(states26[30], sets[40]), new DfaTrans(states26[29], sets[41])};
                states26[31].Transitions = Array.Empty<DfaTrans>();
                states26[32].Transitions = new DfaTrans[1] {new DfaTrans(states26[33], sets[6])};
                states26[33].Transitions = new DfaTrans[1] {new DfaTrans(states26[34], sets[39])};
                states26[34].Transitions = new DfaTrans[3] {new DfaTrans(states26[35], sets[40]), new DfaTrans(states26[34], sets[41]), new DfaTrans(states26[36], sets[9])};
                states26[35].Transitions = new DfaTrans[2] {new DfaTrans(states26[35], sets[40]), new DfaTrans(states26[34], sets[41])};
                states26[36].Transitions = Array.Empty<DfaTrans>();
                states26[37].Transitions = new DfaTrans[1] {new DfaTrans(states26[38], sets[32])};
                states26[38].Transitions = new DfaTrans[2] {new DfaTrans(states26[39], sets[32]), new DfaTrans(states26[24], sets[9])};
                states26[39].Transitions = new DfaTrans[2] {new DfaTrans(states26[40], sets[32]), new DfaTrans(states26[24], sets[9])};
                states26[40].Transitions = new DfaTrans[2] {new DfaTrans(states26[41], sets[32]), new DfaTrans(states26[24], sets[9])};
                states26[41].Transitions = new DfaTrans[2] {new DfaTrans(states26[42], sets[32]), new DfaTrans(states26[24], sets[9])};
                states26[42].Transitions = new DfaTrans[2] {new DfaTrans(states26[43], sets[32]), new DfaTrans(states26[24], sets[9])};
                states26[43].Transitions = new DfaTrans[1] {new DfaTrans(states26[24], sets[9])};
                states26[44].Transitions = Array.Empty<DfaTrans>();
                states26[45].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 27 -- ˈnumberˈ -- */
                var states27 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,1), new DfaState(2,true,1)};
                states27[0].Transitions = new DfaTrans[2] {new DfaTrans(states27[1], sets[45]), new DfaTrans(states27[2], sets[46])};
                states27[1].Transitions = Array.Empty<DfaTrans>();
                states27[2].Transitions = new DfaTrans[1] {new DfaTrans(states27[2], sets[47])};
                
                /* dfa 28 -- ˈtextˈ | ˈucCodepointˈ -- */
                var states28 = new DfaState[30] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,true,6), new DfaState(16,true,6), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,false,-1), new DfaState(22,false,-1), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1)};
                states28[0].Transitions = new DfaTrans[3] {new DfaTrans(states28[1], sets[23]), new DfaTrans(states28[13], sets[35]), new DfaTrans(states28[21], sets[30])};
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
                states28[13].Transitions = new DfaTrans[1] {new DfaTrans(states28[14], sets[37])};
                states28[14].Transitions = new DfaTrans[1] {new DfaTrans(states28[15], sets[32])};
                states28[15].Transitions = new DfaTrans[1] {new DfaTrans(states28[16], sets[32])};
                states28[16].Transitions = new DfaTrans[1] {new DfaTrans(states28[17], sets[32])};
                states28[17].Transitions = new DfaTrans[1] {new DfaTrans(states28[18], sets[32])};
                states28[18].Transitions = new DfaTrans[1] {new DfaTrans(states28[19], sets[32])};
                states28[19].Transitions = new DfaTrans[1] {new DfaTrans(states28[20], sets[32])};
                states28[20].Transitions = Array.Empty<DfaTrans>();
                states28[21].Transitions = new DfaTrans[1] {new DfaTrans(states28[22], sets[14])};
                states28[22].Transitions = new DfaTrans[1] {new DfaTrans(states28[23], sets[6])};
                states28[23].Transitions = new DfaTrans[1] {new DfaTrans(states28[24], sets[32])};
                states28[24].Transitions = new DfaTrans[2] {new DfaTrans(states28[25], sets[32]), new DfaTrans(states28[20], sets[9])};
                states28[25].Transitions = new DfaTrans[2] {new DfaTrans(states28[26], sets[32]), new DfaTrans(states28[20], sets[9])};
                states28[26].Transitions = new DfaTrans[2] {new DfaTrans(states28[27], sets[32]), new DfaTrans(states28[20], sets[9])};
                states28[27].Transitions = new DfaTrans[2] {new DfaTrans(states28[28], sets[32]), new DfaTrans(states28[20], sets[9])};
                states28[28].Transitions = new DfaTrans[2] {new DfaTrans(states28[29], sets[32]), new DfaTrans(states28[20], sets[9])};
                states28[29].Transitions = new DfaTrans[1] {new DfaTrans(states28[20], sets[9])};
                
                /* dfa 29 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states29 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,18), new DfaState(16,true,20), new DfaState(17,true,27), new DfaState(18,true,2), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,28)};
                states29[0].Transitions = new DfaTrans[14] {new DfaTrans(states29[1], sets[23]), new DfaTrans(states29[13], sets[24]), new DfaTrans(states29[14], sets[44]), new DfaTrans(states29[15], sets[42]), new DfaTrans(states29[16], sets[37]), new DfaTrans(states29[17], sets[20]), new DfaTrans(states29[18], sets[33]), new DfaTrans(states29[19], sets[43]), new DfaTrans(states29[20], sets[34]), new DfaTrans(states29[21], sets[35]), new DfaTrans(states29[29], sets[30]), new DfaTrans(states29[48], sets[6]), new DfaTrans(states29[49], sets[28]), new DfaTrans(states29[50], sets[36])};
                states29[1].Transitions = new DfaTrans[2] {new DfaTrans(states29[2], sets[29]), new DfaTrans(states29[4], sets[30])};
                states29[2].Transitions = new DfaTrans[3] {new DfaTrans(states29[2], sets[29]), new DfaTrans(states29[3], sets[23]), new DfaTrans(states29[4], sets[30])};
                states29[3].Transitions = Array.Empty<DfaTrans>();
                states29[4].Transitions = new DfaTrans[2] {new DfaTrans(states29[2], sets[31]), new DfaTrans(states29[5], sets[14])};
                states29[5].Transitions = new DfaTrans[1] {new DfaTrans(states29[6], sets[6])};
                states29[6].Transitions = new DfaTrans[1] {new DfaTrans(states29[7], sets[32])};
                states29[7].Transitions = new DfaTrans[2] {new DfaTrans(states29[8], sets[32]), new DfaTrans(states29[2], sets[9])};
                states29[8].Transitions = new DfaTrans[2] {new DfaTrans(states29[9], sets[32]), new DfaTrans(states29[2], sets[9])};
                states29[9].Transitions = new DfaTrans[2] {new DfaTrans(states29[10], sets[32]), new DfaTrans(states29[2], sets[9])};
                states29[10].Transitions = new DfaTrans[2] {new DfaTrans(states29[11], sets[32]), new DfaTrans(states29[2], sets[9])};
                states29[11].Transitions = new DfaTrans[2] {new DfaTrans(states29[12], sets[32]), new DfaTrans(states29[2], sets[9])};
                states29[12].Transitions = new DfaTrans[1] {new DfaTrans(states29[2], sets[9])};
                states29[13].Transitions = Array.Empty<DfaTrans>();
                states29[14].Transitions = Array.Empty<DfaTrans>();
                states29[15].Transitions = Array.Empty<DfaTrans>();
                states29[16].Transitions = Array.Empty<DfaTrans>();
                states29[17].Transitions = Array.Empty<DfaTrans>();
                states29[18].Transitions = Array.Empty<DfaTrans>();
                states29[19].Transitions = Array.Empty<DfaTrans>();
                states29[20].Transitions = new DfaTrans[1] {new DfaTrans(states29[20], sets[5])};
                states29[21].Transitions = new DfaTrans[2] {new DfaTrans(states29[22], sets[37]), new DfaTrans(states29[20], sets[5])};
                states29[22].Transitions = new DfaTrans[1] {new DfaTrans(states29[23], sets[32])};
                states29[23].Transitions = new DfaTrans[1] {new DfaTrans(states29[24], sets[32])};
                states29[24].Transitions = new DfaTrans[1] {new DfaTrans(states29[25], sets[32])};
                states29[25].Transitions = new DfaTrans[1] {new DfaTrans(states29[26], sets[32])};
                states29[26].Transitions = new DfaTrans[1] {new DfaTrans(states29[27], sets[32])};
                states29[27].Transitions = new DfaTrans[1] {new DfaTrans(states29[28], sets[32])};
                states29[28].Transitions = Array.Empty<DfaTrans>();
                states29[29].Transitions = new DfaTrans[1] {new DfaTrans(states29[30], sets[14])};
                states29[30].Transitions = new DfaTrans[3] {new DfaTrans(states29[31], sets[38]), new DfaTrans(states29[36], sets[18]), new DfaTrans(states29[41], sets[6])};
                states29[31].Transitions = new DfaTrans[1] {new DfaTrans(states29[32], sets[6])};
                states29[32].Transitions = new DfaTrans[1] {new DfaTrans(states29[33], sets[39])};
                states29[33].Transitions = new DfaTrans[3] {new DfaTrans(states29[34], sets[40]), new DfaTrans(states29[33], sets[41]), new DfaTrans(states29[35], sets[9])};
                states29[34].Transitions = new DfaTrans[2] {new DfaTrans(states29[34], sets[40]), new DfaTrans(states29[33], sets[41])};
                states29[35].Transitions = Array.Empty<DfaTrans>();
                states29[36].Transitions = new DfaTrans[1] {new DfaTrans(states29[37], sets[6])};
                states29[37].Transitions = new DfaTrans[1] {new DfaTrans(states29[38], sets[39])};
                states29[38].Transitions = new DfaTrans[3] {new DfaTrans(states29[39], sets[40]), new DfaTrans(states29[38], sets[41]), new DfaTrans(states29[40], sets[9])};
                states29[39].Transitions = new DfaTrans[2] {new DfaTrans(states29[39], sets[40]), new DfaTrans(states29[38], sets[41])};
                states29[40].Transitions = Array.Empty<DfaTrans>();
                states29[41].Transitions = new DfaTrans[1] {new DfaTrans(states29[42], sets[32])};
                states29[42].Transitions = new DfaTrans[2] {new DfaTrans(states29[43], sets[32]), new DfaTrans(states29[28], sets[9])};
                states29[43].Transitions = new DfaTrans[2] {new DfaTrans(states29[44], sets[32]), new DfaTrans(states29[28], sets[9])};
                states29[44].Transitions = new DfaTrans[2] {new DfaTrans(states29[45], sets[32]), new DfaTrans(states29[28], sets[9])};
                states29[45].Transitions = new DfaTrans[2] {new DfaTrans(states29[46], sets[32]), new DfaTrans(states29[28], sets[9])};
                states29[46].Transitions = new DfaTrans[2] {new DfaTrans(states29[47], sets[32]), new DfaTrans(states29[28], sets[9])};
                states29[47].Transitions = new DfaTrans[1] {new DfaTrans(states29[28], sets[9])};
                states29[48].Transitions = Array.Empty<DfaTrans>();
                states29[49].Transitions = Array.Empty<DfaTrans>();
                states29[50].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 30 -- ')' | '-' | '|' -- */
                var states30 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,25), new DfaState(2,true,27), new DfaState(3,true,16)};
                states30[0].Transitions = new DfaTrans[3] {new DfaTrans(states30[1], sets[44]), new DfaTrans(states30[2], sets[20]), new DfaTrans(states30[3], sets[28])};
                states30[1].Transitions = Array.Empty<DfaTrans>();
                states30[2].Transitions = Array.Empty<DfaTrans>();
                states30[3].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 31 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states31 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,18), new DfaState(16,true,20), new DfaState(17,true,27), new DfaState(18,true,2), new DfaState(19,true,29), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,16), new DfaState(51,true,28)};
                states31[0].Transitions = new DfaTrans[14] {new DfaTrans(states31[1], sets[23]), new DfaTrans(states31[13], sets[24]), new DfaTrans(states31[14], sets[44]), new DfaTrans(states31[15], sets[42]), new DfaTrans(states31[16], sets[37]), new DfaTrans(states31[17], sets[20]), new DfaTrans(states31[18], sets[33]), new DfaTrans(states31[20], sets[43]), new DfaTrans(states31[21], sets[34]), new DfaTrans(states31[22], sets[35]), new DfaTrans(states31[30], sets[30]), new DfaTrans(states31[49], sets[6]), new DfaTrans(states31[50], sets[28]), new DfaTrans(states31[51], sets[36])};
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
                states31[15].Transitions = Array.Empty<DfaTrans>();
                states31[16].Transitions = Array.Empty<DfaTrans>();
                states31[17].Transitions = Array.Empty<DfaTrans>();
                states31[18].Transitions = new DfaTrans[1] {new DfaTrans(states31[19], sets[33])};
                states31[19].Transitions = Array.Empty<DfaTrans>();
                states31[20].Transitions = Array.Empty<DfaTrans>();
                states31[21].Transitions = new DfaTrans[1] {new DfaTrans(states31[21], sets[5])};
                states31[22].Transitions = new DfaTrans[2] {new DfaTrans(states31[23], sets[37]), new DfaTrans(states31[21], sets[5])};
                states31[23].Transitions = new DfaTrans[1] {new DfaTrans(states31[24], sets[32])};
                states31[24].Transitions = new DfaTrans[1] {new DfaTrans(states31[25], sets[32])};
                states31[25].Transitions = new DfaTrans[1] {new DfaTrans(states31[26], sets[32])};
                states31[26].Transitions = new DfaTrans[1] {new DfaTrans(states31[27], sets[32])};
                states31[27].Transitions = new DfaTrans[1] {new DfaTrans(states31[28], sets[32])};
                states31[28].Transitions = new DfaTrans[1] {new DfaTrans(states31[29], sets[32])};
                states31[29].Transitions = Array.Empty<DfaTrans>();
                states31[30].Transitions = new DfaTrans[1] {new DfaTrans(states31[31], sets[14])};
                states31[31].Transitions = new DfaTrans[3] {new DfaTrans(states31[32], sets[38]), new DfaTrans(states31[37], sets[18]), new DfaTrans(states31[42], sets[6])};
                states31[32].Transitions = new DfaTrans[1] {new DfaTrans(states31[33], sets[6])};
                states31[33].Transitions = new DfaTrans[1] {new DfaTrans(states31[34], sets[39])};
                states31[34].Transitions = new DfaTrans[3] {new DfaTrans(states31[35], sets[40]), new DfaTrans(states31[34], sets[41]), new DfaTrans(states31[36], sets[9])};
                states31[35].Transitions = new DfaTrans[2] {new DfaTrans(states31[35], sets[40]), new DfaTrans(states31[34], sets[41])};
                states31[36].Transitions = Array.Empty<DfaTrans>();
                states31[37].Transitions = new DfaTrans[1] {new DfaTrans(states31[38], sets[6])};
                states31[38].Transitions = new DfaTrans[1] {new DfaTrans(states31[39], sets[39])};
                states31[39].Transitions = new DfaTrans[3] {new DfaTrans(states31[40], sets[40]), new DfaTrans(states31[39], sets[41]), new DfaTrans(states31[41], sets[9])};
                states31[40].Transitions = new DfaTrans[2] {new DfaTrans(states31[40], sets[40]), new DfaTrans(states31[39], sets[41])};
                states31[41].Transitions = Array.Empty<DfaTrans>();
                states31[42].Transitions = new DfaTrans[1] {new DfaTrans(states31[43], sets[32])};
                states31[43].Transitions = new DfaTrans[2] {new DfaTrans(states31[44], sets[32]), new DfaTrans(states31[29], sets[9])};
                states31[44].Transitions = new DfaTrans[2] {new DfaTrans(states31[45], sets[32]), new DfaTrans(states31[29], sets[9])};
                states31[45].Transitions = new DfaTrans[2] {new DfaTrans(states31[46], sets[32]), new DfaTrans(states31[29], sets[9])};
                states31[46].Transitions = new DfaTrans[2] {new DfaTrans(states31[47], sets[32]), new DfaTrans(states31[29], sets[9])};
                states31[47].Transitions = new DfaTrans[2] {new DfaTrans(states31[48], sets[32]), new DfaTrans(states31[29], sets[9])};
                states31[48].Transitions = new DfaTrans[1] {new DfaTrans(states31[29], sets[9])};
                states31[49].Transitions = Array.Empty<DfaTrans>();
                states31[50].Transitions = Array.Empty<DfaTrans>();
                states31[51].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 32 -- ˈtextˈ | '(' | ',' | '..' | ';' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states32 = new DfaState[22] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,22), new DfaState(15,false,-1), new DfaState(16,true,29), new DfaState(17,true,13), new DfaState(18,true,0), new DfaState(19,true,23), new DfaState(20,true,8), new DfaState(21,true,16)};
                states32[0].Transitions = new DfaTrans[9] {new DfaTrans(states32[1], sets[23]), new DfaTrans(states32[13], sets[24]), new DfaTrans(states32[14], sets[25]), new DfaTrans(states32[15], sets[33]), new DfaTrans(states32[17], sets[26]), new DfaTrans(states32[18], sets[4]), new DfaTrans(states32[19], sets[27]), new DfaTrans(states32[20], sets[6]), new DfaTrans(states32[21], sets[28])};
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
                states32[15].Transitions = new DfaTrans[1] {new DfaTrans(states32[16], sets[33])};
                states32[16].Transitions = Array.Empty<DfaTrans>();
                states32[17].Transitions = Array.Empty<DfaTrans>();
                states32[18].Transitions = new DfaTrans[1] {new DfaTrans(states32[18], sets[5])};
                states32[19].Transitions = Array.Empty<DfaTrans>();
                states32[20].Transitions = Array.Empty<DfaTrans>();
                states32[21].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 33 -- ˈtextˈ | '(' | ',' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states33 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,22), new DfaState(15,true,0), new DfaState(16,true,23), new DfaState(17,true,8), new DfaState(18,true,16), new DfaState(19,true,9)};
                states33[0].Transitions = new DfaTrans[8] {new DfaTrans(states33[1], sets[23]), new DfaTrans(states33[13], sets[24]), new DfaTrans(states33[14], sets[25]), new DfaTrans(states33[15], sets[4]), new DfaTrans(states33[16], sets[27]), new DfaTrans(states33[17], sets[6]), new DfaTrans(states33[18], sets[28]), new DfaTrans(states33[19], sets[9])};
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
                states33[15].Transitions = new DfaTrans[1] {new DfaTrans(states33[15], sets[5])};
                states33[16].Transitions = Array.Empty<DfaTrans>();
                states33[17].Transitions = Array.Empty<DfaTrans>();
                states33[18].Transitions = Array.Empty<DfaTrans>();
                states33[19].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 34 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states34 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,18), new DfaState(15,true,20), new DfaState(16,true,2), new DfaState(17,true,13), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,16), new DfaState(49,true,28)};
                states34[0].Transitions = new DfaTrans[13] {new DfaTrans(states34[1], sets[23]), new DfaTrans(states34[13], sets[24]), new DfaTrans(states34[14], sets[42]), new DfaTrans(states34[15], sets[37]), new DfaTrans(states34[16], sets[33]), new DfaTrans(states34[17], sets[26]), new DfaTrans(states34[18], sets[43]), new DfaTrans(states34[19], sets[34]), new DfaTrans(states34[20], sets[35]), new DfaTrans(states34[28], sets[30]), new DfaTrans(states34[47], sets[6]), new DfaTrans(states34[48], sets[28]), new DfaTrans(states34[49], sets[36])};
                states34[1].Transitions = new DfaTrans[2] {new DfaTrans(states34[2], sets[29]), new DfaTrans(states34[4], sets[30])};
                states34[2].Transitions = new DfaTrans[3] {new DfaTrans(states34[2], sets[29]), new DfaTrans(states34[3], sets[23]), new DfaTrans(states34[4], sets[30])};
                states34[3].Transitions = Array.Empty<DfaTrans>();
                states34[4].Transitions = new DfaTrans[2] {new DfaTrans(states34[2], sets[31]), new DfaTrans(states34[5], sets[14])};
                states34[5].Transitions = new DfaTrans[1] {new DfaTrans(states34[6], sets[6])};
                states34[6].Transitions = new DfaTrans[1] {new DfaTrans(states34[7], sets[32])};
                states34[7].Transitions = new DfaTrans[2] {new DfaTrans(states34[8], sets[32]), new DfaTrans(states34[2], sets[9])};
                states34[8].Transitions = new DfaTrans[2] {new DfaTrans(states34[9], sets[32]), new DfaTrans(states34[2], sets[9])};
                states34[9].Transitions = new DfaTrans[2] {new DfaTrans(states34[10], sets[32]), new DfaTrans(states34[2], sets[9])};
                states34[10].Transitions = new DfaTrans[2] {new DfaTrans(states34[11], sets[32]), new DfaTrans(states34[2], sets[9])};
                states34[11].Transitions = new DfaTrans[2] {new DfaTrans(states34[12], sets[32]), new DfaTrans(states34[2], sets[9])};
                states34[12].Transitions = new DfaTrans[1] {new DfaTrans(states34[2], sets[9])};
                states34[13].Transitions = Array.Empty<DfaTrans>();
                states34[14].Transitions = Array.Empty<DfaTrans>();
                states34[15].Transitions = Array.Empty<DfaTrans>();
                states34[16].Transitions = Array.Empty<DfaTrans>();
                states34[17].Transitions = Array.Empty<DfaTrans>();
                states34[18].Transitions = Array.Empty<DfaTrans>();
                states34[19].Transitions = new DfaTrans[1] {new DfaTrans(states34[19], sets[5])};
                states34[20].Transitions = new DfaTrans[2] {new DfaTrans(states34[21], sets[37]), new DfaTrans(states34[19], sets[5])};
                states34[21].Transitions = new DfaTrans[1] {new DfaTrans(states34[22], sets[32])};
                states34[22].Transitions = new DfaTrans[1] {new DfaTrans(states34[23], sets[32])};
                states34[23].Transitions = new DfaTrans[1] {new DfaTrans(states34[24], sets[32])};
                states34[24].Transitions = new DfaTrans[1] {new DfaTrans(states34[25], sets[32])};
                states34[25].Transitions = new DfaTrans[1] {new DfaTrans(states34[26], sets[32])};
                states34[26].Transitions = new DfaTrans[1] {new DfaTrans(states34[27], sets[32])};
                states34[27].Transitions = Array.Empty<DfaTrans>();
                states34[28].Transitions = new DfaTrans[1] {new DfaTrans(states34[29], sets[14])};
                states34[29].Transitions = new DfaTrans[3] {new DfaTrans(states34[30], sets[38]), new DfaTrans(states34[35], sets[18]), new DfaTrans(states34[40], sets[6])};
                states34[30].Transitions = new DfaTrans[1] {new DfaTrans(states34[31], sets[6])};
                states34[31].Transitions = new DfaTrans[1] {new DfaTrans(states34[32], sets[39])};
                states34[32].Transitions = new DfaTrans[3] {new DfaTrans(states34[33], sets[40]), new DfaTrans(states34[32], sets[41]), new DfaTrans(states34[34], sets[9])};
                states34[33].Transitions = new DfaTrans[2] {new DfaTrans(states34[33], sets[40]), new DfaTrans(states34[32], sets[41])};
                states34[34].Transitions = Array.Empty<DfaTrans>();
                states34[35].Transitions = new DfaTrans[1] {new DfaTrans(states34[36], sets[6])};
                states34[36].Transitions = new DfaTrans[1] {new DfaTrans(states34[37], sets[39])};
                states34[37].Transitions = new DfaTrans[3] {new DfaTrans(states34[38], sets[40]), new DfaTrans(states34[37], sets[41]), new DfaTrans(states34[39], sets[9])};
                states34[38].Transitions = new DfaTrans[2] {new DfaTrans(states34[38], sets[40]), new DfaTrans(states34[37], sets[41])};
                states34[39].Transitions = Array.Empty<DfaTrans>();
                states34[40].Transitions = new DfaTrans[1] {new DfaTrans(states34[41], sets[32])};
                states34[41].Transitions = new DfaTrans[2] {new DfaTrans(states34[42], sets[32]), new DfaTrans(states34[27], sets[9])};
                states34[42].Transitions = new DfaTrans[2] {new DfaTrans(states34[43], sets[32]), new DfaTrans(states34[27], sets[9])};
                states34[43].Transitions = new DfaTrans[2] {new DfaTrans(states34[44], sets[32]), new DfaTrans(states34[27], sets[9])};
                states34[44].Transitions = new DfaTrans[2] {new DfaTrans(states34[45], sets[32]), new DfaTrans(states34[27], sets[9])};
                states34[45].Transitions = new DfaTrans[2] {new DfaTrans(states34[46], sets[32]), new DfaTrans(states34[27], sets[9])};
                states34[46].Transitions = new DfaTrans[1] {new DfaTrans(states34[27], sets[9])};
                states34[47].Transitions = Array.Empty<DfaTrans>();
                states34[48].Transitions = Array.Empty<DfaTrans>();
                states34[49].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 35 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states35 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,18), new DfaState(15,true,20), new DfaState(16,true,2), new DfaState(17,true,29), new DfaState(18,true,13), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,28)};
                states35[0].Transitions = new DfaTrans[13] {new DfaTrans(states35[1], sets[23]), new DfaTrans(states35[13], sets[24]), new DfaTrans(states35[14], sets[42]), new DfaTrans(states35[15], sets[37]), new DfaTrans(states35[16], sets[33]), new DfaTrans(states35[18], sets[26]), new DfaTrans(states35[19], sets[43]), new DfaTrans(states35[20], sets[34]), new DfaTrans(states35[21], sets[35]), new DfaTrans(states35[29], sets[30]), new DfaTrans(states35[48], sets[6]), new DfaTrans(states35[49], sets[28]), new DfaTrans(states35[50], sets[36])};
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
                states35[16].Transitions = new DfaTrans[1] {new DfaTrans(states35[17], sets[33])};
                states35[17].Transitions = Array.Empty<DfaTrans>();
                states35[18].Transitions = Array.Empty<DfaTrans>();
                states35[19].Transitions = Array.Empty<DfaTrans>();
                states35[20].Transitions = new DfaTrans[1] {new DfaTrans(states35[20], sets[5])};
                states35[21].Transitions = new DfaTrans[2] {new DfaTrans(states35[22], sets[37]), new DfaTrans(states35[20], sets[5])};
                states35[22].Transitions = new DfaTrans[1] {new DfaTrans(states35[23], sets[32])};
                states35[23].Transitions = new DfaTrans[1] {new DfaTrans(states35[24], sets[32])};
                states35[24].Transitions = new DfaTrans[1] {new DfaTrans(states35[25], sets[32])};
                states35[25].Transitions = new DfaTrans[1] {new DfaTrans(states35[26], sets[32])};
                states35[26].Transitions = new DfaTrans[1] {new DfaTrans(states35[27], sets[32])};
                states35[27].Transitions = new DfaTrans[1] {new DfaTrans(states35[28], sets[32])};
                states35[28].Transitions = Array.Empty<DfaTrans>();
                states35[29].Transitions = new DfaTrans[1] {new DfaTrans(states35[30], sets[14])};
                states35[30].Transitions = new DfaTrans[3] {new DfaTrans(states35[31], sets[38]), new DfaTrans(states35[36], sets[18]), new DfaTrans(states35[41], sets[6])};
                states35[31].Transitions = new DfaTrans[1] {new DfaTrans(states35[32], sets[6])};
                states35[32].Transitions = new DfaTrans[1] {new DfaTrans(states35[33], sets[39])};
                states35[33].Transitions = new DfaTrans[3] {new DfaTrans(states35[34], sets[40]), new DfaTrans(states35[33], sets[41]), new DfaTrans(states35[35], sets[9])};
                states35[34].Transitions = new DfaTrans[2] {new DfaTrans(states35[34], sets[40]), new DfaTrans(states35[33], sets[41])};
                states35[35].Transitions = Array.Empty<DfaTrans>();
                states35[36].Transitions = new DfaTrans[1] {new DfaTrans(states35[37], sets[6])};
                states35[37].Transitions = new DfaTrans[1] {new DfaTrans(states35[38], sets[39])};
                states35[38].Transitions = new DfaTrans[3] {new DfaTrans(states35[39], sets[40]), new DfaTrans(states35[38], sets[41]), new DfaTrans(states35[40], sets[9])};
                states35[39].Transitions = new DfaTrans[2] {new DfaTrans(states35[39], sets[40]), new DfaTrans(states35[38], sets[41])};
                states35[40].Transitions = Array.Empty<DfaTrans>();
                states35[41].Transitions = new DfaTrans[1] {new DfaTrans(states35[42], sets[32])};
                states35[42].Transitions = new DfaTrans[2] {new DfaTrans(states35[43], sets[32]), new DfaTrans(states35[28], sets[9])};
                states35[43].Transitions = new DfaTrans[2] {new DfaTrans(states35[44], sets[32]), new DfaTrans(states35[28], sets[9])};
                states35[44].Transitions = new DfaTrans[2] {new DfaTrans(states35[45], sets[32]), new DfaTrans(states35[28], sets[9])};
                states35[45].Transitions = new DfaTrans[2] {new DfaTrans(states35[46], sets[32]), new DfaTrans(states35[28], sets[9])};
                states35[46].Transitions = new DfaTrans[2] {new DfaTrans(states35[47], sets[32]), new DfaTrans(states35[28], sets[9])};
                states35[47].Transitions = new DfaTrans[1] {new DfaTrans(states35[28], sets[9])};
                states35[48].Transitions = Array.Empty<DfaTrans>();
                states35[49].Transitions = Array.Empty<DfaTrans>();
                states35[50].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 36 -- ',' | '}' -- */
                var states36 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,22), new DfaState(2,true,9)};
                states36[0].Transitions = new DfaTrans[2] {new DfaTrans(states36[1], sets[25]), new DfaTrans(states36[2], sets[9])};
                states36[1].Transitions = Array.Empty<DfaTrans>();
                states36[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 37 -- ˈtextˈ | '(' | ')' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states37 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,2), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,16), new DfaState(45,true,28)};
                states37[0].Transitions = new DfaTrans[9] {new DfaTrans(states37[1], sets[23]), new DfaTrans(states37[13], sets[24]), new DfaTrans(states37[14], sets[44]), new DfaTrans(states37[15], sets[33]), new DfaTrans(states37[16], sets[34]), new DfaTrans(states37[17], sets[35]), new DfaTrans(states37[25], sets[30]), new DfaTrans(states37[44], sets[28]), new DfaTrans(states37[45], sets[36])};
                states37[1].Transitions = new DfaTrans[2] {new DfaTrans(states37[2], sets[29]), new DfaTrans(states37[4], sets[30])};
                states37[2].Transitions = new DfaTrans[3] {new DfaTrans(states37[2], sets[29]), new DfaTrans(states37[3], sets[23]), new DfaTrans(states37[4], sets[30])};
                states37[3].Transitions = Array.Empty<DfaTrans>();
                states37[4].Transitions = new DfaTrans[2] {new DfaTrans(states37[2], sets[31]), new DfaTrans(states37[5], sets[14])};
                states37[5].Transitions = new DfaTrans[1] {new DfaTrans(states37[6], sets[6])};
                states37[6].Transitions = new DfaTrans[1] {new DfaTrans(states37[7], sets[32])};
                states37[7].Transitions = new DfaTrans[2] {new DfaTrans(states37[8], sets[32]), new DfaTrans(states37[2], sets[9])};
                states37[8].Transitions = new DfaTrans[2] {new DfaTrans(states37[9], sets[32]), new DfaTrans(states37[2], sets[9])};
                states37[9].Transitions = new DfaTrans[2] {new DfaTrans(states37[10], sets[32]), new DfaTrans(states37[2], sets[9])};
                states37[10].Transitions = new DfaTrans[2] {new DfaTrans(states37[11], sets[32]), new DfaTrans(states37[2], sets[9])};
                states37[11].Transitions = new DfaTrans[2] {new DfaTrans(states37[12], sets[32]), new DfaTrans(states37[2], sets[9])};
                states37[12].Transitions = new DfaTrans[1] {new DfaTrans(states37[2], sets[9])};
                states37[13].Transitions = Array.Empty<DfaTrans>();
                states37[14].Transitions = Array.Empty<DfaTrans>();
                states37[15].Transitions = Array.Empty<DfaTrans>();
                states37[16].Transitions = new DfaTrans[1] {new DfaTrans(states37[16], sets[5])};
                states37[17].Transitions = new DfaTrans[2] {new DfaTrans(states37[18], sets[37]), new DfaTrans(states37[16], sets[5])};
                states37[18].Transitions = new DfaTrans[1] {new DfaTrans(states37[19], sets[32])};
                states37[19].Transitions = new DfaTrans[1] {new DfaTrans(states37[20], sets[32])};
                states37[20].Transitions = new DfaTrans[1] {new DfaTrans(states37[21], sets[32])};
                states37[21].Transitions = new DfaTrans[1] {new DfaTrans(states37[22], sets[32])};
                states37[22].Transitions = new DfaTrans[1] {new DfaTrans(states37[23], sets[32])};
                states37[23].Transitions = new DfaTrans[1] {new DfaTrans(states37[24], sets[32])};
                states37[24].Transitions = Array.Empty<DfaTrans>();
                states37[25].Transitions = new DfaTrans[1] {new DfaTrans(states37[26], sets[14])};
                states37[26].Transitions = new DfaTrans[3] {new DfaTrans(states37[27], sets[38]), new DfaTrans(states37[32], sets[18]), new DfaTrans(states37[37], sets[6])};
                states37[27].Transitions = new DfaTrans[1] {new DfaTrans(states37[28], sets[6])};
                states37[28].Transitions = new DfaTrans[1] {new DfaTrans(states37[29], sets[39])};
                states37[29].Transitions = new DfaTrans[3] {new DfaTrans(states37[30], sets[40]), new DfaTrans(states37[29], sets[41]), new DfaTrans(states37[31], sets[9])};
                states37[30].Transitions = new DfaTrans[2] {new DfaTrans(states37[30], sets[40]), new DfaTrans(states37[29], sets[41])};
                states37[31].Transitions = Array.Empty<DfaTrans>();
                states37[32].Transitions = new DfaTrans[1] {new DfaTrans(states37[33], sets[6])};
                states37[33].Transitions = new DfaTrans[1] {new DfaTrans(states37[34], sets[39])};
                states37[34].Transitions = new DfaTrans[3] {new DfaTrans(states37[35], sets[40]), new DfaTrans(states37[34], sets[41]), new DfaTrans(states37[36], sets[9])};
                states37[35].Transitions = new DfaTrans[2] {new DfaTrans(states37[35], sets[40]), new DfaTrans(states37[34], sets[41])};
                states37[36].Transitions = Array.Empty<DfaTrans>();
                states37[37].Transitions = new DfaTrans[1] {new DfaTrans(states37[38], sets[32])};
                states37[38].Transitions = new DfaTrans[2] {new DfaTrans(states37[39], sets[32]), new DfaTrans(states37[24], sets[9])};
                states37[39].Transitions = new DfaTrans[2] {new DfaTrans(states37[40], sets[32]), new DfaTrans(states37[24], sets[9])};
                states37[40].Transitions = new DfaTrans[2] {new DfaTrans(states37[41], sets[32]), new DfaTrans(states37[24], sets[9])};
                states37[41].Transitions = new DfaTrans[2] {new DfaTrans(states37[42], sets[32]), new DfaTrans(states37[24], sets[9])};
                states37[42].Transitions = new DfaTrans[2] {new DfaTrans(states37[43], sets[32]), new DfaTrans(states37[24], sets[9])};
                states37[43].Transitions = new DfaTrans[1] {new DfaTrans(states37[24], sets[9])};
                states37[44].Transitions = Array.Empty<DfaTrans>();
                states37[45].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 38 -- '}' -- */
                var states38 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,9)};
                states38[0].Transitions = new DfaTrans[1] {new DfaTrans(states38[1], sets[9])};
                states38[1].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 39 -- '|' | '}' -- */
                var states39 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,16), new DfaState(2,true,9)};
                states39[0].Transitions = new DfaTrans[2] {new DfaTrans(states39[1], sets[28]), new DfaTrans(states39[2], sets[9])};
                states39[1].Transitions = Array.Empty<DfaTrans>();
                states39[2].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 40 -- ˈtextˈ | '(' | '*' | '*:' | '+' | '+:' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states40 = new DfaState[25] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,20), new DfaState(17,true,21), new DfaState(18,true,22), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,23), new DfaState(22,true,8), new DfaState(23,true,16), new DfaState(24,true,9)};
                states40[0].Transitions = new DfaTrans[11] {new DfaTrans(states40[1], sets[23]), new DfaTrans(states40[13], sets[24]), new DfaTrans(states40[14], sets[42]), new DfaTrans(states40[16], sets[37]), new DfaTrans(states40[18], sets[25]), new DfaTrans(states40[19], sets[43]), new DfaTrans(states40[20], sets[4]), new DfaTrans(states40[21], sets[27]), new DfaTrans(states40[22], sets[6]), new DfaTrans(states40[23], sets[28]), new DfaTrans(states40[24], sets[9])};
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
                states40[14].Transitions = new DfaTrans[1] {new DfaTrans(states40[15], sets[21])};
                states40[15].Transitions = Array.Empty<DfaTrans>();
                states40[16].Transitions = new DfaTrans[1] {new DfaTrans(states40[17], sets[21])};
                states40[17].Transitions = Array.Empty<DfaTrans>();
                states40[18].Transitions = Array.Empty<DfaTrans>();
                states40[19].Transitions = Array.Empty<DfaTrans>();
                states40[20].Transitions = new DfaTrans[1] {new DfaTrans(states40[20], sets[5])};
                states40[21].Transitions = Array.Empty<DfaTrans>();
                states40[22].Transitions = Array.Empty<DfaTrans>();
                states40[23].Transitions = Array.Empty<DfaTrans>();
                states40[24].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 41 -- ˈtextˈ | '(' | ')' | ',' | '..' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states41 = new DfaState[22] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,22), new DfaState(16,false,-1), new DfaState(17,true,29), new DfaState(18,true,0), new DfaState(19,true,23), new DfaState(20,true,8), new DfaState(21,true,16)};
                states41[0].Transitions = new DfaTrans[9] {new DfaTrans(states41[1], sets[23]), new DfaTrans(states41[13], sets[24]), new DfaTrans(states41[14], sets[44]), new DfaTrans(states41[15], sets[25]), new DfaTrans(states41[16], sets[33]), new DfaTrans(states41[18], sets[4]), new DfaTrans(states41[19], sets[27]), new DfaTrans(states41[20], sets[6]), new DfaTrans(states41[21], sets[28])};
                states41[1].Transitions = new DfaTrans[2] {new DfaTrans(states41[2], sets[29]), new DfaTrans(states41[4], sets[30])};
                states41[2].Transitions = new DfaTrans[3] {new DfaTrans(states41[2], sets[29]), new DfaTrans(states41[3], sets[23]), new DfaTrans(states41[4], sets[30])};
                states41[3].Transitions = Array.Empty<DfaTrans>();
                states41[4].Transitions = new DfaTrans[2] {new DfaTrans(states41[2], sets[31]), new DfaTrans(states41[5], sets[14])};
                states41[5].Transitions = new DfaTrans[1] {new DfaTrans(states41[6], sets[6])};
                states41[6].Transitions = new DfaTrans[1] {new DfaTrans(states41[7], sets[32])};
                states41[7].Transitions = new DfaTrans[2] {new DfaTrans(states41[8], sets[32]), new DfaTrans(states41[2], sets[9])};
                states41[8].Transitions = new DfaTrans[2] {new DfaTrans(states41[9], sets[32]), new DfaTrans(states41[2], sets[9])};
                states41[9].Transitions = new DfaTrans[2] {new DfaTrans(states41[10], sets[32]), new DfaTrans(states41[2], sets[9])};
                states41[10].Transitions = new DfaTrans[2] {new DfaTrans(states41[11], sets[32]), new DfaTrans(states41[2], sets[9])};
                states41[11].Transitions = new DfaTrans[2] {new DfaTrans(states41[12], sets[32]), new DfaTrans(states41[2], sets[9])};
                states41[12].Transitions = new DfaTrans[1] {new DfaTrans(states41[2], sets[9])};
                states41[13].Transitions = Array.Empty<DfaTrans>();
                states41[14].Transitions = Array.Empty<DfaTrans>();
                states41[15].Transitions = Array.Empty<DfaTrans>();
                states41[16].Transitions = new DfaTrans[1] {new DfaTrans(states41[17], sets[33])};
                states41[17].Transitions = Array.Empty<DfaTrans>();
                states41[18].Transitions = new DfaTrans[1] {new DfaTrans(states41[18], sets[5])};
                states41[19].Transitions = Array.Empty<DfaTrans>();
                states41[20].Transitions = Array.Empty<DfaTrans>();
                states41[21].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 42 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states42 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,18), new DfaState(16,true,20), new DfaState(17,true,2), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,16), new DfaState(49,true,28)};
                states42[0].Transitions = new DfaTrans[13] {new DfaTrans(states42[1], sets[23]), new DfaTrans(states42[13], sets[24]), new DfaTrans(states42[14], sets[44]), new DfaTrans(states42[15], sets[42]), new DfaTrans(states42[16], sets[37]), new DfaTrans(states42[17], sets[33]), new DfaTrans(states42[18], sets[43]), new DfaTrans(states42[19], sets[34]), new DfaTrans(states42[20], sets[35]), new DfaTrans(states42[28], sets[30]), new DfaTrans(states42[47], sets[6]), new DfaTrans(states42[48], sets[28]), new DfaTrans(states42[49], sets[36])};
                states42[1].Transitions = new DfaTrans[2] {new DfaTrans(states42[2], sets[29]), new DfaTrans(states42[4], sets[30])};
                states42[2].Transitions = new DfaTrans[3] {new DfaTrans(states42[2], sets[29]), new DfaTrans(states42[3], sets[23]), new DfaTrans(states42[4], sets[30])};
                states42[3].Transitions = Array.Empty<DfaTrans>();
                states42[4].Transitions = new DfaTrans[2] {new DfaTrans(states42[2], sets[31]), new DfaTrans(states42[5], sets[14])};
                states42[5].Transitions = new DfaTrans[1] {new DfaTrans(states42[6], sets[6])};
                states42[6].Transitions = new DfaTrans[1] {new DfaTrans(states42[7], sets[32])};
                states42[7].Transitions = new DfaTrans[2] {new DfaTrans(states42[8], sets[32]), new DfaTrans(states42[2], sets[9])};
                states42[8].Transitions = new DfaTrans[2] {new DfaTrans(states42[9], sets[32]), new DfaTrans(states42[2], sets[9])};
                states42[9].Transitions = new DfaTrans[2] {new DfaTrans(states42[10], sets[32]), new DfaTrans(states42[2], sets[9])};
                states42[10].Transitions = new DfaTrans[2] {new DfaTrans(states42[11], sets[32]), new DfaTrans(states42[2], sets[9])};
                states42[11].Transitions = new DfaTrans[2] {new DfaTrans(states42[12], sets[32]), new DfaTrans(states42[2], sets[9])};
                states42[12].Transitions = new DfaTrans[1] {new DfaTrans(states42[2], sets[9])};
                states42[13].Transitions = Array.Empty<DfaTrans>();
                states42[14].Transitions = Array.Empty<DfaTrans>();
                states42[15].Transitions = Array.Empty<DfaTrans>();
                states42[16].Transitions = Array.Empty<DfaTrans>();
                states42[17].Transitions = Array.Empty<DfaTrans>();
                states42[18].Transitions = Array.Empty<DfaTrans>();
                states42[19].Transitions = new DfaTrans[1] {new DfaTrans(states42[19], sets[5])};
                states42[20].Transitions = new DfaTrans[2] {new DfaTrans(states42[21], sets[37]), new DfaTrans(states42[19], sets[5])};
                states42[21].Transitions = new DfaTrans[1] {new DfaTrans(states42[22], sets[32])};
                states42[22].Transitions = new DfaTrans[1] {new DfaTrans(states42[23], sets[32])};
                states42[23].Transitions = new DfaTrans[1] {new DfaTrans(states42[24], sets[32])};
                states42[24].Transitions = new DfaTrans[1] {new DfaTrans(states42[25], sets[32])};
                states42[25].Transitions = new DfaTrans[1] {new DfaTrans(states42[26], sets[32])};
                states42[26].Transitions = new DfaTrans[1] {new DfaTrans(states42[27], sets[32])};
                states42[27].Transitions = Array.Empty<DfaTrans>();
                states42[28].Transitions = new DfaTrans[1] {new DfaTrans(states42[29], sets[14])};
                states42[29].Transitions = new DfaTrans[3] {new DfaTrans(states42[30], sets[38]), new DfaTrans(states42[35], sets[18]), new DfaTrans(states42[40], sets[6])};
                states42[30].Transitions = new DfaTrans[1] {new DfaTrans(states42[31], sets[6])};
                states42[31].Transitions = new DfaTrans[1] {new DfaTrans(states42[32], sets[39])};
                states42[32].Transitions = new DfaTrans[3] {new DfaTrans(states42[33], sets[40]), new DfaTrans(states42[32], sets[41]), new DfaTrans(states42[34], sets[9])};
                states42[33].Transitions = new DfaTrans[2] {new DfaTrans(states42[33], sets[40]), new DfaTrans(states42[32], sets[41])};
                states42[34].Transitions = Array.Empty<DfaTrans>();
                states42[35].Transitions = new DfaTrans[1] {new DfaTrans(states42[36], sets[6])};
                states42[36].Transitions = new DfaTrans[1] {new DfaTrans(states42[37], sets[39])};
                states42[37].Transitions = new DfaTrans[3] {new DfaTrans(states42[38], sets[40]), new DfaTrans(states42[37], sets[41]), new DfaTrans(states42[39], sets[9])};
                states42[38].Transitions = new DfaTrans[2] {new DfaTrans(states42[38], sets[40]), new DfaTrans(states42[37], sets[41])};
                states42[39].Transitions = Array.Empty<DfaTrans>();
                states42[40].Transitions = new DfaTrans[1] {new DfaTrans(states42[41], sets[32])};
                states42[41].Transitions = new DfaTrans[2] {new DfaTrans(states42[42], sets[32]), new DfaTrans(states42[27], sets[9])};
                states42[42].Transitions = new DfaTrans[2] {new DfaTrans(states42[43], sets[32]), new DfaTrans(states42[27], sets[9])};
                states42[43].Transitions = new DfaTrans[2] {new DfaTrans(states42[44], sets[32]), new DfaTrans(states42[27], sets[9])};
                states42[44].Transitions = new DfaTrans[2] {new DfaTrans(states42[45], sets[32]), new DfaTrans(states42[27], sets[9])};
                states42[45].Transitions = new DfaTrans[2] {new DfaTrans(states42[46], sets[32]), new DfaTrans(states42[27], sets[9])};
                states42[46].Transitions = new DfaTrans[1] {new DfaTrans(states42[27], sets[9])};
                states42[47].Transitions = Array.Empty<DfaTrans>();
                states42[48].Transitions = Array.Empty<DfaTrans>();
                states42[49].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 43 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states43 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,25), new DfaState(15,true,18), new DfaState(16,true,20), new DfaState(17,true,2), new DfaState(18,true,29), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,28)};
                states43[0].Transitions = new DfaTrans[13] {new DfaTrans(states43[1], sets[23]), new DfaTrans(states43[13], sets[24]), new DfaTrans(states43[14], sets[44]), new DfaTrans(states43[15], sets[42]), new DfaTrans(states43[16], sets[37]), new DfaTrans(states43[17], sets[33]), new DfaTrans(states43[19], sets[43]), new DfaTrans(states43[20], sets[34]), new DfaTrans(states43[21], sets[35]), new DfaTrans(states43[29], sets[30]), new DfaTrans(states43[48], sets[6]), new DfaTrans(states43[49], sets[28]), new DfaTrans(states43[50], sets[36])};
                states43[1].Transitions = new DfaTrans[2] {new DfaTrans(states43[2], sets[29]), new DfaTrans(states43[4], sets[30])};
                states43[2].Transitions = new DfaTrans[3] {new DfaTrans(states43[2], sets[29]), new DfaTrans(states43[3], sets[23]), new DfaTrans(states43[4], sets[30])};
                states43[3].Transitions = Array.Empty<DfaTrans>();
                states43[4].Transitions = new DfaTrans[2] {new DfaTrans(states43[2], sets[31]), new DfaTrans(states43[5], sets[14])};
                states43[5].Transitions = new DfaTrans[1] {new DfaTrans(states43[6], sets[6])};
                states43[6].Transitions = new DfaTrans[1] {new DfaTrans(states43[7], sets[32])};
                states43[7].Transitions = new DfaTrans[2] {new DfaTrans(states43[8], sets[32]), new DfaTrans(states43[2], sets[9])};
                states43[8].Transitions = new DfaTrans[2] {new DfaTrans(states43[9], sets[32]), new DfaTrans(states43[2], sets[9])};
                states43[9].Transitions = new DfaTrans[2] {new DfaTrans(states43[10], sets[32]), new DfaTrans(states43[2], sets[9])};
                states43[10].Transitions = new DfaTrans[2] {new DfaTrans(states43[11], sets[32]), new DfaTrans(states43[2], sets[9])};
                states43[11].Transitions = new DfaTrans[2] {new DfaTrans(states43[12], sets[32]), new DfaTrans(states43[2], sets[9])};
                states43[12].Transitions = new DfaTrans[1] {new DfaTrans(states43[2], sets[9])};
                states43[13].Transitions = Array.Empty<DfaTrans>();
                states43[14].Transitions = Array.Empty<DfaTrans>();
                states43[15].Transitions = Array.Empty<DfaTrans>();
                states43[16].Transitions = Array.Empty<DfaTrans>();
                states43[17].Transitions = new DfaTrans[1] {new DfaTrans(states43[18], sets[33])};
                states43[18].Transitions = Array.Empty<DfaTrans>();
                states43[19].Transitions = Array.Empty<DfaTrans>();
                states43[20].Transitions = new DfaTrans[1] {new DfaTrans(states43[20], sets[5])};
                states43[21].Transitions = new DfaTrans[2] {new DfaTrans(states43[22], sets[37]), new DfaTrans(states43[20], sets[5])};
                states43[22].Transitions = new DfaTrans[1] {new DfaTrans(states43[23], sets[32])};
                states43[23].Transitions = new DfaTrans[1] {new DfaTrans(states43[24], sets[32])};
                states43[24].Transitions = new DfaTrans[1] {new DfaTrans(states43[25], sets[32])};
                states43[25].Transitions = new DfaTrans[1] {new DfaTrans(states43[26], sets[32])};
                states43[26].Transitions = new DfaTrans[1] {new DfaTrans(states43[27], sets[32])};
                states43[27].Transitions = new DfaTrans[1] {new DfaTrans(states43[28], sets[32])};
                states43[28].Transitions = Array.Empty<DfaTrans>();
                states43[29].Transitions = new DfaTrans[1] {new DfaTrans(states43[30], sets[14])};
                states43[30].Transitions = new DfaTrans[3] {new DfaTrans(states43[31], sets[38]), new DfaTrans(states43[36], sets[18]), new DfaTrans(states43[41], sets[6])};
                states43[31].Transitions = new DfaTrans[1] {new DfaTrans(states43[32], sets[6])};
                states43[32].Transitions = new DfaTrans[1] {new DfaTrans(states43[33], sets[39])};
                states43[33].Transitions = new DfaTrans[3] {new DfaTrans(states43[34], sets[40]), new DfaTrans(states43[33], sets[41]), new DfaTrans(states43[35], sets[9])};
                states43[34].Transitions = new DfaTrans[2] {new DfaTrans(states43[34], sets[40]), new DfaTrans(states43[33], sets[41])};
                states43[35].Transitions = Array.Empty<DfaTrans>();
                states43[36].Transitions = new DfaTrans[1] {new DfaTrans(states43[37], sets[6])};
                states43[37].Transitions = new DfaTrans[1] {new DfaTrans(states43[38], sets[39])};
                states43[38].Transitions = new DfaTrans[3] {new DfaTrans(states43[39], sets[40]), new DfaTrans(states43[38], sets[41]), new DfaTrans(states43[40], sets[9])};
                states43[39].Transitions = new DfaTrans[2] {new DfaTrans(states43[39], sets[40]), new DfaTrans(states43[38], sets[41])};
                states43[40].Transitions = Array.Empty<DfaTrans>();
                states43[41].Transitions = new DfaTrans[1] {new DfaTrans(states43[42], sets[32])};
                states43[42].Transitions = new DfaTrans[2] {new DfaTrans(states43[43], sets[32]), new DfaTrans(states43[28], sets[9])};
                states43[43].Transitions = new DfaTrans[2] {new DfaTrans(states43[44], sets[32]), new DfaTrans(states43[28], sets[9])};
                states43[44].Transitions = new DfaTrans[2] {new DfaTrans(states43[45], sets[32]), new DfaTrans(states43[28], sets[9])};
                states43[45].Transitions = new DfaTrans[2] {new DfaTrans(states43[46], sets[32]), new DfaTrans(states43[28], sets[9])};
                states43[46].Transitions = new DfaTrans[2] {new DfaTrans(states43[47], sets[32]), new DfaTrans(states43[28], sets[9])};
                states43[47].Transitions = new DfaTrans[1] {new DfaTrans(states43[28], sets[9])};
                states43[48].Transitions = Array.Empty<DfaTrans>();
                states43[49].Transitions = Array.Empty<DfaTrans>();
                states43[50].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 44 -- ˈtextˈ | '(' | ',' | '..' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states44 = new DfaState[22] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,24), new DfaState(14,true,22), new DfaState(15,false,-1), new DfaState(16,true,29), new DfaState(17,true,0), new DfaState(18,true,23), new DfaState(19,true,8), new DfaState(20,true,16), new DfaState(21,true,9)};
                states44[0].Transitions = new DfaTrans[9] {new DfaTrans(states44[1], sets[23]), new DfaTrans(states44[13], sets[24]), new DfaTrans(states44[14], sets[25]), new DfaTrans(states44[15], sets[33]), new DfaTrans(states44[17], sets[4]), new DfaTrans(states44[18], sets[27]), new DfaTrans(states44[19], sets[6]), new DfaTrans(states44[20], sets[28]), new DfaTrans(states44[21], sets[9])};
                states44[1].Transitions = new DfaTrans[2] {new DfaTrans(states44[2], sets[29]), new DfaTrans(states44[4], sets[30])};
                states44[2].Transitions = new DfaTrans[3] {new DfaTrans(states44[2], sets[29]), new DfaTrans(states44[3], sets[23]), new DfaTrans(states44[4], sets[30])};
                states44[3].Transitions = Array.Empty<DfaTrans>();
                states44[4].Transitions = new DfaTrans[2] {new DfaTrans(states44[2], sets[31]), new DfaTrans(states44[5], sets[14])};
                states44[5].Transitions = new DfaTrans[1] {new DfaTrans(states44[6], sets[6])};
                states44[6].Transitions = new DfaTrans[1] {new DfaTrans(states44[7], sets[32])};
                states44[7].Transitions = new DfaTrans[2] {new DfaTrans(states44[8], sets[32]), new DfaTrans(states44[2], sets[9])};
                states44[8].Transitions = new DfaTrans[2] {new DfaTrans(states44[9], sets[32]), new DfaTrans(states44[2], sets[9])};
                states44[9].Transitions = new DfaTrans[2] {new DfaTrans(states44[10], sets[32]), new DfaTrans(states44[2], sets[9])};
                states44[10].Transitions = new DfaTrans[2] {new DfaTrans(states44[11], sets[32]), new DfaTrans(states44[2], sets[9])};
                states44[11].Transitions = new DfaTrans[2] {new DfaTrans(states44[12], sets[32]), new DfaTrans(states44[2], sets[9])};
                states44[12].Transitions = new DfaTrans[1] {new DfaTrans(states44[2], sets[9])};
                states44[13].Transitions = Array.Empty<DfaTrans>();
                states44[14].Transitions = Array.Empty<DfaTrans>();
                states44[15].Transitions = new DfaTrans[1] {new DfaTrans(states44[16], sets[33])};
                states44[16].Transitions = Array.Empty<DfaTrans>();
                states44[17].Transitions = new DfaTrans[1] {new DfaTrans(states44[17], sets[5])};
                states44[18].Transitions = Array.Empty<DfaTrans>();
                states44[19].Transitions = Array.Empty<DfaTrans>();
                states44[20].Transitions = Array.Empty<DfaTrans>();
                states44[21].Transitions = Array.Empty<DfaTrans>();
                
                /* dfa 45 --  -- */
                var states45 = new DfaState[12] {new DfaState(0,true,-1), new DfaState(1,false,-1), new DfaState(2,true,-1), new DfaState(3,true,-1), new DfaState(4,true,-1), new DfaState(5,true,-1), new DfaState(6,true,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,true,-1)};
                states45[0].Transitions = new DfaTrans[2] {new DfaTrans(states45[0], sets[48]), new DfaTrans(states45[1], sets[49])};
                states45[1].Transitions = new DfaTrans[2] {new DfaTrans(states45[2], sets[49]), new DfaTrans(states45[9], sets[42])};
                states45[2].Transitions = new DfaTrans[3] {new DfaTrans(states45[2], sets[50]), new DfaTrans(states45[0], sets[51]), new DfaTrans(states45[3], sets[49])};
                states45[3].Transitions = new DfaTrans[4] {new DfaTrans(states45[2], sets[52]), new DfaTrans(states45[0], sets[51]), new DfaTrans(states45[3], sets[49]), new DfaTrans(states45[4], sets[42])};
                states45[4].Transitions = new DfaTrans[4] {new DfaTrans(states45[5], sets[42]), new DfaTrans(states45[6], sets[51]), new DfaTrans(states45[4], sets[52]), new DfaTrans(states45[11], sets[49])};
                states45[5].Transitions = new DfaTrans[3] {new DfaTrans(states45[4], sets[50]), new DfaTrans(states45[6], sets[51]), new DfaTrans(states45[3], sets[49])};
                states45[6].Transitions = new DfaTrans[4] {new DfaTrans(states45[6], sets[48]), new DfaTrans(states45[7], sets[49]), new DfaTrans(states45[9], sets[53]), new DfaTrans(states45[10], sets[42])};
                states45[7].Transitions = new DfaTrans[3] {new DfaTrans(states45[4], sets[49]), new DfaTrans(states45[8], sets[42]), new DfaTrans(states45[9], sets[54])};
                states45[8].Transitions = new DfaTrans[3] {new DfaTrans(states45[9], sets[54]), new DfaTrans(states45[8], sets[42]), new DfaTrans(states45[6], sets[49])};
                states45[9].Transitions = new DfaTrans[2] {new DfaTrans(states45[9], sets[55]), new DfaTrans(states45[10], sets[42])};
                states45[10].Transitions = new DfaTrans[2] {new DfaTrans(states45[0], sets[49]), new DfaTrans(states45[9], sets[56])};
                states45[11].Transitions = new DfaTrans[3] {new DfaTrans(states45[4], sets[52]), new DfaTrans(states45[6], sets[51]), new DfaTrans(states45[11], sets[57])};
                
                var dfas = new Dfa[]
                {
                    new Dfa(states0), new Dfa(states1), new Dfa(states2), new Dfa(states3), new Dfa(states4), new Dfa(states5),
                    new Dfa(states6), new Dfa(states7), new Dfa(states8), new Dfa(states9), new Dfa(states10), new Dfa(states11),
                    new Dfa(states12), new Dfa(states13), new Dfa(states14), new Dfa(states15), new Dfa(states16), new Dfa(states17),
                    new Dfa(states18), new Dfa(states19), new Dfa(states20), new Dfa(states21), new Dfa(states22), new Dfa(states23),
                    new Dfa(states24), new Dfa(states25), new Dfa(states26), new Dfa(states27), new Dfa(states28), new Dfa(states29),
                    new Dfa(states30), new Dfa(states31), new Dfa(states32), new Dfa(states33), new Dfa(states34), new Dfa(states35),
                    new Dfa(states36), new Dfa(states37), new Dfa(states38), new Dfa(states39), new Dfa(states40), new Dfa(states41),
                    new Dfa(states42), new Dfa(states43), new Dfa(states44), new Dfa(states45),
                };
                
                return new DfaSet(dfas, map, dfas.Last());
            }
            
            public static ITable CreateParseTable()
            {
                byte[] compressedTable = 
                {
                    205, 93, 15, 100, 101, 87, 26, 63, 247, 190, 251, 254, 103, 203, 150, 45, 91, 118, 217, 101, 203, 46,
                    187, 108, 217, 97, 135, 29, 118, 216, 176, 195, 14, 59, 236, 176, 195, 150, 45, 91, 182, 108, 217, 178,
                    101, 203, 150, 12, 25, 50, 100, 72, 73, 121, 229, 149, 148, 55, 188, 146, 146, 146, 146, 33, 37, 37,
                    37, 37, 37, 37, 37, 67, 74, 74, 74, 74, 74, 74, 74, 74, 198, 158, 127, 223, 57, 231, 158, 220, 247, 230,
                    222, 239, 124, 103, 50, 191, 243, 239, 251, 190, 119, 238, 119, 239, 61, 239, 222, 220, 119, 191, 239,
                    59, 39, 140, 73, 124, 79, 53, 5, 168, 183, 71, 126, 132, 68, 141, 90, 33, 99, 141, 234, 155, 124, 159,
                    254, 40, 0, 63, 136, 160, 243, 245, 244, 151, 162, 249, 181, 149, 252, 6, 136, 31, 254, 136, 253, 196,
                    235, 253, 51, 127, 243, 159, 23, 233, 188, 147, 222, 73, 85, 235, 202, 2, 14, 82, 225, 137, 39, 100,
                    237, 8, 130, 85, 62, 249, 164, 172, 29, 65, 176, 202, 167, 158, 146, 181, 35, 8, 86, 249, 187, 145, 95,
                    209, 111, 75, 124, 69, 69, 248, 125, 240, 49, 157, 193, 31, 232, 85, 254, 145, 94, 37, 187, 157, 222,
                    150, 87, 162, 170, 65, 22, 97, 71, 18, 157, 128, 109, 223, 74, 217, 95, 24, 251, 107, 241, 135, 127,
                    122, 248, 246, 127, 182, 228, 63, 128, 120, 103, 252, 153, 254, 237, 161, 74, 255, 110, 168, 127, 3,
                    241, 121, 181, 209, 251, 103, 177, 248, 95, 57, 238, 205, 84, 100, 89, 8, 241, 223, 49, 3, 250, 31, 180,
                    214, 255, 161, 183, 28, 137, 169, 132, 70, 207, 93, 51, 126, 150, 10, 134, 185, 152, 102, 198, 31, 229,
                    52, 209, 73, 112, 204, 37, 243, 21, 148, 205, 154, 190, 247, 205, 89, 91, 42, 24, 230, 194, 239, 87,
                    59, 193, 30, 126, 60, 6, 201, 176, 234, 198, 11, 185, 13, 222, 72, 69, 150, 133, 16, 79, 63, 45, 107,
                    71, 128, 213, 180, 72, 119, 173, 24, 44, 69, 208, 249, 182, 25, 64, 75, 209, 225, 153, 103, 100, 237,
                    8, 176, 154, 142, 248, 185, 31, 203, 243, 63, 145, 245, 199, 252, 104, 69, 225, 56, 77, 166, 210, 105,
                    255, 224, 151, 147, 149, 100, 53, 89, 75, 214, 147, 141, 100, 51, 217, 74, 182, 147, 157, 100, 55, 217,
                    75, 246, 147, 131, 17, 163, 120, 168, 229, 239, 114, 85, 162, 184, 181, 162, 120, 35, 18, 246, 20, 24,
                    123, 143, 111, 43, 138, 91, 43, 138, 55, 34, 225, 85, 127, 102, 182, 181, 20, 29, 238, 36, 119, 228,
                    232, 168, 26, 100, 88, 109, 27, 41, 219, 76, 183, 210, 237, 116, 39, 221, 213, 7, 251, 128, 183, 162,
                    72, 236, 73, 102, 127, 228, 121, 204, 240, 79, 102, 211, 185, 116, 62, 237, 165, 253, 116, 33, 29, 164,
                    195, 116, 49, 101, 75, 233, 114, 186, 146, 174, 166, 107, 206, 134, 235, 41, 251, 66, 100, 72, 74, 42,
                    90, 160, 53, 99, 216, 138, 248, 50, 229, 25, 146, 17, 201, 226, 48, 134, 13, 193, 65, 132, 47, 246, 48,
                    130, 206, 163, 8, 58, 63, 224, 58, 69, 193, 226, 184, 112, 219, 103, 101, 14, 197, 71, 92, 183, 40, 110,
                    173, 40, 222, 136, 132, 87, 125, 81, 102, 91, 201, 150, 93, 188, 168, 90, 20, 46, 201, 108, 43, 217,
                    178, 75, 151, 84, 139, 194, 101, 153, 109, 37, 91, 118, 249, 178, 106, 81, 152, 148, 217, 86, 147, 167,
                    233, 84, 109, 186, 54, 83, 155, 173, 77, 78, 74, 33, 14, 207, 201, 108, 171, 231, 0, 120, 149, 207, 203,
                    108, 171, 231, 1, 120, 149, 47, 200, 108, 171, 23, 0, 120, 149, 47, 203, 108, 171, 151, 1, 120, 149,
                    175, 202, 108, 171, 87, 1, 120, 149, 55, 249, 51, 69, 20, 183, 190, 153, 248, 9, 175, 223, 255, 21, 113,
                    65, 230, 81, 191, 33, 56, 230, 106, 229, 127, 64, 104, 220, 230, 31, 139, 226, 214, 183, 19, 63, 225,
                    207, 225, 22, 223, 86, 20, 183, 190, 149, 248, 9, 175, 127, 62, 130, 213, 209, 31, 119, 7, 69, 163, 174,
                    209, 171, 149, 24, 110, 156, 234, 126, 25, 213, 187, 124, 36, 246, 228, 104, 236, 195, 152, 232, 159,
                    156, 7, 181, 195, 218, 81, 77, 51, 6, 11, 181, 65, 109, 88, 91, 172, 45, 213, 150, 107, 43, 181, 213,
                    218, 90, 109, 189, 182, 81, 219, 172, 109, 213, 182, 71, 140, 233, 142, 150, 127, 151, 240, 12, 73, 112,
                    74, 198, 92, 1, 240, 99, 15, 185, 28, 142, 35, 124, 197, 223, 240, 193, 16, 37, 8, 39, 254, 129, 189,
                    197, 79, 87, 20, 82, 188, 201, 21, 138, 2, 152, 202, 144, 138, 190, 75, 121, 134, 100, 68, 178, 56, 140,
                    97, 43, 226, 157, 132, 103, 72, 70, 36, 139, 195, 24, 182, 34, 222, 77, 120, 134, 100, 68, 178, 56, 140,
                    97, 43, 226, 189, 132, 103, 72, 70, 36, 139, 195, 24, 182, 34, 222, 79, 120, 134, 100, 68, 178, 56, 140,
                    97, 43, 226, 94, 194, 51, 36, 54, 35, 47, 14, 78, 240, 50, 155, 205, 101, 108, 62, 51, 188, 168, 31,
                    142, 233, 179, 151, 215, 103, 9, 207, 144, 4, 167, 100, 204, 21, 0, 143, 59, 137, 79, 19, 158, 33, 9,
                    78, 201, 152, 43, 0, 30, 183, 135, 175, 18, 158, 33, 9, 78, 201, 152, 43, 0, 30, 183, 135, 177, 232,
                    101, 84, 239, 158, 119, 249, 225, 137, 98, 222, 61, 239, 38, 227, 223, 61, 5, 250, 217, 216, 247, 78,
                    249, 216, 119, 158, 246, 254, 79, 1, 37, 0, 30, 117, 38, 236, 139, 132, 103, 72, 130, 83, 50, 230, 10,
                    128, 199, 237, 225, 203, 132, 103, 72, 130, 83, 50, 230, 10, 128, 191, 133, 251, 43, 247, 77, 194, 51,
                    36, 193, 41, 25, 115, 5, 192, 227, 78, 226, 219, 132, 103, 72, 130, 83, 50, 230, 10, 128, 199, 237, 225,
                    235, 132, 103, 72, 130, 83, 50, 230, 10, 128, 191, 137, 27, 166, 189, 140, 237, 103, 7, 217, 97, 118,
                    148, 29, 219, 11, 223, 88, 76, 78, 50, 78, 62, 72, 79, 71, 222, 19, 11, 252, 147, 65, 54, 204, 22, 179,
                    165, 108, 57, 91, 201, 86, 179, 181, 108, 61, 99, 27, 217, 102, 182, 149, 109, 103, 59, 206, 134, 187,
                    89, 209, 77, 82, 22, 112, 127, 0, 166, 234, 254, 141, 97, 240, 99, 158, 68, 38, 196, 79, 121, 18, 57,
                    28, 191, 56, 67, 208, 226, 87, 252, 185, 80, 15, 87, 83, 213, 44, 202, 102, 234, 56, 171, 232, 21, 153,
                    109, 37, 91, 118, 229, 138, 106, 81, 184, 42, 179, 173, 100, 203, 174, 94, 85, 45, 10, 131, 58, 27, 214,
                    23, 235, 75, 245, 229, 250, 202, 217, 209, 93, 21, 162, 181, 145, 163, 62, 155, 251, 100, 174, 62, 95,
                    239, 213, 251, 245, 133, 156, 244, 186, 204, 182, 146, 45, 187, 126, 253, 250, 99, 113, 204, 235, 133,
                    199, 252, 33, 191, 8, 68, 113, 107, 69, 241, 70, 36, 252, 177, 143, 199, 102, 125, 171, 218, 37, 190,
                    161, 186, 191, 40, 179, 173, 94, 4, 224, 15, 229, 37, 153, 109, 245, 18, 0, 175, 114, 36, 182, 9, 238,
                    107, 13, 107, 242, 68, 24, 63, 119, 70, 29, 135, 177, 121, 62, 75, 102, 243, 100, 158, 201, 51, 192,
                    232, 153, 179, 121, 50, 199, 230, 121, 145, 198, 230, 201, 28, 155, 231, 37, 26, 155, 39, 115, 108, 158,
                    151, 105, 108, 158, 162, 221, 171, 239, 215, 15, 234, 135, 245, 163, 250, 100, 136, 209, 51, 103, 243,
                    20, 109, 184, 209, 51, 103, 243, 20, 109, 184, 209, 51, 103, 243, 20, 109, 184, 209, 51, 103, 243, 20,
                    109, 184, 209, 51, 103, 243, 20, 109, 184, 209, 211, 183, 121, 74, 130, 208, 232, 89, 96, 197, 186, 224,
                    24, 177, 20, 237, 226, 184, 94, 222, 128, 53, 194, 230, 41, 9, 66, 163, 167, 111, 243, 148, 4, 161, 209,
                    243, 132, 238, 79, 246, 184, 113, 7, 28, 141, 30, 205, 211, 122, 137, 225, 198, 169, 158, 106, 224, 84,
                    143, 181, 121, 78, 55, 176, 54, 207, 215, 205, 215, 101, 41, 90, 188, 193, 245, 206, 32, 2, 94, 99, 248,
                    171, 217, 108, 163, 156, 187, 122, 189, 193, 54, 26, 155, 141, 173, 198, 118, 99, 167, 81, 176, 179,
                    93, 33, 220, 27, 121, 86, 115, 234, 147, 249, 70, 175, 209, 111, 44, 52, 6, 141, 97, 131, 45, 54, 150,
                    26, 203, 141, 149, 198, 170, 179, 213, 90, 131, 125, 156, 240, 12, 73, 73, 69, 11, 180, 102, 12, 91,
                    21, 251, 4, 35, 239, 225, 131, 132, 103, 72, 70, 36, 139, 195, 24, 182, 34, 62, 76, 120, 134, 100, 68,
                    178, 56, 140, 97, 43, 226, 163, 132, 103, 72, 70, 36, 139, 195, 24, 182, 58, 14, 249, 120, 31, 133, 142,
                    249, 65, 78, 193, 183, 41, 207, 144, 140, 72, 22, 135, 49, 108, 69, 20, 57, 61, 152, 239, 243, 208, 157,
                    112, 123, 24, 137, 99, 186, 107, 211, 250, 60, 176, 222, 143, 147, 130, 131, 177, 62, 15, 66, 239, 135,
                    245, 121, 112, 106, 170, 73, 231, 244, 80, 82, 32, 116, 7, 50, 167, 135, 146, 2, 161, 59, 144, 57, 61,
                    148, 20, 8, 221, 129, 204, 233, 161, 164, 64, 232, 14, 100, 78, 15, 37, 5, 66, 119, 32, 113, 122, 192,
                    197, 193, 125, 30, 205, 185, 38, 155, 23, 188, 252, 164, 180, 211, 163, 89, 202, 233, 193, 124, 159,
                    135, 238, 68, 231, 244, 96, 190, 207, 67, 119, 162, 115, 122, 48, 223, 231, 161, 59, 225, 246, 48, 22,
                    189, 38, 161, 245, 216, 248, 60, 78, 50, 78, 222, 77, 198, 91, 143, 5, 250, 205, 177, 150, 227, 98, 167,
                    7, 243, 125, 30, 186, 19, 157, 211, 131, 249, 62, 15, 221, 137, 206, 233, 193, 124, 159, 135, 238, 68,
                    232, 244, 96, 190, 207, 67, 119, 162, 115, 122, 48, 223, 231, 161, 59, 209, 57, 61, 152, 239, 243, 208,
                    157, 206, 209, 233, 177, 208, 44, 235, 244, 40, 222, 91, 41, 192, 253, 1, 24, 52, 253, 27, 227, 243,
                    132, 103, 72, 130, 83, 50, 230, 10, 128, 175, 182, 111, 180, 39, 96, 216, 196, 121, 2, 114, 184, 199,
                    213, 138, 18, 10, 21, 220, 2, 148, 203, 195, 239, 65, 52, 174, 201, 108, 43, 217, 178, 107, 215, 84,
                    139, 130, 114, 205, 3, 229, 242, 240, 52, 67, 67, 249, 228, 129, 114, 121, 120, 140, 161, 161, 156, 241,
                    64, 185, 60, 60, 191, 226, 96, 17, 247, 208, 42, 142, 163, 211, 31, 133, 133, 208, 41, 175, 56, 80, 46,
                    15, 15, 18, 52, 148, 59, 28, 40, 151, 135, 39, 8, 7, 254, 177, 225, 120, 200, 93, 30, 30, 29, 104, 40,
                    7, 56, 80, 46, 15, 207, 12, 52, 148, 231, 27, 40, 151, 135, 135, 5, 199, 57, 62, 33, 150, 74, 63, 33,
                    198, 123, 234, 198, 34, 239, 167, 99, 108, 185, 233, 123, 233, 110, 200, 108, 43, 217, 178, 27, 55, 84,
                    139, 194, 49, 191, 241, 78, 228, 205, 119, 218, 4, 187, 157, 110, 167, 90, 211, 173, 153, 150, 215, 127,
                    165, 185, 218, 92, 107, 174, 55, 55, 154, 155, 205, 173, 230, 118, 115, 167, 185, 219, 220, 107, 238,
                    55, 15, 154, 135, 35, 110, 225, 35, 45, 255, 132, 107, 21, 69, 212, 170, 5, 94, 10, 64, 132, 193, 167,
                    124, 91, 81, 68, 173, 90, 224, 165, 0, 68, 24, 188, 34, 179, 173, 94, 1, 224, 85, 250, 152, 109, 57,
                    14, 127, 36, 170, 154, 100, 217, 92, 11, 103, 145, 205, 249, 248, 153, 227, 227, 191, 66, 227, 227, 103,
                    142, 143, 31, 239, 228, 95, 108, 177, 165, 214, 114, 107, 165, 181, 218, 90, 243, 175, 96, 110, 65, 21,
                    162, 141, 179, 114, 141, 249, 220, 39, 189, 86, 191, 181, 208, 26, 180, 134, 173, 145, 62, 126, 230,
                    248, 248, 175, 63, 14, 199, 188, 89, 120, 204, 190, 143, 159, 121, 46, 254, 104, 78, 254, 202, 62, 254,
                    173, 214, 89, 31, 191, 104, 195, 157, 252, 57, 31, 191, 104, 35, 58, 249, 183, 71, 126, 91, 143, 198,
                    155, 176, 211, 42, 231, 77, 200, 225, 107, 206, 139, 18, 138, 178, 209, 234, 214, 166, 27, 130, 183,
                    185, 18, 81, 66, 81, 38, 88, 219, 114, 17, 98, 181, 45, 23, 33, 84, 219, 114, 17, 34, 181, 45, 23, 33,
                    80, 219, 114, 65, 38, 203, 61, 121, 71, 170, 184, 236, 253, 214, 65, 139, 29, 10, 129, 52, 86, 150, 179,
                    88, 238, 182, 208, 97, 218, 214, 152, 25, 41, 74, 219, 218, 50, 35, 5, 105, 91, 83, 38, 37, 142, 112,
                    127, 37, 11, 92, 160, 185, 24, 237, 114, 46, 80, 118, 220, 26, 235, 1, 45, 31, 162, 109, 13, 153, 145,
                    34, 180, 173, 29, 51, 82, 128, 54, 139, 30, 159, 109, 173, 152, 145, 194, 179, 173, 17, 51, 82, 116,
                    54, 175, 206, 241, 45, 244, 164, 85, 246, 45, 180, 224, 238, 40, 11, 184, 51, 0, 167, 45, 255, 150, 48,
                    184, 149, 123, 87, 152, 14, 89, 218, 108, 170, 253, 32, 97, 15, 18, 72, 156, 20, 82, 81, 187, 2, 224,
                    113, 251, 224, 87, 247, 173, 20, 146, 182, 175, 136, 218, 21, 0, 143, 219, 3, 191, 54, 110, 166, 144,
                    180, 189, 66, 212, 174, 0, 120, 220, 30, 238, 39, 60, 67, 18, 156, 146, 49, 87, 0, 60, 110, 15, 62, 102,
                    218, 110, 168, 12, 18, 20, 87, 63, 155, 109, 151, 188, 248, 219, 108, 163, 189, 217, 222, 106, 111, 183,
                    119, 236, 53, 105, 131, 99, 218, 130, 220, 27, 121, 181, 206, 169, 79, 230, 219, 189, 118, 191, 189,
                    208, 30, 180, 135, 109, 182, 216, 94, 106, 47, 183, 87, 218, 171, 206, 86, 107, 237, 162, 232, 24, 150,
                    11, 142, 209, 29, 198, 15, 206, 72, 236, 183, 31, 69, 116, 140, 146, 2, 161, 59, 144, 69, 199, 40, 41,
                    16, 186, 3, 89, 116, 140, 146, 2, 161, 59, 224, 180, 115, 28, 242, 241, 62, 10, 29, 243, 131, 246, 67,
                    162, 99, 148, 20, 8, 221, 33, 112, 167, 62, 142, 241, 103, 81, 228, 133, 98, 190, 19, 74, 119, 34, 56,
                    210, 247, 249, 169, 139, 66, 128, 83, 126, 210, 83, 33, 107, 207, 9, 156, 148, 27, 185, 105, 252, 126,
                    148, 11, 15, 40, 151, 135, 65, 14, 199, 76, 232, 48, 20, 0, 102, 23, 132, 44, 177, 50, 123, 230, 184,
                    244, 244, 2, 226, 37, 86, 96, 106, 1, 245, 18, 43, 122, 122, 1, 229, 18, 43, 122, 122, 1, 229, 18, 43,
                    122, 122, 1, 229, 18, 43, 122, 102, 193, 228, 124, 167, 215, 233, 119, 22, 58, 131, 14, 205, 18, 43,
                    122, 122, 1, 229, 18, 43, 122, 122, 1, 229, 18, 43, 122, 122, 1, 229, 18, 43, 122, 122, 1, 229, 18, 43,
                    122, 122, 1, 241, 18, 43, 48, 171, 128, 114, 137, 21, 215, 233, 164, 231, 22, 92, 24, 237, 114, 226,
                    24, 118, 202, 251, 155, 10, 92, 195, 240, 110, 30, 107, 137, 21, 152, 85, 64, 185, 196, 202, 98, 132,
                    63, 225, 238, 184, 123, 31, 21, 141, 186, 198, 82, 167, 196, 112, 227, 84, 47, 151, 81, 93, 213, 183,
                    181, 210, 193, 78, 55, 168, 236, 69, 91, 237, 224, 118, 228, 195, 134, 199, 4, 4, 202, 248, 241, 49,
                    150, 48, 118, 120, 146, 248, 24, 230, 196, 199, 92, 35, 139, 143, 177, 132, 49, 166, 82, 197, 199, 88,
                    194, 152, 81, 169, 226, 99, 44, 97, 12, 168, 81, 176, 134, 251, 107, 80, 56, 231, 74, 55, 129, 127, 0,
                    253, 248, 24, 75, 24, 99, 38, 85, 124, 140, 37, 140, 25, 147, 44, 62, 198, 18, 198, 128, 73, 21, 31,
                    99, 9, 99, 186, 164, 138, 143, 177, 132, 49, 90, 158, 107, 124, 204, 122, 167, 172, 101, 114, 188, 151,
                    123, 44, 242, 62, 110, 238, 36, 237, 248, 30, 238, 92, 124, 12, 115, 226, 99, 110, 60, 178, 248, 152,
                    205, 14, 54, 62, 38, 23, 105, 34, 90, 226, 80, 147, 175, 248, 81, 139, 18, 138, 50, 83, 194, 44, 87,
                    21, 91, 157, 115, 153, 17, 102, 185, 8, 19, 194, 44, 23, 97, 62, 152, 229, 170, 99, 135, 15, 246, 110,
                    232, 128, 111, 119, 170, 78, 7, 179, 28, 21, 246, 130, 204, 49, 165, 162, 174, 173, 41, 12, 139, 125,
                    194, 75, 251, 128, 254, 54, 33, 177, 209, 31, 118, 202, 61, 6, 124, 216, 144, 147, 128, 224, 147, 178,
                    147, 5, 105, 98, 78, 152, 27, 114, 18, 16, 124, 82, 102, 174, 28, 101, 204, 137, 146, 2, 145, 139, 64,
                    137, 48, 83, 142, 50, 230, 68, 73, 129, 200, 69, 160, 68, 152, 39, 71, 20, 115, 114, 12, 119, 234, 189,
                    228, 164, 115, 218, 97, 83, 93, 73, 171, 32, 148, 50, 234, 142, 58, 232, 89, 114, 164, 49, 39, 69, 147,
                    228, 72, 99, 78, 138, 230, 200, 197, 137, 57, 153, 22, 223, 65, 117, 20, 59, 22, 109, 200, 73, 91, 144,
                    15, 117, 44, 178, 153, 238, 88, 191, 98, 249, 25, 114, 164, 49, 39, 69, 19, 228, 72, 99, 78, 138, 230,
                    199, 209, 198, 156, 20, 77, 143, 35, 141, 57, 41, 154, 29, 71, 26, 115, 82, 52, 57, 238, 124, 99, 78,
                    102, 187, 165, 99, 78, 10, 239, 142, 82, 128, 59, 195, 240, 93, 255, 150, 136, 17, 115, 50, 223, 45,
                    138, 57, 97, 126, 200, 137, 238, 68, 23, 115, 194, 252, 144, 19, 221, 137, 46, 230, 132, 249, 33, 39,
                    186, 19, 93, 204, 9, 243, 67, 78, 116, 39, 220, 30, 84, 92, 15, 80, 46, 15, 223, 5, 26, 42, 160, 7, 40,
                    151, 135, 47, 1, 13, 21, 201, 3, 148, 203, 195, 232, 163, 161, 66, 120, 128, 114, 121, 24, 118, 52, 94,
                    147, 217, 86, 175, 1, 240, 42, 153, 55, 127, 165, 135, 123, 188, 6, 217, 93, 88, 191, 139, 51, 187, 152,
                    9, 45, 122, 2, 11, 229, 162, 149, 122, 2, 11, 193, 162, 149, 43, 93, 182, 218, 93, 235, 174, 119, 55,
                    186, 155, 103, 71, 119, 75, 136, 182, 71, 142, 250, 66, 238, 147, 65, 119, 216, 93, 236, 46, 117, 151,
                    187, 133, 19, 90, 244, 4, 22, 130, 69, 43, 9, 143, 121, 167, 240, 152, 221, 9, 45, 48, 121, 229, 241,
                    92, 180, 114, 183, 155, 159, 208, 162, 39, 176, 80, 46, 90, 169, 39, 176, 196, 92, 180, 114, 143, 224,
                    190, 214, 176, 33, 63, 97, 193, 63, 7, 252, 144, 14, 67, 15, 107, 191, 156, 130, 163, 46, 89, 204, 143,
                    37, 140, 229, 41, 24, 199, 116, 223, 78, 140, 95, 91, 39, 221, 178, 17, 190, 246, 135, 88, 164, 0, 95,
                    22, 59, 190, 151, 197, 14, 239, 181, 191, 194, 42, 226, 147, 132, 103, 72, 70, 36, 139, 195, 24, 22,
                    139, 155, 17, 254, 121, 136, 134, 117, 97, 4, 56, 51, 202, 4, 238, 226, 125, 24, 167, 221, 115, 137,
                    219, 165, 244, 97, 40, 41, 16, 57, 143, 70, 132, 168, 221, 16, 31, 198, 244, 4, 183, 168, 240, 18, 132,
                    169, 137, 170, 65, 187, 244, 62, 140, 217, 137, 232, 49, 187, 225, 62, 140, 185, 208, 145, 14, 248, 133,
                    63, 63, 129, 251, 133, 207, 252, 216, 26, 234, 197, 104, 192, 157, 64, 189, 24, 141, 14, 174, 33, 94,
                    140, 6, 108, 194, 17, 22, 163, 1, 107, 112, 132, 197, 104, 192, 14, 252, 40, 22, 163, 233, 225, 46, 242,
                    226, 136, 67, 242, 197, 104, 192, 38, 27, 97, 49, 26, 48, 212, 198, 88, 140, 6, 236, 176, 17, 22, 163,
                    1, 11, 108, 132, 197, 104, 192, 44, 251, 56, 45, 70, 211, 159, 40, 107, 146, 29, 255, 6, 62, 22, 249,
                    247, 111, 206, 79, 248, 111, 223, 38, 216, 70, 7, 215, 156, 195, 98, 52, 131, 137, 224, 96, 27, 29, 92,
                    67, 16, 107, 227, 27, 49, 45, 97, 222, 121, 168, 140, 152, 150, 48, 111, 59, 84, 70, 76, 75, 152, 247,
                    28, 42, 35, 166, 37, 204, 27, 14, 137, 17, 83, 180, 132, 86, 204, 33, 221, 79, 156, 24, 239, 209, 139,
                    19, 101, 189, 22, 164, 239, 209, 69, 78, 11, 210, 247, 232, 34, 159, 5, 233, 123, 116, 145, 203, 130,
                    242, 61, 90, 73, 129, 208, 29, 112, 218, 153, 111, 28, 35, 154, 33, 183, 204, 47, 237, 149, 208, 203,
                    123, 169, 156, 130, 213, 9, 18, 107, 25, 188, 177, 80, 207, 144, 91, 163, 187, 203, 203, 216, 84, 44,
                    135, 197, 58, 221, 1, 187, 79, 42, 248, 27, 17, 193, 221, 6, 127, 29, 34, 184, 219, 224, 239, 66, 4,
                    119, 219, 125, 125, 246, 186, 37, 115, 183, 233, 39, 19, 193, 131, 170, 204, 223, 30, 244, 245, 246,
                    127,
                };
                
                ushort[] u16Table = 
                {
                    0, 0, 0, 0, 0, 0, 0, 13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5,
                    9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 274, 45, 0, 0, 0, 0, 49, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    53, 0, 0, 0, 0, 0, 0, 0, 0, 25, 29, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 37, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    270, 270, 0, 0, 0, 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 14, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    18, 18, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 22, 0, 0, 0, 0, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 61, 45,
                    0, 0, 0, 0, 49, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 53, 0, 0, 0, 0, 0, 0, 0, 0, 57, 29, 0, 33, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 69, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 73, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 266, 266, 0, 0, 0, 0, 266,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 286, 0, 85, 0, 0, 89, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 77, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 101, 0,
                    0, 0, 0, 0, 0, 0, 0, 298, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 93, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 113, 0, 0, 0, 0, 0, 0, 0, 0, 350, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 109, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 282, 0, 282, 0, 0, 282, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 121, 0, 85, 0, 0, 89, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 117, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 129, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0,
                    0, 0, 0, 0, 0, 0, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 101, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 133, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 145, 149, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 141, 0, 0, 0, 0, 0, 0, 0, 0, 346, 0, 0, 0, 0, 0, 0, 0, 0, 346, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 113, 0, 0, 0,
                    0, 0, 0, 0, 0, 157, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 153, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 165, 169, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 161, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 278, 0, 278, 0, 0, 278, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 26, 26, 0, 0, 0, 0, 26, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 173, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 177, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 290, 0, 0, 0, 0, 0,
                    0, 0, 0, 290, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 38, 0, 0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 241, 0, 0, 245, 0, 0, 0,
                    0, 249, 0, 0, 0, 0, 330, 0, 0, 330, 0, 0, 0, 0, 0, 253, 257, 261, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 181, 185, 189, 193, 197, 201, 205, 209, 213, 217, 221, 225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 237, 0, 0, 0, 0, 0, 0, 302, 0, 0, 302, 0, 0, 0, 0, 302, 0,
                    0, 0, 0, 302, 0, 0, 302, 0, 0, 0, 0, 0, 302, 302, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 306, 0, 0, 306, 0, 0, 0, 0, 306, 0, 0, 0, 0, 306, 0, 0, 306, 0, 0, 0, 0, 0, 306,
                    306, 306, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 342, 0, 0, 0, 0, 0,
                    0, 0, 0, 342, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 142, 142, 0, 0, 0, 0, 142, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 142, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 329, 0, 333, 337,
                    341, 345, 349, 0, 0, 0, 0, 0, 0, 382, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 353, 0, 0, 382, 357, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 265, 0, 0, 269, 273, 277, 281, 285, 289,
                    293, 297, 301, 0, 305, 309, 313, 317, 321, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 325, 0, 354, 0, 354, 354, 354,
                    354, 354, 0, 0, 0, 0, 0, 0, 354, 0, 0, 354, 0, 0, 0, 0, 0, 0, 0, 354, 0, 0, 354, 354, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 358, 358, 358, 358, 358, 0, 0, 0, 0, 0, 0, 358,
                    0, 0, 358, 0, 0, 0, 0, 0, 0, 0, 358, 0, 0, 358, 358, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 361, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 365,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 369, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 318, 0, 0,
                    318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 373, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 326, 0, 0, 326, 0, 0, 0, 0, 326, 0, 0, 0, 0, 326,
                    0, 0, 326, 0, 0, 0, 0, 0, 326, 326, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 0, 58, 58, 58, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 0, 0,
                    0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 0, 62, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 0, 66, 66, 66,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70,
                    0, 0, 0, 0, 70, 0, 0, 70, 381, 385, 389, 393, 397, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0, 0, 0, 94, 0, 0, 0, 0, 94, 0, 0, 94, 94, 94, 94,
                    94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 98, 0, 0,
                    98, 0, 0, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 98, 98, 98, 98, 98, 98, 98, 98, 98, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102, 0, 0, 0, 0, 102, 0,
                    0, 102, 102, 102, 102, 102, 102, 102, 102, 102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 114, 0, 0, 114, 0, 0, 0, 0, 114, 0, 0, 0, 0, 114, 0, 0, 114, 114, 114, 114, 114, 114,
                    114, 114, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0, 0, 122,
                    0, 0, 0, 0, 122, 0, 0, 0, 0, 122, 0, 0, 122, 122, 122, 122, 122, 122, 122, 122, 122, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 0, 130, 0, 0, 0, 0, 130, 0, 0, 0, 0, 130,
                    0, 0, 130, 130, 130, 130, 130, 130, 130, 130, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 241, 0, 0, 245, 0, 0, 0, 0, 249, 0, 0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 0, 0, 253, 257,
                    261, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 401, 197, 201, 205, 209, 213, 217, 221, 225,
                    229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138,
                    0, 0, 138, 0, 0, 0, 0, 138, 0, 0, 0, 0, 138, 0, 0, 138, 138, 138, 138, 138, 138, 138, 138, 138, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 134, 0, 0, 134, 0, 0, 0, 0, 134, 0,
                    0, 0, 0, 134, 0, 0, 134, 134, 134, 134, 134, 134, 134, 134, 134, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 405, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 241, 0, 0, 245, 0,
                    0, 0, 0, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 261, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 409, 225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 241, 0, 0, 245, 0, 0, 0, 0, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 261, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 413,
                    225, 229, 233, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    477, 0, 0, 481, 0, 0, 0, 0, 485, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 489, 493, 497, 330, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 417, 421, 425, 429, 433, 437, 441, 445, 449, 453, 457, 461, 465, 469,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0, 0, 0, 0, 0, 0, 250, 0, 250,
                    250, 250, 250, 250, 0, 250, 0, 0, 0, 0, 250, 0, 0, 250, 250, 250, 0, 250, 0, 0, 0, 250, 0, 0, 250, 250,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 501,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 505, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0,
                    158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 154, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 513, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 378, 378, 378, 378, 378, 0, 0, 0, 0, 0, 0,
                    378, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 378, 0, 0, 378, 378, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0, 170, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0,
                    170, 0, 0, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174, 174,
                    174, 174, 0, 0, 0, 0, 0, 0, 174, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 174, 0, 0, 174, 174, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 0, 0, 0, 0, 0, 178,
                    0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 178, 0, 0, 178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 182, 0, 0, 182, 0, 0, 0, 0, 0, 0, 0, 182,
                    0, 0, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186,
                    186, 0, 521, 0, 0, 0, 0, 186, 0, 0, 186, 525, 529, 0, 533, 0, 0, 0, 186, 0, 0, 186, 186, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 517,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214, 214, 0, 214, 0, 0, 0,
                    0, 214, 0, 0, 214, 214, 214, 0, 214, 0, 0, 0, 214, 0, 0, 214, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 210, 0, 0, 210, 210, 210,
                    0, 210, 0, 0, 0, 210, 0, 0, 210, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234,
                    0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 234, 0, 0, 234, 234, 234, 0, 234, 0, 0, 0, 234, 0, 0,
                    234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 537, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 329, 0, 333, 337, 341, 345, 349, 0, 0, 0, 0, 0, 0, 166, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0,
                    353, 0, 0, 166, 357, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 265, 0,
                    0, 0, 0, 0, 0, 541, 289, 293, 297, 301, 0, 305, 309, 313, 317, 321, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 138, 0, 138, 138, 138, 138, 138, 0, 138, 0, 0, 0, 0, 138, 0, 0, 138, 138, 138, 0, 138, 0, 0, 0, 138,
                    0, 0, 138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226,
                    226, 0, 226, 0, 0, 0, 0, 226, 0, 0, 226, 226, 226, 0, 226, 0, 0, 0, 226, 0, 0, 226, 226, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 0,
                    230, 0, 0, 230, 230, 230, 0, 230, 0, 0, 0, 230, 0, 0, 230, 230, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 242, 0, 0, 242, 242, 242,
                    0, 242, 0, 0, 0, 242, 0, 0, 242, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246,
                    0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 0, 246, 0, 0, 246, 246, 246, 0, 246, 0, 0, 0, 246, 0, 0,
                    246, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 238, 238, 238, 238, 238,
                    0, 238, 0, 0, 0, 0, 238, 0, 0, 238, 238, 238, 0, 238, 0, 0, 0, 238, 0, 0, 238, 238, 258, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 382, 0, 0, 0, 0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 545, 0, 0, 549, 553, 557, 561, 565, 569, 573, 577, 581, 0, 585, 589, 593, 597, 601,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 329, 0, 333, 337, 341, 345, 349, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 265, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 641, 317, 321, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 30, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 34, 0, 34, 0, 0, 34, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 42,
                    0, 0, 0, 0, 0, 0, 0, 0, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 645, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 241, 0, 0,
                    245, 0, 0, 0, 0, 249, 0, 0, 0, 0, 330, 0, 0, 330, 0, 0, 0, 0, 0, 253, 257, 261, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 649, 189, 193, 197, 201, 205, 209, 213, 217, 221, 225, 229, 233, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 237, 0, 0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0,
                    0, 74, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 0, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 78, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 0,
                    78, 78, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 677, 0, 681, 685,
                    689, 693, 697, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 701, 0, 0, 0, 705, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 653, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 657, 661,
                    665, 669, 673, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86, 0, 0, 0, 0, 86, 0, 0,
                    86, 0, 0, 0, 0, 0, 86, 86, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    677, 0, 681, 685, 689, 693, 697, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 701, 0, 0, 0, 705,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 653, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 709, 661, 665, 669, 673, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 322, 0, 0, 322, 0, 0, 0, 0,
                    322, 0, 0, 0, 0, 322, 0, 0, 322, 0, 0, 0, 0, 0, 322, 322, 322, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 717, 721, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 713, 0, 0, 0, 0, 0, 106, 0, 0, 106, 0,
                    0, 0, 0, 106, 0, 0, 0, 0, 106, 0, 0, 106, 106, 106, 106, 106, 106, 106, 106, 106, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 0, 110, 0, 0, 0, 0, 110, 0, 0, 0, 0, 110,
                    0, 0, 110, 110, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 725,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 318, 0, 0, 0, 0, 0, 0, 0, 0, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 729, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 326, 0, 0, 326, 0, 0, 0, 0, 326, 0,
                    0, 0, 0, 0, 0, 0, 326, 0, 0, 0, 0, 0, 326, 326, 326, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 0, 0, 0, 58, 58,
                    58, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0,
                    0, 62, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 0, 0, 0, 62, 62, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 0, 0, 0, 66,
                    66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0,
                    0, 0, 70, 0, 0, 0, 0, 0, 0, 0, 70, 737, 741, 745, 749, 753, 70, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0, 0, 0, 94, 0, 0, 0, 0, 0, 0, 0, 94, 94,
                    94, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    98, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 0, 0, 0, 0, 0, 98, 98, 98, 98, 98, 98, 98, 98, 98, 98, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102, 0, 0, 0, 0,
                    0, 0, 0, 102, 102, 102, 102, 102, 102, 102, 102, 102, 102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 0, 114, 0, 0, 0, 0, 114, 0, 0, 0, 0, 0, 0, 0, 114, 114, 114, 114,
                    114, 114, 114, 114, 114, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122,
                    0, 0, 122, 0, 0, 0, 0, 122, 0, 0, 0, 0, 0, 0, 0, 122, 122, 122, 122, 122, 122, 122, 122, 122, 122, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 0, 130, 0, 0, 0, 0, 130, 0,
                    0, 0, 0, 0, 0, 0, 130, 130, 130, 130, 130, 130, 130, 130, 130, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 477, 0, 0, 481, 0, 0, 0, 0, 485, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 0,
                    0, 0, 489, 493, 497, 54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 757, 433, 437, 441, 445,
                    449, 453, 457, 461, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138, 0, 0, 0, 0, 0, 0, 0, 138, 138, 138, 138, 138, 138, 138,
                    138, 138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 134, 0, 0, 134, 0,
                    0, 0, 0, 134, 0, 0, 0, 0, 0, 0, 0, 134, 134, 134, 134, 134, 134, 134, 134, 134, 134, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 761, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 477,
                    0, 0, 481, 0, 0, 0, 0, 485, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 497, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 765, 461, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 477, 0, 0, 481, 0, 0, 0, 0, 485, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 497, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 769, 461, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 477, 0, 0, 481, 0, 0, 0, 0, 485, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 489, 493,
                    497, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 773, 421, 425, 429, 433, 437, 441, 445, 449, 453,
                    457, 461, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0, 0, 0, 0,
                    0, 0, 146, 0, 0, 0, 0, 0, 0, 0, 0, 146, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0,
                    0, 777, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 329, 0, 333, 337, 341, 345, 349, 0, 0, 0, 0, 0, 0, 382, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 353, 0, 0,
                    382, 357, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 265, 0, 0, 0, 781,
                    277, 281, 285, 289, 293, 297, 301, 0, 305, 309, 313, 317, 321, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 325, 0,
                    837, 0, 841, 845, 849, 853, 857, 0, 0, 0, 0, 0, 0, 382, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 861, 0, 0, 0,
                    865, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 785, 0, 0, 0, 0, 0, 789,
                    793, 797, 801, 805, 809, 0, 813, 817, 821, 825, 829, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 833, 0, 202, 0, 202,
                    202, 202, 202, 202, 0, 0, 0, 0, 0, 0, 202, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 202, 0, 0, 202, 202, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 869, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 190, 0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 190, 0, 0, 190,
                    190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0,
                    0, 0, 0, 0, 0, 194, 0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 194, 0, 0, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 0, 0, 0, 0, 0, 198, 0, 0, 198, 0, 0,
                    0, 0, 0, 0, 0, 198, 0, 0, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 877, 0, 0, 881, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 873, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 374, 374, 374, 374, 374, 0, 0, 0, 0, 0, 0, 374, 0,
                    0, 374, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 374, 374, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 250, 0, 250, 250, 250, 250, 250, 0, 250, 0, 0, 0, 0, 0, 0, 0, 250, 250, 250, 0, 250, 0, 0, 0,
                    250, 250, 0, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 885, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 0,
                    0, 0, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 889, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 0, 0, 0, 0,
                    0, 0, 154, 0, 897, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 378, 378, 378,
                    378, 378, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 378, 378, 0, 378, 378, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 170, 0, 0, 0, 0, 0, 0, 0, 170, 170, 0, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 174, 0, 174, 174, 174, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 174, 174,
                    0, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 178, 178, 0, 178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0,
                    0, 0, 0, 0, 0, 0, 182, 182, 0, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    186, 0, 186, 186, 186, 186, 186, 0, 905, 0, 0, 0, 0, 0, 0, 0, 186, 909, 913, 0, 917, 0, 0, 0, 186, 186,
                    0, 186, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 901, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214,
                    214, 0, 214, 0, 0, 0, 0, 0, 0, 0, 214, 214, 214, 0, 214, 0, 0, 0, 214, 214, 0, 214, 214, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0,
                    0, 0, 0, 210, 210, 210, 0, 210, 0, 0, 0, 210, 210, 0, 210, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 0, 0, 0, 234, 234, 234, 0,
                    234, 0, 0, 0, 234, 234, 0, 234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 921, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    166, 0, 0, 0, 0, 0, 0, 0, 633, 166, 0, 166, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 545, 0, 0, 0, 0, 0, 0, 925, 569, 573, 577, 581, 0, 585, 589, 593, 597, 601, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 138, 138, 138, 138, 138, 0, 138, 0, 0, 0, 0, 0, 0, 0, 138, 138, 138,
                    0, 138, 0, 0, 0, 138, 138, 0, 138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226,
                    0, 226, 226, 226, 226, 226, 0, 226, 0, 0, 0, 0, 0, 0, 0, 226, 226, 226, 0, 226, 0, 0, 0, 226, 226, 0,
                    226, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230,
                    0, 230, 0, 0, 0, 0, 0, 0, 0, 230, 230, 230, 0, 230, 0, 0, 0, 230, 230, 0, 230, 230, 262, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 0,
                    0, 0, 242, 242, 242, 0, 242, 0, 0, 0, 242, 242, 0, 242, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 246, 0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 0, 0, 0, 0, 246, 246, 246, 0, 246,
                    0, 0, 0, 246, 246, 0, 246, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0,
                    238, 238, 238, 238, 238, 0, 238, 0, 0, 0, 0, 0, 0, 0, 238, 238, 238, 0, 238, 0, 0, 0, 238, 238, 0, 238,
                    238, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 545, 0, 0, 929, 553, 557, 561, 565, 569, 573, 577, 581, 0,
                    585, 589, 593, 597, 601, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 609, 0, 613, 617, 621, 625, 629, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 545, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 933, 597, 601, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0, 0, 0, 0, 222, 0, 0, 222, 222,
                    222, 0, 222, 0, 0, 0, 222, 0, 0, 222, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    241, 0, 0, 245, 0, 0, 0, 0, 249, 0, 0, 0, 0, 330, 0, 0, 330, 0, 0, 0, 0, 0, 253, 257, 261, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 937, 189, 193, 197, 201, 205, 209, 213, 217, 221, 225, 229, 233,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 237, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 314, 0, 0, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 0, 250, 0, 0, 0, 0, 250, 0, 0, 0, 0, 250, 0, 0, 250, 0, 0,
                    0, 0, 0, 250, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0,
                    0, 82, 0, 0, 0, 0, 82, 0, 0, 0, 0, 82, 0, 0, 82, 0, 0, 0, 0, 0, 82, 82, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 0, 214, 0, 0, 0, 0, 214, 0, 0, 0, 0, 214, 0, 0,
                    214, 0, 0, 0, 0, 0, 214, 214, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 210, 0, 0, 210, 0, 0, 0, 0, 210, 0, 0, 0, 0, 210, 0, 0, 210, 0, 0, 0, 0, 0, 210, 210, 210, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0, 0, 234, 0, 0, 0, 0, 234, 0,
                    0, 0, 0, 234, 0, 0, 234, 0, 0, 0, 0, 0, 234, 234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 941, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138,
                    0, 0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 0, 138, 138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 0, 226, 0, 0, 0, 0, 226, 0, 0, 0, 0, 226, 0, 0, 226, 0, 0, 0, 0, 0,
                    226, 226, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 0, 230,
                    0, 0, 0, 0, 230, 0, 0, 0, 0, 230, 0, 0, 230, 0, 0, 0, 0, 0, 230, 230, 230, 0, 0, 0, 0, 262, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 0, 242, 0, 0, 0, 0, 242, 0, 0, 0, 0, 242, 0,
                    0, 242, 0, 0, 0, 0, 0, 242, 242, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 246, 0, 0, 246, 0, 0, 0, 0, 246, 0, 0, 0, 0, 246, 0, 0, 246, 0, 0, 0, 0, 0, 246, 246, 246, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 0, 238, 0, 0, 0, 0, 238,
                    0, 0, 0, 0, 238, 0, 0, 238, 0, 0, 0, 0, 0, 238, 238, 238, 0, 0, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0,
                    0, 0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 545, 0, 0, 945, 553, 557, 561, 565, 569, 573, 577, 581, 0, 585, 589, 593, 597, 601, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 605, 0, 677, 0, 681, 685, 689, 693, 697, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 653,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 949, 669, 673, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0,
                    90, 0, 0, 0, 0, 90, 0, 0, 0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 0, 90, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 1017, 0, 0, 0, 0, 1021, 330, 0, 0, 0, 0, 0, 0,
                    330, 0, 0, 0, 0, 0, 1025, 1029, 1033, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 953, 957, 961, 965,
                    969, 973, 977, 981, 985, 989, 993, 997, 1001, 1005, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1009, 0, 0, 0, 0, 0, 0, 334, 0, 0, 334, 0, 0, 0, 0, 334, 334, 0, 0, 0, 0, 0, 0, 334, 0,
                    0, 0, 0, 0, 334, 334, 334, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 338,
                    0, 0, 338, 0, 0, 0, 0, 338, 338, 0, 0, 0, 0, 0, 0, 338, 0, 0, 0, 0, 0, 338, 338, 338, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 0, 0, 0, 0,
                    118, 0, 0, 118, 118, 118, 118, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1037, 0, 0, 0, 0, 0, 0, 0,
                    0, 46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 477, 0, 0, 481, 0, 0, 0, 0,
                    485, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 489, 493, 497, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 1041, 425, 429, 433, 437, 441, 445, 449, 453, 457, 461, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 473, 0, 0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 0, 0, 0,
                    0, 0, 0, 0, 74, 0, 0, 0, 0, 0, 74, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 78, 0, 0, 78, 0, 0, 0, 0, 78, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 0, 0, 0, 78, 78, 78, 78,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1069, 0, 1073, 1077, 1081, 1085,
                    1089, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1093, 0, 0, 0, 1097, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1045, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1049, 1053,
                    1057, 1061, 1065, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86, 0, 0, 0, 0, 0, 0,
                    0, 86, 0, 0, 0, 0, 0, 86, 86, 86, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1069, 0, 1073, 1077, 1081, 1085, 1089, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1093,
                    0, 0, 0, 1097, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1045, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1101, 1053, 1057, 1061, 1065, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 322, 0,
                    0, 322, 0, 0, 0, 0, 322, 0, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 0, 0, 322, 322, 322, 322, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 717, 721, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 0, 0, 0,
                    0, 106, 0, 0, 106, 0, 0, 0, 0, 106, 0, 0, 0, 0, 0, 0, 0, 106, 106, 106, 106, 106, 106, 106, 106, 106,
                    106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 0, 110, 0, 0, 0, 0,
                    110, 0, 0, 0, 0, 0, 0, 0, 110, 110, 110, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1109, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 329, 0, 333,
                    337, 341, 345, 349, 0, 0, 0, 0, 0, 0, 382, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 353, 0, 0, 382, 357, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 265, 0, 0, 0, 1113, 277, 281, 285,
                    289, 293, 297, 301, 0, 305, 309, 313, 317, 321, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 325, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 0, 366, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250, 250, 0, 250, 0, 0, 0, 0, 250, 0, 0, 250,
                    250, 250, 0, 250, 0, 0, 0, 250, 0, 0, 0, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 0, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 378, 378, 378, 378, 378, 0, 0, 0, 0, 0, 0,
                    378, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 378, 0, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0, 170, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0,
                    170, 0, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 174, 174, 174,
                    174, 174, 0, 0, 0, 0, 0, 0, 174, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 174, 0, 0, 0, 174, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 0, 0, 0, 0, 0, 178, 0,
                    0, 178, 0, 0, 0, 0, 0, 0, 0, 178, 0, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 182, 0, 0, 182, 0, 0, 0, 0, 0, 0, 0, 182, 0,
                    0, 0, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186,
                    0, 1121, 0, 0, 0, 0, 186, 0, 0, 186, 1125, 1129, 0, 1133, 0, 0, 0, 186, 0, 0, 0, 186, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1117, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214, 214, 214, 214, 0, 214, 0, 0, 0, 0,
                    214, 0, 0, 214, 214, 214, 0, 214, 0, 0, 0, 214, 0, 0, 0, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 210, 0, 0, 210, 210, 210, 0,
                    210, 0, 0, 0, 210, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0,
                    234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 234, 0, 0, 234, 234, 234, 0, 234, 0, 0, 0, 234, 0, 0, 0,
                    234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 837, 0, 841, 845, 849, 853, 857, 0, 0, 0, 0, 0, 0, 166, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0, 861,
                    0, 0, 0, 865, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 785, 0, 0, 0, 0,
                    0, 0, 1141, 797, 801, 805, 809, 0, 813, 817, 821, 825, 829, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138,
                    0, 138, 138, 138, 138, 138, 0, 138, 0, 0, 0, 0, 138, 0, 0, 138, 138, 138, 0, 138, 0, 0, 0, 138, 0, 0,
                    0, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226,
                    0, 226, 0, 0, 0, 0, 226, 0, 0, 226, 226, 226, 0, 226, 0, 0, 0, 226, 0, 0, 0, 226, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 0, 230, 0, 0,
                    230, 230, 230, 0, 230, 0, 0, 0, 230, 0, 0, 0, 230, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 242, 0, 242, 242, 242, 242, 242, 0, 242, 0, 0, 0, 0, 242, 0, 0, 242, 242, 242, 0, 242, 0,
                    0, 0, 242, 0, 0, 0, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 246, 246,
                    246, 246, 246, 0, 246, 0, 0, 0, 0, 246, 0, 0, 246, 246, 246, 0, 246, 0, 0, 0, 246, 0, 0, 0, 246, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 238, 238, 238, 238, 238, 0, 238, 0, 0,
                    0, 0, 238, 0, 0, 238, 238, 238, 0, 238, 0, 0, 0, 238, 0, 0, 0, 238, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0,
                    0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 545, 0, 0, 1145, 553, 557, 561, 565, 569, 573, 577, 581, 0, 585, 589, 593, 597, 601, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 605, 0, 837, 0, 841, 845, 849, 853, 857, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 785,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1149, 825, 829, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 390, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1157, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1153, 254, 0, 254, 254, 254, 254, 254, 0, 254, 0, 0, 0, 0, 254,
                    0, 0, 254, 254, 254, 0, 254, 0, 0, 0, 254, 0, 0, 254, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 262, 0, 262, 262, 262, 262, 262, 0, 262, 0, 0, 0, 0, 262, 0, 0, 262, 262, 262, 0, 262,
                    0, 0, 0, 262, 0, 0, 262, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 258,
                    258, 258, 258, 258, 0, 258, 0, 0, 0, 0, 258, 0, 0, 258, 258, 258, 0, 258, 0, 0, 0, 258, 0, 0, 258, 258,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218, 218, 218, 218, 0, 218,
                    0, 0, 0, 0, 218, 0, 0, 218, 218, 218, 0, 218, 0, 0, 0, 218, 0, 0, 218, 218, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1161, 0, 0, 0, 0, 0,
                    0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617,
                    621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 545, 0, 0, 0, 1165, 557, 561, 565, 569, 573,
                    577, 581, 0, 585, 589, 593, 597, 601, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 1221, 0, 1225, 1229, 1233,
                    1237, 1241, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 1245, 382, 0, 0, 1249, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1169, 0, 0, 0, 0, 0, 1173, 1177, 1181, 1185,
                    1189, 1193, 0, 1197, 1201, 1205, 1209, 1213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1217, 0, 202, 0, 202, 202,
                    202, 202, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 202, 202, 0, 202, 202, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1253, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190,
                    0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 190, 190, 0, 190, 190,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 194, 194, 0, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 0, 0, 0,
                    0, 0, 0, 198, 198, 0, 198, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1261, 0, 0, 1265, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 1257, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 374, 374, 374, 374, 374, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 374, 0, 0, 0, 0, 0, 0, 0, 374, 374, 0, 374, 374, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1269, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0,
                    0, 0, 0, 0, 0, 0, 222, 222, 222, 0, 222, 0, 0, 0, 222, 222, 0, 222, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 310, 0, 0, 310, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1277, 0, 0, 1281,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1273, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1285, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 0, 222, 0, 0, 0, 0,
                    222, 0, 0, 0, 0, 222, 0, 0, 222, 0, 0, 0, 0, 0, 222, 222, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1289, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 318, 0, 0, 0, 0, 0, 0, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 1293, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 326, 0, 0, 326, 0, 0, 0,
                    0, 326, 326, 0, 0, 0, 0, 0, 0, 326, 0, 0, 0, 0, 0, 326, 326, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 58, 0, 0, 0, 0, 0, 0, 58, 0, 0, 0,
                    0, 0, 58, 58, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62,
                    0, 0, 0, 0, 62, 62, 0, 0, 0, 0, 0, 0, 62, 0, 0, 0, 0, 0, 62, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 66, 0, 0, 0, 0, 0, 0, 66, 0, 0,
                    0, 0, 0, 66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0,
                    70, 0, 0, 0, 0, 70, 70, 0, 0, 0, 0, 0, 0, 70, 1301, 1305, 1309, 1313, 1317, 70, 70, 70, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0, 0, 0, 94, 94, 0, 0, 0, 0,
                    0, 0, 94, 94, 94, 94, 94, 94, 94, 94, 94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 98, 0, 0, 0, 0, 0, 0, 98, 98, 98, 98, 98, 98, 98, 98, 98, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 0, 102, 0, 0, 0, 0, 102,
                    102, 0, 0, 0, 0, 0, 0, 102, 102, 102, 102, 102, 102, 102, 102, 102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 0, 114, 0, 0, 0, 0, 114, 114, 0, 0, 0, 0, 0, 0, 114, 114,
                    114, 114, 114, 114, 114, 114, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 122, 0, 0, 122, 0, 0, 0, 0, 122, 122, 0, 0, 0, 0, 0, 0, 122, 122, 122, 122, 122, 122, 122, 122,
                    122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 0, 0, 130, 0, 0, 0,
                    0, 130, 130, 0, 0, 0, 0, 0, 0, 130, 130, 130, 130, 130, 130, 130, 130, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 1017, 0, 0, 0, 0, 1021, 54, 0, 0, 0, 0, 0, 0,
                    54, 0, 0, 0, 0, 0, 1025, 1029, 1033, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1321, 969,
                    973, 977, 981, 985, 989, 993, 997, 1001, 1005, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138, 138, 0, 0, 0, 0, 0, 0, 138, 138, 138,
                    138, 138, 138, 138, 138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    134, 0, 0, 134, 0, 0, 0, 0, 134, 134, 0, 0, 0, 0, 0, 0, 134, 134, 134, 134, 134, 134, 134, 134, 134,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1325, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1013, 0, 0, 1017, 0, 0, 0, 0, 1021, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1033,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1329, 997, 1001, 1005, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 1017,
                    0, 0, 0, 0, 1021, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1033, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1333, 997, 1001, 1005, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 477, 0, 0, 481, 0, 0, 0, 0, 485, 0, 0, 0, 0, 0, 0,
                    0, 330, 0, 0, 0, 0, 0, 489, 493, 497, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1337, 421, 425,
                    429, 433, 437, 441, 445, 449, 453, 457, 461, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 473, 0, 0, 0, 0, 0, 0, 477, 0, 0, 481, 0, 0, 0, 0, 485, 0, 0, 0, 0, 0, 0, 0, 330, 0,
                    0, 0, 0, 0, 489, 493, 497, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1341, 425, 429, 433, 437,
                    441, 445, 449, 453, 457, 461, 465, 469, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 473, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 314, 0, 0, 0, 0, 0, 0, 0, 0,
                    314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 0, 250, 0, 0, 0, 0,
                    250, 0, 0, 0, 0, 0, 0, 0, 250, 0, 0, 0, 0, 0, 250, 250, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 82, 0, 0, 0, 0, 82, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 0, 0, 0,
                    82, 82, 82, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 0, 214, 0,
                    0, 0, 0, 214, 0, 0, 0, 0, 0, 0, 0, 214, 0, 0, 0, 0, 0, 214, 214, 214, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 0, 210, 0, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 210,
                    0, 0, 0, 0, 0, 210, 210, 210, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 234, 0, 0, 234, 0, 0, 0, 0, 234, 0, 0, 0, 0, 0, 0, 0, 234, 0, 0, 0, 0, 0, 234, 234, 234, 234, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1345, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138, 0, 0, 0, 0, 0, 0, 0, 138, 0, 0, 0, 0, 0, 138, 138, 138, 138,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 0, 226, 0, 0, 0, 0, 226,
                    0, 0, 0, 0, 0, 0, 0, 226, 0, 0, 0, 0, 0, 226, 226, 226, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 0, 230, 0, 0, 0, 0, 230, 0, 0, 0, 0, 0, 0, 0, 230, 0, 0, 0, 0, 0,
                    230, 230, 230, 230, 0, 0, 0, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 0,
                    242, 0, 0, 0, 0, 242, 0, 0, 0, 0, 0, 0, 0, 242, 0, 0, 0, 0, 0, 242, 242, 242, 242, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 0, 246, 0, 0, 0, 0, 246, 0, 0, 0, 0, 0, 0,
                    0, 246, 0, 0, 0, 0, 0, 246, 246, 246, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 238, 0, 0, 238, 0, 0, 0, 0, 238, 0, 0, 0, 0, 0, 0, 0, 238, 0, 0, 0, 0, 0, 238, 238, 238, 238,
                    0, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 545, 0, 0, 1349, 553, 557, 561, 565, 569, 573, 577, 581,
                    0, 585, 589, 593, 597, 601, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 1069, 0, 1073, 1077, 1081, 1085, 1089,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1045, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1353, 1061, 1065,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0,
                    0, 90, 90, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 1017,
                    0, 0, 0, 0, 1021, 330, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 1025, 1029, 1033, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1357, 957, 961, 965, 969, 973, 977, 981, 985, 989, 993, 997, 1001, 1005, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1009, 0, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0,
                    0, 0, 118, 0, 0, 0, 0, 0, 0, 0, 118, 118, 118, 118, 118, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 0, 362,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202,
                    0, 202, 202, 202, 202, 202, 0, 0, 0, 0, 0, 0, 202, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 202, 0, 0, 0, 202,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1361, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 190, 0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 190, 0,
                    0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194,
                    0, 0, 0, 0, 0, 0, 194, 0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 194, 0, 0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 0, 0, 0, 0, 0, 198, 0, 0, 198, 0,
                    0, 0, 0, 0, 0, 0, 198, 0, 0, 0, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 1369, 0, 0, 1373, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1365, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 374, 374, 374, 374, 374, 0, 0, 0, 0, 0, 0, 374,
                    0, 0, 374, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 374, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1377, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222, 222, 222, 0, 222, 0,
                    0, 0, 0, 222, 0, 0, 222, 222, 222, 0, 222, 0, 0, 0, 222, 0, 0, 0, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1381, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1385, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0,
                    0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 545, 0, 0, 0, 1389, 557, 561, 565, 569, 573, 577, 581, 0, 585, 589, 593, 597, 601, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 605, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 0, 0, 0, 0, 0, 0, 0, 366,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 250, 250, 250, 250, 250,
                    0, 250, 0, 0, 0, 0, 0, 0, 0, 250, 250, 250, 0, 250, 0, 0, 0, 250, 250, 0, 0, 250, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 0, 0,
                    0, 0, 0, 0, 0, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 378,
                    378, 378, 378, 378, 0, 0, 0, 0, 0, 0, 0, 0, 0, 378, 0, 0, 0, 0, 0, 0, 0, 378, 378, 0, 0, 378, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 170, 170, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 174, 0, 174, 174, 174, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0,
                    174, 174, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 178, 178, 178,
                    178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 178, 178, 0, 0, 178, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 182, 0, 182, 182, 182, 182, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    182, 0, 0, 0, 0, 0, 0, 0, 182, 182, 0, 0, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 1397, 0, 0, 0, 0, 0, 0, 0, 186, 1401, 1405, 0, 1409, 0, 0,
                    0, 186, 186, 0, 0, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1393, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 214, 214,
                    214, 214, 214, 0, 214, 0, 0, 0, 0, 0, 0, 0, 214, 214, 214, 0, 214, 0, 0, 0, 214, 214, 0, 0, 214, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0,
                    0, 0, 0, 0, 0, 210, 210, 210, 0, 210, 0, 0, 0, 210, 210, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0, 234, 234, 234, 234, 234, 0, 234, 0, 0, 0, 0, 0, 0, 0, 234, 234, 234,
                    0, 234, 0, 0, 0, 234, 234, 0, 0, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1413, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1221, 0, 1225, 1229, 1233, 1237, 1241, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0, 1245, 166, 0, 0, 1249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1169, 0, 0, 0, 0, 0, 0, 1417, 1181, 1185, 1189, 1193, 0, 1197, 1201, 1205,
                    1209, 1213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 138, 138, 138, 138, 138, 0, 138, 0, 0, 0, 0,
                    0, 0, 0, 138, 138, 138, 0, 138, 0, 0, 0, 138, 138, 0, 0, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 226, 0, 226, 226, 226, 226, 226, 0, 226, 0, 0, 0, 0, 0, 0, 0, 226, 226, 226, 0,
                    226, 0, 0, 0, 226, 226, 0, 0, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230,
                    0, 230, 230, 230, 230, 230, 0, 230, 0, 0, 0, 0, 0, 0, 0, 230, 230, 230, 0, 230, 0, 0, 0, 230, 230, 0,
                    0, 230, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 242, 242, 242, 242, 242,
                    0, 242, 0, 0, 0, 0, 0, 0, 0, 242, 242, 242, 0, 242, 0, 0, 0, 242, 242, 0, 0, 242, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 246, 246, 246, 246, 246, 0, 246, 0, 0, 0, 0, 0, 0, 0,
                    246, 246, 246, 0, 246, 0, 0, 0, 246, 246, 0, 0, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 238, 0, 238, 238, 238, 238, 238, 0, 238, 0, 0, 0, 0, 0, 0, 0, 238, 238, 238, 0, 238, 0, 0,
                    0, 238, 238, 0, 0, 238, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617,
                    621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0, 0, 0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 545, 0, 0, 1421, 553, 557, 561, 565, 569,
                    573, 577, 581, 0, 585, 589, 593, 597, 601, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 605, 0, 1221, 0, 1225, 1229,
                    1233, 1237, 1241, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1169, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1425, 1209, 1213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 390, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1157, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1429, 254, 0, 254, 254, 254, 254, 254, 0, 254, 0, 0, 0, 0, 0, 0, 0, 254, 254, 254, 0, 254, 0, 0, 0, 254,
                    254, 0, 254, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262, 0, 262, 262, 262,
                    262, 262, 0, 262, 0, 0, 0, 0, 0, 0, 0, 262, 262, 262, 0, 262, 0, 0, 0, 262, 262, 0, 262, 262, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 258, 258, 258, 258, 258, 0, 258, 0, 0, 0,
                    0, 0, 0, 0, 258, 258, 258, 0, 258, 0, 0, 0, 258, 258, 0, 258, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218, 218, 218, 218, 0, 218, 0, 0, 0, 0, 0, 0, 0, 218, 218, 218,
                    0, 218, 0, 0, 0, 218, 218, 0, 218, 218, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 254,
                    0, 0, 254, 0, 0, 0, 0, 254, 0, 0, 0, 0, 254, 0, 0, 254, 0, 0, 0, 0, 0, 254, 254, 254, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262, 0, 0, 262, 0, 0, 0, 0, 262, 0, 0, 0, 0,
                    262, 0, 0, 262, 0, 0, 0, 0, 0, 262, 262, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 258, 0, 0, 258, 0, 0, 0, 0, 258, 0, 0, 0, 0, 258, 0, 0, 258, 0, 0, 0, 0, 0, 258, 258,
                    258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 0, 218, 0, 0, 0,
                    0, 218, 0, 0, 0, 0, 218, 0, 0, 218, 0, 0, 0, 0, 0, 218, 218, 218, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 126, 0, 0, 0, 0, 126, 0, 0, 0, 0, 126, 0, 0, 126, 126,
                    126, 126, 126, 126, 126, 126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 0, 0, 0, 1433, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 1017, 0, 0, 0, 0, 1021, 330, 0, 0,
                    0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 1025, 1029, 1033, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1437,
                    961, 965, 969, 973, 977, 981, 985, 989, 993, 997, 1001, 1005, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1009, 0, 0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 74, 0, 0, 0, 0, 0, 0,
                    74, 0, 0, 0, 0, 0, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    78, 0, 0, 78, 0, 0, 0, 0, 78, 78, 0, 0, 0, 0, 0, 0, 78, 0, 0, 0, 0, 0, 78, 78, 78, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1465, 0, 1469, 1473, 1477, 1481, 1485, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1489, 0, 0, 0, 1493, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1441, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1445, 1449, 1453, 1457, 1461,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 86, 0, 0, 86, 0, 0, 0, 0, 86, 86, 0, 0, 0, 0, 0, 0, 86, 0, 0, 0,
                    0, 0, 86, 86, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1465, 0, 1469,
                    1473, 1477, 1481, 1485, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1489, 0, 0, 0, 1493, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1441, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1497, 1449, 1453, 1457, 1461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 322, 0, 0, 322, 0, 0, 0, 0, 322,
                    322, 0, 0, 0, 0, 0, 0, 322, 0, 0, 0, 0, 0, 322, 322, 322, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 717, 721, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1501, 0, 0, 0, 0, 0, 106, 0, 0, 106, 0, 0, 0,
                    0, 106, 106, 0, 0, 0, 0, 0, 0, 106, 106, 106, 106, 106, 106, 106, 106, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 0, 110, 0, 0, 0, 0, 110, 110, 0, 0, 0, 0, 0, 0,
                    110, 110, 110, 110, 110, 110, 110, 110, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1505, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 310, 0, 0, 0, 0, 0, 0, 0, 0, 310, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1513, 0, 0, 1517, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1509, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1521, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 222, 0, 0, 222, 0, 0, 0, 0, 222, 0, 0, 0, 0, 0, 0, 0, 222, 0, 0, 0, 0, 0, 222, 222, 222, 222,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1525,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 390, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1157, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1529, 254, 0, 254, 254, 254, 254, 254,
                    0, 254, 0, 0, 0, 0, 254, 0, 0, 254, 254, 254, 0, 254, 0, 0, 0, 254, 0, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262, 0, 262, 262, 262, 262, 262, 0, 262, 0, 0, 0, 0, 262, 0, 0,
                    262, 262, 262, 0, 262, 0, 0, 0, 262, 0, 0, 0, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 258, 0, 258, 258, 258, 258, 258, 0, 258, 0, 0, 0, 0, 258, 0, 0, 258, 258, 258, 0, 258, 0, 0,
                    0, 258, 0, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218, 218,
                    218, 218, 0, 218, 0, 0, 0, 0, 218, 0, 0, 218, 218, 218, 0, 218, 0, 0, 0, 218, 0, 0, 0, 218, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 0, 0, 0, 0, 0,
                    206, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 206, 0, 0, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 386, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 362, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 202, 202,
                    0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1533, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 0, 0, 0, 0, 0,
                    0, 190, 190, 0, 0, 190, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194,
                    194, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 194, 194, 0, 0, 194, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 198, 0, 0, 0, 0, 0, 0, 0, 198, 198, 0, 0, 198, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1541, 0, 0, 1545, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1537, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 374, 374, 374, 374, 374, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 374, 0, 0, 0, 0, 0, 0, 0, 374, 374, 0, 0, 374, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 1549, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 222, 222, 222,
                    222, 222, 0, 222, 0, 0, 0, 0, 0, 0, 0, 222, 222, 222, 0, 222, 0, 0, 0, 222, 222, 0, 0, 222, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1553, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013,
                    0, 0, 1017, 0, 0, 0, 0, 1021, 330, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 1025, 1029, 1033, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1557, 961, 965, 969, 973, 977, 981, 985, 989, 993, 997, 1001, 1005,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1009, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 314, 0, 0, 0, 0, 0, 0, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, 0, 0, 250, 0, 0, 0, 0, 250, 250, 0, 0, 0, 0, 0, 0, 250, 0, 0,
                    0, 0, 0, 250, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0,
                    0, 82, 0, 0, 0, 0, 82, 82, 0, 0, 0, 0, 0, 0, 82, 0, 0, 0, 0, 0, 82, 82, 82, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 0, 214, 0, 0, 0, 0, 214, 214, 0, 0, 0, 0, 0, 0,
                    214, 0, 0, 0, 0, 0, 214, 214, 214, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 210, 0, 0, 210, 0, 0, 0, 0, 210, 210, 0, 0, 0, 0, 0, 0, 210, 0, 0, 0, 0, 0, 210, 210, 210, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 234, 0, 0, 234, 0, 0, 0, 0, 234, 234,
                    0, 0, 0, 0, 0, 0, 234, 0, 0, 0, 0, 0, 234, 234, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 1561, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138,
                    138, 0, 0, 0, 0, 0, 0, 138, 0, 0, 0, 0, 0, 138, 138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 0, 226, 0, 0, 0, 0, 226, 226, 0, 0, 0, 0, 0, 0, 226, 0, 0, 0, 0, 0,
                    226, 226, 226, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 230, 0, 0, 230,
                    0, 0, 0, 0, 230, 230, 0, 0, 0, 0, 0, 0, 230, 0, 0, 0, 0, 0, 230, 230, 230, 0, 0, 0, 0, 262, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 0, 242, 0, 0, 0, 0, 242, 242, 0, 0, 0, 0, 0,
                    0, 242, 0, 0, 0, 0, 0, 242, 242, 242, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 246, 0, 0, 246, 0, 0, 0, 0, 246, 246, 0, 0, 0, 0, 0, 0, 246, 0, 0, 0, 0, 0, 246, 246, 246, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 0, 238, 0, 0, 0, 0, 238,
                    238, 0, 0, 0, 0, 0, 0, 238, 0, 0, 0, 0, 0, 238, 238, 238, 0, 0, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 609, 0, 613, 617, 621, 625, 629, 0, 0, 0, 0, 0, 0, 0, 0, 0, 382, 0, 0,
                    0, 0, 0, 0, 0, 633, 382, 0, 382, 637, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 545, 0, 0, 1565, 553, 557, 561, 565, 569, 573, 577, 581, 0, 585, 589, 593, 597, 601, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 605, 0, 1465, 0, 1469, 1473, 1477, 1481, 1485, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 1441, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1569, 1457, 1461, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 90, 0, 0, 90, 0, 0, 0, 0, 90, 90, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0, 90, 90, 90, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1013, 0, 0, 1017, 0, 0, 0, 0, 1021, 330, 0,
                    0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 1025, 1029, 1033, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1573,
                    957, 961, 965, 969, 973, 977, 981, 985, 989, 993, 997, 1001, 1005, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1009, 0, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 118, 0, 0, 0,
                    0, 0, 0, 118, 118, 118, 118, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 254, 0, 0, 254, 0, 0, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0, 254, 0, 0, 0, 0, 0, 254,
                    254, 254, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262, 0, 0, 262, 0,
                    0, 0, 0, 262, 0, 0, 0, 0, 0, 0, 0, 262, 0, 0, 0, 0, 0, 262, 262, 262, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 0, 258, 0, 0, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0, 258,
                    0, 0, 0, 0, 0, 258, 258, 258, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 218, 0, 0, 218, 0, 0, 0, 0, 218, 0, 0, 0, 0, 0, 0, 0, 218, 0, 0, 0, 0, 0, 218, 218, 218, 218, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 126, 0, 0, 0, 0, 126, 0, 0,
                    0, 0, 0, 0, 0, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1577, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 390, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1157, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1581, 254, 0, 254, 254, 254, 254, 254, 0, 254, 0, 0, 0, 0, 0, 0, 0, 254, 254,
                    254, 0, 254, 0, 0, 0, 254, 254, 0, 0, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    262, 0, 262, 262, 262, 262, 262, 0, 262, 0, 0, 0, 0, 0, 0, 0, 262, 262, 262, 0, 262, 0, 0, 0, 262, 262,
                    0, 0, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 258, 258, 258, 258, 258,
                    0, 258, 0, 0, 0, 0, 0, 0, 0, 258, 258, 258, 0, 258, 0, 0, 0, 258, 258, 0, 0, 258, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 218, 218, 218, 218, 218, 0, 218, 0, 0, 0, 0, 0, 0, 0,
                    218, 218, 218, 0, 218, 0, 0, 0, 218, 218, 0, 0, 218, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 206,
                    206, 0, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 310, 0, 0, 0, 0, 0, 0, 310, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1589, 0, 0, 1593, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1585, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1597, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 222, 0, 0, 222, 0, 0, 0, 0, 222, 222, 0, 0, 0, 0, 0, 0, 222, 0, 0, 0, 0, 0, 222,
                    222, 222, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 1601, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 0, 0, 0, 0, 0, 206, 0, 0, 206, 0, 0, 0,
                    0, 0, 0, 0, 206, 0, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1605, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 254, 0, 0, 254, 0, 0, 0, 0, 254, 254, 0, 0, 0, 0, 0, 0, 254, 0, 0,
                    0, 0, 0, 254, 254, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262,
                    0, 0, 262, 0, 0, 0, 0, 262, 262, 0, 0, 0, 0, 0, 0, 262, 0, 0, 0, 0, 0, 262, 262, 262, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 0, 258, 0, 0, 0, 0, 258, 258, 0, 0,
                    0, 0, 0, 0, 258, 0, 0, 0, 0, 0, 258, 258, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 218, 0, 0, 218, 0, 0, 0, 0, 218, 218, 0, 0, 0, 0, 0, 0, 218, 0, 0, 0, 0, 0, 218, 218,
                    218, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 126, 0, 0, 0,
                    0, 126, 126, 0, 0, 0, 0, 0, 0, 126, 126, 126, 126, 126, 126, 126, 126, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 206, 0, 0, 0, 0, 0, 0, 0, 206, 206, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0,
                };
                
                return U16ParseTable.From(u16Table, 402, 33, 83);
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
            public static readonly TerminalSymbol __T10 = new TerminalSymbol(16, "__T10", false, "|");
            public static readonly TerminalSymbol __T11 = new TerminalSymbol(17, "__T11", true, "?");
            public static readonly TerminalSymbol __T12 = new TerminalSymbol(18, "__T12", true, "*");
            public static readonly TerminalSymbol __T13 = new TerminalSymbol(19, "__T13", false, "*:");
            public static readonly TerminalSymbol __T14 = new TerminalSymbol(20, "__T14", true, "+");
            public static readonly TerminalSymbol __T15 = new TerminalSymbol(21, "__T15", false, "+:");
            public static readonly TerminalSymbol __T16 = new TerminalSymbol(22, "__T16", false, ",");
            public static readonly TerminalSymbol __T17 = new TerminalSymbol(23, "__T17", false, "^");
            public static readonly TerminalSymbol __T18 = new TerminalSymbol(24, "__T18", false, "(");
            public static readonly TerminalSymbol __T19 = new TerminalSymbol(25, "__T19", false, ")");
            public static readonly TerminalSymbol __T20 = new TerminalSymbol(26, "__T20", false, "terminals");
            public static readonly TerminalSymbol __T21 = new TerminalSymbol(27, "__T21", false, "-");
            public static readonly TerminalSymbol __T22 = new TerminalSymbol(28, "__T22", false, "~");
            public static readonly TerminalSymbol __T23 = new TerminalSymbol(29, "__T23", false, "..");
            public static readonly TerminalSymbol __T24 = new TerminalSymbol(30, "__T24", true, ":");
            public static readonly TerminalSymbol __T25 = new TerminalSymbol(31, "__T25", true, "->");
            public static readonly TerminalSymbol __eof = new TerminalSymbol(32, "__eof", false, "$eof$");
            public static readonly NonterminalSymbol file = new NonterminalSymbol(33, "file", false, RepeatKind.None);
            public static readonly NonterminalSymbol angrammar = new NonterminalSymbol(34, "angrammar", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_item = new NonterminalSymbol(35, "grammar_item", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_options = new NonterminalSymbol(36, "grammar_options", false, RepeatKind.None);
            public static readonly NonterminalSymbol option = new NonterminalSymbol(37, "option", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_rules = new NonterminalSymbol(38, "grammar_rules", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule = new NonterminalSymbol(39, "rule", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_expression = new NonterminalSymbol(40, "rule_expression", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_alternative = new NonterminalSymbol(41, "rule_alternative", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_sequence = new NonterminalSymbol(42, "rule_sequence", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_repetition = new NonterminalSymbol(43, "rule_repetition", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_option = new NonterminalSymbol(44, "rule_option", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_star = new NonterminalSymbol(45, "rule_star", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_plus = new NonterminalSymbol(46, "rule_plus", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_tree_action = new NonterminalSymbol(47, "rule_tree_action", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_drop = new NonterminalSymbol(48, "rule_drop", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_promote = new NonterminalSymbol(49, "rule_promote", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_primary = new NonterminalSymbol(50, "rule_primary", false, RepeatKind.None);
            public static readonly NonterminalSymbol sub_rule = new NonterminalSymbol(51, "sub_rule", false, RepeatKind.None);
            public static readonly NonterminalSymbol rule_atom = new NonterminalSymbol(52, "rule_atom", false, RepeatKind.None);
            public static readonly NonterminalSymbol reference = new NonterminalSymbol(53, "reference", false, RepeatKind.None);
            public static readonly NonterminalSymbol grammar_terminals = new NonterminalSymbol(54, "grammar_terminals", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_rule = new NonterminalSymbol(55, "terminal_rule", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_expression = new NonterminalSymbol(56, "terminal_expression", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_alternative = new NonterminalSymbol(57, "terminal_alternative", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_diff = new NonterminalSymbol(58, "terminal_diff", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_sequence = new NonterminalSymbol(59, "terminal_sequence", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_repetition = new NonterminalSymbol(60, "terminal_repetition", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_option = new NonterminalSymbol(61, "terminal_option", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_star = new NonterminalSymbol(62, "terminal_star", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_plus = new NonterminalSymbol(63, "terminal_plus", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_range_loop = new NonterminalSymbol(64, "terminal_range_loop", false, RepeatKind.None);
            public static readonly NonterminalSymbol range = new NonterminalSymbol(65, "range", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_element = new NonterminalSymbol(66, "terminal_element", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_not = new NonterminalSymbol(67, "terminal_not", false, RepeatKind.None);
            public static readonly NonterminalSymbol terminal_atom = new NonterminalSymbol(68, "terminal_atom", false, RepeatKind.None);
            public static readonly NonterminalSymbol characterRange = new NonterminalSymbol(69, "characterRange", false, RepeatKind.None);
            public static readonly NonterminalSymbol character = new NonterminalSymbol(70, "character", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(71, "__N1", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(72, "__N2", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N3 = new NonterminalSymbol(73, "__N3", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N4 = new NonterminalSymbol(74, "__N4", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N5 = new NonterminalSymbol(75, "__N5", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N6 = new NonterminalSymbol(76, "__N6", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N7 = new NonterminalSymbol(77, "__N7", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N8 = new NonterminalSymbol(78, "__N8", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N9 = new NonterminalSymbol(79, "__N9", false, RepeatKind.None);
            public static readonly NonterminalSymbol __N10 = new NonterminalSymbol(80, "__N10", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N11 = new NonterminalSymbol(81, "__N11", false, RepeatKind.Star);
            public static readonly NonterminalSymbol __N12 = new NonterminalSymbol(82, "__N12", false, RepeatKind.Optional);
            public static readonly TerminalSymbol newline = new TerminalSymbol(83, "newline", false, "");
            public static readonly TerminalSymbol newlineChar = new TerminalSymbol(84, "newlineChar", false, "");
            public static readonly TerminalSymbol whitespace = new TerminalSymbol(85, "whitespace", false, "");
            public static readonly TerminalSymbol lineComment = new TerminalSymbol(86, "lineComment", false, "");
            public static readonly TerminalSymbol blockComment = new TerminalSymbol(87, "blockComment", false, "");
            public static readonly TerminalSymbol spacing = new TerminalSymbol(88, "spacing", false, "");
            public static readonly TerminalSymbol identifierStart = new TerminalSymbol(89, "identifierStart", false, "");
            public static readonly TerminalSymbol identifierContinue = new TerminalSymbol(90, "identifierContinue", false, "");
            public static readonly TerminalSymbol digit = new TerminalSymbol(91, "digit", false, "");
            public static readonly TerminalSymbol nonzeroDigit = new TerminalSymbol(92, "nonzeroDigit", false, "");
            public static readonly TerminalSymbol zero = new TerminalSymbol(93, "zero", false, "");
            public static readonly TerminalSymbol hexDigit = new TerminalSymbol(94, "hexDigit", false, "");
            public static readonly TerminalSymbol escapes = new TerminalSymbol(95, "escapes", false, "");
            public static readonly TerminalSymbol ucNameStart = new TerminalSymbol(96, "ucNameStart", false, "");
            public static readonly TerminalSymbol ucNameInner = new TerminalSymbol(97, "ucNameInner", false, "");
            public static readonly TerminalSymbol ucNameEnd = new TerminalSymbol(98, "ucNameEnd", false, "");
            public static readonly TerminalSymbol ucName = new TerminalSymbol(99, "ucName", false, "");
            public static readonly NonterminalSymbol __acc = new NonterminalSymbol(100, "__acc", true, RepeatKind.None);
            
            public static readonly Symbol[] Symbols = 
            {
                identifier, number, any, text, ucBlock, ucCategory, ucCodepoint, __T1, __T2, __T3, __T4, __T5, __T6, __T7,
                __T8, __T9, __T10, __T11, __T12, __T13, __T14, __T15, __T16, __T17, __T18, __T19, __T20, __T21, __T22, __T23,
                __T24, __T25, __eof, file, angrammar, grammar_item, grammar_options, option, grammar_rules, rule, rule_expression,
                rule_alternative, rule_sequence, rule_repetition, rule_option, rule_star, rule_plus, rule_tree_action, rule_drop,
                rule_promote, rule_primary, sub_rule, rule_atom, reference, grammar_terminals, terminal_rule, terminal_expression,
                terminal_alternative, terminal_diff, terminal_sequence, terminal_repetition, terminal_option, terminal_star,
                terminal_plus, terminal_range_loop, range, terminal_element, terminal_not, terminal_atom, characterRange,
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
                new Production(option, false, "option -> ^'Start' ,'=' ^ˈidentifierˈ ,';'", false, true, false, true),
                new Production(option, false, "option -> ^'Spacing' ,'=' ^ˈidentifierˈ ,';'", false, true, false, true),
                new Production(grammar_rules, false, "grammar_rules -> ,'rules' ,'{' ^__N3 ,'}'", true, true, false, true),
                new Production(rule, false, "rule -> ^ˈidentifierˈ ,__N4 ^rule_expression ,';'", false, true, false, true),
                new Production(rule_expression, false, "rule_expression -> ^rule_alternative ^__N5", false, false),
                new Production(rule_alternative, true, "rule_alternative -> ^rule_sequence", false),
                new Production(rule_sequence, false, "rule_sequence -> ^__N6", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_option", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_star", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_plus", false),
                new Production(rule_repetition, true, "rule_repetition -> ^rule_tree_action", false),
                new Production(rule_option, false, "rule_option -> ^rule_tree_action ,'?'", false, true),
                new Production(rule_star, false, "rule_star -> ^rule_tree_action ,'*'", false, true),
                new Production(rule_star, false, "rule_star -> ^rule_tree_action ,'*:' ^terminal_element", false, true, false),
                new Production(rule_plus, false, "rule_plus -> ^rule_tree_action ,'+'", false, true),
                new Production(rule_plus, false, "rule_plus -> ^rule_tree_action ,'+:' ^terminal_element", false, true, false),
                new Production(rule_tree_action, true, "rule_tree_action -> ^rule_drop", false),
                new Production(rule_tree_action, true, "rule_tree_action -> ^rule_promote", false),
                new Production(rule_tree_action, true, "rule_tree_action -> ^rule_primary", false),
                new Production(rule_drop, false, "rule_drop -> ,',' ^rule_primary", true, false),
                new Production(rule_promote, false, "rule_promote -> ,'^' ^rule_primary", true, false),
                new Production(rule_primary, true, "rule_primary -> ^sub_rule", false),
                new Production(rule_primary, true, "rule_primary -> ,'(' ^rule_expression ,')'", true, false, true),
                new Production(rule_primary, true, "rule_primary -> ^rule_atom", false),
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
