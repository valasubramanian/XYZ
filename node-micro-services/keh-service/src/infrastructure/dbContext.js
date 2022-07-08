import Cart from '../domain/cart/cart.entity.js'
import Catalog from '../domain/product/catalog.entity.js'
import Product from '../domain/product/product.entity.js'
import Price from '../domain/product/price.valueobject.js'
import Order from '../domain/order/order.entity.js'

const catalog = new Catalog()
const carts = [new Cart("default")]
const orders = []
const currency = "USD"

export {
    catalog,
    carts,
    orders,
    currency
}