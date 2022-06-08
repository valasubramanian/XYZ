// //node --experimental-modules permuteArray.mjs
// // Input: [1,2,3]
// // Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

const permute = function(nums) {
    let results = [];
    let go = (current) => {
      if (current.length === nums.length){
        results.push(current);
        return;
      }
      nums.forEach(n => {
        if (!current.includes(n)){
            console.log(current);
            console.log(n);
          go([...current, n]);
        }
      });
    }
    go([]);
    return results;
};

permute([1,2,3]);
//console.log(permute([1,2,3]));