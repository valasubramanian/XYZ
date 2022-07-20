import express from 'express'
import userRouter from './controllers/user.controller.js'
import cartRouter from './controllers/cart.controller.js'
import orderRouter from './controllers/order.controller.js'
import errorMiddleware from './common/error-handling/error.middleware.js'
import loggerMiddleware from './common/logger.middleware.js'

const app = express()
const port = 3000

app.use(loggerMiddleware)
app.use('/api/user', userRouter)
app.use('/api/cart', cartRouter)
app.use('/api/order', orderRouter)

app.all('*', (req, res) => {
    res.status(404).end("API Not Found !!!")
})

app.use(errorMiddleware)

app.listen(port, () => {
    console.log(`app listening at http://localhost:${port}`)
});