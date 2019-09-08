grammar STGrammer;

input
    : block* EOF
    ;

block
    : statement NEWLINE*                        #expr_stlang
    | linecomment NEWLINE*                       #expr_stlinecomment
    ;

statement
    : expr SEMI_COLON                               #expr_void
    ;

expr
    : op=(PLUS|MINUS|NOT) expr                      #expr_unary
    | lhs=expr op=(PLUS|MINUS) rhs=expr         #expr_additive
    | lhs=expr op=(ASTERISK | SLASH | POW | MOD) rhs=expr   #expr_multipricative
    | lhs=expr op=(AND|AND2|OR|XOR) rhs=expr               #expr_logical_operation
    | lhs=expr op=(GT|LT|GE|LE) rhs=expr               #expr_comparison_operation
    | lhs=expr op=(EQ|NEQ) rhs=expr               #expr_equivalent_operation
    | expr ASSIGN expr                #expr_assign
    | expr OUTREF expr                #expr_outref
    | funcname=IDENTIFIER OPEN_PAREN args+=expr* (COMMA expr)*  CLOSE_PAREN #expr_funccall   //+=を使うと、同じ種類の構文要素リスト化できる
    | MULTISTRING expr MULTISTRING          #expr_multistring
    | WIDESTRING expr WIDESTRING            #expr_widestring
    | type_define                           #expr_typedefine
    | disp_define                           #expr_dispdefine
    | define                                #expr_define
    ;

define
    : IDENTIFIER
    | NUM_UINT
    | NUM_REAL
    ;

// todo conbine
type_define
    : TYPE_INT NUM_UINT
    | TYPE_UINT NUM_UINT
    | TYPE_LREAL NUM_REAL
    | TYPE_STRING MULTISTRING IDENTIFIER MULTISTRING
    | TYPE_UINT disp_define
    ;


disp_define
    : DISP_BIN
    | DISP_DEC
    | DISP_HEX;


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
END_REPEAT: E N D '_' R E P E A T;

MULTISTRING : SINGLEQUATE;
WIDESTRING :  DOUBLEQUATE;


WS: [ \t]+ -> skip;
//EOL: '\r'? '\n' | '\r' -> skip;
SINGLE_LINE_COMMENT: '//' ~[\r\n]*;
NEWLINE                 : '\r' | '\n' | '\r\n';


NUM_UINT: [0-9]+;
NUM_REAL : DEC_DIGIT* DOT DEC_DIGIT*;
fragment NUM_HEX : [0-9A-F]+;
fragment BIN: [01]+ UNDERLINE* [01]+;

fragment TYPE_KEY    : '#';
TYPE_INT : INT TYPE_KEY;
TYPE_UINT : UINT TYPE_KEY;
TYPE_LREAL : LREAL TYPE_KEY;
TYPE_STRING : STRING TYPE_KEY;

DISP_BIN    : '2' TYPE_KEY BIN;
DISP_DEC    : '10' TYPE_KEY NUM_UINT;
DISP_HEX    : '16' TYPE_KEY NUM_HEX;


fragment ID_START: [A-Za-z_];
fragment ID_CONTINUE: ID_START | [0-9];
IDENTIFIER: ID_START ID_CONTINUE*;


fragment DOUBLEQUATE    : '"';
fragment SINGLEQUATE    : ['];
fragment UNDERLINE      : '_';

fragment DEC_DIGIT      : [0-9];
fragment DOT            : '.';

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