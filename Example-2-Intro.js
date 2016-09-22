//Inspecting Data Types
var a;
console.log(typeof a); // "undefined"

a = "hello world";
console.log(typeof a); // "string"

a = 42;
console.log(typeof a); // "number"

a = true;
console.log(typeof a); // "boolean"

a = null;
console.log(typeof a); // "object" -- weird, bug

a = undefined;
console.log(typeof a); // "undefined"

a = { b: "c" };
console.log(typeof a);  // "object"