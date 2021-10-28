using System;
using System.IO;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace Azure.Functions
{
    public static class ProcessJsonDataToSql
    {
        [FunctionName("ProcessJsonDataToSql")]
        public static void Run([BlobTrigger("uploads/sql/{name}.json", Connection = "AzureFileUploadStorage")]Stream myBlob,
                                string name, 
                                ILogger log)
        {
            log.LogInformation($"ProcessJsonDataToSql FileName:{name}.json started");
            
            BookModel[] data = ReadFile(myBlob, log);
            
            if(data != null && data.Length > 0)
            {
                bool isCompleted = WriteFileData(data, log);
                if(isCompleted)
                    log.LogInformation($"ProcessJsonDataToSql FileName:{name}.json completed");
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

        private static bool WriteFileData(BookModel[] data, ILogger log)
        {
            try {
                string sqlDbConnecString = Environment.GetEnvironmentVariable("AzureSqlDatabaseConnection");
                SqlBulkCopy bulkcopy = new SqlBulkCopy(sqlDbConnecString);
                bulkcopy.DestinationTableName = "tblBooks";
                DataTable dataTable = Extensions.ToDataTable(data.AsEnumerable());
                bulkcopy.WriteToServer(dataTable);
                return true;
            }
            catch (Exception ex) {
                log.LogError(ex.InnerException.Message);
                return false;
            }
        }
    }
}
