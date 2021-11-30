using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure.Functions
{
    public static class PurchaseOrderFunction
    {
        [FunctionName("PurchaseOrderFunction")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("PurchaseOrderFunction_Activity", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("PurchaseOrderFunction_Activity", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("PurchaseOrderFunction_Activity", "London"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }
    }
}