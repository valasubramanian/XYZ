import http from 'http'
import fetch from 'node-fetch'

const app = http.createServer()

app.on("request", (req, res) => {
    res.end(`Request completed`)
});

app.listen(3001, () => {
    console.log(`app listening at http://localhost:3001`)
});

fetch("http://localhost:3002/1").then(res => res.text())
.then(res => console.log(res))
.catch((err) => console.log(err));

fetch("http://localhost:3002/2").then(res => res.text())
.then(res => console.log(res))
.catch((err) => console.log(err));

// fetch("http://localhost:3002/3").then(res => res.text())
// .then(res => console.log(res))
// .catch((err) => console.log(err));

// fetch("http://localhost:3002/4").then(res => res.text())
// .then(res => console.log(res))
// .catch((err) => console.log(err));