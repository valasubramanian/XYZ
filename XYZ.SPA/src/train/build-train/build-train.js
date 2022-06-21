import React, { useState, useEffect } from "react";
import { LinkedList } from '../../common/index'

const BuildTrain = (props) => {

    // const initialState = {
    //     value: 'Engine',
    //     next: {
    //         value: 'S1',
    //     }
    // }

    const initialState = {
        value: 'Engine',
        next: {
            value: 'S1',
            next: {
                value: 'S2',
                next: {
                    value: 'S3',
                    next: {
                        value: 'A1',
                        next: undefined
                    }
                }
            }
        }
    }

    const [data, setData] = useState(initialState)

    return (
        <div>
            <LinkedList data={data} />
        </div>
    )
}

export default BuildTrain