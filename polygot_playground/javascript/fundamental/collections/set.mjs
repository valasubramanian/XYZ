// node set.mjs

const dataSet = new Set();
const dataSetDefined = new Set(["ABC", "abc", "IJK", "IJK", "xyz"]);
console.log(dataSet, dataSetDefined);
dataSet.add("").add("a").add("2")
console.log(dataSet, dataSet.has("2"));
dataSetDefined.delete("abc")
console.log(dataSetDefined);