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
    public static class ProcessJsonDataToNoSql
    {
        [FunctionName("ProcessJsonDataToNoSql")]
        public static void Run([BlobTrigger("uploads/nosql/{name}.json", Connection="AzureFileUploadStorage")] Stream myBlob, 
                                    [CosmosDB("dbBooks", "bookContainer", ConnectionStringSetting="AzureCosmosDbConnection")] IAsyncCollector<BookModel> books,
                                    string name, 
                                    ILogger log)
        {
            log.LogInformation($"ProcessJsonDataToNoSql FileName:{name}.json started");
            
            BookModel[] newData = ReadFile(myBlob, log);
            
            if(newData != null && newData.Length > 0)
            {
                bool isCompleted = WriteFileData(books, newData, log);
                if(isCompleted)
                    log.LogInformation($"ProcessJsonDataToNoSql FileName:{name}.json completed");
            }
        }

        private static BookModel[] ReadFile(Stream myBlob, ILogger log)
        {
            try {
                StreamReader reader = new StreamReader(myBlob);
                string jsonContent = reader.ReadToEnd();
                BookModel[] data = JsonConvert.DeserializeObject<BookModel[]>(jsonContent);
                return data;
            }
            catch (Exception ex) {
                log.LogError(ex.InnerException.Message);
                return null;
            }
        }

        private static bool WriteFileData(IAsyncCollector<BookModel> books, BookModel[] newBooks, ILogger log)
        {
            try {
                foreach (var book in newBooks)
                {
                   books.AddAsync(book);
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
