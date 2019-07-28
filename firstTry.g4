grammar firstTry;

/* WSをスキップってどういう事だっけ？
input   : 'hello' ID EOF;
ID  : [a-z]+ ;
WS  : ' '+ -> skip ;
*/

// => 字句の定義からスキップを無視するということ。
input2   : ID* EOF;
ID  : [a-z];
WS  : ' '+ -> skip ;


/*
//The dot is a single-character wildcard that matches any single character.
input : .* EOF;
why doesnt work?
*/

// => 字句の定義がないから
// parser: Match any single token except for the end of file token. The “dot” operator is called the wildcard.
// lexser:The dot is a single-character wildcard that matches any single character.


/*
// why missing A?
input : A;
fragment A: [Aa];
*/

// => 字句の定義がないから
input5 : ONE;

ONE : A;
fragment A: [Aa];

/* memo
LINE_COMMENT
    : '//' ~('\n'|'\r')* ('\r\n' | '\r' | '\n')
        { $channel=HIDDEN; } //※またはSkip();
    ；
*/


// []と’’の違いは？
/*
UNIT_CMD : [U_] CHARS;
UNIT_CMD : 'U_' CHARS;
*/

// スペースを１つの構文木の中に入れるには？
input3 : .* EOF;
WSS : ' ';

// これは動作するが、スペースで区切る、というのをどこで?
input4 : IDENTIFIER+;
IDENTIFIER: [A-Za-z]+;
