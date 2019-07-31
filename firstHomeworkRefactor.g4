grammar firstHomeworkRefactor;

input : oneline*;
//oneline : command WS* (operand WS*)* (EOL+ | EOF);
oneline : command (WS+ operand WS*)* (EOL+ | EOF);

command :
          command SUFFIX              // LD.U
        | IDENTIFIER OPERATOR*        // U_SRDBUF, LD, LD=, CAL<<
        | IDENTIFIER ASTRISK
        ;

operand :
        | wordbit                   // DM10.1
        | operand COLON index       // DM10:z1, DM10#1
        | local                     // @DM10, @DM10.1
        | indirect                  // *DM109
        | const_number              // #10, 10, $10
        | const_string              // "hoge"
        | UNKNOWN                   // ???
        | IDENTIFIER                // hoge (variables), _MAIN, DM100, DM10_0
        ;

index : IDENTIFIER | const_number;
wordbit : IDENTIFIER CONST_DEC;
indirect : ASTRISK IDENTIFIER | ASTRISK ATMARK IDENTIFIER;
local   : ATMARK IDENTIFIER | ATMARK wordbit | ATMARK CONST_DEC;
const_number : CONST_DEC          // #10
             | CONST_HEX          // $10
             | INT                // 10
//             | WORDBIT            // なんでここに必要なのだっけ？ CONST_DECしか知らない?
             ;

const_string : '"' IDENTIFIER '"';



// operand
COLON : ':';
DOT   : '.';
WS : ' ';
ATMARK : '@';
ASTRISK : '*';
UNDERLINE : '_';
UNKNOWN : '???';
EOL : '\r' | '\n';

OPERATOR : '='
         | '&'
         | '^'
         | '+'
         | '-'
         | ASTRISK
         | '/'
         | '<'
         | '>'
         | '|'
         ;

CONST_DEC : '#' INT             // #10
          | K INT               // K10
          | '#' FLOAT           // #1.23
          | K FLOAT             // #1.23
          | INT
          | FLOAT
          | FLOAT1
          ;

// todo 桁指定
CONST_HEX : '$' [0-9A-Fa-f]+      // $10
          | H [0-9A-Fa-f]+        // H10
          ;



INT : SIGN? DIGIT+;
FLOAT : SIGN? (REAL | EXP) ;
FLOAT1: WORDBIT;
WORDBIT : DOT INT;

SUFFIX : DOT [A-Za-z]+;

IDENTIFIER : [A-Za-z0-9_]+ ;


fragment REAL : DIGIT* DOT DIGIT*;
fragment EXP : REAL E SIGN? DIGIT+;
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
