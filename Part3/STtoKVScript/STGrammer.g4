grammar STGrammer;

input
    : oneline*;

oneline
    : stlang
    | linecomment
    ;

stlang
    : IDENTIFIER DEFINE expr;

expr
    : define                             #expr_define
    | lhs=expr (PLUS|MINUS) rhs=expr     #expr_additive
    ;

define
    : IDENTIFIER;

linecomment
    : LINECOMMENT  (EOL+ | EOF);
    

DEFINE              : COLON EQUAL;
COLON               : ':';
EQUAL               : '=';
PLUS                : '+';
MINUS               : '-';
ASTERISK            : '*';
SLASH               : '/';


EOL                 : '\r' | '\n' | '\r\n';

LINECOMMENT         : SLASH SLASH (~[EOL])*;

IDENTIFIER : [A-Za-z0-9_]+;


SEPARATOR           : (' ' | '\t')+ -> skip;


fragment FLOAT : SIGN? (REAL | EXP) ;
fragment REAL : DEC_DIGIT* DOT DEC_DIGIT*;
fragment EXP : REAL E SIGN? DEC_DIGIT+;
fragment SIGN : [+-];

fragment DECIMAL_HEAD   : K | SHARP;                    // 10進即値の頭文字
fragment HEX_HEAD       : H | DOLLAR;                   // 16進即値の頭文字
fragment DEC_DIGIT      : [0-9];
fragment HEX_DIGIT      : [0-9A-F];
fragment ESC_QUOTE      : DOUBLEQUATE DOUBLEQUATE;
fragment DOLLAR         : '$';
fragment SINGLE_QUOTE   : '\'';
fragment SHARP          : '#';
fragment SEMICOLLON     : ';';
fragment DOUBLEQUATE    : '"';
fragment DOT            : '.';

fragment ALPHABETS      : [a-zA-Z];
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
