export default class Catalog {
    products = []

    addProduct = (product) => {
        this.products.push(product)
    }

    removeProduct = (product) => {
        this.products = this.products.filter(f => f.product != product);
    }

    getProducts = () => {
        return this.products
    }
}