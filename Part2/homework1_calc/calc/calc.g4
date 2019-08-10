grammar calc;

input: expr EOF;

expr
    : num                                       #expr_none
    | lhs=expr op=(PLUS|MINUS) rhs=expr         #expr_additive
    | lhs=expr op=(ASTERISK | SLASH) rhs=expr   #expr_multipricative
    ;

num
    : UINT
    | REAL
    ;

PLUS: '+';
MINUS: '-';
ASTERISK: '*';
SLASH: '/';

UINT: [0-9]+;

REAL : DEC_DIGIT* DOT DEC_DIGIT*;

WS: [ \t]+ -> skip;

fragment DEC_DIGIT      : [0-9];
fragment DOT            : '.';