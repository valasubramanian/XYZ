/* 
    Javascript ES6 Arrow Function
    cmd: node 3_arrow_function.mjs
*/

class Employee {
    baseSalary = 1298371;
    hra = 12381;
    flexi = 3489573;
    getSalary = () => this.baseSalary + this.hra + this.flexi;
    getBonusSalary = (bonus) => { 
        return this.getSalary() + bonus
    }
}

const employee = new Employee()
console.log(employee.getSalary())
console.log(employee.getBonusSalary(123))