#if true
namespace Grammar
{
    using System.Collections.Generic;
    
    using Lingu.Runtime.Concretes;
    using Lingu.Runtime.Parsing;
    using Lingu.Runtime.Structures;
    
    public static partial class Data
    {
        public static readonly ParseTable Table = new U16ParseTable(u16table, 310, 29, 77);
        
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
        public static readonly TerminalSymbol __T10 = new TerminalSymbol(16, "__T10", "?");
        public static readonly TerminalSymbol __T11 = new TerminalSymbol(17, "__T11", "*");
        public static readonly TerminalSymbol __T12 = new TerminalSymbol(18, "__T12", "+");
        public static readonly TerminalSymbol __T13 = new TerminalSymbol(19, "__T13", ",");
        public static readonly TerminalSymbol __T14 = new TerminalSymbol(20, "__T14", "(");
        public static readonly TerminalSymbol __T15 = new TerminalSymbol(21, "__T15", ")");
        public static readonly TerminalSymbol __T16 = new TerminalSymbol(22, "__T16", "terminals");
        public static readonly TerminalSymbol __T17 = new TerminalSymbol(23, "__T17", "-");
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
        public static readonly NonterminalSymbol rule_sequence = new NonterminalSymbol(36, "rule_sequence", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_repetition = new NonterminalSymbol(37, "rule_repetition", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_optional = new NonterminalSymbol(38, "rule_optional", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_star_closure = new NonterminalSymbol(39, "rule_star_closure", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_plus_closure = new NonterminalSymbol(40, "rule_plus_closure", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol rule_drop_action = new NonterminalSymbol(41, "rule_drop_action", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol sub_rule = new NonterminalSymbol(42, "sub_rule", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol reference = new NonterminalSymbol(43, "reference", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_terminals = new NonterminalSymbol(44, "grammar_terminals", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_rule = new NonterminalSymbol(45, "terminal_rule", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_expression = new NonterminalSymbol(46, "terminal_expression", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_difference = new NonterminalSymbol(47, "terminal_difference", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_sequence = new NonterminalSymbol(48, "terminal_sequence", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_repetition = new NonterminalSymbol(49, "terminal_repetition", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol terminal_not = new NonterminalSymbol(50, "terminal_not", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol characterRange = new NonterminalSymbol(51, "characterRange", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol character = new NonterminalSymbol(52, "character", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol range = new NonterminalSymbol(53, "range", RepeatKind.None, LiftKind.None);
        public static readonly NonterminalSymbol grammar_item = new NonterminalSymbol(54, "grammar_item", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_alternative = new NonterminalSymbol(55, "rule_alternative", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_element = new NonterminalSymbol(56, "rule_element", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol rule_atom = new NonterminalSymbol(57, "rule_atom", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_cardinalilty = new NonterminalSymbol(58, "terminal_cardinalilty", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_element = new NonterminalSymbol(59, "terminal_element", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol terminal_atom = new NonterminalSymbol(60, "terminal_atom", RepeatKind.None, LiftKind.Lift);
        public static readonly NonterminalSymbol __N1 = new NonterminalSymbol(61, "__N1", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N2 = new NonterminalSymbol(62, "__N2", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N3 = new NonterminalSymbol(63, "__N3", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N4 = new NonterminalSymbol(64, "__N4", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N5 = new NonterminalSymbol(65, "__N5", RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N6 = new NonterminalSymbol(66, "__N6", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N7 = new NonterminalSymbol(67, "__N7", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N8 = new NonterminalSymbol(68, "__N8", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N9 = new NonterminalSymbol(69, "__N9", RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N10 = new NonterminalSymbol(70, "__N10", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N11 = new NonterminalSymbol(71, "__N11", RepeatKind.None, LiftKind.Alternate);
        public static readonly NonterminalSymbol __N12 = new NonterminalSymbol(72, "__N12", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N13 = new NonterminalSymbol(73, "__N13", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N14 = new NonterminalSymbol(74, "__N14", RepeatKind.Star, LiftKind.Star);
        public static readonly NonterminalSymbol __N15 = new NonterminalSymbol(75, "__N15", RepeatKind.Optional, LiftKind.Optional);
        public static readonly NonterminalSymbol __N16 = new NonterminalSymbol(76, "__N16", RepeatKind.Optional, LiftKind.Optional);
        public static readonly TerminalSymbol newline = new TerminalSymbol(77, "newline", "");
        public static readonly TerminalSymbol newlineChar = new TerminalSymbol(78, "newlineChar", "");
        public static readonly TerminalSymbol whitespace = new TerminalSymbol(79, "whitespace", "");
        public static readonly TerminalSymbol lineComment = new TerminalSymbol(80, "lineComment", "");
        public static readonly TerminalSymbol blockComment = new TerminalSymbol(81, "blockComment", "");
        public static readonly TerminalSymbol spacing = new TerminalSymbol(82, "spacing", "");
        public static readonly TerminalSymbol identifierStart = new TerminalSymbol(83, "identifierStart", "");
        public static readonly TerminalSymbol identifierContinue = new TerminalSymbol(84, "identifierContinue", "");
        public static readonly TerminalSymbol digit = new TerminalSymbol(85, "digit", "");
        public static readonly TerminalSymbol nonzeroDigit = new TerminalSymbol(86, "nonzeroDigit", "");
        public static readonly TerminalSymbol zero = new TerminalSymbol(87, "zero", "");
        public static readonly TerminalSymbol hexDigit = new TerminalSymbol(88, "hexDigit", "");
        public static readonly TerminalSymbol escapes = new TerminalSymbol(89, "escapes", "");
        public static readonly TerminalSymbol ucNameStart = new TerminalSymbol(90, "ucNameStart", "");
        public static readonly TerminalSymbol ucNameInner = new TerminalSymbol(91, "ucNameInner", "");
        public static readonly TerminalSymbol ucNameEnd = new TerminalSymbol(92, "ucNameEnd", "");
        public static readonly TerminalSymbol ucName = new TerminalSymbol(93, "ucName", "");
        public static readonly NonterminalSymbol _acc_ = new NonterminalSymbol(94, "_acc_", RepeatKind.None, LiftKind.None);
        
        public static readonly Symbol[] Symbols = 
        {
            identifier, number, any, text, ucBlock, ucCategory, ucCodepoint, __T1,
            __T2, __T3, __T4, __T5, __T6, __T7, __T8, __T9, __T10, __T11, __T12,
            __T13, __T14, __T15, __T16, __T17, __T18, __T19, __T20, __T21, __eof,
            file, angrammar, grammar_options, option, grammar_rules, rule, rule_expression,
            rule_sequence, rule_repetition, rule_optional, rule_star_closure, rule_plus_closure,
            rule_drop_action, sub_rule, reference, grammar_terminals, terminal_rule,
            terminal_expression, terminal_difference, terminal_sequence, terminal_repetition,
            terminal_not, characterRange, character, range, grammar_item, rule_alternative,
            rule_element, rule_atom, terminal_cardinalilty, terminal_element, terminal_atom,
            __N1, __N2, __N3, __N4, __N5, __N6, __N7, __N8, __N9, __N10, __N11, __N12,
            __N13, __N14, __N15, __N16, newline, newlineChar, whitespace, lineComment,
            blockComment, spacing, identifierStart, identifierContinue, digit, nonzeroDigit,
            zero, hexDigit, escapes, ucNameStart, ucNameInner, ucNameEnd, ucName,
            _acc_,
        }
        ;
        
        public static readonly Production[] Productions = 
        {
            new Production(_acc_, false),
            new Production(file, false),
            new Production(angrammar, true, false, true, false, true),
            new Production(grammar_options, true, true, false, true),
            new Production(option, false, true, false, true),
            new Production(grammar_rules, true, true, false, true),
            new Production(rule, false, false, true, false, true),
            new Production(rule_expression, false, false),
            new Production(rule_sequence, false),
            new Production(rule_repetition, false),
            new Production(rule_repetition, false),
            new Production(rule_repetition, false),
            new Production(rule_repetition, false),
            new Production(rule_optional, false, true),
            new Production(rule_star_closure, false, true),
            new Production(rule_plus_closure, false, true),
            new Production(rule_drop_action, false, false),
            new Production(sub_rule, true, false, true, false, true),
            new Production(reference, false),
            new Production(grammar_terminals, true, true, false, true),
            new Production(terminal_rule, false, true, false, true),
            new Production(terminal_expression, false, false),
            new Production(terminal_difference, false, false),
            new Production(terminal_sequence, false, false),
            new Production(terminal_repetition, false, false),
            new Production(terminal_not, true, false),
            new Production(characterRange, false, true, false),
            new Production(character, false),
            new Production(character, false),
            new Production(range, true, false, false, true),
            new Production(grammar_item, false),
            new Production(grammar_item, false),
            new Production(grammar_item, false),
            new Production(rule_alternative, false),
            new Production(rule_element, false),
            new Production(rule_element, true, false, true),
            new Production(rule_element, false),
            new Production(rule_atom, false),
            new Production(rule_atom, false),
            new Production(terminal_cardinalilty, false),
            new Production(terminal_cardinalilty, false),
            new Production(terminal_cardinalilty, false),
            new Production(terminal_cardinalilty, false),
            new Production(terminal_element, false),
            new Production(terminal_element, false),
            new Production(terminal_element, true, false, true),
            new Production(terminal_atom, false),
            new Production(terminal_atom, false),
            new Production(terminal_atom, false),
            new Production(terminal_atom, false),
            new Production(terminal_atom, false),
            new Production(terminal_atom, false),
            new Production(terminal_atom, false),
            new Production(__N1, false, false),
            new Production(__N1, false),
            new Production(__N1),
            new Production(__N2, false, false),
            new Production(__N2, false),
            new Production(__N2),
            new Production(__N3, false, false),
            new Production(__N3, false),
            new Production(__N3),
            new Production(__N4, false),
            new Production(__N4),
            new Production(__N5, false),
            new Production(__N5, false),
            new Production(__N6, false, true, false),
            new Production(__N6, true, false),
            new Production(__N6),
            new Production(__N7, false, false),
            new Production(__N7, false),
            new Production(__N7),
            new Production(__N8, false),
            new Production(__N8),
            new Production(__N9, false),
            new Production(__N9, false),
            new Production(__N10, false, false),
            new Production(__N10, false),
            new Production(__N10),
            new Production(__N11, false),
            new Production(__N11, false),
            new Production(__N12, false, true, false),
            new Production(__N12, true, false),
            new Production(__N12),
            new Production(__N13, true, false),
            new Production(__N13),
            new Production(__N14, false, false),
            new Production(__N14, false),
            new Production(__N14),
            new Production(__N15, false),
            new Production(__N15),
            new Production(__N16, true, false),
            new Production(__N16),
        }
        ;
        
    }
}
#endif
