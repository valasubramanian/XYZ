import React, { useState, useEffect } from "react";

const TextBox = (props) => {

    const [value, setValue] = useState('')

    useEffect(() => {
        if (value !== props.value)
            setValue(props.value)
    }, [props.value])

    return (
        <>
            <label class="form-label">{props.label}</label>
            <input type="text" class="form-control" value={value} onChange={(e) => setValue(e.target.value)}></input>
        </>
    )
}

export default TextBox