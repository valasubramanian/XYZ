/* 
    Javascript Pipeline - Synchronous
    used to refactor complex logic into smaller functions and merge them using pipe() function
    cmd: node pipe.mjs
*/

// Pipelining functions
const _addresses = ["20B, Rue Lafayette, 23423", "40B, Rue Lafayette, 34543", "10B, Rue Lafayette, 1231"]

// ES6 pipe implementation
//const pipe = (...fns) => x => fns.reduce((v, f) => f(v), x)
const pipe = (...functions) => (value) => {
    return functions.reduce((currentValue, currentFunction) => {
      return currentFunction(currentValue);
    }, value);
};

// Pipe function #1
const splitAddress = (addresses) => {
    let _addresses = [];
    addresses.forEach(address => _addresses.push(address.split(",")));
    return _addresses;
}

// Pipe function #2
const trimAddress = (addresses) => {
    let _addresses = [];
    addresses.forEach(address => {
        address = address.map(piece => piece.trim());
        _addresses.push(address)
    });
    return _addresses
}

// Pipe function #3
const createAddress = (addresses) => {
    let _addresses = [];
    addresses.forEach(address => {
        address = { 'Door': address[0], 'Street': address[1], 'Code': address[2] }
        _addresses.push(address)
    });
    return _addresses
}

// Main function
const generateAddressObjects = (addresses) => {
    return pipe(splitAddress, trimAddress, createAddress)(addresses)
}

console.log(generateAddressObjects(_addresses))