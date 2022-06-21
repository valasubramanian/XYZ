import React, { useState, useEffect } from "react";
import TextBox from "../../textbox/textbox";

const LinkedListNode = (props) => {

    const [node, setNode] = useState({})
    const [isEdit, setEditNode] = useState(false)

    useEffect(() => {
        if (node !== props.node) {
            setNode(props.node)
        }
    },[props.node]) // , [props.node]

    const renderNextNode = () => {
        return (
            node.next?.value &&
            <>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-left-fill" viewBox="0 0 16 16">
                    <path d="m3.86 8.753 5.482 4.796c.646.566 1.658.106 1.658-.753V3.204a1 1 0 0 0-1.659-.753l-5.48 4.796a1 1 0 0 0 0 1.506z" />
                </svg>
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-caret-left-fill" viewBox="0 0 16 16">
                    <path d="m3.86 8.753 5.482 4.796c.646.566 1.658.106 1.658-.753V3.204a1 1 0 0 0-1.659-.753l-5.48 4.796a1 1 0 0 0 0 1.506z" />
                </svg>
                <LinkedListNode node={node.next} />
            </>
        )
    }

    const renderMainNode = () => {
        return (
            !isEdit ?
            <button 
                type="button" 
                className={props.isRootNode ? "btn btn-danger" : "btn btn-outline-primary"} 
                onClick={() => setEditNode(true)} >{node.value}</button> 
            :
            <TextBox style={{width:50}} 
                value={node.value} 
                onBlur={() => setEditNode(false) } 
                onChange={(v) => setNode({...node, value: v}) } />
        )
    }

    return (
        <>
            {console.log(node)}
            <span className="btn-group" role="group">
                {!props.isRootNode && <button type="button" className="btn btn-primary">+</button>}
                {renderMainNode()}
                {!props.isRootNode && <button type="button" className="btn btn-primary">+</button>}
            </span>
            {renderNextNode()}
        </>
    )
}

export default LinkedListNode