// hasPath - Directed Graph - DFT
//node --experimental-modules hasPath.dft.mjs
import graph from '../data/sample1.mjs'

const hasPathUsingDFT = (startNode, endNode) => {
    if(graph) {
        let stack = [ startNode ];
        while(stack.length > 0) {
            const current = stack.pop();
            for(let neighbour of graph[current]) {
                if(neighbour === endNode) return true;
                stack.push(neighbour);
            }
        }
        return false;
    }
    return false;
}

console.log(hasPathUsingDFT('e', 'c'));