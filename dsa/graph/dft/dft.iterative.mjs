//node --experimental-modules dft.iterative.mjs
import graph from '../data/sample1.mjs'

const depthFirstTraversal = (startNode) => {
    if(graph) {
        let stack = [ startNode ];
        while(stack.length > 0) {
            const current = stack.pop();
            console.log(current);
            for(let neighbour of graph[current]) {
                stack.push(neighbour);
            }
        }
    }
}

depthFirstTraversal('a');