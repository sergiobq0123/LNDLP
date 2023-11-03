namespace LNDP_API.Utils
{
    public interface IImageUtils
    {
        Task<string> ConvertBase64ToUrl(string base64Data, string name);
        bool IsValidUrl(string url);
    }
}