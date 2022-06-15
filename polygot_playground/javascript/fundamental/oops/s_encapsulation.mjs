/* 
    Javascript OOPS - Encapsulation
    cmd: node encapsulation.mjs
*/

class Emp {
    constructor(basic, hra, flexi) {
        this.basic = basic;
        this.hra = hra;
        this.flexi = flexi;
    }

    GetSalary = () => this.basic + this.hra + this.flexi;
}

const objEmp = new Emp(123123, 234234, 23432);
console.log(objEmp.GetSalary())