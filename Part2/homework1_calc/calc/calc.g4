grammar calc;

input: expr EOF;

expr
    : num                                       #expr_none
    | op=(PLUS|MINUS) expr                      #expr_unary
    | lhs=expr op=(PLUS|MINUS) rhs=expr         #expr_additive
    | lhs=expr op=(ASTERISK | SLASH) rhs=expr   #expr_multipricative
    | funcname=IDENTIFIER OPEN_PAREN args+=expr CLOSE_PAREN #expr_funccall   //+=を使うと、同じ種類の構文要素リスト化できる
    ;

num
    : UINT
    | REAL
    ;

PLUS: '+';
MINUS: '-';
ASTERISK: '*';
SLASH: '/';

OPEN_PAREN: '(';
CLOSE_PAREN: ')';
COMMA: ',';

UINT: [0-9]+;

REAL : DEC_DIGIT* DOT DEC_DIGIT*;

WS: [ \t]+ -> skip;

fragment DEC_DIGIT      : [0-9];
fragment DOT            : '.';

fragment ID_START: [A-Za-z_];
fragment ID_CONTINUE: ID_START | [0-9];
IDENTIFIER: ID_START ID_CONTINUE*;