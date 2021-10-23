using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Azure.Functions
{
    public static class SumOfTwo
    {
        [FunctionName("SumOfTwo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function SumOfTwo processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            int first = 0; int second = 0;
            try {
                first = Convert.ToInt32(data.first);
                second = Convert.ToInt32(data.second);
            }
            catch(Exception ex) {

            }

            int third = first + second;

            return new OkObjectResult(third);
        }
    }
}
