grammar firstHomework;

input : (command operand* NEWLINE)* EOF;

command : UNIT_CMD     // U_SRDBUF
        | CHARS        // LD
        ;


operand : CHARS         // hoge (variable)
        | indexDevice   // DM10 : z1
        | DEVICE        // DM100
        | CONST_NUMBER        // #10, 10, $10
        ;

indexDevice : DEVICE ':' ZINDEX       // DM10 : Z1
            | DEVICE ':' NUMBER       // DM10 : #19
            ;

CHARS : [A-Za-z]+ ;
INT     : [0-9]+ ;

NEWLINE : [\r\n]+ ;
WS : [ ¥t] -> skip;

// command
UNIT_CMD : 'U_' CHARS;



// operand

CONST_NUMBER : CONST_DEC          // #10
             | CONST_HEX          // $10
             | INT                // 10
             ;
DEVICE : CHARS INT;         // DM10
CONST_DEC : '#' INT;        // #10
CONST_HEX : '$' INT         // $10
          | '$' [A-Fa-f]    // $Aa
          ;

ZINDEX : Z INT;             // z10, Z10







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

