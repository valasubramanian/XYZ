import React, { useState, useEffect } from "react";

const TextBox = (props) => {

    const [value, setValue] = useState('')

    useEffect(() => {
        if (value !== props.value)
            setValue(props.value)
    }, [props.value]) // , [props.value]

    const onChange = (e) => {
        setValue(e.target.value)
        props.onChange && props.onChange(e.target.value)
    }

    const onBlur = () => {
        props.onBlur && props.onBlur()
    }

    return (
        <>
            {console.log('textbox -> ', value)}
            {props.label && <label className="form-label">{props.label}</label>}
            <input type="text" style={props.style} className="form-control" value={value} onChange={(e) => onChange(e)} onBlur={onBlur}></input>
        </>
    )
}

export default TextBox