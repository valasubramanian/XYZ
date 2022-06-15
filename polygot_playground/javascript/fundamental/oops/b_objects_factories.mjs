/* 
    Javascript OOPS - Objects
    Create JS Object using Factory Function
    cmd: node b_objects_factories.mjs
*/

// Factory function method
const createEmployee = (bsa, hra, flexi) => {
    return {
        baseSalary : bsa,
        hra: hra,
        flexi: flexi,
        getSalary: function() {
            return this.baseSalary + this.hra + this.flexi;
        }
    }
}

const employee1 = createEmployee(1123, 123, 12);
const employee2 = createEmployee(2123, 223, 22);
console.log(employee1.getSalary(), employee2.getSalary())