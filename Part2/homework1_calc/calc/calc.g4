grammar calc;

input : lhs=DISITS PLUS rhs=DISITS EOF      # calc_add
      ;

DISITS : [0-9]+;
PLUS   : '+';