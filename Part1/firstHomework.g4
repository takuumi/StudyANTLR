grammar firstHomework;

input : (command operand* NEWLINE)* EOF;

command :
          command DOT suffix    // LD.U
        | UNIT_CMD     // U_SRDBUF
        | CHARS CALC_SYM    // LD=
        | CHARS        // LD
        ;

operand :
          operand CORON DEVICE      // DM10 : z1
        | operand DOT CONST_NUMBER  // DM10.1
        | DEVICE                    // DM100
        | CONST_NUMBER              // #10, 10, $10
        | UNKNOWN                   // ???
        | CHARS                     // hoge (variables)
        ;


// command
UNIT_CMD : 'U_' CHARS;
CALC_SYM : '='
         | '&'
         | '^'
         | '+'
         | '-'
         | '*'
         | '/'
         ;

// operand
CONST_NUMBER : CONST_DEC          // #10
             | CONST_HEX          // $10
             | INT                // 10
             ;

DEVICE :
       | '*' DEVICE
       | '@' CHARS INT      // @MR0
       | CHARS INT '_' INT   // DM01_9
       | CHARS INT          // DM10
       ;
CONST_DEC : '#' INT        // #10
          | 'K' INT        // K10
          ;

// todo 桁指定
CONST_HEX : '$' [0-9A-Fa-f]+         // $10
          | 'H' [0-9A-Fa-f]+         //H10
          ;


CORON : ':';
DOT   : '.';
suffix : 'L'
       | 'D'
       | 'U'
       | 'F'
       | 'S'
       ;

UNKNOWN : '???';

CHARS : [A-Za-z]+ ;
INT : SIGN? DIGIT+;
FLOAT : SIGN? (REAL | EXP) ;

NEWLINE : [\r\n]+ ;
WS : [ ¥t] -> skip;

fragment REAL : DIGIT+ DOT DIGIT+;
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

