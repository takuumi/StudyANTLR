grammar firstHomeworkRefactor;

input : oneline* EOF;
oneline : command WS* (operand WS*)* EOL*;

command :
          command SUFFIX            // LD.U
        | UNIT_CMD                  // U_SRDBUF
        | CHARS OPERATOR            // LD=
        | CHARS                     // LD
        ;

operand :
          device                    // DM100
        | wordbit                   // DM10.1
        | operand COLON device      // DM10:z1, @DM10:1
        | local                     // @DM10, @DM10.1
        | indirect                  // *DM10
        | unitdev                   // DM10_9
        | const_number              // #10, 10, $10
        | UNKNOWN                   // ???
        | CHARS                     // hoge (variables)
        ;

device : CHARS INT;
wordbit : device DOT INT;
indirect : ASTRISK device | ASTRISK ATMARK device;
local   : ATMARK device | ATMARK wordbit;
unitdev : device UNDERLINE INT;
const_number : CONST_DEC          // #10
             | CONST_HEX          // $10
             | INT                // 10
             ;

// command
UNIT_CMD : 'U_' CHARS;
OPERATOR : '='
         | '&'
         | '^'
         | '+'
         | '-'
//         | '*'                     // *@D10 が動かない。
         | '/'
         ;
SUFFIX : DOT CHARS;

// operand
COLON : ':';
DOT   : '.';
WS : ' ';
ATMARK : '@';
ASTRISK : '*';
UNDERLINE : '_';
UNKNOWN : '???';
EOL : '\r' | '\n';

                                     // 字句なのか、構文なのか。
CONST_DEC : '#' INT               // #10
          | 'K' INT               // K10
          ;

// todo 桁指定
CONST_HEX : '$' [0-9A-Fa-f]+      // $10
          | 'H' [0-9A-Fa-f]+      // H10
          ;


CHARS : [A-Za-z]+ ;
INT : SIGN? DIGIT+;

//FLOAT : SIGN? (REAL | EXP) ;        // DM2000.1が動かない
//fragment REAL : DIGIT+ DOT DIGIT+;
//fragment EXP : REAL E SIGN? DIGIT+;
fragment DIGIT : [0-9];
fragment SIGN : [+-];

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
