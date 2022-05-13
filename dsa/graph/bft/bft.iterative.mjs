//node --experimental-modules bft.iterative.mjs
import graph from '../data/sample1.mjs'

const breadthFirstTraversal = (startNode) => {
    if(graph) {
        let queue = [startNode];
        console.log(startNode);
        while(queue.length > 0) {
            const current = queue.shift();
            for(let neighbour of graph[current]) {
                console.log(neighbour);
                queue.push(neighbour);
            }
        }
    }
}

breadthFirstTraversal('a');