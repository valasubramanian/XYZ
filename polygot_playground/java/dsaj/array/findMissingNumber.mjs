//node --experimental-modules findMissingNumber.mjs
const findMissingNumber = (input) => {
    if(!Array.isArray(input)) {
        input = input.split(",").map(value => {
            return Number(value);
        });
    }

    let missedNumbers = [];
    for (const number of input) {
        const index = input.indexOf(number);
        if(index < input.length - 1) {
            let difference = input[index + 1] - number;
            for (let start = 1; start < difference; start++) {
                missedNumbers.push(number + start);
            }
        }
    }

    return missedNumbers;
}

//console.log(findMissingNumber("1, 2, 3, 4, 6, 7, 8, 9, 10"));
console.log(findMissingNumber([1, 2, 3, 4, 6, 7, 8, 9, 10]));
console.log(findMissingNumber([1, 2, 3, 4, 7, 10]));