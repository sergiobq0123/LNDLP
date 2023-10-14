namespace LNDP_API.Dtos {
    public class ArtistWebGenericDto{
        public int? Id {get;set;}
        public string? Name {get;set;}
        public string? PhotoUrl {get;set;}
        public SocialNetworkWebDto? SocialNetwork {get; set;}
    }
}