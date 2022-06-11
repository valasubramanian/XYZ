/* 
    Javascript Data Types are Dynamic: Number, String & Object
    cmd: node dataTypes.mjs
*/
let x = Number('10')
let x2 = Number('20')
let f = Number('10.123')
var f2 = parseFloat('10.123')
var l = parseFloat('123984923.122348927498237897289234892398479823743')
let y = String(10)
let z = Boolean(0)
let xyz = { name: 'vala' }
let arr = [10, 11, 12]
let arrObj = [{ name: 'vala' }, { name: 'steve' }]

console.log(typeof(x), typeof(y), typeof(z), typeof(xyz), typeof(arr), typeof(arrObj))
console.log(x + x2)
console.log(x + x2)
console.log(x + x2 + f)
console.log(x + x2 + f2)
console.log(x + x2 + y)
console.log(y + x + x2)
console.log(x + y + z)
console.log(x, x2, y, z)
console.log(l)