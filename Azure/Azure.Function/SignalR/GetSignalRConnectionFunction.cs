using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Azure.Functions
{
    public static class GetSignalRConnectionFunction
    {
        [FunctionName("GetSignalRConnectionFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [SignalRConnectionInfo(HubName="stocks", ConnectionStringSetting="AzureSignalRConnection")] SignalRConnectionInfo connectionInfo,
            ILogger log)
        {
            log.LogInformation("GetSignalRConnectionFunction function completed.");
            return new OkObjectResult(connectionInfo);
        }
    }
}
