import React, { useState, useEffect } from "react";
import LinkedListNode from "./node/linked-list-node";

const LinkedList = (props) => {

    const [data, setData] = useState({})

    useEffect(() => {
        if (data !== props.data) {
            setData(props.data);
        }
    }, [props.data])

    return (
        <div>
            <LinkedListNode node={data} isRootNode={true} />
        </div>
    )
}

export default LinkedList