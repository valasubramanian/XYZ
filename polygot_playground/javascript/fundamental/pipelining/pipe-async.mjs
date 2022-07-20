/* 
    Javascript Pipeline - Asynchronous
    used to refactor complex logic into smaller functions and merge them using pipe() function
    cmd: node pipe-async.mjs
*/

// Pipelining functions
const _addresses = ["20B, Rue Lafayette, 23423", "40B, Rue Lafayette, 34543", "10B, Rue Lafayette, 1231"]

// ES6 pipe implementation

const pipeAsyncAwait = (...functions) => (value) => {
    return functions.reduce(async (currentValue, currentFunction) => {
      return currentFunction(await currentValue);
    }, value);
};

const pipeAsyncPromise = (...functions) => (value) => {
    return functions.reduce((currentValue, currentFunction) => {
      return currentValue.then(cv => currentFunction(cv));
    }, Promise.resolve(value));
};

// Pipe function #1
const splitAddress = async (addresses) => {
    let _addresses = [];
    addresses.forEach(address => _addresses.push(address.split(",")));
    return _addresses;
}

// Pipe function #2
const trimAddress = async (addresses) => {
    let _addresses = [];
    addresses.forEach(address => {
        address = address.map(piece => piece.trim());
        _addresses.push(address)
    });
    return _addresses
}

// Pipe function #3
const createAddress = async (addresses) => {
    let _addresses = [];
    addresses.forEach(address => {
        address = { 'Door': address[0], 'Street': address[1], 'Code': address[2] }
        _addresses.push(address)
    });
    return _addresses
}


// Main function
    // const data1 = await splitAddress(addresses);
    // const data2 = await trimAddress(data1);
    // const data3 = await createAddress(data2);
    // return data3;
    
const generateAddressObjects_Promise = (addresses) => {
    return pipeAsyncPromise(splitAddress, trimAddress, createAddress)(addresses)
}

const generateAddressObjects_Await = async (addresses) => {
    return pipeAsyncAwait(splitAddress, trimAddress, createAddress)(addresses)
}

console.log(await generateAddressObjects_Await(_addresses));
generateAddressObjects_Promise(_addresses).then(console.log);

//splitAddress(_addresses).then(console.log)