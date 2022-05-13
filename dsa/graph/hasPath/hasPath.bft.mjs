// hasPath - Directed Graph - BFT
//node --experimental-modules hasPath.bft.mjs
import graph from '../data/sample1.mjs'

const hasPathUsingBFT = (startNode, endNode) => {
    if(graph) {
        let queue = [startNode];
        while(queue.length > 0) {
            const current = queue.shift();
            for(let neighbour of graph[current]) {
                if(neighbour === endNode) return true;
                queue.push(neighbour);
            }
        }
        return false;
    }
    return false;
}

console.log(hasPathUsingBFT('a', 'e'));