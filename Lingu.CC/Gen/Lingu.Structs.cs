namespace Grammar
{
    using Lingu.Runtime.Concretes;
    using Lingu.Runtime.Parsing;
    using Lingu.Runtime.Structures;
    
    public static partial class Data
    {
        public static readonly ParseTable Table = new U16ParseTable(u16Table, 307, 29, 76);
        
        public static readonly TerminalSymbol identifier = new TerminalSymbol(0, "identifier", "");
        public static readonly TerminalSymbol number = new TerminalSymbol(1, "number", "");
        public static readonly TerminalSymbol any = new TerminalSymbol(2, "any", "");
        public static readonly TerminalSymbol text = new TerminalSymbol(3, "text", "");
        public static readonly TerminalSymbol ucBlock = new TerminalSymbol(4, "ucBlock", "");
        public static readonly TerminalSymbol ucCategory = new TerminalSymbol(5, "ucCategory", "");
        public static readonly TerminalSymbol ucCodepoint = new TerminalSymbol(6, "ucCodepoint", "");
        public static readonly TerminalSymbol __T1 = new TerminalSymbol(7, "__T1", "grammar");
        public static readonly TerminalSymbol __T2 = new TerminalSymbol(8, "__T2", "{");
        public static readonly TerminalSymbol __T3 = new TerminalSymbol(9, "__T3", "}");
        public static readonly TerminalSymbol __T4 = new TerminalSymbol(10, "__T4", "options");
        public static readonly TerminalSymbol __T5 = new TerminalSymbol(11, "__T5", "=");
        public static readonly TerminalSymbol __T6 = new TerminalSymbol(12, "__T6", ";");
        public static readonly TerminalSymbol __T7 = new TerminalSymbol(13, "__T7", "rules");
        public static readonly TerminalSymbol __T8 = new TerminalSymbol(14, "__T8", "^");
        public static readonly TerminalSymbol __T9 = new TerminalSymbol(15, "__T9", "|");
        public static readonly TerminalSymbol __T10 = new TerminalSymbol(16, "__T10", ",");
        public static readonly TerminalSymbol __T11 = new TerminalSymbol(17, "__T11", "(");
        public static readonly TerminalSymbol __T12 = new TerminalSymbol(18, "__T12", ")");
        public static readonly TerminalSymbol __T13 = new TerminalSymbol(19, "__T13", "terminals");
        public static readonly TerminalSymbol __T14 = new TerminalSymbol(20, "__T14", "-");
        public static readonly TerminalSymbol __T15 = new TerminalSymbol(21, "__T15", "?");
        public static readonly TerminalSymbol __T16 = new TerminalSymbol(22, "__T16", "*");
        public static readonly TerminalSymbol __T17 = new TerminalSymbol(23, "__T17", "+");
        public static readonly TerminalSymbol __T18 = new TerminalSymbol(24, "__T18", "~");
        public static readonly TerminalSymbol __T19 = new TerminalSymbol(25, "__T19", "..");
        public static readonly TerminalSymbol __T20 = new TerminalSymbol(26, "__T20", ":");
        public static readonly TerminalSymbol __T21 = new TerminalSymbol(27, "__T21", "->");
        public static readonly TerminalSymbol __eof = new TerminalSymbol(28, "__eof", "$eof$");
        public static readonly NonterminalSymbol file = new NonterminalSymbol(29, "file", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol angrammar = new NonterminalSymbol(30, "angrammar", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_options = new NonterminalSymbol(31, "grammar_options", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol option = new NonterminalSymbol(32, "option", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_rules = new NonterminalSymbol(33, "grammar_rules", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule = new NonterminalSymbol(34, "rule", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_expression = new NonterminalSymbol(35, "rule_expression", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_alternative = new NonterminalSymbol(36, "rule_alternative", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_sequence = new NonterminalSymbol(37, "rule_sequence", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_repetition = new NonterminalSymbol(38, "rule_repetition", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_drop_action = new NonterminalSymbol(39, "rule_drop_action", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol sub_rule = new NonterminalSymbol(40, "sub_rule", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol reference = new NonterminalSymbol(41, "reference", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_terminals = new NonterminalSymbol(42, "grammar_terminals", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_rule = new NonterminalSymbol(43, "terminal_rule", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_expression = new NonterminalSymbol(44, "terminal_expression", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_difference = new NonterminalSymbol(45, "terminal_difference", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_sequence = new NonterminalSymbol(46, "terminal_sequence", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_repetition = new NonterminalSymbol(47, "terminal_repetition", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_not = new NonterminalSymbol(48, "terminal_not", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol characterRange = new NonterminalSymbol(49, "characterRange", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol character = new NonterminalSymbol(50, "character", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol range = new NonterminalSymbol(51, "range", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_item = new NonterminalSymbol(52, "grammar_item", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_element = new NonterminalSymbol(53, "rule_element", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_atom = new NonterminalSymbol(54, "rule_atom", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_cardinalilty = new NonterminalSymbol(55, "terminal_cardinalilty", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_element = new NonterminalSymbol(56, "terminal_element", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_atom = new NonterminalSymbol(57, "terminal_atom", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(58, "__N1", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(59, "__N2", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N3 = new NonterminalSymbol(60, "__N3", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N4 = new NonterminalSymbol(61, "__N4", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N5 = new NonterminalSymbol(62, "__N5", RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N6 = new NonterminalSymbol(63, "__N6", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N7 = new NonterminalSymbol(64, "__N7", RepeatKind.Plus, LiftKind.Plus);
        public static readonly NonterminalSymbol __N9 = new NonterminalSymbol(65, "__N9", RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N8 = new NonterminalSymbol(66, "__N8", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N10 = new NonterminalSymbol(67, "__N10", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N11 = new NonterminalSymbol(68, "__N11", RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N12 = new NonterminalSymbol(69, "__N12", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N13 = new NonterminalSymbol(70, "__N13", RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N14 = new NonterminalSymbol(71, "__N14", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N15 = new NonterminalSymbol(72, "__N15", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N16 = new NonterminalSymbol(73, "__N16", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N17 = new NonterminalSymbol(74, "__N17", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N18 = new NonterminalSymbol(75, "__N18", RepeatKind.Optional, LiftKind.Optional);
        public static readonly TerminalSymbol newline = new TerminalSymbol(76, "newline", "");
        public static readonly TerminalSymbol newlineChar = new TerminalSymbol(77, "newlineChar", "");
        public static readonly TerminalSymbol whitespace = new TerminalSymbol(78, "whitespace", "");
        public static readonly TerminalSymbol lineComment = new TerminalSymbol(79, "lineComment", "");
        public static readonly TerminalSymbol blockComment = new TerminalSymbol(80, "blockComment", "");
        public static readonly TerminalSymbol spacing = new TerminalSymbol(81, "spacing", "");
        public static readonly TerminalSymbol identifierStart = new TerminalSymbol(82, "identifierStart", "");
        public static readonly TerminalSymbol identifierContinue = new TerminalSymbol(83, "identifierContinue", "");
        public static readonly TerminalSymbol digit = new TerminalSymbol(84, "digit", "");
        public static readonly TerminalSymbol nonzeroDigit = new TerminalSymbol(85, "nonzeroDigit", "");
        public static readonly TerminalSymbol zero = new TerminalSymbol(86, "zero", "");
        public static readonly TerminalSymbol hexDigit = new TerminalSymbol(87, "hexDigit", "");
        public static readonly TerminalSymbol escapes = new TerminalSymbol(88, "escapes", "");
        public static readonly TerminalSymbol ucNameStart = new TerminalSymbol(89, "ucNameStart", "");
        public static readonly TerminalSymbol ucNameInner = new TerminalSymbol(90, "ucNameInner", "");
        public static readonly TerminalSymbol ucNameEnd = new TerminalSymbol(91, "ucNameEnd", "");
        public static readonly TerminalSymbol ucName = new TerminalSymbol(92, "ucName", "");
        public static readonly NonterminalSymbol __acc = new NonterminalSymbol(93, "__acc", RepeatKind.None, LiftKind.None);
        
        public static readonly Symbol[] Symbols = 
        {
            identifier, number, any, text, ucBlock, ucCategory, ucCodepoint, __T1,
            __T2, __T3, __T4, __T5, __T6, __T7, __T8, __T9, __T10, __T11, __T12,
            __T13, __T14, __T15, __T16, __T17, __T18, __T19, __T20, __T21, __eof,
            file, angrammar, grammar_options, option, grammar_rules, rule, rule_expression,
            rule_alternative, rule_sequence, rule_repetition, rule_drop_action, sub_rule,
            reference, grammar_terminals, terminal_rule, terminal_expression, terminal_difference,
            terminal_sequence, terminal_repetition, terminal_not, characterRange,
            character, range, grammar_item, rule_element, rule_atom, terminal_cardinalilty,
            terminal_element, terminal_atom, __N1, __N2, __N3, __N4, __N5, __N6,
            __N7, __N9, __N8, __N10, __N11, __N12, __N13, __N14, __N15, __N16, __N17,
            __N18, newline, newlineChar, whitespace, lineComment, blockComment, spacing,
            identifierStart, identifierContinue, digit, nonzeroDigit, zero, hexDigit,
            escapes, ucNameStart, ucNameInner, ucNameEnd, ucName, __acc,
        };
        
        public static readonly Production[] Productions = 
        {
            new Production(__acc,"__acc -> file", false),
            new Production(file,"file -> angrammar", false),
            new Production(angrammar,"angrammar -> ,'grammar' ˈidentifierˈ ,'{' __N1 ,'}'", true, false, true, false, true),
            new Production(grammar_options,"grammar_options -> ,'options' ,'{' __N2 ,'}'", true, true, false, true),
            new Production(option,"option -> ˈidentifierˈ ,'=' ˈidentifierˈ ,';'", false, true, false, true),
            new Production(grammar_rules,"grammar_rules -> ,'rules' ,'{' __N3 ,'}'", true, true, false, true),
            new Production(rule,"rule -> ˈidentifierˈ __N4 ,__N5 rule_expression ,';'", false, false, true, false, true),
            new Production(rule_expression,"rule_expression -> rule_alternative __N6", false, false),
            new Production(rule_alternative,"rule_alternative -> rule_sequence", false),
            new Production(rule_alternative,"rule_alternative -> "),
            new Production(rule_sequence,"rule_sequence -> __N7", false),
            new Production(rule_repetition,"rule_repetition -> rule_drop_action __N8", false, false),
            new Production(rule_drop_action,"rule_drop_action -> __N10 rule_element", false, false),
            new Production(sub_rule,"sub_rule -> ,'{' ˈidentifierˈ ,__N11 rule_expression ,'}'", true, false, true, false, true),
            new Production(reference,"reference -> ˈidentifierˈ", false),
            new Production(grammar_terminals,"grammar_terminals -> ,'terminals' ,'{' __N12 ,'}'", true, true, false, true),
            new Production(terminal_rule,"terminal_rule -> ˈidentifierˈ ,__N13 terminal_expression ,';'", false, true, false, true),
            new Production(terminal_expression,"terminal_expression -> terminal_difference __N14", false, false),
            new Production(terminal_difference,"terminal_difference -> terminal_sequence __N15", false, false),
            new Production(terminal_sequence,"terminal_sequence -> terminal_repetition __N16", false, false),
            new Production(terminal_repetition,"terminal_repetition -> terminal_element __N17", false, false),
            new Production(terminal_not,"terminal_not -> ,'~' terminal_atom", true, false),
            new Production(characterRange,"characterRange -> character ,'..' character", false, true, false),
            new Production(character,"character -> ˈucCodepointˈ", false),
            new Production(character,"character -> ˈtextˈ", false),
            new Production(range,"range -> ,'{' ˈnumberˈ __N18 ,'}'", true, false, false, true),
            new Production(grammar_item,"grammar_item -> grammar_options", false),
            new Production(grammar_item,"grammar_item -> grammar_rules", false),
            new Production(grammar_item,"grammar_item -> grammar_terminals", false),
            new Production(rule_element,"rule_element -> sub_rule", false),
            new Production(rule_element,"rule_element -> ,'(' rule_expression ,')'", true, false, true),
            new Production(rule_element,"rule_element -> rule_atom", false),
            new Production(rule_atom,"rule_atom -> reference", false),
            new Production(rule_atom,"rule_atom -> ˈtextˈ", false),
            new Production(terminal_cardinalilty,"terminal_cardinalilty -> '?'", false),
            new Production(terminal_cardinalilty,"terminal_cardinalilty -> '*'", false),
            new Production(terminal_cardinalilty,"terminal_cardinalilty -> '+'", false),
            new Production(terminal_cardinalilty,"terminal_cardinalilty -> range", false),
            new Production(terminal_element,"terminal_element -> terminal_atom", false),
            new Production(terminal_element,"terminal_element -> terminal_not", false),
            new Production(terminal_element,"terminal_element -> ,'(' terminal_expression ,')'", true, false, true),
            new Production(terminal_atom,"terminal_atom -> ˈanyˈ", false),
            new Production(terminal_atom,"terminal_atom -> ˈtextˈ", false),
            new Production(terminal_atom,"terminal_atom -> characterRange", false),
            new Production(terminal_atom,"terminal_atom -> ˈucCodepointˈ", false),
            new Production(terminal_atom,"terminal_atom -> ˈucBlockˈ", false),
            new Production(terminal_atom,"terminal_atom -> ˈucCategoryˈ", false),
            new Production(terminal_atom,"terminal_atom -> reference", false),
            new Production(__N1,"__N1 -> __N1 grammar_item", false, false),
            new Production(__N1,"__N1 -> grammar_item", false),
            new Production(__N1,"__N1 -> "),
            new Production(__N2,"__N2 -> __N2 option", false, false),
            new Production(__N2,"__N2 -> option", false),
            new Production(__N2,"__N2 -> "),
            new Production(__N3,"__N3 -> __N3 rule", false, false),
            new Production(__N3,"__N3 -> rule", false),
            new Production(__N3,"__N3 -> "),
            new Production(__N4,"__N4 -> '^'", false),
            new Production(__N4,"__N4 -> "),
            new Production(__N5,"__N5 -> ':'", false),
            new Production(__N5,"__N5 -> '->'", false),
            new Production(__N6,"__N6 -> __N6 ,'|' rule_alternative", false, true, false),
            new Production(__N6,"__N6 -> ,'|' rule_alternative", true, false),
            new Production(__N6,"__N6 -> "),
            new Production(__N7,"__N7 -> __N7 rule_repetition", false, false),
            new Production(__N7,"__N7 -> rule_repetition", false),
            new Production(__N9,"__N9 -> '?'", false),
            new Production(__N9,"__N9 -> '*'", false),
            new Production(__N9,"__N9 -> '+'", false),
            new Production(__N8,"__N8 -> __N9", false),
            new Production(__N8,"__N8 -> "),
            new Production(__N10,"__N10 -> ','", false),
            new Production(__N10,"__N10 -> "),
            new Production(__N11,"__N11 -> ':'", false),
            new Production(__N11,"__N11 -> '->'", false),
            new Production(__N12,"__N12 -> __N12 terminal_rule", false, false),
            new Production(__N12,"__N12 -> terminal_rule", false),
            new Production(__N12,"__N12 -> "),
            new Production(__N13,"__N13 -> ':'", false),
            new Production(__N13,"__N13 -> '->'", false),
            new Production(__N14,"__N14 -> __N14 ,'|' terminal_difference", false, true, false),
            new Production(__N14,"__N14 -> ,'|' terminal_difference", true, false),
            new Production(__N14,"__N14 -> "),
            new Production(__N15,"__N15 -> ,'-' terminal_sequence", true, false),
            new Production(__N15,"__N15 -> "),
            new Production(__N16,"__N16 -> __N16 terminal_repetition", false, false),
            new Production(__N16,"__N16 -> terminal_repetition", false),
            new Production(__N16,"__N16 -> "),
            new Production(__N17,"__N17 -> terminal_cardinalilty", false),
            new Production(__N17,"__N17 -> "),
            new Production(__N18,"__N18 -> ,',' ˈnumberˈ", true, false),
            new Production(__N18,"__N18 -> "),
        };
    }
}
