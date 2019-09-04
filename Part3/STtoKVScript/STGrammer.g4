grammar STGrammer;

input
    : (oneline? NEWLINE)* oneline? EOF
    ;

oneline
    : stlang                            #expr_stlang
    | linecomment                       #expr_stlinecomment
    ;

stlang
    : IDENTIFIER ASSIGN expr SEMI_COLON            #expr_expr
    ;

expr
    : define                             #expr_define
    | lhs=expr op=(PLUS|MINUS) rhs=expr     #expr_additive
    ;

define
    : IDENTIFIER;

linecomment
    : SINGLE_LINE_COMMENT;
    

NEWLINE                 : '\r' | '\n' | '\r\n';


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

CASE: C A S E;
OF: O F;
END_CASE: E N D '_' C A S E;
REPEAT: R E P E A T;
UNTIL: U N T I L;
END_REPEAT: E N D '_' R E P E A T;

/*
ID_START: [A-Za-z_];
ID_CONTINUE: ID_START | [0-9];
IDENTIFIER: ID_START ID_CONTINUE*;
*/
IDENTIFIER : [A-Za-z0-9_]+;

WS: [ \t]+ -> skip;
//EOL: '\r'? '\n' | '\r' -> skip;
SINGLE_LINE_COMMENT: '//' ~[\r\n]*;

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