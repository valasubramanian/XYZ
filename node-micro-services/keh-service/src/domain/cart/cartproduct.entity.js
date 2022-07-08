export default class CartProduct {
    constructor(product) {
        this.product = product
        this.quantity = 1
    }

    addQuantity = () => {
        this.quantity++
    }

    deleteQuantity = () => {
        this.quantity--
        return this.quantity
    }
}