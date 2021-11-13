using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure.Function
{
    // The following code demonstrates one approach to do this. 
    // The code is triggered from a queue message that contains text representing the input bob filename 
    // that needs reading, capitalizing, and then outputting to an output blob container.
    // Binding expression tokens can be used in binding expressions 
    // and are specified inside a pair of curly braces {…}. 
    // The {queueTrigger} binding token will extract the content of the incoming queue message that triggered a function.
    public static class CapitalizeFileContent
    {
        [FunctionName("CapitalizeFileContent")]
        public static void Run([QueueTrigger("blob-filepath-to-capitalize", Connection="AzureFileUploadStorage")] string blobPath,
                                [Blob("original-files/{queueTrigger}", FileAccess.Read, Connection = "AzureFileUploadStorage")] string originalName,
                                [Blob("capitalized-files/{queueTrigger}", FileAccess.Write, Connection = "AzureFileUploadStorage")] out string capitalizedName,
                                ILogger log)
        {
            log.LogInformation($"CapitalizeFileContent FileName:{blobPath} started");
            capitalizedName = originalName.ToUpperInvariant();   
            log.LogInformation($"CapitalizeFileContent FileName:{blobPath} completed");
        }
    }
}
