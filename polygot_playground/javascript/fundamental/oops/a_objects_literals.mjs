/* 
    Javascript OOPS - Objects Literals
    Create JS Object using Literals
    Objects Literals are collection of key value parirs
    cmd: node a_objects_literals.mjs
*/

let employee = {
    baseSalary : 1298371,
    hra: 12381,
    flexi: 3489573,
    getSalary: function() {
        return this.baseSalary + this.hra + this.flexi;
    }
}
console.log(employee.getSalary())