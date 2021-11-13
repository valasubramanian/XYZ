using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using FFMediaToolkit;
using FFMediaToolkit.Decoding;
using FFMediaToolkit.Graphics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Azure.Function
{
    public static class GenerateVideoThumbnail
    {
        [FunctionName("GenerateVideoThumbnail")]
        public static void Run([BlobTrigger("uploads/videos/{name}", Connection = "AzureFileUploadStorage")] Stream video,
                                [Blob("uploads/images/thumbnail/{name}", FileAccess.Write, Connection = "AzureFileUploadStorage")] Stream thumbnail,
                                string name, ILogger log)
        {
            log.LogInformation($"GenerateVideoThumbnail FileName:{name} started");

            try
            {
                using(var file = MediaFile.Open(video))
                {
                    file.Video.TryGetNextFrame(out var imageData);
                    imageData.ToBitmap().SaveAsJpeg(thumbnail);
                }
            }
            catch(Exception ex)
            {
                log.LogError(ex.InnerException.Message);
            }
            
            log.LogInformation($"GenerateVideoThumbnail FileName:{name} completed");
        }

        public static Image<Bgr24> ToBitmap(this ImageData imageData)
        {
            return Image.LoadPixelData<Bgr24>(imageData.Data, imageData.ImageSize.Width, imageData.ImageSize.Height);
        }
    }
}
