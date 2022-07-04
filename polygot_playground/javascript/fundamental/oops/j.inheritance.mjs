/* 
    Javascript Object Inheritance ES6
    cmd: node j.inheritance.mjs
*/
class Employee {
    constructor(basic, hra, flexi) {
        this.Basic = basic;
        this.HRA = hra;
        this.Flexi = flexi;
    }

    GetSalary = () => this.Basic + this.HRA + this.Flexi;
}

class Intern extends Employee {
    constructor(stipend) {
        super(stipend, 0, 0)
    }
}

const employee1 = new Employee(1123, 123, 12);
const employee2 = new Employee(2123, 223, 22);
const employee3 = new Intern(3123);
console.log(employee1.GetSalary(), employee2.GetSalary(), employee3.GetSalary())