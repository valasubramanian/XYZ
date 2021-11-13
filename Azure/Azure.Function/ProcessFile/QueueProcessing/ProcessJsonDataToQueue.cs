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
        // Processing Step 1 : Read JSON data from blob and push to Storage Queue as message
        [FunctionName("ProcessJsonDataToQueue")]
        public static void Run([BlobTrigger("uploads/queue-book-items/{name}.json", Connection="AzureFileUploadStorage")] Stream jsonFile, 
                                [Queue("queue-book-items", Connection="AzureFileUploadStorage")] IAsyncCollector<string> booksQueue,
                                string name, 
                                ILogger log)
        {
            log.LogInformation($"ProcessJsonDataToQueue FileName:{name}.json started");
            
            BookModel[] data = ReadFileData(jsonFile, log);
            
            if(data != null && data.Length > 0)
            {
                bool isCompleted = PushFileDataToQueue(data, booksQueue, log);
                if(isCompleted)
                    log.LogInformation($"ProcessJsonDataToQueue FileName:{name}.json completed");
            }
        }

        private static BookModel[] ReadFileData(Stream jsonFile, ILogger log)
        {
            try
            {
                StreamReader reader = new StreamReader(jsonFile);
                string jsonContent = reader.ReadToEnd();
                BookModel[] data = JsonConvert.DeserializeObject<BookModel[]>(jsonContent);
                return data;
            }
            catch (Exception ex) {
                log.LogError(ex.InnerException.Message);
                return null;
            }
        }

        private static bool PushFileDataToQueue(BookModel[] data, IAsyncCollector<string> booksQueue, ILogger log)
        {
            try 
            {
                foreach (var item in data)
                {
                    string jsonMessage = JsonConvert.SerializeObject(item);
                    booksQueue.AddAsync(jsonMessage);
                }
                return true;
            }
            catch (Exception ex) {
                log.LogError(ex.InnerException.Message);
                return false;
            }
        }
    }
}
