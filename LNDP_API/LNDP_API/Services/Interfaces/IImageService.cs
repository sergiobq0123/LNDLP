using LNDP_API.Dtos;
using LNDP_API.Models;

namespace LNDP_API.Services{
    public interface IImageService{
        Task<string> ConvertBase64ToUrl(string base64Data, string name);
    }
}