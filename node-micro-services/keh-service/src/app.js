import express from 'express'
import userRouter from './controllers/user.controller.js'
import cartRouter from './controllers/cart.controller.js'
import orderRouter from './controllers/order.controller.js'

const app = express()
const port = 3000

app.use('/api/user', userRouter)
app.use('/api/cart', cartRouter)
app.use('/api/order', orderRouter)

app.listen(port, () => {
    console.log(`app listening at http://localhost:${port}`)
});