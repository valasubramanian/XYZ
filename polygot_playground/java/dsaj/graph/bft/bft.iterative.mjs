//node --experimental-modules bft.iterative.mjs
import directed_graph from '../data/directed_graph.mjs'

const breadthFirstTraversal = (startNode) => {
    if(directed_graph) {
        let queue = [startNode];
        console.log(startNode);
        while(queue.length > 0) {
            const current = queue.shift();
            for(let neighbour of directed_graph[current]) {
                console.log(neighbour);
                queue.push(neighbour);
            }
        }
    }
}

breadthFirstTraversal('a');