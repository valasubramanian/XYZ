import Address from "./address.valueobject.js"

export default class Customer {
    bankAccounts = []
    address = undefined

    constructor(name) {
        this.name = name
    }

    addBankAccount = (account) => {

    }

    updateAddress = (city) => {
        this.address = new Address(city)
    }
}