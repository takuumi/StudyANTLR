//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/takuumi/Projects/StudyANTLR/Part3/STtoKVScript/STGrammer.g4 by ANTLR 4.7.2

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
/// by <see cref="STGrammerParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface ISTGrammerVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInput([NotNull] STGrammerParser.InputContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>st_state_repeat</c>
	/// labeled alternative in <see cref="STGrammerParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSt_state_repeat([NotNull] STGrammerParser.St_state_repeatContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>st_state_return</c>
	/// labeled alternative in <see cref="STGrammerParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSt_state_return([NotNull] STGrammerParser.St_state_returnContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>st_state_case</c>
	/// labeled alternative in <see cref="STGrammerParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSt_state_case([NotNull] STGrammerParser.St_state_caseContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>st_expression</c>
	/// labeled alternative in <see cref="STGrammerParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSt_expression([NotNull] STGrammerParser.St_expressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>st_linecomment</c>
	/// labeled alternative in <see cref="STGrammerParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSt_linecomment([NotNull] STGrammerParser.St_linecommentContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expt_stblock_repeat</c>
	/// labeled alternative in <see cref="STGrammerParser.statement_repeat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpt_stblock_repeat([NotNull] STGrammerParser.Expt_stblock_repeatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.statement_return"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement_return([NotNull] STGrammerParser.Statement_returnContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>st_case_detail</c>
	/// labeled alternative in <see cref="STGrammerParser.statement_case"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSt_case_detail([NotNull] STGrammerParser.St_case_detailContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.case_of_state"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCase_of_state([NotNull] STGrammerParser.Case_of_stateContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_variable</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_variable([NotNull] STGrammerParser.Expr_variableContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_widestring</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_widestring([NotNull] STGrammerParser.Expr_widestringContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_logical_operation</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_logical_operation([NotNull] STGrammerParser.Expr_logical_operationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_assign</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_assign([NotNull] STGrammerParser.Expr_assignContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_funccall</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_funccall([NotNull] STGrammerParser.Expr_funccallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_multipricative</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_multipricative([NotNull] STGrammerParser.Expr_multipricativeContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_multistring</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_multistring([NotNull] STGrammerParser.Expr_multistringContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_typedefine</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_typedefine([NotNull] STGrammerParser.Expr_typedefineContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_outref</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_outref([NotNull] STGrammerParser.Expr_outrefContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_additive</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_additive([NotNull] STGrammerParser.Expr_additiveContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_keyword</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_keyword([NotNull] STGrammerParser.Expr_keywordContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_normal_value</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_normal_value([NotNull] STGrammerParser.Expr_normal_valueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_equivalent_operation</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_equivalent_operation([NotNull] STGrammerParser.Expr_equivalent_operationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_unary</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_unary([NotNull] STGrammerParser.Expr_unaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_dispdefine</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_dispdefine([NotNull] STGrammerParser.Expr_dispdefineContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expr_comparison_operation</c>
	/// labeled alternative in <see cref="STGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr_comparison_operation([NotNull] STGrammerParser.Expr_comparison_operationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>func_named_arg</c>
	/// labeled alternative in <see cref="STGrammerParser.func_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_named_arg([NotNull] STGrammerParser.Func_named_argContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>func_operation</c>
	/// labeled alternative in <see cref="STGrammerParser.func_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_operation([NotNull] STGrammerParser.Func_operationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>func_variable</c>
	/// labeled alternative in <see cref="STGrammerParser.func_expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_variable([NotNull] STGrammerParser.Func_variableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.variable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariable([NotNull] STGrammerParser.VariableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.keyword"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKeyword([NotNull] STGrammerParser.KeywordContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.normal_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNormal_value([NotNull] STGrammerParser.Normal_valueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.type_define"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType_define([NotNull] STGrammerParser.Type_defineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.disp_define"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDisp_define([NotNull] STGrammerParser.Disp_defineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="STGrammerParser.linecomment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinecomment([NotNull] STGrammerParser.LinecommentContext context);
}
