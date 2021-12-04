import React, { useState, useEffect } from "react";
import config from "../appsettings.json";
import { Table } from "reactable";
import { HubConnectionBuilder, HttpTransportType } from "@microsoft/signalr";

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
        const options = {
            accessTokenFactory: () => response.accessToken
        }

        let connection = new HubConnectionBuilder()
                              .withUrl(response.url, options)
                              .build(HttpTransportType.None);

        connection.on('stocksUpdated', OnStocksUpdated);
        connection.onclose(() => console.log('connection closed'));
        connection.start({ withCredentials: false })
                    .then(() => console.log('connection started'))
                    .catch(err => { console.log(err); });

        setConnection(connection);
      })
      .catch(err => {
        console.log(err);
      });      
    }

    return () => {
      if(connection) {
        console.log('connection closed on page close');
        connection.stop();
      }
    };
  }, []);

  const OnStocksUpdated = (response) => {
    console.log('Stocks Updated');
    if(response && response.length > 0) {
      if(stocksData && stocksData.length > 0) {
        let _stocks = stocksData;
        let oldStock = _stocks.filter(f => f.id === response[0].id);
        if(oldStock && oldStock.length > 0) {
          _stocks.forEach(item => {
            if(item.id === oldStock[0].id)
              item.stockPrice = oldStock[0].stockPrice;
          });
        }
        else
          _stocks.push(response[0]);
        setStocksData(_stocks);
      }
      else
        setStocksData(response);
    }
  }

  return (
      <>
        <p>Stocks</p>
        <br />
        <Table className="table" data={stocksData} />
      </>
  );
}

export default Stocks;