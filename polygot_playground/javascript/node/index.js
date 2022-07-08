import http from 'http'
import { fileURLToPath } from 'url'
import { dirname } from 'path'

const app = http.createServer()
const __filename = fileURLToPath(import.meta.url)
const __dirname = dirname(__filename)

app.on("request", (req, res) => res.write(`Request accepted for ${req.url} \n`))
app.on("request", (req, res) => console.log('middleware 1'))
app.on("request", (req, res) => console.log('middleware 2'))
app.on("request", (req, res) => console.log('middleware 3'))
//app.on("request", (req, res) => res.)
app.on("request", (req, res) => res.end("Request ended"))

app.listen(3000, () => {
    console.log(`app listening at http://localhost:3000`)
    console.log('filename -->', __filename)
    console.log('dirname -->', __dirname)
});