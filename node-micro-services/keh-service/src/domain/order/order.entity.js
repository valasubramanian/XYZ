export default class Order {
    constructor(products) {
        this.products = products
    }

    getTotalCost = () => {
        let totalCost = 0
        if (this.products) {
            this.products.forEach(product => {
                totalCost += product.getTotalPrice()
            });
        }
        return totalCost
    }
}