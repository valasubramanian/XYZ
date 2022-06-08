// hasPath - Directed Graph - BFT
//node --experimental-modules hasPath.bft.mjs
import directed_graph from '../data/directed_graph.mjs'

const hasPathUsingBFT = (startNode, endNode) => {
    if(directed_graph) {
        let queue = [startNode];
        while(queue.length > 0) {
            const current = queue.shift();
            for(let neighbour of directed_graph[current]) {
                if(neighbour === endNode) return true;
                queue.push(neighbour);
            }
        }
        return false;
    }
    return false;
}

console.log(hasPathUsingBFT('a', 'e'));