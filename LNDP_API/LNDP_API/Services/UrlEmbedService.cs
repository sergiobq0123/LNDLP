using System;
using System.Text.RegularExpressions;

namespace LNDP_API.Services{

    public class UrlEmbedService : IUrlEmbedService
    {
        public string GetEmbedUrlYoutube(string url)
        {
            string pattern = @"[?&]v=([^&]+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(url);
            string videoCode = match.Groups[1].Value;
            string embedUrl = "https://www.youtube.com/embed/" + videoCode;
            return embedUrl;
            
        }
    }
}