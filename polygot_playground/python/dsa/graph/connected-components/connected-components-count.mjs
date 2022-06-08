// Count Connected Components - BFT
// node --experimental-modules connected-components-count.mjs

const components_data = {
    0: [8, 1, 5],
    1: [0],
    5: [0, 8],
    8: [0, 5],
    2: [3, 4],
    3: [2, 4],
    4: [3, 2]
};

const buildNodesList = (data) => {
    let nodes = [];

    const pushNode = (function(node) {
        const nodeValue = Number(node);
        if(!nodes.includes(nodeValue)) 
            nodes.push(nodeValue);
    });

    for(let node in data) {
        pushNode(node);
        for(let subNode of data[node]) {
            pushNode(subNode);
        }
    }
    return nodes;
}

const countConnectedComponents = () => {
    const nodes = buildNodesList(components_data);
    //console.log(nodes);
    let visited = new Set(); let componentCount = 0;
    for(let node in nodes) {
        console.log(node);
        if(traverseFromNode(node, visited))
            componentCount++;
    }
    return componentCount;
}

const traverseFromNode = (startNode, visited) => {
    if(visited.has(startNode)) return false;

    visited.add(startNode);
    
    let queue = [startNode];
    while(queue.length > 0) {
        const current = queue.shift();
        console.log(current);
        for(let neighbour of components_data[current]) {
            visited.add(neighbour);
            queue.push(neighbour);
        }
    }

    return true;
}

console.log(countConnectedComponents());

