/* 
    Javascript OOPS - Objects
    Create JS Object using Constructor Functions
    In JS, functions are objects
    cmd: node c_objects_constructor.mjs
*/

// Constructor function method
function Employee (bsa, hra, flexi) {
    this.BaseSalary = bsa;
    this.HRA = hra;
    this.Flexi = flexi;
    this.GetSalary = () => this.BaseSalary + this.HRA + this.Flexi;
}

const employee1 = new Employee(1123, 123, 12);
const employee2 = new Employee(2123, 223, 22);
const employee3 = new Employee(3123, 323, 32);
console.log(employee1.GetSalary(), employee2.GetSalary(), employee3.GetSalary())

// internall calls Employee.call({}, 3123, 323, 32)