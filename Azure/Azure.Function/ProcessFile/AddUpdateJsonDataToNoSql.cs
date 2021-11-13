using System;
using System.IO;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;

namespace Azure.Functions
{
    public static class AddUpdateJsonDataToNoSql
    {
        [FunctionName("AddUpdateJsonDataToNoSql")]
        public static void Run([BlobTrigger("uploads/nosqlupdate/{name}.json", Connection="AzureFileUploadStorage")] Stream myBlob, 
                                    [CosmosDB(ConnectionStringSetting="AzureCosmosDbConnection")] DocumentClient client,
                                    string name, 
                                    ILogger log)
        {
            log.LogInformation($"AddUpdateJsonDataToNoSql FileName:{name}.json started");
            
            BookModel[] newData = ReadFile(myBlob, log);
            
            if(newData != null && newData.Length > 0)
            {
                bool isCompleted = AddOrUpdateBooks(client, newData, log);

                if(isCompleted)
                    log.LogInformation($"AddUpdateJsonDataToNoSql FileName:{name}.json completed");
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

        private static bool AddOrUpdateBooks(DocumentClient client, BookModel[] newBooks, ILogger log)
        {
            try {
                Uri collectionUri = UriFactory.CreateDocumentCollectionUri("dbBooks", "bookContainer");
                foreach (var book in newBooks)
                {
                    var bookItem = client.CreateDocumentQuery(collectionUri).Where(t => t.Id == book.Index.ToString()).AsEnumerable().FirstOrDefault();
                    if(bookItem != null) 
                    {
                        bookItem.SetPropertyValue("Title", book.Title);
                    }
                    else
                    {
                        client.CreateDocumentAsync("dbBooks/bookContainer/", book);
                    }
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
