using System;
using System.Text.RegularExpressions;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace LNDP_API.Services{

    public class ImageService : IImageService
    {
        
        public async Task<string> ConvertBase64ToUrl(string base64Data, string fileName)
        {
            try
            {
                var assetsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets");
                if (!Directory.Exists(assetsFolderPath))
                {
                    Directory.CreateDirectory(assetsFolderPath);
                }

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

                string urlPath = filePath.Replace("\\", "/");

                string baseUrl = "https://localhost:7032"; 
                string imageUrl = Path.Combine(baseUrl, "assets", fileName).Replace("\\", "/");
                return imageUrl;
            }
            catch (Exception ex)
            {
                return "Ocurrió un error al procesar la imagen" + ex.Message;
            }
        }

        public async Task<string> DeleteImageFromServer(string filePath)
    {
        try
        {
            // Verifica si la ruta del archivo no es nula o vacía
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return "La ruta de la imagen no es válida.";
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return "La imagen ha sido eliminada.";
            }
            else
            {
                return "La imagen no existe en la ubicación especificada.";
            }
        }
        catch (Exception ex)
        {
            return "Error al eliminar la imagen: " + ex.Message;
        }
    }
    }
}