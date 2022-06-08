//node --experimental-modules dft.iterative.mjs
import directed_graph from '../data/directed_graph.mjs'

const depthFirstTraversal = (startNode) => {
    if(directed_graph) {
        let stack = [ startNode ];
        while(stack.length > 0) {
            const current = stack.pop();
            console.log(current);
            for(let neighbour of directed_graph[current]) {
                stack.push(neighbour);
            }
        }
    }
}

depthFirstTraversal('a');