grammar firstHomework;

input : (command operand* NEWLINE)* EOF;

command : UNIT_CMD     // U_SRDBUF
        | CHARS        // LD
        ;

operand :
          operand ':' device   // DM10 : z1
        | operand '.' const_number   // DM10.1
        | device               // DM100
        | const_number        // #10, 10, $10
        | CHARS                // hoge (variables)
        ;

CHARS : [A-Za-z]+ ;
INT     : [0-9]+ ;

NEWLINE : [\r\n]+ ;
WS : [ ¥t] -> skip;

// command
UNIT_CMD : 'U_' CHARS;



// operand

const_number : CONST_DEC          // #10
             | CONST_HEX          // $10
             | INT                // 10
             ;
device : CHARS INT          // DM10
       | '@' CHARS INT      // @MR0
       ;
CONST_DEC : '#' INT;        // #10
CONST_HEX : '$' INT         // $10
          | '$' [A-Fa-f]    // $Aa
          ;







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

