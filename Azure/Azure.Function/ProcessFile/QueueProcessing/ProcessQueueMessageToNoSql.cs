using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Azure.Functions
{
    public static class ProcessQueueMessageToNoSql
    {
        // Processing Step 2 : Process Storage Queue message to No SQL database
        [FunctionName("ProcessQueueMessageToNoSql")]
        public static void Run([QueueTrigger("queue-book-items", Connection="AzureFileUploadStorage")] string jsonMessage, 
                                [CosmosDB("dbBooks", "bookContainer", ConnectionStringSetting="AzureCosmosDbConnection")] IAsyncCollector<BookModel> books,
                                ILogger log)
        {
            log.LogInformation($"ProcessQueueMessageToNoSql started");
            bool isCompleted = WriteBookData(books, jsonMessage, log);
            if(isCompleted)
                log.LogInformation($"ProcessQueueMessageToNoSql completed");
        }

        private static bool WriteBookData(IAsyncCollector<BookModel> books, string jsonMessage, ILogger log)
        {
            try {
                BookModel book = JsonConvert.DeserializeObject<BookModel>(jsonMessage);
                books.AddAsync(book);
                return true;
            }
            catch (Exception ex) {
                log.LogError(ex.InnerException.Message);
                return false;
            }
        }
    }
}
