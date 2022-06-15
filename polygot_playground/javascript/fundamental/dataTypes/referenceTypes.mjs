/* 
    Javascript Reference Data Types are Non-Primitive Data types
        Object, Function, Array
    cmd: node referenceTypes.mjs
*/

let x = { value: 12 }, y = { value: 40 }
x = y
y.value = 30
console.log(x, y)

y = { value: 50 }
console.log(x, y)

x = { value: 10 }
function increase(x) {
    x.value++
}
increase(x)
console.log(x)