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
                    0, 1, 1, 2, 3, 4, 4, 4, 4, 4, 4, 3, 3, 3, 4, 1, 5, 5, 5, 5, 5, 6, 5, 5, 7, 5, 5, 8, 5, 4, 2, 5, 4, 8,
                    8, 5, 4, 9, 9, 9, 10, 11, 11, 11, 12, 10, 13, 14, 15, 12, 12, 16, 12, 12, 12, 12, 17, 12, 12, 17, 9,
                    18, 5, 10, 13, 11, 11, 11, 11, 19, 13, 11, 20, 20, 5, 13, 9, 13, 9, 15, 15, 21, 15, 15, 15, 22, 15, 15,
                    15, 23, 24, 25, 26, 27, 23, 23, 16, 23, 23, 23, 23, 28, 23, 23, 28, 9, 18, 12, 5, 11, 11, 11, 13, 11,
                    11, 19, 19, 19, 19, 19, 19, 2, 29, 9, 13, 30, 13, 31, 30, 30, 16, 30, 30, 30, 30, 32, 30, 30, 32, 9,
                    18, 15, 12, 12, 12, 33, 12, 25, 9, 25, 9, 27, 27, 21, 27, 27, 27, 22, 27, 27, 27, 24, 23, 11, 13, 8,
                    24, 25, 29, 29, 29, 29, 34, 25, 29, 20, 13, 31, 31, 21, 31, 31, 31, 22, 31, 31, 31, 24, 30, 35, 22, 9,
                    25, 36, 25, 37, 36, 36, 16, 36, 36, 36, 36, 38, 36, 36, 38, 9, 18, 27, 23, 23, 23, 33, 23, 13, 39, 39,
                    39, 19, 29, 29, 29, 25, 29, 29, 34, 34, 34, 34, 34, 34, 2, 29, 31, 30, 30, 30, 33, 30, 15, 35, 25, 37,
                    37, 21, 37, 37, 37, 22, 37, 37, 37, 24, 36, 35, 35, 40, 39, 39, 39, 39, 41, 40, 39, 20, 29, 25, 8, 24,
                    35, 37, 36, 36, 36, 33, 36, 27, 19, 39, 39, 39, 40, 39, 39, 41, 41, 41, 41, 41, 41, 2, 29, 25, 39, 34,
                    31, 35, 39, 40, 8, 24, 35, 37, 40, 39, 41, 34, 35, 41,
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
                    /* 20 */ new Set(new Interval(94,94)),
                    /* 21 */ new Set(new Interval(62,62)),
                    /* 22 */ new Set(new Interval(39,39)),
                    /* 23 */ new Set(new Interval(40,40)),
                    /* 24 */ new Set(new Interval(46,46)),
                    /* 25 */ new Set(new Interval(65,84), new Interval(86,90), new Interval(95,95), new Interval(97,116), new Interval(118,122)),
                    /* 26 */ new Set(new Interval(85,85), new Interval(117,117)),
                    /* 27 */ new Set(new Interval(92,92)),
                    /* 28 */ new Set(new Interval(126,126)),
                    /* 29 */ new Set(new Interval(0,38), new Interval(40,91), new Interval(93,1114111)),
                    /* 30 */ new Set(new Interval(39,39), new Interval(48,48), new Interval(92,92), new Interval(97,98), new Interval(102,102), new Interval(110,110), new Interval(114,114), new Interval(116,116), new Interval(118,118)),
                    /* 31 */ new Set(new Interval(48,57), new Interval(65,70), new Interval(97,102)),
                    /* 32 */ new Set(new Interval(43,43)),
                    /* 33 */ new Set(new Interval(98,98)),
                    /* 34 */ new Set(new Interval(99,99)),
                    /* 35 */ new Set(new Interval(65,90), new Interval(97,122)),
                    /* 36 */ new Set(new Interval(32,32), new Interval(45,45), new Interval(95,95)),
                    /* 37 */ new Set(new Interval(48,57), new Interval(65,90), new Interval(97,122)),
                    /* 38 */ new Set(new Interval(59,59)),
                    /* 39 */ new Set(new Interval(44,44)),
                    /* 40 */ new Set(new Interval(124,124)),
                    /* 41 */ new Set(new Interval(42,42)),
                    /* 42 */ new Set(new Interval(63,63)),
                    /* 43 */ new Set(new Interval(48,48)),
                    /* 44 */ new Set(new Interval(49,57)),
                    /* 45 */ new Set(new Interval(48,57)),
                    /* 46 */ new Set(new Interval(41,41)),
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
                
                /* dfa  7 -- '->' | ':' | '^' -- */
                var states7 = new DfaState[5] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,27), new DfaState(3,true,26), new DfaState(4,true,14)};
                states7[0].Transitions = new DfaTrans[3] {new DfaTrans(states7[1], sets[18]), new DfaTrans(states7[3], sets[19]), new DfaTrans(states7[4], sets[20])};
                states7[1].Transitions = new DfaTrans[1] {new DfaTrans(states7[2], sets[21])};
                states7[2].Transitions = new DfaTrans[0] {};
                states7[3].Transitions = new DfaTrans[0] {};
                states7[4].Transitions = new DfaTrans[0] {};
                
                /* dfa  8 -- '->' | ':' -- */
                var states8 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,27), new DfaState(3,true,26)};
                states8[0].Transitions = new DfaTrans[2] {new DfaTrans(states8[1], sets[18]), new DfaTrans(states8[3], sets[19])};
                states8[1].Transitions = new DfaTrans[1] {new DfaTrans(states8[2], sets[21])};
                states8[2].Transitions = new DfaTrans[0] {};
                states8[3].Transitions = new DfaTrans[0] {};
                
                /* dfa  9 -- ˈtextˈ | '(' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '~' -- */
                var states9 = new DfaState[44] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,2), new DfaState(15,true,0), new DfaState(16,true,0), new DfaState(17,false,-1), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,true,4), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,5), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,true,24)};
                states9[0].Transitions = new DfaTrans[7] {new DfaTrans(states9[1], sets[22]), new DfaTrans(states9[13], sets[23]), new DfaTrans(states9[14], sets[24]), new DfaTrans(states9[15], sets[25]), new DfaTrans(states9[16], sets[26]), new DfaTrans(states9[24], sets[27]), new DfaTrans(states9[43], sets[28])};
                states9[1].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[29]), new DfaTrans(states9[4], sets[27])};
                states9[2].Transitions = new DfaTrans[3] {new DfaTrans(states9[2], sets[29]), new DfaTrans(states9[3], sets[22]), new DfaTrans(states9[4], sets[27])};
                states9[3].Transitions = new DfaTrans[0] {};
                states9[4].Transitions = new DfaTrans[2] {new DfaTrans(states9[2], sets[30]), new DfaTrans(states9[5], sets[14])};
                states9[5].Transitions = new DfaTrans[1] {new DfaTrans(states9[6], sets[6])};
                states9[6].Transitions = new DfaTrans[1] {new DfaTrans(states9[7], sets[31])};
                states9[7].Transitions = new DfaTrans[2] {new DfaTrans(states9[8], sets[31]), new DfaTrans(states9[2], sets[9])};
                states9[8].Transitions = new DfaTrans[2] {new DfaTrans(states9[9], sets[31]), new DfaTrans(states9[2], sets[9])};
                states9[9].Transitions = new DfaTrans[2] {new DfaTrans(states9[10], sets[31]), new DfaTrans(states9[2], sets[9])};
                states9[10].Transitions = new DfaTrans[2] {new DfaTrans(states9[11], sets[31]), new DfaTrans(states9[2], sets[9])};
                states9[11].Transitions = new DfaTrans[2] {new DfaTrans(states9[12], sets[31]), new DfaTrans(states9[2], sets[9])};
                states9[12].Transitions = new DfaTrans[1] {new DfaTrans(states9[2], sets[9])};
                states9[13].Transitions = new DfaTrans[0] {};
                states9[14].Transitions = new DfaTrans[0] {};
                states9[15].Transitions = new DfaTrans[1] {new DfaTrans(states9[15], sets[5])};
                states9[16].Transitions = new DfaTrans[2] {new DfaTrans(states9[17], sets[32]), new DfaTrans(states9[15], sets[5])};
                states9[17].Transitions = new DfaTrans[1] {new DfaTrans(states9[18], sets[31])};
                states9[18].Transitions = new DfaTrans[1] {new DfaTrans(states9[19], sets[31])};
                states9[19].Transitions = new DfaTrans[1] {new DfaTrans(states9[20], sets[31])};
                states9[20].Transitions = new DfaTrans[1] {new DfaTrans(states9[21], sets[31])};
                states9[21].Transitions = new DfaTrans[1] {new DfaTrans(states9[22], sets[31])};
                states9[22].Transitions = new DfaTrans[1] {new DfaTrans(states9[23], sets[31])};
                states9[23].Transitions = new DfaTrans[0] {};
                states9[24].Transitions = new DfaTrans[1] {new DfaTrans(states9[25], sets[14])};
                states9[25].Transitions = new DfaTrans[3] {new DfaTrans(states9[26], sets[33]), new DfaTrans(states9[31], sets[34]), new DfaTrans(states9[36], sets[6])};
                states9[26].Transitions = new DfaTrans[1] {new DfaTrans(states9[27], sets[6])};
                states9[27].Transitions = new DfaTrans[1] {new DfaTrans(states9[28], sets[35])};
                states9[28].Transitions = new DfaTrans[3] {new DfaTrans(states9[29], sets[36]), new DfaTrans(states9[28], sets[37]), new DfaTrans(states9[30], sets[9])};
                states9[29].Transitions = new DfaTrans[2] {new DfaTrans(states9[29], sets[36]), new DfaTrans(states9[28], sets[37])};
                states9[30].Transitions = new DfaTrans[0] {};
                states9[31].Transitions = new DfaTrans[1] {new DfaTrans(states9[32], sets[6])};
                states9[32].Transitions = new DfaTrans[1] {new DfaTrans(states9[33], sets[35])};
                states9[33].Transitions = new DfaTrans[3] {new DfaTrans(states9[34], sets[36]), new DfaTrans(states9[33], sets[37]), new DfaTrans(states9[35], sets[9])};
                states9[34].Transitions = new DfaTrans[2] {new DfaTrans(states9[34], sets[36]), new DfaTrans(states9[33], sets[37])};
                states9[35].Transitions = new DfaTrans[0] {};
                states9[36].Transitions = new DfaTrans[1] {new DfaTrans(states9[37], sets[31])};
                states9[37].Transitions = new DfaTrans[2] {new DfaTrans(states9[38], sets[31]), new DfaTrans(states9[23], sets[9])};
                states9[38].Transitions = new DfaTrans[2] {new DfaTrans(states9[39], sets[31]), new DfaTrans(states9[23], sets[9])};
                states9[39].Transitions = new DfaTrans[2] {new DfaTrans(states9[40], sets[31]), new DfaTrans(states9[23], sets[9])};
                states9[40].Transitions = new DfaTrans[2] {new DfaTrans(states9[41], sets[31]), new DfaTrans(states9[23], sets[9])};
                states9[41].Transitions = new DfaTrans[2] {new DfaTrans(states9[42], sets[31]), new DfaTrans(states9[23], sets[9])};
                states9[42].Transitions = new DfaTrans[1] {new DfaTrans(states9[23], sets[9])};
                states9[43].Transitions = new DfaTrans[0] {};
                
                /* dfa 10 -- ';' -- */
                var states10 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,12)};
                states10[0].Transitions = new DfaTrans[1] {new DfaTrans(states10[1], sets[38])};
                states10[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 11 -- ˈtextˈ | '(' | ',' | ';' | ˈidentifierˈ | '{' | '|' -- */
                var states11 = new DfaState[19] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,19), new DfaState(15,true,12), new DfaState(16,true,0), new DfaState(17,true,8), new DfaState(18,true,15)};
                states11[0].Transitions = new DfaTrans[7] {new DfaTrans(states11[1], sets[22]), new DfaTrans(states11[13], sets[23]), new DfaTrans(states11[14], sets[39]), new DfaTrans(states11[15], sets[38]), new DfaTrans(states11[16], sets[4]), new DfaTrans(states11[17], sets[6]), new DfaTrans(states11[18], sets[40])};
                states11[1].Transitions = new DfaTrans[2] {new DfaTrans(states11[2], sets[29]), new DfaTrans(states11[4], sets[27])};
                states11[2].Transitions = new DfaTrans[3] {new DfaTrans(states11[2], sets[29]), new DfaTrans(states11[3], sets[22]), new DfaTrans(states11[4], sets[27])};
                states11[3].Transitions = new DfaTrans[0] {};
                states11[4].Transitions = new DfaTrans[2] {new DfaTrans(states11[2], sets[30]), new DfaTrans(states11[5], sets[14])};
                states11[5].Transitions = new DfaTrans[1] {new DfaTrans(states11[6], sets[6])};
                states11[6].Transitions = new DfaTrans[1] {new DfaTrans(states11[7], sets[31])};
                states11[7].Transitions = new DfaTrans[2] {new DfaTrans(states11[8], sets[31]), new DfaTrans(states11[2], sets[9])};
                states11[8].Transitions = new DfaTrans[2] {new DfaTrans(states11[9], sets[31]), new DfaTrans(states11[2], sets[9])};
                states11[9].Transitions = new DfaTrans[2] {new DfaTrans(states11[10], sets[31]), new DfaTrans(states11[2], sets[9])};
                states11[10].Transitions = new DfaTrans[2] {new DfaTrans(states11[11], sets[31]), new DfaTrans(states11[2], sets[9])};
                states11[11].Transitions = new DfaTrans[2] {new DfaTrans(states11[12], sets[31]), new DfaTrans(states11[2], sets[9])};
                states11[12].Transitions = new DfaTrans[1] {new DfaTrans(states11[2], sets[9])};
                states11[13].Transitions = new DfaTrans[0] {};
                states11[14].Transitions = new DfaTrans[0] {};
                states11[15].Transitions = new DfaTrans[0] {};
                states11[16].Transitions = new DfaTrans[1] {new DfaTrans(states11[16], sets[5])};
                states11[17].Transitions = new DfaTrans[0] {};
                states11[18].Transitions = new DfaTrans[0] {};
                
                /* dfa 12 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states12 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,17), new DfaState(15,true,18), new DfaState(16,true,23), new DfaState(17,true,2), new DfaState(18,true,12), new DfaState(19,true,16), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,15), new DfaState(50,true,24)};
                states12[0].Transitions = new DfaTrans[14] {new DfaTrans(states12[1], sets[22]), new DfaTrans(states12[13], sets[23]), new DfaTrans(states12[14], sets[41]), new DfaTrans(states12[15], sets[32]), new DfaTrans(states12[16], sets[18]), new DfaTrans(states12[17], sets[24]), new DfaTrans(states12[18], sets[38]), new DfaTrans(states12[19], sets[42]), new DfaTrans(states12[20], sets[25]), new DfaTrans(states12[21], sets[26]), new DfaTrans(states12[29], sets[27]), new DfaTrans(states12[48], sets[6]), new DfaTrans(states12[49], sets[40]), new DfaTrans(states12[50], sets[28])};
                states12[1].Transitions = new DfaTrans[2] {new DfaTrans(states12[2], sets[29]), new DfaTrans(states12[4], sets[27])};
                states12[2].Transitions = new DfaTrans[3] {new DfaTrans(states12[2], sets[29]), new DfaTrans(states12[3], sets[22]), new DfaTrans(states12[4], sets[27])};
                states12[3].Transitions = new DfaTrans[0] {};
                states12[4].Transitions = new DfaTrans[2] {new DfaTrans(states12[2], sets[30]), new DfaTrans(states12[5], sets[14])};
                states12[5].Transitions = new DfaTrans[1] {new DfaTrans(states12[6], sets[6])};
                states12[6].Transitions = new DfaTrans[1] {new DfaTrans(states12[7], sets[31])};
                states12[7].Transitions = new DfaTrans[2] {new DfaTrans(states12[8], sets[31]), new DfaTrans(states12[2], sets[9])};
                states12[8].Transitions = new DfaTrans[2] {new DfaTrans(states12[9], sets[31]), new DfaTrans(states12[2], sets[9])};
                states12[9].Transitions = new DfaTrans[2] {new DfaTrans(states12[10], sets[31]), new DfaTrans(states12[2], sets[9])};
                states12[10].Transitions = new DfaTrans[2] {new DfaTrans(states12[11], sets[31]), new DfaTrans(states12[2], sets[9])};
                states12[11].Transitions = new DfaTrans[2] {new DfaTrans(states12[12], sets[31]), new DfaTrans(states12[2], sets[9])};
                states12[12].Transitions = new DfaTrans[1] {new DfaTrans(states12[2], sets[9])};
                states12[13].Transitions = new DfaTrans[0] {};
                states12[14].Transitions = new DfaTrans[0] {};
                states12[15].Transitions = new DfaTrans[0] {};
                states12[16].Transitions = new DfaTrans[0] {};
                states12[17].Transitions = new DfaTrans[0] {};
                states12[18].Transitions = new DfaTrans[0] {};
                states12[19].Transitions = new DfaTrans[0] {};
                states12[20].Transitions = new DfaTrans[1] {new DfaTrans(states12[20], sets[5])};
                states12[21].Transitions = new DfaTrans[2] {new DfaTrans(states12[22], sets[32]), new DfaTrans(states12[20], sets[5])};
                states12[22].Transitions = new DfaTrans[1] {new DfaTrans(states12[23], sets[31])};
                states12[23].Transitions = new DfaTrans[1] {new DfaTrans(states12[24], sets[31])};
                states12[24].Transitions = new DfaTrans[1] {new DfaTrans(states12[25], sets[31])};
                states12[25].Transitions = new DfaTrans[1] {new DfaTrans(states12[26], sets[31])};
                states12[26].Transitions = new DfaTrans[1] {new DfaTrans(states12[27], sets[31])};
                states12[27].Transitions = new DfaTrans[1] {new DfaTrans(states12[28], sets[31])};
                states12[28].Transitions = new DfaTrans[0] {};
                states12[29].Transitions = new DfaTrans[1] {new DfaTrans(states12[30], sets[14])};
                states12[30].Transitions = new DfaTrans[3] {new DfaTrans(states12[31], sets[33]), new DfaTrans(states12[36], sets[34]), new DfaTrans(states12[41], sets[6])};
                states12[31].Transitions = new DfaTrans[1] {new DfaTrans(states12[32], sets[6])};
                states12[32].Transitions = new DfaTrans[1] {new DfaTrans(states12[33], sets[35])};
                states12[33].Transitions = new DfaTrans[3] {new DfaTrans(states12[34], sets[36]), new DfaTrans(states12[33], sets[37]), new DfaTrans(states12[35], sets[9])};
                states12[34].Transitions = new DfaTrans[2] {new DfaTrans(states12[34], sets[36]), new DfaTrans(states12[33], sets[37])};
                states12[35].Transitions = new DfaTrans[0] {};
                states12[36].Transitions = new DfaTrans[1] {new DfaTrans(states12[37], sets[6])};
                states12[37].Transitions = new DfaTrans[1] {new DfaTrans(states12[38], sets[35])};
                states12[38].Transitions = new DfaTrans[3] {new DfaTrans(states12[39], sets[36]), new DfaTrans(states12[38], sets[37]), new DfaTrans(states12[40], sets[9])};
                states12[39].Transitions = new DfaTrans[2] {new DfaTrans(states12[39], sets[36]), new DfaTrans(states12[38], sets[37])};
                states12[40].Transitions = new DfaTrans[0] {};
                states12[41].Transitions = new DfaTrans[1] {new DfaTrans(states12[42], sets[31])};
                states12[42].Transitions = new DfaTrans[2] {new DfaTrans(states12[43], sets[31]), new DfaTrans(states12[28], sets[9])};
                states12[43].Transitions = new DfaTrans[2] {new DfaTrans(states12[44], sets[31]), new DfaTrans(states12[28], sets[9])};
                states12[44].Transitions = new DfaTrans[2] {new DfaTrans(states12[45], sets[31]), new DfaTrans(states12[28], sets[9])};
                states12[45].Transitions = new DfaTrans[2] {new DfaTrans(states12[46], sets[31]), new DfaTrans(states12[28], sets[9])};
                states12[46].Transitions = new DfaTrans[2] {new DfaTrans(states12[47], sets[31]), new DfaTrans(states12[28], sets[9])};
                states12[47].Transitions = new DfaTrans[1] {new DfaTrans(states12[28], sets[9])};
                states12[48].Transitions = new DfaTrans[0] {};
                states12[49].Transitions = new DfaTrans[0] {};
                states12[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 13 -- ';' | '|' -- */
                var states13 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,12), new DfaState(2,true,15)};
                states13[0].Transitions = new DfaTrans[2] {new DfaTrans(states13[1], sets[38]), new DfaTrans(states13[2], sets[40])};
                states13[1].Transitions = new DfaTrans[0] {};
                states13[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 14 -- '-' | ';' | '|' -- */
                var states14 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,23), new DfaState(2,true,12), new DfaState(3,true,15)};
                states14[0].Transitions = new DfaTrans[3] {new DfaTrans(states14[1], sets[18]), new DfaTrans(states14[2], sets[38]), new DfaTrans(states14[3], sets[40])};
                states14[1].Transitions = new DfaTrans[0] {};
                states14[2].Transitions = new DfaTrans[0] {};
                states14[3].Transitions = new DfaTrans[0] {};
                
                /* dfa 15 -- ˈtextˈ | '(' | '-' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states15 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,23), new DfaState(15,true,2), new DfaState(16,true,12), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,15), new DfaState(46,true,24)};
                states15[0].Transitions = new DfaTrans[10] {new DfaTrans(states15[1], sets[22]), new DfaTrans(states15[13], sets[23]), new DfaTrans(states15[14], sets[18]), new DfaTrans(states15[15], sets[24]), new DfaTrans(states15[16], sets[38]), new DfaTrans(states15[17], sets[25]), new DfaTrans(states15[18], sets[26]), new DfaTrans(states15[26], sets[27]), new DfaTrans(states15[45], sets[40]), new DfaTrans(states15[46], sets[28])};
                states15[1].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[29]), new DfaTrans(states15[4], sets[27])};
                states15[2].Transitions = new DfaTrans[3] {new DfaTrans(states15[2], sets[29]), new DfaTrans(states15[3], sets[22]), new DfaTrans(states15[4], sets[27])};
                states15[3].Transitions = new DfaTrans[0] {};
                states15[4].Transitions = new DfaTrans[2] {new DfaTrans(states15[2], sets[30]), new DfaTrans(states15[5], sets[14])};
                states15[5].Transitions = new DfaTrans[1] {new DfaTrans(states15[6], sets[6])};
                states15[6].Transitions = new DfaTrans[1] {new DfaTrans(states15[7], sets[31])};
                states15[7].Transitions = new DfaTrans[2] {new DfaTrans(states15[8], sets[31]), new DfaTrans(states15[2], sets[9])};
                states15[8].Transitions = new DfaTrans[2] {new DfaTrans(states15[9], sets[31]), new DfaTrans(states15[2], sets[9])};
                states15[9].Transitions = new DfaTrans[2] {new DfaTrans(states15[10], sets[31]), new DfaTrans(states15[2], sets[9])};
                states15[10].Transitions = new DfaTrans[2] {new DfaTrans(states15[11], sets[31]), new DfaTrans(states15[2], sets[9])};
                states15[11].Transitions = new DfaTrans[2] {new DfaTrans(states15[12], sets[31]), new DfaTrans(states15[2], sets[9])};
                states15[12].Transitions = new DfaTrans[1] {new DfaTrans(states15[2], sets[9])};
                states15[13].Transitions = new DfaTrans[0] {};
                states15[14].Transitions = new DfaTrans[0] {};
                states15[15].Transitions = new DfaTrans[0] {};
                states15[16].Transitions = new DfaTrans[0] {};
                states15[17].Transitions = new DfaTrans[1] {new DfaTrans(states15[17], sets[5])};
                states15[18].Transitions = new DfaTrans[2] {new DfaTrans(states15[19], sets[32]), new DfaTrans(states15[17], sets[5])};
                states15[19].Transitions = new DfaTrans[1] {new DfaTrans(states15[20], sets[31])};
                states15[20].Transitions = new DfaTrans[1] {new DfaTrans(states15[21], sets[31])};
                states15[21].Transitions = new DfaTrans[1] {new DfaTrans(states15[22], sets[31])};
                states15[22].Transitions = new DfaTrans[1] {new DfaTrans(states15[23], sets[31])};
                states15[23].Transitions = new DfaTrans[1] {new DfaTrans(states15[24], sets[31])};
                states15[24].Transitions = new DfaTrans[1] {new DfaTrans(states15[25], sets[31])};
                states15[25].Transitions = new DfaTrans[0] {};
                states15[26].Transitions = new DfaTrans[1] {new DfaTrans(states15[27], sets[14])};
                states15[27].Transitions = new DfaTrans[3] {new DfaTrans(states15[28], sets[33]), new DfaTrans(states15[33], sets[34]), new DfaTrans(states15[38], sets[6])};
                states15[28].Transitions = new DfaTrans[1] {new DfaTrans(states15[29], sets[6])};
                states15[29].Transitions = new DfaTrans[1] {new DfaTrans(states15[30], sets[35])};
                states15[30].Transitions = new DfaTrans[3] {new DfaTrans(states15[31], sets[36]), new DfaTrans(states15[30], sets[37]), new DfaTrans(states15[32], sets[9])};
                states15[31].Transitions = new DfaTrans[2] {new DfaTrans(states15[31], sets[36]), new DfaTrans(states15[30], sets[37])};
                states15[32].Transitions = new DfaTrans[0] {};
                states15[33].Transitions = new DfaTrans[1] {new DfaTrans(states15[34], sets[6])};
                states15[34].Transitions = new DfaTrans[1] {new DfaTrans(states15[35], sets[35])};
                states15[35].Transitions = new DfaTrans[3] {new DfaTrans(states15[36], sets[36]), new DfaTrans(states15[35], sets[37]), new DfaTrans(states15[37], sets[9])};
                states15[36].Transitions = new DfaTrans[2] {new DfaTrans(states15[36], sets[36]), new DfaTrans(states15[35], sets[37])};
                states15[37].Transitions = new DfaTrans[0] {};
                states15[38].Transitions = new DfaTrans[1] {new DfaTrans(states15[39], sets[31])};
                states15[39].Transitions = new DfaTrans[2] {new DfaTrans(states15[40], sets[31]), new DfaTrans(states15[25], sets[9])};
                states15[40].Transitions = new DfaTrans[2] {new DfaTrans(states15[41], sets[31]), new DfaTrans(states15[25], sets[9])};
                states15[41].Transitions = new DfaTrans[2] {new DfaTrans(states15[42], sets[31]), new DfaTrans(states15[25], sets[9])};
                states15[42].Transitions = new DfaTrans[2] {new DfaTrans(states15[43], sets[31]), new DfaTrans(states15[25], sets[9])};
                states15[43].Transitions = new DfaTrans[2] {new DfaTrans(states15[44], sets[31]), new DfaTrans(states15[25], sets[9])};
                states15[44].Transitions = new DfaTrans[1] {new DfaTrans(states15[25], sets[9])};
                states15[45].Transitions = new DfaTrans[0] {};
                states15[46].Transitions = new DfaTrans[0] {};
                
                /* dfa 16 -- '..' -- */
                var states16 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,true,25)};
                states16[0].Transitions = new DfaTrans[1] {new DfaTrans(states16[1], sets[24])};
                states16[1].Transitions = new DfaTrans[1] {new DfaTrans(states16[2], sets[24])};
                states16[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 17 -- ˈtextˈ | '(' | '*' | '+' | '-' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states17 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,17), new DfaState(15,true,18), new DfaState(16,true,23), new DfaState(17,true,2), new DfaState(18,true,25), new DfaState(19,true,12), new DfaState(20,true,16), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,15), new DfaState(51,true,24)};
                states17[0].Transitions = new DfaTrans[14] {new DfaTrans(states17[1], sets[22]), new DfaTrans(states17[13], sets[23]), new DfaTrans(states17[14], sets[41]), new DfaTrans(states17[15], sets[32]), new DfaTrans(states17[16], sets[18]), new DfaTrans(states17[17], sets[24]), new DfaTrans(states17[19], sets[38]), new DfaTrans(states17[20], sets[42]), new DfaTrans(states17[21], sets[25]), new DfaTrans(states17[22], sets[26]), new DfaTrans(states17[30], sets[27]), new DfaTrans(states17[49], sets[6]), new DfaTrans(states17[50], sets[40]), new DfaTrans(states17[51], sets[28])};
                states17[1].Transitions = new DfaTrans[2] {new DfaTrans(states17[2], sets[29]), new DfaTrans(states17[4], sets[27])};
                states17[2].Transitions = new DfaTrans[3] {new DfaTrans(states17[2], sets[29]), new DfaTrans(states17[3], sets[22]), new DfaTrans(states17[4], sets[27])};
                states17[3].Transitions = new DfaTrans[0] {};
                states17[4].Transitions = new DfaTrans[2] {new DfaTrans(states17[2], sets[30]), new DfaTrans(states17[5], sets[14])};
                states17[5].Transitions = new DfaTrans[1] {new DfaTrans(states17[6], sets[6])};
                states17[6].Transitions = new DfaTrans[1] {new DfaTrans(states17[7], sets[31])};
                states17[7].Transitions = new DfaTrans[2] {new DfaTrans(states17[8], sets[31]), new DfaTrans(states17[2], sets[9])};
                states17[8].Transitions = new DfaTrans[2] {new DfaTrans(states17[9], sets[31]), new DfaTrans(states17[2], sets[9])};
                states17[9].Transitions = new DfaTrans[2] {new DfaTrans(states17[10], sets[31]), new DfaTrans(states17[2], sets[9])};
                states17[10].Transitions = new DfaTrans[2] {new DfaTrans(states17[11], sets[31]), new DfaTrans(states17[2], sets[9])};
                states17[11].Transitions = new DfaTrans[2] {new DfaTrans(states17[12], sets[31]), new DfaTrans(states17[2], sets[9])};
                states17[12].Transitions = new DfaTrans[1] {new DfaTrans(states17[2], sets[9])};
                states17[13].Transitions = new DfaTrans[0] {};
                states17[14].Transitions = new DfaTrans[0] {};
                states17[15].Transitions = new DfaTrans[0] {};
                states17[16].Transitions = new DfaTrans[0] {};
                states17[17].Transitions = new DfaTrans[1] {new DfaTrans(states17[18], sets[24])};
                states17[18].Transitions = new DfaTrans[0] {};
                states17[19].Transitions = new DfaTrans[0] {};
                states17[20].Transitions = new DfaTrans[0] {};
                states17[21].Transitions = new DfaTrans[1] {new DfaTrans(states17[21], sets[5])};
                states17[22].Transitions = new DfaTrans[2] {new DfaTrans(states17[23], sets[32]), new DfaTrans(states17[21], sets[5])};
                states17[23].Transitions = new DfaTrans[1] {new DfaTrans(states17[24], sets[31])};
                states17[24].Transitions = new DfaTrans[1] {new DfaTrans(states17[25], sets[31])};
                states17[25].Transitions = new DfaTrans[1] {new DfaTrans(states17[26], sets[31])};
                states17[26].Transitions = new DfaTrans[1] {new DfaTrans(states17[27], sets[31])};
                states17[27].Transitions = new DfaTrans[1] {new DfaTrans(states17[28], sets[31])};
                states17[28].Transitions = new DfaTrans[1] {new DfaTrans(states17[29], sets[31])};
                states17[29].Transitions = new DfaTrans[0] {};
                states17[30].Transitions = new DfaTrans[1] {new DfaTrans(states17[31], sets[14])};
                states17[31].Transitions = new DfaTrans[3] {new DfaTrans(states17[32], sets[33]), new DfaTrans(states17[37], sets[34]), new DfaTrans(states17[42], sets[6])};
                states17[32].Transitions = new DfaTrans[1] {new DfaTrans(states17[33], sets[6])};
                states17[33].Transitions = new DfaTrans[1] {new DfaTrans(states17[34], sets[35])};
                states17[34].Transitions = new DfaTrans[3] {new DfaTrans(states17[35], sets[36]), new DfaTrans(states17[34], sets[37]), new DfaTrans(states17[36], sets[9])};
                states17[35].Transitions = new DfaTrans[2] {new DfaTrans(states17[35], sets[36]), new DfaTrans(states17[34], sets[37])};
                states17[36].Transitions = new DfaTrans[0] {};
                states17[37].Transitions = new DfaTrans[1] {new DfaTrans(states17[38], sets[6])};
                states17[38].Transitions = new DfaTrans[1] {new DfaTrans(states17[39], sets[35])};
                states17[39].Transitions = new DfaTrans[3] {new DfaTrans(states17[40], sets[36]), new DfaTrans(states17[39], sets[37]), new DfaTrans(states17[41], sets[9])};
                states17[40].Transitions = new DfaTrans[2] {new DfaTrans(states17[40], sets[36]), new DfaTrans(states17[39], sets[37])};
                states17[41].Transitions = new DfaTrans[0] {};
                states17[42].Transitions = new DfaTrans[1] {new DfaTrans(states17[43], sets[31])};
                states17[43].Transitions = new DfaTrans[2] {new DfaTrans(states17[44], sets[31]), new DfaTrans(states17[29], sets[9])};
                states17[44].Transitions = new DfaTrans[2] {new DfaTrans(states17[45], sets[31]), new DfaTrans(states17[29], sets[9])};
                states17[45].Transitions = new DfaTrans[2] {new DfaTrans(states17[46], sets[31]), new DfaTrans(states17[29], sets[9])};
                states17[46].Transitions = new DfaTrans[2] {new DfaTrans(states17[47], sets[31]), new DfaTrans(states17[29], sets[9])};
                states17[47].Transitions = new DfaTrans[2] {new DfaTrans(states17[48], sets[31]), new DfaTrans(states17[29], sets[9])};
                states17[48].Transitions = new DfaTrans[1] {new DfaTrans(states17[29], sets[9])};
                states17[49].Transitions = new DfaTrans[0] {};
                states17[50].Transitions = new DfaTrans[0] {};
                states17[51].Transitions = new DfaTrans[0] {};
                
                /* dfa 18 -- ˈtextˈ | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ -- */
                var states18 = new DfaState[42] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,2), new DfaState(14,true,0), new DfaState(15,true,0), new DfaState(16,false,-1), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,true,4), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,5), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1)};
                states18[0].Transitions = new DfaTrans[5] {new DfaTrans(states18[1], sets[22]), new DfaTrans(states18[13], sets[24]), new DfaTrans(states18[14], sets[25]), new DfaTrans(states18[15], sets[26]), new DfaTrans(states18[23], sets[27])};
                states18[1].Transitions = new DfaTrans[2] {new DfaTrans(states18[2], sets[29]), new DfaTrans(states18[4], sets[27])};
                states18[2].Transitions = new DfaTrans[3] {new DfaTrans(states18[2], sets[29]), new DfaTrans(states18[3], sets[22]), new DfaTrans(states18[4], sets[27])};
                states18[3].Transitions = new DfaTrans[0] {};
                states18[4].Transitions = new DfaTrans[2] {new DfaTrans(states18[2], sets[30]), new DfaTrans(states18[5], sets[14])};
                states18[5].Transitions = new DfaTrans[1] {new DfaTrans(states18[6], sets[6])};
                states18[6].Transitions = new DfaTrans[1] {new DfaTrans(states18[7], sets[31])};
                states18[7].Transitions = new DfaTrans[2] {new DfaTrans(states18[8], sets[31]), new DfaTrans(states18[2], sets[9])};
                states18[8].Transitions = new DfaTrans[2] {new DfaTrans(states18[9], sets[31]), new DfaTrans(states18[2], sets[9])};
                states18[9].Transitions = new DfaTrans[2] {new DfaTrans(states18[10], sets[31]), new DfaTrans(states18[2], sets[9])};
                states18[10].Transitions = new DfaTrans[2] {new DfaTrans(states18[11], sets[31]), new DfaTrans(states18[2], sets[9])};
                states18[11].Transitions = new DfaTrans[2] {new DfaTrans(states18[12], sets[31]), new DfaTrans(states18[2], sets[9])};
                states18[12].Transitions = new DfaTrans[1] {new DfaTrans(states18[2], sets[9])};
                states18[13].Transitions = new DfaTrans[0] {};
                states18[14].Transitions = new DfaTrans[1] {new DfaTrans(states18[14], sets[5])};
                states18[15].Transitions = new DfaTrans[2] {new DfaTrans(states18[16], sets[32]), new DfaTrans(states18[14], sets[5])};
                states18[16].Transitions = new DfaTrans[1] {new DfaTrans(states18[17], sets[31])};
                states18[17].Transitions = new DfaTrans[1] {new DfaTrans(states18[18], sets[31])};
                states18[18].Transitions = new DfaTrans[1] {new DfaTrans(states18[19], sets[31])};
                states18[19].Transitions = new DfaTrans[1] {new DfaTrans(states18[20], sets[31])};
                states18[20].Transitions = new DfaTrans[1] {new DfaTrans(states18[21], sets[31])};
                states18[21].Transitions = new DfaTrans[1] {new DfaTrans(states18[22], sets[31])};
                states18[22].Transitions = new DfaTrans[0] {};
                states18[23].Transitions = new DfaTrans[1] {new DfaTrans(states18[24], sets[14])};
                states18[24].Transitions = new DfaTrans[3] {new DfaTrans(states18[25], sets[33]), new DfaTrans(states18[30], sets[34]), new DfaTrans(states18[35], sets[6])};
                states18[25].Transitions = new DfaTrans[1] {new DfaTrans(states18[26], sets[6])};
                states18[26].Transitions = new DfaTrans[1] {new DfaTrans(states18[27], sets[35])};
                states18[27].Transitions = new DfaTrans[3] {new DfaTrans(states18[28], sets[36]), new DfaTrans(states18[27], sets[37]), new DfaTrans(states18[29], sets[9])};
                states18[28].Transitions = new DfaTrans[2] {new DfaTrans(states18[28], sets[36]), new DfaTrans(states18[27], sets[37])};
                states18[29].Transitions = new DfaTrans[0] {};
                states18[30].Transitions = new DfaTrans[1] {new DfaTrans(states18[31], sets[6])};
                states18[31].Transitions = new DfaTrans[1] {new DfaTrans(states18[32], sets[35])};
                states18[32].Transitions = new DfaTrans[3] {new DfaTrans(states18[33], sets[36]), new DfaTrans(states18[32], sets[37]), new DfaTrans(states18[34], sets[9])};
                states18[33].Transitions = new DfaTrans[2] {new DfaTrans(states18[33], sets[36]), new DfaTrans(states18[32], sets[37])};
                states18[34].Transitions = new DfaTrans[0] {};
                states18[35].Transitions = new DfaTrans[1] {new DfaTrans(states18[36], sets[31])};
                states18[36].Transitions = new DfaTrans[2] {new DfaTrans(states18[37], sets[31]), new DfaTrans(states18[22], sets[9])};
                states18[37].Transitions = new DfaTrans[2] {new DfaTrans(states18[38], sets[31]), new DfaTrans(states18[22], sets[9])};
                states18[38].Transitions = new DfaTrans[2] {new DfaTrans(states18[39], sets[31]), new DfaTrans(states18[22], sets[9])};
                states18[39].Transitions = new DfaTrans[2] {new DfaTrans(states18[40], sets[31]), new DfaTrans(states18[22], sets[9])};
                states18[40].Transitions = new DfaTrans[2] {new DfaTrans(states18[41], sets[31]), new DfaTrans(states18[22], sets[9])};
                states18[41].Transitions = new DfaTrans[1] {new DfaTrans(states18[22], sets[9])};
                
                /* dfa 19 -- ˈtextˈ | '(' | '*' | '+' | ',' | ';' | '?' | ˈidentifierˈ | '{' | '|' -- */
                var states19 = new DfaState[22] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,17), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,12), new DfaState(18,true,16), new DfaState(19,true,0), new DfaState(20,true,8), new DfaState(21,true,15)};
                states19[0].Transitions = new DfaTrans[10] {new DfaTrans(states19[1], sets[22]), new DfaTrans(states19[13], sets[23]), new DfaTrans(states19[14], sets[41]), new DfaTrans(states19[15], sets[32]), new DfaTrans(states19[16], sets[39]), new DfaTrans(states19[17], sets[38]), new DfaTrans(states19[18], sets[42]), new DfaTrans(states19[19], sets[4]), new DfaTrans(states19[20], sets[6]), new DfaTrans(states19[21], sets[40])};
                states19[1].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[29]), new DfaTrans(states19[4], sets[27])};
                states19[2].Transitions = new DfaTrans[3] {new DfaTrans(states19[2], sets[29]), new DfaTrans(states19[3], sets[22]), new DfaTrans(states19[4], sets[27])};
                states19[3].Transitions = new DfaTrans[0] {};
                states19[4].Transitions = new DfaTrans[2] {new DfaTrans(states19[2], sets[30]), new DfaTrans(states19[5], sets[14])};
                states19[5].Transitions = new DfaTrans[1] {new DfaTrans(states19[6], sets[6])};
                states19[6].Transitions = new DfaTrans[1] {new DfaTrans(states19[7], sets[31])};
                states19[7].Transitions = new DfaTrans[2] {new DfaTrans(states19[8], sets[31]), new DfaTrans(states19[2], sets[9])};
                states19[8].Transitions = new DfaTrans[2] {new DfaTrans(states19[9], sets[31]), new DfaTrans(states19[2], sets[9])};
                states19[9].Transitions = new DfaTrans[2] {new DfaTrans(states19[10], sets[31]), new DfaTrans(states19[2], sets[9])};
                states19[10].Transitions = new DfaTrans[2] {new DfaTrans(states19[11], sets[31]), new DfaTrans(states19[2], sets[9])};
                states19[11].Transitions = new DfaTrans[2] {new DfaTrans(states19[12], sets[31]), new DfaTrans(states19[2], sets[9])};
                states19[12].Transitions = new DfaTrans[1] {new DfaTrans(states19[2], sets[9])};
                states19[13].Transitions = new DfaTrans[0] {};
                states19[14].Transitions = new DfaTrans[0] {};
                states19[15].Transitions = new DfaTrans[0] {};
                states19[16].Transitions = new DfaTrans[0] {};
                states19[17].Transitions = new DfaTrans[0] {};
                states19[18].Transitions = new DfaTrans[0] {};
                states19[19].Transitions = new DfaTrans[1] {new DfaTrans(states19[19], sets[5])};
                states19[20].Transitions = new DfaTrans[0] {};
                states19[21].Transitions = new DfaTrans[0] {};
                
                /* dfa 20 -- ˈtextˈ | '(' | ˈidentifierˈ | '{' -- */
                var states20 = new DfaState[16] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,0), new DfaState(15,true,8)};
                states20[0].Transitions = new DfaTrans[4] {new DfaTrans(states20[1], sets[22]), new DfaTrans(states20[13], sets[23]), new DfaTrans(states20[14], sets[4]), new DfaTrans(states20[15], sets[6])};
                states20[1].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[29]), new DfaTrans(states20[4], sets[27])};
                states20[2].Transitions = new DfaTrans[3] {new DfaTrans(states20[2], sets[29]), new DfaTrans(states20[3], sets[22]), new DfaTrans(states20[4], sets[27])};
                states20[3].Transitions = new DfaTrans[0] {};
                states20[4].Transitions = new DfaTrans[2] {new DfaTrans(states20[2], sets[30]), new DfaTrans(states20[5], sets[14])};
                states20[5].Transitions = new DfaTrans[1] {new DfaTrans(states20[6], sets[6])};
                states20[6].Transitions = new DfaTrans[1] {new DfaTrans(states20[7], sets[31])};
                states20[7].Transitions = new DfaTrans[2] {new DfaTrans(states20[8], sets[31]), new DfaTrans(states20[2], sets[9])};
                states20[8].Transitions = new DfaTrans[2] {new DfaTrans(states20[9], sets[31]), new DfaTrans(states20[2], sets[9])};
                states20[9].Transitions = new DfaTrans[2] {new DfaTrans(states20[10], sets[31]), new DfaTrans(states20[2], sets[9])};
                states20[10].Transitions = new DfaTrans[2] {new DfaTrans(states20[11], sets[31]), new DfaTrans(states20[2], sets[9])};
                states20[11].Transitions = new DfaTrans[2] {new DfaTrans(states20[12], sets[31]), new DfaTrans(states20[2], sets[9])};
                states20[12].Transitions = new DfaTrans[1] {new DfaTrans(states20[2], sets[9])};
                states20[13].Transitions = new DfaTrans[0] {};
                states20[14].Transitions = new DfaTrans[1] {new DfaTrans(states20[14], sets[5])};
                states20[15].Transitions = new DfaTrans[0] {};
                
                /* dfa 21 -- ˈtextˈ | ˈucCodepointˈ -- */
                var states21 = new DfaState[30] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,false,-1), new DfaState(14,false,-1), new DfaState(15,true,6), new DfaState(16,true,6), new DfaState(17,true,6), new DfaState(18,true,6), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,false,-1), new DfaState(22,false,-1), new DfaState(23,false,-1), new DfaState(24,false,-1), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1)};
                states21[0].Transitions = new DfaTrans[3] {new DfaTrans(states21[1], sets[22]), new DfaTrans(states21[13], sets[26]), new DfaTrans(states21[21], sets[27])};
                states21[1].Transitions = new DfaTrans[2] {new DfaTrans(states21[2], sets[29]), new DfaTrans(states21[4], sets[27])};
                states21[2].Transitions = new DfaTrans[3] {new DfaTrans(states21[2], sets[29]), new DfaTrans(states21[3], sets[22]), new DfaTrans(states21[4], sets[27])};
                states21[3].Transitions = new DfaTrans[0] {};
                states21[4].Transitions = new DfaTrans[2] {new DfaTrans(states21[2], sets[30]), new DfaTrans(states21[5], sets[14])};
                states21[5].Transitions = new DfaTrans[1] {new DfaTrans(states21[6], sets[6])};
                states21[6].Transitions = new DfaTrans[1] {new DfaTrans(states21[7], sets[31])};
                states21[7].Transitions = new DfaTrans[2] {new DfaTrans(states21[8], sets[31]), new DfaTrans(states21[2], sets[9])};
                states21[8].Transitions = new DfaTrans[2] {new DfaTrans(states21[9], sets[31]), new DfaTrans(states21[2], sets[9])};
                states21[9].Transitions = new DfaTrans[2] {new DfaTrans(states21[10], sets[31]), new DfaTrans(states21[2], sets[9])};
                states21[10].Transitions = new DfaTrans[2] {new DfaTrans(states21[11], sets[31]), new DfaTrans(states21[2], sets[9])};
                states21[11].Transitions = new DfaTrans[2] {new DfaTrans(states21[12], sets[31]), new DfaTrans(states21[2], sets[9])};
                states21[12].Transitions = new DfaTrans[1] {new DfaTrans(states21[2], sets[9])};
                states21[13].Transitions = new DfaTrans[1] {new DfaTrans(states21[14], sets[32])};
                states21[14].Transitions = new DfaTrans[1] {new DfaTrans(states21[15], sets[31])};
                states21[15].Transitions = new DfaTrans[1] {new DfaTrans(states21[16], sets[31])};
                states21[16].Transitions = new DfaTrans[1] {new DfaTrans(states21[17], sets[31])};
                states21[17].Transitions = new DfaTrans[1] {new DfaTrans(states21[18], sets[31])};
                states21[18].Transitions = new DfaTrans[1] {new DfaTrans(states21[19], sets[31])};
                states21[19].Transitions = new DfaTrans[1] {new DfaTrans(states21[20], sets[31])};
                states21[20].Transitions = new DfaTrans[0] {};
                states21[21].Transitions = new DfaTrans[1] {new DfaTrans(states21[22], sets[14])};
                states21[22].Transitions = new DfaTrans[1] {new DfaTrans(states21[23], sets[6])};
                states21[23].Transitions = new DfaTrans[1] {new DfaTrans(states21[24], sets[31])};
                states21[24].Transitions = new DfaTrans[2] {new DfaTrans(states21[25], sets[31]), new DfaTrans(states21[20], sets[9])};
                states21[25].Transitions = new DfaTrans[2] {new DfaTrans(states21[26], sets[31]), new DfaTrans(states21[20], sets[9])};
                states21[26].Transitions = new DfaTrans[2] {new DfaTrans(states21[27], sets[31]), new DfaTrans(states21[20], sets[9])};
                states21[27].Transitions = new DfaTrans[2] {new DfaTrans(states21[28], sets[31]), new DfaTrans(states21[20], sets[9])};
                states21[28].Transitions = new DfaTrans[2] {new DfaTrans(states21[29], sets[31]), new DfaTrans(states21[20], sets[9])};
                states21[29].Transitions = new DfaTrans[1] {new DfaTrans(states21[20], sets[9])};
                
                /* dfa 22 -- ˈnumberˈ -- */
                var states22 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,1), new DfaState(2,true,1)};
                states22[0].Transitions = new DfaTrans[2] {new DfaTrans(states22[1], sets[43]), new DfaTrans(states22[2], sets[44])};
                states22[1].Transitions = new DfaTrans[0] {};
                states22[2].Transitions = new DfaTrans[1] {new DfaTrans(states22[2], sets[45])};
                
                /* dfa 23 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states23 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,17), new DfaState(16,true,18), new DfaState(17,true,23), new DfaState(18,true,2), new DfaState(19,true,16), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,15), new DfaState(50,true,24)};
                states23[0].Transitions = new DfaTrans[14] {new DfaTrans(states23[1], sets[22]), new DfaTrans(states23[13], sets[23]), new DfaTrans(states23[14], sets[46]), new DfaTrans(states23[15], sets[41]), new DfaTrans(states23[16], sets[32]), new DfaTrans(states23[17], sets[18]), new DfaTrans(states23[18], sets[24]), new DfaTrans(states23[19], sets[42]), new DfaTrans(states23[20], sets[25]), new DfaTrans(states23[21], sets[26]), new DfaTrans(states23[29], sets[27]), new DfaTrans(states23[48], sets[6]), new DfaTrans(states23[49], sets[40]), new DfaTrans(states23[50], sets[28])};
                states23[1].Transitions = new DfaTrans[2] {new DfaTrans(states23[2], sets[29]), new DfaTrans(states23[4], sets[27])};
                states23[2].Transitions = new DfaTrans[3] {new DfaTrans(states23[2], sets[29]), new DfaTrans(states23[3], sets[22]), new DfaTrans(states23[4], sets[27])};
                states23[3].Transitions = new DfaTrans[0] {};
                states23[4].Transitions = new DfaTrans[2] {new DfaTrans(states23[2], sets[30]), new DfaTrans(states23[5], sets[14])};
                states23[5].Transitions = new DfaTrans[1] {new DfaTrans(states23[6], sets[6])};
                states23[6].Transitions = new DfaTrans[1] {new DfaTrans(states23[7], sets[31])};
                states23[7].Transitions = new DfaTrans[2] {new DfaTrans(states23[8], sets[31]), new DfaTrans(states23[2], sets[9])};
                states23[8].Transitions = new DfaTrans[2] {new DfaTrans(states23[9], sets[31]), new DfaTrans(states23[2], sets[9])};
                states23[9].Transitions = new DfaTrans[2] {new DfaTrans(states23[10], sets[31]), new DfaTrans(states23[2], sets[9])};
                states23[10].Transitions = new DfaTrans[2] {new DfaTrans(states23[11], sets[31]), new DfaTrans(states23[2], sets[9])};
                states23[11].Transitions = new DfaTrans[2] {new DfaTrans(states23[12], sets[31]), new DfaTrans(states23[2], sets[9])};
                states23[12].Transitions = new DfaTrans[1] {new DfaTrans(states23[2], sets[9])};
                states23[13].Transitions = new DfaTrans[0] {};
                states23[14].Transitions = new DfaTrans[0] {};
                states23[15].Transitions = new DfaTrans[0] {};
                states23[16].Transitions = new DfaTrans[0] {};
                states23[17].Transitions = new DfaTrans[0] {};
                states23[18].Transitions = new DfaTrans[0] {};
                states23[19].Transitions = new DfaTrans[0] {};
                states23[20].Transitions = new DfaTrans[1] {new DfaTrans(states23[20], sets[5])};
                states23[21].Transitions = new DfaTrans[2] {new DfaTrans(states23[22], sets[32]), new DfaTrans(states23[20], sets[5])};
                states23[22].Transitions = new DfaTrans[1] {new DfaTrans(states23[23], sets[31])};
                states23[23].Transitions = new DfaTrans[1] {new DfaTrans(states23[24], sets[31])};
                states23[24].Transitions = new DfaTrans[1] {new DfaTrans(states23[25], sets[31])};
                states23[25].Transitions = new DfaTrans[1] {new DfaTrans(states23[26], sets[31])};
                states23[26].Transitions = new DfaTrans[1] {new DfaTrans(states23[27], sets[31])};
                states23[27].Transitions = new DfaTrans[1] {new DfaTrans(states23[28], sets[31])};
                states23[28].Transitions = new DfaTrans[0] {};
                states23[29].Transitions = new DfaTrans[1] {new DfaTrans(states23[30], sets[14])};
                states23[30].Transitions = new DfaTrans[3] {new DfaTrans(states23[31], sets[33]), new DfaTrans(states23[36], sets[34]), new DfaTrans(states23[41], sets[6])};
                states23[31].Transitions = new DfaTrans[1] {new DfaTrans(states23[32], sets[6])};
                states23[32].Transitions = new DfaTrans[1] {new DfaTrans(states23[33], sets[35])};
                states23[33].Transitions = new DfaTrans[3] {new DfaTrans(states23[34], sets[36]), new DfaTrans(states23[33], sets[37]), new DfaTrans(states23[35], sets[9])};
                states23[34].Transitions = new DfaTrans[2] {new DfaTrans(states23[34], sets[36]), new DfaTrans(states23[33], sets[37])};
                states23[35].Transitions = new DfaTrans[0] {};
                states23[36].Transitions = new DfaTrans[1] {new DfaTrans(states23[37], sets[6])};
                states23[37].Transitions = new DfaTrans[1] {new DfaTrans(states23[38], sets[35])};
                states23[38].Transitions = new DfaTrans[3] {new DfaTrans(states23[39], sets[36]), new DfaTrans(states23[38], sets[37]), new DfaTrans(states23[40], sets[9])};
                states23[39].Transitions = new DfaTrans[2] {new DfaTrans(states23[39], sets[36]), new DfaTrans(states23[38], sets[37])};
                states23[40].Transitions = new DfaTrans[0] {};
                states23[41].Transitions = new DfaTrans[1] {new DfaTrans(states23[42], sets[31])};
                states23[42].Transitions = new DfaTrans[2] {new DfaTrans(states23[43], sets[31]), new DfaTrans(states23[28], sets[9])};
                states23[43].Transitions = new DfaTrans[2] {new DfaTrans(states23[44], sets[31]), new DfaTrans(states23[28], sets[9])};
                states23[44].Transitions = new DfaTrans[2] {new DfaTrans(states23[45], sets[31]), new DfaTrans(states23[28], sets[9])};
                states23[45].Transitions = new DfaTrans[2] {new DfaTrans(states23[46], sets[31]), new DfaTrans(states23[28], sets[9])};
                states23[46].Transitions = new DfaTrans[2] {new DfaTrans(states23[47], sets[31]), new DfaTrans(states23[28], sets[9])};
                states23[47].Transitions = new DfaTrans[1] {new DfaTrans(states23[28], sets[9])};
                states23[48].Transitions = new DfaTrans[0] {};
                states23[49].Transitions = new DfaTrans[0] {};
                states23[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 24 -- ')' -- */
                var states24 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,21)};
                states24[0].Transitions = new DfaTrans[1] {new DfaTrans(states24[1], sets[46])};
                states24[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 25 -- ')' | '|' -- */
                var states25 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,21), new DfaState(2,true,15)};
                states25[0].Transitions = new DfaTrans[2] {new DfaTrans(states25[1], sets[46]), new DfaTrans(states25[2], sets[40])};
                states25[1].Transitions = new DfaTrans[0] {};
                states25[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 26 -- ')' | '-' | '|' -- */
                var states26 = new DfaState[4] {new DfaState(0,false,-1), new DfaState(1,true,21), new DfaState(2,true,23), new DfaState(3,true,15)};
                states26[0].Transitions = new DfaTrans[3] {new DfaTrans(states26[1], sets[46]), new DfaTrans(states26[2], sets[18]), new DfaTrans(states26[3], sets[40])};
                states26[1].Transitions = new DfaTrans[0] {};
                states26[2].Transitions = new DfaTrans[0] {};
                states26[3].Transitions = new DfaTrans[0] {};
                
                /* dfa 27 -- ˈtextˈ | '(' | ')' | '-' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states27 = new DfaState[47] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,23), new DfaState(16,true,2), new DfaState(17,true,0), new DfaState(18,true,0), new DfaState(19,false,-1), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,true,4), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,true,5), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,true,15), new DfaState(46,true,24)};
                states27[0].Transitions = new DfaTrans[10] {new DfaTrans(states27[1], sets[22]), new DfaTrans(states27[13], sets[23]), new DfaTrans(states27[14], sets[46]), new DfaTrans(states27[15], sets[18]), new DfaTrans(states27[16], sets[24]), new DfaTrans(states27[17], sets[25]), new DfaTrans(states27[18], sets[26]), new DfaTrans(states27[26], sets[27]), new DfaTrans(states27[45], sets[40]), new DfaTrans(states27[46], sets[28])};
                states27[1].Transitions = new DfaTrans[2] {new DfaTrans(states27[2], sets[29]), new DfaTrans(states27[4], sets[27])};
                states27[2].Transitions = new DfaTrans[3] {new DfaTrans(states27[2], sets[29]), new DfaTrans(states27[3], sets[22]), new DfaTrans(states27[4], sets[27])};
                states27[3].Transitions = new DfaTrans[0] {};
                states27[4].Transitions = new DfaTrans[2] {new DfaTrans(states27[2], sets[30]), new DfaTrans(states27[5], sets[14])};
                states27[5].Transitions = new DfaTrans[1] {new DfaTrans(states27[6], sets[6])};
                states27[6].Transitions = new DfaTrans[1] {new DfaTrans(states27[7], sets[31])};
                states27[7].Transitions = new DfaTrans[2] {new DfaTrans(states27[8], sets[31]), new DfaTrans(states27[2], sets[9])};
                states27[8].Transitions = new DfaTrans[2] {new DfaTrans(states27[9], sets[31]), new DfaTrans(states27[2], sets[9])};
                states27[9].Transitions = new DfaTrans[2] {new DfaTrans(states27[10], sets[31]), new DfaTrans(states27[2], sets[9])};
                states27[10].Transitions = new DfaTrans[2] {new DfaTrans(states27[11], sets[31]), new DfaTrans(states27[2], sets[9])};
                states27[11].Transitions = new DfaTrans[2] {new DfaTrans(states27[12], sets[31]), new DfaTrans(states27[2], sets[9])};
                states27[12].Transitions = new DfaTrans[1] {new DfaTrans(states27[2], sets[9])};
                states27[13].Transitions = new DfaTrans[0] {};
                states27[14].Transitions = new DfaTrans[0] {};
                states27[15].Transitions = new DfaTrans[0] {};
                states27[16].Transitions = new DfaTrans[0] {};
                states27[17].Transitions = new DfaTrans[1] {new DfaTrans(states27[17], sets[5])};
                states27[18].Transitions = new DfaTrans[2] {new DfaTrans(states27[19], sets[32]), new DfaTrans(states27[17], sets[5])};
                states27[19].Transitions = new DfaTrans[1] {new DfaTrans(states27[20], sets[31])};
                states27[20].Transitions = new DfaTrans[1] {new DfaTrans(states27[21], sets[31])};
                states27[21].Transitions = new DfaTrans[1] {new DfaTrans(states27[22], sets[31])};
                states27[22].Transitions = new DfaTrans[1] {new DfaTrans(states27[23], sets[31])};
                states27[23].Transitions = new DfaTrans[1] {new DfaTrans(states27[24], sets[31])};
                states27[24].Transitions = new DfaTrans[1] {new DfaTrans(states27[25], sets[31])};
                states27[25].Transitions = new DfaTrans[0] {};
                states27[26].Transitions = new DfaTrans[1] {new DfaTrans(states27[27], sets[14])};
                states27[27].Transitions = new DfaTrans[3] {new DfaTrans(states27[28], sets[33]), new DfaTrans(states27[33], sets[34]), new DfaTrans(states27[38], sets[6])};
                states27[28].Transitions = new DfaTrans[1] {new DfaTrans(states27[29], sets[6])};
                states27[29].Transitions = new DfaTrans[1] {new DfaTrans(states27[30], sets[35])};
                states27[30].Transitions = new DfaTrans[3] {new DfaTrans(states27[31], sets[36]), new DfaTrans(states27[30], sets[37]), new DfaTrans(states27[32], sets[9])};
                states27[31].Transitions = new DfaTrans[2] {new DfaTrans(states27[31], sets[36]), new DfaTrans(states27[30], sets[37])};
                states27[32].Transitions = new DfaTrans[0] {};
                states27[33].Transitions = new DfaTrans[1] {new DfaTrans(states27[34], sets[6])};
                states27[34].Transitions = new DfaTrans[1] {new DfaTrans(states27[35], sets[35])};
                states27[35].Transitions = new DfaTrans[3] {new DfaTrans(states27[36], sets[36]), new DfaTrans(states27[35], sets[37]), new DfaTrans(states27[37], sets[9])};
                states27[36].Transitions = new DfaTrans[2] {new DfaTrans(states27[36], sets[36]), new DfaTrans(states27[35], sets[37])};
                states27[37].Transitions = new DfaTrans[0] {};
                states27[38].Transitions = new DfaTrans[1] {new DfaTrans(states27[39], sets[31])};
                states27[39].Transitions = new DfaTrans[2] {new DfaTrans(states27[40], sets[31]), new DfaTrans(states27[25], sets[9])};
                states27[40].Transitions = new DfaTrans[2] {new DfaTrans(states27[41], sets[31]), new DfaTrans(states27[25], sets[9])};
                states27[41].Transitions = new DfaTrans[2] {new DfaTrans(states27[42], sets[31]), new DfaTrans(states27[25], sets[9])};
                states27[42].Transitions = new DfaTrans[2] {new DfaTrans(states27[43], sets[31]), new DfaTrans(states27[25], sets[9])};
                states27[43].Transitions = new DfaTrans[2] {new DfaTrans(states27[44], sets[31]), new DfaTrans(states27[25], sets[9])};
                states27[44].Transitions = new DfaTrans[1] {new DfaTrans(states27[25], sets[9])};
                states27[45].Transitions = new DfaTrans[0] {};
                states27[46].Transitions = new DfaTrans[0] {};
                
                /* dfa 28 -- ˈtextˈ | '(' | ')' | '*' | '+' | '-' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states28 = new DfaState[52] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,17), new DfaState(16,true,18), new DfaState(17,true,23), new DfaState(18,true,2), new DfaState(19,true,25), new DfaState(20,true,16), new DfaState(21,true,0), new DfaState(22,true,0), new DfaState(23,false,-1), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,true,6), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,4), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,true,5), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,false,-1), new DfaState(49,true,8), new DfaState(50,true,15), new DfaState(51,true,24)};
                states28[0].Transitions = new DfaTrans[14] {new DfaTrans(states28[1], sets[22]), new DfaTrans(states28[13], sets[23]), new DfaTrans(states28[14], sets[46]), new DfaTrans(states28[15], sets[41]), new DfaTrans(states28[16], sets[32]), new DfaTrans(states28[17], sets[18]), new DfaTrans(states28[18], sets[24]), new DfaTrans(states28[20], sets[42]), new DfaTrans(states28[21], sets[25]), new DfaTrans(states28[22], sets[26]), new DfaTrans(states28[30], sets[27]), new DfaTrans(states28[49], sets[6]), new DfaTrans(states28[50], sets[40]), new DfaTrans(states28[51], sets[28])};
                states28[1].Transitions = new DfaTrans[2] {new DfaTrans(states28[2], sets[29]), new DfaTrans(states28[4], sets[27])};
                states28[2].Transitions = new DfaTrans[3] {new DfaTrans(states28[2], sets[29]), new DfaTrans(states28[3], sets[22]), new DfaTrans(states28[4], sets[27])};
                states28[3].Transitions = new DfaTrans[0] {};
                states28[4].Transitions = new DfaTrans[2] {new DfaTrans(states28[2], sets[30]), new DfaTrans(states28[5], sets[14])};
                states28[5].Transitions = new DfaTrans[1] {new DfaTrans(states28[6], sets[6])};
                states28[6].Transitions = new DfaTrans[1] {new DfaTrans(states28[7], sets[31])};
                states28[7].Transitions = new DfaTrans[2] {new DfaTrans(states28[8], sets[31]), new DfaTrans(states28[2], sets[9])};
                states28[8].Transitions = new DfaTrans[2] {new DfaTrans(states28[9], sets[31]), new DfaTrans(states28[2], sets[9])};
                states28[9].Transitions = new DfaTrans[2] {new DfaTrans(states28[10], sets[31]), new DfaTrans(states28[2], sets[9])};
                states28[10].Transitions = new DfaTrans[2] {new DfaTrans(states28[11], sets[31]), new DfaTrans(states28[2], sets[9])};
                states28[11].Transitions = new DfaTrans[2] {new DfaTrans(states28[12], sets[31]), new DfaTrans(states28[2], sets[9])};
                states28[12].Transitions = new DfaTrans[1] {new DfaTrans(states28[2], sets[9])};
                states28[13].Transitions = new DfaTrans[0] {};
                states28[14].Transitions = new DfaTrans[0] {};
                states28[15].Transitions = new DfaTrans[0] {};
                states28[16].Transitions = new DfaTrans[0] {};
                states28[17].Transitions = new DfaTrans[0] {};
                states28[18].Transitions = new DfaTrans[1] {new DfaTrans(states28[19], sets[24])};
                states28[19].Transitions = new DfaTrans[0] {};
                states28[20].Transitions = new DfaTrans[0] {};
                states28[21].Transitions = new DfaTrans[1] {new DfaTrans(states28[21], sets[5])};
                states28[22].Transitions = new DfaTrans[2] {new DfaTrans(states28[23], sets[32]), new DfaTrans(states28[21], sets[5])};
                states28[23].Transitions = new DfaTrans[1] {new DfaTrans(states28[24], sets[31])};
                states28[24].Transitions = new DfaTrans[1] {new DfaTrans(states28[25], sets[31])};
                states28[25].Transitions = new DfaTrans[1] {new DfaTrans(states28[26], sets[31])};
                states28[26].Transitions = new DfaTrans[1] {new DfaTrans(states28[27], sets[31])};
                states28[27].Transitions = new DfaTrans[1] {new DfaTrans(states28[28], sets[31])};
                states28[28].Transitions = new DfaTrans[1] {new DfaTrans(states28[29], sets[31])};
                states28[29].Transitions = new DfaTrans[0] {};
                states28[30].Transitions = new DfaTrans[1] {new DfaTrans(states28[31], sets[14])};
                states28[31].Transitions = new DfaTrans[3] {new DfaTrans(states28[32], sets[33]), new DfaTrans(states28[37], sets[34]), new DfaTrans(states28[42], sets[6])};
                states28[32].Transitions = new DfaTrans[1] {new DfaTrans(states28[33], sets[6])};
                states28[33].Transitions = new DfaTrans[1] {new DfaTrans(states28[34], sets[35])};
                states28[34].Transitions = new DfaTrans[3] {new DfaTrans(states28[35], sets[36]), new DfaTrans(states28[34], sets[37]), new DfaTrans(states28[36], sets[9])};
                states28[35].Transitions = new DfaTrans[2] {new DfaTrans(states28[35], sets[36]), new DfaTrans(states28[34], sets[37])};
                states28[36].Transitions = new DfaTrans[0] {};
                states28[37].Transitions = new DfaTrans[1] {new DfaTrans(states28[38], sets[6])};
                states28[38].Transitions = new DfaTrans[1] {new DfaTrans(states28[39], sets[35])};
                states28[39].Transitions = new DfaTrans[3] {new DfaTrans(states28[40], sets[36]), new DfaTrans(states28[39], sets[37]), new DfaTrans(states28[41], sets[9])};
                states28[40].Transitions = new DfaTrans[2] {new DfaTrans(states28[40], sets[36]), new DfaTrans(states28[39], sets[37])};
                states28[41].Transitions = new DfaTrans[0] {};
                states28[42].Transitions = new DfaTrans[1] {new DfaTrans(states28[43], sets[31])};
                states28[43].Transitions = new DfaTrans[2] {new DfaTrans(states28[44], sets[31]), new DfaTrans(states28[29], sets[9])};
                states28[44].Transitions = new DfaTrans[2] {new DfaTrans(states28[45], sets[31]), new DfaTrans(states28[29], sets[9])};
                states28[45].Transitions = new DfaTrans[2] {new DfaTrans(states28[46], sets[31]), new DfaTrans(states28[29], sets[9])};
                states28[46].Transitions = new DfaTrans[2] {new DfaTrans(states28[47], sets[31]), new DfaTrans(states28[29], sets[9])};
                states28[47].Transitions = new DfaTrans[2] {new DfaTrans(states28[48], sets[31]), new DfaTrans(states28[29], sets[9])};
                states28[48].Transitions = new DfaTrans[1] {new DfaTrans(states28[29], sets[9])};
                states28[49].Transitions = new DfaTrans[0] {};
                states28[50].Transitions = new DfaTrans[0] {};
                states28[51].Transitions = new DfaTrans[0] {};
                
                /* dfa 29 -- ˈtextˈ | '(' | ')' | ',' | ˈidentifierˈ | '{' | '|' -- */
                var states29 = new DfaState[19] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,19), new DfaState(16,true,0), new DfaState(17,true,8), new DfaState(18,true,15)};
                states29[0].Transitions = new DfaTrans[7] {new DfaTrans(states29[1], sets[22]), new DfaTrans(states29[13], sets[23]), new DfaTrans(states29[14], sets[46]), new DfaTrans(states29[15], sets[39]), new DfaTrans(states29[16], sets[4]), new DfaTrans(states29[17], sets[6]), new DfaTrans(states29[18], sets[40])};
                states29[1].Transitions = new DfaTrans[2] {new DfaTrans(states29[2], sets[29]), new DfaTrans(states29[4], sets[27])};
                states29[2].Transitions = new DfaTrans[3] {new DfaTrans(states29[2], sets[29]), new DfaTrans(states29[3], sets[22]), new DfaTrans(states29[4], sets[27])};
                states29[3].Transitions = new DfaTrans[0] {};
                states29[4].Transitions = new DfaTrans[2] {new DfaTrans(states29[2], sets[30]), new DfaTrans(states29[5], sets[14])};
                states29[5].Transitions = new DfaTrans[1] {new DfaTrans(states29[6], sets[6])};
                states29[6].Transitions = new DfaTrans[1] {new DfaTrans(states29[7], sets[31])};
                states29[7].Transitions = new DfaTrans[2] {new DfaTrans(states29[8], sets[31]), new DfaTrans(states29[2], sets[9])};
                states29[8].Transitions = new DfaTrans[2] {new DfaTrans(states29[9], sets[31]), new DfaTrans(states29[2], sets[9])};
                states29[9].Transitions = new DfaTrans[2] {new DfaTrans(states29[10], sets[31]), new DfaTrans(states29[2], sets[9])};
                states29[10].Transitions = new DfaTrans[2] {new DfaTrans(states29[11], sets[31]), new DfaTrans(states29[2], sets[9])};
                states29[11].Transitions = new DfaTrans[2] {new DfaTrans(states29[12], sets[31]), new DfaTrans(states29[2], sets[9])};
                states29[12].Transitions = new DfaTrans[1] {new DfaTrans(states29[2], sets[9])};
                states29[13].Transitions = new DfaTrans[0] {};
                states29[14].Transitions = new DfaTrans[0] {};
                states29[15].Transitions = new DfaTrans[0] {};
                states29[16].Transitions = new DfaTrans[1] {new DfaTrans(states29[16], sets[5])};
                states29[17].Transitions = new DfaTrans[0] {};
                states29[18].Transitions = new DfaTrans[0] {};
                
                /* dfa 30 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states30 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,17), new DfaState(15,true,18), new DfaState(16,true,2), new DfaState(17,true,12), new DfaState(18,true,16), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,15), new DfaState(49,true,24)};
                states30[0].Transitions = new DfaTrans[13] {new DfaTrans(states30[1], sets[22]), new DfaTrans(states30[13], sets[23]), new DfaTrans(states30[14], sets[41]), new DfaTrans(states30[15], sets[32]), new DfaTrans(states30[16], sets[24]), new DfaTrans(states30[17], sets[38]), new DfaTrans(states30[18], sets[42]), new DfaTrans(states30[19], sets[25]), new DfaTrans(states30[20], sets[26]), new DfaTrans(states30[28], sets[27]), new DfaTrans(states30[47], sets[6]), new DfaTrans(states30[48], sets[40]), new DfaTrans(states30[49], sets[28])};
                states30[1].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[29]), new DfaTrans(states30[4], sets[27])};
                states30[2].Transitions = new DfaTrans[3] {new DfaTrans(states30[2], sets[29]), new DfaTrans(states30[3], sets[22]), new DfaTrans(states30[4], sets[27])};
                states30[3].Transitions = new DfaTrans[0] {};
                states30[4].Transitions = new DfaTrans[2] {new DfaTrans(states30[2], sets[30]), new DfaTrans(states30[5], sets[14])};
                states30[5].Transitions = new DfaTrans[1] {new DfaTrans(states30[6], sets[6])};
                states30[6].Transitions = new DfaTrans[1] {new DfaTrans(states30[7], sets[31])};
                states30[7].Transitions = new DfaTrans[2] {new DfaTrans(states30[8], sets[31]), new DfaTrans(states30[2], sets[9])};
                states30[8].Transitions = new DfaTrans[2] {new DfaTrans(states30[9], sets[31]), new DfaTrans(states30[2], sets[9])};
                states30[9].Transitions = new DfaTrans[2] {new DfaTrans(states30[10], sets[31]), new DfaTrans(states30[2], sets[9])};
                states30[10].Transitions = new DfaTrans[2] {new DfaTrans(states30[11], sets[31]), new DfaTrans(states30[2], sets[9])};
                states30[11].Transitions = new DfaTrans[2] {new DfaTrans(states30[12], sets[31]), new DfaTrans(states30[2], sets[9])};
                states30[12].Transitions = new DfaTrans[1] {new DfaTrans(states30[2], sets[9])};
                states30[13].Transitions = new DfaTrans[0] {};
                states30[14].Transitions = new DfaTrans[0] {};
                states30[15].Transitions = new DfaTrans[0] {};
                states30[16].Transitions = new DfaTrans[0] {};
                states30[17].Transitions = new DfaTrans[0] {};
                states30[18].Transitions = new DfaTrans[0] {};
                states30[19].Transitions = new DfaTrans[1] {new DfaTrans(states30[19], sets[5])};
                states30[20].Transitions = new DfaTrans[2] {new DfaTrans(states30[21], sets[32]), new DfaTrans(states30[19], sets[5])};
                states30[21].Transitions = new DfaTrans[1] {new DfaTrans(states30[22], sets[31])};
                states30[22].Transitions = new DfaTrans[1] {new DfaTrans(states30[23], sets[31])};
                states30[23].Transitions = new DfaTrans[1] {new DfaTrans(states30[24], sets[31])};
                states30[24].Transitions = new DfaTrans[1] {new DfaTrans(states30[25], sets[31])};
                states30[25].Transitions = new DfaTrans[1] {new DfaTrans(states30[26], sets[31])};
                states30[26].Transitions = new DfaTrans[1] {new DfaTrans(states30[27], sets[31])};
                states30[27].Transitions = new DfaTrans[0] {};
                states30[28].Transitions = new DfaTrans[1] {new DfaTrans(states30[29], sets[14])};
                states30[29].Transitions = new DfaTrans[3] {new DfaTrans(states30[30], sets[33]), new DfaTrans(states30[35], sets[34]), new DfaTrans(states30[40], sets[6])};
                states30[30].Transitions = new DfaTrans[1] {new DfaTrans(states30[31], sets[6])};
                states30[31].Transitions = new DfaTrans[1] {new DfaTrans(states30[32], sets[35])};
                states30[32].Transitions = new DfaTrans[3] {new DfaTrans(states30[33], sets[36]), new DfaTrans(states30[32], sets[37]), new DfaTrans(states30[34], sets[9])};
                states30[33].Transitions = new DfaTrans[2] {new DfaTrans(states30[33], sets[36]), new DfaTrans(states30[32], sets[37])};
                states30[34].Transitions = new DfaTrans[0] {};
                states30[35].Transitions = new DfaTrans[1] {new DfaTrans(states30[36], sets[6])};
                states30[36].Transitions = new DfaTrans[1] {new DfaTrans(states30[37], sets[35])};
                states30[37].Transitions = new DfaTrans[3] {new DfaTrans(states30[38], sets[36]), new DfaTrans(states30[37], sets[37]), new DfaTrans(states30[39], sets[9])};
                states30[38].Transitions = new DfaTrans[2] {new DfaTrans(states30[38], sets[36]), new DfaTrans(states30[37], sets[37])};
                states30[39].Transitions = new DfaTrans[0] {};
                states30[40].Transitions = new DfaTrans[1] {new DfaTrans(states30[41], sets[31])};
                states30[41].Transitions = new DfaTrans[2] {new DfaTrans(states30[42], sets[31]), new DfaTrans(states30[27], sets[9])};
                states30[42].Transitions = new DfaTrans[2] {new DfaTrans(states30[43], sets[31]), new DfaTrans(states30[27], sets[9])};
                states30[43].Transitions = new DfaTrans[2] {new DfaTrans(states30[44], sets[31]), new DfaTrans(states30[27], sets[9])};
                states30[44].Transitions = new DfaTrans[2] {new DfaTrans(states30[45], sets[31]), new DfaTrans(states30[27], sets[9])};
                states30[45].Transitions = new DfaTrans[2] {new DfaTrans(states30[46], sets[31]), new DfaTrans(states30[27], sets[9])};
                states30[46].Transitions = new DfaTrans[1] {new DfaTrans(states30[27], sets[9])};
                states30[47].Transitions = new DfaTrans[0] {};
                states30[48].Transitions = new DfaTrans[0] {};
                states30[49].Transitions = new DfaTrans[0] {};
                
                /* dfa 31 -- ˈtextˈ | '(' | ˈanyˈ | ';' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states31 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,2), new DfaState(15,true,12), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,15), new DfaState(45,true,24)};
                states31[0].Transitions = new DfaTrans[9] {new DfaTrans(states31[1], sets[22]), new DfaTrans(states31[13], sets[23]), new DfaTrans(states31[14], sets[24]), new DfaTrans(states31[15], sets[38]), new DfaTrans(states31[16], sets[25]), new DfaTrans(states31[17], sets[26]), new DfaTrans(states31[25], sets[27]), new DfaTrans(states31[44], sets[40]), new DfaTrans(states31[45], sets[28])};
                states31[1].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[29]), new DfaTrans(states31[4], sets[27])};
                states31[2].Transitions = new DfaTrans[3] {new DfaTrans(states31[2], sets[29]), new DfaTrans(states31[3], sets[22]), new DfaTrans(states31[4], sets[27])};
                states31[3].Transitions = new DfaTrans[0] {};
                states31[4].Transitions = new DfaTrans[2] {new DfaTrans(states31[2], sets[30]), new DfaTrans(states31[5], sets[14])};
                states31[5].Transitions = new DfaTrans[1] {new DfaTrans(states31[6], sets[6])};
                states31[6].Transitions = new DfaTrans[1] {new DfaTrans(states31[7], sets[31])};
                states31[7].Transitions = new DfaTrans[2] {new DfaTrans(states31[8], sets[31]), new DfaTrans(states31[2], sets[9])};
                states31[8].Transitions = new DfaTrans[2] {new DfaTrans(states31[9], sets[31]), new DfaTrans(states31[2], sets[9])};
                states31[9].Transitions = new DfaTrans[2] {new DfaTrans(states31[10], sets[31]), new DfaTrans(states31[2], sets[9])};
                states31[10].Transitions = new DfaTrans[2] {new DfaTrans(states31[11], sets[31]), new DfaTrans(states31[2], sets[9])};
                states31[11].Transitions = new DfaTrans[2] {new DfaTrans(states31[12], sets[31]), new DfaTrans(states31[2], sets[9])};
                states31[12].Transitions = new DfaTrans[1] {new DfaTrans(states31[2], sets[9])};
                states31[13].Transitions = new DfaTrans[0] {};
                states31[14].Transitions = new DfaTrans[0] {};
                states31[15].Transitions = new DfaTrans[0] {};
                states31[16].Transitions = new DfaTrans[1] {new DfaTrans(states31[16], sets[5])};
                states31[17].Transitions = new DfaTrans[2] {new DfaTrans(states31[18], sets[32]), new DfaTrans(states31[16], sets[5])};
                states31[18].Transitions = new DfaTrans[1] {new DfaTrans(states31[19], sets[31])};
                states31[19].Transitions = new DfaTrans[1] {new DfaTrans(states31[20], sets[31])};
                states31[20].Transitions = new DfaTrans[1] {new DfaTrans(states31[21], sets[31])};
                states31[21].Transitions = new DfaTrans[1] {new DfaTrans(states31[22], sets[31])};
                states31[22].Transitions = new DfaTrans[1] {new DfaTrans(states31[23], sets[31])};
                states31[23].Transitions = new DfaTrans[1] {new DfaTrans(states31[24], sets[31])};
                states31[24].Transitions = new DfaTrans[0] {};
                states31[25].Transitions = new DfaTrans[1] {new DfaTrans(states31[26], sets[14])};
                states31[26].Transitions = new DfaTrans[3] {new DfaTrans(states31[27], sets[33]), new DfaTrans(states31[32], sets[34]), new DfaTrans(states31[37], sets[6])};
                states31[27].Transitions = new DfaTrans[1] {new DfaTrans(states31[28], sets[6])};
                states31[28].Transitions = new DfaTrans[1] {new DfaTrans(states31[29], sets[35])};
                states31[29].Transitions = new DfaTrans[3] {new DfaTrans(states31[30], sets[36]), new DfaTrans(states31[29], sets[37]), new DfaTrans(states31[31], sets[9])};
                states31[30].Transitions = new DfaTrans[2] {new DfaTrans(states31[30], sets[36]), new DfaTrans(states31[29], sets[37])};
                states31[31].Transitions = new DfaTrans[0] {};
                states31[32].Transitions = new DfaTrans[1] {new DfaTrans(states31[33], sets[6])};
                states31[33].Transitions = new DfaTrans[1] {new DfaTrans(states31[34], sets[35])};
                states31[34].Transitions = new DfaTrans[3] {new DfaTrans(states31[35], sets[36]), new DfaTrans(states31[34], sets[37]), new DfaTrans(states31[36], sets[9])};
                states31[35].Transitions = new DfaTrans[2] {new DfaTrans(states31[35], sets[36]), new DfaTrans(states31[34], sets[37])};
                states31[36].Transitions = new DfaTrans[0] {};
                states31[37].Transitions = new DfaTrans[1] {new DfaTrans(states31[38], sets[31])};
                states31[38].Transitions = new DfaTrans[2] {new DfaTrans(states31[39], sets[31]), new DfaTrans(states31[24], sets[9])};
                states31[39].Transitions = new DfaTrans[2] {new DfaTrans(states31[40], sets[31]), new DfaTrans(states31[24], sets[9])};
                states31[40].Transitions = new DfaTrans[2] {new DfaTrans(states31[41], sets[31]), new DfaTrans(states31[24], sets[9])};
                states31[41].Transitions = new DfaTrans[2] {new DfaTrans(states31[42], sets[31]), new DfaTrans(states31[24], sets[9])};
                states31[42].Transitions = new DfaTrans[2] {new DfaTrans(states31[43], sets[31]), new DfaTrans(states31[24], sets[9])};
                states31[43].Transitions = new DfaTrans[1] {new DfaTrans(states31[24], sets[9])};
                states31[44].Transitions = new DfaTrans[0] {};
                states31[45].Transitions = new DfaTrans[0] {};
                
                /* dfa 32 -- ˈtextˈ | '(' | '*' | '+' | ˈanyˈ | '..' | ';' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states32 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,17), new DfaState(15,true,18), new DfaState(16,true,2), new DfaState(17,true,25), new DfaState(18,true,12), new DfaState(19,true,16), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,15), new DfaState(50,true,24)};
                states32[0].Transitions = new DfaTrans[13] {new DfaTrans(states32[1], sets[22]), new DfaTrans(states32[13], sets[23]), new DfaTrans(states32[14], sets[41]), new DfaTrans(states32[15], sets[32]), new DfaTrans(states32[16], sets[24]), new DfaTrans(states32[18], sets[38]), new DfaTrans(states32[19], sets[42]), new DfaTrans(states32[20], sets[25]), new DfaTrans(states32[21], sets[26]), new DfaTrans(states32[29], sets[27]), new DfaTrans(states32[48], sets[6]), new DfaTrans(states32[49], sets[40]), new DfaTrans(states32[50], sets[28])};
                states32[1].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[29]), new DfaTrans(states32[4], sets[27])};
                states32[2].Transitions = new DfaTrans[3] {new DfaTrans(states32[2], sets[29]), new DfaTrans(states32[3], sets[22]), new DfaTrans(states32[4], sets[27])};
                states32[3].Transitions = new DfaTrans[0] {};
                states32[4].Transitions = new DfaTrans[2] {new DfaTrans(states32[2], sets[30]), new DfaTrans(states32[5], sets[14])};
                states32[5].Transitions = new DfaTrans[1] {new DfaTrans(states32[6], sets[6])};
                states32[6].Transitions = new DfaTrans[1] {new DfaTrans(states32[7], sets[31])};
                states32[7].Transitions = new DfaTrans[2] {new DfaTrans(states32[8], sets[31]), new DfaTrans(states32[2], sets[9])};
                states32[8].Transitions = new DfaTrans[2] {new DfaTrans(states32[9], sets[31]), new DfaTrans(states32[2], sets[9])};
                states32[9].Transitions = new DfaTrans[2] {new DfaTrans(states32[10], sets[31]), new DfaTrans(states32[2], sets[9])};
                states32[10].Transitions = new DfaTrans[2] {new DfaTrans(states32[11], sets[31]), new DfaTrans(states32[2], sets[9])};
                states32[11].Transitions = new DfaTrans[2] {new DfaTrans(states32[12], sets[31]), new DfaTrans(states32[2], sets[9])};
                states32[12].Transitions = new DfaTrans[1] {new DfaTrans(states32[2], sets[9])};
                states32[13].Transitions = new DfaTrans[0] {};
                states32[14].Transitions = new DfaTrans[0] {};
                states32[15].Transitions = new DfaTrans[0] {};
                states32[16].Transitions = new DfaTrans[1] {new DfaTrans(states32[17], sets[24])};
                states32[17].Transitions = new DfaTrans[0] {};
                states32[18].Transitions = new DfaTrans[0] {};
                states32[19].Transitions = new DfaTrans[0] {};
                states32[20].Transitions = new DfaTrans[1] {new DfaTrans(states32[20], sets[5])};
                states32[21].Transitions = new DfaTrans[2] {new DfaTrans(states32[22], sets[32]), new DfaTrans(states32[20], sets[5])};
                states32[22].Transitions = new DfaTrans[1] {new DfaTrans(states32[23], sets[31])};
                states32[23].Transitions = new DfaTrans[1] {new DfaTrans(states32[24], sets[31])};
                states32[24].Transitions = new DfaTrans[1] {new DfaTrans(states32[25], sets[31])};
                states32[25].Transitions = new DfaTrans[1] {new DfaTrans(states32[26], sets[31])};
                states32[26].Transitions = new DfaTrans[1] {new DfaTrans(states32[27], sets[31])};
                states32[27].Transitions = new DfaTrans[1] {new DfaTrans(states32[28], sets[31])};
                states32[28].Transitions = new DfaTrans[0] {};
                states32[29].Transitions = new DfaTrans[1] {new DfaTrans(states32[30], sets[14])};
                states32[30].Transitions = new DfaTrans[3] {new DfaTrans(states32[31], sets[33]), new DfaTrans(states32[36], sets[34]), new DfaTrans(states32[41], sets[6])};
                states32[31].Transitions = new DfaTrans[1] {new DfaTrans(states32[32], sets[6])};
                states32[32].Transitions = new DfaTrans[1] {new DfaTrans(states32[33], sets[35])};
                states32[33].Transitions = new DfaTrans[3] {new DfaTrans(states32[34], sets[36]), new DfaTrans(states32[33], sets[37]), new DfaTrans(states32[35], sets[9])};
                states32[34].Transitions = new DfaTrans[2] {new DfaTrans(states32[34], sets[36]), new DfaTrans(states32[33], sets[37])};
                states32[35].Transitions = new DfaTrans[0] {};
                states32[36].Transitions = new DfaTrans[1] {new DfaTrans(states32[37], sets[6])};
                states32[37].Transitions = new DfaTrans[1] {new DfaTrans(states32[38], sets[35])};
                states32[38].Transitions = new DfaTrans[3] {new DfaTrans(states32[39], sets[36]), new DfaTrans(states32[38], sets[37]), new DfaTrans(states32[40], sets[9])};
                states32[39].Transitions = new DfaTrans[2] {new DfaTrans(states32[39], sets[36]), new DfaTrans(states32[38], sets[37])};
                states32[40].Transitions = new DfaTrans[0] {};
                states32[41].Transitions = new DfaTrans[1] {new DfaTrans(states32[42], sets[31])};
                states32[42].Transitions = new DfaTrans[2] {new DfaTrans(states32[43], sets[31]), new DfaTrans(states32[28], sets[9])};
                states32[43].Transitions = new DfaTrans[2] {new DfaTrans(states32[44], sets[31]), new DfaTrans(states32[28], sets[9])};
                states32[44].Transitions = new DfaTrans[2] {new DfaTrans(states32[45], sets[31]), new DfaTrans(states32[28], sets[9])};
                states32[45].Transitions = new DfaTrans[2] {new DfaTrans(states32[46], sets[31]), new DfaTrans(states32[28], sets[9])};
                states32[46].Transitions = new DfaTrans[2] {new DfaTrans(states32[47], sets[31]), new DfaTrans(states32[28], sets[9])};
                states32[47].Transitions = new DfaTrans[1] {new DfaTrans(states32[28], sets[9])};
                states32[48].Transitions = new DfaTrans[0] {};
                states32[49].Transitions = new DfaTrans[0] {};
                states32[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 33 -- ',' | '}' -- */
                var states33 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,19), new DfaState(2,true,9)};
                states33[0].Transitions = new DfaTrans[2] {new DfaTrans(states33[1], sets[39]), new DfaTrans(states33[2], sets[9])};
                states33[1].Transitions = new DfaTrans[0] {};
                states33[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 34 -- ˈtextˈ | '(' | ')' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '{' | '|' -- */
                var states34 = new DfaState[22] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,17), new DfaState(16,true,18), new DfaState(17,true,19), new DfaState(18,true,16), new DfaState(19,true,0), new DfaState(20,true,8), new DfaState(21,true,15)};
                states34[0].Transitions = new DfaTrans[10] {new DfaTrans(states34[1], sets[22]), new DfaTrans(states34[13], sets[23]), new DfaTrans(states34[14], sets[46]), new DfaTrans(states34[15], sets[41]), new DfaTrans(states34[16], sets[32]), new DfaTrans(states34[17], sets[39]), new DfaTrans(states34[18], sets[42]), new DfaTrans(states34[19], sets[4]), new DfaTrans(states34[20], sets[6]), new DfaTrans(states34[21], sets[40])};
                states34[1].Transitions = new DfaTrans[2] {new DfaTrans(states34[2], sets[29]), new DfaTrans(states34[4], sets[27])};
                states34[2].Transitions = new DfaTrans[3] {new DfaTrans(states34[2], sets[29]), new DfaTrans(states34[3], sets[22]), new DfaTrans(states34[4], sets[27])};
                states34[3].Transitions = new DfaTrans[0] {};
                states34[4].Transitions = new DfaTrans[2] {new DfaTrans(states34[2], sets[30]), new DfaTrans(states34[5], sets[14])};
                states34[5].Transitions = new DfaTrans[1] {new DfaTrans(states34[6], sets[6])};
                states34[6].Transitions = new DfaTrans[1] {new DfaTrans(states34[7], sets[31])};
                states34[7].Transitions = new DfaTrans[2] {new DfaTrans(states34[8], sets[31]), new DfaTrans(states34[2], sets[9])};
                states34[8].Transitions = new DfaTrans[2] {new DfaTrans(states34[9], sets[31]), new DfaTrans(states34[2], sets[9])};
                states34[9].Transitions = new DfaTrans[2] {new DfaTrans(states34[10], sets[31]), new DfaTrans(states34[2], sets[9])};
                states34[10].Transitions = new DfaTrans[2] {new DfaTrans(states34[11], sets[31]), new DfaTrans(states34[2], sets[9])};
                states34[11].Transitions = new DfaTrans[2] {new DfaTrans(states34[12], sets[31]), new DfaTrans(states34[2], sets[9])};
                states34[12].Transitions = new DfaTrans[1] {new DfaTrans(states34[2], sets[9])};
                states34[13].Transitions = new DfaTrans[0] {};
                states34[14].Transitions = new DfaTrans[0] {};
                states34[15].Transitions = new DfaTrans[0] {};
                states34[16].Transitions = new DfaTrans[0] {};
                states34[17].Transitions = new DfaTrans[0] {};
                states34[18].Transitions = new DfaTrans[0] {};
                states34[19].Transitions = new DfaTrans[1] {new DfaTrans(states34[19], sets[5])};
                states34[20].Transitions = new DfaTrans[0] {};
                states34[21].Transitions = new DfaTrans[0] {};
                
                /* dfa 35 -- '}' -- */
                var states35 = new DfaState[2] {new DfaState(0,false,-1), new DfaState(1,true,9)};
                states35[0].Transitions = new DfaTrans[1] {new DfaTrans(states35[1], sets[9])};
                states35[1].Transitions = new DfaTrans[0] {};
                
                /* dfa 36 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states36 = new DfaState[50] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,17), new DfaState(16,true,18), new DfaState(17,true,2), new DfaState(18,true,16), new DfaState(19,true,0), new DfaState(20,true,0), new DfaState(21,false,-1), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,true,4), new DfaState(35,false,-1), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,true,5), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,true,8), new DfaState(48,true,15), new DfaState(49,true,24)};
                states36[0].Transitions = new DfaTrans[13] {new DfaTrans(states36[1], sets[22]), new DfaTrans(states36[13], sets[23]), new DfaTrans(states36[14], sets[46]), new DfaTrans(states36[15], sets[41]), new DfaTrans(states36[16], sets[32]), new DfaTrans(states36[17], sets[24]), new DfaTrans(states36[18], sets[42]), new DfaTrans(states36[19], sets[25]), new DfaTrans(states36[20], sets[26]), new DfaTrans(states36[28], sets[27]), new DfaTrans(states36[47], sets[6]), new DfaTrans(states36[48], sets[40]), new DfaTrans(states36[49], sets[28])};
                states36[1].Transitions = new DfaTrans[2] {new DfaTrans(states36[2], sets[29]), new DfaTrans(states36[4], sets[27])};
                states36[2].Transitions = new DfaTrans[3] {new DfaTrans(states36[2], sets[29]), new DfaTrans(states36[3], sets[22]), new DfaTrans(states36[4], sets[27])};
                states36[3].Transitions = new DfaTrans[0] {};
                states36[4].Transitions = new DfaTrans[2] {new DfaTrans(states36[2], sets[30]), new DfaTrans(states36[5], sets[14])};
                states36[5].Transitions = new DfaTrans[1] {new DfaTrans(states36[6], sets[6])};
                states36[6].Transitions = new DfaTrans[1] {new DfaTrans(states36[7], sets[31])};
                states36[7].Transitions = new DfaTrans[2] {new DfaTrans(states36[8], sets[31]), new DfaTrans(states36[2], sets[9])};
                states36[8].Transitions = new DfaTrans[2] {new DfaTrans(states36[9], sets[31]), new DfaTrans(states36[2], sets[9])};
                states36[9].Transitions = new DfaTrans[2] {new DfaTrans(states36[10], sets[31]), new DfaTrans(states36[2], sets[9])};
                states36[10].Transitions = new DfaTrans[2] {new DfaTrans(states36[11], sets[31]), new DfaTrans(states36[2], sets[9])};
                states36[11].Transitions = new DfaTrans[2] {new DfaTrans(states36[12], sets[31]), new DfaTrans(states36[2], sets[9])};
                states36[12].Transitions = new DfaTrans[1] {new DfaTrans(states36[2], sets[9])};
                states36[13].Transitions = new DfaTrans[0] {};
                states36[14].Transitions = new DfaTrans[0] {};
                states36[15].Transitions = new DfaTrans[0] {};
                states36[16].Transitions = new DfaTrans[0] {};
                states36[17].Transitions = new DfaTrans[0] {};
                states36[18].Transitions = new DfaTrans[0] {};
                states36[19].Transitions = new DfaTrans[1] {new DfaTrans(states36[19], sets[5])};
                states36[20].Transitions = new DfaTrans[2] {new DfaTrans(states36[21], sets[32]), new DfaTrans(states36[19], sets[5])};
                states36[21].Transitions = new DfaTrans[1] {new DfaTrans(states36[22], sets[31])};
                states36[22].Transitions = new DfaTrans[1] {new DfaTrans(states36[23], sets[31])};
                states36[23].Transitions = new DfaTrans[1] {new DfaTrans(states36[24], sets[31])};
                states36[24].Transitions = new DfaTrans[1] {new DfaTrans(states36[25], sets[31])};
                states36[25].Transitions = new DfaTrans[1] {new DfaTrans(states36[26], sets[31])};
                states36[26].Transitions = new DfaTrans[1] {new DfaTrans(states36[27], sets[31])};
                states36[27].Transitions = new DfaTrans[0] {};
                states36[28].Transitions = new DfaTrans[1] {new DfaTrans(states36[29], sets[14])};
                states36[29].Transitions = new DfaTrans[3] {new DfaTrans(states36[30], sets[33]), new DfaTrans(states36[35], sets[34]), new DfaTrans(states36[40], sets[6])};
                states36[30].Transitions = new DfaTrans[1] {new DfaTrans(states36[31], sets[6])};
                states36[31].Transitions = new DfaTrans[1] {new DfaTrans(states36[32], sets[35])};
                states36[32].Transitions = new DfaTrans[3] {new DfaTrans(states36[33], sets[36]), new DfaTrans(states36[32], sets[37]), new DfaTrans(states36[34], sets[9])};
                states36[33].Transitions = new DfaTrans[2] {new DfaTrans(states36[33], sets[36]), new DfaTrans(states36[32], sets[37])};
                states36[34].Transitions = new DfaTrans[0] {};
                states36[35].Transitions = new DfaTrans[1] {new DfaTrans(states36[36], sets[6])};
                states36[36].Transitions = new DfaTrans[1] {new DfaTrans(states36[37], sets[35])};
                states36[37].Transitions = new DfaTrans[3] {new DfaTrans(states36[38], sets[36]), new DfaTrans(states36[37], sets[37]), new DfaTrans(states36[39], sets[9])};
                states36[38].Transitions = new DfaTrans[2] {new DfaTrans(states36[38], sets[36]), new DfaTrans(states36[37], sets[37])};
                states36[39].Transitions = new DfaTrans[0] {};
                states36[40].Transitions = new DfaTrans[1] {new DfaTrans(states36[41], sets[31])};
                states36[41].Transitions = new DfaTrans[2] {new DfaTrans(states36[42], sets[31]), new DfaTrans(states36[27], sets[9])};
                states36[42].Transitions = new DfaTrans[2] {new DfaTrans(states36[43], sets[31]), new DfaTrans(states36[27], sets[9])};
                states36[43].Transitions = new DfaTrans[2] {new DfaTrans(states36[44], sets[31]), new DfaTrans(states36[27], sets[9])};
                states36[44].Transitions = new DfaTrans[2] {new DfaTrans(states36[45], sets[31]), new DfaTrans(states36[27], sets[9])};
                states36[45].Transitions = new DfaTrans[2] {new DfaTrans(states36[46], sets[31]), new DfaTrans(states36[27], sets[9])};
                states36[46].Transitions = new DfaTrans[1] {new DfaTrans(states36[27], sets[9])};
                states36[47].Transitions = new DfaTrans[0] {};
                states36[48].Transitions = new DfaTrans[0] {};
                states36[49].Transitions = new DfaTrans[0] {};
                
                /* dfa 37 -- ˈtextˈ | '(' | ')' | ˈanyˈ | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '|' | '~' -- */
                var states37 = new DfaState[46] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,2), new DfaState(16,true,0), new DfaState(17,true,0), new DfaState(18,false,-1), new DfaState(19,true,6), new DfaState(20,true,6), new DfaState(21,true,6), new DfaState(22,true,6), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,false,-1), new DfaState(26,false,-1), new DfaState(27,false,-1), new DfaState(28,false,-1), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,true,4), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,false,-1), new DfaState(36,true,5), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,false,-1), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,true,15), new DfaState(45,true,24)};
                states37[0].Transitions = new DfaTrans[9] {new DfaTrans(states37[1], sets[22]), new DfaTrans(states37[13], sets[23]), new DfaTrans(states37[14], sets[46]), new DfaTrans(states37[15], sets[24]), new DfaTrans(states37[16], sets[25]), new DfaTrans(states37[17], sets[26]), new DfaTrans(states37[25], sets[27]), new DfaTrans(states37[44], sets[40]), new DfaTrans(states37[45], sets[28])};
                states37[1].Transitions = new DfaTrans[2] {new DfaTrans(states37[2], sets[29]), new DfaTrans(states37[4], sets[27])};
                states37[2].Transitions = new DfaTrans[3] {new DfaTrans(states37[2], sets[29]), new DfaTrans(states37[3], sets[22]), new DfaTrans(states37[4], sets[27])};
                states37[3].Transitions = new DfaTrans[0] {};
                states37[4].Transitions = new DfaTrans[2] {new DfaTrans(states37[2], sets[30]), new DfaTrans(states37[5], sets[14])};
                states37[5].Transitions = new DfaTrans[1] {new DfaTrans(states37[6], sets[6])};
                states37[6].Transitions = new DfaTrans[1] {new DfaTrans(states37[7], sets[31])};
                states37[7].Transitions = new DfaTrans[2] {new DfaTrans(states37[8], sets[31]), new DfaTrans(states37[2], sets[9])};
                states37[8].Transitions = new DfaTrans[2] {new DfaTrans(states37[9], sets[31]), new DfaTrans(states37[2], sets[9])};
                states37[9].Transitions = new DfaTrans[2] {new DfaTrans(states37[10], sets[31]), new DfaTrans(states37[2], sets[9])};
                states37[10].Transitions = new DfaTrans[2] {new DfaTrans(states37[11], sets[31]), new DfaTrans(states37[2], sets[9])};
                states37[11].Transitions = new DfaTrans[2] {new DfaTrans(states37[12], sets[31]), new DfaTrans(states37[2], sets[9])};
                states37[12].Transitions = new DfaTrans[1] {new DfaTrans(states37[2], sets[9])};
                states37[13].Transitions = new DfaTrans[0] {};
                states37[14].Transitions = new DfaTrans[0] {};
                states37[15].Transitions = new DfaTrans[0] {};
                states37[16].Transitions = new DfaTrans[1] {new DfaTrans(states37[16], sets[5])};
                states37[17].Transitions = new DfaTrans[2] {new DfaTrans(states37[18], sets[32]), new DfaTrans(states37[16], sets[5])};
                states37[18].Transitions = new DfaTrans[1] {new DfaTrans(states37[19], sets[31])};
                states37[19].Transitions = new DfaTrans[1] {new DfaTrans(states37[20], sets[31])};
                states37[20].Transitions = new DfaTrans[1] {new DfaTrans(states37[21], sets[31])};
                states37[21].Transitions = new DfaTrans[1] {new DfaTrans(states37[22], sets[31])};
                states37[22].Transitions = new DfaTrans[1] {new DfaTrans(states37[23], sets[31])};
                states37[23].Transitions = new DfaTrans[1] {new DfaTrans(states37[24], sets[31])};
                states37[24].Transitions = new DfaTrans[0] {};
                states37[25].Transitions = new DfaTrans[1] {new DfaTrans(states37[26], sets[14])};
                states37[26].Transitions = new DfaTrans[3] {new DfaTrans(states37[27], sets[33]), new DfaTrans(states37[32], sets[34]), new DfaTrans(states37[37], sets[6])};
                states37[27].Transitions = new DfaTrans[1] {new DfaTrans(states37[28], sets[6])};
                states37[28].Transitions = new DfaTrans[1] {new DfaTrans(states37[29], sets[35])};
                states37[29].Transitions = new DfaTrans[3] {new DfaTrans(states37[30], sets[36]), new DfaTrans(states37[29], sets[37]), new DfaTrans(states37[31], sets[9])};
                states37[30].Transitions = new DfaTrans[2] {new DfaTrans(states37[30], sets[36]), new DfaTrans(states37[29], sets[37])};
                states37[31].Transitions = new DfaTrans[0] {};
                states37[32].Transitions = new DfaTrans[1] {new DfaTrans(states37[33], sets[6])};
                states37[33].Transitions = new DfaTrans[1] {new DfaTrans(states37[34], sets[35])};
                states37[34].Transitions = new DfaTrans[3] {new DfaTrans(states37[35], sets[36]), new DfaTrans(states37[34], sets[37]), new DfaTrans(states37[36], sets[9])};
                states37[35].Transitions = new DfaTrans[2] {new DfaTrans(states37[35], sets[36]), new DfaTrans(states37[34], sets[37])};
                states37[36].Transitions = new DfaTrans[0] {};
                states37[37].Transitions = new DfaTrans[1] {new DfaTrans(states37[38], sets[31])};
                states37[38].Transitions = new DfaTrans[2] {new DfaTrans(states37[39], sets[31]), new DfaTrans(states37[24], sets[9])};
                states37[39].Transitions = new DfaTrans[2] {new DfaTrans(states37[40], sets[31]), new DfaTrans(states37[24], sets[9])};
                states37[40].Transitions = new DfaTrans[2] {new DfaTrans(states37[41], sets[31]), new DfaTrans(states37[24], sets[9])};
                states37[41].Transitions = new DfaTrans[2] {new DfaTrans(states37[42], sets[31]), new DfaTrans(states37[24], sets[9])};
                states37[42].Transitions = new DfaTrans[2] {new DfaTrans(states37[43], sets[31]), new DfaTrans(states37[24], sets[9])};
                states37[43].Transitions = new DfaTrans[1] {new DfaTrans(states37[24], sets[9])};
                states37[44].Transitions = new DfaTrans[0] {};
                states37[45].Transitions = new DfaTrans[0] {};
                
                /* dfa 38 -- ˈtextˈ | '(' | ')' | '*' | '+' | ˈanyˈ | '..' | '?' | ˈidentifierˈ | ˈucCodepointˈ | ˈucBlockˈ | ˈucCategoryˈ | '{' | '|' | '~' -- */
                var states38 = new DfaState[51] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,21), new DfaState(15,true,17), new DfaState(16,true,18), new DfaState(17,true,2), new DfaState(18,true,25), new DfaState(19,true,16), new DfaState(20,true,0), new DfaState(21,true,0), new DfaState(22,false,-1), new DfaState(23,true,6), new DfaState(24,true,6), new DfaState(25,true,6), new DfaState(26,true,6), new DfaState(27,true,6), new DfaState(28,true,6), new DfaState(29,false,-1), new DfaState(30,false,-1), new DfaState(31,false,-1), new DfaState(32,false,-1), new DfaState(33,false,-1), new DfaState(34,false,-1), new DfaState(35,true,4), new DfaState(36,false,-1), new DfaState(37,false,-1), new DfaState(38,false,-1), new DfaState(39,false,-1), new DfaState(40,true,5), new DfaState(41,false,-1), new DfaState(42,false,-1), new DfaState(43,false,-1), new DfaState(44,false,-1), new DfaState(45,false,-1), new DfaState(46,false,-1), new DfaState(47,false,-1), new DfaState(48,true,8), new DfaState(49,true,15), new DfaState(50,true,24)};
                states38[0].Transitions = new DfaTrans[13] {new DfaTrans(states38[1], sets[22]), new DfaTrans(states38[13], sets[23]), new DfaTrans(states38[14], sets[46]), new DfaTrans(states38[15], sets[41]), new DfaTrans(states38[16], sets[32]), new DfaTrans(states38[17], sets[24]), new DfaTrans(states38[19], sets[42]), new DfaTrans(states38[20], sets[25]), new DfaTrans(states38[21], sets[26]), new DfaTrans(states38[29], sets[27]), new DfaTrans(states38[48], sets[6]), new DfaTrans(states38[49], sets[40]), new DfaTrans(states38[50], sets[28])};
                states38[1].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[29]), new DfaTrans(states38[4], sets[27])};
                states38[2].Transitions = new DfaTrans[3] {new DfaTrans(states38[2], sets[29]), new DfaTrans(states38[3], sets[22]), new DfaTrans(states38[4], sets[27])};
                states38[3].Transitions = new DfaTrans[0] {};
                states38[4].Transitions = new DfaTrans[2] {new DfaTrans(states38[2], sets[30]), new DfaTrans(states38[5], sets[14])};
                states38[5].Transitions = new DfaTrans[1] {new DfaTrans(states38[6], sets[6])};
                states38[6].Transitions = new DfaTrans[1] {new DfaTrans(states38[7], sets[31])};
                states38[7].Transitions = new DfaTrans[2] {new DfaTrans(states38[8], sets[31]), new DfaTrans(states38[2], sets[9])};
                states38[8].Transitions = new DfaTrans[2] {new DfaTrans(states38[9], sets[31]), new DfaTrans(states38[2], sets[9])};
                states38[9].Transitions = new DfaTrans[2] {new DfaTrans(states38[10], sets[31]), new DfaTrans(states38[2], sets[9])};
                states38[10].Transitions = new DfaTrans[2] {new DfaTrans(states38[11], sets[31]), new DfaTrans(states38[2], sets[9])};
                states38[11].Transitions = new DfaTrans[2] {new DfaTrans(states38[12], sets[31]), new DfaTrans(states38[2], sets[9])};
                states38[12].Transitions = new DfaTrans[1] {new DfaTrans(states38[2], sets[9])};
                states38[13].Transitions = new DfaTrans[0] {};
                states38[14].Transitions = new DfaTrans[0] {};
                states38[15].Transitions = new DfaTrans[0] {};
                states38[16].Transitions = new DfaTrans[0] {};
                states38[17].Transitions = new DfaTrans[1] {new DfaTrans(states38[18], sets[24])};
                states38[18].Transitions = new DfaTrans[0] {};
                states38[19].Transitions = new DfaTrans[0] {};
                states38[20].Transitions = new DfaTrans[1] {new DfaTrans(states38[20], sets[5])};
                states38[21].Transitions = new DfaTrans[2] {new DfaTrans(states38[22], sets[32]), new DfaTrans(states38[20], sets[5])};
                states38[22].Transitions = new DfaTrans[1] {new DfaTrans(states38[23], sets[31])};
                states38[23].Transitions = new DfaTrans[1] {new DfaTrans(states38[24], sets[31])};
                states38[24].Transitions = new DfaTrans[1] {new DfaTrans(states38[25], sets[31])};
                states38[25].Transitions = new DfaTrans[1] {new DfaTrans(states38[26], sets[31])};
                states38[26].Transitions = new DfaTrans[1] {new DfaTrans(states38[27], sets[31])};
                states38[27].Transitions = new DfaTrans[1] {new DfaTrans(states38[28], sets[31])};
                states38[28].Transitions = new DfaTrans[0] {};
                states38[29].Transitions = new DfaTrans[1] {new DfaTrans(states38[30], sets[14])};
                states38[30].Transitions = new DfaTrans[3] {new DfaTrans(states38[31], sets[33]), new DfaTrans(states38[36], sets[34]), new DfaTrans(states38[41], sets[6])};
                states38[31].Transitions = new DfaTrans[1] {new DfaTrans(states38[32], sets[6])};
                states38[32].Transitions = new DfaTrans[1] {new DfaTrans(states38[33], sets[35])};
                states38[33].Transitions = new DfaTrans[3] {new DfaTrans(states38[34], sets[36]), new DfaTrans(states38[33], sets[37]), new DfaTrans(states38[35], sets[9])};
                states38[34].Transitions = new DfaTrans[2] {new DfaTrans(states38[34], sets[36]), new DfaTrans(states38[33], sets[37])};
                states38[35].Transitions = new DfaTrans[0] {};
                states38[36].Transitions = new DfaTrans[1] {new DfaTrans(states38[37], sets[6])};
                states38[37].Transitions = new DfaTrans[1] {new DfaTrans(states38[38], sets[35])};
                states38[38].Transitions = new DfaTrans[3] {new DfaTrans(states38[39], sets[36]), new DfaTrans(states38[38], sets[37]), new DfaTrans(states38[40], sets[9])};
                states38[39].Transitions = new DfaTrans[2] {new DfaTrans(states38[39], sets[36]), new DfaTrans(states38[38], sets[37])};
                states38[40].Transitions = new DfaTrans[0] {};
                states38[41].Transitions = new DfaTrans[1] {new DfaTrans(states38[42], sets[31])};
                states38[42].Transitions = new DfaTrans[2] {new DfaTrans(states38[43], sets[31]), new DfaTrans(states38[28], sets[9])};
                states38[43].Transitions = new DfaTrans[2] {new DfaTrans(states38[44], sets[31]), new DfaTrans(states38[28], sets[9])};
                states38[44].Transitions = new DfaTrans[2] {new DfaTrans(states38[45], sets[31]), new DfaTrans(states38[28], sets[9])};
                states38[45].Transitions = new DfaTrans[2] {new DfaTrans(states38[46], sets[31]), new DfaTrans(states38[28], sets[9])};
                states38[46].Transitions = new DfaTrans[2] {new DfaTrans(states38[47], sets[31]), new DfaTrans(states38[28], sets[9])};
                states38[47].Transitions = new DfaTrans[1] {new DfaTrans(states38[28], sets[9])};
                states38[48].Transitions = new DfaTrans[0] {};
                states38[49].Transitions = new DfaTrans[0] {};
                states38[50].Transitions = new DfaTrans[0] {};
                
                /* dfa 39 -- ˈtextˈ | '(' | ',' | ˈidentifierˈ | '{' | '|' | '}' -- */
                var states39 = new DfaState[19] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,19), new DfaState(15,true,0), new DfaState(16,true,8), new DfaState(17,true,15), new DfaState(18,true,9)};
                states39[0].Transitions = new DfaTrans[7] {new DfaTrans(states39[1], sets[22]), new DfaTrans(states39[13], sets[23]), new DfaTrans(states39[14], sets[39]), new DfaTrans(states39[15], sets[4]), new DfaTrans(states39[16], sets[6]), new DfaTrans(states39[17], sets[40]), new DfaTrans(states39[18], sets[9])};
                states39[1].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[29]), new DfaTrans(states39[4], sets[27])};
                states39[2].Transitions = new DfaTrans[3] {new DfaTrans(states39[2], sets[29]), new DfaTrans(states39[3], sets[22]), new DfaTrans(states39[4], sets[27])};
                states39[3].Transitions = new DfaTrans[0] {};
                states39[4].Transitions = new DfaTrans[2] {new DfaTrans(states39[2], sets[30]), new DfaTrans(states39[5], sets[14])};
                states39[5].Transitions = new DfaTrans[1] {new DfaTrans(states39[6], sets[6])};
                states39[6].Transitions = new DfaTrans[1] {new DfaTrans(states39[7], sets[31])};
                states39[7].Transitions = new DfaTrans[2] {new DfaTrans(states39[8], sets[31]), new DfaTrans(states39[2], sets[9])};
                states39[8].Transitions = new DfaTrans[2] {new DfaTrans(states39[9], sets[31]), new DfaTrans(states39[2], sets[9])};
                states39[9].Transitions = new DfaTrans[2] {new DfaTrans(states39[10], sets[31]), new DfaTrans(states39[2], sets[9])};
                states39[10].Transitions = new DfaTrans[2] {new DfaTrans(states39[11], sets[31]), new DfaTrans(states39[2], sets[9])};
                states39[11].Transitions = new DfaTrans[2] {new DfaTrans(states39[12], sets[31]), new DfaTrans(states39[2], sets[9])};
                states39[12].Transitions = new DfaTrans[1] {new DfaTrans(states39[2], sets[9])};
                states39[13].Transitions = new DfaTrans[0] {};
                states39[14].Transitions = new DfaTrans[0] {};
                states39[15].Transitions = new DfaTrans[1] {new DfaTrans(states39[15], sets[5])};
                states39[16].Transitions = new DfaTrans[0] {};
                states39[17].Transitions = new DfaTrans[0] {};
                states39[18].Transitions = new DfaTrans[0] {};
                
                /* dfa 40 -- '|' | '}' -- */
                var states40 = new DfaState[3] {new DfaState(0,false,-1), new DfaState(1,true,15), new DfaState(2,true,9)};
                states40[0].Transitions = new DfaTrans[2] {new DfaTrans(states40[1], sets[40]), new DfaTrans(states40[2], sets[9])};
                states40[1].Transitions = new DfaTrans[0] {};
                states40[2].Transitions = new DfaTrans[0] {};
                
                /* dfa 41 -- ˈtextˈ | '(' | '*' | '+' | ',' | '?' | ˈidentifierˈ | '{' | '|' | '}' -- */
                var states41 = new DfaState[22] {new DfaState(0,false,-1), new DfaState(1,false,-1), new DfaState(2,false,-1), new DfaState(3,true,3), new DfaState(4,false,-1), new DfaState(5,false,-1), new DfaState(6,false,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,false,-1), new DfaState(12,false,-1), new DfaState(13,true,20), new DfaState(14,true,17), new DfaState(15,true,18), new DfaState(16,true,19), new DfaState(17,true,16), new DfaState(18,true,0), new DfaState(19,true,8), new DfaState(20,true,15), new DfaState(21,true,9)};
                states41[0].Transitions = new DfaTrans[10] {new DfaTrans(states41[1], sets[22]), new DfaTrans(states41[13], sets[23]), new DfaTrans(states41[14], sets[41]), new DfaTrans(states41[15], sets[32]), new DfaTrans(states41[16], sets[39]), new DfaTrans(states41[17], sets[42]), new DfaTrans(states41[18], sets[4]), new DfaTrans(states41[19], sets[6]), new DfaTrans(states41[20], sets[40]), new DfaTrans(states41[21], sets[9])};
                states41[1].Transitions = new DfaTrans[2] {new DfaTrans(states41[2], sets[29]), new DfaTrans(states41[4], sets[27])};
                states41[2].Transitions = new DfaTrans[3] {new DfaTrans(states41[2], sets[29]), new DfaTrans(states41[3], sets[22]), new DfaTrans(states41[4], sets[27])};
                states41[3].Transitions = new DfaTrans[0] {};
                states41[4].Transitions = new DfaTrans[2] {new DfaTrans(states41[2], sets[30]), new DfaTrans(states41[5], sets[14])};
                states41[5].Transitions = new DfaTrans[1] {new DfaTrans(states41[6], sets[6])};
                states41[6].Transitions = new DfaTrans[1] {new DfaTrans(states41[7], sets[31])};
                states41[7].Transitions = new DfaTrans[2] {new DfaTrans(states41[8], sets[31]), new DfaTrans(states41[2], sets[9])};
                states41[8].Transitions = new DfaTrans[2] {new DfaTrans(states41[9], sets[31]), new DfaTrans(states41[2], sets[9])};
                states41[9].Transitions = new DfaTrans[2] {new DfaTrans(states41[10], sets[31]), new DfaTrans(states41[2], sets[9])};
                states41[10].Transitions = new DfaTrans[2] {new DfaTrans(states41[11], sets[31]), new DfaTrans(states41[2], sets[9])};
                states41[11].Transitions = new DfaTrans[2] {new DfaTrans(states41[12], sets[31]), new DfaTrans(states41[2], sets[9])};
                states41[12].Transitions = new DfaTrans[1] {new DfaTrans(states41[2], sets[9])};
                states41[13].Transitions = new DfaTrans[0] {};
                states41[14].Transitions = new DfaTrans[0] {};
                states41[15].Transitions = new DfaTrans[0] {};
                states41[16].Transitions = new DfaTrans[0] {};
                states41[17].Transitions = new DfaTrans[0] {};
                states41[18].Transitions = new DfaTrans[1] {new DfaTrans(states41[18], sets[5])};
                states41[19].Transitions = new DfaTrans[0] {};
                states41[20].Transitions = new DfaTrans[0] {};
                states41[21].Transitions = new DfaTrans[0] {};
                
                /* dfa 42 --  -- */
                var states42 = new DfaState[12] {new DfaState(0,true,-1), new DfaState(1,false,-1), new DfaState(2,true,-1), new DfaState(3,true,-1), new DfaState(4,true,-1), new DfaState(5,true,-1), new DfaState(6,true,-1), new DfaState(7,false,-1), new DfaState(8,false,-1), new DfaState(9,false,-1), new DfaState(10,false,-1), new DfaState(11,true,-1)};
                states42[0].Transitions = new DfaTrans[2] {new DfaTrans(states42[0], sets[47]), new DfaTrans(states42[1], sets[48])};
                states42[1].Transitions = new DfaTrans[2] {new DfaTrans(states42[2], sets[48]), new DfaTrans(states42[9], sets[41])};
                states42[2].Transitions = new DfaTrans[3] {new DfaTrans(states42[2], sets[49]), new DfaTrans(states42[0], sets[50]), new DfaTrans(states42[3], sets[48])};
                states42[3].Transitions = new DfaTrans[4] {new DfaTrans(states42[2], sets[51]), new DfaTrans(states42[0], sets[50]), new DfaTrans(states42[3], sets[48]), new DfaTrans(states42[4], sets[41])};
                states42[4].Transitions = new DfaTrans[4] {new DfaTrans(states42[5], sets[41]), new DfaTrans(states42[6], sets[50]), new DfaTrans(states42[4], sets[51]), new DfaTrans(states42[11], sets[48])};
                states42[5].Transitions = new DfaTrans[3] {new DfaTrans(states42[4], sets[49]), new DfaTrans(states42[6], sets[50]), new DfaTrans(states42[3], sets[48])};
                states42[6].Transitions = new DfaTrans[4] {new DfaTrans(states42[6], sets[47]), new DfaTrans(states42[7], sets[48]), new DfaTrans(states42[9], sets[52]), new DfaTrans(states42[10], sets[41])};
                states42[7].Transitions = new DfaTrans[3] {new DfaTrans(states42[4], sets[48]), new DfaTrans(states42[8], sets[41]), new DfaTrans(states42[9], sets[53])};
                states42[8].Transitions = new DfaTrans[3] {new DfaTrans(states42[9], sets[53]), new DfaTrans(states42[8], sets[41]), new DfaTrans(states42[6], sets[48])};
                states42[9].Transitions = new DfaTrans[2] {new DfaTrans(states42[9], sets[54]), new DfaTrans(states42[10], sets[41])};
                states42[10].Transitions = new DfaTrans[2] {new DfaTrans(states42[0], sets[48]), new DfaTrans(states42[9], sets[55])};
                states42[11].Transitions = new DfaTrans[3] {new DfaTrans(states42[4], sets[51]), new DfaTrans(states42[6], sets[50]), new DfaTrans(states42[11], sets[56])};
                
                var dfas = new Dfa[]
                {
                    new Dfa(states0), new Dfa(states1), new Dfa(states2), new Dfa(states3), new Dfa(states4), new Dfa(states5),
                    new Dfa(states6), new Dfa(states7), new Dfa(states8), new Dfa(states9), new Dfa(states10), new Dfa(states11),
                    new Dfa(states12), new Dfa(states13), new Dfa(states14), new Dfa(states15), new Dfa(states16), new Dfa(states17),
                    new Dfa(states18), new Dfa(states19), new Dfa(states20), new Dfa(states21), new Dfa(states22), new Dfa(states23),
                    new Dfa(states24), new Dfa(states25), new Dfa(states26), new Dfa(states27), new Dfa(states28), new Dfa(states29),
                    new Dfa(states30), new Dfa(states31), new Dfa(states32), new Dfa(states33), new Dfa(states34), new Dfa(states35),
                    new Dfa(states36), new Dfa(states37), new Dfa(states38), new Dfa(states39), new Dfa(states40), new Dfa(states41),
                    new Dfa(states42),
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
                    0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 222, 45, 0, 0, 49, 0, 0, 0, 0, 0, 0, 0, 0,
                    53, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 37,
                    0, 0, 0, 0, 0, 0, 41, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 122, 122,
                    0, 0, 122, 0, 0, 0, 0, 0, 0, 0, 0, 122, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 126, 126, 0, 0, 126, 0, 0, 0, 0, 0, 0, 0, 0, 126, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 130, 130, 0, 0, 130, 0, 0, 0, 0, 0, 0, 0,
                    0, 130, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 218,
                    218, 0, 0, 218, 0, 0, 0, 0, 0, 0, 0, 0, 218, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 61, 45, 0, 0, 49, 0, 0, 0, 0, 0, 0, 0, 0, 53, 0, 0, 0, 0, 0, 0, 0, 0, 25,
                    0, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 57, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 69, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 73, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 214, 214, 0, 0, 214, 0, 0, 0, 0, 0, 0, 0, 0, 214, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 85, 0, 0, 0, 0, 0, 0, 0,
                    0, 234, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 77, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 97, 0, 0, 0, 0, 0, 0, 0, 0, 246, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 89, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 93,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 109, 0, 0, 0, 0, 0, 0, 0, 0, 314, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 101, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 105, 0, 0, 0, 0, 0, 0, 230, 0, 0, 0, 0, 0, 0, 0, 0,
                    230, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 85, 0, 0, 0, 0, 0, 0, 0, 0, 117, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    113, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 121, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0, 0, 0, 0, 0, 0, 0, 0, 242, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 97, 0,
                    0, 0, 0, 0, 0, 0, 0, 129, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 137, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 254, 254, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 133, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 310, 0, 0, 0, 0, 0, 0, 0, 0, 310, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 109, 0, 0,
                    0, 0, 0, 0, 0, 0, 145, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 141, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    153, 157, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 149, 0, 0, 0, 0, 0, 226, 0, 0, 0, 0, 0, 0, 0, 0, 226, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 14, 14, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 161, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 0, 0, 0, 0, 0, 0, 0, 238, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    22, 22, 0, 0, 22, 0, 0, 0, 0, 0, 0, 0, 0, 22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 169, 173, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 165,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 250, 250, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 306, 0, 0, 0, 0, 0, 0, 0, 0, 306, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 78, 78, 0, 0, 78, 0, 0, 0, 0, 0, 0, 0, 0, 78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 217, 0, 221, 225, 229, 233, 237, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 241, 0,
                    0, 0, 245, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 177, 0, 0, 181, 185, 189, 193, 197,
                    201, 205, 0, 0, 0, 0, 0, 0, 209, 213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 318, 0, 318, 318,
                    318, 318, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 318, 0, 0, 0, 318, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 322, 0, 322, 322, 322, 322, 322, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 322,
                    0, 0, 0, 322, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 249, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294,
                    0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 286, 0, 0, 286, 0, 0, 0, 293, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 253, 257, 261, 265, 269, 273, 277, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 281, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 285, 289, 0, 0, 0, 0, 0, 0, 0, 0, 258, 0, 0, 258, 0, 0, 0, 0, 258, 0, 0, 0, 258,
                    0, 0, 258, 0, 0, 0, 258, 258, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 262,
                    0, 0, 262, 0, 0, 0, 0, 262, 0, 0, 0, 262, 0, 0, 262, 0, 0, 0, 262, 262, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 210, 0, 0, 210,
                    210, 210, 210, 0, 210, 0, 0, 210, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 297, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 0, 334, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 301, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 342, 0, 0, 342,
                    0, 0, 0, 0, 0, 0, 0, 313, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 309, 0, 0, 0, 217, 0, 221, 225,
                    229, 233, 237, 0, 0, 0, 0, 0, 354, 0, 0, 354, 0, 0, 0, 0, 241, 0, 0, 354, 245, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 177, 0, 0, 0, 0, 0, 317, 197, 201, 205, 0, 0, 0, 0, 0, 0, 209, 213, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 321, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 178, 0, 0, 0, 178,
                    0, 0, 178, 178, 178, 178, 0, 178, 0, 0, 178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 194, 0, 194, 194, 194, 194, 194, 0, 194, 0, 0, 0, 194, 0, 0, 194, 194, 194, 194, 0, 194, 0, 0, 194,
                    194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 325, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 362,
                    362, 362, 362, 362, 0, 341, 0, 0, 0, 362, 0, 0, 362, 345, 349, 353, 0, 362, 0, 0, 362, 362, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 329, 0, 0, 0, 0, 333, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 337, 0, 174, 0, 174, 174, 174, 174, 174, 0, 174, 0, 0, 0, 174,
                    0, 0, 174, 174, 174, 174, 0, 174, 0, 0, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 74, 0, 74, 74, 74, 74, 74, 0, 74, 0, 0, 0, 74, 0, 0, 74, 74, 74, 74, 0, 74, 0, 0, 74, 74, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 186, 0, 0, 0, 186, 0,
                    0, 186, 186, 186, 186, 0, 186, 0, 0, 186, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    190, 0, 190, 190, 190, 190, 190, 0, 190, 0, 0, 0, 190, 0, 0, 190, 190, 190, 190, 0, 190, 0, 0, 190, 190,
                    114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0, 202, 0,
                    0, 0, 202, 0, 0, 202, 202, 202, 202, 0, 202, 0, 0, 202, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 206, 0, 0, 206, 206, 206, 206, 0, 206,
                    0, 0, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198,
                    0, 198, 0, 0, 0, 198, 0, 0, 198, 198, 198, 198, 0, 198, 0, 0, 198, 198, 110, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409, 413, 417, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 421,
                    0, 0, 0, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 357, 0, 0, 361, 365, 369, 373, 377,
                    381, 385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 217, 0, 221, 225,
                    229, 233, 237, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 177, 0, 0, 0, 0, 0, 0, 0, 201, 205, 0, 0, 0, 0, 0, 0, 0, 429, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 433,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 134, 0, 0, 134, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 282, 0, 0, 282, 0, 0, 0, 0, 282, 0, 0, 0, 282, 0, 0, 282, 0, 0, 0, 282, 282, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 42, 0, 0, 42, 0, 0, 0, 0, 42, 0, 0, 0, 42,
                    0, 0, 42, 0, 0, 0, 42, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0,
                    46, 0, 0, 0, 0, 46, 0, 0, 0, 46, 0, 0, 46, 0, 0, 0, 46, 46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 50, 0, 0, 0, 0, 50, 0, 0, 0, 50, 0, 0, 50, 0, 0, 0, 50, 50, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 0, 0, 38, 0, 0, 0, 0, 38, 0, 0, 0, 38, 0,
                    0, 38, 437, 441, 445, 38, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 274, 0, 0, 274, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 449, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 34, 0, 0, 34, 0, 0, 0, 293, 294,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 457, 265, 269, 273, 277, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 289, 0, 0, 0, 0, 0, 0, 0, 0, 477, 0, 0, 481, 0, 0, 0,
                    0, 485, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 489, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 461, 465, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 469, 473, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 290, 0, 0, 290, 0, 0, 0, 0, 290, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 290, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 0, 0, 0, 0, 0, 0, 82, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 86, 0, 0, 493, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 217, 0, 221, 225, 229, 233, 237, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 241, 0, 0, 0, 245,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 177, 0, 0, 0, 497, 189, 193, 197, 201, 205, 0,
                    0, 0, 0, 0, 0, 209, 213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 90, 0, 0, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    533, 0, 537, 541, 545, 549, 553, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 557, 0, 0, 0, 561, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 501, 0, 0, 0, 0, 505, 509, 513, 517, 521, 0, 0, 0, 0, 0, 0,
                    525, 529, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 350, 0, 350, 350, 350, 350, 350, 0, 0, 0, 0,
                    0, 350, 0, 0, 350, 0, 0, 0, 0, 350, 0, 0, 350, 350, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 217, 0, 221, 225, 229, 233, 237, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0, 0, 0, 241, 0, 0, 94, 245, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 177, 0, 0, 0, 0, 0, 565, 197, 201, 205, 0, 0, 0, 0, 0,
                    0, 209, 213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 573, 0, 0, 577, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 569, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0,
                    170, 170, 170, 170, 170, 0, 0, 0, 0, 0, 170, 0, 0, 170, 0, 0, 0, 0, 170, 0, 0, 170, 170, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 358, 358, 358, 358, 358, 0, 0, 0, 0, 0, 358, 0, 0,
                    358, 0, 0, 0, 0, 358, 0, 0, 358, 358, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 98, 0, 98,
                    98, 98, 98, 98, 0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 98, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 581, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 158, 158, 158, 158, 158, 0, 0, 0, 0,
                    0, 158, 0, 0, 158, 0, 0, 0, 0, 158, 0, 0, 158, 158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 162, 0, 162, 162, 162, 162, 162, 0, 0, 0, 0, 0, 162, 0, 0, 162, 0, 0, 0, 0, 162, 0, 0, 162, 162, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 166,
                    0, 0, 166, 0, 0, 0, 0, 166, 0, 0, 166, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210,
                    0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 0, 0, 210, 210, 210, 210, 0, 210, 210, 0, 210, 210, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 585, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 334, 0, 0, 0, 0, 0, 334, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 589,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 342, 0, 0, 0, 0, 0, 342, 0, 601, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 597, 0, 0, 0, 397, 0, 401, 405, 409, 413, 417, 0, 0, 0, 0, 0, 0, 0,
                    0, 354, 0, 0, 0, 0, 421, 354, 0, 354, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 357,
                    0, 0, 0, 0, 0, 605, 377, 381, 385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    609, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 178, 0, 0, 0, 0, 0, 0, 178, 178, 178, 178, 0, 178, 178,
                    0, 178, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0,
                    194, 0, 0, 0, 0, 0, 0, 194, 194, 194, 194, 0, 194, 194, 0, 194, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 613,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362, 0, 362, 362, 362, 362, 362, 0, 629, 0, 0, 0,
                    0, 0, 0, 362, 633, 637, 641, 0, 362, 362, 0, 362, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 617, 0, 0, 0, 0, 621, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 625, 0, 174, 0, 174, 174, 174, 174, 174, 0, 174, 0, 0, 0, 0, 0, 0, 174, 174, 174, 174, 0, 174, 174,
                    0, 174, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 74, 0, 74, 74, 74, 74, 74, 0, 74, 0,
                    0, 0, 0, 0, 0, 74, 74, 74, 74, 0, 74, 74, 0, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 186, 0, 0, 0, 0, 0, 0, 186, 186, 186, 186, 0, 186, 186, 0,
                    186, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 190,
                    0, 0, 0, 0, 0, 0, 190, 190, 190, 190, 0, 190, 190, 0, 190, 190, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0, 202, 0, 0, 0, 0, 0, 0, 202, 202, 202, 202, 0, 202,
                    202, 0, 202, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206,
                    0, 206, 0, 0, 0, 0, 0, 0, 206, 206, 206, 206, 0, 206, 206, 0, 206, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198, 0, 198, 0, 0, 0, 0, 0, 0, 198, 198, 198, 198,
                    0, 198, 198, 0, 198, 198, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409,
                    413, 417, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 421, 0, 0, 0, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 357, 0, 0, 645, 365, 369, 373, 377, 381, 385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409, 413, 417, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 357, 0, 0, 0, 0, 0,
                    0, 0, 381, 385, 0, 0, 0, 0, 0, 0, 0, 649, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 102,
                    102, 102, 102, 102, 0, 102, 0, 0, 0, 102, 0, 0, 102, 102, 102, 102, 0, 102, 0, 0, 102, 102, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0, 26, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 0,
                    54, 0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 54, 54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 58, 58, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 0, 0, 0, 62, 0, 0, 62, 0, 0,
                    0, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 30, 0, 0, 653, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 286, 0, 0, 286, 0, 0, 0, 293, 294, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 257, 261, 265, 269, 273, 277, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 657,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 285, 289, 0, 0, 0, 0, 0, 0, 0, 0, 278, 0, 0, 278, 0, 0, 0, 0, 278, 0,
                    0, 0, 278, 0, 0, 278, 0, 0, 0, 278, 278, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138, 0, 0, 0, 138, 0, 0, 138, 138, 138, 138, 138, 138, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0, 150, 0, 0, 0, 0, 150, 0, 0, 0, 150,
                    0, 0, 150, 150, 150, 150, 150, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    66, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0, 66, 0, 0, 66, 66, 66, 66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 146, 0, 0, 146, 0, 0, 0, 0, 146, 0, 0, 0, 146, 0, 0, 146, 146, 146,
                    146, 146, 146, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0,
                    0, 0, 74, 0, 0, 0, 74, 0, 0, 74, 74, 74, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 154, 0, 0, 154, 0, 0, 0, 0, 154, 0, 0, 0, 154, 0, 0, 154, 154, 154, 154, 154, 154,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 661, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294,
                    0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 0, 0, 0, 286, 0, 0, 0, 293, 294, 286, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 665, 669, 673, 677, 681, 685, 689, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 693, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 697, 701, 0, 0, 0, 0, 0, 0, 0, 0, 217, 0, 221, 225, 229, 233, 237, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 241, 0, 0, 0, 245, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 177,
                    0, 0, 0, 705, 189, 193, 197, 201, 205, 0, 0, 0, 0, 0, 0, 209, 213, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 210, 0, 0,
                    210, 210, 210, 210, 0, 210, 0, 0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 338, 0, 0, 338, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 533, 0, 537, 541, 545, 549, 553, 0, 0, 0, 0, 0, 354, 0, 0, 354, 0, 0, 0, 0, 557,
                    0, 0, 0, 561, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 501, 0, 0, 0, 0, 0, 709, 513, 517,
                    521, 0, 0, 0, 0, 0, 0, 525, 529, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 713, 0, 0, 178, 0, 178, 178,
                    178, 178, 178, 0, 178, 0, 0, 0, 178, 0, 0, 178, 178, 178, 178, 0, 178, 0, 0, 0, 178, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0, 194, 0, 0, 0, 194, 0, 0, 194,
                    194, 194, 194, 0, 194, 0, 0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 717, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 362, 0, 362, 362, 362, 362, 362, 0, 733, 0, 0, 0, 362, 0, 0, 362, 737, 741, 745, 0,
                    362, 0, 0, 0, 362, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    721, 0, 0, 0, 0, 725, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 729, 0, 174, 0, 174, 174, 174,
                    174, 174, 0, 174, 0, 0, 0, 174, 0, 0, 174, 174, 174, 174, 0, 174, 0, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 74, 0, 74, 74, 74, 74, 74, 0, 74, 0, 0, 0, 74, 0, 0, 74, 74, 74, 74,
                    0, 74, 0, 0, 0, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186,
                    186, 0, 186, 0, 0, 0, 186, 0, 0, 186, 186, 186, 186, 0, 186, 0, 0, 0, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 190, 0, 0, 0, 190, 0, 0, 190, 190, 190,
                    190, 0, 190, 0, 0, 0, 190, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202,
                    202, 202, 202, 0, 202, 0, 0, 0, 202, 0, 0, 202, 202, 202, 202, 0, 202, 0, 0, 0, 202, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 206, 0, 0, 206,
                    206, 206, 206, 0, 206, 0, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198,
                    198, 198, 198, 198, 0, 198, 0, 0, 0, 198, 0, 0, 198, 198, 198, 198, 0, 198, 0, 0, 0, 198, 110, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409, 413, 417, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 421, 0, 0, 0, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 357, 0, 0, 749,
                    365, 369, 373, 377, 381, 385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 533, 0, 537, 541, 545, 549, 553, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 501, 0, 0, 0, 0, 0, 0, 0, 517, 521, 0, 0, 0, 0, 0, 0, 0, 753,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 346, 0, 346, 346, 346, 346, 346, 0, 0, 0, 0, 0, 346,
                    0, 0, 346, 0, 0, 0, 0, 346, 0, 0, 346, 346, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 106,
                    0, 106, 106, 106, 106, 106, 0, 106, 0, 0, 0, 106, 0, 0, 106, 106, 106, 106, 0, 106, 0, 0, 106, 106, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 114, 114, 114, 114, 114, 0, 114, 0, 0, 0,
                    114, 0, 0, 114, 114, 114, 114, 0, 114, 0, 0, 114, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 110, 0, 110, 110, 110, 110, 110, 0, 110, 0, 0, 0, 110, 0, 0, 110, 110, 110, 110, 0, 110, 0, 0,
                    110, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 761, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 757, 182,
                    0, 182, 182, 182, 182, 182, 0, 182, 0, 0, 0, 182, 0, 0, 182, 182, 182, 182, 0, 182, 0, 0, 182, 182, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 765,
                    0, 0, 0, 0, 0, 86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409,
                    413, 417, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 421, 0, 0, 0, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 357, 0, 0, 0, 769, 369, 373, 377, 381, 385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 90, 0, 0, 0, 0, 0,
                    90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 805, 0, 809, 813, 817, 821, 825, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 829, 0, 0, 0, 833, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 773, 0, 0, 0, 0, 777, 781, 785, 789, 793, 0, 0, 0, 0, 0, 0, 797, 801, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 350, 0, 350, 350, 350, 350, 350, 0, 0, 0, 0, 0, 0, 0, 0, 350, 0, 0, 0, 0, 350, 350,
                    0, 350, 350, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409, 413, 417, 0,
                    0, 0, 0, 0, 0, 0, 0, 94, 0, 0, 0, 0, 421, 94, 0, 94, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 357, 0, 0, 0, 0, 0, 837, 377, 381, 385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 845, 0, 0, 849, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 841, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0,
                    0, 0, 0, 0, 170, 0, 0, 0, 0, 170, 170, 0, 170, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 358, 0, 358, 358, 358, 358, 358, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 0, 0, 0, 358, 358, 0, 358, 358, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 98, 0, 98, 98, 98, 98, 98, 0, 0, 0, 0, 0, 0, 0, 0,
                    98, 0, 0, 0, 0, 98, 98, 0, 98, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 853, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 158, 0, 158, 158, 158, 158, 158, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 158, 158,
                    0, 158, 158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0,
                    0, 0, 0, 0, 0, 0, 0, 162, 0, 0, 0, 0, 162, 162, 0, 162, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 0, 0, 0, 166, 166, 0, 166,
                    166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 857, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 102,
                    102, 102, 102, 102, 0, 102, 0, 0, 0, 0, 0, 0, 102, 102, 102, 102, 0, 102, 102, 0, 102, 102, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 286, 0, 0, 286,
                    0, 0, 0, 293, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 257, 261, 265, 269, 273, 277, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 861, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 285, 289, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0, 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 869, 873, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 865, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 877, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 134, 0, 0, 0, 0, 0, 134, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 282, 0, 0, 282, 0, 0, 0, 0, 282, 0, 0, 0, 0, 0, 0, 282, 0, 0, 0, 282, 282, 282,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 42, 0, 0, 42, 0, 0, 0, 0, 42, 0, 0, 0,
                    0, 0, 0, 42, 0, 0, 0, 42, 42, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0,
                    0, 46, 0, 0, 0, 0, 46, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 46, 46, 46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 50, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 50, 50, 50, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 0, 0, 38, 0, 0, 0, 0, 38, 0, 0, 0, 0,
                    0, 0, 38, 881, 885, 889, 38, 38, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 274, 0, 0, 0, 0, 0, 274, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 893,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 0, 0, 0, 34, 0, 0, 0, 293, 294,
                    34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 901, 677, 681, 685, 689, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 701, 0, 0, 0, 0, 0, 0, 0, 0, 921, 0, 0, 925, 0, 0,
                    0, 0, 929, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 933, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 905, 909, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 913, 917, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 326, 0, 0, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 350, 0, 350, 350, 350, 350, 350, 0, 0, 0, 0, 0, 350,
                    0, 0, 350, 0, 0, 0, 0, 350, 0, 0, 0, 350, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 533,
                    0, 537, 541, 545, 549, 553, 0, 0, 0, 0, 0, 94, 0, 0, 94, 0, 0, 0, 0, 557, 0, 0, 0, 561, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 501, 0, 0, 0, 0, 0, 937, 513, 517, 521, 0, 0, 0, 0, 0, 0, 525,
                    529, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 945, 0, 0, 949, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 941, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170,
                    170, 170, 170, 0, 0, 0, 0, 0, 170, 0, 0, 170, 0, 0, 0, 0, 170, 0, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 358, 358, 358, 358, 358, 0, 0, 0, 0, 0, 358, 0, 0, 358, 0, 0, 0,
                    0, 358, 0, 0, 0, 358, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 98, 0, 98, 98, 98, 98, 98,
                    0, 0, 0, 0, 0, 98, 0, 0, 98, 0, 0, 0, 0, 98, 0, 0, 0, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 953, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 158, 158, 158, 158, 158, 0, 0, 0, 0, 0, 158, 0, 0, 158,
                    0, 0, 0, 0, 158, 0, 0, 0, 158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 162, 162,
                    162, 162, 162, 0, 0, 0, 0, 0, 162, 0, 0, 162, 0, 0, 0, 0, 162, 0, 0, 0, 162, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 166, 0, 0, 166, 0, 0, 0,
                    0, 166, 0, 0, 0, 166, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 957, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 102, 0, 102, 102, 102, 102, 102, 0, 102, 0, 0, 0, 102, 0, 0, 102, 102, 102, 102, 0, 102, 0, 0, 0,
                    102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 961, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 965, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409, 413, 417, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 421, 0, 0,
                    0, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 357, 0, 0, 0, 969, 369, 373, 377, 381,
                    385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 330, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 210, 0, 210, 210, 210, 210, 210, 0, 210, 0, 0, 0, 0, 0, 0, 210, 210, 210, 210, 0, 210, 210,
                    0, 0, 210, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 338, 0, 0, 0, 0, 0, 338, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 805,
                    0, 809, 813, 817, 821, 825, 0, 0, 0, 0, 0, 0, 0, 0, 354, 0, 0, 0, 0, 829, 354, 0, 0, 833, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 773, 0, 0, 0, 0, 0, 973, 785, 789, 793, 0, 0, 0, 0, 0, 0, 797,
                    801, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 977, 0, 0, 178, 0, 178, 178, 178, 178, 178, 0, 178, 0, 0,
                    0, 0, 0, 0, 178, 178, 178, 178, 0, 178, 178, 0, 0, 178, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 194, 0, 194, 194, 194, 194, 194, 0, 194, 0, 0, 0, 0, 0, 0, 194, 194, 194, 194, 0, 194, 194,
                    0, 0, 194, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 981, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 362,
                    0, 362, 362, 362, 362, 362, 0, 997, 0, 0, 0, 0, 0, 0, 362, 1001, 1005, 1009, 0, 362, 362, 0, 0, 362,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 985, 0, 0, 0, 0,
                    989, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 993, 0, 174, 0, 174, 174, 174, 174, 174, 0, 174,
                    0, 0, 0, 0, 0, 0, 174, 174, 174, 174, 0, 174, 174, 0, 0, 174, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 74, 0, 74, 74, 74, 74, 74, 0, 74, 0, 0, 0, 0, 0, 0, 74, 74, 74, 74, 0, 74, 74, 0, 0, 74,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 186, 0, 186, 186, 186, 186, 186, 0, 186, 0, 0,
                    0, 0, 0, 0, 186, 186, 186, 186, 0, 186, 186, 0, 0, 186, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 190, 0, 190, 190, 190, 190, 190, 0, 190, 0, 0, 0, 0, 0, 0, 190, 190, 190, 190, 0, 190, 190,
                    0, 0, 190, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 202, 0, 202, 202, 202, 202, 202, 0,
                    202, 0, 0, 0, 0, 0, 0, 202, 202, 202, 202, 0, 202, 202, 0, 0, 202, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 206, 0, 206, 206, 206, 206, 206, 0, 206, 0, 0, 0, 0, 0, 0, 206, 206, 206, 206, 0, 206,
                    206, 0, 0, 206, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 198, 0, 198, 198, 198, 198, 198,
                    0, 198, 0, 0, 0, 0, 0, 0, 198, 198, 198, 198, 0, 198, 198, 0, 0, 198, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 397, 0, 401, 405, 409, 413, 417, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 421,
                    0, 0, 0, 425, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 357, 0, 0, 1013, 365, 369, 373, 377,
                    381, 385, 0, 0, 0, 0, 0, 0, 389, 393, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 805, 0, 809, 813,
                    817, 821, 825, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 773, 0, 0, 0, 0, 0, 0, 0, 789, 793, 0, 0, 0, 0, 0, 0, 0, 1017, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 346, 0, 346, 346, 346, 346, 346, 0, 0, 0, 0, 0, 0, 0, 0, 346, 0, 0, 0,
                    0, 346, 346, 0, 346, 346, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 106, 0, 106, 106, 106,
                    106, 106, 0, 106, 0, 0, 0, 0, 0, 0, 106, 106, 106, 106, 0, 106, 106, 0, 106, 106, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 114, 0, 114, 114, 114, 114, 114, 0, 114, 0, 0, 0, 0, 0, 0, 114, 114,
                    114, 114, 0, 114, 114, 0, 114, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 110,
                    110, 110, 110, 110, 0, 110, 0, 0, 0, 0, 0, 0, 110, 110, 110, 110, 0, 110, 110, 0, 110, 110, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 761, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1021, 182, 0, 182, 182, 182,
                    182, 182, 0, 182, 0, 0, 0, 0, 0, 0, 182, 182, 182, 182, 0, 182, 182, 0, 182, 182, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 266, 0, 0, 266, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 286,
                    0, 0, 0, 0, 0, 286, 0, 0, 0, 293, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1025, 1029, 1033, 1037,
                    1041, 1045, 1049, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1053, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1057,
                    1061, 0, 0, 0, 0, 0, 0, 0, 0, 298, 0, 0, 298, 0, 0, 0, 0, 298, 298, 0, 0, 0, 0, 0, 298, 0, 0, 0, 298,
                    298, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 302, 0, 0, 302, 0, 0, 0, 0, 302,
                    302, 0, 0, 0, 0, 0, 302, 0, 0, 0, 302, 302, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 142, 0, 0, 142, 0, 0, 0, 0, 142, 0, 0, 0, 142, 0, 0, 142, 142, 142, 142, 142, 142, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 54, 0, 0, 54, 0, 0, 0, 0, 54, 0, 0, 0, 0, 0,
                    0, 54, 0, 0, 0, 54, 54, 54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58,
                    0, 0, 0, 0, 58, 0, 0, 0, 0, 0, 0, 58, 0, 0, 0, 58, 58, 58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 0, 0, 0, 0, 0, 0, 62, 0, 0, 0, 62, 62, 62, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1065,
                    0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0,
                    0, 0, 294, 0, 0, 0, 0, 0, 0, 286, 0, 0, 0, 293, 294, 286, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 669,
                    673, 677, 681, 685, 689, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1069, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    697, 701, 0, 0, 0, 0, 0, 0, 0, 0, 278, 0, 0, 278, 0, 0, 0, 0, 278, 0, 0, 0, 0, 0, 0, 278, 0, 0, 0, 278,
                    278, 278, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138,
                    0, 0, 0, 0, 0, 0, 138, 138, 138, 138, 138, 138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 150, 0, 0, 150, 0, 0, 0, 0, 150, 0, 0, 0, 0, 0, 0, 150, 150, 150, 150, 150, 150, 150,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 0, 0, 0,
                    0, 0, 0, 66, 66, 66, 66, 66, 66, 66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 146,
                    0, 0, 146, 0, 0, 0, 0, 146, 0, 0, 0, 0, 0, 0, 146, 146, 146, 146, 146, 146, 146, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 74, 0, 0, 74, 0, 0, 0, 0, 74, 0, 0, 0, 0, 0, 0, 74, 74, 74,
                    74, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 154, 0, 0, 0,
                    0, 154, 0, 0, 0, 0, 0, 0, 154, 154, 154, 154, 154, 154, 154, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 1073, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 0, 0, 0,
                    286, 0, 0, 0, 293, 294, 286, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1077, 669, 673, 677, 681, 685, 689,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 693, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 697, 701, 0, 0, 0, 0, 0,
                    0, 0, 0, 346, 0, 346, 346, 346, 346, 346, 0, 0, 0, 0, 0, 346, 0, 0, 346, 0, 0, 0, 0, 346, 0, 0, 0, 346,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 106, 0, 106, 106, 106, 106, 106, 0, 106, 0, 0,
                    0, 106, 0, 0, 106, 106, 106, 106, 0, 106, 0, 0, 0, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 114, 0, 114, 114, 114, 114, 114, 0, 114, 0, 0, 0, 114, 0, 0, 114, 114, 114, 114, 0, 114, 0,
                    0, 0, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 110, 110, 110, 110, 110, 0,
                    110, 0, 0, 0, 110, 0, 0, 110, 110, 110, 110, 0, 110, 0, 0, 0, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 761, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1081, 182, 0, 182, 182, 182, 182, 182, 0, 182, 0, 0, 0,
                    182, 0, 0, 182, 182, 182, 182, 0, 182, 0, 0, 0, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 118, 0, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 0, 0, 118, 118,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 366, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 326, 0, 0, 0, 0, 0, 326, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 350, 0, 350, 350, 350, 350, 350, 0, 0, 0, 0, 0, 0, 0, 0, 350, 0, 0, 0, 0, 350, 350, 0, 0,
                    350, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 805, 0, 809, 813, 817, 821, 825, 0, 0, 0,
                    0, 0, 0, 0, 0, 94, 0, 0, 0, 0, 829, 94, 0, 0, 833, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 773, 0, 0, 0, 0, 0, 1085, 785, 789, 793, 0, 0, 0, 0, 0, 0, 797, 801, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1093, 0, 0, 1097, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1089, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 170, 0, 170, 170, 170, 170, 170, 0, 0, 0, 0, 0,
                    0, 0, 0, 170, 0, 0, 0, 0, 170, 170, 0, 0, 170, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    358, 0, 358, 358, 358, 358, 358, 0, 0, 0, 0, 0, 0, 0, 0, 358, 0, 0, 0, 0, 358, 358, 0, 0, 358, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 98, 0, 98, 98, 98, 98, 98, 0, 0, 0, 0, 0, 0, 0, 0, 98,
                    0, 0, 0, 0, 98, 98, 0, 0, 98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1101, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 158, 0, 158, 158, 158, 158, 158, 0, 0, 0, 0, 0, 0, 0, 0, 158, 0, 0, 0, 0, 158, 158, 0, 0,
                    158, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 162, 0, 162, 162, 162, 162, 162, 0, 0, 0,
                    0, 0, 0, 0, 0, 162, 0, 0, 0, 0, 162, 162, 0, 0, 162, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 166, 0, 166, 166, 166, 166, 166, 0, 0, 0, 0, 0, 0, 0, 0, 166, 0, 0, 0, 0, 166, 166, 0, 0, 166,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1105, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 102, 0, 102, 102,
                    102, 102, 102, 0, 102, 0, 0, 0, 0, 0, 0, 102, 102, 102, 102, 0, 102, 102, 0, 0, 102, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1109, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1113, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 134, 0, 0, 0, 0, 0, 134, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 282, 0, 0, 282, 0, 0, 0, 0, 282, 282, 0, 0, 0, 0, 0, 282, 0, 0, 0, 282, 282,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 42, 0, 0, 42, 0, 0, 0, 0, 42, 42, 0,
                    0, 0, 0, 0, 42, 0, 0, 0, 42, 42, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46,
                    0, 0, 46, 0, 0, 0, 0, 46, 46, 0, 0, 0, 0, 0, 46, 0, 0, 0, 46, 46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 0, 50, 0, 0, 0, 0, 50, 50, 0, 0, 0, 0, 0, 50, 0, 0, 0, 50, 50, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 38, 0, 0, 38, 0, 0, 0, 0, 38, 38, 0, 0,
                    0, 0, 0, 38, 1117, 1121, 1125, 38, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 274, 0, 0, 0, 0, 0, 274, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    1129, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 34, 0, 0, 0, 0, 0, 34, 0, 0, 0,
                    293, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1137, 1037, 1041, 1045, 1049, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1061, 0, 0, 0, 0, 0, 0, 0, 0, 1157, 0,
                    0, 1161, 0, 0, 0, 0, 1165, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1169, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1141, 1145, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1149, 1153, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 0, 0, 0, 286, 0,
                    0, 0, 293, 294, 286, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 669, 673, 677, 681, 685, 689, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1173, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 697, 701, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0, 0, 0, 0, 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 869, 873, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1177, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1181, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1185, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 346, 0, 346, 346, 346, 346, 346, 0, 0, 0, 0, 0, 0, 0, 0, 346, 0, 0, 0, 0, 346, 346,
                    0, 0, 346, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 106, 0, 106, 106, 106, 106, 106, 0,
                    106, 0, 0, 0, 0, 0, 0, 106, 106, 106, 106, 0, 106, 106, 0, 0, 106, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 114, 0, 114, 114, 114, 114, 114, 0, 114, 0, 0, 0, 0, 0, 0, 114, 114, 114, 114, 0, 114,
                    114, 0, 0, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 110, 0, 110, 110, 110, 110, 110,
                    0, 110, 0, 0, 0, 0, 0, 0, 110, 110, 110, 110, 0, 110, 110, 0, 0, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 370, 0, 0, 0, 0, 0, 0, 0, 0, 0, 761, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1189, 182, 0, 182, 182, 182, 182, 182, 0, 182, 0, 0,
                    0, 0, 0, 0, 182, 182, 182, 182, 0, 182, 182, 0, 0, 182, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 118, 0, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 0, 0, 0, 118, 0, 0, 0, 0, 118, 118, 0, 118,
                    118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70, 0, 0, 0, 70,
                    0, 0, 70, 70, 70, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 54, 0,
                    0, 54, 0, 0, 0, 0, 54, 54, 0, 0, 0, 0, 0, 54, 0, 0, 0, 54, 54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 58, 0, 0, 58, 0, 0, 0, 0, 58, 58, 0, 0, 0, 0, 0, 58, 0, 0, 0, 58, 58, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 62, 0, 0, 62, 0, 0, 0, 0, 62, 62, 0, 0, 0,
                    0, 0, 62, 0, 0, 0, 62, 62, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 1193, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 286, 0, 0, 0, 0, 0, 286, 0, 0, 0, 293, 294, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1029, 1033, 1037, 1041, 1045, 1049, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 1197, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1057, 1061, 0, 0, 0, 0, 0, 0, 0, 0, 278, 0, 0,
                    278, 0, 0, 0, 0, 278, 278, 0, 0, 0, 0, 0, 278, 0, 0, 0, 278, 278, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 138, 0, 0, 138, 0, 0, 0, 0, 138, 138, 0, 0, 0, 0, 0, 138, 138, 138, 138,
                    138, 138, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 150, 0, 0, 150, 0, 0, 0, 0,
                    150, 150, 0, 0, 0, 0, 0, 150, 150, 150, 150, 150, 150, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 66, 0, 0, 66, 0, 0, 0, 0, 66, 66, 0, 0, 0, 0, 0, 66, 66, 66, 66, 66, 66, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 146, 0, 0, 146, 0, 0, 0, 0, 146, 146, 0, 0, 0,
                    0, 0, 146, 146, 146, 146, 146, 146, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    74, 0, 0, 74, 0, 0, 0, 0, 74, 74, 0, 0, 0, 0, 0, 74, 74, 74, 74, 74, 74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 154, 0, 0, 154, 0, 0, 0, 0, 154, 154, 0, 0, 0, 0, 0, 154, 154, 154,
                    154, 154, 154, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1201, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 0, 0, 0, 0, 0, 0, 286, 0, 0, 0, 293, 294, 286, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 1205, 669, 673, 677, 681, 685, 689, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    693, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 697, 701, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    294, 0, 0, 294, 0, 0, 0, 0, 294, 286, 0, 0, 0, 0, 0, 286, 0, 0, 0, 293, 294, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 1209, 1029, 1033, 1037, 1041, 1045, 1049, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1053,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1057, 1061, 0, 0, 0, 0, 0, 0, 0, 0, 142, 0, 0, 142, 0, 0, 0, 0, 142,
                    0, 0, 0, 0, 0, 0, 142, 142, 142, 142, 142, 142, 142, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 118, 0, 118, 118, 118, 118, 118, 0, 0, 0, 0, 0, 118, 0, 0, 118, 0, 0, 0, 0, 118, 0, 0,
                    0, 118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1213, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0,
                    0, 294, 0, 0, 0, 0, 294, 286, 0, 0, 0, 0, 0, 286, 0, 0, 0, 293, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 1029, 1033, 1037, 1041, 1045, 1049, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1217, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 1057, 1061, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 270, 0, 0, 0,
                    0, 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 869, 873, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1221,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1225, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1229, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 118, 0, 118, 118, 118,
                    118, 118, 0, 0, 0, 0, 0, 0, 0, 0, 118, 0, 0, 0, 0, 118, 118, 0, 0, 118, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 266, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 294, 0, 0, 294, 0, 0, 0, 0, 294, 286, 0, 0, 0,
                    0, 0, 286, 0, 0, 0, 293, 294, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1233, 1029, 1033, 1037, 1041,
                    1045, 1049, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1053, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1057, 1061,
                    0, 0, 0, 0, 0, 0, 0, 0, 142, 0, 0, 142, 0, 0, 0, 0, 142, 142, 0, 0, 0, 0, 0, 142, 142, 142, 142, 142,
                    142, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70,
                    0, 0, 0, 0, 0, 0, 70, 70, 70, 70, 70, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1237, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 70, 0, 0, 70, 0, 0, 0, 0, 70, 70, 0, 0, 0, 0, 0, 70, 70, 70, 70,
                    70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                };
                
                return U16ParseTable.From(u16Table, 310, 77, 29);
            }
        }
    }
}
