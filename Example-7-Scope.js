//Scope - Nested scope
function x() {
	var a = 1;
	function y() {
		var b = 2;
		function z() {
			var c = 3;
			console.log( a, b, c ); // 1 2 3
		}
		z();
		console.log( a, b );        // 1 2
	}
	y();
	console.log( a );               // 1
}
x();