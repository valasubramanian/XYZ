import http from 'http'
import * as fs from 'fs'

// Read Stream Method
// HTTP request to read the whole file as chunks
const app = http.createServer((req, res) => {
    const readStream = fs.createReadStream('./big-file.txt', { highWaterMark: 90000, encoding: "utf8" });
    readStream.on("open", (content) => {
        readStream.pipe(res)
    });
    readStream.on("error", (err) => {
        res.end(err)
    });
});

app.listen(3000)