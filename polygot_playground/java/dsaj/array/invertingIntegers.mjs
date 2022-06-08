//node --experimental-modules invertingIntegers.mjs
const invertingIntegers = (input) => {
    if(!Number(input)) 
        return 'Invalid number';

    let numbers = [...input.toString()];
    const isNegativeNumber = numbers[0] == '-';
    
    let invertedInteger = [];
    for (const number of numbers) {
        if(number != '-' && number != '+')
            invertedInteger.unshift(number);
    }

    if(isNegativeNumber)
        invertedInteger.unshift('-');

    return invertedInteger.toString();
}

console.log(invertingIntegers("12345678a9"));
console.log(invertingIntegers("+123456789"));
console.log(invertingIntegers("-123456789"));
console.log(invertingIntegers(123456789));
console.log(invertingIntegers(-987654321));