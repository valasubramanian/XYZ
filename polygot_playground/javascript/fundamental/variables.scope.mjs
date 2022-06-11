/* 
    Javascript Variables Scope
    cmd: node variables.scope.mjs
*/
var globalVariable = "global";
const TryVariables = (parameter) => {
    console.log(globalVariable);
    globalVariable = "parameter --> " 
                            + parameter;
    let localVariable = "I'm a local boy";
    const constVariable = "I'm a constant man";
    const innerFunction = () => {
        console.log(globalVariable);
        var globalVariable = "function modified global";
        var fnGlobalVariable = "function global variable";
        let fnLocalVariable = "function local variable";
        console.log(globalVariable);
        console.log(localVariable);
        console.log(constVariable);
        localVariable = "I'm still a local boy";
        // constVariable = "I'm still a constant man"; --> TypeError: Assignment to constant variable.
    }

    innerFunction();

    // console.log(fnGlobalVariable); --> ReferenceError: fnGlobalVariable is not defined
    // console.log(fnLocalVariable); --> ReferenceError: fnLocalVariable is not defined
    console.log(globalVariable);
    console.log(localVariable);
}

TryVariables(globalVariable);
console.log(globalVariable);
// console.log(localVariable); // --> ReferenceError: localVariable is not defined