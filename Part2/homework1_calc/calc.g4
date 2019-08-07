grammar calc;

input : CHARS* EOF      # calc_test
      ;

CHARS : [a-z]+;

hogege