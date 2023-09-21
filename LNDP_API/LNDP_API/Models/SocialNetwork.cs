using LNDP_API.Models;

namespace LNDP_API.Models {
    public class SocialNetwork{
        public int Id {get;set;}
        public Artist? Artist {get; set; }
        public int? ArtistId {get; set; }
        public string? Instagram {get; set;}
        public string? Youtube {get; set;}
        public string? Spotify {get; set;}
        public string? TikTok {get; set;}
        public string? Twitter {get; set;}
    } 
}