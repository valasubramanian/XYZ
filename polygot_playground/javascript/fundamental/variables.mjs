/* 
    Javascript Variables 
    cmd: node variables.mjs
*/
let x = 10
let y = 11
let z = 21
let xyz = 3298
var shouldAbc = false

function firstFunction() {
    var shouldAbc = true
    let abc = xyz
    xyz = x + y + z
    return true
}

function secondFunction() {
    if(isFirstFnExecuted)
        console.log('firstFunction Executed')
    if (shouldAbc)
        console.log(abc)
}

const isFirstFnExecuted = firstFunction()
console.log(isFirstFnExecuted)
console.log(x + y + z)
console.log(x, y, z)
y = "11"
z = "12"
console.log(x + y + z)
console.log(x, y, z)
console.log(xyz)
if(isFirstFnExecuted)
    secondFunction()