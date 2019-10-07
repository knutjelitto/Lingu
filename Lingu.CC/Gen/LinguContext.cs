namespace Lingu.CC
{
    using Lingu.Runtime.Concretes;
    using Lingu.Runtime.Lexing;
    using Lingu.Runtime.Parsing;
    using Lingu.Runtime.Structures;
    
    public partial class LinguContext
    {
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
        public static readonly TerminalSymbol __T8 = new TerminalSymbol(14, "__T8", true, "^");
        public static readonly TerminalSymbol __T9 = new TerminalSymbol(15, "__T9", false, "|");
        public static readonly TerminalSymbol __T10 = new TerminalSymbol(16, "__T10", true, "?");
        public static readonly TerminalSymbol __T11 = new TerminalSymbol(17, "__T11", true, "*");
        public static readonly TerminalSymbol __T12 = new TerminalSymbol(18, "__T12", true, "+");
        public static readonly TerminalSymbol __T13 = new TerminalSymbol(19, "__T13", true, ",");
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
        public static readonly NonterminalSymbol grammar_options = new NonterminalSymbol(31, "grammar_options", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol option = new NonterminalSymbol(32, "option", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_rules = new NonterminalSymbol(33, "grammar_rules", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule = new NonterminalSymbol(34, "rule", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_expression = new NonterminalSymbol(35, "rule_expression", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_sequence = new NonterminalSymbol(36, "rule_sequence", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_repetition = new NonterminalSymbol(37, "rule_repetition", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_optional = new NonterminalSymbol(38, "rule_optional", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_star_closure = new NonterminalSymbol(39, "rule_star_closure", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_plus_closure = new NonterminalSymbol(40, "rule_plus_closure", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_drop_action = new NonterminalSymbol(41, "rule_drop_action", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol sub_rule = new NonterminalSymbol(42, "sub_rule", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol reference = new NonterminalSymbol(43, "reference", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_terminals = new NonterminalSymbol(44, "grammar_terminals", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_rule = new NonterminalSymbol(45, "terminal_rule", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_expression = new NonterminalSymbol(46, "terminal_expression", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_difference = new NonterminalSymbol(47, "terminal_difference", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_sequence = new NonterminalSymbol(48, "terminal_sequence", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_repetition = new NonterminalSymbol(49, "terminal_repetition", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_not = new NonterminalSymbol(50, "terminal_not", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol characterRange = new NonterminalSymbol(51, "characterRange", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol character = new NonterminalSymbol(52, "character", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol range = new NonterminalSymbol(53, "range", false, RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_item = new NonterminalSymbol(54, "grammar_item", true, RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_alternative = new NonterminalSymbol(55, "rule_alternative", true, RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_element = new NonterminalSymbol(56, "rule_element", true, RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_atom = new NonterminalSymbol(57, "rule_atom", true, RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_cardinalilty = new NonterminalSymbol(58, "terminal_cardinalilty", true, RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_element = new NonterminalSymbol(59, "terminal_element", true, RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_atom = new NonterminalSymbol(60, "terminal_atom", true, RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(61, "__N1", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(62, "__N2", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N3 = new NonterminalSymbol(63, "__N3", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N4 = new NonterminalSymbol(64, "__N4", true, RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N5 = new NonterminalSymbol(65, "__N5", true, RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N6 = new NonterminalSymbol(66, "__N6", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N7 = new NonterminalSymbol(67, "__N7", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N8 = new NonterminalSymbol(68, "__N8", true, RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N9 = new NonterminalSymbol(69, "__N9", true, RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N10 = new NonterminalSymbol(70, "__N10", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N11 = new NonterminalSymbol(71, "__N11", true, RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N12 = new NonterminalSymbol(72, "__N12", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N13 = new NonterminalSymbol(73, "__N13", true, RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N14 = new NonterminalSymbol(74, "__N14", true, RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N15 = new NonterminalSymbol(75, "__N15", true, RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N16 = new NonterminalSymbol(76, "__N16", true, RepeatKind.Optional, LiftKind.Optional);
        public static readonly TerminalSymbol newline = new TerminalSymbol(77, "newline", false, "");
        public static readonly TerminalSymbol newlineChar = new TerminalSymbol(78, "newlineChar", false, "");
        public static readonly TerminalSymbol whitespace = new TerminalSymbol(79, "whitespace", false, "");
        public static readonly TerminalSymbol lineComment = new TerminalSymbol(80, "lineComment", false, "");
        public static readonly TerminalSymbol blockComment = new TerminalSymbol(81, "blockComment", false, "");
        public static readonly TerminalSymbol spacing = new TerminalSymbol(82, "spacing", false, "");
        public static readonly TerminalSymbol identifierStart = new TerminalSymbol(83, "identifierStart", false, "");
        public static readonly TerminalSymbol identifierContinue = new TerminalSymbol(84, "identifierContinue", false, "");
        public static readonly TerminalSymbol digit = new TerminalSymbol(85, "digit", false, "");
        public static readonly TerminalSymbol nonzeroDigit = new TerminalSymbol(86, "nonzeroDigit", false, "");
        public static readonly TerminalSymbol zero = new TerminalSymbol(87, "zero", false, "");
        public static readonly TerminalSymbol hexDigit = new TerminalSymbol(88, "hexDigit", false, "");
        public static readonly TerminalSymbol escapes = new TerminalSymbol(89, "escapes", false, "");
        public static readonly TerminalSymbol ucNameStart = new TerminalSymbol(90, "ucNameStart", false, "");
        public static readonly TerminalSymbol ucNameInner = new TerminalSymbol(91, "ucNameInner", false, "");
        public static readonly TerminalSymbol ucNameEnd = new TerminalSymbol(92, "ucNameEnd", false, "");
        public static readonly TerminalSymbol ucName = new TerminalSymbol(93, "ucName", false, "");
        public static readonly NonterminalSymbol __acc = new NonterminalSymbol(94, "__acc", true, RepeatKind.None, LiftKind.None);
        
        public static readonly Symbol[] Symbols = 
        {
            identifier, number, any, text, ucBlock, ucCategory, ucCodepoint, __T1, __T2, __T3, __T4, __T5, __T6, __T7, __T8,
            __T9, __T10, __T11, __T12, __T13, __T14, __T15, __T16, __T17, __T18, __T19, __T20, __T21, __eof, file, angrammar,
            grammar_options, option, grammar_rules, rule, rule_expression, rule_sequence, rule_repetition, rule_optional,
            rule_star_closure, rule_plus_closure, rule_drop_action, sub_rule, reference, grammar_terminals, terminal_rule,
            terminal_expression, terminal_difference, terminal_sequence, terminal_repetition, terminal_not, characterRange,
            character, range, grammar_item, rule_alternative, rule_element, rule_atom, terminal_cardinalilty, terminal_element,
            terminal_atom, __N1, __N2, __N3, __N4, __N5, __N6, __N7, __N8, __N9, __N10, __N11, __N12, __N13, __N14, __N15,
            __N16, newline, newlineChar, whitespace, lineComment, blockComment, spacing, identifierStart, identifierContinue,
            digit, nonzeroDigit, zero, hexDigit, escapes, ucNameStart, ucNameInner, ucNameEnd, ucName, __acc,
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
            new Production(rule_sequence,"rule_sequence -> __N7", false),
            new Production(rule_repetition,"rule_repetition -> rule_drop_action", false),
            new Production(rule_repetition,"rule_repetition -> rule_optional", false),
            new Production(rule_repetition,"rule_repetition -> rule_star_closure", false),
            new Production(rule_repetition,"rule_repetition -> rule_plus_closure", false),
            new Production(rule_optional,"rule_optional -> rule_drop_action ,'?'", false, true),
            new Production(rule_star_closure,"rule_star_closure -> rule_drop_action ,'*'", false, true),
            new Production(rule_plus_closure,"rule_plus_closure -> rule_drop_action ,'+'", false, true),
            new Production(rule_drop_action,"rule_drop_action -> __N8 rule_element", false, false),
            new Production(sub_rule,"sub_rule -> ,'{' ˈidentifierˈ ,__N9 rule_expression ,'}'", true, false, true, false, true),
            new Production(reference,"reference -> ˈidentifierˈ", false),
            new Production(grammar_terminals,"grammar_terminals -> ,'terminals' ,'{' __N10 ,'}'", true, true, false, true),
            new Production(terminal_rule,"terminal_rule -> ˈidentifierˈ ,__N11 terminal_expression ,';'", false, true, false, true),
            new Production(terminal_expression,"terminal_expression -> terminal_difference __N12", false, false),
            new Production(terminal_difference,"terminal_difference -> terminal_sequence __N13", false, false),
            new Production(terminal_sequence,"terminal_sequence -> terminal_repetition __N14", false, false),
            new Production(terminal_repetition,"terminal_repetition -> terminal_element __N15", false, false),
            new Production(terminal_not,"terminal_not -> ,'~' terminal_atom", true, false),
            new Production(characterRange,"characterRange -> character ,'..' character", false, true, false),
            new Production(character,"character -> ˈucCodepointˈ", false),
            new Production(character,"character -> ˈtextˈ", false),
            new Production(range,"range -> ,'{' ˈnumberˈ __N16 ,'}'", true, false, false, true),
            new Production(grammar_item,"grammar_item -> grammar_options", false),
            new Production(grammar_item,"grammar_item -> grammar_rules", false),
            new Production(grammar_item,"grammar_item -> grammar_terminals", false),
            new Production(rule_alternative,"rule_alternative -> rule_sequence", false),
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
            new Production(__N7,"__N7 -> "),
            new Production(__N8,"__N8 -> ','", false),
            new Production(__N8,"__N8 -> "),
            new Production(__N9,"__N9 -> ':'", false),
            new Production(__N9,"__N9 -> '->'", false),
            new Production(__N10,"__N10 -> __N10 terminal_rule", false, false),
            new Production(__N10,"__N10 -> terminal_rule", false),
            new Production(__N10,"__N10 -> "),
            new Production(__N11,"__N11 -> ':'", false),
            new Production(__N11,"__N11 -> '->'", false),
            new Production(__N12,"__N12 -> __N12 ,'|' terminal_difference", false, true, false),
            new Production(__N12,"__N12 -> ,'|' terminal_difference", true, false),
            new Production(__N12,"__N12 -> "),
            new Production(__N13,"__N13 -> ,'-' terminal_sequence", true, false),
            new Production(__N13,"__N13 -> "),
            new Production(__N14,"__N14 -> __N14 terminal_repetition", false, false),
            new Production(__N14,"__N14 -> terminal_repetition", false),
            new Production(__N14,"__N14 -> "),
            new Production(__N15,"__N15 -> terminal_cardinalilty", false),
            new Production(__N15,"__N15 -> "),
            new Production(__N16,"__N16 -> ,',' ˈnumberˈ", true, false),
            new Production(__N16,"__N16 -> "),
        };
    }
}
