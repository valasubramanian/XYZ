/* 
    Javascript ES6 Array.Map function
    cmd: node 2_array_map.mjs
*/

const array = ["a", "b", "c", "z"]

array.map(item => console.log(item))

array.map((item, index) => {
    console.log(index, item)
})