grammar firstHomework;

/*
// why missing A?
input : A;
fragment A: [Aa];
*/

// => 字句の定義がないから
input : ONE;

ONE : A;
fragment A: [Aa];
