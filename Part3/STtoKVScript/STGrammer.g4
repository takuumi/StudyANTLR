grammar STGrammer;

input
    : block* EOF
    ;

block
    : statement_repeat                     #st_state_repeat
    | statement_return                     #st_state_return
    | statement_case                       #st_state_case
    | expr SEMI_COLON                      #st_expression
    | linecomment                          #st_linecomment
    ;

/* REPEAT */
statement_repeat
    : REPEAT blks +=block* UNTIL expr END_REPEAT SEMI_COLON   #expt_stblock_repeat
    ;

/* RETURN */
statement_return
    : RETURN SEMI_COLON
    ;

/* CASE */
/* first try
statement_case
    : CASE expr OF (caseState+=case_of_state+ COLON blks+=block*)* (ELSE else_blks+=block*)? END_CASE SEMI_COLON #st_case_detail
    ;
case_of_state
    : IDENTIFIER
    | COMMA IDENTIFIER
    | RANGE IDENTIFIER
    ;
*/

/* After FB */
statement_case
    : CASE expr OF caseblk+=case_block+ else_block? END_CASE SEMI_COLON;
case_block: lbl+=case_label+ blk+=block*;
case_label: case_cond (COMMA cnd2+=case_cond)* COLON;
case_cond
    : IDENTIFIER
    | IDENTIFIER RANGE IDENTIFIER
    | normal_value
    | normal_value RANGE normal_value
    ;
else_block :ELSE blk+=block*;

/* Expression */
expr
    : op=(PLUS|MINUS) expr                                  #expr_unary
    //todo
    | NOT func_expr                                         #expr_not
    | lhs=expr op=(PLUS|MINUS) rhs=expr                     #expr_additive
    | lhs=expr op=(ASTERISK|SLASH|POW|MOD) rhs=expr         #expr_multipricative
    | lhs=expr op=(AND|AND2|OR|XOR) rhs=expr                #expr_logical_operation
    | lhs=expr op=(GT|LT|GE|LE) rhs=expr                    #expr_comparison_operation
    | lhs=expr op=(EQ|NEQ) rhs=expr                         #expr_equivalent_operation
    | lhs=expr ASSIGN rhs=expr                              #expr_assign
    | lhs=expr OUTREF rhs=expr                              #expr_outref
    | funcname=IDENTIFIER OPEN_PAREN args+=func_expr* (COMMA args2+=func_expr)* CLOSE_PAREN  #expr_funccall
    | reserveword                                                                            #expr_reserveword
    | literal                                                                                #expr_literal
    | variable                                                                               #expr_variable
    ;

//todo
func_expr
    : lhs=expr op=(ASSIGN|OUTREF) rhs=expr                         #func_named_arg
    | lhs=expr op=(AND|AND2|OR|XOR|GT|LT|GE|LE|EQ|NEQ) rhs=expr    #func_operation
    | variable                                                     #func_variable
    ;

reserveword
    : EXIT;

literal
    : type_define                                           #expr_typedefine
    | disp_define                                           #expr_dispdefine
    | normal_value                                          #expr_normal_value
    | MULTISTRING expr MULTISTRING                          #expr_multistring
    | WIDESTRING expr WIDESTRING                            #expr_widestring
    ;

type_define
    : TYPE_INT (normal_value | disp_define)                 #type_int
    | TYPE_UINT (normal_value | disp_define)                #type_uint
    | TYPE_LREAL NUM_REAL                                   #type_lreal
    | TYPE_STRING MULTISTRING (literal | variable) MULTISTRING  #type_string
    ;

disp_define
    : DISP_BIN
    | DISP_OCT
    | DISP_HEX;

normal_value
    : NUM_UINT
    | NUM_REAL
    ;

variable
    : IDENTIFIER;

linecomment
    : SINGLE_LINE_COMMENT;


PLUS : '+';
MINUS : '-';
ASTERISK : '*';
SLASH : '/';
POW: '**';
LT: '<';
GT: '>';
LE: '<=';
GE: '>=';
EQ: '=';
NEQ: '<>';
ASSIGN: ':=';
OUTREF: '=>';
RANGE: '..';
COMMA: ',';
OPEN_PAREN : '(';
CLOSE_PAREN : ')';
SEMI_COLON: ';';
COLON : ':';

NOT : N O T;
MOD : M O D;
AND : A N D;
OR : O R;
XOR : X O R;
AND2 : '&';

CASE: C A S E;
OF: O F;
END_CASE: E N D '_' C A S E;
REPEAT: R E P E A T;
UNTIL: U N T I L;
ELSE : E L S E;
RETURN: R E T U R N;
END_REPEAT: E N D '_' R E P E A T;
EXIT: E X I T;

MULTISTRING : SINGLEQUATE;
WIDESTRING :  DOUBLEQUATE;

WS                  : (' ' | '\t' | '\n' | '\r' | '\r\n')+ -> skip;
SINGLE_LINE_COMMENT: '//' ~[\r\n]*;

NUM_UINT: [0-9]+;
NUM_REAL : DEC_DIGIT* DOT DEC_DIGIT*;

TYPE_INT : INT SHARP;
TYPE_UINT : UINT SHARP;
TYPE_LREAL : LREAL SHARP;
TYPE_STRING : STRING SHARP;

DISP_BIN    : '2' SHARP BIN;
DISP_OCT    : '8' SHARP NUM_UINT;
DISP_HEX    : '16' SHARP NUM_HEX;

IDENTIFIER: ID_START ID_CONTINUE*;

fragment ID_START: [A-Za-z_];
fragment ID_CONTINUE: ID_START | [0-9];

fragment DOUBLEQUATE    : '"';
fragment SINGLEQUATE    : ['];
fragment UNDERLINE      : '_';

fragment DOT            : '.';
fragment DEC_DIGIT      : [0-9];
fragment NUM_HEX : [0-9A-F]+;
fragment BIN: [01]+ UNDERLINE* [01]+;
fragment SHARP    : '#';

fragment INT: I N T;
fragment DINT: D INT;
fragment UINT: U INT;
fragment UDINT: U DINT;
fragment REAL: R E A L;
fragment LREAL: L REAL;
fragment STRING: S T R I N G;
fragment WSTRING: W STRING;

fragment A: [Aa];
fragment B: [Bb];
fragment C: [Cc];
fragment D: [Dd];
fragment E: [Ee];
fragment F: [Ff];
fragment G: [Gg];
fragment H: [Hh];
fragment I: [Ii];
fragment J: [Jj];
fragment K: [Kk];
fragment L: [Ll];
fragment M: [Mm];
fragment N: [Nn];
fragment O: [Oo];
fragment P: [Pp];
fragment Q: [Qq];
fragment R: [Rr];
fragment S: [Ss];
fragment T: [Tt];
fragment U: [Uu];
fragment V: [Vv];
fragment W: [Ww];
fragment X: [Xx];
fragment Y: [Yy];
fragment Z: [Zz];