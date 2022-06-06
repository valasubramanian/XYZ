//node --experimental-modules findMissingNumber.mjs
const findMissingNumber = (input) => {
    if(!Array.isArray(input)) {
        input = input.split(",").map(value => {
            return Number(value);
        });
    }

    let missedNumbers = [];
    let queue = [input[0]];
    while(queue.length > 0) {
        const currentNumber = queue.pop();
        const index = input.indexOf(currentNumber); 
        if(index < input.length - 1) {
            const nextNumber = input[index + 1];
            queue.push(nextNumber);

            let difference = nextNumber - currentNumber;
            for (let start = 1; start < difference; start++) {
                missedNumbers.push(currentNumber + start);
            }
        }
    }
    
    return missedNumbers;
}

//console.log(findMissingNumber("1, 2, 3, 4, 6, 7, 8, 9, 10"));
console.log(findMissingNumber([1, 2, 3, 4, 6, 7, 8, 9, 10]));
console.log(findMissingNumber([1, 2, 3, 4, 7, 10]));