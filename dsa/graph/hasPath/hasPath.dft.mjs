// hasPath - Directed Graph - DFT
//node --experimental-modules hasPath.dft.mjs
import directed_graph from '../data/sample1.mjs'

const hasPathUsingDFT = (startNode, endNode) => {
    if(directed_graph) {
        let stack = [ startNode ];
        while(stack.length > 0) {
            const current = stack.pop();
            for(let neighbour of directed_graph[current]) {
                if(neighbour === endNode) return true;
                stack.push(neighbour);
            }
        }
        return false;
    }
    return false;
}

console.log(hasPathUsingDFT('e', 'c'));