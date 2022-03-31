import React, { useState, useEffect } from "react";
import config from "../appsettings.json";
import { Table } from "reactable";

const Home = (props) => {

  const [callGetData, setCallGetData] = useState(true);
  const [gridData, setGridData] = useState([]);

  const columns = [
    { key: 'userId', name: 'ID' },
    { key: 'userName', name: 'Name' },
    { key: 'emailAddress', name: 'Email' }
  ];

  useEffect(() => {
    if(callGetData)
      getData();
  });

  const getData = () => {
    fetch(config.gatewayUrl + "GetUsers", {
      "method": "POST",
      "headers": {
        "content-type": "application/json",
        "accept": "application/json"
      },
      "body": JSON.stringify({"UserName":"vala","Password":"vala","MobileNumber":123123,"EmailAddress":"vala"})
    })
    .then(response => response.json())
    .then(response => {
      console.log(response);
      setGridData(response.result);
      setCallGetData(false);
    })
    .catch(err => {
      console.log(err);
      setGridData([]);
      setCallGetData(false);
    });
  }

  return (
      <>
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>

        <Table className="table" data={gridData} />
      </>
  );
}

export default Home;