import React, { useState, useEffect } from "react";
import { TextBox } from "../../common/index";

const CreateUser = (props) => {

    return (
        <div>
            <div>
                <span>First name:</span>
                <TextBox value="" />
            </div>
            <div>
                <span>Last name:</span>
                <TextBox value="" />
            </div>
        </div>
    )
}

export default CreateUser