import React, { useState, useEffect } from "react";
import { TextBox } from "../../common/index";

const CreateUser = (props) => {

    return (
        <div className="row">
            <div className="mb-3 col">
                <TextBox value="" label="First name" />
            </div>
            <div className="mb-3 col">
                <TextBox value="" label="Last name" />
            </div>
            <div class="col-12">
                <button type="submit" class="btn btn-primary">Create</button>
            </div>
        </div>
    )
}

export default CreateUser