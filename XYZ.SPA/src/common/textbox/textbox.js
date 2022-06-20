import React, { useState, useEffect } from "react";

const TextBox = (props) => {

    const [value, setValue] = useState('')

    useEffect(() => {
        if (value !== props.value)
            setValue(props.value)
    }, [props.value])

    return (
        <input type="text" value={value} onChange={(e) => setValue(e.target.value)} />
    )
}

export default TextBox