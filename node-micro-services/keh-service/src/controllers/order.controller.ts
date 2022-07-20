import Router from 'express'

const orderRouter = Router()

orderRouter.get('/order/:cartname', (req, res) => {
  // const cart = getCard(req.params.cartname);
  // cart.checkOut().then((order) => {
  //   orders.push(order)
  //   res.end("Order Created !!! Total Price : " + order.getTotalCost());
  // });
});

export default orderRouter;
