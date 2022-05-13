// hasPath - Undirected Graph - DFT
//node --experimental-modules hasPath.undirected.mjs
import data from "../data/undirected_graph_data.mjs";
import buildUndirectedGraph from "../build-graph.mjs";

const hasPath = (graph, src, dest, visited) => {
    if(src === dest) return true;

    if(visited.has(src)) return false;

    visited.add(src);

    for(let neighbour of graph[src]) {
        if(hasPath(graph, neighbour, dest, visited))
            return true;
    }
    
    return false;
}

const undirectedPath = (src, dest) => {
    const graph = buildUndirectedGraph(data);
    console.log(graph);
    return hasPath(graph, src, dest, new Set());
}

console.log(undirectedPath('i', 'l'));
