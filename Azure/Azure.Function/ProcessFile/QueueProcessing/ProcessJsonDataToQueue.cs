using System;
using System.IO;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;

namespace Azure.Functions
{
    public static class ProcessJsonDataToQueue
    {
        // Processing Step 1 : Read JSON data from blob and push to Storage Queue
        [FunctionName("ProcessJsonDataToQueue")]
        public static void Run([BlobTrigger("uploads/queue/{name}.json", Connection="AzureFileUploadStorage")] Stream jsonFile, 
                                string name, 
                                ILogger log)
        {
            
        }
    }
}
