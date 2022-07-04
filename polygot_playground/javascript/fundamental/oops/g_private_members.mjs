/* 
    Javascript OOPS - Object Members Abstraction
    Creating Private members using local variables
    cmd: node g_private_members.mjs
*/

function Employee (bsa, hra, flexi) {
    this.BaseSalary = bsa;
    this.HRA = hra;
    this.Flexi = flexi;

    /*********************************************/
    let eligibleForBonus = true;
    const defaultBonus = 100;
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
console.log(employee1.GetSalary(), employee1.eligibleForBonus)