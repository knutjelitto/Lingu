/*
 * WARNING: this file has been generated by
 * Hime Parser Generator 3.4.0.0
 */
using System.Collections.Generic;
using System.IO;
using Hime.Redist;
using Hime.Redist.Lexer;

namespace Lingu.Bootstrap
{
	/// <summary>
	/// Represents a lexer
	/// </summary>
	public class LinguLexer : ContextFreeLexer
	{
		/// <summary>
		/// The automaton for this lexer
		/// </summary>
		private static readonly Automaton commonAutomaton = Automaton.Find(typeof(LinguLexer), "LinguLexer.bin");
		/// <summary>
		/// Contains the constant IDs for the terminals for this lexer
		/// </summary>
		public class ID
		{
			/// <summary>
			/// The unique identifier for terminal SEPARATOR
			/// </summary>
			public const int TerminalSeparator = 0x0007;
			/// <summary>
			/// The unique identifier for terminal NAME
			/// </summary>
			public const int TerminalName = 0x0009;
			/// <summary>
			/// The unique identifier for terminal INTEGER
			/// </summary>
			public const int TerminalInteger = 0x000A;
			/// <summary>
			/// The unique identifier for terminal LITERAL_STRING
			/// </summary>
			public const int TerminalLiteralString = 0x000C;
			/// <summary>
			/// The unique identifier for terminal LITERAL_ANY
			/// </summary>
			public const int TerminalLiteralAny = 0x000D;
			/// <summary>
			/// The unique identifier for terminal LITERAL_TEXT
			/// </summary>
			public const int TerminalLiteralText = 0x000E;
			/// <summary>
			/// The unique identifier for terminal LITERAL_CLASS
			/// </summary>
			public const int TerminalLiteralClass = 0x000F;
			/// <summary>
			/// The unique identifier for terminal UNICODE_BLOCK
			/// </summary>
			public const int TerminalUnicodeBlock = 0x0010;
			/// <summary>
			/// The unique identifier for terminal UNICODE_CATEGORY
			/// </summary>
			public const int TerminalUnicodeCategory = 0x0011;
			/// <summary>
			/// The unique identifier for terminal UNICODE_CODEPOINT
			/// </summary>
			public const int TerminalUnicodeCodepoint = 0x0012;
			/// <summary>
			/// The unique identifier for terminal UNICODE_SPAN_MARKER
			/// </summary>
			public const int TerminalUnicodeSpanMarker = 0x0013;
			/// <summary>
			/// The unique identifier for terminal OPERATOR_UNION
			/// </summary>
			public const int TerminalOperatorUnion = 0x0014;
			/// <summary>
			/// The unique identifier for terminal OPERATOR_DIFFERENCE
			/// </summary>
			public const int TerminalOperatorDifference = 0x0015;
			/// <summary>
			/// The unique identifier for terminal TREE_ACTION_PROMOTE
			/// </summary>
			public const int TerminalTreeActionPromote = 0x0016;
			/// <summary>
			/// The unique identifier for terminal TREE_ACTION_DROP
			/// </summary>
			public const int TerminalTreeActionDrop = 0x0017;
		}
		/// <summary>
		/// Contains the constant IDs for the contexts for this lexer
		/// </summary>
		public class Context
		{
			/// <summary>
			/// The unique identifier for the default context
			/// </summary>
			public const int Default = 0;
		}
		/// <summary>
		/// The collection of terminals matched by this lexer
		/// </summary>
		/// <remarks>
		/// The terminals are in an order consistent with the automaton,
		/// so that terminal indices in the automaton can be used to retrieve the terminals in this table
		/// </remarks>
		private static readonly Symbol[] terminals = {
			new Symbol(0x0001, "ε"),
			new Symbol(0x0002, "$"),
			new Symbol(0x0007, "SEPARATOR"),
			new Symbol(0x0009, "NAME"),
			new Symbol(0x000A, "INTEGER"),
			new Symbol(0x000C, "LITERAL_STRING"),
			new Symbol(0x000D, "LITERAL_ANY"),
			new Symbol(0x000E, "LITERAL_TEXT"),
			new Symbol(0x000F, "LITERAL_CLASS"),
			new Symbol(0x0010, "UNICODE_BLOCK"),
			new Symbol(0x0011, "UNICODE_CATEGORY"),
			new Symbol(0x0012, "UNICODE_CODEPOINT"),
			new Symbol(0x0013, "UNICODE_SPAN_MARKER"),
			new Symbol(0x0014, "OPERATOR_UNION"),
			new Symbol(0x0015, "OPERATOR_DIFFERENCE"),
			new Symbol(0x0016, "TREE_ACTION_PROMOTE"),
			new Symbol(0x0017, "TREE_ACTION_DROP"),
			new Symbol(0x003C, "grammar"),
			new Symbol(0x003D, "{"),
			new Symbol(0x003E, "}"),
			new Symbol(0x003F, "options"),
			new Symbol(0x0041, "="),
			new Symbol(0x0042, ";"),
			new Symbol(0x0043, "terminals"),
			new Symbol(0x0045, "->"),
			new Symbol(0x0046, "fragment"),
			new Symbol(0x0047, "context"),
			new Symbol(0x004C, "("),
			new Symbol(0x004D, ")"),
			new Symbol(0x004E, "?"),
			new Symbol(0x004F, "*"),
			new Symbol(0x0050, "+"),
			new Symbol(0x0052, ","),
			new Symbol(0x0053, "rules"),
			new Symbol(0x0057, "!"),
			new Symbol(0x0058, "^"),
			new Symbol(0x0059, "#"),
			new Symbol(0x005A, "@"),
			new Symbol(0x005B, "<"),
			new Symbol(0x005D, ">") };
		/// <summary>
		/// Initializes a new instance of the lexer
		/// </summary>
		/// <param name="input">The lexer's input</param>
		public LinguLexer(string input) : base(commonAutomaton, terminals, 0x0007, input) {}
		/// <summary>
		/// Initializes a new instance of the lexer
		/// </summary>
		/// <param name="input">The lexer's input</param>
		public LinguLexer(TextReader input) : base(commonAutomaton, terminals, 0x0007, input) {}
	}
}
