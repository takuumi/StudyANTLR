grammar submit1;

input
    : oneline*;

oneline
    : mnemonic
    | linecomment
    ;

mnemonic
    : separator* command (separator operand separator*)* (EOL+ | EOF);

command
    : IDENTIFIER SUFFIX?                        // LD=, CAL++.L
    | IDENTIFIER operator+ SUFFIX?              // LD.U, U_SRDBUF, LD, LD=, CAL<<
    ;

separator
    : SEPARATOR+;

linecomment
    : LINECOMMENT  (EOL+ | EOF);


operator
    : EQUAL
    | AND
    | HAT
    | PLUS
    | MINUS
    | MUL_OR_INDIRECT
    | SLASH
    | GT
    | LT
    | VBAR
    | TILDA
    ;

operand
    : literal
    | operand COLON index       // DM10:z1, DM10#1
    | indirect                  // *DM109, *@DM200, #TM10, #TM0.1
    | wordbit                   // DM10.1
    | local                     // @DM10, @DM10.1
    | IDENTIFIER                // hoge (variables), _MAIN, DM100, DM10_0
    ;

index
    : IDENTIFIER
    | const_number
    ;

wordbit
    : IDENTIFIER DOTINT
    ;

indirect
    : MUL_OR_INDIRECT IDENTIFIER
    | MUL_OR_INDIRECT local
    | OLDINDIRECT
    | OLDINDIRECT DOTINT
    ;

local
    : ATMARK IDENTIFIER             // @EM0
    | ATMARK wordbit                // @DM0.1
    | ATMARK CONST_DEC_NUMBER       // @0
    ;

literal
    : const_string          // "hoge"
    | const_number          // #10, 10, $10
    | UNDEFINE              // ???
    ;

const_number
    : const_dec_number      // #10, 10
    | const_hex_number      // $10
    | const_float           // 10
    ;

const_string
    : CONST_STRING
    ;

const_dec_number
    : CONST_DEC_NUMBER
    ;

const_hex_number
    : CONST_HEX_NUMBER
    ;

const_float
    : CONST_FLOAT
    | DOTINT
    ;

EQUAL               : '=';
AND                 : '&';
HAT                 : '^';
PLUS                : '+';
MINUS               : '-';
MUL_OR_INDIRECT     : '*';
SLASH               : '/';
GT                  : '>';
LT                  : '<';
VBAR                : '|';
TILDA               : '~';
COLON               : ':';
ATMARK              : '@';
UNDEFINE            : '???';

DOTINT              : DOT DEC_DIGIT+;                    // DM10.0　と .1　は意味解析
OLDINDIRECT         : SHARP T M DEC_DIGIT+;              // #TM

EOL                 : '\r' | '\n' | '\r\n';
SEPARATOR           : (' ' | '\t')+;
//LINECOMMENT         : SEMICOLLON  (~([\n] | [\r] | [\r\n]))*;
LINECOMMENT         : SEMICOLLON  (~[EOL])*;
CONST_DEC_NUMBER                              // 10進即値
    : SIGN? DECIMAL_HEAD? SIGN? DEC_DIGIT+
    ;

CONST_HEX_NUMBER                              // 16進即値
    : HEX_HEAD HEX_DIGIT+
    ;

CONST_FLOAT                                   // 浮動少数即値
    : DECIMAL_HEAD? FLOAT
    ;

CONST_STRING
    : DOUBLEQUATE (ESC_QUOTE | ~["])* DOUBLEQUATE
    ;

SUFFIX : DOT ALPHABETS ALPHABETS?;
IDENTIFIER : [A-Za-z0-9_]+;


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
fragment ASTERISK       : '*';
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
