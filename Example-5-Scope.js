//variable and function hoisting
var a = 5;
x(); //function declaration hoisted
function x(){
	a = 10; //variable declaration hoisted
	console.log(a);//10
	var a;
}
console.log(a);//5