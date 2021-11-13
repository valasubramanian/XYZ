using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure.Functions
{
    public static class ProcessQueueMessageToNoSql
    {
        // Processing Step 2 : Process Storage Queue message to No SQL database
        [FunctionName("ProcessQueueMessageToNoSql")]
        public static void Run([QueueTrigger("queue-book-items", Connection="AzureFileUploadStorage")] string jsonMessage, 
                                ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed");
        }
    }
}
