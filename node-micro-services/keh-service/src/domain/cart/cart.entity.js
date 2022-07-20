import CartProduct from './cartproduct.entity.js'
import Order from '../order/order.entity.js'

export default class Cart {
    products = []
    removedProducts = []
    name:any

    constructor(name:any) {
        this.name = name
    }

    addProduct = (product) => {
        let addedProduct = this.products.filter(f => f.product == product);
        if(addedProduct)
            addedProduct.addQuantity()
        else {
            const cartProduct = new CartProduct(product);
            this.products.push(cartProduct);
        }
    }

    removeProduct = (product) => {
        let existingProduct = this.products.filter(f => f.product == product);
        if(existingProduct) {
            const quantity = existingProduct.deleteQuantity()
            if(quantity == 0) {
                this.removedProducts.push(product)
                this.products = this.products.filter(f => f.product != product);
            }
        }
    }

    getRemovedProducts = () => {
        return this.removeProducts
    }

    getProducts = () => {
        return this.products
    }

    checkOut = () => {
        return new Order(this.products)
    }
}