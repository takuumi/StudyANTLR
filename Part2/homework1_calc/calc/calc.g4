grammar calc;

input: expr EOF;

expr
    : num                                       #expr_none
    | lhs=expr op=(PLUS|MINUS) rhs=expr         #expr_additive
    ;

num
    : UINT
    ;

PLUS: '+';
MINUS: '-';

UINT: [0-9]+;

WS: [ \t]+ -> skip;