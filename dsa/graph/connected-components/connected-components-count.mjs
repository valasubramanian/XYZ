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
    for(let node in data) {
        const num = Number(node);
        if(!nodes.includes(num)) nodes.push(num);
        for(let subNode of data[node]) {
            const subNum = Number(subNode);
            if(!nodes.includes(subNum)) 
                nodes.push(subNum);
        }
    }
    return nodes;
}

const countConnectedComponents = () => {
    const nodes = buildNodesList(components_data);
    let visited = new Set(); let componentCount = 0;
    for(let node of nodes) {
        if(traverseFromNode(node, visited))
            componentCount++;
    }
    console.log(componentCount);
}

const traverseFromNode = (startNode, visited) => {
    if(visited.has(startNode)) return false;

    visited.add(startNode);

    let queue = [startNode];
    while(queue.length > 0) {
        const current = queue.shift();
        for(let neighbour of components_data[current]) {
            visited.add(neighbour);
            queue.push(neighbour);
        }
    }

    return true;
}

console.log(countConnectedComponents());

