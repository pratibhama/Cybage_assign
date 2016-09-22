//function expression
//named function
var x = function square(a){
 return a * a
};

console.log(x(5));//25
//OR
x(5);//25

//anonymous function
var y = function(a){
 return a * a
};

y(6);//36

//advantage of named function expression
var factorial = function fac(n) { 
  return n<2 ? 1 : n*fac(n-1) 
};

console.log(factorial(3));//6