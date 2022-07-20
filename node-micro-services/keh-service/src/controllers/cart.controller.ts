import { Router } from 'express'
// import {
//   catalog,
//   carts,
//   orders,
//   currency
// } from '../infrastructure/dbContext.js'

const cartRouter = Router()

const getCard = (name?:any) => {
  return []
  // if(name) {
  //   const cart = carts.filter(c => c.name === name)
  //   if (!cart) {
  //     cart = new Cart(name)
  //     carts.push(cart)
  //     return getCard(name)
  //   }
  //   else
  //     return cart[0]
  // }
  // else
  //   return carts.filter(c => c.name === "default")[0]
}


cartRouter.get('/add/:name', (req, res) => {
  // const product = new Product(req.params.name, new Price(150, currency))
  // getCard().addProduct(product)
  res.end('Product added');
});

cartRouter.get('/:cartname/add/:name', (req, res) => {
  // const product = new Product(req.params.name)
  // getCard(req.params.cartname).addProduct(product, new Price(150, currency))
  res.end('Product added');
});

cartRouter.get('/remove/:name', (req, res) => {
  // const product = new Product(req.params.name, new Price(150, currency))
  // getCard().removeProduct(product)
  res.end('Product removed');
});

cartRouter.get('/view', (req, res) => {
  //res.json(getCard().getProducts());
});

cartRouter.get('/view/removed', (req, res) => {
  //res.json(getCard().getRemovedProducts());
});

export default cartRouter;
