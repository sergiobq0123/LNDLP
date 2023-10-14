using System;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace LNDP_API.Services{

    public class ImageService : IImageService
    {
        private readonly string assetsFolderPath;
        private readonly string hostServer;

        public ImageService()
        {
            hostServer = "https://localhost:7032";
            assetsFolderPath = "wwwroot/assets";
        }
        public async Task<string> ConvertBase64ToUrl(string base64Data, string fileName)
        {
                if (string.IsNullOrWhiteSpace(Path.GetExtension(fileName)))
                {
                    fileName += ".jpg";
                }

                var filePath = Path.Combine(assetsFolderPath, fileName);

                byte[] imageBytes = Convert.FromBase64String(base64Data);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileStream.WriteAsync(imageBytes, 0, imageBytes.Length);
                }
                string uniqueQueryParam = DateTime.Now.Ticks.ToString();
                string imageUrl = $"{Path.Combine(hostServer, "assets", fileName).Replace("\\", "/")}?v={uniqueQueryParam}";
                return imageUrl;
        }
    }

}

