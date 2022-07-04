/* 
    Javascript ES6 Variables & Scope
        var -> scope within function it is declared
        let -> scope within block it is declared
        const -> scope within block it is declared, but cannot be modified

    cmd: node 1_var_let_const.mjs
*/

function HiVar() {
    console.log('Var')
    for(var i = 0; i < 5; i++) {
        console.log(i)
    }

    function last() {
        i++
        console.log(i)  //  i is 6
        i++
        var j = i * 2
    }

    const last_arrow = () => console.log(i)  //  i is 7

    console.log(i) //  i is 5
    last()
    last_arrow()
    //console.log(j) // j is not defined
}

function HiLet() {
    console.log('Let')
    for(let i = 0; i < 5; i++) {
        console.log(i)
    }
    // console.log(i) //  i is not defined
}

function HiConst() {
    console.log('Let')
    for(const i = 0; i < 5; i++) { // Assignment to constant variable.
        console.log(i)
    }
    // console.log(i) //  i is not defined
}


HiVar()
HiLet()
HiConst()