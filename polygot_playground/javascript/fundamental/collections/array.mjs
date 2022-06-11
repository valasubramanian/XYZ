/* 
    Javascript Array
    cmd: node array.mjs
*/
const arrayOfVala = [ "vala", "subramanian", 1991]
const newArrayOfVala = [ ...arrayOfVala, "developer", "cricket", "indian"]
console.log(...arrayOfVala)
console.log(...newArrayOfVala)
const [fname, lname, yob] = arrayOfVala
console.log(fname, lname, yob)

const arrayOfKevin = [ "kevin", "sambath", 1992 ]
const newArrayOfKevin = [ ...arrayOfKevin, "developer", "cricket", "indian" ]

const arrayOfValaAndKevin = arrayOfVala.concat(arrayOfKevin)
console.log(arrayOfValaAndKevin)

const arrayOfArray = [arrayOfVala, arrayOfKevin]
console.log(arrayOfArray)

const filterArray = arrayOfArray.filter(f => f.includes("vala"))
console.log(filterArray)

const splicedArray = arrayOfVala.splice(0, 1)
console.log(splicedArray)

const slicedArray = [ arrayOfVala.slice(0), arrayOfVala.slice(1), arrayOfVala.slice(0, 1), arrayOfVala.slice(1, 2)]
console.log(slicedArray)

const sortedArray = newArrayOfVala.sort()
console.log(sortedArray)

const points = [40, 100, 1, 5, 25, 10];
console.log(points.sort());

const strPoints = ['40', '100', '1', '5', '25', '10'];
console.log(strPoints.sort());

const strPointsCorrectWay = ['40', '100', '1', '5', '25', '10'];
console.log(strPointsCorrectWay.sort(function(a, b){return a - b}));

const strPointsCorrectWayDesc = ['40', '100', '1', '5', '25', '10'];
console.log(strPointsCorrectWayDesc.sort(function(a, b){return b - a }));

const arrayOfObjects = [{ id: 1, name: 'vala' }, { id: 3, name: 'bala' }, { id: 2, name: 'arun'  }, {id: 9, name: 'mano' }, { id: 5, name: 'david'}]
console.log(arrayOfObjects.sort());
console.log(arrayOfObjects.sort(function(a, b){ return a.id - b.id }));
console.log(arrayOfObjects.sort(function(a, b){
    let x = a.name.toLowerCase();
    let y = b.name.toLowerCase();
    if (x < y) {return -1;}
    if (x > y) {return 1;}
    return 0;
  }));