import http from 'http'
import * as os from 'os'
import cluster from 'cluster'

const app = http.createServer()
const numCPUs = os.cpus().length

app.on("request", (req, res) => {
    if(req.url === "/1") {
        console.log("request received from 1");
    }
    else if(req.url === "/2") {
        console.log("request received from 2");
        while(1);
    }
    else if(req.url === "/3") {
        console.log("request received from 3");
    }
    res.end("I am from 3002 born on " + new Date().toUTCString())
});

// For Master process
if (cluster.isPrimary) {
    console.log(`Master ${process.pid} is running`);
   
    // Fork workers.
    for (let i = 0; i < numCPUs; i++) {
      cluster.fork();
    }
   
    // This event is firs when worker died
    cluster.on('exit', (worker, code, signal) => {
      console.log(`worker ${worker.process.pid} died`);
    });
  }
  // For Worker
  else {
    app.listen(3002, () => {
        console.log(`app listening at http://localhost:3002`);
    });
}