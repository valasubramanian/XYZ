/* 
    Javascript OOPS - Objects
    Create JS Object using Class
    cmd: node d_objects_class.mjs
*/

class Employee {
    constructor(basic, hra, flexi) {
        this.Basic = basic;
        this.HRA = hra;
        this.Flexi = flexi;
    }

    GetSalary = () => this.Basic + this.HRA + this.Flexi;
}

const employee1 = new Employee(1123, 123, 12);
const employee2 = new Employee(2123, 223, 22);
const employee3 = new Employee(3123, 323, 32);
console.log(employee1.GetSalary(), employee2.GetSalary(), employee3.GetSalary())