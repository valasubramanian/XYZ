/* 
    Javascript Number Data Types : Number, BigInt
    JavaScript Numbers are Always 64-bit Floating Point
    cmd: node numbers.mjs
*/
let number = 123
let numberObject = new Number(123)
console.log(number == numberObject)
console.log(number === numberObject)

console.log(parseInt("123213easd.123123"))
console.log(Number("123213easd"))
console.log(isNaN("123213easd"))
console.log(isNaN(Infinity))
console.log(Number("123213.123213"))
console.log(Number("123213.123213").toFixed(2))
console.log(Number("123213.123213").toPrecision(3))
console.log(Number.MAX_SAFE_INTEGER)
console.log(Number.MAX_VALUE)
console.log(Number.MIN_SAFE_INTEGER)
console.log(Number.MIN_VALUE)
console.log(Number.POSITIVE_INFINITY)
console.log(Number.NEGATIVE_INFINITY)
console.log(BigInt("123213123213"))