//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/takuumi/Projects/StudyANTLR/Part2/homework2_plcsim/plcsim/plcsim.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="plcsimParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IplcsimVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInput([NotNull] plcsimParser.InputContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plcsim_memonic</c>
	/// labeled alternative in <see cref="plcsimParser.oneline"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlcsim_memonic([NotNull] plcsimParser.Plcsim_memonicContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plcsim_linecomment</c>
	/// labeled alternative in <see cref="plcsimParser.oneline"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlcsim_linecomment([NotNull] plcsimParser.Plcsim_linecommentContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plcsim_main</c>
	/// labeled alternative in <see cref="plcsimParser.mnemonic"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlcsim_main([NotNull] plcsimParser.Plcsim_mainContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.command"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCommand([NotNull] plcsimParser.CommandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.separator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSeparator([NotNull] plcsimParser.SeparatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.linecomment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinecomment([NotNull] plcsimParser.LinecommentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperator([NotNull] plcsimParser.OperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.operand"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperand([NotNull] plcsimParser.OperandContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.index"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndex([NotNull] plcsimParser.IndexContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.wordbit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWordbit([NotNull] plcsimParser.WordbitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.indirect"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndirect([NotNull] plcsimParser.IndirectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.local"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLocal([NotNull] plcsimParser.LocalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] plcsimParser.LiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.const_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConst_number([NotNull] plcsimParser.Const_numberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.const_string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConst_string([NotNull] plcsimParser.Const_stringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.const_dec_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConst_dec_number([NotNull] plcsimParser.Const_dec_numberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.const_hex_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConst_hex_number([NotNull] plcsimParser.Const_hex_numberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="plcsimParser.const_float"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConst_float([NotNull] plcsimParser.Const_floatContext context);
}
