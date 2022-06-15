/* 
    Javascript OOPS - Object Properties
    JS Object properties are dynamic
    cmd: node f_properties.mjs
*/

// Constructor function method
function Employee (bsa, hra, flexi) {
    this.BaseSalary = bsa;
    this.HRA = hra;
    this.Flexi = flexi;
    this.GetSalary = () => this.BaseSalary + this.HRA + this.Flexi;
    this.GetId = () => {
        return this.Id || undefined
    }
    this.GetName = () => {
        return this.Name || undefined
    }
}

const employee1 = new Employee(1123, 123, 12);
console.log(employee1.GetId(), employee1.GetName())

employee1.Id = "Emp276"
employee1["Name"] = "Vala"
console.log(employee1.GetId(), employee1.GetName(), "Name" in employee1)

console.log(Object.keys(employee1))

for(let prope in employee1) {
    console.log(prope, ' - ', employee1[prope], ' - ', typeof(employee1[prope]))
}