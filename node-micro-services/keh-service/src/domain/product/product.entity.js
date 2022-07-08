export default class Product {
    constructor(name, price, weight) {
        this.name = name
        this.price = price
        this.weight = weight
    }

    getTotalPrice = () => {
        return this.price + (this.weight * 0.1)
    }
}