using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ImageResizer;
using System.Drawing;
using System.Drawing.Imaging;

namespace Azure.Function
{
    public static class ResizeImage
    {
        [FunctionName("ResizeImage")]
        public static void Run([BlobTrigger("uploads/images/{name}", Connection = "AzureFileUploadStorage")] Stream image,
                                [Blob("uploads/images/small/{name}", FileAccess.Write, Connection = "AzureFileUploadStorage")] Stream imageSmall,
                                [Blob("uploads/images/big/{name}", FileAccess.Write, Connection = "AzureFileUploadStorage")] Stream imageBig,
                                string name,
                                ILogger log)
        {
            log.LogInformation($"ResizeImage FileName:{name} started");

            try
            {
                var smallImageSettings = new ImageResizer.ResizeSettings
                {
                    MaxWidth = 200,
                    MaxHeight = 200,
                    Format = "png"
                };

                var bigImageSettings = new ImageResizer.ResizeSettings
                {
                    Width = 600,
                    Height = 600,
                    Format = "png"
                };

                ImageResizer.ImageBuilder.Current.Build(image, imageSmall, smallImageSettings);
                ImageResizer.ImageBuilder.Current.Build(image, imageBig, bigImageSettings);
            }
            catch(Exception ex)
            {
                log.LogError(ex.InnerException.Message);
            }
            
            log.LogInformation($"ResizeImage FileName:{name} completed");
        }
    }
}
