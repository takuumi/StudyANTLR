grammar calc;

input: expr EOF;

expr
    : num                                       #expr_none
    | lhs=expr op=(PLUS|MINUS) rhs=expr         #expr_additive
    | lhs=expr op=(ASTERISK | SLASH) rhs=expr   #expr_multipricative
    ;

num
    : UINT
    ;

PLUS: '+';
MINUS: '-';
ASTERISK: '*';
SLASH: '/';

UINT: [0-9]+;

WS: [ \t]+ -> skip;