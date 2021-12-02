import React, { useState, useEffect } from "react";
import config from "../appsettings.json";
import { Table } from "reactable";
import { HubConnectionBuilder } from "@microsoft/signalr";

const Stocks = (props) => {

  const [connection, setConnection] = useState(null);
  const [stocksData, setStocksData] = useState([]);

  useEffect(() => {
    if(!connection) {
      fetch(config.getSignalRConnectionFunctionUrl, {
        "method": "GET",
        "headers": {
          "content-type": "application/json",
          "accept": "application/json"
        }
      })
      .then(response => response.json())
      .then(response => {
        console.log(response);
        const options = {
            accessTokenFactory: () => response.accessToken
        }
        let connection = new HubConnectionBuilder()
                              .withUrl(response.url, options)
                              .build();

        connection.start().then(() => console.log('connection started'));
        setConnection(connection);

      // const socket = new SignalR.HubConnectionBuilder()
      //     .withUrl(response.data.url, options)
      //     .build(SignalR.HttpTransportType.None)

      // connection.on('OnNewEvent', ProcessMyEvent);
      // connection.onclose(() => console.log('disconnected'));
      // console.log('connecting...');

      // connection.start({ withCredentials: false })
      //     .then(() => console.log('ready...'))
      //     .catch(console.error);

      })
      .catch(err => {
        console.log(err);
      });      
    }
  });

  return (
      <>
        <p>Stocks</p>
        <br />
        <Table className="table" data={stocksData} />
      </>
  );
}

export default Stocks;