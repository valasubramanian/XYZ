import http from 'http'

const app = http.createServer()

const fnAsync = async () => {
    return new Promise(() => {
        let i = false
        setTimeout(() => {
            i = true
        }, 5000)

        let j = 0;
        while(!i) {
            j++
        }
        return j
    })
}

app.on("request", async (req, res) => {
    if(req.url === "/1") {
        console.log("request received from 1");
        res.end("200 OK: I am from 3002 born on for 1 " + new Date().toUTCString())
    }
    else if(req.url === "/2") {
        console.log("request received from 2");
        const result = await fnAsync();
        if (result > 0)
            res.end("200 OK: I am from 3002 born on for 2 " + new Date().toUTCString())
        else
            res.end("500 ERR: I am from 3002 born on for 2 " + new Date().toUTCString())
    }
    else if(req.url === "/3") {
        console.log("request received from 3");
        setTimeout(() => {
            res.end("200 OK: I am from 3002 born on for 3  " + new Date().toUTCString())
        }, 3000)
    }
    else if(req.url === "/4") {
        console.log("request received from 4");
        setTimeout(() => {
            res.end("200 OK: I am from 3002 born on for 4  " + new Date().toUTCString())
        }, 2000)
    }
});

app.listen(3002, () => {
    console.log(`app listening at http://localhost:3002`);
});