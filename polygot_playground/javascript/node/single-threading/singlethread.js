import http from 'http'

const app = http.createServer()

app.on("request", (req, res) => {
    if(req.url === "/get") {
        res.end(`Request completed`)
    }
    else if(req.url === "/wait") {
        console.log(`Request processing...`)
        while(1);
    }
    else res.end()
});

app.listen(3000, () => {
    console.log(`app listening at http://localhost:3000`)
});