/* 
    Javascript Object Prototypes __proto__
    cmd: node i_prototype.mjs
*/
let str = new String("Hi Hello - ")
String.prototype.reverse = function() {
    const chars = [...this.valueOf()]
    return chars.reverse().join("")
}
let reverseStr = str.reverse()
console.log(str.toString(), reverseStr)

let strNew = new String("New")
console.log(strNew.toString(), strNew.reverse())