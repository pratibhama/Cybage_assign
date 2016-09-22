//Scope - Global scope
var a = 2;
function x(){
	a = 3;//'a' is global
	console.log(a);//3
}
x();
console.log(a);//3

//Scope - Local scope
var a = 2;
function x(a){
	a = 3;//'a' is local
	console.log(a);//3
}
x();
console.log(a);//2