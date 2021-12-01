using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;

namespace Azure.Functions
{
    public static class BroadcastStocksFromCosmoDbFunction
    {
        [FunctionName("BroadcastStocksFromCosmoDbFunction")]
        public static void Run(
            [CosmosDBTrigger(
                databaseName: "dbStocks",
                collectionName: "stocks",
                ConnectionStringSetting = "AzureCosmosDbConnection",
                LeaseCollectionName = "leases",
                CreateLeaseCollectionIfNotExists = true)] IReadOnlyList<Document> stocks, 
            [SignalR(
                HubName="stocks", 
                ConnectionStringSetting="AzureSignalRConnection")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            log.LogInformation("BroadcastStocksFromCosmoDb function started.");
            if (stocks != null && stocks.Count > 0)
            {
                signalRMessages.AddAsync(new SignalRMessage
                {
                    Target = "stocksUpdated",
                    Arguments = new[] { stocks }
                });
            }
            log.LogInformation("BroadcastStocksFromCosmoDb function completed.");
        }
    }
}
