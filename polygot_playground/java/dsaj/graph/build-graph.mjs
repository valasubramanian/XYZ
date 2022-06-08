const buildUndirectedGraph = (edges) => {
    let graph = {};
    for(let edge of edges) {
        const [a, b] = edge;
        if(a) {
            graph[a] = !(a in graph) ? [] : graph[a];
            if(b) {
                graph[b] = !(b in graph) ? [] : graph[b];
                graph[a].push(b);
                graph[b].push(a);
            }
        }
    }
    return graph;
}

export default buildUndirectedGraph;