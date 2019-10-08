namespace Lingu.CC
{
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
                    20, 21, 5, 5, 6, 12, 9, 9, 9, 9, 9, 8, 13, 13, 22, 23, 23, 15, 15, 15, 15, 24, 24, 24, 24, 24, 24, 24,
                    15, 24, 24, 2, 14, 14, 15, 6, 12, 10, 25, 10, 26, 10, 10, 10, 27, 10, 28, 22, 23, 23, 29, 20, 20, 20,
                    20, 20, 28, 28, 28, 28, 18, 20, 28, 28, 30, 28, 28, 30, 20, 21, 16, 9, 12, 31, 31, 31, 13, 23, 15, 15,
                    15, 15, 15, 8, 24, 24, 22, 10, 12, 32, 12, 25, 25, 25, 25, 25, 32, 32, 32, 32, 18, 25, 32, 32, 33, 32,
                    32, 33, 20, 21, 34, 16, 16, 16, 16, 23, 20, 35, 20, 26, 20, 20, 20, 27, 20, 22, 28, 12, 36, 37, 37, 31,
                    31, 31, 31, 38, 38, 38, 38, 38, 38, 38, 31, 38, 38, 2, 14, 14, 15, 15, 23, 31, 24, 12, 25, 26, 25, 25,
                    25, 27, 25, 22, 32, 36, 26, 20, 23, 39, 23, 35, 35, 35, 35, 35, 39, 39, 39, 39, 18, 35, 39, 39, 40, 39,
                    39, 40, 20, 21, 34, 28, 28, 28, 28, 13, 37, 31, 31, 31, 31, 31, 8, 38, 38, 22, 23, 36, 34, 32, 32, 32,
                    32, 10, 36, 23, 35, 26, 35, 35, 35, 27, 35, 22, 39, 36, 31, 37, 31, 38, 24, 36, 34, 39, 39, 39, 39, 20,
                    37, 36, 25, 36, 38, 35,
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
                states0[7].Transitions = new DfaTrans[0] {};
                
                /* dfa  1 -- '$eof$' -- */
                var states1 = new DfaState[1] {new DfaState(0,true,30)};
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
                var states4 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,false,-1), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,true,10), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,true,15), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,false,-1), new DfaState(16,false,-1), new DfaState(17,false,-1), new DfaState(18,false,-1), new DfaState(19,false,-1), new DfaState(20,false,-1), new DfaState(21,true,24), new DfaState(22,true,9)};
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
                
                /* dfa  5 -- 'Spacing' | 'Start' | '}' -- */
                var states5 = new DfaState[13] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,false,-1), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,true,14), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,true,11), new DfaState(12,true,9)};
                states5[0].Transitions = new DfaTrans[2] {new DfaTrans(states5[1], sets[17]), new DfaTrans(states5[12], sets[9])};
                states5[1].Transitions = new DfaTrans[2] {new DfaTrans(states5[2], sets[10]), new DfaTrans(states5[8], sets[8])};
                states5[2].Transitions = new DfaTrans[1] {new DfaTrans(states5[3], sets[2])};
                states5[3].Transitions = new DfaTrans[1] {new DfaTrans(states5[4], sets[18])};
                states5[4].Transitions = new DfaTrans[1] {new DfaTrans(states5[5], sets[11])};
                states5[5].Transitions = new DfaTrans[1] {new DfaTrans(states5[6], sets[12])};
                states5[6].Transitions = new DfaTrans[1] {new DfaTrans(states5[7], sets[0])};
                states5[7].Transitions = new DfaTrans[0] {};
                states5[8].Transitions = new DfaTrans[1] {new DfaTrans(states5[9], sets[2])};
                states5[9].Transitions = new DfaTrans[1] {new DfaTrans(states5[10], sets[1])};
                states5[10].Transitions = new DfaTrans[1] {new DfaTrans(states5[11], sets[8])};
                states5[11].Transitions = new DfaTrans[0] {};
                states5[12].Transitions = new DfaTrans[0] {};
                
                /* dfa  6 -- ˈidentifierˈ | '}' -- */
                var states6 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,0), new DfaState(2,true,9)};
                states6[0].Transitions = new DfaTrans[2] {new DfaTrans(states6[1], sets[4]), new DfaTrans(states6[2], sets[9])};
                states6[1].Transitions = new DfaTrans[1] {new DfaTrans(states6[1], sets[5])};
                states6[2].Transitions = new DfaTrans[0] {};
                
                /* dfa  7 -- '=' -- */
                var states7 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,12)};
                states7[0].Transitions = new DfaTrans[1] {new DfaTrans(states7[1], sets[19])};
                states7[1].Transitions = new DfaTrans[0] {};
                
                /* dfa  8 -- '->' | ':' -- */
                var states8 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,29), new DfaState(3,true,28)};
                states8[0].Transitions = new DfaTrans[2] {new DfaTrans(states8[1], sets[20]), new DfaTrans(states8[3], sets[21])};
                states8[1].Transitions = new DfaTrans[1] {new DfaTrans(states8[2], sets[22])};
                states8[2].Transitions = new DfaTrans[0] {};
                states8[3].Transitions = new DfaTrans[0] {};
                
                /* dfa  9 -- ˈtextˈ | '(' | ',' | ';' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states9 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,20), new DfaState(15,true,13), new DfaState(16,true,0), new DfaState(17,true,21), new DfaState(18,true,8), new DfaState(19,true,16)};
                states9[0].Transitions = new DfaTrans[8] {new DfaTrans(states9[1], sets[23]), new DfaTrans(states9[13], sets[24]), new DfaTrans(states9[14], sets[25]), new DfaTrans(states9[15], sets[26]), new DfaTrans(states9[16], sets[4]), new DfaTrans(states9[17], sets[27]), new DfaTrans(states9[18], sets[6]), new DfaTrans(states9[19], sets[28])};
                states9[1].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[29]), new DfaTrans(states9[4], sets[30])};
                states9[2].Transitions = new DfaTrans[3] {new DfaTrans(states9[2], sets[29]), new DfaTrans(states9[3], sets[23]), new DfaTrans(states9[4], sets[30])};
                states9[3].Transitions = new DfaTrans[0] {};
                states9[4].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[31]), new DfaTrans(states9[5], sets[14])};
                states9[5].Transitions = new DfaTrans[1] {new DfaTrans(states9[6], sets[6])};
                states9[6].Transitions = new DfaTrans[1] {new DfaTrans(states9[7], sets[32])};
                states9[7].Transitions = new DfaTrans[2] {new DfaTrans(states9[8], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[8].Transitions = new DfaTrans[2] {new DfaTrans(states9[9], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[9].Transitions = new DfaTrans[2] {new DfaTrans(states9[10], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[10].Transitions = new DfaTrans[2] {new DfaTrans(states9[11], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[11].Transitions = new DfaTrans[2] {new DfaTrans(states9[12], sets[32]), new DfaTrans(states9[2], sets[9])};
                states9[12].Transitions = new DfaTrans[1] {new DfaTrans(states9[2], sets[9])};
                states9[13].Transitions = new DfaTrans[0] {};
                states9[14].Transitions = new DfaTrans[0] {};
                states9[15].Transitions = new DfaTrans[0] {};
                states9[16].Transitions = new DfaTrans[1] {new DfaTrans(states9[16], sets[5])};
                states9[17].Transitions = new DfaTrans[0] {};
                states9[18].Transitions = new DfaTrans[0] {};
                states9[19].Transitions = new DfaTrans[0] {};
                
                /* dfa 10 -- ˈtextˈ | '(' | '-' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states10 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,25), new DfaState(15,true,2), new DfaState(16,true,13), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,16), new DfaState(46,true,26)};
                states10[0].Transitions = new DfaTrans[10] {new DfaTrans(states10[1], sets[23]), new DfaTrans(states10[13], sets[24]), new DfaTrans(states10[14], sets[20]), new DfaTrans(states10[15], sets[33]), new DfaTrans(states10[16], sets[26]), new DfaTrans(states10[17], sets[34]), new DfaTrans(states10[18], sets[35]), new DfaTrans(states10[26], sets[30]), new DfaTrans(states10[45], sets[28]), new DfaTrans(states10[46], sets[36])};
                states10[1].Transitions = new DfaTrans[2] {new DfaTrans(states10[2], sets[29]), new DfaTrans(states10[4], sets[30])};
                states10[2].Transitions = new DfaTrans[3] {new DfaTrans(states10[2], sets[29]), new DfaTrans(states10[3], sets[23]), new DfaTrans(states10[4], sets[30])};
                states10[3].Transitions = new DfaTrans[0] {};
                states10[4].Transitions = new DfaTrans[2] {new DfaTrans(states10[2], sets[31]), new DfaTrans(states10[5], sets[14])};
                states10[5].Transitions = new DfaTrans[1] {new DfaTrans(states10[6], sets[6])};
                states10[6].Transitions = new DfaTrans[1] {new DfaTrans(states10[7], sets[32])};
                states10[7].Transitions = new DfaTrans[2] {new DfaTrans(states10[8], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[8].Transitions = new DfaTrans[2] {new DfaTrans(states10[9], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[9].Transitions = new DfaTrans[2] {new DfaTrans(states10[10], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[10].Transitions = new DfaTrans[2] {new DfaTrans(states10[11], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[11].Transitions = new DfaTrans[2] {new DfaTrans(states10[12], sets[32]), new DfaTrans(states10[2], sets[9])};
                states10[12].Transitions = new DfaTrans[1] {new DfaTrans(states10[2], sets[9])};
                states10[13].Transitions = new DfaTrans[0] {};
                states10[14].Transitions = new DfaTrans[0] {};
                states10[15].Transitions = new DfaTrans[0] {};
                states10[16].Transitions = new DfaTrans[0] {};
                states10[17].Transitions = new DfaTrans[1] {new DfaTrans(states10[17], sets[5])};
                states10[18].Transitions = new DfaTrans[2] {new DfaTrans(states10[19], sets[37]), new DfaTrans(states10[17], sets[5])};
                states10[19].Transitions = new DfaTrans[1] {new DfaTrans(states10[20], sets[32])};
                states10[20].Transitions = new DfaTrans[1] {new DfaTrans(states10[21], sets[32])};
                states10[21].Transitions = new DfaTrans[1] {new DfaTrans(states10[22], sets[32])};
                states10[22].Transitions = new DfaTrans[1] {new DfaTrans(states10[23], sets[32])};
                states10[23].Transitions = new DfaTrans[1] {new DfaTrans(states10[24], sets[32])};
                states10[24].Transitions = new DfaTrans[1] {new DfaTrans(states10[25], sets[32])};
                states10[25].Transitions = new DfaTrans[0] {};
                states10[26].Transitions = new DfaTrans[1] {new DfaTrans(states10[27], sets[14])};
                states10[27].Transitions = new DfaTrans[3] {new DfaTrans(states10[28], sets[38]), new DfaTrans(states10[33], sets[18]), new DfaTrans(states10[38], sets[6])};
                states10[28].Transitions = new DfaTrans[1] {new DfaTrans(states10[29], sets[6])};
                states10[29].Transitions = new DfaTrans[1] {new DfaTrans(states10[30], sets[39])};
                states10[30].Transitions = new DfaTrans[3] {new DfaTrans(states10[31], sets[40]), new DfaTrans(states10[30], sets[41]), new DfaTrans(states10[32], sets[9])};
                states10[31].Transitions = new DfaTrans[2] {new DfaTrans(states10[31], sets[40]), new DfaTrans(states10[30], sets[41])};
                states10[32].Transitions = new DfaTrans[0] {};
                states10[33].Transitions = new DfaTrans[1] {new DfaTrans(states10[34], sets[6])};
                states10[34].Transitions = new DfaTrans[1] {new DfaTrans(states10[35], sets[39])};
                states10[35].Transitions = new DfaTrans[3] {new DfaTrans(states10[36], sets[40]), new DfaTrans(states10[35], sets[41]), new DfaTrans(states10[37], sets[9])};
                states10[36].Transitions = new DfaTrans[2] {new DfaTrans(states10[36], sets[40]), new DfaTrans(states10[35], sets[41])};
                states10[37].Transitions = new DfaTrans[0] {};
                states10[38].Transitions = new DfaTrans[1] {new DfaTrans(states10[39], sets[32])};
                states10[39].Transitions = new DfaTrans[2] {new DfaTrans(states10[40], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[40].Transitions = new DfaTrans[2] {new DfaTrans(states10[41], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[41].Transitions = new DfaTrans[2] {new DfaTrans(states10[42], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[42].Transitions = new DfaTrans[2] {new DfaTrans(states10[43], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[43].Transitions = new DfaTrans[2] {new DfaTrans(states10[44], sets[32]), new DfaTrans(states10[25], sets[9])};
                states10[44].Transitions = new DfaTrans[1] {new DfaTrans(states10[25], sets[9])};
                states10[45].Transitions = new DfaTrans[0] {};
                states10[46].Transitions = new DfaTrans[0] {};
                
                /* dfa 11 -- ';' -- */
                var states11 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,13)};
                states11[0].Transitions = new DfaTrans[1] {new DfaTrans(states11[1], sets[26])};
                states11[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 12 -- ';' | '|' -- */
                var states12 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,13), new DfaState(2,true,16)};
                states12[0].Transitions = new DfaTrans[2] {new DfaTrans(states12[1], sets[26]), new DfaTrans(states12[2], sets[28])};
                states12[1].Transitions = new DfaTrans[0] {};
                states12[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 13 -- ˈtextˈ | '(' | '*' | '+' | ',' | ';' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states13 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,20), new DfaState(17,true,13), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,21), new DfaState(21,true,8), new DfaState(22,true,16)};
                states13[0].Transitions = new DfaTrans[11] {new DfaTrans(states13[1], sets[23]), new DfaTrans(states13[13], sets[24]), new DfaTrans(states13[14], sets[42]), new DfaTrans(states13[15], sets[37]), new DfaTrans(states13[16], sets[25]), new DfaTrans(states13[17], sets[26]), new DfaTrans(states13[18], sets[43]), new DfaTrans(states13[19], sets[4]), new DfaTrans(states13[20], sets[27]), new DfaTrans(states13[21], sets[6]), new DfaTrans(states13[22], sets[28])};
                states13[1].Transitions = new DfaTrans[2] {new DfaTrans(states13[2], sets[29]), new DfaTrans(states13[4], sets[30])};
                states13[2].Transitions = new DfaTrans[3] {new DfaTrans(states13[2], sets[29]), new DfaTrans(states13[3], sets[23]), new DfaTrans(states13[4], sets[30])};
                states13[3].Transitions = new DfaTrans[0] {};
                states13[4].Transitions = new DfaTrans[2] {new DfaTrans(states13[2], sets[31]), new DfaTrans(states13[5], sets[14])};
                states13[5].Transitions = new DfaTrans[1] {new DfaTrans(states13[6], sets[6])};
                states13[6].Transitions = new DfaTrans[1] {new DfaTrans(states13[7], sets[32])};
                states13[7].Transitions = new DfaTrans[2] {new DfaTrans(states13[8], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[8].Transitions = new DfaTrans[2] {new DfaTrans(states13[9], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[9].Transitions = new DfaTrans[2] {new DfaTrans(states13[10], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[10].Transitions = new DfaTrans[2] {new DfaTrans(states13[11], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[11].Transitions = new DfaTrans[2] {new DfaTrans(states13[12], sets[32]), new DfaTrans(states13[2], sets[9])};
                states13[12].Transitions = new DfaTrans[1] {new DfaTrans(states13[2], sets[9])};
                states13[13].Transitions = new DfaTrans[0] {};
                states13[14].Transitions = new DfaTrans[0] {};
                states13[15].Transitions = new DfaTrans[0] {};
                states13[16].Transitions = new DfaTrans[0] {};
                states13[17].Transitions = new DfaTrans[0] {};
                states13[18].Transitions = new DfaTrans[0] {};
                states13[19].Transitions = new DfaTrans[1] {new DfaTrans(states13[19], sets[5])};
                states13[20].Transitions = new DfaTrans[0] {};
                states13[21].Transitions = new DfaTrans[0] {};
                states13[22].Transitions = new DfaTrans[0] {};
                
                /* dfa 14 -- ˈtextˈ | '(' | ˈidentifierˈ | '{' -- */
                var states14 = new DfaState[16] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,0), new DfaState(15,true,8)};
                states14[0].Transitions = new DfaTrans[4] {new DfaTrans(states14[1], sets[23]), new DfaTrans(states14[13], sets[24]), new DfaTrans(states14[14], sets[4]), new DfaTrans(states14[15], sets[6])};
                states14[1].Transitions = new DfaTrans[2] {new DfaTrans(states14[2], sets[29]), new DfaTrans(states14[4], sets[30])};
                states14[2].Transitions = new DfaTrans[3] {new DfaTrans(states14[2], sets[29]), new DfaTrans(states14[3], sets[23]), new DfaTrans(states14[4], sets[30])};
                states14[3].Transitions = new DfaTrans[0] {};
                states14[4].Transitions = new DfaTrans[2] {new DfaTrans(states14[2], sets[31]), new DfaTrans(states14[5], sets[14])};
                states14[5].Transitions = new DfaTrans[1] {new DfaTrans(states14[6], sets[6])};
                states14[6].Transitions = new DfaTrans[1] {new DfaTrans(states14[7], sets[32])};
                states14[7].Transitions = new DfaTrans[2] {new DfaTrans(states14[8], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[8].Transitions = new DfaTrans[2] {new DfaTrans(states14[9], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[9].Transitions = new DfaTrans[2] {new DfaTrans(states14[10], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[10].Transitions = new DfaTrans[2] {new DfaTrans(states14[11], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[11].Transitions = new DfaTrans[2] {new DfaTrans(states14[12], sets[32]), new DfaTrans(states14[2], sets[9])};
                states14[12].Transitions = new DfaTrans[1] {new DfaTrans(states14[2], sets[9])};
                states14[13].Transitions = new DfaTrans[0] {};
                states14[14].Transitions = new DfaTrans[1] {new DfaTrans(states14[14], sets[5])};
                states14[15].Transitions = new DfaTrans[0] {};
                
                /* dfa 15 -- ˈtextˈ | '(' | ')' | ',' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states15 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,20), new DfaState(16,true,0), new DfaState(17,true,21), new DfaState(18,true,8), new DfaState(19,true,16)};
                states15[0].Transitions = new DfaTrans[8] {new DfaTrans(states15[1], sets[23]), new DfaTrans(states15[13], sets[24]), new DfaTrans(states15[14], sets[44]), new DfaTrans(states15[15], sets[25]), new DfaTrans(states15[16], sets[4]), new DfaTrans(states15[17], sets[27]), new DfaTrans(states15[18], sets[6]), new DfaTrans(states15[19], sets[28])};
                states15[1].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[29]), new DfaTrans(states15[4], sets[30])};
                states15[2].Transitions = new DfaTrans[3] {new DfaTrans(states15[2], sets[29]), new DfaTrans(states15[3], sets[23]), new DfaTrans(states15[4], sets[30])};
                states15[3].Transitions = new DfaTrans[0] {};
                states15[4].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[31]), new DfaTrans(states15[5], sets[14])};
                states15[5].Transitions = new DfaTrans[1] {new DfaTrans(states15[6], sets[6])};
                states15[6].Transitions = new DfaTrans[1] {new DfaTrans(states15[7], sets[32])};
                states15[7].Transitions = new DfaTrans[2] {new DfaTrans(states15[8], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[8].Transitions = new DfaTrans[2] {new DfaTrans(states15[9], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[9].Transitions = new DfaTrans[2] {new DfaTrans(states15[10], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[10].Transitions = new DfaTrans[2] {new DfaTrans(states15[11], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[11].Transitions = new DfaTrans[2] {new DfaTrans(states15[12], sets[32]), new DfaTrans(states15[2], sets[9])};
                states15[12].Transitions = new DfaTrans[1] {new DfaTrans(states15[2], sets[9])};
                states15[13].Transitions = new DfaTrans[0] {};
                states15[14].Transitions = new DfaTrans[0] {};
                states15[15].Transitions = new DfaTrans[0] {};
                states15[16].Transitions = new DfaTrans[1] {new DfaTrans(states15[16], sets[5])};
                states15[17].Transitions = new DfaTrans[0] {};
                states15[18].Transitions = new DfaTrans[0] {};
                states15[19].Transitions = new DfaTrans[0] {};
                
                /* dfa 16 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states16 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,25), new DfaState(17,true,2), new DfaState(18,true,13), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,26)};
                states16[0].Transitions = new DfaTrans[14] {new DfaTrans(states16[1], sets[23]), new DfaTrans(states16[13], sets[24]), new DfaTrans(states16[14], sets[42]), new DfaTrans(states16[15], sets[37]), new DfaTrans(states16[16], sets[20]), new DfaTrans(states16[17], sets[33]), new DfaTrans(states16[18], sets[26]), new DfaTrans(states16[19], sets[43]), new DfaTrans(states16[20], sets[34]), new DfaTrans(states16[21], sets[35]), new DfaTrans(states16[29], sets[30]), new DfaTrans(states16[48], sets[6]), new DfaTrans(states16[49], sets[28]), new DfaTrans(states16[50], sets[36])};
                states16[1].Transitions = new DfaTrans[2] {new DfaTrans(states16[2], sets[29]), new DfaTrans(states16[4], sets[30])};
                states16[2].Transitions = new DfaTrans[3] {new DfaTrans(states16[2], sets[29]), new DfaTrans(states16[3], sets[23]), new DfaTrans(states16[4], sets[30])};
                states16[3].Transitions = new DfaTrans[0] {};
                states16[4].Transitions = new DfaTrans[2] {new DfaTrans(states16[2], sets[31]), new DfaTrans(states16[5], sets[14])};
                states16[5].Transitions = new DfaTrans[1] {new DfaTrans(states16[6], sets[6])};
                states16[6].Transitions = new DfaTrans[1] {new DfaTrans(states16[7], sets[32])};
                states16[7].Transitions = new DfaTrans[2] {new DfaTrans(states16[8], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[8].Transitions = new DfaTrans[2] {new DfaTrans(states16[9], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[9].Transitions = new DfaTrans[2] {new DfaTrans(states16[10], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[10].Transitions = new DfaTrans[2] {new DfaTrans(states16[11], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[11].Transitions = new DfaTrans[2] {new DfaTrans(states16[12], sets[32]), new DfaTrans(states16[2], sets[9])};
                states16[12].Transitions = new DfaTrans[1] {new DfaTrans(states16[2], sets[9])};
                states16[13].Transitions = new DfaTrans[0] {};
                states16[14].Transitions = new DfaTrans[0] {};
                states16[15].Transitions = new DfaTrans[0] {};
                states16[16].Transitions = new DfaTrans[0] {};
                states16[17].Transitions = new DfaTrans[0] {};
                states16[18].Transitions = new DfaTrans[0] {};
                states16[19].Transitions = new DfaTrans[0] {};
                states16[20].Transitions = new DfaTrans[1] {new DfaTrans(states16[20], sets[5])};
                states16[21].Transitions = new DfaTrans[2] {new DfaTrans(states16[22], sets[37]), new DfaTrans(states16[20], sets[5])};
                states16[22].Transitions = new DfaTrans[1] {new DfaTrans(states16[23], sets[32])};
                states16[23].Transitions = new DfaTrans[1] {new DfaTrans(states16[24], sets[32])};
                states16[24].Transitions = new DfaTrans[1] {new DfaTrans(states16[25], sets[32])};
                states16[25].Transitions = new DfaTrans[1] {new DfaTrans(states16[26], sets[32])};
                states16[26].Transitions = new DfaTrans[1] {new DfaTrans(states16[27], sets[32])};
                states16[27].Transitions = new DfaTrans[1] {new DfaTrans(states16[28], sets[32])};
                states16[28].Transitions = new DfaTrans[0] {};
                states16[29].Transitions = new DfaTrans[1] {new DfaTrans(states16[30], sets[14])};
                states16[30].Transitions = new DfaTrans[3] {new DfaTrans(states16[31], sets[38]), new DfaTrans(states16[36], sets[18]), new DfaTrans(states16[41], sets[6])};
                states16[31].Transitions = new DfaTrans[1] {new DfaTrans(states16[32], sets[6])};
                states16[32].Transitions = new DfaTrans[1] {new DfaTrans(states16[33], sets[39])};
                states16[33].Transitions = new DfaTrans[3] {new DfaTrans(states16[34], sets[40]), new DfaTrans(states16[33], sets[41]), new DfaTrans(states16[35], sets[9])};
                states16[34].Transitions = new DfaTrans[2] {new DfaTrans(states16[34], sets[40]), new DfaTrans(states16[33], sets[41])};
                states16[35].Transitions = new DfaTrans[0] {};
                states16[36].Transitions = new DfaTrans[1] {new DfaTrans(states16[37], sets[6])};
                states16[37].Transitions = new DfaTrans[1] {new DfaTrans(states16[38], sets[39])};
                states16[38].Transitions = new DfaTrans[3] {new DfaTrans(states16[39], sets[40]), new DfaTrans(states16[38], sets[41]), new DfaTrans(states16[40], sets[9])};
                states16[39].Transitions = new DfaTrans[2] {new DfaTrans(states16[39], sets[40]), new DfaTrans(states16[38], sets[41])};
                states16[40].Transitions = new DfaTrans[0] {};
                states16[41].Transitions = new DfaTrans[1] {new DfaTrans(states16[42], sets[32])};
                states16[42].Transitions = new DfaTrans[2] {new DfaTrans(states16[43], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[43].Transitions = new DfaTrans[2] {new DfaTrans(states16[44], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[44].Transitions = new DfaTrans[2] {new DfaTrans(states16[45], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[45].Transitions = new DfaTrans[2] {new DfaTrans(states16[46], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[46].Transitions = new DfaTrans[2] {new DfaTrans(states16[47], sets[32]), new DfaTrans(states16[28], sets[9])};
                states16[47].Transitions = new DfaTrans[1] {new DfaTrans(states16[28], sets[9])};
                states16[48].Transitions = new DfaTrans[0] {};
                states16[49].Transitions = new DfaTrans[0] {};
                states16[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 17 -- '-' | ';' | '|' -- */
                var states17 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,25), new DfaState(2,true,13), new DfaState(3,true,16)};
                states17[0].Transitions = new DfaTrans[3] {new DfaTrans(states17[1], sets[20]), new DfaTrans(states17[2], sets[26]), new DfaTrans(states17[3], sets[28])};
                states17[1].Transitions = new DfaTrans[0] {};
                states17[2].Transitions = new DfaTrans[0] {};
                states17[3].Transitions = new DfaTrans[0] {};
                
                /* dfa 18 -- '..' -- */
                var states18 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,27)};
                states18[0].Transitions = new DfaTrans[1] {new DfaTrans(states18[1], sets[33])};
                states18[1].Transitions = new DfaTrans[1] {new DfaTrans(states18[2], sets[33])};
                states18[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 19 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states19 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,25), new DfaState(17,true,2), new DfaState(18,true,27), new DfaState(19,true,13), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,16), new DfaState(51,true,26)};
                states19[0].Transitions = new DfaTrans[14] {new DfaTrans(states19[1], sets[23]), new DfaTrans(states19[13], sets[24]), new DfaTrans(states19[14], sets[42]), new DfaTrans(states19[15], sets[37]), new DfaTrans(states19[16], sets[20]), new DfaTrans(states19[17], sets[33]), new DfaTrans(states19[19], sets[26]), new DfaTrans(states19[20], sets[43]), new DfaTrans(states19[21], sets[34]), new DfaTrans(states19[22], sets[35]), new DfaTrans(states19[30], sets[30]), new DfaTrans(states19[49], sets[6]), new DfaTrans(states19[50], sets[28]), new DfaTrans(states19[51], sets[36])};
                states19[1].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[29]), new DfaTrans(states19[4], sets[30])};
                states19[2].Transitions = new DfaTrans[3] {new DfaTrans(states19[2], sets[29]), new DfaTrans(states19[3], sets[23]), new DfaTrans(states19[4], sets[30])};
                states19[3].Transitions = new DfaTrans[0] {};
                states19[4].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[31]), new DfaTrans(states19[5], sets[14])};
                states19[5].Transitions = new DfaTrans[1] {new DfaTrans(states19[6], sets[6])};
                states19[6].Transitions = new DfaTrans[1] {new DfaTrans(states19[7], sets[32])};
                states19[7].Transitions = new DfaTrans[2] {new DfaTrans(states19[8], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[8].Transitions = new DfaTrans[2] {new DfaTrans(states19[9], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[9].Transitions = new DfaTrans[2] {new DfaTrans(states19[10], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[10].Transitions = new DfaTrans[2] {new DfaTrans(states19[11], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[11].Transitions = new DfaTrans[2] {new DfaTrans(states19[12], sets[32]), new DfaTrans(states19[2], sets[9])};
                states19[12].Transitions = new DfaTrans[1] {new DfaTrans(states19[2], sets[9])};
                states19[13].Transitions = new DfaTrans[0] {};
                states19[14].Transitions = new DfaTrans[0] {};
                states19[15].Transitions = new DfaTrans[0] {};
                states19[16].Transitions = new DfaTrans[0] {};
                states19[17].Transitions = new DfaTrans[1] {new DfaTrans(states19[18], sets[33])};
                states19[18].Transitions = new DfaTrans[0] {};
                states19[19].Transitions = new DfaTrans[0] {};
                states19[20].Transitions = new DfaTrans[0] {};
                states19[21].Transitions = new DfaTrans[1] {new DfaTrans(states19[21], sets[5])};
                states19[22].Transitions = new DfaTrans[2] {new DfaTrans(states19[23], sets[37]), new DfaTrans(states19[21], sets[5])};
                states19[23].Transitions = new DfaTrans[1] {new DfaTrans(states19[24], sets[32])};
                states19[24].Transitions = new DfaTrans[1] {new DfaTrans(states19[25], sets[32])};
                states19[25].Transitions = new DfaTrans[1] {new DfaTrans(states19[26], sets[32])};
                states19[26].Transitions = new DfaTrans[1] {new DfaTrans(states19[27], sets[32])};
                states19[27].Transitions = new DfaTrans[1] {new DfaTrans(states19[28], sets[32])};
                states19[28].Transitions = new DfaTrans[1] {new DfaTrans(states19[29], sets[32])};
                states19[29].Transitions = new DfaTrans[0] {};
                states19[30].Transitions = new DfaTrans[1] {new DfaTrans(states19[31], sets[14])};
                states19[31].Transitions = new DfaTrans[3] {new DfaTrans(states19[32], sets[38]), new DfaTrans(states19[37], sets[18]), new DfaTrans(states19[42], sets[6])};
                states19[32].Transitions = new DfaTrans[1] {new DfaTrans(states19[33], sets[6])};
                states19[33].Transitions = new DfaTrans[1] {new DfaTrans(states19[34], sets[39])};
                states19[34].Transitions = new DfaTrans[3] {new DfaTrans(states19[35], sets[40]), new DfaTrans(states19[34], sets[41]), new DfaTrans(states19[36], sets[9])};
                states19[35].Transitions = new DfaTrans[2] {new DfaTrans(states19[35], sets[40]), new DfaTrans(states19[34], sets[41])};
                states19[36].Transitions = new DfaTrans[0] {};
                states19[37].Transitions = new DfaTrans[1] {new DfaTrans(states19[38], sets[6])};
                states19[38].Transitions = new DfaTrans[1] {new DfaTrans(states19[39], sets[39])};
                states19[39].Transitions = new DfaTrans[3] {new DfaTrans(states19[40], sets[40]), new DfaTrans(states19[39], sets[41]), new DfaTrans(states19[41], sets[9])};
                states19[40].Transitions = new DfaTrans[2] {new DfaTrans(states19[40], sets[40]), new DfaTrans(states19[39], sets[41])};
                states19[41].Transitions = new DfaTrans[0] {};
                states19[42].Transitions = new DfaTrans[1] {new DfaTrans(states19[43], sets[32])};
                states19[43].Transitions = new DfaTrans[2] {new DfaTrans(states19[44], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[44].Transitions = new DfaTrans[2] {new DfaTrans(states19[45], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[45].Transitions = new DfaTrans[2] {new DfaTrans(states19[46], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[46].Transitions = new DfaTrans[2] {new DfaTrans(states19[47], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[47].Transitions = new DfaTrans[2] {new DfaTrans(states19[48], sets[32]), new DfaTrans(states19[29], sets[9])};
                states19[48].Transitions = new DfaTrans[1] {new DfaTrans(states19[29], sets[9])};
                states19[49].Transitions = new DfaTrans[0] {};
                states19[50].Transitions = new DfaTrans[0] {};
                states19[51].Transitions = new DfaTrans[0] {};
                
                /* dfa 20 -- ˈtextˈ | '(' | ')' | '-' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states20 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,25), new DfaState(16,true,2), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,16), new DfaState(46,true,26)};
                states20[0].Transitions = new DfaTrans[10] {new DfaTrans(states20[1], sets[23]), new DfaTrans(states20[13], sets[24]), new DfaTrans(states20[14], sets[44]), new DfaTrans(states20[15], sets[20]), new DfaTrans(states20[16], sets[33]), new DfaTrans(states20[17], sets[34]), new DfaTrans(states20[18], sets[35]), new DfaTrans(states20[26], sets[30]), new DfaTrans(states20[45], sets[28]), new DfaTrans(states20[46], sets[36])};
                states20[1].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[29]), new DfaTrans(states20[4], sets[30])};
                states20[2].Transitions = new DfaTrans[3] {new DfaTrans(states20[2], sets[29]), new DfaTrans(states20[3], sets[23]), new DfaTrans(states20[4], sets[30])};
                states20[3].Transitions = new DfaTrans[0] {};
                states20[4].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[31]), new DfaTrans(states20[5], sets[14])};
                states20[5].Transitions = new DfaTrans[1] {new DfaTrans(states20[6], sets[6])};
                states20[6].Transitions = new DfaTrans[1] {new DfaTrans(states20[7], sets[32])};
                states20[7].Transitions = new DfaTrans[2] {new DfaTrans(states20[8], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[8].Transitions = new DfaTrans[2] {new DfaTrans(states20[9], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[9].Transitions = new DfaTrans[2] {new DfaTrans(states20[10], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[10].Transitions = new DfaTrans[2] {new DfaTrans(states20[11], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[11].Transitions = new DfaTrans[2] {new DfaTrans(states20[12], sets[32]), new DfaTrans(states20[2], sets[9])};
                states20[12].Transitions = new DfaTrans[1] {new DfaTrans(states20[2], sets[9])};
                states20[13].Transitions = new DfaTrans[0] {};
                states20[14].Transitions = new DfaTrans[0] {};
                states20[15].Transitions = new DfaTrans[0] {};
                states20[16].Transitions = new DfaTrans[0] {};
                states20[17].Transitions = new DfaTrans[1] {new DfaTrans(states20[17], sets[5])};
                states20[18].Transitions = new DfaTrans[2] {new DfaTrans(states20[19], sets[37]), new DfaTrans(states20[17], sets[5])};
                states20[19].Transitions = new DfaTrans[1] {new DfaTrans(states20[20], sets[32])};
                states20[20].Transitions = new DfaTrans[1] {new DfaTrans(states20[21], sets[32])};
                states20[21].Transitions = new DfaTrans[1] {new DfaTrans(states20[22], sets[32])};
                states20[22].Transitions = new DfaTrans[1] {new DfaTrans(states20[23], sets[32])};
                states20[23].Transitions = new DfaTrans[1] {new DfaTrans(states20[24], sets[32])};
                states20[24].Transitions = new DfaTrans[1] {new DfaTrans(states20[25], sets[32])};
                states20[25].Transitions = new DfaTrans[0] {};
                states20[26].Transitions = new DfaTrans[1] {new DfaTrans(states20[27], sets[14])};
                states20[27].Transitions = new DfaTrans[3] {new DfaTrans(states20[28], sets[38]), new DfaTrans(states20[33], sets[18]), new DfaTrans(states20[38], sets[6])};
                states20[28].Transitions = new DfaTrans[1] {new DfaTrans(states20[29], sets[6])};
                states20[29].Transitions = new DfaTrans[1] {new DfaTrans(states20[30], sets[39])};
                states20[30].Transitions = new DfaTrans[3] {new DfaTrans(states20[31], sets[40]), new DfaTrans(states20[30], sets[41]), new DfaTrans(states20[32], sets[9])};
                states20[31].Transitions = new DfaTrans[2] {new DfaTrans(states20[31], sets[40]), new DfaTrans(states20[30], sets[41])};
                states20[32].Transitions = new DfaTrans[0] {};
                states20[33].Transitions = new DfaTrans[1] {new DfaTrans(states20[34], sets[6])};
                states20[34].Transitions = new DfaTrans[1] {new DfaTrans(states20[35], sets[39])};
                states20[35].Transitions = new DfaTrans[3] {new DfaTrans(states20[36], sets[40]), new DfaTrans(states20[35], sets[41]), new DfaTrans(states20[37], sets[9])};
                states20[36].Transitions = new DfaTrans[2] {new DfaTrans(states20[36], sets[40]), new DfaTrans(states20[35], sets[41])};
                states20[37].Transitions = new DfaTrans[0] {};
                states20[38].Transitions = new DfaTrans[1] {new DfaTrans(states20[39], sets[32])};
                states20[39].Transitions = new DfaTrans[2] {new DfaTrans(states20[40], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[40].Transitions = new DfaTrans[2] {new DfaTrans(states20[41], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[41].Transitions = new DfaTrans[2] {new DfaTrans(states20[42], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[42].Transitions = new DfaTrans[2] {new DfaTrans(states20[43], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[43].Transitions = new DfaTrans[2] {new DfaTrans(states20[44], sets[32]), new DfaTrans(states20[25], sets[9])};
                states20[44].Transitions = new DfaTrans[1] {new DfaTrans(states20[25], sets[9])};
                states20[45].Transitions = new DfaTrans[0] {};
                states20[46].Transitions = new DfaTrans[0] {};
                
                /* dfa 21 -- ˈtextˈ | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ -- */
                var states21 = new DfaState[42] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,2), new DfaState(14,true,0), new DfaState(15,true,0), new DfaState(16,false,-1), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,true,4), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,5), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1)};
                states21[0].Transitions = new DfaTrans[5] {new DfaTrans(states21[1], sets[23]), new DfaTrans(states21[13], sets[33]), new DfaTrans(states21[14], sets[34]), new DfaTrans(states21[15], sets[35]), new DfaTrans(states21[23], sets[30])};
                states21[1].Transitions = new DfaTrans[2] {new DfaTrans(states21[2], sets[29]), new DfaTrans(states21[4], sets[30])};
                states21[2].Transitions = new DfaTrans[3] {new DfaTrans(states21[2], sets[29]), new DfaTrans(states21[3], sets[23]), new DfaTrans(states21[4], sets[30])};
                states21[3].Transitions = new DfaTrans[0] {};
                states21[4].Transitions = new DfaTrans[2] {new DfaTrans(states21[2], sets[31]), new DfaTrans(states21[5], sets[14])};
                states21[5].Transitions = new DfaTrans[1] {new DfaTrans(states21[6], sets[6])};
                states21[6].Transitions = new DfaTrans[1] {new DfaTrans(states21[7], sets[32])};
                states21[7].Transitions = new DfaTrans[2] {new DfaTrans(states21[8], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[8].Transitions = new DfaTrans[2] {new DfaTrans(states21[9], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[9].Transitions = new DfaTrans[2] {new DfaTrans(states21[10], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[10].Transitions = new DfaTrans[2] {new DfaTrans(states21[11], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[11].Transitions = new DfaTrans[2] {new DfaTrans(states21[12], sets[32]), new DfaTrans(states21[2], sets[9])};
                states21[12].Transitions = new DfaTrans[1] {new DfaTrans(states21[2], sets[9])};
                states21[13].Transitions = new DfaTrans[0] {};
                states21[14].Transitions = new DfaTrans[1] {new DfaTrans(states21[14], sets[5])};
                states21[15].Transitions = new DfaTrans[2] {new DfaTrans(states21[16], sets[37]), new DfaTrans(states21[14], sets[5])};
                states21[16].Transitions = new DfaTrans[1] {new DfaTrans(states21[17], sets[32])};
                states21[17].Transitions = new DfaTrans[1] {new DfaTrans(states21[18], sets[32])};
                states21[18].Transitions = new DfaTrans[1] {new DfaTrans(states21[19], sets[32])};
                states21[19].Transitions = new DfaTrans[1] {new DfaTrans(states21[20], sets[32])};
                states21[20].Transitions = new DfaTrans[1] {new DfaTrans(states21[21], sets[32])};
                states21[21].Transitions = new DfaTrans[1] {new DfaTrans(states21[22], sets[32])};
                states21[22].Transitions = new DfaTrans[0] {};
                states21[23].Transitions = new DfaTrans[1] {new DfaTrans(states21[24], sets[14])};
                states21[24].Transitions = new DfaTrans[3] {new DfaTrans(states21[25], sets[38]), new DfaTrans(states21[30], sets[18]), new DfaTrans(states21[35], sets[6])};
                states21[25].Transitions = new DfaTrans[1] {new DfaTrans(states21[26], sets[6])};
                states21[26].Transitions = new DfaTrans[1] {new DfaTrans(states21[27], sets[39])};
                states21[27].Transitions = new DfaTrans[3] {new DfaTrans(states21[28], sets[40]), new DfaTrans(states21[27], sets[41]), new DfaTrans(states21[29], sets[9])};
                states21[28].Transitions = new DfaTrans[2] {new DfaTrans(states21[28], sets[40]), new DfaTrans(states21[27], sets[41])};
                states21[29].Transitions = new DfaTrans[0] {};
                states21[30].Transitions = new DfaTrans[1] {new DfaTrans(states21[31], sets[6])};
                states21[31].Transitions = new DfaTrans[1] {new DfaTrans(states21[32], sets[39])};
                states21[32].Transitions = new DfaTrans[3] {new DfaTrans(states21[33], sets[40]), new DfaTrans(states21[32], sets[41]), new DfaTrans(states21[34], sets[9])};
                states21[33].Transitions = new DfaTrans[2] {new DfaTrans(states21[33], sets[40]), new DfaTrans(states21[32], sets[41])};
                states21[34].Transitions = new DfaTrans[0] {};
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
                states22[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 23 -- ')' | '|' -- */
                var states23 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,23), new DfaState(2,true,16)};
                states23[0].Transitions = new DfaTrans[2] {new DfaTrans(states23[1], sets[44]), new DfaTrans(states23[2], sets[28])};
                states23[1].Transitions = new DfaTrans[0] {};
                states23[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 24 -- ˈtextˈ | '(' | ')' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' -- */
                var states24 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,20), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,21), new DfaState(21,true,8), new DfaState(22,true,16)};
                states24[0].Transitions = new DfaTrans[11] {new DfaTrans(states24[1], sets[23]), new DfaTrans(states24[13], sets[24]), new DfaTrans(states24[14], sets[44]), new DfaTrans(states24[15], sets[42]), new DfaTrans(states24[16], sets[37]), new DfaTrans(states24[17], sets[25]), new DfaTrans(states24[18], sets[43]), new DfaTrans(states24[19], sets[4]), new DfaTrans(states24[20], sets[27]), new DfaTrans(states24[21], sets[6]), new DfaTrans(states24[22], sets[28])};
                states24[1].Transitions = new DfaTrans[2] {new DfaTrans(states24[2], sets[29]), new DfaTrans(states24[4], sets[30])};
                states24[2].Transitions = new DfaTrans[3] {new DfaTrans(states24[2], sets[29]), new DfaTrans(states24[3], sets[23]), new DfaTrans(states24[4], sets[30])};
                states24[3].Transitions = new DfaTrans[0] {};
                states24[4].Transitions = new DfaTrans[2] {new DfaTrans(states24[2], sets[31]), new DfaTrans(states24[5], sets[14])};
                states24[5].Transitions = new DfaTrans[1] {new DfaTrans(states24[6], sets[6])};
                states24[6].Transitions = new DfaTrans[1] {new DfaTrans(states24[7], sets[32])};
                states24[7].Transitions = new DfaTrans[2] {new DfaTrans(states24[8], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[8].Transitions = new DfaTrans[2] {new DfaTrans(states24[9], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[9].Transitions = new DfaTrans[2] {new DfaTrans(states24[10], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[10].Transitions = new DfaTrans[2] {new DfaTrans(states24[11], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[11].Transitions = new DfaTrans[2] {new DfaTrans(states24[12], sets[32]), new DfaTrans(states24[2], sets[9])};
                states24[12].Transitions = new DfaTrans[1] {new DfaTrans(states24[2], sets[9])};
                states24[13].Transitions = new DfaTrans[0] {};
                states24[14].Transitions = new DfaTrans[0] {};
                states24[15].Transitions = new DfaTrans[0] {};
                states24[16].Transitions = new DfaTrans[0] {};
                states24[17].Transitions = new DfaTrans[0] {};
                states24[18].Transitions = new DfaTrans[0] {};
                states24[19].Transitions = new DfaTrans[1] {new DfaTrans(states24[19], sets[5])};
                states24[20].Transitions = new DfaTrans[0] {};
                states24[21].Transitions = new DfaTrans[0] {};
                states24[22].Transitions = new DfaTrans[0] {};
                
                /* dfa 25 -- ˈtextˈ | '(' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states25 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,2), new DfaState(15,true,13), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,16), new DfaState(45,true,26)};
                states25[0].Transitions = new DfaTrans[9] {new DfaTrans(states25[1], sets[23]), new DfaTrans(states25[13], sets[24]), new DfaTrans(states25[14], sets[33]), new DfaTrans(states25[15], sets[26]), new DfaTrans(states25[16], sets[34]), new DfaTrans(states25[17], sets[35]), new DfaTrans(states25[25], sets[30]), new DfaTrans(states25[44], sets[28]), new DfaTrans(states25[45], sets[36])};
                states25[1].Transitions = new DfaTrans[2] {new DfaTrans(states25[2], sets[29]), new DfaTrans(states25[4], sets[30])};
                states25[2].Transitions = new DfaTrans[3] {new DfaTrans(states25[2], sets[29]), new DfaTrans(states25[3], sets[23]), new DfaTrans(states25[4], sets[30])};
                states25[3].Transitions = new DfaTrans[0] {};
                states25[4].Transitions = new DfaTrans[2] {new DfaTrans(states25[2], sets[31]), new DfaTrans(states25[5], sets[14])};
                states25[5].Transitions = new DfaTrans[1] {new DfaTrans(states25[6], sets[6])};
                states25[6].Transitions = new DfaTrans[1] {new DfaTrans(states25[7], sets[32])};
                states25[7].Transitions = new DfaTrans[2] {new DfaTrans(states25[8], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[8].Transitions = new DfaTrans[2] {new DfaTrans(states25[9], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[9].Transitions = new DfaTrans[2] {new DfaTrans(states25[10], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[10].Transitions = new DfaTrans[2] {new DfaTrans(states25[11], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[11].Transitions = new DfaTrans[2] {new DfaTrans(states25[12], sets[32]), new DfaTrans(states25[2], sets[9])};
                states25[12].Transitions = new DfaTrans[1] {new DfaTrans(states25[2], sets[9])};
                states25[13].Transitions = new DfaTrans[0] {};
                states25[14].Transitions = new DfaTrans[0] {};
                states25[15].Transitions = new DfaTrans[0] {};
                states25[16].Transitions = new DfaTrans[1] {new DfaTrans(states25[16], sets[5])};
                states25[17].Transitions = new DfaTrans[2] {new DfaTrans(states25[18], sets[37]), new DfaTrans(states25[16], sets[5])};
                states25[18].Transitions = new DfaTrans[1] {new DfaTrans(states25[19], sets[32])};
                states25[19].Transitions = new DfaTrans[1] {new DfaTrans(states25[20], sets[32])};
                states25[20].Transitions = new DfaTrans[1] {new DfaTrans(states25[21], sets[32])};
                states25[21].Transitions = new DfaTrans[1] {new DfaTrans(states25[22], sets[32])};
                states25[22].Transitions = new DfaTrans[1] {new DfaTrans(states25[23], sets[32])};
                states25[23].Transitions = new DfaTrans[1] {new DfaTrans(states25[24], sets[32])};
                states25[24].Transitions = new DfaTrans[0] {};
                states25[25].Transitions = new DfaTrans[1] {new DfaTrans(states25[26], sets[14])};
                states25[26].Transitions = new DfaTrans[3] {new DfaTrans(states25[27], sets[38]), new DfaTrans(states25[32], sets[18]), new DfaTrans(states25[37], sets[6])};
                states25[27].Transitions = new DfaTrans[1] {new DfaTrans(states25[28], sets[6])};
                states25[28].Transitions = new DfaTrans[1] {new DfaTrans(states25[29], sets[39])};
                states25[29].Transitions = new DfaTrans[3] {new DfaTrans(states25[30], sets[40]), new DfaTrans(states25[29], sets[41]), new DfaTrans(states25[31], sets[9])};
                states25[30].Transitions = new DfaTrans[2] {new DfaTrans(states25[30], sets[40]), new DfaTrans(states25[29], sets[41])};
                states25[31].Transitions = new DfaTrans[0] {};
                states25[32].Transitions = new DfaTrans[1] {new DfaTrans(states25[33], sets[6])};
                states25[33].Transitions = new DfaTrans[1] {new DfaTrans(states25[34], sets[39])};
                states25[34].Transitions = new DfaTrans[3] {new DfaTrans(states25[35], sets[40]), new DfaTrans(states25[34], sets[41]), new DfaTrans(states25[36], sets[9])};
                states25[35].Transitions = new DfaTrans[2] {new DfaTrans(states25[35], sets[40]), new DfaTrans(states25[34], sets[41])};
                states25[36].Transitions = new DfaTrans[0] {};
                states25[37].Transitions = new DfaTrans[1] {new DfaTrans(states25[38], sets[32])};
                states25[38].Transitions = new DfaTrans[2] {new DfaTrans(states25[39], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[39].Transitions = new DfaTrans[2] {new DfaTrans(states25[40], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[40].Transitions = new DfaTrans[2] {new DfaTrans(states25[41], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[41].Transitions = new DfaTrans[2] {new DfaTrans(states25[42], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[42].Transitions = new DfaTrans[2] {new DfaTrans(states25[43], sets[32]), new DfaTrans(states25[24], sets[9])};
                states25[43].Transitions = new DfaTrans[1] {new DfaTrans(states25[24], sets[9])};
                states25[44].Transitions = new DfaTrans[0] {};
                states25[45].Transitions = new DfaTrans[0] {};
                
                /* dfa 26 -- ˈnumberˈ -- */
                var states26 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,1), new DfaState(2,true,1)};
                states26[0].Transitions = new DfaTrans[2] {new DfaTrans(states26[1], sets[45]), new DfaTrans(states26[2], sets[46])};
                states26[1].Transitions = new DfaTrans[0] {};
                states26[2].Transitions = new DfaTrans[1] {new DfaTrans(states26[2], sets[47])};
                
                /* dfa 27 -- ˈtextˈ | ˈucCodepointˈ -- */
                var states27 = new DfaState[30] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,true,6), new DfaState(16,true,6), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,false,-1), new DfaState(22,false,-1), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1)};
                states27[0].Transitions = new DfaTrans[3] {new DfaTrans(states27[1], sets[23]), new DfaTrans(states27[13], sets[35]), new DfaTrans(states27[21], sets[30])};
                states27[1].Transitions = new DfaTrans[2] {new DfaTrans(states27[2], sets[29]), new DfaTrans(states27[4], sets[30])};
                states27[2].Transitions = new DfaTrans[3] {new DfaTrans(states27[2], sets[29]), new DfaTrans(states27[3], sets[23]), new DfaTrans(states27[4], sets[30])};
                states27[3].Transitions = new DfaTrans[0] {};
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
                states27[20].Transitions = new DfaTrans[0] {};
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
                states28[3].Transitions = new DfaTrans[0] {};
                states28[4].Transitions = new DfaTrans[2] {new DfaTrans(states28[2], sets[31]), new DfaTrans(states28[5], sets[14])};
                states28[5].Transitions = new DfaTrans[1] {new DfaTrans(states28[6], sets[6])};
                states28[6].Transitions = new DfaTrans[1] {new DfaTrans(states28[7], sets[32])};
                states28[7].Transitions = new DfaTrans[2] {new DfaTrans(states28[8], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[8].Transitions = new DfaTrans[2] {new DfaTrans(states28[9], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[9].Transitions = new DfaTrans[2] {new DfaTrans(states28[10], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[10].Transitions = new DfaTrans[2] {new DfaTrans(states28[11], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[11].Transitions = new DfaTrans[2] {new DfaTrans(states28[12], sets[32]), new DfaTrans(states28[2], sets[9])};
                states28[12].Transitions = new DfaTrans[1] {new DfaTrans(states28[2], sets[9])};
                states28[13].Transitions = new DfaTrans[0] {};
                states28[14].Transitions = new DfaTrans[0] {};
                states28[15].Transitions = new DfaTrans[0] {};
                states28[16].Transitions = new DfaTrans[0] {};
                states28[17].Transitions = new DfaTrans[0] {};
                states28[18].Transitions = new DfaTrans[0] {};
                states28[19].Transitions = new DfaTrans[0] {};
                states28[20].Transitions = new DfaTrans[1] {new DfaTrans(states28[20], sets[5])};
                states28[21].Transitions = new DfaTrans[2] {new DfaTrans(states28[22], sets[37]), new DfaTrans(states28[20], sets[5])};
                states28[22].Transitions = new DfaTrans[1] {new DfaTrans(states28[23], sets[32])};
                states28[23].Transitions = new DfaTrans[1] {new DfaTrans(states28[24], sets[32])};
                states28[24].Transitions = new DfaTrans[1] {new DfaTrans(states28[25], sets[32])};
                states28[25].Transitions = new DfaTrans[1] {new DfaTrans(states28[26], sets[32])};
                states28[26].Transitions = new DfaTrans[1] {new DfaTrans(states28[27], sets[32])};
                states28[27].Transitions = new DfaTrans[1] {new DfaTrans(states28[28], sets[32])};
                states28[28].Transitions = new DfaTrans[0] {};
                states28[29].Transitions = new DfaTrans[1] {new DfaTrans(states28[30], sets[14])};
                states28[30].Transitions = new DfaTrans[3] {new DfaTrans(states28[31], sets[38]), new DfaTrans(states28[36], sets[18]), new DfaTrans(states28[41], sets[6])};
                states28[31].Transitions = new DfaTrans[1] {new DfaTrans(states28[32], sets[6])};
                states28[32].Transitions = new DfaTrans[1] {new DfaTrans(states28[33], sets[39])};
                states28[33].Transitions = new DfaTrans[3] {new DfaTrans(states28[34], sets[40]), new DfaTrans(states28[33], sets[41]), new DfaTrans(states28[35], sets[9])};
                states28[34].Transitions = new DfaTrans[2] {new DfaTrans(states28[34], sets[40]), new DfaTrans(states28[33], sets[41])};
                states28[35].Transitions = new DfaTrans[0] {};
                states28[36].Transitions = new DfaTrans[1] {new DfaTrans(states28[37], sets[6])};
                states28[37].Transitions = new DfaTrans[1] {new DfaTrans(states28[38], sets[39])};
                states28[38].Transitions = new DfaTrans[3] {new DfaTrans(states28[39], sets[40]), new DfaTrans(states28[38], sets[41]), new DfaTrans(states28[40], sets[9])};
                states28[39].Transitions = new DfaTrans[2] {new DfaTrans(states28[39], sets[40]), new DfaTrans(states28[38], sets[41])};
                states28[40].Transitions = new DfaTrans[0] {};
                states28[41].Transitions = new DfaTrans[1] {new DfaTrans(states28[42], sets[32])};
                states28[42].Transitions = new DfaTrans[2] {new DfaTrans(states28[43], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[43].Transitions = new DfaTrans[2] {new DfaTrans(states28[44], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[44].Transitions = new DfaTrans[2] {new DfaTrans(states28[45], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[45].Transitions = new DfaTrans[2] {new DfaTrans(states28[46], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[46].Transitions = new DfaTrans[2] {new DfaTrans(states28[47], sets[32]), new DfaTrans(states28[28], sets[9])};
                states28[47].Transitions = new DfaTrans[1] {new DfaTrans(states28[28], sets[9])};
                states28[48].Transitions = new DfaTrans[0] {};
                states28[49].Transitions = new DfaTrans[0] {};
                states28[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 29 -- ')' | '-' | '|' -- */
                var states29 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,23), new DfaState(2,true,25), new DfaState(3,true,16)};
                states29[0].Transitions = new DfaTrans[3] {new DfaTrans(states29[1], sets[44]), new DfaTrans(states29[2], sets[20]), new DfaTrans(states29[3], sets[28])};
                states29[1].Transitions = new DfaTrans[0] {};
                states29[2].Transitions = new DfaTrans[0] {};
                states29[3].Transitions = new DfaTrans[0] {};
                
                /* dfa 30 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states30 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,25), new DfaState(18,true,2), new DfaState(19,true,27), new DfaState(20,true,17), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,16), new DfaState(51,true,26)};
                states30[0].Transitions = new DfaTrans[14] {new DfaTrans(states30[1], sets[23]), new DfaTrans(states30[13], sets[24]), new DfaTrans(states30[14], sets[44]), new DfaTrans(states30[15], sets[42]), new DfaTrans(states30[16], sets[37]), new DfaTrans(states30[17], sets[20]), new DfaTrans(states30[18], sets[33]), new DfaTrans(states30[20], sets[43]), new DfaTrans(states30[21], sets[34]), new DfaTrans(states30[22], sets[35]), new DfaTrans(states30[30], sets[30]), new DfaTrans(states30[49], sets[6]), new DfaTrans(states30[50], sets[28]), new DfaTrans(states30[51], sets[36])};
                states30[1].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[29]), new DfaTrans(states30[4], sets[30])};
                states30[2].Transitions = new DfaTrans[3] {new DfaTrans(states30[2], sets[29]), new DfaTrans(states30[3], sets[23]), new DfaTrans(states30[4], sets[30])};
                states30[3].Transitions = new DfaTrans[0] {};
                states30[4].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[31]), new DfaTrans(states30[5], sets[14])};
                states30[5].Transitions = new DfaTrans[1] {new DfaTrans(states30[6], sets[6])};
                states30[6].Transitions = new DfaTrans[1] {new DfaTrans(states30[7], sets[32])};
                states30[7].Transitions = new DfaTrans[2] {new DfaTrans(states30[8], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[8].Transitions = new DfaTrans[2] {new DfaTrans(states30[9], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[9].Transitions = new DfaTrans[2] {new DfaTrans(states30[10], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[10].Transitions = new DfaTrans[2] {new DfaTrans(states30[11], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[11].Transitions = new DfaTrans[2] {new DfaTrans(states30[12], sets[32]), new DfaTrans(states30[2], sets[9])};
                states30[12].Transitions = new DfaTrans[1] {new DfaTrans(states30[2], sets[9])};
                states30[13].Transitions = new DfaTrans[0] {};
                states30[14].Transitions = new DfaTrans[0] {};
                states30[15].Transitions = new DfaTrans[0] {};
                states30[16].Transitions = new DfaTrans[0] {};
                states30[17].Transitions = new DfaTrans[0] {};
                states30[18].Transitions = new DfaTrans[1] {new DfaTrans(states30[19], sets[33])};
                states30[19].Transitions = new DfaTrans[0] {};
                states30[20].Transitions = new DfaTrans[0] {};
                states30[21].Transitions = new DfaTrans[1] {new DfaTrans(states30[21], sets[5])};
                states30[22].Transitions = new DfaTrans[2] {new DfaTrans(states30[23], sets[37]), new DfaTrans(states30[21], sets[5])};
                states30[23].Transitions = new DfaTrans[1] {new DfaTrans(states30[24], sets[32])};
                states30[24].Transitions = new DfaTrans[1] {new DfaTrans(states30[25], sets[32])};
                states30[25].Transitions = new DfaTrans[1] {new DfaTrans(states30[26], sets[32])};
                states30[26].Transitions = new DfaTrans[1] {new DfaTrans(states30[27], sets[32])};
                states30[27].Transitions = new DfaTrans[1] {new DfaTrans(states30[28], sets[32])};
                states30[28].Transitions = new DfaTrans[1] {new DfaTrans(states30[29], sets[32])};
                states30[29].Transitions = new DfaTrans[0] {};
                states30[30].Transitions = new DfaTrans[1] {new DfaTrans(states30[31], sets[14])};
                states30[31].Transitions = new DfaTrans[3] {new DfaTrans(states30[32], sets[38]), new DfaTrans(states30[37], sets[18]), new DfaTrans(states30[42], sets[6])};
                states30[32].Transitions = new DfaTrans[1] {new DfaTrans(states30[33], sets[6])};
                states30[33].Transitions = new DfaTrans[1] {new DfaTrans(states30[34], sets[39])};
                states30[34].Transitions = new DfaTrans[3] {new DfaTrans(states30[35], sets[40]), new DfaTrans(states30[34], sets[41]), new DfaTrans(states30[36], sets[9])};
                states30[35].Transitions = new DfaTrans[2] {new DfaTrans(states30[35], sets[40]), new DfaTrans(states30[34], sets[41])};
                states30[36].Transitions = new DfaTrans[0] {};
                states30[37].Transitions = new DfaTrans[1] {new DfaTrans(states30[38], sets[6])};
                states30[38].Transitions = new DfaTrans[1] {new DfaTrans(states30[39], sets[39])};
                states30[39].Transitions = new DfaTrans[3] {new DfaTrans(states30[40], sets[40]), new DfaTrans(states30[39], sets[41]), new DfaTrans(states30[41], sets[9])};
                states30[40].Transitions = new DfaTrans[2] {new DfaTrans(states30[40], sets[40]), new DfaTrans(states30[39], sets[41])};
                states30[41].Transitions = new DfaTrans[0] {};
                states30[42].Transitions = new DfaTrans[1] {new DfaTrans(states30[43], sets[32])};
                states30[43].Transitions = new DfaTrans[2] {new DfaTrans(states30[44], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[44].Transitions = new DfaTrans[2] {new DfaTrans(states30[45], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[45].Transitions = new DfaTrans[2] {new DfaTrans(states30[46], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[46].Transitions = new DfaTrans[2] {new DfaTrans(states30[47], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[47].Transitions = new DfaTrans[2] {new DfaTrans(states30[48], sets[32]), new DfaTrans(states30[29], sets[9])};
                states30[48].Transitions = new DfaTrans[1] {new DfaTrans(states30[29], sets[9])};
                states30[49].Transitions = new DfaTrans[0] {};
                states30[50].Transitions = new DfaTrans[0] {};
                states30[51].Transitions = new DfaTrans[0] {};
                
                /* dfa 31 -- ˈtextˈ | '(' | ',' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states31 = new DfaState[20] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,20), new DfaState(15,true,0), new DfaState(16,true,21), new DfaState(17,true,8), new DfaState(18,true,16), new DfaState(19,true,9)};
                states31[0].Transitions = new DfaTrans[8] {new DfaTrans(states31[1], sets[23]), new DfaTrans(states31[13], sets[24]), new DfaTrans(states31[14], sets[25]), new DfaTrans(states31[15], sets[4]), new DfaTrans(states31[16], sets[27]), new DfaTrans(states31[17], sets[6]), new DfaTrans(states31[18], sets[28]), new DfaTrans(states31[19], sets[9])};
                states31[1].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[29]), new DfaTrans(states31[4], sets[30])};
                states31[2].Transitions = new DfaTrans[3] {new DfaTrans(states31[2], sets[29]), new DfaTrans(states31[3], sets[23]), new DfaTrans(states31[4], sets[30])};
                states31[3].Transitions = new DfaTrans[0] {};
                states31[4].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[31]), new DfaTrans(states31[5], sets[14])};
                states31[5].Transitions = new DfaTrans[1] {new DfaTrans(states31[6], sets[6])};
                states31[6].Transitions = new DfaTrans[1] {new DfaTrans(states31[7], sets[32])};
                states31[7].Transitions = new DfaTrans[2] {new DfaTrans(states31[8], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[8].Transitions = new DfaTrans[2] {new DfaTrans(states31[9], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[9].Transitions = new DfaTrans[2] {new DfaTrans(states31[10], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[10].Transitions = new DfaTrans[2] {new DfaTrans(states31[11], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[11].Transitions = new DfaTrans[2] {new DfaTrans(states31[12], sets[32]), new DfaTrans(states31[2], sets[9])};
                states31[12].Transitions = new DfaTrans[1] {new DfaTrans(states31[2], sets[9])};
                states31[13].Transitions = new DfaTrans[0] {};
                states31[14].Transitions = new DfaTrans[0] {};
                states31[15].Transitions = new DfaTrans[1] {new DfaTrans(states31[15], sets[5])};
                states31[16].Transitions = new DfaTrans[0] {};
                states31[17].Transitions = new DfaTrans[0] {};
                states31[18].Transitions = new DfaTrans[0] {};
                states31[19].Transitions = new DfaTrans[0] {};
                
                /* dfa 32 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states32 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,2), new DfaState(17,true,13), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,16), new DfaState(49,true,26)};
                states32[0].Transitions = new DfaTrans[13] {new DfaTrans(states32[1], sets[23]), new DfaTrans(states32[13], sets[24]), new DfaTrans(states32[14], sets[42]), new DfaTrans(states32[15], sets[37]), new DfaTrans(states32[16], sets[33]), new DfaTrans(states32[17], sets[26]), new DfaTrans(states32[18], sets[43]), new DfaTrans(states32[19], sets[34]), new DfaTrans(states32[20], sets[35]), new DfaTrans(states32[28], sets[30]), new DfaTrans(states32[47], sets[6]), new DfaTrans(states32[48], sets[28]), new DfaTrans(states32[49], sets[36])};
                states32[1].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[29]), new DfaTrans(states32[4], sets[30])};
                states32[2].Transitions = new DfaTrans[3] {new DfaTrans(states32[2], sets[29]), new DfaTrans(states32[3], sets[23]), new DfaTrans(states32[4], sets[30])};
                states32[3].Transitions = new DfaTrans[0] {};
                states32[4].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[31]), new DfaTrans(states32[5], sets[14])};
                states32[5].Transitions = new DfaTrans[1] {new DfaTrans(states32[6], sets[6])};
                states32[6].Transitions = new DfaTrans[1] {new DfaTrans(states32[7], sets[32])};
                states32[7].Transitions = new DfaTrans[2] {new DfaTrans(states32[8], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[8].Transitions = new DfaTrans[2] {new DfaTrans(states32[9], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[9].Transitions = new DfaTrans[2] {new DfaTrans(states32[10], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[10].Transitions = new DfaTrans[2] {new DfaTrans(states32[11], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[11].Transitions = new DfaTrans[2] {new DfaTrans(states32[12], sets[32]), new DfaTrans(states32[2], sets[9])};
                states32[12].Transitions = new DfaTrans[1] {new DfaTrans(states32[2], sets[9])};
                states32[13].Transitions = new DfaTrans[0] {};
                states32[14].Transitions = new DfaTrans[0] {};
                states32[15].Transitions = new DfaTrans[0] {};
                states32[16].Transitions = new DfaTrans[0] {};
                states32[17].Transitions = new DfaTrans[0] {};
                states32[18].Transitions = new DfaTrans[0] {};
                states32[19].Transitions = new DfaTrans[1] {new DfaTrans(states32[19], sets[5])};
                states32[20].Transitions = new DfaTrans[2] {new DfaTrans(states32[21], sets[37]), new DfaTrans(states32[19], sets[5])};
                states32[21].Transitions = new DfaTrans[1] {new DfaTrans(states32[22], sets[32])};
                states32[22].Transitions = new DfaTrans[1] {new DfaTrans(states32[23], sets[32])};
                states32[23].Transitions = new DfaTrans[1] {new DfaTrans(states32[24], sets[32])};
                states32[24].Transitions = new DfaTrans[1] {new DfaTrans(states32[25], sets[32])};
                states32[25].Transitions = new DfaTrans[1] {new DfaTrans(states32[26], sets[32])};
                states32[26].Transitions = new DfaTrans[1] {new DfaTrans(states32[27], sets[32])};
                states32[27].Transitions = new DfaTrans[0] {};
                states32[28].Transitions = new DfaTrans[1] {new DfaTrans(states32[29], sets[14])};
                states32[29].Transitions = new DfaTrans[3] {new DfaTrans(states32[30], sets[38]), new DfaTrans(states32[35], sets[18]), new DfaTrans(states32[40], sets[6])};
                states32[30].Transitions = new DfaTrans[1] {new DfaTrans(states32[31], sets[6])};
                states32[31].Transitions = new DfaTrans[1] {new DfaTrans(states32[32], sets[39])};
                states32[32].Transitions = new DfaTrans[3] {new DfaTrans(states32[33], sets[40]), new DfaTrans(states32[32], sets[41]), new DfaTrans(states32[34], sets[9])};
                states32[33].Transitions = new DfaTrans[2] {new DfaTrans(states32[33], sets[40]), new DfaTrans(states32[32], sets[41])};
                states32[34].Transitions = new DfaTrans[0] {};
                states32[35].Transitions = new DfaTrans[1] {new DfaTrans(states32[36], sets[6])};
                states32[36].Transitions = new DfaTrans[1] {new DfaTrans(states32[37], sets[39])};
                states32[37].Transitions = new DfaTrans[3] {new DfaTrans(states32[38], sets[40]), new DfaTrans(states32[37], sets[41]), new DfaTrans(states32[39], sets[9])};
                states32[38].Transitions = new DfaTrans[2] {new DfaTrans(states32[38], sets[40]), new DfaTrans(states32[37], sets[41])};
                states32[39].Transitions = new DfaTrans[0] {};
                states32[40].Transitions = new DfaTrans[1] {new DfaTrans(states32[41], sets[32])};
                states32[41].Transitions = new DfaTrans[2] {new DfaTrans(states32[42], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[42].Transitions = new DfaTrans[2] {new DfaTrans(states32[43], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[43].Transitions = new DfaTrans[2] {new DfaTrans(states32[44], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[44].Transitions = new DfaTrans[2] {new DfaTrans(states32[45], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[45].Transitions = new DfaTrans[2] {new DfaTrans(states32[46], sets[32]), new DfaTrans(states32[27], sets[9])};
                states32[46].Transitions = new DfaTrans[1] {new DfaTrans(states32[27], sets[9])};
                states32[47].Transitions = new DfaTrans[0] {};
                states32[48].Transitions = new DfaTrans[0] {};
                states32[49].Transitions = new DfaTrans[0] {};
                
                /* dfa 33 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states33 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,2), new DfaState(17,true,27), new DfaState(18,true,13), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,26)};
                states33[0].Transitions = new DfaTrans[13] {new DfaTrans(states33[1], sets[23]), new DfaTrans(states33[13], sets[24]), new DfaTrans(states33[14], sets[42]), new DfaTrans(states33[15], sets[37]), new DfaTrans(states33[16], sets[33]), new DfaTrans(states33[18], sets[26]), new DfaTrans(states33[19], sets[43]), new DfaTrans(states33[20], sets[34]), new DfaTrans(states33[21], sets[35]), new DfaTrans(states33[29], sets[30]), new DfaTrans(states33[48], sets[6]), new DfaTrans(states33[49], sets[28]), new DfaTrans(states33[50], sets[36])};
                states33[1].Transitions = new DfaTrans[2] {new DfaTrans(states33[2], sets[29]), new DfaTrans(states33[4], sets[30])};
                states33[2].Transitions = new DfaTrans[3] {new DfaTrans(states33[2], sets[29]), new DfaTrans(states33[3], sets[23]), new DfaTrans(states33[4], sets[30])};
                states33[3].Transitions = new DfaTrans[0] {};
                states33[4].Transitions = new DfaTrans[2] {new DfaTrans(states33[2], sets[31]), new DfaTrans(states33[5], sets[14])};
                states33[5].Transitions = new DfaTrans[1] {new DfaTrans(states33[6], sets[6])};
                states33[6].Transitions = new DfaTrans[1] {new DfaTrans(states33[7], sets[32])};
                states33[7].Transitions = new DfaTrans[2] {new DfaTrans(states33[8], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[8].Transitions = new DfaTrans[2] {new DfaTrans(states33[9], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[9].Transitions = new DfaTrans[2] {new DfaTrans(states33[10], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[10].Transitions = new DfaTrans[2] {new DfaTrans(states33[11], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[11].Transitions = new DfaTrans[2] {new DfaTrans(states33[12], sets[32]), new DfaTrans(states33[2], sets[9])};
                states33[12].Transitions = new DfaTrans[1] {new DfaTrans(states33[2], sets[9])};
                states33[13].Transitions = new DfaTrans[0] {};
                states33[14].Transitions = new DfaTrans[0] {};
                states33[15].Transitions = new DfaTrans[0] {};
                states33[16].Transitions = new DfaTrans[1] {new DfaTrans(states33[17], sets[33])};
                states33[17].Transitions = new DfaTrans[0] {};
                states33[18].Transitions = new DfaTrans[0] {};
                states33[19].Transitions = new DfaTrans[0] {};
                states33[20].Transitions = new DfaTrans[1] {new DfaTrans(states33[20], sets[5])};
                states33[21].Transitions = new DfaTrans[2] {new DfaTrans(states33[22], sets[37]), new DfaTrans(states33[20], sets[5])};
                states33[22].Transitions = new DfaTrans[1] {new DfaTrans(states33[23], sets[32])};
                states33[23].Transitions = new DfaTrans[1] {new DfaTrans(states33[24], sets[32])};
                states33[24].Transitions = new DfaTrans[1] {new DfaTrans(states33[25], sets[32])};
                states33[25].Transitions = new DfaTrans[1] {new DfaTrans(states33[26], sets[32])};
                states33[26].Transitions = new DfaTrans[1] {new DfaTrans(states33[27], sets[32])};
                states33[27].Transitions = new DfaTrans[1] {new DfaTrans(states33[28], sets[32])};
                states33[28].Transitions = new DfaTrans[0] {};
                states33[29].Transitions = new DfaTrans[1] {new DfaTrans(states33[30], sets[14])};
                states33[30].Transitions = new DfaTrans[3] {new DfaTrans(states33[31], sets[38]), new DfaTrans(states33[36], sets[18]), new DfaTrans(states33[41], sets[6])};
                states33[31].Transitions = new DfaTrans[1] {new DfaTrans(states33[32], sets[6])};
                states33[32].Transitions = new DfaTrans[1] {new DfaTrans(states33[33], sets[39])};
                states33[33].Transitions = new DfaTrans[3] {new DfaTrans(states33[34], sets[40]), new DfaTrans(states33[33], sets[41]), new DfaTrans(states33[35], sets[9])};
                states33[34].Transitions = new DfaTrans[2] {new DfaTrans(states33[34], sets[40]), new DfaTrans(states33[33], sets[41])};
                states33[35].Transitions = new DfaTrans[0] {};
                states33[36].Transitions = new DfaTrans[1] {new DfaTrans(states33[37], sets[6])};
                states33[37].Transitions = new DfaTrans[1] {new DfaTrans(states33[38], sets[39])};
                states33[38].Transitions = new DfaTrans[3] {new DfaTrans(states33[39], sets[40]), new DfaTrans(states33[38], sets[41]), new DfaTrans(states33[40], sets[9])};
                states33[39].Transitions = new DfaTrans[2] {new DfaTrans(states33[39], sets[40]), new DfaTrans(states33[38], sets[41])};
                states33[40].Transitions = new DfaTrans[0] {};
                states33[41].Transitions = new DfaTrans[1] {new DfaTrans(states33[42], sets[32])};
                states33[42].Transitions = new DfaTrans[2] {new DfaTrans(states33[43], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[43].Transitions = new DfaTrans[2] {new DfaTrans(states33[44], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[44].Transitions = new DfaTrans[2] {new DfaTrans(states33[45], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[45].Transitions = new DfaTrans[2] {new DfaTrans(states33[46], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[46].Transitions = new DfaTrans[2] {new DfaTrans(states33[47], sets[32]), new DfaTrans(states33[28], sets[9])};
                states33[47].Transitions = new DfaTrans[1] {new DfaTrans(states33[28], sets[9])};
                states33[48].Transitions = new DfaTrans[0] {};
                states33[49].Transitions = new DfaTrans[0] {};
                states33[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 34 -- ',' | '}' -- */
                var states34 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,20), new DfaState(2,true,9)};
                states34[0].Transitions = new DfaTrans[2] {new DfaTrans(states34[1], sets[25]), new DfaTrans(states34[2], sets[9])};
                states34[1].Transitions = new DfaTrans[0] {};
                states34[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 35 -- ˈtextˈ | '(' | ')' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states35 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,2), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,16), new DfaState(45,true,26)};
                states35[0].Transitions = new DfaTrans[9] {new DfaTrans(states35[1], sets[23]), new DfaTrans(states35[13], sets[24]), new DfaTrans(states35[14], sets[44]), new DfaTrans(states35[15], sets[33]), new DfaTrans(states35[16], sets[34]), new DfaTrans(states35[17], sets[35]), new DfaTrans(states35[25], sets[30]), new DfaTrans(states35[44], sets[28]), new DfaTrans(states35[45], sets[36])};
                states35[1].Transitions = new DfaTrans[2] {new DfaTrans(states35[2], sets[29]), new DfaTrans(states35[4], sets[30])};
                states35[2].Transitions = new DfaTrans[3] {new DfaTrans(states35[2], sets[29]), new DfaTrans(states35[3], sets[23]), new DfaTrans(states35[4], sets[30])};
                states35[3].Transitions = new DfaTrans[0] {};
                states35[4].Transitions = new DfaTrans[2] {new DfaTrans(states35[2], sets[31]), new DfaTrans(states35[5], sets[14])};
                states35[5].Transitions = new DfaTrans[1] {new DfaTrans(states35[6], sets[6])};
                states35[6].Transitions = new DfaTrans[1] {new DfaTrans(states35[7], sets[32])};
                states35[7].Transitions = new DfaTrans[2] {new DfaTrans(states35[8], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[8].Transitions = new DfaTrans[2] {new DfaTrans(states35[9], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[9].Transitions = new DfaTrans[2] {new DfaTrans(states35[10], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[10].Transitions = new DfaTrans[2] {new DfaTrans(states35[11], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[11].Transitions = new DfaTrans[2] {new DfaTrans(states35[12], sets[32]), new DfaTrans(states35[2], sets[9])};
                states35[12].Transitions = new DfaTrans[1] {new DfaTrans(states35[2], sets[9])};
                states35[13].Transitions = new DfaTrans[0] {};
                states35[14].Transitions = new DfaTrans[0] {};
                states35[15].Transitions = new DfaTrans[0] {};
                states35[16].Transitions = new DfaTrans[1] {new DfaTrans(states35[16], sets[5])};
                states35[17].Transitions = new DfaTrans[2] {new DfaTrans(states35[18], sets[37]), new DfaTrans(states35[16], sets[5])};
                states35[18].Transitions = new DfaTrans[1] {new DfaTrans(states35[19], sets[32])};
                states35[19].Transitions = new DfaTrans[1] {new DfaTrans(states35[20], sets[32])};
                states35[20].Transitions = new DfaTrans[1] {new DfaTrans(states35[21], sets[32])};
                states35[21].Transitions = new DfaTrans[1] {new DfaTrans(states35[22], sets[32])};
                states35[22].Transitions = new DfaTrans[1] {new DfaTrans(states35[23], sets[32])};
                states35[23].Transitions = new DfaTrans[1] {new DfaTrans(states35[24], sets[32])};
                states35[24].Transitions = new DfaTrans[0] {};
                states35[25].Transitions = new DfaTrans[1] {new DfaTrans(states35[26], sets[14])};
                states35[26].Transitions = new DfaTrans[3] {new DfaTrans(states35[27], sets[38]), new DfaTrans(states35[32], sets[18]), new DfaTrans(states35[37], sets[6])};
                states35[27].Transitions = new DfaTrans[1] {new DfaTrans(states35[28], sets[6])};
                states35[28].Transitions = new DfaTrans[1] {new DfaTrans(states35[29], sets[39])};
                states35[29].Transitions = new DfaTrans[3] {new DfaTrans(states35[30], sets[40]), new DfaTrans(states35[29], sets[41]), new DfaTrans(states35[31], sets[9])};
                states35[30].Transitions = new DfaTrans[2] {new DfaTrans(states35[30], sets[40]), new DfaTrans(states35[29], sets[41])};
                states35[31].Transitions = new DfaTrans[0] {};
                states35[32].Transitions = new DfaTrans[1] {new DfaTrans(states35[33], sets[6])};
                states35[33].Transitions = new DfaTrans[1] {new DfaTrans(states35[34], sets[39])};
                states35[34].Transitions = new DfaTrans[3] {new DfaTrans(states35[35], sets[40]), new DfaTrans(states35[34], sets[41]), new DfaTrans(states35[36], sets[9])};
                states35[35].Transitions = new DfaTrans[2] {new DfaTrans(states35[35], sets[40]), new DfaTrans(states35[34], sets[41])};
                states35[36].Transitions = new DfaTrans[0] {};
                states35[37].Transitions = new DfaTrans[1] {new DfaTrans(states35[38], sets[32])};
                states35[38].Transitions = new DfaTrans[2] {new DfaTrans(states35[39], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[39].Transitions = new DfaTrans[2] {new DfaTrans(states35[40], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[40].Transitions = new DfaTrans[2] {new DfaTrans(states35[41], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[41].Transitions = new DfaTrans[2] {new DfaTrans(states35[42], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[42].Transitions = new DfaTrans[2] {new DfaTrans(states35[43], sets[32]), new DfaTrans(states35[24], sets[9])};
                states35[43].Transitions = new DfaTrans[1] {new DfaTrans(states35[24], sets[9])};
                states35[44].Transitions = new DfaTrans[0] {};
                states35[45].Transitions = new DfaTrans[0] {};
                
                /* dfa 36 -- '}' -- */
                var states36 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,9)};
                states36[0].Transitions = new DfaTrans[1] {new DfaTrans(states36[1], sets[9])};
                states36[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 37 -- '|' | '}' -- */
                var states37 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,16), new DfaState(2,true,9)};
                states37[0].Transitions = new DfaTrans[2] {new DfaTrans(states37[1], sets[28]), new DfaTrans(states37[2], sets[9])};
                states37[1].Transitions = new DfaTrans[0] {};
                states37[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 38 -- ˈtextˈ | '(' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '^' | '{' | '|' | '}' -- */
                var states38 = new DfaState[23] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,18), new DfaState(15,true,19), new DfaState(16,true,20), new DfaState(17,true,17), new DfaState(18,true,0), new DfaState(19,true,21), new DfaState(20,true,8), new DfaState(21,true,16), new DfaState(22,true,9)};
                states38[0].Transitions = new DfaTrans[11] {new DfaTrans(states38[1], sets[23]), new DfaTrans(states38[13], sets[24]), new DfaTrans(states38[14], sets[42]), new DfaTrans(states38[15], sets[37]), new DfaTrans(states38[16], sets[25]), new DfaTrans(states38[17], sets[43]), new DfaTrans(states38[18], sets[4]), new DfaTrans(states38[19], sets[27]), new DfaTrans(states38[20], sets[6]), new DfaTrans(states38[21], sets[28]), new DfaTrans(states38[22], sets[9])};
                states38[1].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[29]), new DfaTrans(states38[4], sets[30])};
                states38[2].Transitions = new DfaTrans[3] {new DfaTrans(states38[2], sets[29]), new DfaTrans(states38[3], sets[23]), new DfaTrans(states38[4], sets[30])};
                states38[3].Transitions = new DfaTrans[0] {};
                states38[4].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[31]), new DfaTrans(states38[5], sets[14])};
                states38[5].Transitions = new DfaTrans[1] {new DfaTrans(states38[6], sets[6])};
                states38[6].Transitions = new DfaTrans[1] {new DfaTrans(states38[7], sets[32])};
                states38[7].Transitions = new DfaTrans[2] {new DfaTrans(states38[8], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[8].Transitions = new DfaTrans[2] {new DfaTrans(states38[9], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[9].Transitions = new DfaTrans[2] {new DfaTrans(states38[10], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[10].Transitions = new DfaTrans[2] {new DfaTrans(states38[11], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[11].Transitions = new DfaTrans[2] {new DfaTrans(states38[12], sets[32]), new DfaTrans(states38[2], sets[9])};
                states38[12].Transitions = new DfaTrans[1] {new DfaTrans(states38[2], sets[9])};
                states38[13].Transitions = new DfaTrans[0] {};
                states38[14].Transitions = new DfaTrans[0] {};
                states38[15].Transitions = new DfaTrans[0] {};
                states38[16].Transitions = new DfaTrans[0] {};
                states38[17].Transitions = new DfaTrans[0] {};
                states38[18].Transitions = new DfaTrans[1] {new DfaTrans(states38[18], sets[5])};
                states38[19].Transitions = new DfaTrans[0] {};
                states38[20].Transitions = new DfaTrans[0] {};
                states38[21].Transitions = new DfaTrans[0] {};
                states38[22].Transitions = new DfaTrans[0] {};
                
                /* dfa 39 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states39 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,2), new DfaState(18,true,17), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,16), new DfaState(49,true,26)};
                states39[0].Transitions = new DfaTrans[13] {new DfaTrans(states39[1], sets[23]), new DfaTrans(states39[13], sets[24]), new DfaTrans(states39[14], sets[44]), new DfaTrans(states39[15], sets[42]), new DfaTrans(states39[16], sets[37]), new DfaTrans(states39[17], sets[33]), new DfaTrans(states39[18], sets[43]), new DfaTrans(states39[19], sets[34]), new DfaTrans(states39[20], sets[35]), new DfaTrans(states39[28], sets[30]), new DfaTrans(states39[47], sets[6]), new DfaTrans(states39[48], sets[28]), new DfaTrans(states39[49], sets[36])};
                states39[1].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[29]), new DfaTrans(states39[4], sets[30])};
                states39[2].Transitions = new DfaTrans[3] {new DfaTrans(states39[2], sets[29]), new DfaTrans(states39[3], sets[23]), new DfaTrans(states39[4], sets[30])};
                states39[3].Transitions = new DfaTrans[0] {};
                states39[4].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[31]), new DfaTrans(states39[5], sets[14])};
                states39[5].Transitions = new DfaTrans[1] {new DfaTrans(states39[6], sets[6])};
                states39[6].Transitions = new DfaTrans[1] {new DfaTrans(states39[7], sets[32])};
                states39[7].Transitions = new DfaTrans[2] {new DfaTrans(states39[8], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[8].Transitions = new DfaTrans[2] {new DfaTrans(states39[9], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[9].Transitions = new DfaTrans[2] {new DfaTrans(states39[10], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[10].Transitions = new DfaTrans[2] {new DfaTrans(states39[11], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[11].Transitions = new DfaTrans[2] {new DfaTrans(states39[12], sets[32]), new DfaTrans(states39[2], sets[9])};
                states39[12].Transitions = new DfaTrans[1] {new DfaTrans(states39[2], sets[9])};
                states39[13].Transitions = new DfaTrans[0] {};
                states39[14].Transitions = new DfaTrans[0] {};
                states39[15].Transitions = new DfaTrans[0] {};
                states39[16].Transitions = new DfaTrans[0] {};
                states39[17].Transitions = new DfaTrans[0] {};
                states39[18].Transitions = new DfaTrans[0] {};
                states39[19].Transitions = new DfaTrans[1] {new DfaTrans(states39[19], sets[5])};
                states39[20].Transitions = new DfaTrans[2] {new DfaTrans(states39[21], sets[37]), new DfaTrans(states39[19], sets[5])};
                states39[21].Transitions = new DfaTrans[1] {new DfaTrans(states39[22], sets[32])};
                states39[22].Transitions = new DfaTrans[1] {new DfaTrans(states39[23], sets[32])};
                states39[23].Transitions = new DfaTrans[1] {new DfaTrans(states39[24], sets[32])};
                states39[24].Transitions = new DfaTrans[1] {new DfaTrans(states39[25], sets[32])};
                states39[25].Transitions = new DfaTrans[1] {new DfaTrans(states39[26], sets[32])};
                states39[26].Transitions = new DfaTrans[1] {new DfaTrans(states39[27], sets[32])};
                states39[27].Transitions = new DfaTrans[0] {};
                states39[28].Transitions = new DfaTrans[1] {new DfaTrans(states39[29], sets[14])};
                states39[29].Transitions = new DfaTrans[3] {new DfaTrans(states39[30], sets[38]), new DfaTrans(states39[35], sets[18]), new DfaTrans(states39[40], sets[6])};
                states39[30].Transitions = new DfaTrans[1] {new DfaTrans(states39[31], sets[6])};
                states39[31].Transitions = new DfaTrans[1] {new DfaTrans(states39[32], sets[39])};
                states39[32].Transitions = new DfaTrans[3] {new DfaTrans(states39[33], sets[40]), new DfaTrans(states39[32], sets[41]), new DfaTrans(states39[34], sets[9])};
                states39[33].Transitions = new DfaTrans[2] {new DfaTrans(states39[33], sets[40]), new DfaTrans(states39[32], sets[41])};
                states39[34].Transitions = new DfaTrans[0] {};
                states39[35].Transitions = new DfaTrans[1] {new DfaTrans(states39[36], sets[6])};
                states39[36].Transitions = new DfaTrans[1] {new DfaTrans(states39[37], sets[39])};
                states39[37].Transitions = new DfaTrans[3] {new DfaTrans(states39[38], sets[40]), new DfaTrans(states39[37], sets[41]), new DfaTrans(states39[39], sets[9])};
                states39[38].Transitions = new DfaTrans[2] {new DfaTrans(states39[38], sets[40]), new DfaTrans(states39[37], sets[41])};
                states39[39].Transitions = new DfaTrans[0] {};
                states39[40].Transitions = new DfaTrans[1] {new DfaTrans(states39[41], sets[32])};
                states39[41].Transitions = new DfaTrans[2] {new DfaTrans(states39[42], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[42].Transitions = new DfaTrans[2] {new DfaTrans(states39[43], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[43].Transitions = new DfaTrans[2] {new DfaTrans(states39[44], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[44].Transitions = new DfaTrans[2] {new DfaTrans(states39[45], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[45].Transitions = new DfaTrans[2] {new DfaTrans(states39[46], sets[32]), new DfaTrans(states39[27], sets[9])};
                states39[46].Transitions = new DfaTrans[1] {new DfaTrans(states39[27], sets[9])};
                states39[47].Transitions = new DfaTrans[0] {};
                states39[48].Transitions = new DfaTrans[0] {};
                states39[49].Transitions = new DfaTrans[0] {};
                
                /* dfa 40 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states40 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,22), new DfaState(14,true,23), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,2), new DfaState(18,true,27), new DfaState(19,true,17), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,16), new DfaState(50,true,26)};
                states40[0].Transitions = new DfaTrans[13] {new DfaTrans(states40[1], sets[23]), new DfaTrans(states40[13], sets[24]), new DfaTrans(states40[14], sets[44]), new DfaTrans(states40[15], sets[42]), new DfaTrans(states40[16], sets[37]), new DfaTrans(states40[17], sets[33]), new DfaTrans(states40[19], sets[43]), new DfaTrans(states40[20], sets[34]), new DfaTrans(states40[21], sets[35]), new DfaTrans(states40[29], sets[30]), new DfaTrans(states40[48], sets[6]), new DfaTrans(states40[49], sets[28]), new DfaTrans(states40[50], sets[36])};
                states40[1].Transitions = new DfaTrans[2] {new DfaTrans(states40[2], sets[29]), new DfaTrans(states40[4], sets[30])};
                states40[2].Transitions = new DfaTrans[3] {new DfaTrans(states40[2], sets[29]), new DfaTrans(states40[3], sets[23]), new DfaTrans(states40[4], sets[30])};
                states40[3].Transitions = new DfaTrans[0] {};
                states40[4].Transitions = new DfaTrans[2] {new DfaTrans(states40[2], sets[31]), new DfaTrans(states40[5], sets[14])};
                states40[5].Transitions = new DfaTrans[1] {new DfaTrans(states40[6], sets[6])};
                states40[6].Transitions = new DfaTrans[1] {new DfaTrans(states40[7], sets[32])};
                states40[7].Transitions = new DfaTrans[2] {new DfaTrans(states40[8], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[8].Transitions = new DfaTrans[2] {new DfaTrans(states40[9], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[9].Transitions = new DfaTrans[2] {new DfaTrans(states40[10], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[10].Transitions = new DfaTrans[2] {new DfaTrans(states40[11], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[11].Transitions = new DfaTrans[2] {new DfaTrans(states40[12], sets[32]), new DfaTrans(states40[2], sets[9])};
                states40[12].Transitions = new DfaTrans[1] {new DfaTrans(states40[2], sets[9])};
                states40[13].Transitions = new DfaTrans[0] {};
                states40[14].Transitions = new DfaTrans[0] {};
                states40[15].Transitions = new DfaTrans[0] {};
                states40[16].Transitions = new DfaTrans[0] {};
                states40[17].Transitions = new DfaTrans[1] {new DfaTrans(states40[18], sets[33])};
                states40[18].Transitions = new DfaTrans[0] {};
                states40[19].Transitions = new DfaTrans[0] {};
                states40[20].Transitions = new DfaTrans[1] {new DfaTrans(states40[20], sets[5])};
                states40[21].Transitions = new DfaTrans[2] {new DfaTrans(states40[22], sets[37]), new DfaTrans(states40[20], sets[5])};
                states40[22].Transitions = new DfaTrans[1] {new DfaTrans(states40[23], sets[32])};
                states40[23].Transitions = new DfaTrans[1] {new DfaTrans(states40[24], sets[32])};
                states40[24].Transitions = new DfaTrans[1] {new DfaTrans(states40[25], sets[32])};
                states40[25].Transitions = new DfaTrans[1] {new DfaTrans(states40[26], sets[32])};
                states40[26].Transitions = new DfaTrans[1] {new DfaTrans(states40[27], sets[32])};
                states40[27].Transitions = new DfaTrans[1] {new DfaTrans(states40[28], sets[32])};
                states40[28].Transitions = new DfaTrans[0] {};
                states40[29].Transitions = new DfaTrans[1] {new DfaTrans(states40[30], sets[14])};
                states40[30].Transitions = new DfaTrans[3] {new DfaTrans(states40[31], sets[38]), new DfaTrans(states40[36], sets[18]), new DfaTrans(states40[41], sets[6])};
                states40[31].Transitions = new DfaTrans[1] {new DfaTrans(states40[32], sets[6])};
                states40[32].Transitions = new DfaTrans[1] {new DfaTrans(states40[33], sets[39])};
                states40[33].Transitions = new DfaTrans[3] {new DfaTrans(states40[34], sets[40]), new DfaTrans(states40[33], sets[41]), new DfaTrans(states40[35], sets[9])};
                states40[34].Transitions = new DfaTrans[2] {new DfaTrans(states40[34], sets[40]), new DfaTrans(states40[33], sets[41])};
                states40[35].Transitions = new DfaTrans[0] {};
                states40[36].Transitions = new DfaTrans[1] {new DfaTrans(states40[37], sets[6])};
                states40[37].Transitions = new DfaTrans[1] {new DfaTrans(states40[38], sets[39])};
                states40[38].Transitions = new DfaTrans[3] {new DfaTrans(states40[39], sets[40]), new DfaTrans(states40[38], sets[41]), new DfaTrans(states40[40], sets[9])};
                states40[39].Transitions = new DfaTrans[2] {new DfaTrans(states40[39], sets[40]), new DfaTrans(states40[38], sets[41])};
                states40[40].Transitions = new DfaTrans[0] {};
                states40[41].Transitions = new DfaTrans[1] {new DfaTrans(states40[42], sets[32])};
                states40[42].Transitions = new DfaTrans[2] {new DfaTrans(states40[43], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[43].Transitions = new DfaTrans[2] {new DfaTrans(states40[44], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[44].Transitions = new DfaTrans[2] {new DfaTrans(states40[45], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[45].Transitions = new DfaTrans[2] {new DfaTrans(states40[46], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[46].Transitions = new DfaTrans[2] {new DfaTrans(states40[47], sets[32]), new DfaTrans(states40[28], sets[9])};
                states40[47].Transitions = new DfaTrans[1] {new DfaTrans(states40[28], sets[9])};
                states40[48].Transitions = new DfaTrans[0] {};
                states40[49].Transitions = new DfaTrans[0] {};
                states40[50].Transitions = new DfaTrans[0] {};
                
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
                    205, 93, 15, 132, 108, 215, 25, 63, 231, 254, 159, 165, 161, 161, 161, 161, 165, 165, 161, 165, 165,
                    161, 143, 62, 250, 232, 163, 75, 31, 125, 244, 209, 208, 208, 208, 208, 208, 208, 208, 144, 208, 208,
                    48, 143, 125, 76, 152, 48, 97, 194, 134, 121, 108, 216, 199, 62, 54, 236, 99, 195, 62, 246, 177, 97,
                    195, 132, 13, 27, 54, 108, 152, 176, 97, 195, 132, 13, 19, 246, 177, 143, 125, 122, 254, 159, 123, 102,
                    238, 204, 220, 251, 157, 239, 190, 215, 223, 249, 247, 157, 239, 220, 251, 205, 189, 103, 238, 157, 185,
                    231, 247, 125, 179, 75, 136, 192, 247, 100, 51, 129, 184, 49, 101, 0, 136, 16, 215, 28, 33, 73, 245,
                    93, 190, 143, 125, 12, 26, 63, 64, 183, 248, 86, 240, 75, 222, 252, 90, 247, 127, 163, 133, 31, 254,
                    136, 252, 100, 108, 219, 159, 141, 239, 252, 243, 34, 139, 55, 130, 27, 129, 108, 173, 198, 243, 32,
                    9, 121, 226, 9, 81, 155, 174, 183, 193, 39, 159, 20, 181, 233, 122, 27, 124, 234, 41, 81, 155, 174, 183,
                    193, 223, 77, 121, 99, 126, 91, 226, 141, 41, 194, 239, 189, 143, 104, 12, 127, 192, 54, 248, 71, 108,
                    131, 228, 122, 112, 93, 92, 123, 178, 118, 37, 92, 44, 120, 236, 251, 110, 64, 254, 66, 200, 95, 139,
                    134, 254, 52, 127, 239, 63, 91, 241, 31, 90, 120, 127, 214, 89, 254, 109, 174, 201, 191, 27, 233, 223,
                    90, 248, 188, 202, 188, 253, 179, 88, 253, 47, 167, 247, 78, 192, 179, 40, 104, 248, 207, 212, 137, 124,
                    13, 108, 243, 191, 224, 61, 167, 160, 73, 49, 172, 220, 52, 243, 102, 37, 79, 152, 203, 167, 53, 235,
                    8, 151, 80, 14, 159, 161, 67, 187, 21, 76, 181, 205, 182, 159, 153, 243, 181, 146, 39, 204, 101, 222,
                    171, 114, 114, 203, 208, 153, 88, 165, 107, 85, 119, 93, 113, 118, 120, 59, 224, 89, 20, 52, 60, 253,
                    180, 168, 77, 23, 106, 103, 29, 235, 250, 48, 216, 64, 183, 248, 158, 153, 56, 43, 97, 225, 153, 103,
                    68, 109, 186, 80, 59, 35, 118, 214, 167, 226, 204, 207, 68, 253, 17, 59, 82, 94, 200, 57, 109, 6, 75,
                    227, 135, 189, 73, 183, 232, 54, 221, 161, 187, 180, 79, 247, 232, 62, 61, 160, 135, 116, 64, 143, 232,
                    49, 29, 78, 153, 189, 19, 165, 191, 197, 76, 241, 146, 175, 133, 116, 43, 224, 9, 122, 248, 132, 220,
                    102, 251, 242, 146, 175, 133, 116, 59, 224, 9, 110, 248, 83, 179, 175, 149, 176, 112, 131, 222, 16, 243,
                    34, 107, 87, 170, 138, 126, 64, 246, 130, 253, 224, 32, 56, 12, 6, 234, 64, 239, 179, 150, 23, 134, 35,
                    33, 30, 79, 61, 131, 22, 27, 105, 7, 157, 160, 27, 44, 7, 189, 96, 37, 88, 13, 214, 130, 245, 128, 108,
                    4, 155, 193, 86, 176, 29, 236, 228, 118, 220, 13, 200, 23, 60, 235, 36, 181, 188, 85, 178, 20, 245, 64,
                    85, 124, 25, 176, 172, 147, 81, 137, 98, 68, 61, 224, 133, 33, 250, 219, 121, 130, 110, 113, 132, 110,
                    241, 67, 102, 145, 23, 24, 78, 11, 247, 124, 86, 100, 63, 220, 99, 150, 121, 201, 215, 66, 186, 23, 240,
                    4, 55, 124, 81, 100, 91, 241, 246, 226, 69, 209, 131, 225, 146, 200, 182, 226, 237, 165, 75, 162, 7,
                    195, 101, 145, 109, 197, 219, 203, 151, 69, 15, 134, 69, 145, 109, 181, 120, 30, 52, 195, 165, 112, 113,
                    81, 40, 96, 120, 78, 100, 91, 61, 39, 1, 55, 248, 188, 200, 182, 122, 94, 2, 110, 240, 5, 145, 109, 245,
                    130, 4, 220, 224, 203, 34, 219, 234, 101, 9, 184, 193, 87, 69, 182, 213, 171, 18, 112, 131, 111, 136,
                    108, 171, 55, 36, 224, 6, 199, 31, 3, 46, 136, 92, 252, 16, 192, 208, 10, 203, 63, 1, 40, 92, 103, 195,
                    188, 228, 235, 235, 52, 159, 224, 71, 255, 166, 200, 182, 122, 83, 2, 110, 176, 141, 206, 239, 141, 79,
                    176, 65, 209, 244, 42, 116, 194, 18, 243, 10, 49, 220, 45, 99, 248, 128, 205, 193, 161, 152, 135, 129,
                    158, 13, 241, 96, 120, 20, 30, 135, 195, 80, 136, 57, 44, 135, 189, 112, 37, 92, 13, 215, 194, 245, 112,
                    35, 220, 12, 183, 194, 237, 112, 39, 220, 13, 251, 225, 222, 148, 185, 220, 87, 250, 239, 40, 203, 58,
                    241, 158, 212, 25, 165, 237, 205, 60, 220, 114, 56, 65, 127, 99, 191, 97, 19, 193, 139, 7, 70, 227, 7,
                    245, 46, 59, 85, 94, 16, 241, 14, 51, 199, 139, 196, 25, 116, 26, 190, 11, 88, 214, 201, 168, 68, 49,
                    162, 30, 168, 138, 247, 41, 203, 58, 25, 149, 40, 70, 212, 3, 85, 113, 139, 178, 172, 147, 81, 137, 98,
                    68, 61, 80, 21, 183, 41, 203, 58, 25, 149, 40, 70, 212, 3, 85, 241, 1, 101, 89, 39, 163, 18, 197, 136,
                    122, 160, 42, 238, 80, 150, 117, 34, 205, 72, 233, 88, 89, 138, 90, 81, 59, 210, 61, 94, 207, 199, 249,
                    228, 37, 245, 41, 101, 89, 39, 222, 147, 58, 163, 180, 61, 216, 9, 124, 66, 89, 214, 137, 247, 164, 206,
                    40, 109, 15, 102, 255, 43, 202, 178, 78, 188, 39, 117, 70, 105, 123, 48, 251, 51, 208, 17, 239, 6, 198,
                    90, 240, 38, 59, 56, 94, 212, 90, 240, 38, 157, 189, 22, 228, 232, 70, 51, 215, 129, 226, 187, 59, 247,
                    181, 61, 249, 125, 110, 123, 160, 179, 32, 95, 80, 150, 117, 226, 61, 169, 51, 74, 219, 131, 217, 255,
                    146, 178, 172, 19, 239, 73, 157, 81, 218, 222, 67, 216, 43, 124, 67, 89, 214, 137, 247, 164, 206, 40,
                    109, 15, 118, 2, 223, 82, 150, 117, 226, 61, 169, 51, 74, 219, 131, 217, 255, 154, 178, 172, 19, 239,
                    73, 157, 81, 218, 222, 3, 216, 43, 28, 70, 100, 16, 29, 69, 199, 209, 48, 58, 177, 151, 186, 226, 44,
                    70, 17, 19, 238, 7, 167, 83, 239, 129, 101, 54, 210, 139, 86, 162, 213, 104, 45, 90, 143, 54, 162, 205,
                    104, 43, 218, 142, 200, 78, 180, 27, 245, 163, 189, 104, 63, 183, 227, 65, 84, 116, 83, 148, 131, 190,
                    31, 52, 206, 162, 241, 27, 193, 224, 199, 44, 241, 140, 134, 159, 178, 196, 179, 47, 126, 49, 33, 96,
                    226, 87, 236, 115, 31, 246, 73, 5, 166, 32, 73, 51, 134, 49, 144, 87, 68, 182, 21, 111, 175, 92, 17,
                    61, 24, 174, 138, 108, 43, 222, 94, 189, 42, 122, 48, 92, 19, 217, 86, 188, 189, 118, 77, 244, 96, 184,
                    203, 38, 143, 151, 124, 45, 164, 187, 1, 79, 112, 195, 179, 208, 138, 219, 113, 165, 29, 150, 228, 230,
                    47, 138, 108, 171, 23, 37, 224, 7, 242, 146, 200, 182, 122, 73, 2, 110, 112, 10, 58, 213, 78, 119, 22,
                    52, 65, 7, 32, 234, 186, 211, 142, 66, 49, 116, 207, 162, 49, 116, 196, 33, 232, 60, 40, 58, 135, 161,
                    35, 134, 161, 187, 136, 195, 208, 17, 195, 208, 93, 194, 97, 232, 136, 97, 232, 46, 227, 48, 116, 188,
                    237, 197, 43, 241, 106, 188, 232, 67, 209, 57, 12, 29, 111, 125, 41, 58, 135, 161, 227, 173, 47, 69,
                    231, 48, 116, 188, 245, 165, 232, 28, 134, 142, 183, 190, 20, 157, 195, 208, 241, 214, 151, 162, 115,
                    24, 58, 222, 250, 82, 116, 5, 116, 204, 5, 195, 198, 112, 201, 197, 90, 92, 158, 137, 153, 194, 208,
                    9, 1, 137, 162, 115, 24, 58, 222, 250, 82, 116, 235, 120, 31, 186, 211, 39, 88, 98, 56, 125, 218, 54,
                    226, 18, 243, 10, 49, 188, 9, 52, 60, 131, 161, 219, 138, 161, 12, 221, 91, 230, 125, 183, 18, 38, 222,
                    102, 86, 183, 189, 223, 79, 127, 63, 40, 217, 137, 203, 185, 65, 207, 98, 114, 30, 55, 147, 165, 164,
                    149, 180, 147, 137, 151, 234, 112, 85, 119, 106, 64, 231, 174, 60, 211, 126, 188, 23, 239, 199, 7, 241,
                    97, 60, 136, 201, 81, 124, 28, 15, 227, 147, 120, 148, 155, 133, 211, 152, 124, 68, 89, 214, 73, 106,
                    121, 171, 100, 41, 234, 129, 202, 88, 6, 132, 156, 206, 196, 135, 148, 101, 157, 140, 74, 20, 35, 234,
                    129, 170, 184, 75, 89, 214, 201, 168, 68, 49, 162, 30, 168, 138, 123, 148, 101, 157, 140, 74, 20, 35,
                    234, 1, 0, 86, 216, 60, 175, 250, 205, 117, 207, 217, 253, 219, 128, 101, 157, 140, 74, 20, 35, 234,
                    129, 170, 40, 34, 227, 137, 203, 197, 171, 77, 160, 231, 82, 136, 53, 188, 107, 81, 115, 241, 80, 78,
                    126, 189, 224, 80, 52, 23, 143, 200, 201, 107, 46, 158, 181, 155, 9, 30, 25, 47, 181, 178, 81, 195, 104,
                    100, 188, 212, 202, 70, 13, 163, 145, 241, 82, 43, 27, 53, 140, 70, 198, 75, 173, 108, 212, 48, 26, 25,
                    47, 181, 178, 81, 195, 24, 100, 252, 182, 190, 36, 238, 208, 157, 100, 55, 233, 179, 174, 208, 151, 37,
                    227, 183, 146, 82, 100, 60, 113, 185, 120, 181, 9, 30, 25, 79, 92, 46, 94, 109, 130, 71, 198, 19, 151,
                    139, 87, 155, 192, 236, 207, 192, 94, 130, 200, 113, 42, 46, 126, 20, 49, 225, 38, 157, 205, 113, 114,
                    236, 39, 51, 249, 205, 98, 50, 158, 184, 92, 188, 218, 4, 143, 140, 39, 46, 23, 175, 54, 193, 35, 227,
                    137, 203, 197, 171, 77, 16, 201, 120, 226, 114, 241, 106, 19, 60, 50, 158, 184, 92, 188, 218, 4, 143,
                    140, 39, 46, 23, 175, 54, 121, 108, 100, 252, 65, 82, 150, 140, 47, 126, 173, 18, 208, 247, 131, 57,
                    232, 100, 252, 70, 248, 156, 178, 172, 19, 239, 73, 157, 81, 218, 94, 149, 215, 5, 243, 212, 131, 4,
                    198, 83, 59, 184, 195, 204, 242, 226, 135, 94, 202, 30, 67, 89, 97, 15, 162, 169, 94, 22, 138, 118, 45,
                    93, 79, 55, 196, 64, 14, 71, 201, 113, 50, 76, 78, 146, 81, 114, 154, 156, 37, 231, 73, 51, 93, 74, 91,
                    105, 59, 237, 164, 221, 241, 77, 21, 150, 149, 254, 99, 102, 147, 23, 94, 203, 86, 245, 121, 87, 43,
                    32, 248, 132, 237, 203, 11, 175, 101, 171, 250, 188, 171, 21, 16, 188, 34, 178, 173, 94, 145, 128, 27,
                    28, 199, 102, 106, 60, 37, 64, 84, 91, 229, 147, 173, 20, 182, 200, 119, 220, 35, 196, 184, 71, 174,
                    224, 184, 71, 136, 113, 143, 92, 197, 113, 143, 16, 227, 30, 185, 134, 230, 30, 33, 142, 119, 164, 38,
                    255, 72, 101, 247, 200, 118, 58, 233, 30, 225, 173, 175, 127, 196, 113, 143, 240, 182, 38, 255, 200,
                    206, 148, 15, 141, 71, 67, 233, 236, 166, 229, 40, 29, 7, 95, 179, 62, 47, 126, 40, 23, 216, 102, 23,
                    217, 62, 120, 143, 25, 225, 197, 15, 243, 163, 187, 180, 92, 67, 112, 151, 150, 107, 136, 237, 210, 114,
                    13, 161, 93, 90, 174, 33, 178, 75, 203, 158, 107, 201, 61, 113, 255, 201, 80, 174, 253, 244, 32, 61,
                    100, 125, 177, 138, 44, 183, 148, 236, 167, 192, 184, 46, 187, 198, 172, 37, 172, 203, 46, 49, 107, 137,
                    234, 178, 43, 76, 60, 12, 96, 159, 132, 5, 108, 115, 46, 168, 171, 28, 219, 76, 142, 210, 153, 100, 115,
                    217, 152, 46, 187, 190, 172, 37, 164, 203, 46, 47, 107, 137, 232, 34, 53, 7, 116, 217, 197, 101, 45,
                    241, 92, 118, 109, 89, 75, 56, 23, 121, 140, 11, 200, 227, 180, 236, 2, 178, 224, 110, 40, 7, 125, 39,
                    104, 12, 211, 241, 91, 192, 224, 97, 238, 75, 110, 4, 127, 124, 97, 107, 186, 244, 62, 37, 247, 169,
                    78, 76, 228, 90, 94, 27, 149, 233, 193, 94, 129, 93, 207, 15, 217, 69, 45, 19, 239, 73, 157, 81, 218,
                    30, 204, 62, 187, 34, 30, 176, 203, 66, 38, 222, 147, 58, 163, 180, 61, 152, 253, 207, 40, 203, 58, 241,
                    158, 212, 25, 165, 237, 193, 236, 143, 227, 52, 181, 62, 71, 32, 252, 175, 118, 114, 150, 150, 187, 216,
                    55, 50, 178, 153, 109, 101, 219, 217, 78, 182, 155, 141, 191, 84, 63, 227, 194, 158, 213, 143, 225, 92,
                    158, 106, 51, 91, 202, 90, 89, 59, 235, 100, 221, 140, 44, 103, 189, 108, 37, 91, 205, 214, 114, 123,
                    173, 103, 69, 142, 70, 146, 243, 51, 170, 225, 50, 147, 83, 128, 253, 169, 71, 136, 231, 104, 148, 90,
                    217, 168, 97, 52, 71, 163, 212, 202, 70, 13, 163, 57, 26, 165, 86, 54, 106, 24, 102, 155, 225, 144, 205,
                    243, 192, 111, 174, 15, 178, 57, 142, 70, 169, 149, 141, 26, 246, 122, 193, 113, 28, 193, 143, 191, 136,
                    254, 35, 46, 251, 167, 54, 65, 56, 206, 15, 216, 105, 243, 130, 132, 99, 236, 91, 196, 39, 146, 80, 97,
                    152, 161, 71, 18, 22, 4, 20, 234, 240, 65, 220, 159, 252, 170, 16, 66, 188, 159, 252, 170, 16, 66, 188,
                    159, 252, 170, 16, 66, 188, 159, 252, 170, 248, 193, 197, 81, 118, 154, 157, 101, 56, 63, 249, 85, 33,
                    132, 120, 63, 249, 85, 33, 132, 120, 63, 249, 85, 33, 132, 120, 63, 249, 85, 33, 132, 120, 63, 249, 85,
                    33, 132, 120, 63, 249, 85, 33, 132, 222, 63, 249, 205, 59, 5, 84, 252, 224, 133, 105, 46, 1, 134, 243,
                    172, 188, 63, 160, 32, 160, 80, 175, 27, 209, 127, 242, 171, 66, 8, 189, 127, 242, 219, 68, 254, 11,
                    129, 238, 4, 59, 3, 69, 211, 171, 176, 212, 40, 49, 175, 16, 195, 173, 50, 134, 171, 185, 26, 218, 13,
                    104, 64, 97, 69, 151, 70, 167, 1, 123, 153, 113, 104, 71, 154, 135, 67, 173, 154, 39, 173, 219, 128,
                    122, 210, 28, 191, 20, 111, 81, 29, 83, 95, 177, 35, 230, 197, 15, 243, 163, 19, 181, 92, 29, 203, 141,
                    71, 30, 156, 168, 229, 26, 98, 19, 181, 92, 67, 104, 162, 150, 33, 88, 97, 147, 188, 234, 55, 209, 189,
                    70, 181, 200, 68, 45, 99, 97, 13, 126, 248, 229, 194, 5, 236, 66, 2, 138, 117, 180, 75, 121, 3, 251,
                    166, 64, 96, 50, 54, 27, 229, 152, 140, 113, 104, 247, 154, 135, 155, 173, 92, 172, 42, 142, 127, 141,
                    88, 247, 154, 135, 155, 109, 126, 192, 38, 166, 127, 77, 106, 101, 147, 243, 181, 213, 16, 174, 137,
                    233, 95, 147, 90, 217, 228, 124, 109, 53, 4, 107, 34, 249, 215, 182, 27, 54, 86, 179, 177, 219, 232,
                    179, 174, 12, 211, 44, 25, 170, 217, 0, 134, 106, 162, 250, 215, 38, 35, 53, 81, 253, 107, 147, 129,
                    154, 117, 248, 215, 246, 96, 159, 143, 197, 36, 171, 114, 175, 245, 51, 46, 204, 37, 89, 201, 126, 99,
                    38, 199, 90, 54, 76, 19, 213, 191, 54, 25, 165, 137, 234, 95, 155, 12, 210, 196, 245, 175, 77, 198, 104,
                    162, 250, 215, 38, 67, 52, 81, 253, 107, 147, 17, 154, 143, 211, 191, 118, 208, 40, 235, 95, 43, 190,
                    27, 74, 64, 223, 9, 230, 160, 27, 227, 183, 0, 190, 127, 109, 208, 40, 242, 175, 17, 215, 189, 166, 54,
                    193, 243, 175, 17, 215, 189, 166, 54, 193, 243, 175, 17, 215, 189, 166, 54, 193, 243, 175, 17, 215, 189,
                    166, 54, 129, 217, 127, 93, 100, 91, 189, 46, 1, 51, 230, 64, 69, 76, 30, 121, 63, 244, 86, 91, 179,
                    147, 227, 6, 108, 201, 110, 2, 40, 85, 200, 36, 222, 223, 151, 80, 33, 147, 120, 127, 95, 66, 133, 76,
                    162, 254, 125, 9, 29, 46, 249, 255, 247, 247, 37, 134, 13, 55, 128, 82, 133, 76, 226, 253, 125, 9, 21,
                    50, 89, 215, 223, 151, 56, 193, 91, 246, 105, 151, 21, 134, 235, 106, 132, 78, 152, 162, 125, 45, 156,
                    54, 202, 133, 93, 216, 239, 139, 90, 162, 46, 236, 215, 69, 45, 65, 23, 246, 219, 162, 150, 152, 11,
                    251, 101, 81, 17, 31, 83, 150, 117, 50, 42, 81, 140, 168, 7, 192, 120, 80, 211, 167, 139, 225, 69, 61,
                    248, 209, 249, 209, 20, 112, 98, 244, 236, 17, 16, 163, 82, 43, 155, 28, 73, 90, 67, 44, 5, 38, 49, 42,
                    181, 178, 201, 145, 164, 16, 52, 23, 152, 39, 198, 231, 127, 173, 176, 167, 225, 121, 196, 168, 212,
                    202, 38, 71, 146, 98, 161, 181, 80, 115, 32, 133, 63, 49, 218, 246, 155, 97, 240, 3, 94, 103, 1, 246,
                    128, 135, 233, 71, 2, 29, 121, 119, 193, 219, 157, 164, 28, 72, 222, 222, 36, 231, 177, 159, 183, 104,
                    207, 253, 203, 88, 87, 5, 254, 99, 69, 111, 161, 220, 106, 19, 245, 177, 98, 114, 177, 137, 250, 88,
                    49, 185, 214, 68, 125, 172, 152, 92, 106, 98, 62, 86, 72, 173, 108, 212, 48, 204, 118, 45, 15, 200, 10,
                    43, 88, 23, 244, 252, 231, 42, 45, 195, 177, 138, 117, 176, 230, 3, 66, 125, 36, 120, 127, 62, 204, 127,
                    251, 193, 103, 255, 63,
                };
                
                var ushorts = Blob.UInt16FromBytes(29244, 26730, compressedTable);
                return U16ParseTable.From(ushorts, 330, 31, 81);
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
            public static readonly NonterminalSymbol file = new NonterminalSymbol(31, "file", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol angrammar = new NonterminalSymbol(32, "angrammar", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_item = new NonterminalSymbol(33, "grammar_item", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_options = new NonterminalSymbol(34, "grammar_options", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol option = new NonterminalSymbol(35, "option", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_rules = new NonterminalSymbol(36, "grammar_rules", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule = new NonterminalSymbol(37, "rule", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_expression = new NonterminalSymbol(38, "rule_expression", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_alternative = new NonterminalSymbol(39, "rule_alternative", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_sequence = new NonterminalSymbol(40, "rule_sequence", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_repetition = new NonterminalSymbol(41, "rule_repetition", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_optional = new NonterminalSymbol(42, "rule_optional", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_star_closure = new NonterminalSymbol(43, "rule_star_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_plus_closure = new NonterminalSymbol(44, "rule_plus_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_tree_action = new NonterminalSymbol(45, "rule_tree_action", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_drop_element = new NonterminalSymbol(46, "rule_drop_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_promote_element = new NonterminalSymbol(47, "rule_promote_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_element = new NonterminalSymbol(48, "rule_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol sub_rule = new NonterminalSymbol(49, "sub_rule", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol rule_atom = new NonterminalSymbol(50, "rule_atom", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol reference = new NonterminalSymbol(51, "reference", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol grammar_terminals = new NonterminalSymbol(52, "grammar_terminals", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_rule = new NonterminalSymbol(53, "terminal_rule", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_expression = new NonterminalSymbol(54, "terminal_expression", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_alternative = new NonterminalSymbol(55, "terminal_alternative", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_diff = new NonterminalSymbol(56, "terminal_diff", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_sequence = new NonterminalSymbol(57, "terminal_sequence", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_repetition = new NonterminalSymbol(58, "terminal_repetition", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_optional = new NonterminalSymbol(59, "terminal_optional", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_star_closure = new NonterminalSymbol(60, "terminal_star_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_plus_closure = new NonterminalSymbol(61, "terminal_plus_closure", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_range_loop = new NonterminalSymbol(62, "terminal_range_loop", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol range = new NonterminalSymbol(63, "range", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_element = new NonterminalSymbol(64, "terminal_element", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_not = new NonterminalSymbol(65, "terminal_not", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol terminal_atom = new NonterminalSymbol(66, "terminal_atom", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol characterRange = new NonterminalSymbol(67, "characterRange", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol character = new NonterminalSymbol(68, "character", false, RepeatKind.None, LiftKind.None);
            public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(69, "__N1", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(70, "__N2", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N3 = new NonterminalSymbol(71, "__N3", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N4 = new NonterminalSymbol(72, "__N4", true, RepeatKind.None, LiftKind.Alternate);
            public static readonly NonterminalSymbol __N5 = new NonterminalSymbol(73, "__N5", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N6 = new NonterminalSymbol(74, "__N6", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N7 = new NonterminalSymbol(75, "__N7", true, RepeatKind.None, LiftKind.Alternate);
            public static readonly NonterminalSymbol __N8 = new NonterminalSymbol(76, "__N8", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N9 = new NonterminalSymbol(77, "__N9", true, RepeatKind.None, LiftKind.Alternate);
            public static readonly NonterminalSymbol __N10 = new NonterminalSymbol(78, "__N10", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N11 = new NonterminalSymbol(79, "__N11", true, RepeatKind.Star, LiftKind.Star);
            public static readonly NonterminalSymbol __N12 = new NonterminalSymbol(80, "__N12", true, RepeatKind.Optional, LiftKind.Optional);
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
            public static readonly NonterminalSymbol __acc = new NonterminalSymbol(98, "__acc", true, RepeatKind.None, LiftKind.None);
            
            public static readonly Symbol[] Symbols = 
            {
                identifier, number, any, text, ucBlock, ucCategory, ucCodepoint, __T1, __T2, __T3, __T4, __T5, __T6, __T7,
                __T8, __T9, __T10, __T11, __T12, __T13, __T14, __T15, __T16, __T17, __T18, __T19, __T20, __T21, __T22, __T23,
                __eof, file, angrammar, grammar_item, grammar_options, option, grammar_rules, rule, rule_expression, rule_alternative,
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
                new Production(option, false, "option -> ^'Start' ,'=' ^ˈidentifierˈ ,';'", false, true, false, true),
                new Production(option, false, "option -> ^'Spacing' ,'=' ^ˈidentifierˈ ,';'", false, true, false, true),
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
