import http from 'http'

const app = http.createServer()

app.on("request", (req, res) => {
    if(req.url === "/1") {
        console.log("request received from 1");
        res.end("I am from 3002 born on for 1 " + new Date().toUTCString())
    }
    else if(req.url === "/2") {
        console.log("request received from 2");
        for(let i = 0; i <= 100000; i++) {
            i = i
        }
        res.end("I am from 3002 born on for 2 " + new Date().toUTCString())
    }
    else if(req.url === "/3") {
        console.log("request received from 3");
        setTimeout(() => {
            //while(1);
            res.end("I am from 3002 born on for 3  " + new Date().toUTCString())
        }, 5000)
    }
    else if(req.url === "/4") {
        console.log("request received from 4");
        res.end("I am from 3002 born on for 4  " + new Date().toUTCString())
    }
});

app.listen(3002, () => {
    console.log(`app listening at http://localhost:3002`);
});