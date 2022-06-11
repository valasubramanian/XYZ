/* 
    Javascript String Data Types
    cmd: node string.mjs
*/
let string = "Valasubramanian \"Sunmugavel\""
let stringObject = new String("Valasubramanian \"Sunmugavel\"")
let stringConvert = String("Valasubramanian \"Sunmugavel\"")
console.log(string);
console.log(stringObject);
console.log(stringConvert);
console.log(string == stringObject && stringObject == stringConvert && string == stringConvert);
console.log(string === stringObject)
console.log(stringConvert === stringObject)
console.log(stringConvert === string)

console.log(string.slice(0, 15))
console.log(string.slice(16))
console.log(string.slice(60,94), string.slice(60,94).length)
console.log([...string])
console.log([...string].map((m) => m.toUpperCase()))
var arr = [ ...string ];
arr.forEach((v) => { v = v.toLowerCase(); }); // no return type
console.log(string.split())
console.log(string.split(''))
console.log(string.split(' '))
console.log(string.includes("Valasubramanian"))

