/* 
    Javascript OOPS - Get Set Properties
    Creating Read-only / Read-write properties
    cmd: node h_get_set_properties.mjs
*/

function Employee (bsa, hra, flexi) {
    this.BaseSalary = bsa;
    this.HRA = hra;
    this.Flexi = flexi;

    /*********************************************/
    let eligibleForBonus = true;
    Object.defineProperty(this, "eligibleForBonus", {
        get: () => eligibleForBonus,
        set: function(value) {
            eligibleForBonus = value;
        }
    });

    let defaultBonus = 100;
    Object.defineProperty(this, "defaultBonus", {
        get: () => defaultBonus,
    });

    const calculateSalary = () => {
        let salary = this.BaseSalary + this.HRA + this.Flexi;
        if (eligibleForBonus)
            salary += defaultBonus
        return salary
    }
    /*********************************************/

    this.GetSalary = () => {
        return calculateSalary()
    }

    
}

const employee1 = new Employee(1123, 123, 12);
console.log(employee1.eligibleForBonus, employee1.defaultBonus, employee1.GetSalary())

employee1.eligibleForBonus = false;
console.log(employee1.eligibleForBonus, employee1.defaultBonus, employee1.GetSalary())