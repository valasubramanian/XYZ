import { createReadStream } from 'fs'

const readStream = createReadStream('./big-file.txt', { highWaterMark: 90000, encoding: "utf8" })

readStream.on("data", (data) => {
    console.log(data)
})

readStream.on("error", (err) => {
    console.log(err)
})