import http from 'http'
import * as fs from 'fs'

// Read File Method
// HTTP request to read the whole file
const app = http.createServer((req, res) => {
    const content = fs.readFileSync('./big-file.txt', { encoding: "utf8" });
    res.end(content)
});

app.listen(3000)