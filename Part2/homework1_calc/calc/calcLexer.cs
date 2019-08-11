//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/takuumi/Projects/StudyANTLR/Part2/homework1_calc/calc/calc.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class calcLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		PLUS=1, MINUS=2, ASTERISK=3, SLASH=4, OPEN_PAREN=5, CLOSE_PAREN=6, COMMA=7, 
		UINT=8, REAL=9, WS=10, IDENTIFIER=11;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"PLUS", "MINUS", "ASTERISK", "SLASH", "OPEN_PAREN", "CLOSE_PAREN", "COMMA", 
		"UINT", "REAL", "WS", "DEC_DIGIT", "DOT", "ID_START", "ID_CONTINUE", "IDENTIFIER"
	};


	public calcLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public calcLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'+'", "'-'", "'*'", "'/'", "'('", "')'", "','"
	};
	private static readonly string[] _SymbolicNames = {
		null, "PLUS", "MINUS", "ASTERISK", "SLASH", "OPEN_PAREN", "CLOSE_PAREN", 
		"COMMA", "UINT", "REAL", "WS", "IDENTIFIER"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "calc.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static calcLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\r', 'Y', '\b', '\x1', '\x4', '\x2', '\t', '\x2', '\x4', 
		'\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', 
		'\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', 
		'\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', 
		'\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x6', '\t', 
		'\x31', '\n', '\t', '\r', '\t', '\xE', '\t', '\x32', '\x3', '\n', '\a', 
		'\n', '\x36', '\n', '\n', '\f', '\n', '\xE', '\n', '\x39', '\v', '\n', 
		'\x3', '\n', '\x3', '\n', '\a', '\n', '=', '\n', '\n', '\f', '\n', '\xE', 
		'\n', '@', '\v', '\n', '\x3', '\v', '\x6', '\v', '\x43', '\n', '\v', '\r', 
		'\v', '\xE', '\v', '\x44', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', 
		'\f', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', 
		'\x3', '\xF', '\x5', '\xF', 'Q', '\n', '\xF', '\x3', '\x10', '\x3', '\x10', 
		'\a', '\x10', 'U', '\n', '\x10', '\f', '\x10', '\xE', '\x10', 'X', '\v', 
		'\x10', '\x2', '\x2', '\x11', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', 
		'\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', 
		'\v', '\x15', '\f', '\x17', '\x2', '\x19', '\x2', '\x1B', '\x2', '\x1D', 
		'\x2', '\x1F', '\r', '\x3', '\x2', '\x5', '\x3', '\x2', '\x32', ';', '\x4', 
		'\x2', '\v', '\v', '\"', '\"', '\x5', '\x2', '\x43', '\\', '\x61', '\x61', 
		'\x63', '|', '\x2', 'Z', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x3', '!', '\x3', '\x2', '\x2', 
		'\x2', '\x5', '#', '\x3', '\x2', '\x2', '\x2', '\a', '%', '\x3', '\x2', 
		'\x2', '\x2', '\t', '\'', '\x3', '\x2', '\x2', '\x2', '\v', ')', '\x3', 
		'\x2', '\x2', '\x2', '\r', '+', '\x3', '\x2', '\x2', '\x2', '\xF', '-', 
		'\x3', '\x2', '\x2', '\x2', '\x11', '\x30', '\x3', '\x2', '\x2', '\x2', 
		'\x13', '\x37', '\x3', '\x2', '\x2', '\x2', '\x15', '\x42', '\x3', '\x2', 
		'\x2', '\x2', '\x17', 'H', '\x3', '\x2', '\x2', '\x2', '\x19', 'J', '\x3', 
		'\x2', '\x2', '\x2', '\x1B', 'L', '\x3', '\x2', '\x2', '\x2', '\x1D', 
		'P', '\x3', '\x2', '\x2', '\x2', '\x1F', 'R', '\x3', '\x2', '\x2', '\x2', 
		'!', '\"', '\a', '-', '\x2', '\x2', '\"', '\x4', '\x3', '\x2', '\x2', 
		'\x2', '#', '$', '\a', '/', '\x2', '\x2', '$', '\x6', '\x3', '\x2', '\x2', 
		'\x2', '%', '&', '\a', ',', '\x2', '\x2', '&', '\b', '\x3', '\x2', '\x2', 
		'\x2', '\'', '(', '\a', '\x31', '\x2', '\x2', '(', '\n', '\x3', '\x2', 
		'\x2', '\x2', ')', '*', '\a', '*', '\x2', '\x2', '*', '\f', '\x3', '\x2', 
		'\x2', '\x2', '+', ',', '\a', '+', '\x2', '\x2', ',', '\xE', '\x3', '\x2', 
		'\x2', '\x2', '-', '.', '\a', '.', '\x2', '\x2', '.', '\x10', '\x3', '\x2', 
		'\x2', '\x2', '/', '\x31', '\t', '\x2', '\x2', '\x2', '\x30', '/', '\x3', 
		'\x2', '\x2', '\x2', '\x31', '\x32', '\x3', '\x2', '\x2', '\x2', '\x32', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\x32', '\x33', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\x12', '\x3', '\x2', '\x2', '\x2', '\x34', '\x36', '\x5', 
		'\x17', '\f', '\x2', '\x35', '\x34', '\x3', '\x2', '\x2', '\x2', '\x36', 
		'\x39', '\x3', '\x2', '\x2', '\x2', '\x37', '\x35', '\x3', '\x2', '\x2', 
		'\x2', '\x37', '\x38', '\x3', '\x2', '\x2', '\x2', '\x38', ':', '\x3', 
		'\x2', '\x2', '\x2', '\x39', '\x37', '\x3', '\x2', '\x2', '\x2', ':', 
		'>', '\x5', '\x19', '\r', '\x2', ';', '=', '\x5', '\x17', '\f', '\x2', 
		'<', ';', '\x3', '\x2', '\x2', '\x2', '=', '@', '\x3', '\x2', '\x2', '\x2', 
		'>', '<', '\x3', '\x2', '\x2', '\x2', '>', '?', '\x3', '\x2', '\x2', '\x2', 
		'?', '\x14', '\x3', '\x2', '\x2', '\x2', '@', '>', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\x43', '\t', '\x3', '\x2', '\x2', '\x42', '\x41', '\x3', 
		'\x2', '\x2', '\x2', '\x43', '\x44', '\x3', '\x2', '\x2', '\x2', '\x44', 
		'\x42', '\x3', '\x2', '\x2', '\x2', '\x44', '\x45', '\x3', '\x2', '\x2', 
		'\x2', '\x45', '\x46', '\x3', '\x2', '\x2', '\x2', '\x46', 'G', '\b', 
		'\v', '\x2', '\x2', 'G', '\x16', '\x3', '\x2', '\x2', '\x2', 'H', 'I', 
		'\t', '\x2', '\x2', '\x2', 'I', '\x18', '\x3', '\x2', '\x2', '\x2', 'J', 
		'K', '\a', '\x30', '\x2', '\x2', 'K', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'L', 'M', '\t', '\x4', '\x2', '\x2', 'M', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', 'N', 'Q', '\x5', '\x1B', '\xE', '\x2', 'O', 'Q', '\t', '\x2', '\x2', 
		'\x2', 'P', 'N', '\x3', '\x2', '\x2', '\x2', 'P', 'O', '\x3', '\x2', '\x2', 
		'\x2', 'Q', '\x1E', '\x3', '\x2', '\x2', '\x2', 'R', 'V', '\x5', '\x1B', 
		'\xE', '\x2', 'S', 'U', '\x5', '\x1D', '\xF', '\x2', 'T', 'S', '\x3', 
		'\x2', '\x2', '\x2', 'U', 'X', '\x3', '\x2', '\x2', '\x2', 'V', 'T', '\x3', 
		'\x2', '\x2', '\x2', 'V', 'W', '\x3', '\x2', '\x2', '\x2', 'W', ' ', '\x3', 
		'\x2', '\x2', '\x2', 'X', 'V', '\x3', '\x2', '\x2', '\x2', '\t', '\x2', 
		'\x32', '\x37', '>', '\x44', 'P', 'V', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
